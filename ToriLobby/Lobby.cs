using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.IO;
using System.Text.RegularExpressions;

namespace ToriLobby
{
    class Lobby
    {
        // List of rooms in this lobby
        private List<Room> Rooms = new List<Room>();

        private string Hostname;
        private int Port;

        private int totalPlayers;

        public Lobby (string host, int port)
        {
            Hostname = host;
            Port = port;

        }


        public List<Room> GetRooms()
        {
            return Rooms;
        }

        public void Update()
        {
            TcpClient client = new TcpClient(Hostname, Port);
            StreamReader sReader = new StreamReader(client.GetStream());

            string LobbyResponse = sReader.ReadToEnd();

            var ParsedRoomList = ParseRooms(LobbyResponse);

            // Clear the rooms
            Rooms.Clear();

            // Replace with new list of rooms
            Rooms = ParsedRoomList;

            totalPlayers = 0;

            foreach (Room room in Rooms)
            {
                totalPlayers += room.Players.Count;
            }
        }

        public int getTotalPlayers()
        {
            return totalPlayers;
        }


        private List<Room> ParseRooms(string LobbyResponse)
        {

            List<Room> tmpRooms = new List<Room>();

            // Each gameroom data structure is prefixed by "TORIBASH 30\n"
            string[] tmpGameRooms = LobbyResponse.Split(
                new string[] { "TORIBASH 30\n" },
                StringSplitOptions.RemoveEmptyEntries
            );

            foreach (string room in tmpGameRooms)
            {
                // Regex the shit out of it.
                Dictionary<string, Match> LobbyInfo = new Dictionary<string, Match>();
            
                // Add Regex Matches to LobbyInfo dictionary

                // TODO: The INFO values are unknown, needs to be reverse engineered.
                LobbyInfo.Add("INFO", Regex.Match(room, "INFO 1; (?<unkown_1>.+)"));
                LobbyInfo.Add("SERVER", Regex.Match(room, "SERVER 0; (?<ip_address>\\d+.\\d+.\\d+.\\d+):(?<port>\\d+) (?<name>.+)"));
                LobbyInfo.Add("DESC", Regex.Match(room, "DESC 0;(?<description>.+)"));
                LobbyInfo.Add("NEWGAME", Regex.Match(room, "NEWGAME 1;(?<mod>\\w+\\.tbm)"));
                LobbyInfo.Add("TMP", Regex.Match(room, "NEWGAME 1;(?<rules>.+)"));
                LobbyInfo.Add("CLIENTS", Regex.Match(room, "CLIENTS 2;(?<players>.+)"));

                // Convert tab delimited string of players to a list.
                string tmpPlayers = LobbyInfo["CLIENTS"].Groups["players"].ToString();
                List<string> Players = new List<string>(tmpPlayers.Split(
                    new string[] { "\t" },
                    StringSplitOptions.RemoveEmptyEntries
                ));

                Rules ParsedRules = Utils.ParseGameRules(LobbyInfo["TMP"].Groups["rules"].ToString());

                // Add the new gameroom with the parsed information
                tmpRooms.Add(new Room(
                    LobbyInfo["SERVER"].Groups["name"].ToString(),
                    LobbyInfo["DESC"].Groups["description"].ToString(),
                    Players,
                    LobbyInfo["SERVER"].Groups["ip_address"].ToString(),
                    Int32.Parse(LobbyInfo["SERVER"].Groups["port"].ToString()),
                    ParsedRules
                ));
            }

            return tmpRooms;
        }

    }
}
