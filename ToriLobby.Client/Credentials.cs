using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace ToriLobby.Client
{
    public class Credentials
    {
        private string _password;

        public string Username { get; set; }
        public string Md5Password { get; private set; }
        public string Password
        {
            get { return _password; }
            set
            {
                // When assigning a new plaintext password, calculate new MD5 password as well
                _password = value;
                Md5Password = HashPassword(value);
            }
        }

        public Credentials(string username, string password)
        {
            Username = username;
            Password = password;
            Md5Password = HashPassword(password);
        }

        public bool Validate()
        {
            // Construct the login URL
            string address = $"http://www.toribash.com/cp/login.php?username={Username}&md5password={Md5Password}";

            // Connect to the url
            WebClient client = new WebClient();
            string response = client.DownloadString(address);

            // Check if the password was accepted
            return response == "PASS";
        }

        public static string HashPassword(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits for each byte
                strBuilder.Append(i.ToString("x2"));
            }

            return strBuilder.ToString();
        }

        public string GetLoginString()
        {
            return $"mlogin {Username} {Md5Password}";
        }
    }
}
