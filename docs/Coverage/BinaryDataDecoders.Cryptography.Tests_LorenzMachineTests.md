# BinaryDataDecoders.Cryptography.Tests.Lorenz.LorenzMachineTests

## Summary

| Key             | Value                                                             |
| :-------------- | :---------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Cryptography.Tests.Lorenz.LorenzMachineTests` |
| Assembly        | `BinaryDataDecoders.Cryptography.Tests`                           |
| Coveredlines    | `0`                                                               |
| Uncoveredlines  | `8`                                                               |
| Coverablelines  | `8`                                                               |
| Totallines      | `30`                                                              |
| Linecoverage    | `0`                                                               |
| Coveredbranches | `0`                                                               |
| Totalbranches   | `0`                                                               |

## Metrics

| Complexity | Lines | Branches | Name              |
| :--------- | :---- | :------- | :---------------- |
| 1          | 0     | 100      | `get_TestContext` |
| 1          | 0     | 100      | `Test`            |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Cryptography.Tests/Lorenz/LorenzMachineTests.cs

```CSharp
〰1:   using BinaryDataDecoders.Cryptography.Lorenz;
〰2:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰3:   using System;
〰4:   using System.Collections.Generic;
〰5:   using System.Text;
〰6:   
〰7:   namespace BinaryDataDecoders.Cryptography.Tests.Lorenz
〰8:   {
〰9:       [TestClass]
〰10:      public class LorenzMachineTests
〰11:      {
‼12:          public TestContext TestContext { get; set; }
〰13:  
〰14:          [TestMethod]
〰15:          public void Test()
〰16:          {
‼17:              var lm = new LorenzMachine(LorenzMachine.ZMUG.key, LorenzMachine.ZMUG.start);
〰18:  
‼19:              var mesg = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ012345";
〰20:  
‼21:              var result = lm.Encode(mesg);
〰22:  
‼23:              Assert.AreEqual("EATAS1DSSQ421X4B5ZHPRXE5XNV4CESS", result);
〰24:  
‼25:              var check = lm.Encode(result);
〰26:  
‼27:              Assert.AreEqual(mesg, check);
‼28:          }
〰29:      }
〰30:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

