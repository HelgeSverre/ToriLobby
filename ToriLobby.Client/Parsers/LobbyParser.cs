using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Torilobby;

namespace Torilobby.Client.Parsers
{
    class LobbyParser
    {
        // TODO: Clean this up
        public static List<Room> Parse(string lobbyResponse)
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
                LobbyInfo.Add("INFO",       Regex.Match(room, "INFO 1; (?<unkown_1>.+)"));
                LobbyInfo.Add("SERVER",     Regex.Match(room, "SERVER 0; (?<ip_address>\\d+.\\d+.\\d+.\\d+):(?<port>\\d+) (?<name>.+)"));
                LobbyInfo.Add("DESC",       Regex.Match(room, "DESC 0;(?<description>.+)"));
                LobbyInfo.Add("NEWGAME",    Regex.Match(room, "NEWGAME 1;(?<mod>\\w+\\.tbm)"));
                LobbyInfo.Add("TMP",        Regex.Match(room, "NEWGAME 1;(?<rules>.+)"));
                LobbyInfo.Add("CLIENTS",    Regex.Match(room, "CLIENTS 2;(?<players>.+)"));

                // Convert tab delimited string of players to a list.
                string tmpPlayers = LobbyInfo["CLIENTS"].Groups["players"].ToString();
                List<string> playerUsernames = new List<string>(tmpPlayers.Split(
                    new string[] { "\t" },
                    StringSplitOptions.RemoveEmptyEntries
                ));

                List<Player> Players = new List<Player>();

                foreach (string playerUsername in playerUsernames)
                {
                    Player tmpPlayer = new Player(playerUsername);
                    Players.Add(tmpPlayer);
                }

                Rules parsedRules = RulesParser.Parse(LobbyInfo["TMP"].Groups["rules"].ToString());

                // Add the new gameroom with the parsed information
                tmpRooms.Add(new Room(
                    LobbyInfo["SERVER"].Groups["name"].ToString(),
                    Regex.Replace(LobbyInfo["DESC"].Groups["description"].ToString(), "\\^\\d+", ""),
                    Players,
                    LobbyInfo["SERVER"].Groups["ip_address"].ToString(),
                    Int32.Parse(LobbyInfo["SERVER"].Groups["port"].ToString()),
                    parsedRules
                ));
            }

            return tmpRooms;
        }
    }
}
