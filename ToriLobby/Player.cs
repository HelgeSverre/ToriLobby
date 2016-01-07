using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace ToriLobby
{
    public class Player
    {
        
        public string Username { get; }
        /*
        public int Id { get; }
        public DateTime Joined { get; }
        public DateTime LastActivity { get; }
        public DateTime LastInGame { get; }
        public int ToriCredits { get; }
        public string BeltName { get; }
        public int BeltRank { get; }
        public float WinRatio { get; }
        public float Elo{ get; }
        */

        public static string PlayerStatUrl = "http://forum.toribash.com/tori_stats.php?username={0}&format=json";

        public Player (string user)
        {
            Username = user;
        }
        

        public dynamic getStats()
        {
            WebRequest request = WebRequest.Create(String.Format(PlayerStatUrl, Username));
            request.ContentType = "application/json; charset=utf-8";
            WebResponse response = request.GetResponse();
            var sr = new StreamReader(response.GetResponseStream());
            var text = sr.ReadToEnd();

            dynamic PlayerStatObject = JsonConvert.DeserializeObject(text);

            return PlayerStatObject;
        }


        public static dynamic getPlayerStats(string username)
        {

            WebRequest request = WebRequest.Create(String.Format(PlayerStatUrl, username));
            request.ContentType = "application/json; charset=utf-8";
            WebResponse response = request.GetResponse();
            var sr = new StreamReader(response.GetResponseStream());
            var text = sr.ReadToEnd();

            dynamic PlayerStatObject = JsonConvert.DeserializeObject(text);

            return PlayerStatObject;
        }

    }
}
