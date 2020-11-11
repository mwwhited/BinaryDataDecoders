# BinaryDataDecoders.Cryptography.Lorenz.LorenzMachine

## Summary

| Key             | Value                                                  |
| :-------------- | :----------------------------------------------------- |
| Class           | `BinaryDataDecoders.Cryptography.Lorenz.LorenzMachine` |
| Assembly        | `BinaryDataDecoders.Cryptography`                      |
| Coveredlines    | `0`                                                    |
| Uncoveredlines  | `92`                                                   |
| Coverablelines  | `92`                                                   |
| Totallines      | `183`                                                  |
| Linecoverage    | `0`                                                    |
| Coveredbranches | `0`                                                    |
| Totalbranches   | `16`                                                   |
| Branchcoverage  | `0`                                                    |

## Metrics

| Complexity | Lines | Branches | Name     |
| :--------- | :---- | :------- | :------- |
| 1          | 0     | 100      | `cctor`  |
| 1          | 0     | 100      | `ctor`   |
| 16         | 0     | 0        | `Encode` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Cryptography\Lorenz\LorenzMachine.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections;
〰3:   using System.Collections.Generic;
〰4:   using System.ComponentModel;
〰5:   using System.Linq;
〰6:   using System.Runtime.InteropServices.ComTypes;
〰7:   using System.Text;
〰8:   
〰9:   namespace BinaryDataDecoders.Cryptography.Lorenz
〰10:  {
〰11:      // https://www.codesandciphers.org.uk/cevent2.htm
〰12:      // https://lorenz.virtualcolossus.co.uk/LorenzSZ/#
〰13:      public class LorenzMachine
〰14:      {
〰15:  
‼16:          public static readonly (byte[] key, int[] start) ZMUG = (new byte[]
‼17:          {
‼18:              0b00011100,0b11100111,0b10001100,0b01100111,
‼19:              0b00011001,0b01111010,0b01110011,0b10011000,
‼20:              0b11110001,0b11001100,0b11100010,0b00111001,
‼21:              0b10001100,0b01110001,0b00011110,0b00100111,
‼22:              0b00111001,0b10010101,0b11001100,0b01100100,
‼23:              0b11100110,0b00100011,0b11001110,0b01100111,
‼24:              0b00001100,0b01001110,0b01100111,0b00110001,
‼25:              0b11100100,0b11100111,0b10001000,0b11100111,
‼26:              0b10111011,0b10101101,0b11011101,0b10101101,
‼27:              0b01010101,0b01111010,0b10111011,0b10111011,
‼28:              0b01101101,0b10111010,0b10111011,0b10101101,
‼29:              0b01100111,0b00001110,0b01110000,0b10011011,
‼30:              0b00011011,0b00001100,0b11000101,0b11101110,
‼31:              0b00011011,0b01111011,0b00011100,0b01100011,
‼32:              0b00100101,0b00111010,0b01100011,0b00101011,
‼33:              0b01000011,0b10100011,0b11001000,0b00000000,
‼34:          }, new[] {
‼35:              29, 1, 38, 53, 3,
‼36:              1, 51,
‼37:              33, 22, 28, 15, 19,
‼38:          });
〰39:  
‼40:          public LorenzMachine(byte[] keySet, int[] startPosition)
〰41:          {
‼42:              _keySet = keySet;
‼43:              _positions = startPosition;
‼44:          }
〰45:  
〰46:          // https://en.wikipedia.org/wiki/Baudot_code#ITA2
‼47:          private readonly string _ita2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ012345";
〰48:  
〰49:          public string Encode(string input)
〰50:          {
‼51:              var chars = input.ToUpper()
‼52:                               .Replace('+', '5')
‼53:                               .Select(i => _ita2.IndexOf(i))
‼54:                               .Where(i => i >= 0)
‼55:                               .ToArray();
〰56:  
‼57:              var key = new BitArray(_keySet);
〰58:  
‼59:              var output = new char[chars.Length];
〰60:  
‼61:              var keyOffsets = new[]
‼62:              {
‼63:                   _chiModulus.Take(0).Sum(),
‼64:                   _chiModulus.Take(1).Sum(),
‼65:                   _chiModulus.Take(2).Sum(),
‼66:                   _chiModulus.Take(3).Sum(),
‼67:                   _chiModulus.Take(4).Sum(),
‼68:  
‼69:                   _chiModulus.Concat(_muModulus.Take(0)).Sum(),
‼70:                   _chiModulus.Concat(_muModulus.Take(1)).Sum(),
‼71:  
‼72:                   _chiModulus.Concat(_muModulus).Concat(_psiModulus.Take(0)).Sum(),
‼73:                   _chiModulus.Concat(_muModulus).Concat(_psiModulus.Take(1)).Sum(),
‼74:                   _chiModulus.Concat(_muModulus).Concat(_psiModulus.Take(2)).Sum(),
‼75:                   _chiModulus.Concat(_muModulus).Concat(_psiModulus.Take(3)).Sum(),
‼76:                   _chiModulus.Concat(_muModulus).Concat(_psiModulus.Take(4)).Sum(),
‼77:              };
〰78:  
‼79:              for (int chi = 0, mu = 0, psi = 0; chi < chars.Length; chi++)
〰80:              {
‼81:                  var bit1 = (chars[chi] & 0b10000) >> 4 == 1;
‼82:                  var bit2 = (chars[chi] & 0b01000) >> 3 == 1;
‼83:                  var bit3 = (chars[chi] & 0b00100) >> 2 == 1;
‼84:                  var bit4 = (chars[chi] & 0b00010) >> 1 == 1;
‼85:                  var bit5 = (chars[chi] & 0b00001) >> 0 == 1;
〰86:  
‼87:                  var chi1 = (chi + _positions[0]) % _chiModulus[0];
‼88:                  var chi2 = (chi + _positions[1]) % _chiModulus[1];
‼89:                  var chi3 = (chi + _positions[2]) % _chiModulus[2];
‼90:                  var chi4 = (chi + _positions[3]) % _chiModulus[3];
‼91:                  var chi5 = (chi + _positions[4]) % _chiModulus[4];
〰92:  
‼93:                  var mu1 = (chi + _positions[5]) % _muModulus[0];
〰94:  
‼95:                  if (key[mu1]) mu++;
‼96:                  var mu2 = (mu + _positions[6]) % _muModulus[1];
〰97:  
‼98:                  if (key[mu2]) psi++;
〰99:  
‼100:                 var psi1 = (psi + _positions[7]) % _psiModulus[0];
‼101:                 var psi2 = (psi + _positions[8]) % _psiModulus[1];
‼102:                 var psi3 = (psi + _positions[9]) % _psiModulus[2];
‼103:                 var psi4 = (psi + _positions[10]) % _psiModulus[3];
‼104:                 var psi5 = (psi + _positions[11]) % _psiModulus[4];
〰105: 
‼106:                 var z1 = (bit1 ^ key[chi1 + keyOffsets[0]] ^ key[psi1 + keyOffsets[7]]) ? 1 : 0;
‼107:                 var z2 = (bit2 ^ key[chi2 + keyOffsets[1]] ^ key[psi2 + keyOffsets[8]]) ? 1 : 0;
‼108:                 var z3 = (bit3 ^ key[chi3 + keyOffsets[2]] ^ key[psi3 + keyOffsets[9]]) ? 1 : 0;
‼109:                 var z4 = (bit4 ^ key[chi4 + keyOffsets[3]] ^ key[psi4 + keyOffsets[10]]) ? 1 : 0;
‼110:                 var z5 = (bit5 ^ key[chi5 + keyOffsets[4]] ^ key[psi5 + keyOffsets[11]]) ? 1 : 0;
〰111: 
‼112:                 var z = z1 << 4 | z2 << 3 | z3 << 2 | z4 << 1 | z5;
〰113: 
‼114:                 output[chi] = _ita2[z % _ita2.Length];
〰115:             }
〰116: 
‼117:             return new string(output);
〰118:         }
〰119: 
〰120:         private readonly byte[] _keySet;
〰121:         /*
〰122:         chi = 41 31 29 26 31
〰123:         psi = 43 47 51 53 29
〰124:         u = 61 37
〰125:         */
〰126: 
〰127:         //always advance
‼128:         private readonly int[] _chiModulus = new int[]
‼129:         {
‼130:             41,31,29,26,23
‼131:         };
〰132:         //0 always advance, 1 only advance if 0 is 1
‼133:         private readonly int[] _muModulus = new int[]
‼134:         {
‼135:             61,37
‼136:         };
〰137:         //only advance if mu 1 is 1
‼138:         private readonly int[] _psiModulus = new int[]
‼139:         {
‼140:             43,47,51,53,59
‼141:         };
〰142: 
〰143:         private readonly int[] _positions;
〰144:         /*
〰145: VIRTUAL LORENZ SETTINGS
〰146: 
〰147: EXPORT FORMAT: TUNNY
〰148: MODEL: SZ42A
〰149: P5 LIMITATION: OFF
〰150: 
〰151: WHEEL SETTINGS
〰152: PSI 1:  ...xxx..xxx..xxxx...xx...xx..xxx...xx..x.xx
〰153: PSI 2:  xx.x..xxx..xxx..xx...xxxx...xxx..xx..xxx...x...
〰154: PSI 3:  xxx..xx...xx...xxx...x...xxxx...x..xxx..xxx..xx..x.
〰155: PSI 4:  x.xxx..xx...xx..x..xxx..xx...x...xxxx..xxx..xx..xxx..
〰156: PSI 5:  ..xx...x..xxx..xx..xxx..xx...xxxx..x..xxx..xxxx...x...xxx..x
〰157: MU  6:  xxx.xxx.xxx.x.xx.xxx.xxx.xx.x.xx.x.x.
〰158: MU  7:  x.x.x.xxxx.x.x.xxx.xxx.xxx.xx.xx.xx.xx.xxx.x.x.xxx.xxx.x.xx.x
〰159: CHI 8:  .xx..xxx....xxx..xxx....x..xx.xx...xx.xx.
〰160: CHI 9:  ...xx..xx...x.xxxx.xxx....xx.xx
〰161: CHI 10: .xxxx.xx...xxx...xx...xx..x..
〰162: CHI 11: x.x..xxx.x..xx...xx..x.x.x
〰163: CHI 12: x.x....xxx.x...xxxx..x.
〰164: 
〰165: WHEEL STARTS
〰166: ST 1:  29
〰167: ST 2:  1
〰168: ST 3:  38
〰169: ST 4:  53
〰170: ST 5:  3
〰171: ST 6:  1
〰172: ST 7:  51
〰173: ST 8:  33
〰174: ST 9:  22
〰175: ST 10: 28
〰176: ST 11: 15
〰177: ST 12: 19
〰178: 
〰179: 
〰180: WWW.VIRTUALCOLOSSUS.CO.UK
〰181:         */
〰182:     }
〰183: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

