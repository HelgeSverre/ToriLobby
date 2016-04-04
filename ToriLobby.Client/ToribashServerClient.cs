using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ToriLobby.Client
{
    public class ToribashServerClient : TcpClient
    {
        public StreamReader Reader;
        public StreamWriter Writer;

        public ToribashServerClient(string hostname, int port) : base(hostname, port)
        {
            Reader = new StreamReader(GetStream());
            Writer = new StreamWriter(GetStream())
            {
                AutoFlush = true
            };
        }

        public ToribashServerClient() : base() { }


        public void Send(string line)
        {
            if (Connected)
            {
                Writer.WriteLine(line);
            }
        }
    }
}
