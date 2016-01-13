using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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

            // TODO: Move this somewhere else maybe
            // Remove the clan name from the username
            Username = Regex.Replace(user, "\\[.*\\]|\\(.*\\)", "");
        }

        // TODO: Create properties and use them instead of using this, or populate propeties with this method
        public static Dictionary<string, string> getStats(string user)
        {
            // Connect to the player stat webservice
            WebRequest request = WebRequest.Create(String.Format(PlayerStatUrl, user));
            request.ContentType = "application/json; charset=utf-8";

            // Get the response stream and read all the text returned
            WebResponse response = request.GetResponse();
            var sr = new StreamReader(response.GetResponseStream());
            var text = sr.ReadToEnd();

            // Parse the JSON stats into an object
            dynamic PlayerStatObject = JsonConvert.DeserializeObject(text);

            // Create tmp dictionary for statistics
            // NAUGHTY NAUGHTY STRINGS, BAD HELGE BAAAAAAAD!!!!
            Dictionary<string, string> tmpStats = new Dictionary<string, string>();


            // Add all the stats from the PlayerAStatObject to the tmpstat

            tmpStats.Add("Username", PlayerStatObject.username.ToString());
            tmpStats.Add("Id", PlayerStatObject.userid.ToString());

            // TODO: Convert to human readable date string
            tmpStats.Add("Join Date", PlayerStatObject.joindate.ToString()); 
            tmpStats.Add("Last Activity", PlayerStatObject.lastactivity.ToString());
            tmpStats.Add("Last InGame", PlayerStatObject.lastingame.ToString());
            
            tmpStats.Add("Posts", PlayerStatObject.posts.ToString());
            tmpStats.Add("Achievement Progress", PlayerStatObject.achiev_progress.ToString());
            tmpStats.Add("Belt", PlayerStatObject.belt.ToString());
            tmpStats.Add("Belt Rank", PlayerStatObject.beltrank.ToString());

            // Only add this if it is not the default value
            if (PlayerStatObject.belttitle.ToString() != " Belt")
            {
                tmpStats.Add("Belt Title", PlayerStatObject.belttitle.ToString());
            }

            tmpStats.Add("Clan Name", PlayerStatObject.clanname.ToString());
            tmpStats.Add("Clan Tag", PlayerStatObject.clantag.ToString());
            tmpStats.Add("ELO", PlayerStatObject.elo.ToString());
            tmpStats.Add("Win Ratio", PlayerStatObject.winratio.ToString());
            tmpStats.Add("ToriCredits", PlayerStatObject.tc.ToString());
            // Not needed atm
            // tmpStats.Add("Room", PlayerStatObject.room);


            // Return the stats
            return tmpStats;
        }


        // TODO: Remove, never used
        internal static dynamic getPlayerStats(string username)
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
