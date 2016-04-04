using System;

namespace Torilobby.Client
{

    public enum CommandType
    {
        Say,
        Disconnect,
        Spectate,
        Ping,
        Kick,
        Whisper,
        Ban,
        None
    }

    public class Command
    {
        // TODO: Move this elsewhere, possibly to enum
        public static string Chat = "SAY";
        public static string Bout = "BOUT";
        public static string Disconnect = "DISCONNECT";
        public static string Spectators = "SPECS";
        public static string Game = "GAME";
        public static string NewGame = "NEWGAME";
        public static string Ping = "PING";
        public static string BoutEndString = " -1 0 0 0 0 END 0";

        public string Name;
        public string Info;
        public string Value;

        // TODO: Implement Strategy pattern
        public Command(string name, string info, string value)
        {
            Name = name;
            Info = info;
            Value = value;
        }
        public override string ToString()
        {
            return String.Format("{0} {1};{2}", Name, Info, Value);
        }


    }
}