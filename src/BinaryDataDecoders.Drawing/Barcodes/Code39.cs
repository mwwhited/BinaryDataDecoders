using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace BinaryDataDecoders.Drawing.Barcodes
{
    public class Code39
    {
        // http://en.wikipedia.org/wiki/Code_39

        private Dictionary<char, byte[]> Standard
        { get; }
        = new Dictionary<char, byte[]>
        {
            ['A'] = [ (byte)0x8A, (byte)0xE8 ],
            ['B'] = [ (byte)0xA2, (byte)0xE8 ],
            ['C'] = [ (byte)0x88, (byte)0xBA ],
            ['D'] = [ (byte)0xA8, (byte)0xE8 ],
            ['E'] = [ (byte)0x8A, (byte)0x3A ],
            ['F'] = [ (byte)0xA2, (byte)0x3A ],
            ['G'] = [ (byte)0xAB, (byte)0x88 ],
            ['H'] = [ (byte)0x8A, (byte)0xE2 ],
            ['I'] = [ (byte)0xA2, (byte)0xE2 ],
            ['J'] = [ (byte)0xA8, (byte)0xE2 ],
            ['K'] = [ (byte)0x8A, (byte)0xB8 ],
            ['L'] = [ (byte)0xA2, (byte)0xB8 ],
            ['M'] = [ (byte)0x88, (byte)0xAE ],
            ['N'] = [ (byte)0xA8, (byte)0xB8 ],
            ['O'] = [ (byte)0x8A, (byte)0x2E ],
            ['P'] = [ (byte)0xA2, (byte)0x2E ],
            ['Q'] = [ (byte)0xAA, (byte)0x38 ],
            ['R'] = [ (byte)0x8A, (byte)0x8E ],
            ['S'] = [ (byte)0xA2, (byte)0x8E ],
            ['T'] = [ (byte)0xA8, (byte)0x8E ],
            ['U'] = [ (byte)0x8E, (byte)0xA8 ],
            ['V'] = [ (byte)0xB8, (byte)0xA8 ],
            ['W'] = [ (byte)0x8E, (byte)0x2A ],
            ['X'] = [ (byte)0xBA, (byte)0x28 ],
            ['Y'] = [ (byte)0x8E, (byte)0x8A ],
            ['Z'] = [ (byte)0xB8, (byte)0x8A ],
            ['0'] = [ (byte)0xAE, (byte)0x22 ],
            ['1'] = [ (byte)0x8B, (byte)0xA8 ],
            ['2'] = [ (byte)0xA3, (byte)0xA8 ],
            ['3'] = [ (byte)0x88, (byte)0xEA ],
            ['4'] = [ (byte)0xAE, (byte)0x28 ],
            ['5'] = [ (byte)0x8B, (byte)0x8A ],
            ['6'] = [ (byte)0xA3, (byte)0x8A ],
            ['7'] = [ (byte)0xAE, (byte)0x88 ],
            ['8'] = [ (byte)0x8B, (byte)0xA2 ],
            ['9'] = [ (byte)0xA3, (byte)0xA2 ],
            [' '] = [ (byte)0xB8, (byte)0xA2 ],
            ['-'] = [ (byte)0xBA, (byte)0x88 ],
            ['$'] = [ (byte)0xBB, (byte)0xBA ],
            ['%'] = [ (byte)0xAE, (byte)0xEE ],
            ['.'] = [ (byte)0x8E, (byte)0xA2 ],
            ['/'] = [ (byte)0xBB, (byte)0xAE ],
            ['+'] = [ (byte)0xBA, (byte)0xEE ],
            ['*'] = [ (byte)0xBA, (byte)0x22 ],
        };

        private Dictionary<char, string> FullAscii
        { get; }
        = new Dictionary<char, string>()
        {
            [(char)0] = "%U", // NUL
            [(char)1] = "$A", // SOH
            [(char)2] = "$B", // STX
            [(char)3] = "$C", // ETX
            [(char)4] = "$D", // EOT
            [(char)5] = "$E", // ENQ
            [(char)6] = "$F", // ACK
            [(char)7] = "$G", // BEL
            [(char)8] = "$H", // BS
            [(char)9] = "$I", // HT
            [(char)10] = "$J", // LF
            [(char)11] = "$K", // VT
            [(char)12] = "$L", // FF
            [(char)13] = "$M", // CR
            [(char)14] = "$N", // SO
            [(char)15] = "$O", // SI
            [(char)16] = "$P", // DLE
            [(char)17] = "$Q", // DC1
            [(char)18] = "$R", // DC2
            [(char)19] = "$S", // DC3
            [(char)20] = "$T", // DC4
            [(char)21] = "$U", // NAK
            [(char)22] = "$V", // SYN
            [(char)23] = "$W", // ETB
            [(char)24] = "$X", // CAN
            [(char)25] = "$Y", // EM
            [(char)26] = "$Z", // SUB
            [(char)27] = "%A", // ESC
            [(char)28] = "%B", // FS
            [(char)29] = "%C", // GS
            [(char)30] = "%D", // RS
            [(char)31] = "%E", // US
            [(char)32] = " ", // [space]
            [(char)33] = "/A", //  !
            [(char)34] = "/B", // "
            [(char)35] = "/C", // #
            [(char)36] = "/D", // $
            [(char)37] = "/E", // %
            [(char)38] = "/F", // &
            [(char)39] = "/G", // '
            [(char)40] = "/H", // (
            [(char)41] = "/I", // )
            [(char)42] = "/J", // *
            [(char)43] = "/K", // +
            [(char)44] = "/L", // ,
            [(char)45] = "-", // -
            [(char)46] = ".", // .
            [(char)47] = "/O", // /
            [(char)48] = "0", // 0
            [(char)49] = "1", // 1
            [(char)50] = "2", // 2
            [(char)51] = "3", // 3
            [(char)52] = "4", // 4
            [(char)53] = "5", // 5
            [(char)54] = "6", // 6
            [(char)55] = "7", // 7
            [(char)56] = "8", // 8
            [(char)57] = "9", // 9
            [(char)58] = "/Z", //  :
            [(char)59] = "%F", //  ;
            [(char)60] = "%G", // <
            [(char)61] = "%H", // =
            [(char)62] = "%I", // >
            [(char)63] = "%J", //  ?
            [(char)64] = "%V", // @
            [(char)65] = "A", // A
            [(char)66] = "B", // B
            [(char)67] = "C", // C
            [(char)68] = "D", // D
            [(char)69] = "E", // E
            [(char)70] = "F", // F
            [(char)71] = "G", // G
            [(char)72] = "H", // H
            [(char)73] = "I", // I
            [(char)74] = "J", // J
            [(char)75] = "K", // K
            [(char)76] = "L", // L
            [(char)77] = "M", // M
            [(char)78] = "N", // N
            [(char)79] = "O", // O
            [(char)80] = "P", // P
            [(char)81] = "Q", // Q
            [(char)82] = "R", // R
            [(char)83] = "S", // S
            [(char)84] = "T", // T
            [(char)85] = "U", // U
            [(char)86] = "V", // V
            [(char)87] = "W", // W
            [(char)88] = "X", // X
            [(char)89] = "Y", // Y
            [(char)90] = "Z", // Z
            [(char)91] = "%K", // [
            [(char)92] = "%L", // \
            [(char)93] = "%M", // ]
            [(char)94] = "%N", // ^
            [(char)95] = "%O", // _
            [(char)96] = "%W", // `
            [(char)97] = "+A", // a
            [(char)98] = "+B", // b
            [(char)99] = "+C", // c
            [(char)100] = "+D", // d
            [(char)101] = "+E", // e
            [(char)102] = "+F", // f
            [(char)103] = "+G", // g
            [(char)104] = "+H", // h
            [(char)105] = "+I", // i
            [(char)106] = "+J", // j
            [(char)107] = "+K", // k
            [(char)108] = "+L", // l
            [(char)109] = "+M", // m
            [(char)110] = "+N", // n
            [(char)111] = "+O", // o
            [(char)112] = "+P", // p
            [(char)113] = "+Q", // q
            [(char)114] = "+R", // r
            [(char)115] = "+S", // s
            [(char)116] = "+T", // t
            [(char)117] = "+U", // u
            [(char)118] = "+V", // v
            [(char)119] = "+W", // w
            [(char)120] = "+X", // x
            [(char)121] = "+Y", // y
            [(char)122] = "+Z", // z
            [(char)123] = "%P", // {
            [(char)124] = "%Q", // |
            [(char)125] = "%R", // }
            [(char)126] = "%S", // ~
            [(char)127] = "%T", // DEL
        };

        public Image EncodeFullAscii(string message)
        {
            if (message.Any(c => !this.FullAscii.ContainsKey(c)))
                throw new InvalidOperationException($"{nameof(message)} contains invalid characters");

            if (message.StartsWith('*') && message.EndsWith('*'))
                message = message.Trim('*');

            var codes = this.FullAscii;
            var encoded = message.Select(c => codes[c])
                                 .Aggregate(new StringBuilder(), (sb, v) => sb.Append(v), sb => sb.ToString());
            var image = this.EncodeStandard(encoded);
            return image;
        }

        public Image EncodeStandard(string message)
        {
            var regexValid = new Regex(@"^(\*[-0-9A-Z.$/+% ]{1,}\*|[-0-9A-Z.$/+% ]{1,})$", RegexOptions.Compiled);
            if (!regexValid.IsMatch(message))
                throw new InvalidOperationException($"{nameof(message)} contains invalid characters");

            if (!message.StartsWith("*"))
                message = '*' + message + '*';

            var len = message.Length;

            var codes = this.Standard;
            var mapped = message.SelectMany(c => codes[c]).ToArray();

            var size = new
            {
                width = mapped.Length * 8,
                height = 16,
            };

            var bitmap = new Bitmap(size.width, size.height, PixelFormat.Format1bppIndexed);
            var bitmapdata = bitmap.LockBits(new Rectangle(new Point(), bitmap.Size), ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);
            var ptr = bitmapdata.Scan0;
            var lineLength = mapped.Length;
            var lineOffset = bitmapdata.Stride;
            var lineCount = size.height;

            for (var line = 0; line < lineCount; line++)
                Marshal.Copy(mapped, 0, ptr + (lineOffset * line), lineLength);

            bitmap.UnlockBits(bitmapdata);
            return bitmap;
        }
    }
}
