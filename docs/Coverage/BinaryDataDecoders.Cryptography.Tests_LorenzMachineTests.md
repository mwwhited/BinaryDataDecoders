# BinaryDataDecoders.Cryptography.Tests.Lorenz.LorenzMachineTests

## Summary

| Key             | Value                                                             |
| :-------------- | :---------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Cryptography.Tests.Lorenz.LorenzMachineTests` |
| Assembly        | `BinaryDataDecoders.Cryptography.Tests`                           |
| Coveredlines    | `7`                                                               |
| Uncoveredlines  | `0`                                                               |
| Coverablelines  | `7`                                                               |
| Totallines      | `31`                                                              |
| Linecoverage    | `100`                                                             |
| Coveredbranches | `0`                                                               |
| Totalbranches   | `0`                                                               |
| Coveredmethods  | `1`                                                               |
| Totalmethods    | `1`                                                               |
| Methodcoverage  | `100`                                                             |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 100   | 100      | `Test`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Cryptography.Tests/Lorenz/LorenzMachineTests.cs

```CSharp
〰1:   using BinaryDataDecoders.Cryptography.Lorenz;
〰2:   using BinaryDataDecoders.TestUtilities;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   using System;
〰5:   using System.Collections.Generic;
〰6:   using System.Text;
〰7:   
〰8:   namespace BinaryDataDecoders.Cryptography.Tests.Lorenz
〰9:   {
〰10:      [TestClass]
〰11:      public class LorenzMachineTests
〰12:      {
〰13:          public TestContext TestContext { get; set; }
〰14:  
〰15:          [TestMethod, TestCategory(TestCategories.Unit)]
〰16:          public void Test()
〰17:          {
✔18:              var lm = new LorenzMachine(LorenzMachine.ZMUG.key, LorenzMachine.ZMUG.start);
〰19:  
✔20:              var mesg = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ012345";
〰21:  
✔22:              var result = lm.Encode(mesg);
〰23:  
✔24:              Assert.AreEqual("EATAS1DSSQ421X4B5ZHPRXE5XNV4CESS", result);
〰25:  
✔26:              var check = lm.Encode(result);
〰27:  
✔28:              Assert.AreEqual(mesg, check);
✔29:          }
〰30:      }
〰31:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

