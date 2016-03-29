using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Timers;
using Toribash.Bot;
using Timer = System.Timers.Timer;

namespace Torilobby
{
    public class Bot
    {
        private TcpClient _socket;

        private StreamReader _reader;
        private StreamWriter _writer;

        private Room _currentRoom;

        private readonly string _username;
        private readonly string _password;

        public Timer PingTimer = new Timer(10000);


        // Used when building the user list, can be partial
        //  not to be used to show bouts
        private List<Bout> _tempUsers = new List<Bout>();

        // Complete User list
        public List<Bout> Users = new List<Bout>();




        public Bot(string username, string password)
        {
            // Setup authentication
            _username = username;
            _password = Utils.HashPassword(password);

            // Check if the credentials are valid
            if (!Utils.ValidateCredentials(_username, _password))
            {
                throw new ArgumentException("Invalid username or password");
            }

            PingTimer.Elapsed += PingTimerOnElapsed;
        }

        public void Join(Room room)
        {
            _currentRoom = room;

            Console.WriteLine($"Connecting to {room.IPAddress}:{room.Port}");

            // Create a new TcpSocketClient
            _socket = new TcpClient(room.IPAddress, room.Port);
            _reader = new StreamReader(_socket.GetStream());
            _writer = new StreamWriter(_socket.GetStream())
            {
                AutoFlush = true
            };

            Login();
            ReadLoop();

        }

        private void Login()
        {
            _writer.WriteLine($"mlogin {_username} {_password}");
            _writer.WriteLine("SPEC");
            PingTimer.Start();
        }

        // An event that fires when the bot detects a chat line
        public delegate void CommandReceivedHandler(Command line);
        public event CommandReceivedHandler ChatRecieved;
        protected virtual void OnChatRecieved(Command line)
        {
            if (ChatRecieved != null) ChatRecieved(line);
        }

        public event CommandReceivedHandler CommandRecieved;
        protected virtual void OnCommandRecieved(Command line)
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
            while (_socket.Connected)
            {
                string line = await _reader.ReadLineAsync();

                if (line != null) // If the line is null that means the connection has ended.
                {
                    // Convert the line to a BashCommand and then process it
                    Console.WriteLine(line);
                    Command command = CommandParser.Parse(line);
                    ProcessCommand(command);

                }
                else
                {
                    // If we disconnect, try to reconnect!
                    Console.WriteLine("Disconnected, Reconnecting..");
                    _socket = new TcpClient();
                    Login();
                }
            }
        }

        // Stops the bot!
        public void Stop()
        {
            if (_socket.Connected)
            {
                _writer.WriteLine("DISCONNECT BYE!");
                _socket.Close();
            }

            PingTimer.Stop();
        }

        private void ProcessCommand(Command command)
        {

            // Send the command to all event handlers
            OnCommandRecieved(command);

            if (command.Name == Command.Chat)
            {
                // Send the chat to all event handlers
                OnChatRecieved(command);
            }
            else if (command.Name == Command.Bout)
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
        }


        private void PingTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("PING");
            _writer.Write("PING");
        }

        public void Send(string command)
        {
            if (_socket.Connected)
            {
                _writer.WriteLine(command);
            }
        }

        // Sends a BashCommand
        public void Send(Command command)
        {
            Send(command.ToString());
        }
    }
}
