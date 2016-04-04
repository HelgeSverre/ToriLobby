using System.Collections.Generic;

namespace Torilobby.Client
{
    public struct Rules
    {

        /*
        Flag 1  -> DQ = yes,	DM = no, 	Frac = no, 	Grip = yes
        Flag 2  -> DQ = no, 	DM = yes, 	Frac = no, 	Grip = yes
        Flag 3  -> DQ = yes,	DM = yes, 	Frac = no, 	Grip = yes
        Flag 4  -> DQ = no, 	DM = no, 	Frac = no, 	Grip = no
        Flag 5  -> DQ = yes,	DM = no, 	Frac = no, 	Grip = no
        Flag 6  -> DQ = no, 	DM = yes, 	Frac = no, 	Grip = no
        Flag 7  -> DQ = yes,	DM = yes, 	Frac = no, 	Grip = no
        Flag 8  -> DQ = no, 	DM = no, 	Frac = yes, Grip = yes
        Flag 9  -> DQ = yes,	DM = no, 	Frac = yes, Grip = yes
        Flag 10 -> DQ = no, 	DM = yes, 	Frac = yes, Grip = yes
        Flag 11 -> DQ = yes,	DM = yes, 	Frac = yes, Grip = yes
        Flag 12 -> DQ = no, 	DM = no, 	Frac = yes, Grip = no
        Flag 13 -> DQ = yes,	DM = no, 	Frac = yes, Grip = no
        Flag 14 -> DQ = no, 	DM = yes, 	Frac = yes, Grip = no
        Flag 15 -> DQ = yes,	DM = yes, 	Frac = yes, Grip = no
        Flag 16 -> DQ = no, 	DM = no, 	Frac = no, 	Grip = yes
        */
        public int Flags { get; set; }
        public int Matchframes { get; set; }
        public List<int> TurnFrames { get; set; }
        public int ReactionTime { get; set; }
        public int EngageDistance { get; set; }
        public int Damage { get; set; }
        public int Sumo { get; set; }
        public string Mod { get; set; }
        public int DojoSize { get; set; }
        public int DismemberThreshold { get; set; }
        public int FractureThreshold { get; set; }
        public int EngageHeight { get; set; }
        public int EngageRotation { get; set; }
        public int EngageSpace { get; set; }
        public int DQTimeOut { get; set; }
        public int DojoType { get; set; }

        // TODO: Create and change to a vector3f type
        // NOTE: When pushing this to a client or sending it via sockets, 
        // it must be formatted with 6 decimal places, ex: GravityX.ToString("N6");
        public float GravityX { get; set; }
        public float GravityZ { get; set; }
        public float GravityY { get; set; }

        /*
        0  | You achieve points for hitting your opponent.
        1  | You achieve points for hitting your opponent; your opponent gets points when you touch yourself.
        2  | Your opponent achieves points when you touch yourself.
        */
        public int DQFlag { get; set; }
        public bool DrawWinner { get; set; }
        public int PointThreshold { get; set; }
        public int MaxContacts { get; set; }

    }
}
