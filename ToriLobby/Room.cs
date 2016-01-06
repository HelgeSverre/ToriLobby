using System.Collections.Generic;
using System.Net;

namespace ToriLobby
{
    public struct Room
    {

        public string IPAddress { get; set; }
        public int Port { get; set; }

        // Name of the room
        public string Name { get; set; }

        // Description of the room
        public string Description { get; set; }

        // The gamerules currently active in this room
        public Rules GameRules { get; set; }

        // Array of player names in this room
        public List<string> Players { get; set; }


        public Room(string name, string desc, List<string> players, string ip, int port, Rules rules)
        {
            Name = name;
            Description = desc;
            IPAddress = ip;
            Port = port;
            Players = players;
            GameRules = rules;
        }
    }
}
