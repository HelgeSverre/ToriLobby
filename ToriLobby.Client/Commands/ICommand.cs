using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ToriLobby.Client.Commands
{
    public interface ICommand
    {
        void Perform(ToribashServerClient serverClient);
    }
}
