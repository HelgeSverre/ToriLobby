using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Timers;
using Torilobby.Client.Parsers;
using ToriLobby.Client;
using ToriLobby.Client.Commands;
using Timer = System.Timers.Timer;

namespace Torilobby.Client
{
    public class Bot
    {
        private ToribashServerClient _serverClient;
        private readonly Credentials _credentials;
        private readonly Timer _pingTimer = new Timer(10000);

        // Complete User list
        public List<Bout> Users = new List<Bout>();


        private Room currentRoom;




        public Bot(Credentials credentials)
        {
            _credentials = credentials;
            _pingTimer.Elapsed += PingTimerOnElapsed;
        }

        public void Join(string ip, int port)
        {

            Console.WriteLine($"Connecting to {ip}:{port}");

            // Create a new TcpSocketClient
            _serverClient = new ToribashServerClient(ip, port);

            Login();
            ReadLoop();
        }

        public void Join(Room room)
        {
            currentRoom = room;


            Console.WriteLine($"Connecting to {room.IPAddress}:{room.Port}");

            // Create a new TcpSocketClient
            _serverClient = new ToribashServerClient(room.IPAddress, room.Port);

            Login();
            ReadLoop();

        }

        private void Login()
        {
            _serverClient.Send(_credentials.GetLoginString());
            _serverClient.Send("SPEC");

            _pingTimer.Start();
        }

        // An event that fires when the bot detects a chat line
        public delegate void CommandReceivedHandler(ICommand command);
        public event CommandReceivedHandler ChatRecieved;
        protected virtual void OnChatRecieved(ICommand command)
        {
            if (ChatRecieved != null) ChatRecieved(command);
        }

        public event CommandReceivedHandler CommandRecieved;
        protected virtual void OnCommandRecieved(ICommand line)
        {
            if (CommandRecieved != null) CommandRecieved(line);
        }

        // An event that happens when the Bout list is updated.
        public delegate void BoutListUpdateHandler(List<Bout> bouts);
        public event BoutListUpdateHandler BoutListUpdate;
        protected virtual void OnBoutListUpdate(List<Bout> bouts)
        {
            if (BoutListUpdate != null) BoutListUpdate(bouts);
        }


        private async void ReadLoop()
        {
            while (_serverClient.Connected)
            {
                Console.WriteLine("Loop");

                string line = await _serverClient.Reader.ReadLineAsync();

                if (line != null) // If the line is null that means the connection has ended.
                {

                    if (line.Contains("FORWARD"))
                    {
                        Console.WriteLine("Forward requested, not handled, quiting");
                        break;
                    }

                    // Convert the line to a BashCommand and then process it

                    // TODO: Construct a command execution framework thing

                    Console.WriteLine(line);
                    CommandType commandType = CommandParser.Parse(line);

                    ProcessCommand(commandType);

                    // ICommand command = CommandFactory.Create(line);
                    // ProcessCommand(command);

                }
                else
                {
                    // If we disconnect, try to reconnect!
                    Console.WriteLine("Disconnected, Reconnecting..");
                    _serverClient = new ToribashServerClient(currentRoom.IPAddress, currentRoom.Port);

                    Console.WriteLine("Logging in");
                    Login();

                }
            }
        }

        // Stops the bot!
        public void Stop()
        {
            if (_serverClient.Connected)
            {
                _serverClient.Send("DISCONNECT BYE!");
                _serverClient.Close();
            }

            _pingTimer.Stop();
        }

        private void ProcessCommand(CommandType commandType)
        {

            ICommand command = CommandFactory.Create(commandType);

            // TODO: Refactor everything

            // Send the command to all event handlers
            OnCommandRecieved(command);

            if (commandType == CommandType.Say)
            {
                // Send the chat to all event handlers
                OnChatRecieved(command);
            }

            command.Perform(_serverClient);

            /*


            // TODO: This should be handled in a different way
            if (command.Name == Command.Bout)
            {
                if (command.Value == Command.BoutEndString)
                {
                    // Here we have built up _tempUsers fully
                    //  so we set Users to _tempUsers
                    //  and create a new List for the next BOUT list
                    Users = _tempUsers;
                    _tempUsers = new List<Bout>();
                    // Send the users to all event handlers
                    OnBoutListUpdate(Users);
                }
                else
                {
                    // Parse and add the bout to the temporary list
                    var bout = BoutParser.Parse(command.Value);
                    _tempUsers.Add(bout);
                }
            }
            */
        }


        private void PingTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            PingCommand pingCommand = new PingCommand();
            pingCommand.Perform(_serverClient);
        }
    }
}
