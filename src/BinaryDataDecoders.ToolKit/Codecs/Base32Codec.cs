using System;
using System.Linq;
using System.Text;

namespace BinaryDataDecoders.ToolKit.Codecs
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    ///  https://tools.ietf.org/html/rfc4648
    ///
    /// The case for base 32 is shown in the following figure, borrowed from
    /// [7].  Each successive character in a base-32 value represents 5
    /// successive bits of the underlying octet sequence.  Thus, each group
    /// of 8 characters represents a sequence of 5 octets (40 bits).
    ///             1          2          3
    ///  01234567 89012345 67890123 45678901 23456789
    /// +--------+--------+--------+--------+--------+
    /// |&lt; 1 &gt;&lt; 2| &gt;&lt; 3 &gt;&lt;|.4 &gt;&lt; 5.|&gt;&lt; 6 &gt;&lt;.|7 &gt;&lt; 8 &gt;|
    /// +--------+--------+--------+--------+--------+
    ///                                         &lt;===&gt; 8th character
    ///                                   &lt;====&gt; 7th character
    ///                              &lt;===&gt; 6th character
    ///                        &lt;====&gt; 5th character
    ///                  &lt;====&gt; 4th character
    ///             &lt;===&gt; 3rd character
    ///       &lt;====&gt; 2nd character
    ///  &lt;===&gt; 1st character
    /// 
    ///  01234567 01234567 01234567 01234567 01234567
    ///  00000000 11111111 22222222 33333333 44444444
    ///  AAAAABBB BBCCCCCD DDDDEEEE EFFFFFGG GGGHHHHH
    /// </remarks>
    public class Base32Codec
    {
        //TODO: refactor this to use ReadOnlySpan/Memory

        private readonly string _base32Alphabet  = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567=";

        /// <summary>
        /// Encoding 8bit binary data as base32 string
        /// </summary>
        /// <param name="data">8bit data</param>
        /// <returns>base32 string</returns>
        public string Encode(byte[] data)
        {
            var vo = new byte[8];
            var vi = new byte[5];

            var sb = new StringBuilder();
            var l = data.Length;
            for (var i = 0; i < l; i += 5)
            {
                var cl = data.Length - i;
                Array.Clear(vi, 0, 5);
                Array.Copy(data, i, vi, 0, cl >= 5 ? 5 : cl);

                vo[0] = (byte)((vi[0] & 0xf8) / 8);
                vo[1] = (byte)((vi[0] & 0x7) * 4 + (vi[1] & 0xc0) / 64);
                vo[2] = (byte)((vi[1] & 0x3E) / 2);
                vo[3] = (byte)((vi[1] & 0x1) * 16 + (vi[2] & 0xF0) / 16);
                vo[4] = (byte)((vi[2] & 0xF) * 2 + (vi[3] & 0x80) / 128);
                vo[5] = (byte)((vi[3] & 0x7E) / 4);
                vo[6] = (byte)((vi[3] & 0x3) * 8 + (vi[4] & 0xE0) / 32);
                vo[7] = (byte)((vi[4] & 0x1F));

                if (cl < 5)
                {
                    var o = (int)Math.Ceiling(cl * 8d / 5d);

                    Array.Copy(new byte[] { 32, 32, 32, 32, 32, 32, 32, 32 }, 0, vo, o, 8 - o);
                }

                sb.Append(string.Join("", vo.Select(o => _base32Alphabet[o])));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Decode base32 string into 8bit binary
        /// </summary>
        /// <param name="input">base32 string</param>
        /// <returns>8bit data</returns>
        public byte[] Decode(string input)
        {
            var vi = new byte[8];
            var vo = new byte[5];
            var l = input.Length;

            var m = input.Length % 8;
            if (m != 0)
                input += new string('=', 8 - m);

            var iData = input.Select(c => (byte)_base32Alphabet.IndexOf(c))
                             .Select(c => c == 32 ? (byte)0 : c)
                             .ToArray();
            var oData = new byte[(int)(input.TrimEnd('=').Length * 5 / 8)];

            for (int i = 0, o = 0; i < l; i += 8, o += 5)
            {
                Array.Copy(iData, i, vi, 0, 8);

                vo[0] = (byte)((vi[0]) * 8 + (vi[1] & 0x1C) / 4);
                vo[1] = (byte)((vi[1] & 0x3) * 64 + (vi[2]) * 2 + (vi[3] & 0x10) / 16);
                vo[2] = (byte)((vi[3] & 0xF) * 16 + (vi[4] & 0x1E) / 2);
                vo[3] = (byte)((vi[4] & 0x1) * 128 + (vi[5]) * 4 + (vi[6] & 0x18) / 8);
                vo[4] = (byte)((vi[6] & 0x7) * 32 + (vi[7]));

                var cl = oData.Length - o;
                Array.Copy(vo, 0, oData, o, cl < 5 ? cl : 5);

            }

            return oData;
        }
    }
}
