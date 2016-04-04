using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToriLobby.Client.Commands
{
    class PingCommand : BaseCommand
    {
        public override void Perform(ToribashServerClient serverClient)
        {
            serverClient.Send("PING");
        }
    }
}
