
# BinaryDataDecoders.ToolKit.Codecs.Base32Codec
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_Base32Codec.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.Codecs.Base32Codec                | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 42                                                           | 
| Coverablelines       | 42                                                           | 
| Totallines           | 119                                                          | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 12                                                           | 
| Branchcoverage       | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Codecs\Base32Codec.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 0     | 100      | ctor | 
| 6          | 0     | 0        | Encode | 
| 6          | 0     | 0        | Decode | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Codecs\Base32Codec.cs

```CSharp
〰1:   using System;
〰2:   using System.Linq;
〰3:   using System.Text;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Codecs
〰6:   {
〰7:       /// <summary>
〰8:       ///
〰9:       /// </summary>
〰10:      /// <remarks>
〰11:      ///  https://tools.ietf.org/html/rfc4648
〰12:      ///
〰13:      /// The case for base 32 is shown in the following figure, borrowed from
〰14:      /// [7].  Each successive character in a base-32 value represents 5
〰15:      /// successive bits of the underlying octet sequence.  Thus, each group
〰16:      /// of 8 characters represents a sequence of 5 octets (40 bits).
〰17:      ///             1          2          3
〰18:      ///  01234567 89012345 67890123 45678901 23456789
〰19:      /// +--------+--------+--------+--------+--------+
〰20:      /// |&lt; 1 &gt;&lt; 2| &gt;&lt; 3 &gt;&lt;|.4 &gt;&lt; 5.|&gt;&lt; 6 &gt;&lt;.|7 &gt;&lt; 8 &gt;|
〰21:      /// +--------+--------+--------+--------+--------+
〰22:      ///                                         &lt;===&gt; 8th character
〰23:      ///                                   &lt;====&gt; 7th character
〰24:      ///                              &lt;===&gt; 6th character
〰25:      ///                        &lt;====&gt; 5th character
〰26:      ///                  &lt;====&gt; 4th character
〰27:      ///             &lt;===&gt; 3rd character
〰28:      ///       &lt;====&gt; 2nd character
〰29:      ///  &lt;===&gt; 1st character
〰30:      ///
〰31:      ///  01234567 01234567 01234567 01234567 01234567
〰32:      ///  00000000 11111111 22222222 33333333 44444444
〰33:      ///  AAAAABBB BBCCCCCD DDDDEEEE EFFFFFGG GGGHHHHH
〰34:      /// </remarks>
〰35:      public class Base32Codec
〰36:      {
〰37:          //TODO: refactor this to use ReadOnlySpan/Memory
〰38:  
‼39:          private readonly string _base32Alphabet  = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567=";
〰40:  
〰41:          /// <summary>
〰42:          /// Encoding 8bit binary data as base32 string
〰43:          /// </summary>
〰44:          /// <param name="data">8bit data</param>
〰45:          /// <returns>base32 string</returns>
〰46:          public string Encode(byte[] data)
〰47:          {
‼48:              var vo = new byte[8];
‼49:              var vi = new byte[5];
〰50:  
‼51:              var sb = new StringBuilder();
‼52:              var l = data.Length;
‼53:              for (var i = 0; i < l; i += 5)
〰54:              {
‼55:                  var cl = data.Length - i;
‼56:                  Array.Clear(vi, 0, 5);
‼57:                  Array.Copy(data, i, vi, 0, cl >= 5 ? 5 : cl);
〰58:  
‼59:                  vo[0] = (byte)((vi[0] & 0xf8) / 8);
‼60:                  vo[1] = (byte)((vi[0] & 0x7) * 4 + (vi[1] & 0xc0) / 64);
‼61:                  vo[2] = (byte)((vi[1] & 0x3E) / 2);
‼62:                  vo[3] = (byte)((vi[1] & 0x1) * 16 + (vi[2] & 0xF0) / 16);
‼63:                  vo[4] = (byte)((vi[2] & 0xF) * 2 + (vi[3] & 0x80) / 128);
‼64:                  vo[5] = (byte)((vi[3] & 0x7E) / 4);
‼65:                  vo[6] = (byte)((vi[3] & 0x3) * 8 + (vi[4] & 0xE0) / 32);
‼66:                  vo[7] = (byte)((vi[4] & 0x1F));
〰67:  
‼68:                  if (cl < 5)
〰69:                  {
‼70:                      var o = (int)Math.Ceiling(cl * 8d / 5d);
〰71:  
‼72:                      Array.Copy(new byte[] { 32, 32, 32, 32, 32, 32, 32, 32 }, 0, vo, o, 8 - o);
〰73:                  }
〰74:  
‼75:                  sb.Append(string.Join("", vo.Select(o => _base32Alphabet[o])));
〰76:              }
〰77:  
‼78:              return sb.ToString();
〰79:          }
〰80:  
〰81:          /// <summary>
〰82:          /// Decode base32 string into 8bit binary
〰83:          /// </summary>
〰84:          /// <param name="input">base32 string</param>
〰85:          /// <returns>8bit data</returns>
〰86:          public byte[] Decode(string input)
〰87:          {
‼88:              var vi = new byte[8];
‼89:              var vo = new byte[5];
‼90:              var l = input.Length;
〰91:  
‼92:              var m = input.Length % 8;
‼93:              if (m != 0)
‼94:                  input += new string('=', 8 - m);
〰95:  
‼96:              var iData = input.Select(c => (byte)_base32Alphabet.IndexOf(c))
‼97:                               .Select(c => c == 32 ? (byte)0 : c)
‼98:                               .ToArray();
‼99:              var oData = new byte[(int)(input.TrimEnd('=').Length * 5 / 8)];
〰100: 
‼101:             for (int i = 0, o = 0; i < l; i += 8, o += 5)
〰102:             {
‼103:                 Array.Copy(iData, i, vi, 0, 8);
〰104: 
‼105:                 vo[0] = (byte)((vi[0]) * 8 + (vi[1] & 0x1C) / 4);
‼106:                 vo[1] = (byte)((vi[1] & 0x3) * 64 + (vi[2]) * 2 + (vi[3] & 0x10) / 16);
‼107:                 vo[2] = (byte)((vi[3] & 0xF) * 16 + (vi[4] & 0x1E) / 2);
‼108:                 vo[3] = (byte)((vi[4] & 0x1) * 128 + (vi[5]) * 4 + (vi[6] & 0x18) / 8);
‼109:                 vo[4] = (byte)((vi[6] & 0x7) * 32 + (vi[7]));
〰110: 
‼111:                 var cl = oData.Length - o;
‼112:                 Array.Copy(vo, 0, oData, o, cl < 5 ? cl : 5);
〰113: 
〰114:             }
〰115: 
‼116:             return oData;
〰117:         }
〰118:     }
〰119: }

```
## Footer 
[Return to Summary](Summary.md)

