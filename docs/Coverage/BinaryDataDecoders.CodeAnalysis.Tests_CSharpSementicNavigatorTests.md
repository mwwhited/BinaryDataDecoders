# BinaryDataDecoders.CodeAnalysis.Tests.CSharp.CSharpSementicNavigatorTests

## Summary

| Key             | Value                                                                       |
| :-------------- | :-------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.CodeAnalysis.Tests.CSharp.CSharpSementicNavigatorTests` |
| Assembly        | `BinaryDataDecoders.CodeAnalysis.Tests`                                     |
| Coveredlines    | `0`                                                                         |
| Uncoveredlines  | `24`                                                                        |
| Coverablelines  | `24`                                                                        |
| Totallines      | `49`                                                                        |
| Linecoverage    | `0`                                                                         |
| Coveredbranches | `0`                                                                         |
| Totalbranches   | `0`                                                                         |

## Metrics

| Complexity | Lines | Branches | Name              |
| :--------- | :---- | :------- | :---------------- |
| 1          | 0     | 100      | `get_TestContext` |
| 1          | 0     | 100      | `TestXPath`       |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.CodeAnalysis.Tests\CSharp\CSharpSementicNavigatorTests.cs

```CSharp
〰1:   using BinaryDataDecoders.CodeAnalysis.CSharp;
〰2:   using BinaryDataDecoders.TestUtilities;
〰3:   using BinaryDataDecoders.ToolKit;
〰4:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰5:   using System.Xml;
〰6:   
〰7:   namespace BinaryDataDecoders.CodeAnalysis.Tests.CSharp
〰8:   {
〰9:       [TestClass]
〰10:      public class CSharpSementicNavigatorTests
〰11:      {
‼12:          public TestContext TestContext { get; set; }
〰13:  
〰14:          [TestMethod]
〰15:          //[TestCategory(TestCategories.Unit)]
〰16:          [TestTarget(typeof(SemanticModelNavigatorFactory), Member = nameof(SemanticModelNavigatorFactory.AsNode))]
〰17:          public void TestXPath()
〰18:          {
‼19:              var filePath = @"SampleClasses.cs";
‼20:              using var stream = this.GetResourceStream(filePath);
‼21:              var csharp = new CSharpSementicNavigator();
‼22:              var navigator = csharp.ToNavigable(stream).CreateNavigator();
〰23:  
‼24:              this.TestContext.AddResult(navigator);
〰25:  
‼26:              var query = navigator.Compile(@"//cs-n:CompilationUnit//*[self::cs-n:ClassDeclaration or self::cs-n:InterfaceDeclaration or self::cs-n:StructDeclaration or self::cs-n:EnumDeclaration]");
‼27:              var manager = new XmlNamespaceManager(navigator.NameTable);
‼28:              manager.AddNamespace("cs-n", "bdd:CodeAnalysis/Node");
‼29:              manager.AddNamespace("cs-s", "bdd:CodeAnalysis/Symbol");
‼30:              query.SetContext(manager);
‼31:              var selected = navigator.Select(query);
‼32:              this.TestContext.AddResult(selected, "QueryTypes.xml");
‼33:              Assert.AreEqual(13, selected.Count);
〰34:  
‼35:              var rootQuery = navigator.Compile("/");
‼36:              rootQuery.SetContext(manager);
‼37:              var root = navigator.Select(rootQuery);
‼38:              this.TestContext.AddResult(root, "QueryRoot.xml");
‼39:              Assert.AreEqual(1, root.Count);
〰40:  
‼41:              var querySymbols = navigator.Compile(@"//cs-s:*");
‼42:              querySymbols.SetContext(manager);
‼43:              var selectedSymbols = navigator.Select(querySymbols);
‼44:              this.TestContext.AddResult(selectedSymbols, "QuerySymbols.xml");
〰45:  
〰46:  
‼47:          }
〰48:      }
〰49:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

