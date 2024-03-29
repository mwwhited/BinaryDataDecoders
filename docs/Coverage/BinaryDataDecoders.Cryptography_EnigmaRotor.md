﻿# BinaryDataDecoders.Cryptography.Enigma.EnigmaRotor

## Summary

| Key             | Value                                                |
| :-------------- | :--------------------------------------------------- |
| Class           | `BinaryDataDecoders.Cryptography.Enigma.EnigmaRotor` |
| Assembly        | `BinaryDataDecoders.Cryptography`                    |
| Coveredlines    | `27`                                                 |
| Uncoveredlines  | `29`                                                 |
| Coverablelines  | `56`                                                 |
| Totallines      | `81`                                                 |
| Linecoverage    | `48.2`                                               |
| Coveredbranches | `0`                                                  |
| Totalbranches   | `0`                                                  |
| Coveredmethods  | `1`                                                  |
| Totalmethods    | `4`                                                  |
| Methodcoverage  | `25`                                                 |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 1          | 0     | 100      | `cctor` |
| 1          | 0     | 100      | `ctor`  |
| 1          | 100   | 100      | `cctor` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Cryptography/Enigma/EnigmaRotor.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   
〰3:   namespace BinaryDataDecoders.Cryptography.Enigma;
〰4:   
‼5:   public record EnigmaRotor
〰6:   {
‼7:       public static IEnumerable<EnigmaRotor> Rotors { get; } = new[]
‼8:       {
‼9:           new EnigmaRotor {Number="IC", Series="Commercial Enigma A, B",Wiring="DMTWSILRUYQNKFEJCAZBPGXOHV",Introduced="1924",RotateOn=['Q']},
‼10:          new EnigmaRotor {Number="IIC", Series="Commercial Enigma A, B",Wiring="HQZGPJTMOBLNCIFDYAWVEUSRKX",Introduced="1924",RotateOn=['E']},
‼11:          new EnigmaRotor {Number="IIIC", Series="Commercial Enigma A, B",Wiring="UQNTLSZFMREHDPXKIBVYGJCWOA",Introduced="1924",RotateOn=['V']},
‼12:          new EnigmaRotor {Number="I", Series="German Railway (Rocket)",Wiring="JGDQOXUSCAMIFRVTPNEWKBLZYH",Introduced="15014",RotateOn=['Q']},
‼13:          new EnigmaRotor {Number="II", Series="German Railway (Rocket)",Wiring="NTZPSFBOKMWRCJDIVLAEYUXHGQ",Introduced="15014",RotateOn=['E']},
‼14:          new EnigmaRotor {Number="III", Series="German Railway (Rocket)",Wiring="JVIUBHTCDYAKEQZPOSGXNRMWFL",Introduced="15014",RotateOn=['V']},
‼15:          // new EnigmaRotor {Number="UKW", Series="German Railway (Rocket)",Wiring="QYHOGNECVPUZTFDJAXWMKISRBL",Introduced="15014",RotateOn=new char[]{}},
‼16:          // new EnigmaRotor {Number="ETW", Series="German Railway (Rocket)",Wiring="QWERTZUIOASDFGHJKPYXCVBNML",Introduced="15014",RotateOn=new char[]{}},
‼17:          new EnigmaRotor {Number="I-K", Series="Swiss K",Wiring="PEZUOHXSCVFMTBGLRINQJWAYDK",Introduced="14277",RotateOn=['Q']},
‼18:          new EnigmaRotor {Number="II-K", Series="Swiss K",Wiring="ZOUESYDKFWPCIQXHMVBLGNJRAT",Introduced="14277",RotateOn=['E']},
‼19:          new EnigmaRotor {Number="III-K", Series="Swiss K",Wiring="EHRVXGAOBQUSIMZFLYNWKTPDJC",Introduced="14277",RotateOn=['V']},
‼20:          // new EnigmaRotor {Number="UKW-K", Series="Swiss K",Wiring="IMETCGFRAYSQBZXWLHKDVUPOJN",Introduced="14277",RotateOn=new char[]{}},
‼21:          // new EnigmaRotor {Number="ETW-K", Series="Swiss K",Wiring="QWERTZUIOASDFGHJKPYXCVBNML",Introduced="14277",RotateOn=new char[]{}},
‼22:          new EnigmaRotor {Number="I", Series="Enigma I",Wiring="EKMFLGDQVZNTOWYHXUSPAIBRCJ",Introduced="1930",RotateOn=['Q']},
‼23:          new EnigmaRotor {Number="II", Series="Enigma I",Wiring="AJDKSIRUXBLHWTMCQGZNPYFVOE",Introduced="1930",RotateOn=['E']},
‼24:          new EnigmaRotor {Number="III", Series="Enigma I",Wiring="BDFHJLCPRTXVZNYEIWGAKMUSQO",Introduced="1930",RotateOn=['V']},
‼25:          new EnigmaRotor {Number="IV", Series="M3 Army",Wiring="ESOVPZJAYQUIRHXLNFTGKDCMWB",Introduced="14215",RotateOn=['J']},
‼26:          new EnigmaRotor {Number="V", Series="M3 Army",Wiring="VZBRGITYUPSDNHLXAWMJQOFECK",Introduced="14215",RotateOn=['Z']},
‼27:          new EnigmaRotor {Number="VI", Series="M3 & M4 Naval (FEB 1942)",Wiring="JPGVOUMFYQBENHZRDKASXLICTW",Introduced="1939",RotateOn=['Z','M']},
‼28:          new EnigmaRotor {Number="VII", Series="M3 & M4 Naval (FEB 1942)",Wiring="NZJHGRCXMYSWBOUFAIVLPEKQDT",Introduced="1939",RotateOn=['Z','M']},
‼29:          new EnigmaRotor {Number="VIII", Series="M3 & M4 Naval (FEB 1942)",Wiring="FKQHTLXOCBJSPDZRAMEWNIUYGV",Introduced="1939",RotateOn=['Z','M']},
‼30:          // new EnigmaRotor {Number="Beta", Series="M4 R2",Wiring="LEYJVCNIXWPBQMDRTAKZGFUHOS",Introduced="Spring 1941",RotateOn=new char[]{}},
‼31:          // new EnigmaRotor {Number="Gamma", Series="M4 R2",Wiring="FSOKANUERHMBTIYCWLQPZXVGJD",Introduced="Spring 1942",RotateOn=new char[]{}},
‼32:          // new EnigmaRotor {Number="ETW", Series="Enigma I",Wiring="ABCDEFGHIJKLMNOPQRSTUVWXYZ",Introduced="",RotateOn=new char[]{}},
‼33:      };
〰34:  
〰35:      public string Introduced { get; init; }
〰36:      public string Number { get; init; }
〰37:      public char[] RotateOn { get; init; }
〰38:      public string Series { get; init; }
〰39:      public string Wiring { get; init; }
〰40:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.Cryptography/Enigma/EnigmaRotor.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   
〰3:   namespace BinaryDataDecoders.Cryptography.Enigma;
〰4:   
‼5:   public record EnigmaRotor
〰6:   {
✔7:       public static IEnumerable<EnigmaRotor> Rotors { get; } = new[]
✔8:       {
✔9:           new EnigmaRotor {Number="IC", Series="Commercial Enigma A, B",Wiring="DMTWSILRUYQNKFEJCAZBPGXOHV",Introduced="1924",RotateOn=['Q']},
✔10:          new EnigmaRotor {Number="IIC", Series="Commercial Enigma A, B",Wiring="HQZGPJTMOBLNCIFDYAWVEUSRKX",Introduced="1924",RotateOn=['E']},
✔11:          new EnigmaRotor {Number="IIIC", Series="Commercial Enigma A, B",Wiring="UQNTLSZFMREHDPXKIBVYGJCWOA",Introduced="1924",RotateOn=['V']},
✔12:          new EnigmaRotor {Number="I", Series="German Railway (Rocket)",Wiring="JGDQOXUSCAMIFRVTPNEWKBLZYH",Introduced="15014",RotateOn=['Q']},
✔13:          new EnigmaRotor {Number="II", Series="German Railway (Rocket)",Wiring="NTZPSFBOKMWRCJDIVLAEYUXHGQ",Introduced="15014",RotateOn=['E']},
✔14:          new EnigmaRotor {Number="III", Series="German Railway (Rocket)",Wiring="JVIUBHTCDYAKEQZPOSGXNRMWFL",Introduced="15014",RotateOn=['V']},
✔15:          // new EnigmaRotor {Number="UKW", Series="German Railway (Rocket)",Wiring="QYHOGNECVPUZTFDJAXWMKISRBL",Introduced="15014",RotateOn=new char[]{}},
✔16:          // new EnigmaRotor {Number="ETW", Series="German Railway (Rocket)",Wiring="QWERTZUIOASDFGHJKPYXCVBNML",Introduced="15014",RotateOn=new char[]{}},
✔17:          new EnigmaRotor {Number="I-K", Series="Swiss K",Wiring="PEZUOHXSCVFMTBGLRINQJWAYDK",Introduced="14277",RotateOn=['Q']},
✔18:          new EnigmaRotor {Number="II-K", Series="Swiss K",Wiring="ZOUESYDKFWPCIQXHMVBLGNJRAT",Introduced="14277",RotateOn=['E']},
✔19:          new EnigmaRotor {Number="III-K", Series="Swiss K",Wiring="EHRVXGAOBQUSIMZFLYNWKTPDJC",Introduced="14277",RotateOn=['V']},
✔20:          // new EnigmaRotor {Number="UKW-K", Series="Swiss K",Wiring="IMETCGFRAYSQBZXWLHKDVUPOJN",Introduced="14277",RotateOn=new char[]{}},
✔21:          // new EnigmaRotor {Number="ETW-K", Series="Swiss K",Wiring="QWERTZUIOASDFGHJKPYXCVBNML",Introduced="14277",RotateOn=new char[]{}},
✔22:          new EnigmaRotor {Number="I", Series="Enigma I",Wiring="EKMFLGDQVZNTOWYHXUSPAIBRCJ",Introduced="1930",RotateOn=['Q']},
✔23:          new EnigmaRotor {Number="II", Series="Enigma I",Wiring="AJDKSIRUXBLHWTMCQGZNPYFVOE",Introduced="1930",RotateOn=['E']},
✔24:          new EnigmaRotor {Number="III", Series="Enigma I",Wiring="BDFHJLCPRTXVZNYEIWGAKMUSQO",Introduced="1930",RotateOn=['V']},
✔25:          new EnigmaRotor {Number="IV", Series="M3 Army",Wiring="ESOVPZJAYQUIRHXLNFTGKDCMWB",Introduced="14215",RotateOn=['J']},
✔26:          new EnigmaRotor {Number="V", Series="M3 Army",Wiring="VZBRGITYUPSDNHLXAWMJQOFECK",Introduced="14215",RotateOn=['Z']},
✔27:          new EnigmaRotor {Number="VI", Series="M3 & M4 Naval (FEB 1942)",Wiring="JPGVOUMFYQBENHZRDKASXLICTW",Introduced="1939",RotateOn=['Z','M']},
✔28:          new EnigmaRotor {Number="VII", Series="M3 & M4 Naval (FEB 1942)",Wiring="NZJHGRCXMYSWBOUFAIVLPEKQDT",Introduced="1939",RotateOn=['Z','M']},
✔29:          new EnigmaRotor {Number="VIII", Series="M3 & M4 Naval (FEB 1942)",Wiring="FKQHTLXOCBJSPDZRAMEWNIUYGV",Introduced="1939",RotateOn=['Z','M']},
✔30:          // new EnigmaRotor {Number="Beta", Series="M4 R2",Wiring="LEYJVCNIXWPBQMDRTAKZGFUHOS",Introduced="Spring 1941",RotateOn=new char[]{}},
✔31:          // new EnigmaRotor {Number="Gamma", Series="M4 R2",Wiring="FSOKANUERHMBTIYCWLQPZXVGJD",Introduced="Spring 1942",RotateOn=new char[]{}},
✔32:          // new EnigmaRotor {Number="ETW", Series="Enigma I",Wiring="ABCDEFGHIJKLMNOPQRSTUVWXYZ",Introduced="",RotateOn=new char[]{}},
✔33:      };
〰34:  
〰35:      public string Introduced { get; init; }
〰36:      public string Number { get; init; }
〰37:      public char[] RotateOn { get; init; }
〰38:      public string Series { get; init; }
〰39:      public string Wiring { get; init; }
〰40:  }
〰41:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

