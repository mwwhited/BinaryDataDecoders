﻿using System.Collections;
using System.Linq;

namespace BinaryDataDecoders.Cryptography.Lorenz;

// https://www.codesandciphers.org.uk/cevent2.htm
// https://lorenz.virtualcolossus.co.uk/LorenzSZ/#
public class LorenzMachine(byte[] keySet, int[] startPosition)
{

    public static readonly (byte[] key, int[] start) ZMUG = (new byte[]
    {
        0b00011100,0b11100111,0b10001100,0b01100111,
        0b00011001,0b01111010,0b01110011,0b10011000,
        0b11110001,0b11001100,0b11100010,0b00111001,
        0b10001100,0b01110001,0b00011110,0b00100111,
        0b00111001,0b10010101,0b11001100,0b01100100,
        0b11100110,0b00100011,0b11001110,0b01100111,
        0b00001100,0b01001110,0b01100111,0b00110001,
        0b11100100,0b11100111,0b10001000,0b11100111,
        0b10111011,0b10101101,0b11011101,0b10101101,
        0b01010101,0b01111010,0b10111011,0b10111011,
        0b01101101,0b10111010,0b10111011,0b10101101,
        0b01100111,0b00001110,0b01110000,0b10011011,
        0b00011011,0b00001100,0b11000101,0b11101110,
        0b00011011,0b01111011,0b00011100,0b01100011,
        0b00100101,0b00111010,0b01100011,0b00101011,
        0b01000011,0b10100011,0b11001000,0b00000000,
    }, new[] {
        29, 1, 38, 53, 3,
        1, 51,
        33, 22, 28, 15, 19,
    });

    // https://en.wikipedia.org/wiki/Baudot_code#ITA2
    private readonly string _ita2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ012345";

    public string Encode(string input)
    {
        var chars = input.ToUpper()
                         .Replace('+', '5')
                         .Select(i => _ita2.IndexOf(i))
                         .Where(i => i >= 0)
                         .ToArray();

        var key = new BitArray(keySet);

        var output = new char[chars.Length];

        var keyOffsets = new[]
        {
             _chiModulus.Take(0).Sum(),
             _chiModulus.Take(1).Sum(),
             _chiModulus.Take(2).Sum(),
             _chiModulus.Take(3).Sum(),
             _chiModulus.Take(4).Sum(),

             _chiModulus.Concat(_muModulus.Take(0)).Sum(),
             _chiModulus.Concat(_muModulus.Take(1)).Sum(),

             _chiModulus.Concat(_muModulus).Concat(_psiModulus.Take(0)).Sum(),
             _chiModulus.Concat(_muModulus).Concat(_psiModulus.Take(1)).Sum(),
             _chiModulus.Concat(_muModulus).Concat(_psiModulus.Take(2)).Sum(),
             _chiModulus.Concat(_muModulus).Concat(_psiModulus.Take(3)).Sum(),
             _chiModulus.Concat(_muModulus).Concat(_psiModulus.Take(4)).Sum(),
        };

        for (int chi = 0, mu = 0, psi = 0; chi < chars.Length; chi++)
        {
            var bit1 = (chars[chi] & 0b10000) >> 4 == 1;
            var bit2 = (chars[chi] & 0b01000) >> 3 == 1;
            var bit3 = (chars[chi] & 0b00100) >> 2 == 1;
            var bit4 = (chars[chi] & 0b00010) >> 1 == 1;
            var bit5 = (chars[chi] & 0b00001) >> 0 == 1;

            var chi1 = (chi + startPosition[0]) % _chiModulus[0];
            var chi2 = (chi + startPosition[1]) % _chiModulus[1];
            var chi3 = (chi + startPosition[2]) % _chiModulus[2];
            var chi4 = (chi + startPosition[3]) % _chiModulus[3];
            var chi5 = (chi + startPosition[4]) % _chiModulus[4];

            var mu1 = (chi + startPosition[5]) % _muModulus[0];

            if (key[mu1]) mu++;
            var mu2 = (mu + startPosition[6]) % _muModulus[1];

            if (key[mu2]) psi++;

            var psi1 = (psi + startPosition[7]) % _psiModulus[0];
            var psi2 = (psi + startPosition[8]) % _psiModulus[1];
            var psi3 = (psi + startPosition[9]) % _psiModulus[2];
            var psi4 = (psi + startPosition[10]) % _psiModulus[3];
            var psi5 = (psi + startPosition[11]) % _psiModulus[4];

            var z1 = (bit1 ^ key[chi1 + keyOffsets[0]] ^ key[psi1 + keyOffsets[7]]) ? 1 : 0;
            var z2 = (bit2 ^ key[chi2 + keyOffsets[1]] ^ key[psi2 + keyOffsets[8]]) ? 1 : 0;
            var z3 = (bit3 ^ key[chi3 + keyOffsets[2]] ^ key[psi3 + keyOffsets[9]]) ? 1 : 0;
            var z4 = (bit4 ^ key[chi4 + keyOffsets[3]] ^ key[psi4 + keyOffsets[10]]) ? 1 : 0;
            var z5 = (bit5 ^ key[chi5 + keyOffsets[4]] ^ key[psi5 + keyOffsets[11]]) ? 1 : 0;

            var z = z1 << 4 | z2 << 3 | z3 << 2 | z4 << 1 | z5;

            output[chi] = _ita2[z % _ita2.Length];
        }

        return new string(output);
    }

    /*
    chi = 41 31 29 26 31
    psi = 43 47 51 53 29
    u = 61 37
    */

    //always advance
    private readonly int[] _chiModulus =
    [
        41,31,29,26,23
    ];
    //0 always advance, 1 only advance if 0 is 1
    private readonly int[] _muModulus =
    [
        61,37
    ];
    //only advance if mu 1 is 1
    private readonly int[] _psiModulus =
    [
        43,47,51,53,59
    ];
    /*
VIRTUAL LORENZ SETTINGS

EXPORT FORMAT: TUNNY
MODEL: SZ42A
P5 LIMITATION: OFF

WHEEL SETTINGS
PSI 1:  ...xxx..xxx..xxxx...xx...xx..xxx...xx..x.xx
PSI 2:  xx.x..xxx..xxx..xx...xxxx...xxx..xx..xxx...x...
PSI 3:  xxx..xx...xx...xxx...x...xxxx...x..xxx..xxx..xx..x.
PSI 4:  x.xxx..xx...xx..x..xxx..xx...x...xxxx..xxx..xx..xxx..
PSI 5:  ..xx...x..xxx..xx..xxx..xx...xxxx..x..xxx..xxxx...x...xxx..x
MU  6:  xxx.xxx.xxx.x.xx.xxx.xxx.xx.x.xx.x.x.
MU  7:  x.x.x.xxxx.x.x.xxx.xxx.xxx.xx.xx.xx.xx.xxx.x.x.xxx.xxx.x.xx.x
CHI 8:  .xx..xxx....xxx..xxx....x..xx.xx...xx.xx.
CHI 9:  ...xx..xx...x.xxxx.xxx....xx.xx
CHI 10: .xxxx.xx...xxx...xx...xx..x..
CHI 11: x.x..xxx.x..xx...xx..x.x.x
CHI 12: x.x....xxx.x...xxxx..x.

WHEEL STARTS
ST 1:  29
ST 2:  1
ST 3:  38
ST 4:  53
ST 5:  3
ST 6:  1
ST 7:  51
ST 8:  33
ST 9:  22
ST 10: 28
ST 11: 15
ST 12: 19


WWW.VIRTUALCOLOSSUS.CO.UK
    */
}
