using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test1
{
    public enum GeneralHeading
    {
        North = 0,
        North_NorthEast = 1,
        NorthEast = 2,
        East_NorthEast = 3,
        East = 4,
        East_SouthEast = 5,
        SouthEast = 6,
        South_SouthEast = 7,
        South = 8,
        South_SouthWest = 9,
        SouthWest = 10,
        West_SouthWest = 11,
        West = 12,
        West_NorthWest = 13,
        NorthWest = 14,
        North_NorthWest = 15,
    }

    public enum GeneralHeadingShort
    {
        N = 0,
        NNE = 1,
        NE = 2,
        ENE = 3,
        E = 4,
        ESE = 5,
        SE = 6,
        SSE = 7,
        S = 8,
        SSW = 9,
        SW = 10,
        WSW = 11,
        W = 12,
        WNW = 13,
        NW = 14,
        NNW = 15,
    }
    
    public static class GeneralHeadingExtensions
    {
        public static GeneralHeading GetGeneralHeading(this float bearing)
        {
            bearing -= (((int)Math.Floor(bearing / 360)) * 360);
            return (GeneralHeading)(((int)Math.Floor(((bearing - 11.25) / 22.5) + 1)) & 0x000F);
        }

        public static GeneralHeadingShort ToGeneralHeadingShort(this GeneralHeading generalHeading)
        {
            return (GeneralHeadingShort)generalHeading;
        }

        public static GeneralHeading ToGeneralHeading(this GeneralHeadingShort generalHeading)
        {
            return (GeneralHeading)generalHeading;
        }

        public static int Xor(this IEnumerable<byte> buffer)
        {
            int _result = 0;
            foreach (var _byte in buffer)
            {
                _result ^= _byte;
            }
            return _result;
        }
    }
}
