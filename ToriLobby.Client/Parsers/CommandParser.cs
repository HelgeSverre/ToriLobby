using System;

namespace Torilobby.Client.Parsers
{
    public class CommandParser
    {
        /** 
         * This is the command parser, it should return the type of command, 
         * this info shall be used by the CommandFactory to select a 
         * Command class that implements the ICommand interface. 
         */
        public static CommandType Parse(string command)
        {
            var spaceMarker = command.IndexOf(' ');
            if (spaceMarker != -1)
            {
                string commandName = command.Substring(0, spaceMarker);

                if (!String.IsNullOrWhiteSpace(commandName))
                {
                    try
                    {
                        return (CommandType)Enum.Parse(typeof(CommandType), commandName);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Could not parse command string to Enum");
                    }
                }
            }

            Console.WriteLine("Command string could not be parsed.");

            return CommandType.None;
        }
    }
}