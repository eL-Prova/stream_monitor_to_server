using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace KerkPptStream.Stream
{
    public class StreamServer : IDisposable
    {
        private List<Socket> _clients;
        private Thread _thread;

        public StreamServer(StreamSnapshotManager snapshotManager) : this(snapshotManager.GenerateSnapshots()) { }
        private StreamServer(IEnumerable<Image> imagesSource)
        {
            _clients = new List<Socket>();
            _thread = null;

            ImagesSource = imagesSource;
            Interval = 50;
        }


        /// <summary>
        /// Gets or sets the source of images that will be streamed to the 
        /// any connected client.
        /// </summary>
        public IEnumerable<Image> ImagesSource { get; set; }

        /// <summary>
        /// Gets or sets the interval in milliseconds (or the delay time) between 
        /// the each image and the other of the stream (the default is . 
        /// </summary>
        public int Interval { get; set; }

        /// <summary>
        /// Gets a collection of client sockets.
        /// </summary>
        public IEnumerable<Socket> Clients { get { return _clients; } }

        /// <summary>
        /// Returns the status of the server. True means the server is currently 
        /// running and ready to serve any client requests.
        /// </summary>
        public bool IsRunning { get { return (_thread != null && _thread.IsAlive); } }

        /// <summary>
        /// Starts the server to accepts any new connections on the specified port.
        /// </summary>
        /// <param name="port"></param>
        public void Start(int port)
        {

            lock (this)
            {
                _thread = new Thread(new ParameterizedThreadStart(ServerThread))
                {
                    IsBackground = true
                };
                _thread.Start(port);
            }

        }

        /// <summary>
        /// Starts the server to accepts any new connections on the default port (8080).
        /// </summary>
        public void Start()
        {
            this.Start(8080);
        }

        public void Stop()
        {

            if (this.IsRunning)
            {
                try
                {
                    _thread.Join();
                    _thread.Abort();
                }
                finally
                {
                    lock (_clients)
                    {
                        foreach (var s in _clients)
                        {
                            try
                            {
                                s.Close();
                            }
                            catch { }
                        }
                        _clients.Clear();
                    }
                    _thread = null;
                }
            }
        }

        /// <summary>
        /// This the main thread of the server that serves all the new 
        /// connections from clients.
        /// </summary>
        /// <param name="state"></param>
        private void ServerThread(object state)
        {
            try
            {
                var Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                Server.Bind(new IPEndPoint(IPAddress.Any, (int)state));
                Server.Listen(10);

                Debug.WriteLine(string.Format("Server started on port {0}.", state));

                foreach (Socket client in Server.IncomingConnections())
                    ThreadPool.QueueUserWorkItem(new WaitCallback(ClientThread), client);

            }
            catch { }

            Stop();
        }

        /// <summary>
        /// Each client connection will be served by this thread.
        /// </summary>
        /// <param name="client"></param>
        private void ClientThread(object client)
        {
            var socket = client as Socket;

            Debug.WriteLine(string.Format("New client from {0}", socket.RemoteEndPoint.ToString()));

            lock (_clients)
                _clients.Add(socket);
            try
            {
                using (var wr = new StreamJPGWriter(new NetworkStream(socket, true)))
                {
                    wr.WriteHeader();
                    foreach (var imgStream in ImagesSource.GenerateMemoryStream())
                    {
                        if (Interval > 0)
                            Thread.Sleep(Interval);

                        wr.Write(imgStream);
                    }

                }
            }
            catch { }
            finally
            {
                lock (_clients)
                    _clients.Remove(socket);
            }
        }

        public void Dispose()
        {
            this.Stop();
        }
    }
}

