# BinaryDataDecoders.Cryptography.Tests.Enigma.EnigmaMachineTests

## Summary

| Key             | Value                                                             |
| :-------------- | :---------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Cryptography.Tests.Enigma.EnigmaMachineTests` |
| Assembly        | `BinaryDataDecoders.Cryptography.Tests`                           |
| Coveredlines    | `14`                                                              |
| Uncoveredlines  | `0`                                                               |
| Coverablelines  | `14`                                                              |
| Totallines      | `33`                                                              |
| Linecoverage    | `100`                                                             |
| Coveredbranches | `2`                                                               |
| Totalbranches   | `2`                                                               |
| Branchcoverage  | `100`                                                             |
| Coveredmethods  | `1`                                                               |
| Totalmethods    | `1`                                                               |
| Methodcoverage  | `100`                                                             |

## Metrics

| Complexity | Lines | Branches | Name                                           |
| :--------- | :---- | :------- | :--------------------------------------------- |
| 2          | 100   | 100      | `ProcessTest_EnigmaI_I_II_III_RefB_ABDEYZ_AAA` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.Cryptography.Tests/Enigma/EnigmaMachineTests.cs

```CSharp
〰1:   using BinaryDataDecoders.Cryptography.Enigma;
〰2:   using BinaryDataDecoders.TestUtilities;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   using System;
〰5:   using System.Linq;
〰6:   
〰7:   namespace BinaryDataDecoders.Cryptography.Tests.Enigma;
〰8:   
〰9:   [TestClass]
〰10:  public class EnigmaMachineTests
〰11:  {
〰12:      [TestMethod, TestCategory(TestCategories.Unit)]
〰13:      [TestTarget(typeof(EnigmaMachine), Member = nameof(EnigmaMachine.Process))]
〰14:      public void ProcessTest_EnigmaI_I_II_III_RefB_ABDEYZ_AAA()
〰15:      {
✔16:          var rotors = EnigmaRotor.Rotors
✔17:                                  .Where(r => r.Series == "Enigma I" &&
✔18:                                              new[] { "I", "II", "III" }.Contains(r.Number))
✔19:                                  .ToArray();
✔20:          var reflector = EnigmaReflector.Reflectors
✔21:                                         .First(r => r.Number == "Reflector B");
〰22:  
✔23:          var em = new EnigmaMachine(rotors, reflector)
✔24:          {
✔25:              PlugBoard = "AB DE YZ"
✔26:          };
✔27:          var start = em.Positions = "AAA";
〰28:  
✔29:          var ret = em.Process("AAAAA");
✔30:          Assert.AreEqual("BJLCS", ret);
✔31:      }
〰32:  }
〰33:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

