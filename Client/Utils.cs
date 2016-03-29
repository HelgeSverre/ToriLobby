using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Torilobby
{
    class Utils
    {
        // Move to authentication class?
        public static bool ValidateCredentials(string username, string password)
        { 
            // Construct the login URL
            string address = $"http://www.toribash.com/cp/login.php?username={username}&md5password={password}";

            // Connect to the url
            WebClient client = new WebClient();
            string response = client.DownloadString(address);

            // Check if the password was accepted
            return response == "PASS";
        }

        public static string HashPassword(string password)
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
    }
}
