using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace StreamServer
{
    //Example from: https://stackoverflow.com/questions/10182751/server-client-send-receive-simple-text
    class Program
    {
        const int PORT_NO = 5000;
        const string SERVER_IP = "127.0.0.1";

        static void Main(string[] args)
        {
            var connectionClosed = true;
            while (connectionClosed)
            {
                connectionClosed = false;
                IPAddress localAdd = IPAddress.Parse(SERVER_IP);
                TcpListener listener = new TcpListener(localAdd, PORT_NO);
                Console.WriteLine("Listening...");
                listener.Start();

                //---incoming client connected---
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Connected!");

                //---get the incoming data through a network stream---
                NetworkStream nwStream = client.GetStream();

                while (client.Connected)
                {
                    byte[] bytesToRead = new byte[client.ReceiveBufferSize];
                    int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);

                    if(bytesRead > 0)
                    {
                        using (var ms = new MemoryStream(bytesToRead))
                        {
                            using (Image dataReceived = Image.FromStream(ms))
                            {
                                dataReceived.Save($"{Guid.NewGuid()}.jpg", ImageFormat.Jpeg);
                                Console.WriteLine("Received : " + dataReceived.Size.ToString());
                            }
                        }
                    }
                    //using (BinaryReader reader = new BinaryReader(nwStream))
                    //{
                    //    int ctBytes = reader.ReadInt32();

                    //    //byte[] buffer = new byte[client.ReceiveBufferSize];
                    //    //int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

                    //    using (var ms = new MemoryStream(reader.ReadBytes(client.ReceiveBufferSize)))
                    //    {
                    //        Image dataReceived = Image.FromStream(ms);
                    //        dataReceived.Save($"{DateTime.Now.ToString()}.jpg", ImageFormat.Jpeg);
                    //        Console.WriteLine("Received : " + dataReceived.Size.ToString());
                    //    }

                    //    //string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    //}
                }
                //---convert the data received into a string---
                //Image dataReceived = Image.FromStream(nwStream);
                //dataReceived.Save($"{DateTime.Now.ToString()}.jpg", ImageFormat.Jpeg);
                //Console.WriteLine("Received : " + dataReceived.Size.ToString());

                //---write back the text to the client---
                //Console.WriteLine("Sending back : " + dataReceived);
                //nwStream.Write(buffer, 0, bytesRead);
                client.Close();
                listener.Stop();
                connectionClosed = true;
            }
        }
    }
}
