# BinaryDataDecoders.Drawing.Barcodes.Code39

## Summary

| Key             | Value                                        |
| :-------------- | :------------------------------------------- |
| Class           | `BinaryDataDecoders.Drawing.Barcodes.Code39` |
| Assembly        | `BinaryDataDecoders.Drawing`                 |
| Coveredlines    | `0`                                          |
| Uncoveredlines  | `210`                                        |
| Coverablelines  | `210`                                        |
| Totallines      | `248`                                        |
| Linecoverage    | `0`                                          |
| Coveredbranches | `0`                                          |
| Totalbranches   | `12`                                         |
| Branchcoverage  | `0`                                          |
| Coveredmethods  | `0`                                          |
| Totalmethods    | `3`                                          |
| Methodcoverage  | `0`                                          |

## Metrics

| Complexity | Lines | Branches | Name              |
| :--------- | :---- | :------- | :---------------- |
| 1          | 0     | 100      | `ctor`            |
| 6          | 0     | 0        | `EncodeFullAscii` |
| 6          | 0     | 0        | `EncodeStandard`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Drawing/Barcodes/Code39.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Drawing;
〰4:   using System.Drawing.Imaging;
〰5:   using System.Linq;
〰6:   using System.Runtime.InteropServices;
〰7:   using System.Text;
〰8:   using System.Text.RegularExpressions;
〰9:   
〰10:  namespace BinaryDataDecoders.Drawing.Barcodes;
〰11:  
〰12:  public class Code39
〰13:  {
〰14:      // http://en.wikipedia.org/wiki/Code_39
〰15:  
〰16:      private Dictionary<char, byte[]> Standard
〰17:      { get; }
‼18:      = new Dictionary<char, byte[]>
‼19:      {
‼20:          ['A'] = [ (byte)0x8A, (byte)0xE8 ],
‼21:          ['B'] = [ (byte)0xA2, (byte)0xE8 ],
‼22:          ['C'] = [ (byte)0x88, (byte)0xBA ],
‼23:          ['D'] = [ (byte)0xA8, (byte)0xE8 ],
‼24:          ['E'] = [ (byte)0x8A, (byte)0x3A ],
‼25:          ['F'] = [ (byte)0xA2, (byte)0x3A ],
‼26:          ['G'] = [ (byte)0xAB, (byte)0x88 ],
‼27:          ['H'] = [ (byte)0x8A, (byte)0xE2 ],
‼28:          ['I'] = [ (byte)0xA2, (byte)0xE2 ],
‼29:          ['J'] = [ (byte)0xA8, (byte)0xE2 ],
‼30:          ['K'] = [ (byte)0x8A, (byte)0xB8 ],
‼31:          ['L'] = [ (byte)0xA2, (byte)0xB8 ],
‼32:          ['M'] = [ (byte)0x88, (byte)0xAE ],
‼33:          ['N'] = [ (byte)0xA8, (byte)0xB8 ],
‼34:          ['O'] = [ (byte)0x8A, (byte)0x2E ],
‼35:          ['P'] = [ (byte)0xA2, (byte)0x2E ],
‼36:          ['Q'] = [ (byte)0xAA, (byte)0x38 ],
‼37:          ['R'] = [ (byte)0x8A, (byte)0x8E ],
‼38:          ['S'] = [ (byte)0xA2, (byte)0x8E ],
‼39:          ['T'] = [ (byte)0xA8, (byte)0x8E ],
‼40:          ['U'] = [ (byte)0x8E, (byte)0xA8 ],
‼41:          ['V'] = [ (byte)0xB8, (byte)0xA8 ],
‼42:          ['W'] = [ (byte)0x8E, (byte)0x2A ],
‼43:          ['X'] = [ (byte)0xBA, (byte)0x28 ],
‼44:          ['Y'] = [ (byte)0x8E, (byte)0x8A ],
‼45:          ['Z'] = [ (byte)0xB8, (byte)0x8A ],
‼46:          ['0'] = [ (byte)0xAE, (byte)0x22 ],
‼47:          ['1'] = [ (byte)0x8B, (byte)0xA8 ],
‼48:          ['2'] = [ (byte)0xA3, (byte)0xA8 ],
‼49:          ['3'] = [ (byte)0x88, (byte)0xEA ],
‼50:          ['4'] = [ (byte)0xAE, (byte)0x28 ],
‼51:          ['5'] = [ (byte)0x8B, (byte)0x8A ],
‼52:          ['6'] = [ (byte)0xA3, (byte)0x8A ],
‼53:          ['7'] = [ (byte)0xAE, (byte)0x88 ],
‼54:          ['8'] = [ (byte)0x8B, (byte)0xA2 ],
‼55:          ['9'] = [ (byte)0xA3, (byte)0xA2 ],
‼56:          [' '] = [ (byte)0xB8, (byte)0xA2 ],
‼57:          ['-'] = [ (byte)0xBA, (byte)0x88 ],
‼58:          ['$'] = [ (byte)0xBB, (byte)0xBA ],
‼59:          ['%'] = [ (byte)0xAE, (byte)0xEE ],
‼60:          ['.'] = [ (byte)0x8E, (byte)0xA2 ],
‼61:          ['/'] = [ (byte)0xBB, (byte)0xAE ],
‼62:          ['+'] = [ (byte)0xBA, (byte)0xEE ],
‼63:          ['*'] = [ (byte)0xBA, (byte)0x22 ],
‼64:      };
〰65:  
〰66:      private Dictionary<char, string> FullAscii
〰67:      { get; }
‼68:      = new Dictionary<char, string>()
‼69:      {
‼70:          [(char)0] = "%U", // NUL
‼71:          [(char)1] = "$A", // SOH
‼72:          [(char)2] = "$B", // STX
‼73:          [(char)3] = "$C", // ETX
‼74:          [(char)4] = "$D", // EOT
‼75:          [(char)5] = "$E", // ENQ
‼76:          [(char)6] = "$F", // ACK
‼77:          [(char)7] = "$G", // BEL
‼78:          [(char)8] = "$H", // BS
‼79:          [(char)9] = "$I", // HT
‼80:          [(char)10] = "$J", // LF
‼81:          [(char)11] = "$K", // VT
‼82:          [(char)12] = "$L", // FF
‼83:          [(char)13] = "$M", // CR
‼84:          [(char)14] = "$N", // SO
‼85:          [(char)15] = "$O", // SI
‼86:          [(char)16] = "$P", // DLE
‼87:          [(char)17] = "$Q", // DC1
‼88:          [(char)18] = "$R", // DC2
‼89:          [(char)19] = "$S", // DC3
‼90:          [(char)20] = "$T", // DC4
‼91:          [(char)21] = "$U", // NAK
‼92:          [(char)22] = "$V", // SYN
‼93:          [(char)23] = "$W", // ETB
‼94:          [(char)24] = "$X", // CAN
‼95:          [(char)25] = "$Y", // EM
‼96:          [(char)26] = "$Z", // SUB
‼97:          [(char)27] = "%A", // ESC
‼98:          [(char)28] = "%B", // FS
‼99:          [(char)29] = "%C", // GS
‼100:         [(char)30] = "%D", // RS
‼101:         [(char)31] = "%E", // US
‼102:         [(char)32] = " ", // [space]
‼103:         [(char)33] = "/A", //  !
‼104:         [(char)34] = "/B", // "
‼105:         [(char)35] = "/C", // #
‼106:         [(char)36] = "/D", // $
‼107:         [(char)37] = "/E", // %
‼108:         [(char)38] = "/F", // &
‼109:         [(char)39] = "/G", // '
‼110:         [(char)40] = "/H", // (
‼111:         [(char)41] = "/I", // )
‼112:         [(char)42] = "/J", // *
‼113:         [(char)43] = "/K", // +
‼114:         [(char)44] = "/L", // ,
‼115:         [(char)45] = "-", // -
‼116:         [(char)46] = ".", // .
‼117:         [(char)47] = "/O", // /
‼118:         [(char)48] = "0", // 0
‼119:         [(char)49] = "1", // 1
‼120:         [(char)50] = "2", // 2
‼121:         [(char)51] = "3", // 3
‼122:         [(char)52] = "4", // 4
‼123:         [(char)53] = "5", // 5
‼124:         [(char)54] = "6", // 6
‼125:         [(char)55] = "7", // 7
‼126:         [(char)56] = "8", // 8
‼127:         [(char)57] = "9", // 9
‼128:         [(char)58] = "/Z", //  :
‼129:         [(char)59] = "%F", //  ;
‼130:         [(char)60] = "%G", // <
‼131:         [(char)61] = "%H", // =
‼132:         [(char)62] = "%I", // >
‼133:         [(char)63] = "%J", //  ?
‼134:         [(char)64] = "%V", // @
‼135:         [(char)65] = "A", // A
‼136:         [(char)66] = "B", // B
‼137:         [(char)67] = "C", // C
‼138:         [(char)68] = "D", // D
‼139:         [(char)69] = "E", // E
‼140:         [(char)70] = "F", // F
‼141:         [(char)71] = "G", // G
‼142:         [(char)72] = "H", // H
‼143:         [(char)73] = "I", // I
‼144:         [(char)74] = "J", // J
‼145:         [(char)75] = "K", // K
‼146:         [(char)76] = "L", // L
‼147:         [(char)77] = "M", // M
‼148:         [(char)78] = "N", // N
‼149:         [(char)79] = "O", // O
‼150:         [(char)80] = "P", // P
‼151:         [(char)81] = "Q", // Q
‼152:         [(char)82] = "R", // R
‼153:         [(char)83] = "S", // S
‼154:         [(char)84] = "T", // T
‼155:         [(char)85] = "U", // U
‼156:         [(char)86] = "V", // V
‼157:         [(char)87] = "W", // W
‼158:         [(char)88] = "X", // X
‼159:         [(char)89] = "Y", // Y
‼160:         [(char)90] = "Z", // Z
‼161:         [(char)91] = "%K", // [
‼162:         [(char)92] = "%L", // \
‼163:         [(char)93] = "%M", // ]
‼164:         [(char)94] = "%N", // ^
‼165:         [(char)95] = "%O", // _
‼166:         [(char)96] = "%W", // `
‼167:         [(char)97] = "+A", // a
‼168:         [(char)98] = "+B", // b
‼169:         [(char)99] = "+C", // c
‼170:         [(char)100] = "+D", // d
‼171:         [(char)101] = "+E", // e
‼172:         [(char)102] = "+F", // f
‼173:         [(char)103] = "+G", // g
‼174:         [(char)104] = "+H", // h
‼175:         [(char)105] = "+I", // i
‼176:         [(char)106] = "+J", // j
‼177:         [(char)107] = "+K", // k
‼178:         [(char)108] = "+L", // l
‼179:         [(char)109] = "+M", // m
‼180:         [(char)110] = "+N", // n
‼181:         [(char)111] = "+O", // o
‼182:         [(char)112] = "+P", // p
‼183:         [(char)113] = "+Q", // q
‼184:         [(char)114] = "+R", // r
‼185:         [(char)115] = "+S", // s
‼186:         [(char)116] = "+T", // t
‼187:         [(char)117] = "+U", // u
‼188:         [(char)118] = "+V", // v
‼189:         [(char)119] = "+W", // w
‼190:         [(char)120] = "+X", // x
‼191:         [(char)121] = "+Y", // y
‼192:         [(char)122] = "+Z", // z
‼193:         [(char)123] = "%P", // {
‼194:         [(char)124] = "%Q", // |
‼195:         [(char)125] = "%R", // }
‼196:         [(char)126] = "%S", // ~
‼197:         [(char)127] = "%T", // DEL
‼198:     };
〰199: 
〰200:     public Image EncodeFullAscii(string message)
〰201:     {
‼202:         if (message.Any(c => !this.FullAscii.ContainsKey(c)))
‼203:             throw new InvalidOperationException($"{nameof(message)} contains invalid characters");
〰204: 
‼205:         if (message.StartsWith('*') && message.EndsWith('*'))
‼206:             message = message.Trim('*');
〰207: 
‼208:         var codes = this.FullAscii;
‼209:         var encoded = message.Select(c => codes[c])
‼210:                              .Aggregate(new StringBuilder(), (sb, v) => sb.Append(v), sb => sb.ToString());
‼211:         var image = this.EncodeStandard(encoded);
‼212:         return image;
〰213:     }
〰214: 
〰215:     public Image EncodeStandard(string message)
〰216:     {
‼217:         var regexValid = new Regex(@"^(\*[-0-9A-Z.$/+% ]{1,}\*|[-0-9A-Z.$/+% ]{1,})$", RegexOptions.Compiled);
‼218:         if (!regexValid.IsMatch(message))
‼219:             throw new InvalidOperationException($"{nameof(message)} contains invalid characters");
〰220: 
‼221:         if (!message.StartsWith("*"))
‼222:             message = '*' + message + '*';
〰223: 
‼224:         var len = message.Length;
〰225: 
‼226:         var codes = this.Standard;
‼227:         var mapped = message.SelectMany(c => codes[c]).ToArray();
〰228: 
‼229:         var size = new
‼230:         {
‼231:             width = mapped.Length * 8,
‼232:             height = 16,
‼233:         };
〰234: 
‼235:         var bitmap = new Bitmap(size.width, size.height, PixelFormat.Format1bppIndexed);
‼236:         var bitmapdata = bitmap.LockBits(new Rectangle(new Point(), bitmap.Size), ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);
‼237:         var ptr = bitmapdata.Scan0;
‼238:         var lineLength = mapped.Length;
‼239:         var lineOffset = bitmapdata.Stride;
‼240:         var lineCount = size.height;
〰241: 
‼242:         for (var line = 0; line < lineCount; line++)
‼243:             Marshal.Copy(mapped, 0, ptr + (lineOffset * line), lineLength);
〰244: 
‼245:         bitmap.UnlockBits(bitmapdata);
‼246:         return bitmap;
〰247:     }
〰248: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

