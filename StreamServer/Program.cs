using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace StreamServer
{
    class Program
    {
        const int PORT_NO = 5000;
        const string SERVER_IP = "127.0.0.1";

        static void Main(string[] args)
        {
            IPAddress localAdd = IPAddress.Parse(SERVER_IP);
            TcpListener listener = new TcpListener(localAdd, PORT_NO);
            Console.WriteLine("Listening...");
            listener.Start();

            //---incoming client connected---
            TcpClient client = listener.AcceptTcpClient();

            //---get the incoming data through a network stream---
            NetworkStream nwStream = client.GetStream();

            //---convert the data received into a string---
            Image dataReceived = Image.FromStream(nwStream);
            dataReceived.Save($"{DateTime.Now.ToString()}.jpg", ImageFormat.Jpeg);
            Console.WriteLine("Received : " + dataReceived.Size.ToString());

            //---write back the text to the client---
            //Console.WriteLine("Sending back : " + dataReceived);
            //nwStream.Write(buffer, 0, bytesRead);
            //client.Close();
            //listener.Stop();
            Console.ReadLine();
        }
    }
}
