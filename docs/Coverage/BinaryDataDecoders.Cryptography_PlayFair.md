# BinaryDataDecoders.Cryptography.PlayFair

## Summary

| Key             | Value                                      |
| :-------------- | :----------------------------------------- |
| Class           | `BinaryDataDecoders.Cryptography.PlayFair` |
| Assembly        | `BinaryDataDecoders.Cryptography`          |
| Coveredlines    | `0`                                        |
| Uncoveredlines  | `178`                                      |
| Coverablelines  | `178`                                      |
| Totallines      | `385`                                      |
| Linecoverage    | `0`                                        |
| Coveredbranches | `0`                                        |
| Totalbranches   | `104`                                      |
| Branchcoverage  | `0`                                        |
| Coveredmethods  | `0`                                        |
| Totalmethods    | `4`                                        |
| Methodcoverage  | `0`                                        |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 20         | 0     | 0        | `BuildKey` |
| 32         | 0     | 0        | `Cipher`   |
| 20         | 0     | 0        | `BuildKey` |
| 32         | 0     | 0        | `Cipher`   |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Cryptography/PlayFair.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Text;
〰4:   
〰5:   namespace BinaryDataDecoders.Cryptography;
〰6:   
〰7:   public class PlayFair
〰8:   {
〰9:       /*
〰10:      [edit] Using Playfair
〰11:      The Playfair cipher uses a 5 by 5 table containing a key word or phrase. Memorization of the keyword and 4 simple rules was all that was required to create the 5 by 5 table and use the cipher.
〰12:  
〰13:      To generate the key table, one would first fill in the spaces in the table with the letters of the keyword (dropping any duplicate letters), then fill the remaining spaces with the rest of the letters of the alphabet in order (usually omitting "Q" to reduce the alphabet to fit, other versions put both "I" and "J" in the same space). The key can be written in the top rows of the table, from left to right, or in some other pattern, such as a spiral beginning in the upper-left-hand corner and ending in the center. The keyword together with the conventions for filling in the 5 by 5 table constitute the cipher key.
〰14:  
〰15:      To encrypt a message, one would break the message into digraphs (groups of 2 letters) such that, for example, "HelloWorld" becomes "HE LL OW OR LD", and map them out on the key table. The two letters of the digraph look like the corners of a rectangle in the key table. Note the relative position of the corners of this rectangle. Then apply the following 4 rules, in order, to each pair of letters in the plaintext:
〰16:  
〰17:      If both letters are the same (or only one letter is left), add an "X" after the first letter. Encrypt the new pair and continue. Some variants of Playfair use "Q" instead of "X", but any uncommon monograph will do.
〰18:      If the letters appear on the same row of your table, replace them with the letters to their immediate right respectively (wrapping around to the left side of the row if a letter in the original pair was on the right side of the row).
〰19:      If the letters appear on the same column of your table, replace them with the letters immediately below respectively (wrapping around to the top side of the column if a letter in the original pair was on the bottom side of the column).
〰20:      If the letters are not on the same row or column, replace them with the letters on the same row respectively but at the other pair of corners of the rectangle defined by the original pair. The order is important – the first encrypted letter of the pair is the one that lies on the same row as the first plaintext letter.
〰21:      To decrypt, use the inverse of these 4 rules (dropping any extra "X"s (or "Q"s) that don't make sense in the final message when you finish).
〰22:      */
〰23:      public enum Mode
〰24:      {
〰25:          Q = 1, //to X
〰26:          J = 2, //to I
〰27:          I = 3  //to J
〰28:      }
〰29:  
〰30:      public enum Swap
〰31:      {
〰32:          X = 1,
〰33:          Z = 2
〰34:      }
〰35:  
〰36:      public static char[] BuildKey(string key, Mode mode, Swap swap)
〰37:      {
‼38:          if (string.IsNullOrEmpty(key))
‼39:              throw new ArgumentNullException(nameof(key));
〰40:  
‼41:          string seed = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
〰42:  
‼43:          char[] cipherKey = new char[5 * 5];
‼44:          key = key.ToUpper();
〰45:          char cMode;
‼46:          var cSwap = swap switch
‼47:          {
‼48:              Swap.X => 'X',
‼49:              Swap.Z => 'Z',
‼50:              _ => throw new ArgumentOutOfRangeException(nameof(swap)),
‼51:          };
〰52:          switch (mode)
〰53:          {
〰54:              case Mode.Q:
‼55:                  cMode = 'Q';
‼56:                  key = key.Replace('Q', cSwap);
‼57:                  break;
〰58:              case Mode.J:
‼59:                  cMode = 'J';
‼60:                  key = key.Replace('J', 'I');
‼61:                  break;
〰62:              case Mode.I:
‼63:                  cMode = 'I';
‼64:                  key = key.Replace('I', 'J');
‼65:                  break;
〰66:              default:
‼67:                  throw new ArgumentOutOfRangeException(nameof(mode));
〰68:          }
‼69:          seed = seed.Replace(cMode.ToString(), "");
‼70:          int pos = 0;
〰71:  
‼72:          foreach (char currentChar in key.ToCharArray())
〰73:          {
‼74:              if (seed.IndexOf(currentChar) >= 0)
〰75:              {
‼76:                  seed = seed.Replace(currentChar.ToString(), "");
‼77:                  cipherKey[pos++] = currentChar;
〰78:              }
〰79:  
‼80:              if (pos >= cipherKey.Length)
〰81:                  break;
〰82:          }
〰83:  
‼84:          foreach (char currentChar in seed.ToCharArray())
〰85:          {
‼86:              if (pos >= cipherKey.Length)
〰87:                  break;
‼88:              cipherKey[pos++] = currentChar;
〰89:          }
〰90:  
‼91:          return cipherKey;
〰92:      }
〰93:  
〰94:      public static string Cipher(char[] cryptic, string message, Mode mode, Swap swap)
〰95:      {
‼96:          if (cryptic == null)
‼97:              throw new ArgumentNullException(nameof(cryptic));
〰98:  
‼99:          if (cryptic.Length != 25)
‼100:             throw new ArgumentOutOfRangeException(nameof(cryptic));
〰101: 
‼102:         if (string.IsNullOrEmpty(message))
‼103:             throw new ArgumentNullException(nameof(message));
〰104: 
‼105:         message = message.ToUpper();
〰106:         char cMode;
〰107: 
‼108:         var cSwap = swap switch
‼109:         {
‼110:             Swap.X => 'X',
‼111:             Swap.Z => 'Z',
‼112:             _ => throw new ArgumentOutOfRangeException(nameof(swap)),
‼113:         };
‼114:         string check = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
〰115:         switch (mode)
〰116:         {
〰117:             case Mode.Q:
〰118:                 cMode = 'Q';
‼119:                 check = check.Replace("Q", "");
‼120:                 message = message.Replace('Q', cSwap);
‼121:                 break;
〰122:             case Mode.J:
〰123:                 cMode = 'J';
‼124:                 check = check.Replace("J", "");
‼125:                 message = message.Replace('J', 'I');
‼126:                 break;
〰127:             case Mode.I:
〰128:                 cMode = 'I';
‼129:                 check = check.Replace("I", "");
‼130:                 message = message.Replace('I', 'J');
‼131:                 break;
〰132:             default:
‼133:                 throw new ArgumentOutOfRangeException(nameof(mode));
〰134:         }
〰135: 
‼136:         List<char> newMessage = new();
‼137:         foreach (char currentChar in message.ToCharArray())
‼138:             if (check.IndexOf(currentChar) >= 0)
‼139:                 newMessage.Add(currentChar);
‼140:         message = new string(newMessage.ToArray());
〰141: 
‼142:         foreach (char currentChar in check.ToCharArray())
〰143:         {
‼144:             if (currentChar != cSwap)
‼145:                 message = message.Replace(
‼146:                     new string(new char[] { currentChar, currentChar }),
‼147:                     new string(new char[] { currentChar, cSwap, currentChar }));
〰148:         }
〰149: 
‼150:         message = message.PadRight(message.Length + (message.Length % 2), cSwap);
〰151: 
‼152:         string sCryptic = new(cryptic);
〰153: 
‼154:         List<char> cipherText = new();
〰155: 
‼156:         for (int i = 0; i < message.Length; i += 2)
〰157:         {
‼158:             int p1 = sCryptic.IndexOf(message[i]);
‼159:             int p2 = sCryptic.IndexOf(message[i + 1]);
〰160: 
‼161:             int mn = Math.Min(p1, p2);
‼162:             int mx = Math.Max(p1, p2);
〰163: 
‼164:             bool column = mn % 5 == mx % 5;
‼165:             bool row = mx - mn < 5;
〰166: 
‼167:             if (row)
〰168:             {
‼169:                 p1 = p1++ % 5 == 0 ? p1 - 5 : p1;
‼170:                 p2 = p2++ % 5 == 0 ? p2 - 5 : p2;
〰171:             }
‼172:             else if (column)
〰173:             {
‼174:                 p1 = p1 += 5 >= 25 ? p1 - 25 : p1;
‼175:                 p2 = p2 += 5 >= 25 ? p2 - 25 : p2;
〰176:             }
〰177:             else
〰178:             {
‼179:                 int x1 = p1 % 5;
‼180:                 int y1 = p1 / 5;
〰181: 
‼182:                 int x2 = p2 % 5;
‼183:                 int y2 = p2 / 5;
〰184:             }
〰185: 
‼186:             cipherText.Add(sCryptic[p1]);
‼187:             cipherText.Add(sCryptic[p2]);
〰188:         }
〰189: 
‼190:         return new string(cipherText.ToArray());
〰191:     }
〰192: }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.Cryptography/PlayFair.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Text;
〰4:   
〰5:   namespace BinaryDataDecoders.Cryptography;
〰6:   
〰7:   public class PlayFair
〰8:   {
〰9:       /*
〰10:      [edit] Using Playfair
〰11:      The Playfair cipher uses a 5 by 5 table containing a key word or phrase. Memorization of the keyword and 4 simple rules was all that was required to create the 5 by 5 table and use the cipher.
〰12:  
〰13:      To generate the key table, one would first fill in the spaces in the table with the letters of the keyword (dropping any duplicate letters), then fill the remaining spaces with the rest of the letters of the alphabet in order (usually omitting "Q" to reduce the alphabet to fit, other versions put both "I" and "J" in the same space). The key can be written in the top rows of the table, from left to right, or in some other pattern, such as a spiral beginning in the upper-left-hand corner and ending in the center. The keyword together with the conventions for filling in the 5 by 5 table constitute the cipher key.
〰14:  
〰15:      To encrypt a message, one would break the message into digraphs (groups of 2 letters) such that, for example, "HelloWorld" becomes "HE LL OW OR LD", and map them out on the key table. The two letters of the digraph look like the corners of a rectangle in the key table. Note the relative position of the corners of this rectangle. Then apply the following 4 rules, in order, to each pair of letters in the plaintext:
〰16:  
〰17:      If both letters are the same (or only one letter is left), add an "X" after the first letter. Encrypt the new pair and continue. Some variants of Playfair use "Q" instead of "X", but any uncommon monograph will do.
〰18:      If the letters appear on the same row of your table, replace them with the letters to their immediate right respectively (wrapping around to the left side of the row if a letter in the original pair was on the right side of the row).
〰19:      If the letters appear on the same column of your table, replace them with the letters immediately below respectively (wrapping around to the top side of the column if a letter in the original pair was on the bottom side of the column).
〰20:      If the letters are not on the same row or column, replace them with the letters on the same row respectively but at the other pair of corners of the rectangle defined by the original pair. The order is important – the first encrypted letter of the pair is the one that lies on the same row as the first plaintext letter.
〰21:      To decrypt, use the inverse of these 4 rules (dropping any extra "X"s (or "Q"s) that don't make sense in the final message when you finish).
〰22:      */
〰23:      public enum Mode
〰24:      {
〰25:          Q = 1, //to X
〰26:          J = 2, //to I
〰27:          I = 3  //to J
〰28:      }
〰29:  
〰30:      public enum Swap
〰31:      {
〰32:          X = 1,
〰33:          Z = 2
〰34:      }
〰35:  
〰36:      public static char[] BuildKey(string key, Mode mode, Swap swap)
〰37:      {
‼38:          if (string.IsNullOrEmpty(key))
‼39:              throw new ArgumentNullException(nameof(key));
〰40:  
‼41:          string seed = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
〰42:  
‼43:          char[] cipherKey = new char[5 * 5];
‼44:          key = key.ToUpper();
〰45:          char cMode;
‼46:          var cSwap = swap switch
‼47:          {
‼48:              Swap.X => 'X',
‼49:              Swap.Z => 'Z',
‼50:              _ => throw new ArgumentOutOfRangeException(nameof(swap)),
‼51:          };
〰52:          switch (mode)
〰53:          {
〰54:              case Mode.Q:
‼55:                  cMode = 'Q';
‼56:                  key = key.Replace('Q', cSwap);
‼57:                  break;
〰58:              case Mode.J:
‼59:                  cMode = 'J';
‼60:                  key = key.Replace('J', 'I');
‼61:                  break;
〰62:              case Mode.I:
‼63:                  cMode = 'I';
‼64:                  key = key.Replace('I', 'J');
‼65:                  break;
〰66:              default:
‼67:                  throw new ArgumentOutOfRangeException(nameof(mode));
〰68:          }
‼69:          seed = seed.Replace(cMode.ToString(), "");
‼70:          int pos = 0;
〰71:  
‼72:          foreach (char currentChar in key.ToCharArray())
〰73:          {
‼74:              if (seed.IndexOf(currentChar) >= 0)
〰75:              {
‼76:                  seed = seed.Replace(currentChar.ToString(), "");
‼77:                  cipherKey[pos++] = currentChar;
〰78:              }
〰79:  
‼80:              if (pos >= cipherKey.Length)
〰81:                  break;
〰82:          }
〰83:  
‼84:          foreach (char currentChar in seed.ToCharArray())
〰85:          {
‼86:              if (pos >= cipherKey.Length)
〰87:                  break;
‼88:              cipherKey[pos++] = currentChar;
〰89:          }
〰90:  
‼91:          return cipherKey;
〰92:      }
〰93:  
〰94:      public static string Cipher(char[] cryptic, string message, Mode mode, Swap swap)
〰95:      {
‼96:          if (cryptic == null)
‼97:              throw new ArgumentNullException(nameof(cryptic));
〰98:  
‼99:          if (cryptic.Length != 25)
‼100:             throw new ArgumentOutOfRangeException(nameof(cryptic));
〰101: 
‼102:         if (string.IsNullOrEmpty(message))
‼103:             throw new ArgumentNullException(nameof(message));
〰104: 
‼105:         message = message.ToUpper();
〰106:         char cMode;
〰107: 
‼108:         var cSwap = swap switch
‼109:         {
‼110:             Swap.X => 'X',
‼111:             Swap.Z => 'Z',
‼112:             _ => throw new ArgumentOutOfRangeException(nameof(swap)),
‼113:         };
‼114:         string check = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
〰115:         switch (mode)
〰116:         {
〰117:             case Mode.Q:
〰118:                 cMode = 'Q';
‼119:                 check = check.Replace("Q", "");
‼120:                 message = message.Replace('Q', cSwap);
‼121:                 break;
〰122:             case Mode.J:
〰123:                 cMode = 'J';
‼124:                 check = check.Replace("J", "");
‼125:                 message = message.Replace('J', 'I');
‼126:                 break;
〰127:             case Mode.I:
〰128:                 cMode = 'I';
‼129:                 check = check.Replace("I", "");
‼130:                 message = message.Replace('I', 'J');
‼131:                 break;
〰132:             default:
‼133:                 throw new ArgumentOutOfRangeException(nameof(mode));
〰134:         }
〰135: 
‼136:         List<char> newMessage = new();
‼137:         foreach (char currentChar in message.ToCharArray())
‼138:             if (check.IndexOf(currentChar) >= 0)
‼139:                 newMessage.Add(currentChar);
‼140:         message = new string(newMessage.ToArray());
〰141: 
‼142:         foreach (char currentChar in check.ToCharArray())
〰143:         {
‼144:             if (currentChar != cSwap)
‼145:                 message = message.Replace(
‼146:                     new string(new char[] { currentChar, currentChar }),
‼147:                     new string(new char[] { currentChar, cSwap, currentChar }));
〰148:         }
〰149: 
‼150:         message = message.PadRight(message.Length + (message.Length % 2), cSwap);
〰151: 
‼152:         string sCryptic = new(cryptic);
〰153: 
‼154:         List<char> cipherText = new();
〰155: 
‼156:         for (int i = 0; i < message.Length; i += 2)
〰157:         {
‼158:             int p1 = sCryptic.IndexOf(message[i]);
‼159:             int p2 = sCryptic.IndexOf(message[i + 1]);
〰160: 
‼161:             int mn = Math.Min(p1, p2);
‼162:             int mx = Math.Max(p1, p2);
〰163: 
‼164:             bool column = mn % 5 == mx % 5;
‼165:             bool row = mx - mn < 5;
〰166: 
‼167:             if (row)
〰168:             {
‼169:                 p1 = p1++ % 5 == 0 ? p1 - 5 : p1;
‼170:                 p2 = p2++ % 5 == 0 ? p2 - 5 : p2;
〰171:             }
‼172:             else if (column)
〰173:             {
‼174:                 p1 = p1 += 5 >= 25 ? p1 - 25 : p1;
‼175:                 p2 = p2 += 5 >= 25 ? p2 - 25 : p2;
〰176:             }
〰177:             else
〰178:             {
‼179:                 int x1 = p1 % 5;
‼180:                 int y1 = p1 / 5;
〰181: 
‼182:                 int x2 = p2 % 5;
‼183:                 int y2 = p2 / 5;
〰184:             }
〰185: 
‼186:             cipherText.Add(sCryptic[p1]);
‼187:             cipherText.Add(sCryptic[p2]);
〰188:         }
〰189: 
‼190:         return new string(cipherText.ToArray());
〰191:     }
〰192: }
〰193: 
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

