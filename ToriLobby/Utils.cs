using System;
using System.Linq;
using System.Globalization;

namespace ToriLobby
{
    class Utils
    {

        

        // TODO: Implement default fallback for gamerules, (maybe it grabs it from the mod instead?)
        public static Rules ParseGameRules(string GameRulesString)
        {

            Rules rules = new Rules();

            string[] RulesArray = GameRulesString.Split(
                 new string[] { " " },
                 StringSplitOptions.RemoveEmptyEntries
             );

            // Catch any errors from Int32.Parse, if that fails, just quit cause my program cant parse the rules correctly.
            try { 
                rules.Matchframes = Int32.Parse(RulesArray[0]);
                rules.TurnFrames = RulesArray[1].Split(
                    new string[] { "," },
                    StringSplitOptions.RemoveEmptyEntries
                ).Select(int.Parse).ToList();
                rules.ReactionTime = Int32.Parse(RulesArray[2]);
                // rules.unknown_1 = Int32.Parse(tmp[3]);
                // rules.unknown_2 = Int32.Parse(tmp[4]);
                rules.Flags = Int32.Parse(RulesArray[5]);
                rules.EngageDistance = Int32.Parse(RulesArray[6]);
                rules.Damage = Int32.Parse(RulesArray[7]);
                rules.Sumo = Int32.Parse(RulesArray[8]);
                rules.Mod = RulesArray[9];
                // rules.unknown_3 = Int32.Parse(tmp[10]);
                rules.DojoSize = Int32.Parse(RulesArray[11]);
                rules.DismemberThreshold = Int32.Parse(RulesArray[12]);
                rules.FractureThreshold = Int32.Parse(RulesArray[13]);
                rules.EngageHeight = Int32.Parse(RulesArray[14]);
                // rules.unknown_4 = Int32.Parse(tmp[15]);
                // rules.unknown_5 = Int32.Parse(tmp[16]);
                // rules.unknown_6 = Int32.Parse(tmp[17]);
                // rules.unknown_7 = Int32.Parse(tmp[18]);                  
                rules.EngageRotation = Int32.Parse(RulesArray[19]);
                // rules.unknown_8 = Int32.Parse(tmp[20]);;
                rules.EngageSpace = Int32.Parse(RulesArray[21]);
                rules.DQTimeOut = Int32.Parse(RulesArray[22]);
                // rules.unknown_9 = Int32.Parse(tmp[23]);;
                rules.DojoType = Int32.Parse(RulesArray[24]);

                // These have to be parsed using the American decimal seperator, can't rely on the user's computer localization being correct.
                rules.GravityX = float.Parse(RulesArray[25], NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"));
                rules.GravityZ = float.Parse(RulesArray[26], NumberStyles.Number, CultureInfo.CreateSpecificCulture ("en-US" ));
                rules.GravityY = float.Parse(RulesArray[27], NumberStyles.Number, CultureInfo.CreateSpecificCulture ("en-US" ));


                rules.DQFlag = Int32.Parse(RulesArray[28]);
                // rules.unknown_10 = Int32.Parse(tmp[29]);
                rules.DrawWinner = (RulesArray[30] == "1"); // "convert" to bool
                rules.PointThreshold = Int32.Parse(RulesArray[31]);
                rules.MaxContacts = Int32.Parse(RulesArray[32]);
            } catch (IndexOutOfRangeException e) {
                // Ignore IndexOutOfRange Exceptions because if the value doesnt exist, and it should fallback to a default
            }

            return rules;
        }

    }
}
