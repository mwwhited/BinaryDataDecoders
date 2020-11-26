# BinaryDataDecoders.Cryptography.PlayFair

## Summary

| Key             | Value                                      |
| :-------------- | :----------------------------------------- |
| Class           | `BinaryDataDecoders.Cryptography.PlayFair` |
| Assembly        | `BinaryDataDecoders.Cryptography`          |
| Coveredlines    | `0`                                        |
| Uncoveredlines  | `87`                                       |
| Coverablelines  | `87`                                       |
| Totallines      | `209`                                      |
| Linecoverage    | `0`                                        |
| Coveredbranches | `0`                                        |
| Totalbranches   | `52`                                       |
| Branchcoverage  | `0`                                        |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 20         | 0     | 0        | `BuildKey` |
| 32         | 0     | 0        | `Cipher`   |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Cryptography/PlayFair.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Text;
〰4:   
〰5:   namespace BinaryDataDecoders.Cryptography
〰6:   {
〰7:       public class PlayFair
〰8:       {
〰9:           /*
〰10:          [edit] Using Playfair
〰11:          The Playfair cipher uses a 5 by 5 table containing a key word or phrase. Memorization of the keyword and 4 simple rules was all that was required to create the 5 by 5 table and use the cipher.
〰12:  
〰13:          To generate the key table, one would first fill in the spaces in the table with the letters of the keyword (dropping any duplicate letters), then fill the remaining spaces with the rest of the letters of the alphabet in order (usually omitting "Q" to reduce the alphabet to fit, other versions put both "I" and "J" in the same space). The key can be written in the top rows of the table, from left to right, or in some other pattern, such as a spiral beginning in the upper-left-hand corner and ending in the center. The keyword together with the conventions for filling in the 5 by 5 table constitute the cipher key.
〰14:  
〰15:          To encrypt a message, one would break the message into digraphs (groups of 2 letters) such that, for example, "HelloWorld" becomes "HE LL OW OR LD", and map them out on the key table. The two letters of the digraph look like the corners of a rectangle in the key table. Note the relative position of the corners of this rectangle. Then apply the following 4 rules, in order, to each pair of letters in the plaintext:
〰16:  
〰17:          If both letters are the same (or only one letter is left), add an "X" after the first letter. Encrypt the new pair and continue. Some variants of Playfair use "Q" instead of "X", but any uncommon monograph will do.
〰18:          If the letters appear on the same row of your table, replace them with the letters to their immediate right respectively (wrapping around to the left side of the row if a letter in the original pair was on the right side of the row).
〰19:          If the letters appear on the same column of your table, replace them with the letters immediately below respectively (wrapping around to the top side of the column if a letter in the original pair was on the bottom side of the column).
〰20:          If the letters are not on the same row or column, replace them with the letters on the same row respectively but at the other pair of corners of the rectangle defined by the original pair. The order is important – the first encrypted letter of the pair is the one that lies on the same row as the first plaintext letter.
〰21:          To decrypt, use the inverse of these 4 rules (dropping any extra "X"s (or "Q"s) that don't make sense in the final message when you finish).
〰22:          */
〰23:          public enum Mode
〰24:          {
〰25:              Q = 1, //to X
〰26:              J = 2, //to I
〰27:              I = 3  //to J
〰28:          }
〰29:  
〰30:          public enum Swap
〰31:          {
〰32:              X = 1,
〰33:              Z = 2
〰34:          }
〰35:  
〰36:          public static char[] BuildKey(string key, Mode mode, Swap swap)
〰37:          {
‼38:              if (string.IsNullOrEmpty(key))
‼39:                  throw new ArgumentNullException("key");
〰40:  
‼41:              string seed = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
〰42:  
‼43:              char[] cipherKey = new char[5 * 5];
‼44:              key = key.ToUpper();
〰45:              char cSwap;
〰46:              char cMode;
〰47:  
〰48:              switch (swap)
〰49:              {
〰50:                  case Swap.X:
‼51:                      cSwap = 'X';
‼52:                      break;
〰53:                  case Swap.Z:
‼54:                      cSwap = 'Z';
‼55:                      break;
〰56:                  default:
‼57:                      throw new ArgumentOutOfRangeException("swap");
〰58:              }
〰59:  
〰60:              switch (mode)
〰61:              {
〰62:                  case Mode.Q:
‼63:                      cMode = 'Q';
‼64:                      key = key.Replace('Q', cSwap);
‼65:                      break;
〰66:                  case Mode.J:
‼67:                      cMode = 'J';
‼68:                      key = key.Replace('J', 'I');
‼69:                      break;
〰70:                  case Mode.I:
‼71:                      cMode = 'I';
‼72:                      key = key.Replace('I', 'J');
‼73:                      break;
〰74:                  default:
‼75:                      throw new ArgumentOutOfRangeException("mode");
〰76:              }
‼77:              seed = seed.Replace(cMode.ToString(), "");
‼78:              int pos = 0;
〰79:  
‼80:              foreach (char currentChar in key.ToCharArray())
〰81:              {
‼82:                  if (seed.IndexOf(currentChar) >= 0)
〰83:                  {
‼84:                      seed = seed.Replace(currentChar.ToString(), "");
‼85:                      cipherKey[pos++] = currentChar;
〰86:                  }
〰87:  
‼88:                  if (pos >= cipherKey.Length)
〰89:                      break;
〰90:              }
〰91:  
‼92:              foreach (char currentChar in seed.ToCharArray())
〰93:              {
‼94:                  if (pos >= cipherKey.Length)
〰95:                      break;
‼96:                  cipherKey[pos++] = currentChar;
〰97:              }
〰98:  
‼99:              return cipherKey;
〰100:         }
〰101: 
〰102:         public static string Cipher(char[] cryptic, string message, Mode mode, Swap swap)
〰103:         {
‼104:             if (cryptic == null)
‼105:                 throw new ArgumentNullException("cryptic");
〰106: 
‼107:             if (cryptic.Length != 25)
‼108:                 throw new ArgumentOutOfRangeException("cryptic");
〰109: 
‼110:             if (string.IsNullOrEmpty(message))
‼111:                 throw new ArgumentNullException("message");
〰112: 
‼113:             message = message.ToUpper();
〰114: 
〰115:             char cSwap;
〰116:             char cMode;
〰117: 
〰118:             switch (swap)
〰119:             {
〰120:                 case Swap.X:
‼121:                     cSwap = 'X';
‼122:                     break;
〰123:                 case Swap.Z:
‼124:                     cSwap = 'Z';
‼125:                     break;
〰126:                 default:
‼127:                     throw new ArgumentOutOfRangeException("swap");
〰128:             }
〰129: 
‼130:             string check = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
〰131:             switch (mode)
〰132:             {
〰133:                 case Mode.Q:
〰134:                     cMode = 'Q';
‼135:                     check = check.Replace("Q", "");
‼136:                     message = message.Replace('Q', cSwap);
‼137:                     break;
〰138:                 case Mode.J:
〰139:                     cMode = 'J';
‼140:                     check = check.Replace("J", "");
‼141:                     message = message.Replace('J', 'I');
‼142:                     break;
〰143:                 case Mode.I:
〰144:                     cMode = 'I';
‼145:                     check = check.Replace("I", "");
‼146:                     message = message.Replace('I', 'J');
‼147:                     break;
〰148:                 default:
‼149:                     throw new ArgumentOutOfRangeException("mode");
〰150:             }
〰151: 
‼152:             List<char> newMessage = new List<char>();
‼153:             foreach (char currentChar in message.ToCharArray())
‼154:                 if (check.IndexOf(currentChar) >= 0)
‼155:                     newMessage.Add(currentChar);
‼156:             message = new string(newMessage.ToArray());
〰157: 
‼158:             foreach (char currentChar in check.ToCharArray())
〰159:             {
‼160:                 if (currentChar != cSwap)
‼161:                     message = message.Replace(
‼162:                         new string(new char[] { currentChar, currentChar }),
‼163:                         new string(new char[] { currentChar, cSwap, currentChar }));
〰164:             }
〰165: 
‼166:             message = message.PadRight(message.Length + (message.Length % 2), cSwap);
〰167: 
‼168:             string sCryptic = new string(cryptic);
〰169: 
‼170:             List<char> cipherText = new List<char>();
〰171: 
‼172:             for (int i = 0; i < message.Length; i += 2)
〰173:             {
‼174:                 int p1 = sCryptic.IndexOf(message[i]);
‼175:                 int p2 = sCryptic.IndexOf(message[i + 1]);
〰176: 
‼177:                 int mn = Math.Min(p1, p2);
‼178:                 int mx = Math.Max(p1, p2);
〰179: 
‼180:                 bool column = mn % 5 == mx % 5;
‼181:                 bool row = mx - mn < 5;
〰182: 
‼183:                 if (row)
〰184:                 {
‼185:                     p1 = p1++ % 5 == 0 ? p1 - 5 : p1;
‼186:                     p2 = p2++ % 5 == 0 ? p2 - 5 : p2;
〰187:                 }
‼188:                 else if (column)
〰189:                 {
‼190:                     p1 = p1 += 5 >= 25 ? p1 - 25 : p1;
‼191:                     p2 = p2 += 5 >= 25 ? p2 - 25 : p2;
〰192:                 }
〰193:                 else
〰194:                 {
‼195:                     int x1 = p1 % 5;
‼196:                     int y1 = p1 / 5;
〰197: 
‼198:                     int x2 = p2 % 5;
‼199:                     int y2 = p2 / 5;
〰200:                 }
〰201: 
‼202:                 cipherText.Add(sCryptic[p1]);
‼203:                 cipherText.Add(sCryptic[p2]);
〰204:             }
〰205: 
‼206:             return new string(cipherText.ToArray());
〰207:         }
〰208:     }
〰209: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

