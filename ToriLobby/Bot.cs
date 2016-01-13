using System;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Net;

namespace ToriLobby
{
    class Bot
    {

        private TcpClient BotSocket;

        private StreamReader Reader;
        private StreamWriter Writer;

        private string CurrentRoom = null;

        private string Username;
        private string Password;



        public Bot(string username, string password, string host, int port)
        {
            // Create a new TcpSocketClient
            BotSocket = new TcpClient(host, port);
            Reader = new StreamReader(BotSocket.GetStream());
            Writer = new StreamWriter(BotSocket.GetStream());


            // Setup authentication
            Username = username;
            Password = HashPassword(password);

            // Check if the credentials are valid
            if (ValidateCredientials(Username, Password))
            {

            }
            else
            {
                throw new ArgumentException("Invalid username or password");
            }
        }


        
        // Gets host info from lobby object
        public Bot(string username, string password, Lobby lobby)
        {
            // Create a new TcpSocketClient
            BotSocket = new TcpClient(lobby.Hostname, lobby.Port);
            Reader = new StreamReader(BotSocket.GetStream());
            Writer = new StreamWriter(BotSocket.GetStream());


            // Setup authentication
            Username = username;
            Password = HashPassword(password);

            // Check if the credentials are valid
            if (ValidateCredientials(Username, Password))
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new ArgumentException("Invalid username or password");
            }

        }
       

        public bool Join(string RoomName)
        {

            // We are connected to a lobby, we need to ask the lobby what ip and port to connect to to join the room
        
            Writer.WriteLine("join {0}", RoomName);
            Writer.WriteLine("PING");

            // TODO: This does not work, I might have misunderstood how sockets work....
            string response = Reader.ReadLine();

            // If the line i got includes this, the next line will be the FORWARD ip and port
            if (response == "TORILOBBY 0;0")
            {
                response = Reader.ReadLine();

                // Regex the response to grab the data we need
                Match ForwardMatch = Regex.Match(response, "FORWARD 0;(?<ip>.+):(?<port>\\d+)");

                // Extract the IP and PORT from the regex match
                string ip   = ForwardMatch.Groups["ip"].ToString();
                int port    = Int32.Parse(ForwardMatch.Groups["port"].ToString());

                // Connect to new server
                BotSocket.Connect(ip, port);


                /* 
                
                I suspect that the hashes are the salted md5 password, not sure what 
                the salt would be though, gotta put Toribash into Ollydbg or IDA to figure it out. 

                FORMAT: mlogin [username] [unknown_md5_hash_1] [unknown_int] [unknown_md5_hash_2]

                */

                // Authenticate to the room
                Writer.WriteLine("mlogin {0} {1} {2} {3}");

                // If we have been authenticated correctly and we are connected, set room as 
                CurrentRoom = RoomName;


                return true;
            }
            else
            {
                throw new Exception("Not sure what to do now.");
            }
        }





        public void SendChatMessage(string Message)
        {
            throw new NotImplementedException();
        }


        // Move elsewhre
        struct ChatMessage
        {
            public string Username;
            public DateTime Received;
            public string Text;
        }

        // TODO: Move to utils class or something
        private string HashPassword(string password)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString().ToLower();
        }


        // Move to authentication class?
        private bool ValidateCredientials(string username, string password)
        {

            // Construct the login URL
            string address = string.Format(
                "http://www.toribash.com/cp/login.php?username={0}&md5password={1}",
                username,
                password
            );

            // Connect to the url
            WebClient client = new WebClient();
            var response = client.DownloadString(address);

            // Check if the password was accepted
            if (response == "PASS")
            {
                return true;
            }

            return false;
        }
    }
}
