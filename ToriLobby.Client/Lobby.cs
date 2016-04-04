using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace Torilobby.Client
{
    public class Lobby
    {

        public string Hostname;
        public int Port;

        public int Players { get; private set; }
        public List<Room> Rooms = new List<Room>();


        public Lobby(string host, int port)
        {
            Hostname = host;
            Port = port;
        }

        public void Update()
        {
            TcpClient client = new TcpClient(Hostname, Port);
            StreamReader reader = new StreamReader(client.GetStream());

            string lobbyResponse = reader.ReadToEnd();

            List<Room> parsedRoomList = Parsers.LobbyParser.Parse(lobbyResponse);

            // Clear the rooms
            Rooms.Clear();

            // Replace with new list of rooms
            Rooms = parsedRoomList;

            Players = 0;

            foreach (Room room in Rooms)
            {
                Players += room.Players.Count;
            }
        }
    }
}
