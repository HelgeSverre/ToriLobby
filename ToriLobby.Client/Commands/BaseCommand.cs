using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ToriLobby.Client.Commands
{
    abstract class BaseCommand : ICommand
    {
        public abstract void Perform(ToribashServerClient serverClient);
    }
}
