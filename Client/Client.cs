using System;
using System.IO;
using System.Net.Sockets;
using System.Timers;

namespace Client
{
    class Client
    {

        private bool connected;
        private TcpClient _socket;

        private StreamReader _reader;
        private StreamWriter _writer;

        private Room _currentRoom;

        private readonly string _username;
        private readonly string _password;



        public Client(string username, string password)
        {
            // Setup authentication
            _username = username;
            _password = Utils.HashPassword(password);

            // Check if the credentials are valid
            if (!Utils.ValidateCredentials(_username, _password))
            {
                throw new ArgumentException("Invalid username or password");
            }
        }

        public void Join(Room room)
        {
            _currentRoom = room;

            // Create a new TcpSocketClient
            _socket = new TcpClient(room.IPAddress, room.Port);
            _reader = new StreamReader(_socket.GetStream());
            _writer = new StreamWriter(_socket.GetStream());

            // Authenticate to room
            _writer.Write($"mlogin {_username} {_password}");

            // if we connected
            connected = true;


            // Setup a pinger, if we dont ping the server regularly, we get kicked out.
            Timer pingTimer = new Timer(10000);
            pingTimer.Elapsed += (o, args) => _writer.Write("PING");
        }


        private void Loop()
        {
            string data = "";

            while (connected)
            {

                if (_socket.Available > 0)
                {
                    data = _reader.ReadLine();
                }

                Console.WriteLine(data);

            }
        }
    }
}
