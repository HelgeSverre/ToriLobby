using System;

namespace Torilobby
{
    public class Bout
    {
        public int ID;
        public int Qi;
        public string Name;
        public string Country;
        public string DateJoined;
        public string Raw;

        public override string ToString()
        {
            return String.Format("{0} - {1}", Country, Name);
        }
    }
}