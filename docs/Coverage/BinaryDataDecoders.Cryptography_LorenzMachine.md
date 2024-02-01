# BinaryDataDecoders.Cryptography.Lorenz.LorenzMachine

## Summary

| Key             | Value                                                  |
| :-------------- | :----------------------------------------------------- |
| Class           | `BinaryDataDecoders.Cryptography.Lorenz.LorenzMachine` |
| Assembly        | `BinaryDataDecoders.Cryptography`                      |
| Coveredlines    | `88`                                                   |
| Uncoveredlines  | `88`                                                   |
| Coverablelines  | `176`                                                  |
| Totallines      | `337`                                                  |
| Linecoverage    | `50`                                                   |
| Coveredbranches | `16`                                                   |
| Totalbranches   | `32`                                                   |
| Branchcoverage  | `50`                                                   |
| Coveredmethods  | `3`                                                    |
| Totalmethods    | `6`                                                    |
| Methodcoverage  | `50`                                                   |

## Metrics

| Complexity | Lines | Branches | Name     |
| :--------- | :---- | :------- | :------- |
| 1          | 0     | 100      | `cctor`  |
| 1          | 0     | 100      | `ctor`   |
| 16         | 0     | 0        | `Encode` |
| 1          | 100   | 100      | `cctor`  |
| 1          | 100   | 100      | `ctor`   |
| 16         | 100   | 100      | `Encode` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Cryptography/Lorenz/LorenzMachine.cs

```CSharp
〰1:   using System.Collections;
〰2:   using System.Linq;
〰3:   
〰4:   namespace BinaryDataDecoders.Cryptography.Lorenz;
〰5:   
〰6:   // https://www.codesandciphers.org.uk/cevent2.htm
〰7:   // https://lorenz.virtualcolossus.co.uk/LorenzSZ/#
〰8:   public class LorenzMachine(byte[] keySet, int[] startPosition)
〰9:   {
〰10:  
‼11:      public static readonly (byte[] key, int[] start) ZMUG = (new byte[]
‼12:      {
‼13:          0b00011100,0b11100111,0b10001100,0b01100111,
‼14:          0b00011001,0b01111010,0b01110011,0b10011000,
‼15:          0b11110001,0b11001100,0b11100010,0b00111001,
‼16:          0b10001100,0b01110001,0b00011110,0b00100111,
‼17:          0b00111001,0b10010101,0b11001100,0b01100100,
‼18:          0b11100110,0b00100011,0b11001110,0b01100111,
‼19:          0b00001100,0b01001110,0b01100111,0b00110001,
‼20:          0b11100100,0b11100111,0b10001000,0b11100111,
‼21:          0b10111011,0b10101101,0b11011101,0b10101101,
‼22:          0b01010101,0b01111010,0b10111011,0b10111011,
‼23:          0b01101101,0b10111010,0b10111011,0b10101101,
‼24:          0b01100111,0b00001110,0b01110000,0b10011011,
‼25:          0b00011011,0b00001100,0b11000101,0b11101110,
‼26:          0b00011011,0b01111011,0b00011100,0b01100011,
‼27:          0b00100101,0b00111010,0b01100011,0b00101011,
‼28:          0b01000011,0b10100011,0b11001000,0b00000000,
‼29:      }, new[] {
‼30:          29, 1, 38, 53, 3,
‼31:          1, 51,
‼32:          33, 22, 28, 15, 19,
‼33:      });
〰34:  
〰35:      // https://en.wikipedia.org/wiki/Baudot_code#ITA2
‼36:      private readonly string _ita2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ012345";
〰37:  
〰38:      public string Encode(string input)
〰39:      {
‼40:          var chars = input.ToUpper()
‼41:                           .Replace('+', '5')
‼42:                           .Select(i => _ita2.IndexOf(i))
‼43:                           .Where(i => i >= 0)
‼44:                           .ToArray();
〰45:  
‼46:          var key = new BitArray(keySet);
〰47:  
‼48:          var output = new char[chars.Length];
〰49:  
‼50:          var keyOffsets = new[]
‼51:          {
‼52:               _chiModulus.Take(0).Sum(),
‼53:               _chiModulus.Take(1).Sum(),
‼54:               _chiModulus.Take(2).Sum(),
‼55:               _chiModulus.Take(3).Sum(),
‼56:               _chiModulus.Take(4).Sum(),
‼57:  
‼58:               _chiModulus.Concat(_muModulus.Take(0)).Sum(),
‼59:               _chiModulus.Concat(_muModulus.Take(1)).Sum(),
‼60:  
‼61:               _chiModulus.Concat(_muModulus).Concat(_psiModulus.Take(0)).Sum(),
‼62:               _chiModulus.Concat(_muModulus).Concat(_psiModulus.Take(1)).Sum(),
‼63:               _chiModulus.Concat(_muModulus).Concat(_psiModulus.Take(2)).Sum(),
‼64:               _chiModulus.Concat(_muModulus).Concat(_psiModulus.Take(3)).Sum(),
‼65:               _chiModulus.Concat(_muModulus).Concat(_psiModulus.Take(4)).Sum(),
‼66:          };
〰67:  
‼68:          for (int chi = 0, mu = 0, psi = 0; chi < chars.Length; chi++)
〰69:          {
‼70:              var bit1 = (chars[chi] & 0b10000) >> 4 == 1;
‼71:              var bit2 = (chars[chi] & 0b01000) >> 3 == 1;
‼72:              var bit3 = (chars[chi] & 0b00100) >> 2 == 1;
‼73:              var bit4 = (chars[chi] & 0b00010) >> 1 == 1;
‼74:              var bit5 = (chars[chi] & 0b00001) >> 0 == 1;
〰75:  
‼76:              var chi1 = (chi + startPosition[0]) % _chiModulus[0];
‼77:              var chi2 = (chi + startPosition[1]) % _chiModulus[1];
‼78:              var chi3 = (chi + startPosition[2]) % _chiModulus[2];
‼79:              var chi4 = (chi + startPosition[3]) % _chiModulus[3];
‼80:              var chi5 = (chi + startPosition[4]) % _chiModulus[4];
〰81:  
‼82:              var mu1 = (chi + startPosition[5]) % _muModulus[0];
〰83:  
‼84:              if (key[mu1]) mu++;
‼85:              var mu2 = (mu + startPosition[6]) % _muModulus[1];
〰86:  
‼87:              if (key[mu2]) psi++;
〰88:  
‼89:              var psi1 = (psi + startPosition[7]) % _psiModulus[0];
‼90:              var psi2 = (psi + startPosition[8]) % _psiModulus[1];
‼91:              var psi3 = (psi + startPosition[9]) % _psiModulus[2];
‼92:              var psi4 = (psi + startPosition[10]) % _psiModulus[3];
‼93:              var psi5 = (psi + startPosition[11]) % _psiModulus[4];
〰94:  
‼95:              var z1 = (bit1 ^ key[chi1 + keyOffsets[0]] ^ key[psi1 + keyOffsets[7]]) ? 1 : 0;
‼96:              var z2 = (bit2 ^ key[chi2 + keyOffsets[1]] ^ key[psi2 + keyOffsets[8]]) ? 1 : 0;
‼97:              var z3 = (bit3 ^ key[chi3 + keyOffsets[2]] ^ key[psi3 + keyOffsets[9]]) ? 1 : 0;
‼98:              var z4 = (bit4 ^ key[chi4 + keyOffsets[3]] ^ key[psi4 + keyOffsets[10]]) ? 1 : 0;
‼99:              var z5 = (bit5 ^ key[chi5 + keyOffsets[4]] ^ key[psi5 + keyOffsets[11]]) ? 1 : 0;
〰100: 
‼101:             var z = z1 << 4 | z2 << 3 | z3 << 2 | z4 << 1 | z5;
〰102: 
‼103:             output[chi] = _ita2[z % _ita2.Length];
〰104:         }
〰105: 
‼106:         return new string(output);
〰107:     }
〰108: 
〰109:     /*
〰110:     chi = 41 31 29 26 31
〰111:     psi = 43 47 51 53 29
〰112:     u = 61 37
〰113:     */
〰114: 
〰115:     //always advance
‼116:     private readonly int[] _chiModulus =
‼117:     [
‼118:         41,31,29,26,23
‼119:     ];
〰120:     //0 always advance, 1 only advance if 0 is 1
‼121:     private readonly int[] _muModulus =
‼122:     [
‼123:         61,37
‼124:     ];
〰125:     //only advance if mu 1 is 1
‼126:     private readonly int[] _psiModulus =
‼127:     [
‼128:         43,47,51,53,59
‼129:     ];
〰130:     /*
〰131: VIRTUAL LORENZ SETTINGS
〰132: 
〰133: EXPORT FORMAT: TUNNY
〰134: MODEL: SZ42A
〰135: P5 LIMITATION: OFF
〰136: 
〰137: WHEEL SETTINGS
〰138: PSI 1:  ...xxx..xxx..xxxx...xx...xx..xxx...xx..x.xx
〰139: PSI 2:  xx.x..xxx..xxx..xx...xxxx...xxx..xx..xxx...x...
〰140: PSI 3:  xxx..xx...xx...xxx...x...xxxx...x..xxx..xxx..xx..x.
〰141: PSI 4:  x.xxx..xx...xx..x..xxx..xx...x...xxxx..xxx..xx..xxx..
〰142: PSI 5:  ..xx...x..xxx..xx..xxx..xx...xxxx..x..xxx..xxxx...x...xxx..x
〰143: MU  6:  xxx.xxx.xxx.x.xx.xxx.xxx.xx.x.xx.x.x.
〰144: MU  7:  x.x.x.xxxx.x.x.xxx.xxx.xxx.xx.xx.xx.xx.xxx.x.x.xxx.xxx.x.xx.x
〰145: CHI 8:  .xx..xxx....xxx..xxx....x..xx.xx...xx.xx.
〰146: CHI 9:  ...xx..xx...x.xxxx.xxx....xx.xx
〰147: CHI 10: .xxxx.xx...xxx...xx...xx..x..
〰148: CHI 11: x.x..xxx.x..xx...xx..x.x.x
〰149: CHI 12: x.x....xxx.x...xxxx..x.
〰150: 
〰151: WHEEL STARTS
〰152: ST 1:  29
〰153: ST 2:  1
〰154: ST 3:  38
〰155: ST 4:  53
〰156: ST 5:  3
〰157: ST 6:  1
〰158: ST 7:  51
〰159: ST 8:  33
〰160: ST 9:  22
〰161: ST 10: 28
〰162: ST 11: 15
〰163: ST 12: 19
〰164: 
〰165: 
〰166: WWW.VIRTUALCOLOSSUS.CO.UK
〰167:     */
〰168: }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.Cryptography/Lorenz/LorenzMachine.cs

```CSharp
〰1:   using System.Collections;
〰2:   using System.Linq;
〰3:   
〰4:   namespace BinaryDataDecoders.Cryptography.Lorenz;
〰5:   
〰6:   // https://www.codesandciphers.org.uk/cevent2.htm
〰7:   // https://lorenz.virtualcolossus.co.uk/LorenzSZ/#
〰8:   public class LorenzMachine(byte[] keySet, int[] startPosition)
〰9:   {
〰10:  
✔11:      public static readonly (byte[] key, int[] start) ZMUG = (new byte[]
✔12:      {
✔13:          0b00011100,0b11100111,0b10001100,0b01100111,
✔14:          0b00011001,0b01111010,0b01110011,0b10011000,
✔15:          0b11110001,0b11001100,0b11100010,0b00111001,
✔16:          0b10001100,0b01110001,0b00011110,0b00100111,
✔17:          0b00111001,0b10010101,0b11001100,0b01100100,
✔18:          0b11100110,0b00100011,0b11001110,0b01100111,
✔19:          0b00001100,0b01001110,0b01100111,0b00110001,
✔20:          0b11100100,0b11100111,0b10001000,0b11100111,
✔21:          0b10111011,0b10101101,0b11011101,0b10101101,
✔22:          0b01010101,0b01111010,0b10111011,0b10111011,
✔23:          0b01101101,0b10111010,0b10111011,0b10101101,
✔24:          0b01100111,0b00001110,0b01110000,0b10011011,
✔25:          0b00011011,0b00001100,0b11000101,0b11101110,
✔26:          0b00011011,0b01111011,0b00011100,0b01100011,
✔27:          0b00100101,0b00111010,0b01100011,0b00101011,
✔28:          0b01000011,0b10100011,0b11001000,0b00000000,
✔29:      }, new[] {
✔30:          29, 1, 38, 53, 3,
✔31:          1, 51,
✔32:          33, 22, 28, 15, 19,
✔33:      });
〰34:  
〰35:      // https://en.wikipedia.org/wiki/Baudot_code#ITA2
✔36:      private readonly string _ita2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ012345";
〰37:  
〰38:      public string Encode(string input)
〰39:      {
✔40:          var chars = input.ToUpper()
✔41:                           .Replace('+', '5')
✔42:                           .Select(i => _ita2.IndexOf(i))
✔43:                           .Where(i => i >= 0)
✔44:                           .ToArray();
〰45:  
✔46:          var key = new BitArray(keySet);
〰47:  
✔48:          var output = new char[chars.Length];
〰49:  
✔50:          var keyOffsets = new[]
✔51:          {
✔52:               _chiModulus.Take(0).Sum(),
✔53:               _chiModulus.Take(1).Sum(),
✔54:               _chiModulus.Take(2).Sum(),
✔55:               _chiModulus.Take(3).Sum(),
✔56:               _chiModulus.Take(4).Sum(),
✔57:  
✔58:               _chiModulus.Concat(_muModulus.Take(0)).Sum(),
✔59:               _chiModulus.Concat(_muModulus.Take(1)).Sum(),
✔60:  
✔61:               _chiModulus.Concat(_muModulus).Concat(_psiModulus.Take(0)).Sum(),
✔62:               _chiModulus.Concat(_muModulus).Concat(_psiModulus.Take(1)).Sum(),
✔63:               _chiModulus.Concat(_muModulus).Concat(_psiModulus.Take(2)).Sum(),
✔64:               _chiModulus.Concat(_muModulus).Concat(_psiModulus.Take(3)).Sum(),
✔65:               _chiModulus.Concat(_muModulus).Concat(_psiModulus.Take(4)).Sum(),
✔66:          };
〰67:  
✔68:          for (int chi = 0, mu = 0, psi = 0; chi < chars.Length; chi++)
〰69:          {
✔70:              var bit1 = (chars[chi] & 0b10000) >> 4 == 1;
✔71:              var bit2 = (chars[chi] & 0b01000) >> 3 == 1;
✔72:              var bit3 = (chars[chi] & 0b00100) >> 2 == 1;
✔73:              var bit4 = (chars[chi] & 0b00010) >> 1 == 1;
✔74:              var bit5 = (chars[chi] & 0b00001) >> 0 == 1;
〰75:  
✔76:              var chi1 = (chi + startPosition[0]) % _chiModulus[0];
✔77:              var chi2 = (chi + startPosition[1]) % _chiModulus[1];
✔78:              var chi3 = (chi + startPosition[2]) % _chiModulus[2];
✔79:              var chi4 = (chi + startPosition[3]) % _chiModulus[3];
✔80:              var chi5 = (chi + startPosition[4]) % _chiModulus[4];
〰81:  
✔82:              var mu1 = (chi + startPosition[5]) % _muModulus[0];
〰83:  
✔84:              if (key[mu1]) mu++;
✔85:              var mu2 = (mu + startPosition[6]) % _muModulus[1];
〰86:  
✔87:              if (key[mu2]) psi++;
〰88:  
✔89:              var psi1 = (psi + startPosition[7]) % _psiModulus[0];
✔90:              var psi2 = (psi + startPosition[8]) % _psiModulus[1];
✔91:              var psi3 = (psi + startPosition[9]) % _psiModulus[2];
✔92:              var psi4 = (psi + startPosition[10]) % _psiModulus[3];
✔93:              var psi5 = (psi + startPosition[11]) % _psiModulus[4];
〰94:  
✔95:              var z1 = (bit1 ^ key[chi1 + keyOffsets[0]] ^ key[psi1 + keyOffsets[7]]) ? 1 : 0;
✔96:              var z2 = (bit2 ^ key[chi2 + keyOffsets[1]] ^ key[psi2 + keyOffsets[8]]) ? 1 : 0;
✔97:              var z3 = (bit3 ^ key[chi3 + keyOffsets[2]] ^ key[psi3 + keyOffsets[9]]) ? 1 : 0;
✔98:              var z4 = (bit4 ^ key[chi4 + keyOffsets[3]] ^ key[psi4 + keyOffsets[10]]) ? 1 : 0;
✔99:              var z5 = (bit5 ^ key[chi5 + keyOffsets[4]] ^ key[psi5 + keyOffsets[11]]) ? 1 : 0;
〰100: 
✔101:             var z = z1 << 4 | z2 << 3 | z3 << 2 | z4 << 1 | z5;
〰102: 
✔103:             output[chi] = _ita2[z % _ita2.Length];
〰104:         }
〰105: 
✔106:         return new string(output);
〰107:     }
〰108: 
〰109:     /*
〰110:     chi = 41 31 29 26 31
〰111:     psi = 43 47 51 53 29
〰112:     u = 61 37
〰113:     */
〰114: 
〰115:     //always advance
✔116:     private readonly int[] _chiModulus =
✔117:     [
✔118:         41,31,29,26,23
✔119:     ];
〰120:     //0 always advance, 1 only advance if 0 is 1
✔121:     private readonly int[] _muModulus =
✔122:     [
✔123:         61,37
✔124:     ];
〰125:     //only advance if mu 1 is 1
✔126:     private readonly int[] _psiModulus =
✔127:     [
✔128:         43,47,51,53,59
✔129:     ];
〰130:     /*
〰131: VIRTUAL LORENZ SETTINGS
〰132: 
〰133: EXPORT FORMAT: TUNNY
〰134: MODEL: SZ42A
〰135: P5 LIMITATION: OFF
〰136: 
〰137: WHEEL SETTINGS
〰138: PSI 1:  ...xxx..xxx..xxxx...xx...xx..xxx...xx..x.xx
〰139: PSI 2:  xx.x..xxx..xxx..xx...xxxx...xxx..xx..xxx...x...
〰140: PSI 3:  xxx..xx...xx...xxx...x...xxxx...x..xxx..xxx..xx..x.
〰141: PSI 4:  x.xxx..xx...xx..x..xxx..xx...x...xxxx..xxx..xx..xxx..
〰142: PSI 5:  ..xx...x..xxx..xx..xxx..xx...xxxx..x..xxx..xxxx...x...xxx..x
〰143: MU  6:  xxx.xxx.xxx.x.xx.xxx.xxx.xx.x.xx.x.x.
〰144: MU  7:  x.x.x.xxxx.x.x.xxx.xxx.xxx.xx.xx.xx.xx.xxx.x.x.xxx.xxx.x.xx.x
〰145: CHI 8:  .xx..xxx....xxx..xxx....x..xx.xx...xx.xx.
〰146: CHI 9:  ...xx..xx...x.xxxx.xxx....xx.xx
〰147: CHI 10: .xxxx.xx...xxx...xx...xx..x..
〰148: CHI 11: x.x..xxx.x..xx...xx..x.x.x
〰149: CHI 12: x.x....xxx.x...xxxx..x.
〰150: 
〰151: WHEEL STARTS
〰152: ST 1:  29
〰153: ST 2:  1
〰154: ST 3:  38
〰155: ST 4:  53
〰156: ST 5:  3
〰157: ST 6:  1
〰158: ST 7:  51
〰159: ST 8:  33
〰160: ST 9:  22
〰161: ST 10: 28
〰162: ST 11: 15
〰163: ST 12: 19
〰164: 
〰165: 
〰166: WWW.VIRTUALCOLOSSUS.CO.UK
〰167:     */
〰168: }
〰169: 
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

