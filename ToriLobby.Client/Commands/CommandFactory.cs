using System;
using Torilobby.Client;
using Torilobby.Client.Parsers;
using static Torilobby.Client.CommandType;

namespace ToriLobby.Client.Commands
{
    public static class CommandFactory
    {

        public static ICommand Create(string command)
        {
            CommandType commandType = CommandParser.Parse(command);
            return Create(commandType);
        }


        public static ICommand Create(CommandType commandType)
        {
            ICommand commandStrategy;

            switch (commandType)
            {
                case Say:
                    commandStrategy = new SayCommand();
                    break;

                case Disconnect:
                    commandStrategy = new DisconnectCommand();
                    break;

                case Spectate:
                    commandStrategy = new SpectateCommand();
                    break;

                case Ping:
                    commandStrategy = new PingCommand();
                    break;

                case Kick:
                    commandStrategy = new KickCommand();
                    break;

                case Whisper:
                    commandStrategy = new WhisperCommand();
                    break;

                case Ban:
                    commandStrategy = new BanCommand();
                    break;

                default:
                    commandStrategy = new DummyCommand();
                    break;
            }

            return commandStrategy;
        }
    }
}
