using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Client
{
    public class Client
    {
        private TcpClient _socket;

        private StreamReader _reader;
        private StreamWriter _writer;

        private Room _currentRoom;

        private readonly string _username;
        private readonly string _password;

        public Timer PingTimer = new Timer(30000);



        public Client(string username, string password)
        {
            // Setup authentication
            _username = username;
            _password = Utils.HashPassword(password);


            // TODO: Move to login function
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
            PingTimer.Start();
        }



        private async void ReadLoop()
        {
            while (_socket.Connected)
            {
                // Asyncronously read line
                var line = await _reader.ReadLineAsync();
                if (line != null) // If the line is null that means the connection has ended.
                {
                    // Convert the line to a BashCommand and then process it
                    Console.WriteLine(line);
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


        private void PingTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("ping");
            _writer.Write("PING");
        }
    }
}
