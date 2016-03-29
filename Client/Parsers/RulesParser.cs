using System;
using System.Globalization;
using System.Linq;
using Toribash.Bot;

namespace Torilobby
{
    class RulesParser
    {
        public static Rules Parse(string gameRulesString)
        {

            string[] rulesArray = gameRulesString.Split(
                new[] {" "},
                StringSplitOptions.RemoveEmptyEntries
                );

            try
            {
                return new Rules()
                {
                    Matchframes = Int32.Parse(rulesArray[0]),
                    TurnFrames = rulesArray[1].Split(
                        new[] {","},
                        StringSplitOptions.RemoveEmptyEntries
                        ).Select(int.Parse).ToList(),

                    ReactionTime = Int32.Parse(rulesArray[2]),
                    // rules.unknown_1 = Int32.Parse(tmp[3]);
                    // rules.unknown_2 = Int32.Parse(tmp[4]);
                    Flags = Int32.Parse(rulesArray[5]),
                    EngageDistance = Int32.Parse(rulesArray[6]),
                    Damage = Int32.Parse(rulesArray[7]),
                    Sumo = Int32.Parse(rulesArray[8]),
                    Mod = rulesArray[9],
                    // rules.unknown_3 = Int32.Parse(tmp[10]);
                    DojoSize = Int32.Parse(rulesArray[11]),
                    DismemberThreshold = Int32.Parse(rulesArray[12]),
                    FractureThreshold = Int32.Parse(rulesArray[13]),
                    EngageHeight = Int32.Parse(rulesArray[14]),
                    // rules.unknown_4 = Int32.Parse(tmp[15]);
                    // rules.unknown_5 = Int32.Parse(tmp[16]);
                    // rules.unknown_6 = Int32.Parse(tmp[17]);
                    // rules.unknown_7 = Int32.Parse(tmp[18]);                  
                    EngageRotation = Int32.Parse(rulesArray[19]),
                    // rules.unknown_8 = Int32.Parse(tmp[20]);;
                    EngageSpace = Int32.Parse(rulesArray[21]),
                    DQTimeOut = Int32.Parse(rulesArray[22]),
                    // rules.unknown_9 = Int32.Parse(tmp[23]);;
                    DojoType = Int32.Parse(rulesArray[24]),

                    // These have to be parsed using the American decimal separator, can't rely on the user's computer localization being correct.
                    GravityX =
                        float.Parse(rulesArray[25], NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US")),
                    GravityZ =
                        float.Parse(rulesArray[26], NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US")),
                    GravityY =
                        float.Parse(rulesArray[27], NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US")),


                    DQFlag = Int32.Parse(rulesArray[28]),
                    // rules.unknown_10 = Int32.Parse(tmp[29]);
                    DrawWinner = (rulesArray[30] == "1"), // "convert" to bool
                    PointThreshold = Int32.Parse(rulesArray[31]),
                    MaxContacts = Int32.Parse(rulesArray[32])
                };
            }
            catch
            {
                return new Rules();
            }
        }
    }
}
