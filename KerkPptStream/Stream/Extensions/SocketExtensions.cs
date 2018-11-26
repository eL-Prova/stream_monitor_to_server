using System.Collections.Generic;
using System.Net.Sockets;

namespace KerkPptStream.Stream
{
    public static class SocketExtensions
    {
        public static IEnumerable<Socket> IncomingConnections(this Socket server)
        {
            while (true)
                yield return server.Accept();
        }
    }
}
