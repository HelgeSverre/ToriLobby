using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torilobby.Client;
using ToriLobby.Client;

namespace Torilobby.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {

            Lobby lobby = new Lobby("game1.toribash.com", 22000);
            lobby.Update();
            List<Room> rooms = lobby.Rooms;

            Credentials creds = new Credentials("", "");
            
            for (int i = 0; i < rooms.Count; i++)
            {
                Console.WriteLine($"{i}\t - {rooms[i].Name}");
            }

            int selectedRoom = Int32.Parse(Console.ReadLine());



            Bot bot1 = new Bot(creds);
            bot1.Join(rooms[selectedRoom]);
            
            Console.Read();
        }
    }
}
