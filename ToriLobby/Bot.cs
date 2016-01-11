using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace ToriLobby
{
    class Bot
    {




        public static void createRoom(string name)
        {


            TcpClient client = new TcpClient("144.76.163.135", 22001);

            StreamReader sReader = new StreamReader(client.GetStream());

            string LobbyResponse = sReader.ReadToEnd();


        }



    }
}
