# BinaryDataDecoders.Cryptography.Enigma.EnigmaRotor

## Summary

| Key             | Value                                                |
| :-------------- | :--------------------------------------------------- |
| Class           | `BinaryDataDecoders.Cryptography.Enigma.EnigmaRotor` |
| Assembly        | `BinaryDataDecoders.Cryptography`                    |
| Coveredlines    | `31`                                                 |
| Uncoveredlines  | `1`                                                  |
| Coverablelines  | `32`                                                 |
| Totallines      | `41`                                                 |
| Linecoverage    | `96.8`                                               |
| Coveredbranches | `0`                                                  |
| Totalbranches   | `0`                                                  |

## Metrics

| Complexity | Lines | Branches | Name             |
| :--------- | :---- | :------- | :--------------- |
| 1          | 100   | 100      | `get_Rotors`     |
| 1          | 100   | 100      | `cctor`          |
| 1          | 0     | 100      | `get_Introduced` |
| 1          | 100   | 100      | `get_Number`     |
| 1          | 100   | 100      | `get_RotateOn`   |
| 1          | 100   | 100      | `get_Series`     |
| 1          | 100   | 100      | `get_Wiring`     |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Cryptography/Enigma/EnigmaRotor.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   
〰3:   namespace BinaryDataDecoders.Cryptography.Enigma
〰4:   {
〰5:       public class EnigmaRotor
〰6:       {
✔7:           public static IEnumerable<EnigmaRotor> Rotors { get; } = new[]
✔8:           {
✔9:               new EnigmaRotor {Number="IC", Series="Commercial Enigma A, B",Wiring="DMTWSILRUYQNKFEJCAZBPGXOHV",Introduced="1924",RotateOn=new char[]{'Q'}},
✔10:              new EnigmaRotor {Number="IIC", Series="Commercial Enigma A, B",Wiring="HQZGPJTMOBLNCIFDYAWVEUSRKX",Introduced="1924",RotateOn=new char[]{'E'}},
✔11:              new EnigmaRotor {Number="IIIC", Series="Commercial Enigma A, B",Wiring="UQNTLSZFMREHDPXKIBVYGJCWOA",Introduced="1924",RotateOn=new char[]{'V'}},
✔12:              new EnigmaRotor {Number="I", Series="German Railway (Rocket)",Wiring="JGDQOXUSCAMIFRVTPNEWKBLZYH",Introduced="15014",RotateOn=new char[]{'Q'}},
✔13:              new EnigmaRotor {Number="II", Series="German Railway (Rocket)",Wiring="NTZPSFBOKMWRCJDIVLAEYUXHGQ",Introduced="15014",RotateOn=new char[]{'E'}},
✔14:              new EnigmaRotor {Number="III", Series="German Railway (Rocket)",Wiring="JVIUBHTCDYAKEQZPOSGXNRMWFL",Introduced="15014",RotateOn=new char[]{'V'}},
✔15:              // new EnigmaRotor {Number="UKW", Series="German Railway (Rocket)",Wiring="QYHOGNECVPUZTFDJAXWMKISRBL",Introduced="15014",RotateOn=new char[]{}},
✔16:              // new EnigmaRotor {Number="ETW", Series="German Railway (Rocket)",Wiring="QWERTZUIOASDFGHJKPYXCVBNML",Introduced="15014",RotateOn=new char[]{}},
✔17:              new EnigmaRotor {Number="I-K", Series="Swiss K",Wiring="PEZUOHXSCVFMTBGLRINQJWAYDK",Introduced="14277",RotateOn=new char[]{'Q'}},
✔18:              new EnigmaRotor {Number="II-K", Series="Swiss K",Wiring="ZOUESYDKFWPCIQXHMVBLGNJRAT",Introduced="14277",RotateOn=new char[]{'E'}},
✔19:              new EnigmaRotor {Number="III-K", Series="Swiss K",Wiring="EHRVXGAOBQUSIMZFLYNWKTPDJC",Introduced="14277",RotateOn=new char[]{'V'}},
✔20:              // new EnigmaRotor {Number="UKW-K", Series="Swiss K",Wiring="IMETCGFRAYSQBZXWLHKDVUPOJN",Introduced="14277",RotateOn=new char[]{}},
✔21:              // new EnigmaRotor {Number="ETW-K", Series="Swiss K",Wiring="QWERTZUIOASDFGHJKPYXCVBNML",Introduced="14277",RotateOn=new char[]{}},
✔22:              new EnigmaRotor {Number="I", Series="Enigma I",Wiring="EKMFLGDQVZNTOWYHXUSPAIBRCJ",Introduced="1930",RotateOn=new char[]{'Q'}},
✔23:              new EnigmaRotor {Number="II", Series="Enigma I",Wiring="AJDKSIRUXBLHWTMCQGZNPYFVOE",Introduced="1930",RotateOn=new char[]{'E'}},
✔24:              new EnigmaRotor {Number="III", Series="Enigma I",Wiring="BDFHJLCPRTXVZNYEIWGAKMUSQO",Introduced="1930",RotateOn=new char[]{'V'}},
✔25:              new EnigmaRotor {Number="IV", Series="M3 Army",Wiring="ESOVPZJAYQUIRHXLNFTGKDCMWB",Introduced="14215",RotateOn=new char[]{'J'}},
✔26:              new EnigmaRotor {Number="V", Series="M3 Army",Wiring="VZBRGITYUPSDNHLXAWMJQOFECK",Introduced="14215",RotateOn=new char[]{'Z'}},
✔27:              new EnigmaRotor {Number="VI", Series="M3 & M4 Naval (FEB 1942)",Wiring="JPGVOUMFYQBENHZRDKASXLICTW",Introduced="1939",RotateOn=new char[]{'Z','M'}},
✔28:              new EnigmaRotor {Number="VII", Series="M3 & M4 Naval (FEB 1942)",Wiring="NZJHGRCXMYSWBOUFAIVLPEKQDT",Introduced="1939",RotateOn=new char[]{'Z','M'}},
✔29:              new EnigmaRotor {Number="VIII", Series="M3 & M4 Naval (FEB 1942)",Wiring="FKQHTLXOCBJSPDZRAMEWNIUYGV",Introduced="1939",RotateOn=new char[]{'Z','M'}},
✔30:              // new EnigmaRotor {Number="Beta", Series="M4 R2",Wiring="LEYJVCNIXWPBQMDRTAKZGFUHOS",Introduced="Spring 1941",RotateOn=new char[]{}},
✔31:              // new EnigmaRotor {Number="Gamma", Series="M4 R2",Wiring="FSOKANUERHMBTIYCWLQPZXVGJD",Introduced="Spring 1942",RotateOn=new char[]{}},
✔32:              // new EnigmaRotor {Number="ETW", Series="Enigma I",Wiring="ABCDEFGHIJKLMNOPQRSTUVWXYZ",Introduced="",RotateOn=new char[]{}},
✔33:          };
〰34:  
‼35:          public string Introduced { get; private set; }
✔36:          public string Number { get; private set; }
✔37:          public char[] RotateOn { get; private set; }
✔38:          public string Series { get; private set; }
✔39:          public string Wiring { get; private set; }
〰40:      }
〰41:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

