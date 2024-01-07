# BinaryDataDecoders.Cryptography.Enigma.EnigmaReflector

## Summary

| Key             | Value                                                    |
| :-------------- | :------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Cryptography.Enigma.EnigmaReflector` |
| Assembly        | `BinaryDataDecoders.Cryptography`                        |
| Coveredlines    | `8`                                                      |
| Uncoveredlines  | `8`                                                      |
| Coverablelines  | `16`                                                     |
| Totallines      | `39`                                                     |
| Linecoverage    | `50`                                                     |
| Coveredbranches | `0`                                                      |
| Totalbranches   | `0`                                                      |
| Coveredmethods  | `1`                                                      |
| Totalmethods    | `2`                                                      |
| Methodcoverage  | `50`                                                     |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `cctor` |
| 1          | 100   | 100      | `cctor` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Cryptography/Enigma/EnigmaReflector.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   
〰3:   namespace BinaryDataDecoders.Cryptography.Enigma;
〰4:   
〰5:   public class EnigmaReflector
〰6:   {
‼7:       public static IEnumerable<EnigmaReflector> Reflectors { get; } = new[]
‼8:       {
‼9:           new EnigmaReflector {Number="Reflector A", Series="",Wiring="EJMZALYXVBWFCRQUONTSPIKHGD",Introduced=""},
‼10:          new EnigmaReflector {Number="Reflector B", Series="",Wiring="YRUHQSLDPXNGOKMIEBFZCWVJAT",Introduced=""},
‼11:          new EnigmaReflector {Number="Reflector C", Series="",Wiring="FVPJIAOYEDRZXWGCTKUQSBNMHL",Introduced=""},
‼12:          new EnigmaReflector {Number="Reflector B Thin", Series="M4 R1 (M3 + Thin)",Wiring="ENKQAUYWJICOPBLMDXZVFTHRGS",Introduced="1940"},
‼13:          new EnigmaReflector {Number="Reflector C Thin", Series="M4 R1 (M3 + Thin)",Wiring="RDOBJNTKVEHMLFCWZAXGYIPSUQ",Introduced="1940"},
‼14:      };
〰15:      public string Introduced { get; private set; }
〰16:      public string Number { get; private set; }
〰17:      public string Series { get; private set; }
〰18:      public string Wiring { get; private set; }
〰19:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.Cryptography/Enigma/EnigmaReflector.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   
〰3:   namespace BinaryDataDecoders.Cryptography.Enigma;
〰4:   
〰5:   public class EnigmaReflector
〰6:   {
✔7:       public static IEnumerable<EnigmaReflector> Reflectors { get; } = new[]
✔8:       {
✔9:           new EnigmaReflector {Number="Reflector A", Series="",Wiring="EJMZALYXVBWFCRQUONTSPIKHGD",Introduced=""},
✔10:          new EnigmaReflector {Number="Reflector B", Series="",Wiring="YRUHQSLDPXNGOKMIEBFZCWVJAT",Introduced=""},
✔11:          new EnigmaReflector {Number="Reflector C", Series="",Wiring="FVPJIAOYEDRZXWGCTKUQSBNMHL",Introduced=""},
✔12:          new EnigmaReflector {Number="Reflector B Thin", Series="M4 R1 (M3 + Thin)",Wiring="ENKQAUYWJICOPBLMDXZVFTHRGS",Introduced="1940"},
✔13:          new EnigmaReflector {Number="Reflector C Thin", Series="M4 R1 (M3 + Thin)",Wiring="RDOBJNTKVEHMLFCWZAXGYIPSUQ",Introduced="1940"},
✔14:      };
〰15:      public string Introduced { get; private set; }
〰16:      public string Number { get; private set; }
〰17:      public string Series { get; private set; }
〰18:      public string Wiring { get; private set; }
〰19:  }
〰20:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

