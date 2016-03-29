using Torilobby;

namespace Toribash.Bot
{
    public class CommandParser
    {
        public static Command Parse(string command)
        {

            var spaceMarker = command.IndexOf(' ');
            if (spaceMarker != -1)
            {
                var name = command.Substring(0, spaceMarker);
                var colonMarker = command.IndexOf(';');
                if (colonMarker != -1 && spaceMarker < colonMarker)
                {
                    var info = command.Substring(spaceMarker + 1, colonMarker - spaceMarker - 1);
                    var value = command.Substring(colonMarker + 1);

                    return new Command(name, info, value);
                }
                return new Command(name, command.Substring(spaceMarker + 1), "");
            }
            return new Command(command, "", "");
        }
    }
}