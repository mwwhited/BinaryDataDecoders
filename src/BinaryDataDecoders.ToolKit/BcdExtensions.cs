using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryDataDecoders.ToolKit
{
    public static class BcdExtensions
    {
        public static int AsBCD(this byte input)
        {
            var low = (int)(input & 0x0f);
            var high = (int)((input & 0xf0) >> 4);

            if (low > 9)
                throw new ArgumentOutOfRangeException("low nibble");
            if (high > 9)
                throw new ArgumentOutOfRangeException("high nibble");

            return low + (high * 10);
        }
        public static byte ToBCD(this int input)
        {
            if (input > 99 || input < 0)
                throw new ArgumentOutOfRangeException();

            var high = input / 10;
            var low = input - (high * 10);

            if (low > 9)
                throw new ArgumentOutOfRangeException("low nibble");
            if (high > 9)
                throw new ArgumentOutOfRangeException("high nibble");


            return (byte)((high << 4) | low);
        }
    }
}
