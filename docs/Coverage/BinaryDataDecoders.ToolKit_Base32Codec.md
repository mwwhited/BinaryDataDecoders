# BinaryDataDecoders.ToolKit.Codecs.Base32Codec

## Summary

| Key             | Value                                           |
| :-------------- | :---------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Codecs.Base32Codec` |
| Assembly        | `BinaryDataDecoders.ToolKit`                    |
| Coveredlines    | `41`                                            |
| Uncoveredlines  | `43`                                            |
| Coverablelines  | `84`                                            |
| Totallines      | `487`                                           |
| Linecoverage    | `48.8`                                          |
| Coveredbranches | `13`                                            |
| Totalbranches   | `28`                                            |
| Branchcoverage  | `46.4`                                          |
| Coveredmethods  | `3`                                             |
| Totalmethods    | `6`                                             |
| Methodcoverage  | `50`                                            |

## Metrics

| Complexity | Lines | Branches | Name     |
| :--------- | :---- | :------- | :------- |
| 1          | 0     | 100      | `ctor`   |
| 6          | 0     | 0        | `Encode` |
| 8          | 0     | 0        | `Decode` |
| 1          | 100   | 100      | `ctor`   |
| 6          | 100   | 100      | `Encode` |
| 8          | 95.00 | 87.50    | `Decode` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Codecs/Base32Codec.cs

```CSharp
〰1:   using System;
〰2:   using System.Linq;
〰3:   using System.Text;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Codecs;
〰6:   
〰7:   /// <summary>
〰8:   ///
〰9:   /// </summary>
〰10:  /// <remarks>
〰11:  ///  https://tools.ietf.org/html/rfc4648
〰12:  ///
〰13:  /// The case for base 32 is shown in the following figure, borrowed from
〰14:  /// [7].  Each successive character in a base-32 value represents 5
〰15:  /// successive bits of the underlying octet sequence.  Thus, each group
〰16:  /// of 8 characters represents a sequence of 5 octets (40 bits).
〰17:  ///             1          2          3
〰18:  ///  01234567 89012345 67890123 45678901 23456789
〰19:  /// +--------+--------+--------+--------+--------+
〰20:  /// |&lt; 1 &gt;&lt; 2| &gt;&lt; 3 &gt;&lt;|.4 &gt;&lt; 5.|&gt;&lt; 6 &gt;&lt;.|7 &gt;&lt; 8 &gt;|
〰21:  /// +--------+--------+--------+--------+--------+
〰22:  ///                                         &lt;===&gt; 8th character
〰23:  ///                                   &lt;====&gt; 7th character
〰24:  ///                              &lt;===&gt; 6th character
〰25:  ///                        &lt;====&gt; 5th character
〰26:  ///                  &lt;====&gt; 4th character
〰27:  ///             &lt;===&gt; 3rd character
〰28:  ///       &lt;====&gt; 2nd character
〰29:  ///  &lt;===&gt; 1st character
〰30:  ///
〰31:  ///  01234567 01234567 01234567 01234567 01234567
〰32:  ///  00000000 11111111 22222222 33333333 44444444
〰33:  ///  AAAAABBB BBCCCCCD DDDDEEEE EFFFFFGG GGGHHHHH
〰34:  /// </remarks>
〰35:  public class Base32Codec
〰36:  {
〰37:      //TODO: refactor this to use ReadOnlySpan/Memory
〰38:  
‼39:      private readonly string _base32Alphabet  = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567=";
〰40:  
〰41:      /// <summary>
〰42:      /// Encoding 8bit binary data as base32 string
〰43:      /// </summary>
〰44:      /// <param name="data">8bit data</param>
〰45:      /// <returns>base32 string</returns>
〰46:      public string Encode(byte[] data)
〰47:      {
‼48:          var vo = new byte[8];
‼49:          var vi = new byte[5];
〰50:  
‼51:          var sb = new StringBuilder();
‼52:          var l = data.Length;
‼53:          for (var i = 0; i < l; i += 5)
〰54:          {
‼55:              var cl = data.Length - i;
‼56:              Array.Clear(vi, 0, 5);
‼57:              Array.Copy(data, i, vi, 0, cl >= 5 ? 5 : cl);
〰58:  
‼59:              vo[0] = (byte)((vi[0] & 0xf8) / 8);
‼60:              vo[1] = (byte)((vi[0] & 0x7) * 4 + (vi[1] & 0xc0) / 64);
‼61:              vo[2] = (byte)((vi[1] & 0x3E) / 2);
‼62:              vo[3] = (byte)((vi[1] & 0x1) * 16 + (vi[2] & 0xF0) / 16);
‼63:              vo[4] = (byte)((vi[2] & 0xF) * 2 + (vi[3] & 0x80) / 128);
‼64:              vo[5] = (byte)((vi[3] & 0x7E) / 4);
‼65:              vo[6] = (byte)((vi[3] & 0x3) * 8 + (vi[4] & 0xE0) / 32);
‼66:              vo[7] = (byte)((vi[4] & 0x1F));
〰67:  
‼68:              if (cl < 5)
〰69:              {
‼70:                  var o = (int)Math.Ceiling(cl * 8d / 5d);
〰71:  
‼72:                  Array.Copy("        "u8.ToArray(), 0, vo, o, 8 - o);
〰73:              }
〰74:  
‼75:              sb.Append(string.Join("", vo.Select(o => _base32Alphabet[o])));
〰76:          }
〰77:  
‼78:          return sb.ToString();
〰79:      }
〰80:  
〰81:      /// <summary>
〰82:      /// Decode base32 string into 8bit binary
〰83:      /// </summary>
〰84:      /// <param name="input">base32 string</param>
〰85:      /// <returns>8bit data</returns>
〰86:      public byte[] Decode(string input)
〰87:      {
‼88:          var vi = new byte[8];
‼89:          var vo = new byte[5];
‼90:          var l = input.Length;
〰91:  
‼92:          var m = input.Length % 8;
‼93:          if (m != 0)
‼94:              input += new string('=', 8 - m);
〰95:  
‼96:          var iData = input.Select(c => (byte)_base32Alphabet.IndexOf(c))
‼97:                           .Select(c => c == 32 ? (byte)0 : c)
‼98:                           .ToArray();
‼99:          var oData = new byte[(int)(input.TrimEnd('=').Length * 5 / 8)];
〰100: 
‼101:         for (int i = 0, o = 0; i < l; i += 8, o += 5)
〰102:         {
‼103:             Array.Copy(iData, i, vi, 0, 8);
〰104: 
‼105:             vo[0] = (byte)((vi[0]) * 8 + (vi[1] & 0x1C) / 4);
‼106:             vo[1] = (byte)((vi[1] & 0x3) * 64 + (vi[2]) * 2 + (vi[3] & 0x10) / 16);
‼107:             vo[2] = (byte)((vi[3] & 0xF) * 16 + (vi[4] & 0x1E) / 2);
‼108:             vo[3] = (byte)((vi[4] & 0x1) * 128 + (vi[5]) * 4 + (vi[6] & 0x18) / 8);
‼109:             vo[4] = (byte)((vi[6] & 0x7) * 32 + (vi[7]));
〰110: 
‼111:             var cl = oData.Length - o;
‼112:             Array.Copy(vo, 0, oData, o, cl < 5 ? cl : 5);
〰113: 
〰114:         }
〰115: 
‼116:         return oData;
〰117:     }
〰118: }
〰119: 
〰120: 
〰121: //public class Base32Encoding
〰122: //{
〰123: //    public static byte[] ToBytes(string input)
〰124: //    {
〰125: //        if (string.IsNullOrEmpty(input))
〰126: //        {
〰127: //            throw new ArgumentNullException("input");
〰128: //        }
〰129: 
〰130: //        input = input.TrimEnd('='); //remove padding characters
〰131: //        int byteCount = input.Length * 5 / 8; //this must be TRUNCATED
〰132: //        byte[] returnArray = new byte[byteCount];
〰133: 
〰134: //        byte curByte = 0, bitsRemaining = 8;
〰135: //        int mask = 0, arrayIndex = 0;
〰136: 
〰137: //        foreach (char c in input)
〰138: //        {
〰139: //            int cValue = CharToValue(c);
〰140: 
〰141: //            if (bitsRemaining > 5)
〰142: //            {
〰143: //                mask = cValue << (bitsRemaining - 5);
〰144: //                curByte = (byte)(curByte | mask);
〰145: //                bitsRemaining -= 5;
〰146: //            }
〰147: //            else
〰148: //            {
〰149: //                mask = cValue >> (5 - bitsRemaining);
〰150: //                curByte = (byte)(curByte | mask);
〰151: //                returnArray[arrayIndex++] = curByte;
〰152: //                curByte = (byte)(cValue << (3 + bitsRemaining));
〰153: //                bitsRemaining += 3;
〰154: //            }
〰155: //        }
〰156: 
〰157: //        //if we didn't end with a full byte
〰158: //        if (arrayIndex != byteCount)
〰159: //        {
〰160: //            returnArray[arrayIndex] = curByte;
〰161: //        }
〰162: 
〰163: //        return returnArray;
〰164: //    }
〰165: 
〰166: //    public static string ToString(byte[] input)
〰167: //    {
〰168: //        if (input == null || input.Length == 0)
〰169: //        {
〰170: //            throw new ArgumentNullException("input");
〰171: //        }
〰172: 
〰173: //        int charCount = (int)Math.Ceiling(input.Length / 5d) * 8;
〰174: //        char[] returnArray = new char[charCount];
〰175: 
〰176: //        byte nextChar = 0, bitsRemaining = 5;
〰177: //        int arrayIndex = 0;
〰178: 
〰179: //        foreach (byte b in input)
〰180: //        {
〰181: //            nextChar = (byte)(nextChar | (b >> (8 - bitsRemaining)));
〰182: //            returnArray[arrayIndex++] = ValueToChar(nextChar);
〰183: 
〰184: //            if (bitsRemaining < 4)
〰185: //            {
〰186: //                nextChar = (byte)((b >> (3 - bitsRemaining)) & 31);
〰187: //                returnArray[arrayIndex++] = ValueToChar(nextChar);
〰188: //                bitsRemaining += 5;
〰189: //            }
〰190: 
〰191: //            bitsRemaining -= 3;
〰192: //            nextChar = (byte)((b << bitsRemaining) & 31);
〰193: //        }
〰194: 
〰195: //        //if we didn't end with a full char
〰196: //        if (arrayIndex != charCount)
〰197: //        {
〰198: //            returnArray[arrayIndex++] = ValueToChar(nextChar);
〰199: //            while (arrayIndex != charCount) returnArray[arrayIndex++] = '='; //padding
〰200: //        }
〰201: 
〰202: //        return new string(returnArray);
〰203: //    }
〰204: 
〰205: //    private static int CharToValue(char c)
〰206: //    {
〰207: //        int value = (int)c;
〰208: 
〰209: //        //65-90 == uppercase letters
〰210: //        if (value < 91 && value > 64)
〰211: //        {
〰212: //            return value - 65;
〰213: //        }
〰214: //        //50-55 == numbers 2-7
〰215: //        if (value < 56 && value > 49)
〰216: //        {
〰217: //            return value - 24;
〰218: //        }
〰219: //        //97-122 == lowercase letters
〰220: //        if (value < 123 && value > 96)
〰221: //        {
〰222: //            return value - 97;
〰223: //        }
〰224: 
〰225: //        throw new ArgumentException("Character is not a Base32 character.", "c");
〰226: //    }
〰227: 
〰228: //    private static char ValueToChar(byte b)
〰229: //    {
〰230: //        if (b < 26)
〰231: //        {
〰232: //            return (char)(b + 65);
〰233: //        }
〰234: 
〰235: //        if (b < 32)
〰236: //        {
〰237: //            return (char)(b + 24);
〰238: //        }
〰239: 
〰240: //        throw new ArgumentException("Byte is not a value Base32 value.", "b");
〰241: //    }
〰242: 
〰243: //}
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/Codecs/Base32Codec.cs

```CSharp
〰1:   using System;
〰2:   using System.Linq;
〰3:   using System.Text;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Codecs;
〰6:   
〰7:   /// <summary>
〰8:   ///
〰9:   /// </summary>
〰10:  /// <remarks>
〰11:  ///  https://tools.ietf.org/html/rfc4648
〰12:  ///
〰13:  /// The case for base 32 is shown in the following figure, borrowed from
〰14:  /// [7].  Each successive character in a base-32 value represents 5
〰15:  /// successive bits of the underlying octet sequence.  Thus, each group
〰16:  /// of 8 characters represents a sequence of 5 octets (40 bits).
〰17:  ///             1          2          3
〰18:  ///  01234567 89012345 67890123 45678901 23456789
〰19:  /// +--------+--------+--------+--------+--------+
〰20:  /// |&lt; 1 &gt;&lt; 2| &gt;&lt; 3 &gt;&lt;|.4 &gt;&lt; 5.|&gt;&lt; 6 &gt;&lt;.|7 &gt;&lt; 8 &gt;|
〰21:  /// +--------+--------+--------+--------+--------+
〰22:  ///                                         &lt;===&gt; 8th character
〰23:  ///                                   &lt;====&gt; 7th character
〰24:  ///                              &lt;===&gt; 6th character
〰25:  ///                        &lt;====&gt; 5th character
〰26:  ///                  &lt;====&gt; 4th character
〰27:  ///             &lt;===&gt; 3rd character
〰28:  ///       &lt;====&gt; 2nd character
〰29:  ///  &lt;===&gt; 1st character
〰30:  ///
〰31:  ///  01234567 01234567 01234567 01234567 01234567
〰32:  ///  00000000 11111111 22222222 33333333 44444444
〰33:  ///  AAAAABBB BBCCCCCD DDDDEEEE EFFFFFGG GGGHHHHH
〰34:  /// </remarks>
〰35:  public class Base32Codec
〰36:  {
〰37:      //TODO: refactor this to use ReadOnlySpan/Memory
〰38:  
✔39:      private readonly string _base32Alphabet  = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567=";
〰40:  
〰41:      /// <summary>
〰42:      /// Encoding 8bit binary data as base32 string
〰43:      /// </summary>
〰44:      /// <param name="data">8bit data</param>
〰45:      /// <returns>base32 string</returns>
〰46:      public string Encode(byte[] data)
〰47:      {
✔48:          var vo = new byte[8];
✔49:          var vi = new byte[5];
〰50:  
✔51:          var sb = new StringBuilder();
✔52:          var l = data.Length;
✔53:          for (var i = 0; i < l; i += 5)
〰54:          {
✔55:              var cl = data.Length - i;
✔56:              Array.Clear(vi, 0, 5);
✔57:              Array.Copy(data, i, vi, 0, cl >= 5 ? 5 : cl);
〰58:  
✔59:              vo[0] = (byte)((vi[0] & 0xf8) / 8);
✔60:              vo[1] = (byte)((vi[0] & 0x7) * 4 + (vi[1] & 0xc0) / 64);
✔61:              vo[2] = (byte)((vi[1] & 0x3E) / 2);
✔62:              vo[3] = (byte)((vi[1] & 0x1) * 16 + (vi[2] & 0xF0) / 16);
✔63:              vo[4] = (byte)((vi[2] & 0xF) * 2 + (vi[3] & 0x80) / 128);
✔64:              vo[5] = (byte)((vi[3] & 0x7E) / 4);
✔65:              vo[6] = (byte)((vi[3] & 0x3) * 8 + (vi[4] & 0xE0) / 32);
✔66:              vo[7] = (byte)((vi[4] & 0x1F));
〰67:  
✔68:              if (cl < 5)
〰69:              {
✔70:                  var o = (int)Math.Ceiling(cl * 8d / 5d);
〰71:  
✔72:                  Array.Copy("        "u8.ToArray(), 0, vo, o, 8 - o);
〰73:              }
〰74:  
✔75:              sb.Append(string.Join("", vo.Select(o => _base32Alphabet[o])));
〰76:          }
〰77:  
✔78:          return sb.ToString();
〰79:      }
〰80:  
〰81:      /// <summary>
〰82:      /// Decode base32 string into 8bit binary
〰83:      /// </summary>
〰84:      /// <param name="input">base32 string</param>
〰85:      /// <returns>8bit data</returns>
〰86:      public byte[] Decode(string input)
〰87:      {
✔88:          var vi = new byte[8];
✔89:          var vo = new byte[5];
✔90:          var l = input.Length;
〰91:  
✔92:          var m = input.Length % 8;
⚠93:          if (m != 0)
‼94:              input += new string('=', 8 - m);
〰95:  
✔96:          var iData = input.Select(c => (byte)_base32Alphabet.IndexOf(c))
✔97:                           .Select(c => c == 32 ? (byte)0 : c)
✔98:                           .ToArray();
✔99:          var oData = new byte[(int)(input.TrimEnd('=').Length * 5 / 8)];
〰100: 
✔101:         for (int i = 0, o = 0; i < l; i += 8, o += 5)
〰102:         {
✔103:             Array.Copy(iData, i, vi, 0, 8);
〰104: 
✔105:             vo[0] = (byte)((vi[0]) * 8 + (vi[1] & 0x1C) / 4);
✔106:             vo[1] = (byte)((vi[1] & 0x3) * 64 + (vi[2]) * 2 + (vi[3] & 0x10) / 16);
✔107:             vo[2] = (byte)((vi[3] & 0xF) * 16 + (vi[4] & 0x1E) / 2);
✔108:             vo[3] = (byte)((vi[4] & 0x1) * 128 + (vi[5]) * 4 + (vi[6] & 0x18) / 8);
✔109:             vo[4] = (byte)((vi[6] & 0x7) * 32 + (vi[7]));
〰110: 
✔111:             var cl = oData.Length - o;
✔112:             Array.Copy(vo, 0, oData, o, cl < 5 ? cl : 5);
〰113: 
〰114:         }
〰115: 
✔116:         return oData;
〰117:     }
〰118: }
〰119: 
〰120: 
〰121: //public class Base32Encoding
〰122: //{
〰123: //    public static byte[] ToBytes(string input)
〰124: //    {
〰125: //        if (string.IsNullOrEmpty(input))
〰126: //        {
〰127: //            throw new ArgumentNullException("input");
〰128: //        }
〰129: 
〰130: //        input = input.TrimEnd('='); //remove padding characters
〰131: //        int byteCount = input.Length * 5 / 8; //this must be TRUNCATED
〰132: //        byte[] returnArray = new byte[byteCount];
〰133: 
〰134: //        byte curByte = 0, bitsRemaining = 8;
〰135: //        int mask = 0, arrayIndex = 0;
〰136: 
〰137: //        foreach (char c in input)
〰138: //        {
〰139: //            int cValue = CharToValue(c);
〰140: 
〰141: //            if (bitsRemaining > 5)
〰142: //            {
〰143: //                mask = cValue << (bitsRemaining - 5);
〰144: //                curByte = (byte)(curByte | mask);
〰145: //                bitsRemaining -= 5;
〰146: //            }
〰147: //            else
〰148: //            {
〰149: //                mask = cValue >> (5 - bitsRemaining);
〰150: //                curByte = (byte)(curByte | mask);
〰151: //                returnArray[arrayIndex++] = curByte;
〰152: //                curByte = (byte)(cValue << (3 + bitsRemaining));
〰153: //                bitsRemaining += 3;
〰154: //            }
〰155: //        }
〰156: 
〰157: //        //if we didn't end with a full byte
〰158: //        if (arrayIndex != byteCount)
〰159: //        {
〰160: //            returnArray[arrayIndex] = curByte;
〰161: //        }
〰162: 
〰163: //        return returnArray;
〰164: //    }
〰165: 
〰166: //    public static string ToString(byte[] input)
〰167: //    {
〰168: //        if (input == null || input.Length == 0)
〰169: //        {
〰170: //            throw new ArgumentNullException("input");
〰171: //        }
〰172: 
〰173: //        int charCount = (int)Math.Ceiling(input.Length / 5d) * 8;
〰174: //        char[] returnArray = new char[charCount];
〰175: 
〰176: //        byte nextChar = 0, bitsRemaining = 5;
〰177: //        int arrayIndex = 0;
〰178: 
〰179: //        foreach (byte b in input)
〰180: //        {
〰181: //            nextChar = (byte)(nextChar | (b >> (8 - bitsRemaining)));
〰182: //            returnArray[arrayIndex++] = ValueToChar(nextChar);
〰183: 
〰184: //            if (bitsRemaining < 4)
〰185: //            {
〰186: //                nextChar = (byte)((b >> (3 - bitsRemaining)) & 31);
〰187: //                returnArray[arrayIndex++] = ValueToChar(nextChar);
〰188: //                bitsRemaining += 5;
〰189: //            }
〰190: 
〰191: //            bitsRemaining -= 3;
〰192: //            nextChar = (byte)((b << bitsRemaining) & 31);
〰193: //        }
〰194: 
〰195: //        //if we didn't end with a full char
〰196: //        if (arrayIndex != charCount)
〰197: //        {
〰198: //            returnArray[arrayIndex++] = ValueToChar(nextChar);
〰199: //            while (arrayIndex != charCount) returnArray[arrayIndex++] = '='; //padding
〰200: //        }
〰201: 
〰202: //        return new string(returnArray);
〰203: //    }
〰204: 
〰205: //    private static int CharToValue(char c)
〰206: //    {
〰207: //        int value = (int)c;
〰208: 
〰209: //        //65-90 == uppercase letters
〰210: //        if (value < 91 && value > 64)
〰211: //        {
〰212: //            return value - 65;
〰213: //        }
〰214: //        //50-55 == numbers 2-7
〰215: //        if (value < 56 && value > 49)
〰216: //        {
〰217: //            return value - 24;
〰218: //        }
〰219: //        //97-122 == lowercase letters
〰220: //        if (value < 123 && value > 96)
〰221: //        {
〰222: //            return value - 97;
〰223: //        }
〰224: 
〰225: //        throw new ArgumentException("Character is not a Base32 character.", "c");
〰226: //    }
〰227: 
〰228: //    private static char ValueToChar(byte b)
〰229: //    {
〰230: //        if (b < 26)
〰231: //        {
〰232: //            return (char)(b + 65);
〰233: //        }
〰234: 
〰235: //        if (b < 32)
〰236: //        {
〰237: //            return (char)(b + 24);
〰238: //        }
〰239: 
〰240: //        throw new ArgumentException("Byte is not a value Base32 value.", "b");
〰241: //    }
〰242: 
〰243: //}
〰244: 
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

