using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToriLobby.Client.Commands
{
    class DummyCommand : BaseCommand
    {
        public override void Perform(ToribashServerClient serverClient)
        {
            // Do nothing
            Console.WriteLine("Nothing");
        }
    }
}
