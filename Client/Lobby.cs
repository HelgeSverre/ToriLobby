using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using Toribash.Bot;

namespace Torilobby
{
    public class Lobby
    {
        // List of rooms in this lobby
        private List<Room> _rooms = new List<Room>();

        public string Hostname;
        public int Port;

        private int _totalPlayers;

        public Lobby(string host, int port)
        {
            Hostname = host;
            Port = port;

        }


        public List<Room> GetRooms()
        {
            return _rooms;
        }

        public void Update()
        {
            TcpClient client = new TcpClient(Hostname, Port);
            StreamReader reader = new StreamReader(client.GetStream());

            string lobbyResponse = reader.ReadToEnd();

            List<Room> parsedRoomList = ParseRooms(lobbyResponse);

            // Clear the rooms
            _rooms.Clear();

            // Replace with new list of rooms
            _rooms = parsedRoomList;

            _totalPlayers = 0;

            foreach (Room room in _rooms)
            {
                _totalPlayers += room.Players.Count;
            }
        }

        public int GetTotalPlayers()
        {
            return _totalPlayers;
        }


        private List<Room> ParseRooms(string lobbyResponse)
        {

            List<Room> tmpRooms = new List<Room>();

            // Each gameroom data structure is prefixed by "TORIBASH 30\n"
            string[] tmpGameRooms = lobbyResponse.Split(
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
                List<string> PlayerUsernames = new List<string>(tmpPlayers.Split(
                    new string[] { "\t" },
                    StringSplitOptions.RemoveEmptyEntries
                ));

                List<Player> Players = new List<Player>();

                foreach (string playerUsername in PlayerUsernames)
                {
                    Player tmpPlayer = new Player(playerUsername);
                    Players.Add(tmpPlayer);
                }

                Rules ParsedRules = RulesParser.Parse(LobbyInfo["TMP"].Groups["rules"].ToString());

                // Add the new gameroom with the parsed information
                tmpRooms.Add(new Room(
                    LobbyInfo["SERVER"].Groups["name"].ToString(),
                    Regex.Replace(LobbyInfo["DESC"].Groups["description"].ToString(), "\\^\\d+", ""),
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
