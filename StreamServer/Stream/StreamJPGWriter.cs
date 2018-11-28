using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace StreamServer.Stream
{
    public class StreamJPGWriter : IDisposable
    {
        public StreamJPGWriter(System.IO.Stream stream)
            : this(stream, "--boundary")
        {

        }

        public StreamJPGWriter(System.IO.Stream stream, string boundary)
        {

            Stream = stream;
            Boundary = boundary;
        }

        public string Boundary { get; private set; }
        public System.IO.Stream Stream { get; private set; }

        public void WriteHeader()
        {
            Write(
                    "HTTP/1.1 200 OK\r\n" +
                    "Content-Type: multipart/x-mixed-replace; boundary=" +
                    Boundary +
                    "\r\n"
                 );

            Stream.Flush();
        }

        public void Write(Image image) => Write(BytesOf(image));

        public void Write(MemoryStream imageStream)
        {

            var sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine(Boundary);
            sb.AppendLine("Content-Type: image/jpeg");
            sb.AppendLine("Content-Length: " + imageStream.Length);
            sb.AppendLine();

            Write(sb.ToString());
            imageStream.WriteTo(Stream);
            Write("\r\n");

            Stream.Flush();

        }

        private void Write(string text)
        {
            var data = BytesOf(text);
            Stream.Write(data, 0, data.Length);
        }

        private static byte[] BytesOf(string text)
        {
            return Encoding.ASCII.GetBytes(text);
        }

        private static MemoryStream BytesOf(Image image)
        {
            var ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);

            return ms;
        }

        public string ReadRequest(int length)
        {

            var data = new byte[length];
            var count = Stream.Read(data, 0, data.Length);

            if (count != 0)
                return Encoding.ASCII.GetString(data, 0, count);

            return null;
        }

        public void Dispose()
        {
            try
            {
                if (Stream != null)
                    Stream.Dispose();
            }
            finally
            {
                Stream = null;
            }
        }
    }
}
