# BinaryDataDecoders.TestUtilities.ContextualTestClassBase

## Summary

| Key             | Value                                                      |
| :-------------- | :--------------------------------------------------------- |
| Class           | `BinaryDataDecoders.TestUtilities.ContextualTestClassBase` |
| Assembly        | `BinaryDataDecoders.TestUtilities`                         |
| Coveredlines    | `0`                                                        |
| Uncoveredlines  | `22`                                                       |
| Coverablelines  | `22`                                                       |
| Totallines      | `73`                                                       |
| Linecoverage    | `0`                                                        |
| Coveredbranches | `0`                                                        |
| Totalbranches   | `16`                                                       |
| Branchcoverage  | `0`                                                        |
| Coveredmethods  | `0`                                                        |
| Totalmethods    | `4`                                                        |
| Methodcoverage  | `0`                                                        |

## Metrics

| Complexity | Lines | Branches | Name             |
| :--------- | :---- | :------- | :--------------- |
| 4          | 0     | 0        | `TestInitialize` |
| 4          | 0     | 0        | `TestCleanup`    |
| 4          | 0     | 0        | `TestInitialize` |
| 4          | 0     | 0        | `TestCleanup`    |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.TestUtilities/ContextualTestClassBase.cs

```CSharp
〰1:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰2:   
〰3:   namespace BinaryDataDecoders.TestUtilities;
〰4:   
〰5:   /// <summary>
〰6:   /// this is a base class to handle setting up a TestContext and bind up the ContextualTestMethod
〰7:   /// </summary>
〰8:   public abstract class ContextualTestClassBase
〰9:   {
〰10:      // https://github.com/MicrosoftDocs/visualstudio-docs/blob/main/docs/test/using-microsoft-visualstudio-testtools-unittesting-members-in-unit-tests.md
〰11:      // https://github.com/dotnet/docs/blob/main/docs/core/tutorials/testing-library-with-visual-studio.md
〰12:      public virtual TestContext TestContext { get; set; } = null!;
〰13:  
〰14:      [TestInitialize]
〰15:      public virtual void TestInitialize()
〰16:      {
‼17:          if (ContextualTestMethodAttribute.Current == null)
〰18:          {
‼19:              if (TestContext.Properties.Contains(ContextualTestMethodAttribute.CurrentTestMethod))
‼20:                  TestContext.Properties.Remove(ContextualTestMethodAttribute.CurrentTestMethod);
〰21:          }
〰22:          else
〰23:          {
‼24:              TestContext.Properties[ContextualTestMethodAttribute.CurrentTestMethod] = ContextualTestMethodAttribute.Current;
〰25:          }
‼26:          TestContext.Properties[ContextualTestMethodAttribute.CurrentTestInstance] = ContextualTestMethodAttribute.Instance = this;
‼27:      }
〰28:      [TestCleanup]
〰29:      public virtual void TestCleanup()
〰30:      {
‼31:          if (TestContext.Properties.Contains(ContextualTestMethodAttribute.CurrentTestMethod))
‼32:              TestContext.Properties.Remove(ContextualTestMethodAttribute.CurrentTestMethod);
‼33:          if (TestContext.Properties.Contains(ContextualTestMethodAttribute.CurrentTestInstance))
‼34:              TestContext.Properties.Remove(ContextualTestMethodAttribute.CurrentTestInstance);
‼35:      }
〰36:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.TestUtilities/ContextualTestClassBase.cs

```CSharp
〰1:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰2:   
〰3:   namespace BinaryDataDecoders.TestUtilities;
〰4:   
〰5:   /// <summary>
〰6:   /// this is a base class to handle setting up a TestContext and bind up the ContextualTestMethod
〰7:   /// </summary>
〰8:   public abstract class ContextualTestClassBase
〰9:   {
〰10:      // https://github.com/MicrosoftDocs/visualstudio-docs/blob/main/docs/test/using-microsoft-visualstudio-testtools-unittesting-members-in-unit-tests.md
〰11:      // https://github.com/dotnet/docs/blob/main/docs/core/tutorials/testing-library-with-visual-studio.md
〰12:      public virtual TestContext TestContext { get; set; } = null!;
〰13:  
〰14:      [TestInitialize]
〰15:      public virtual void TestInitialize()
〰16:      {
‼17:          if (ContextualTestMethodAttribute.Current == null)
〰18:          {
‼19:              if (TestContext.Properties.Contains(ContextualTestMethodAttribute.CurrentTestMethod))
‼20:                  TestContext.Properties.Remove(ContextualTestMethodAttribute.CurrentTestMethod);
〰21:          }
〰22:          else
〰23:          {
‼24:              TestContext.Properties[ContextualTestMethodAttribute.CurrentTestMethod] = ContextualTestMethodAttribute.Current;
〰25:          }
‼26:          TestContext.Properties[ContextualTestMethodAttribute.CurrentTestInstance] = ContextualTestMethodAttribute.Instance = this;
‼27:      }
〰28:      [TestCleanup]
〰29:      public virtual void TestCleanup()
〰30:      {
‼31:          if (TestContext.Properties.Contains(ContextualTestMethodAttribute.CurrentTestMethod))
‼32:              TestContext.Properties.Remove(ContextualTestMethodAttribute.CurrentTestMethod);
‼33:          if (TestContext.Properties.Contains(ContextualTestMethodAttribute.CurrentTestInstance))
‼34:              TestContext.Properties.Remove(ContextualTestMethodAttribute.CurrentTestInstance);
‼35:      }
〰36:  }
〰37:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

