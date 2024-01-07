# BinaryDataDecoders.CodeAnalysis.Tests.CSharp.CSharpNavigatorTests

## Summary

| Key             | Value                                                               |
| :-------------- | :------------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.CodeAnalysis.Tests.CSharp.CSharpNavigatorTests` |
| Assembly        | `BinaryDataDecoders.CodeAnalysis.Tests`                             |
| Coveredlines    | `19`                                                                |
| Uncoveredlines  | `0`                                                                 |
| Coverablelines  | `19`                                                                |
| Totallines      | `45`                                                                |
| Linecoverage    | `100`                                                               |
| Coveredbranches | `0`                                                                 |
| Totalbranches   | `0`                                                                 |
| Coveredmethods  | `1`                                                                 |
| Totalmethods    | `1`                                                                 |
| Methodcoverage  | `100`                                                               |

## Metrics

| Complexity | Lines | Branches | Name        |
| :--------- | :---- | :------- | :---------- |
| 1          | 100   | 100      | `TestXPath` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.CodeAnalysis.Tests/CSharp/CSharpNavigatorTests.cs

```CSharp
〰1:   using BinaryDataDecoders.TestUtilities;
〰2:   using BinaryDataDecoders.ToolKit;
〰3:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰4:   using Microsoft.CodeAnalysis.CSharp;
〰5:   using Microsoft.CodeAnalysis.Text;
〰6:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰7:   using System.Xml;
〰8:   
〰9:   namespace BinaryDataDecoders.CodeAnalysis.Tests.CSharp;
〰10:  
〰11:  [TestClass]
〰12:  public class CSharpNavigatorTests
〰13:  {
〰14:      public TestContext TestContext { get; set; }
〰15:  
〰16:      [TestMethod]
〰17:      [TestCategory(TestCategories.Unit)]
〰18:      [TestTarget(typeof(SyntaxTreeNavigatorFactory), Member = nameof(SyntaxTreeNavigatorFactory.AsNode))]
〰19:      public void TestXPath()
〰20:      {
✔21:          var filePath = @"SampleClasses.cs";
✔22:          using var stream = this.GetResourceStream(filePath);
✔23:          var content = SourceText.From(stream);
✔24:          var syntax = CSharpSyntaxTree.ParseText(content);
✔25:          var node = syntax.AsNode(filePath);
✔26:          var nav = new ExtensibleNavigator(node);
✔27:          var navigator = nav.Clone();
〰28:          // this.TestContext.WriteLine(navigator.OuterXml);
✔29:          this.TestContext.AddResult(node);
〰30:  
✔31:          var query = navigator.Compile(@"//cs-n:CompilationUnit//*[self::cs-n:ClassDeclaration or self::cs-n:InterfaceDeclaration or self::cs-n:StructDeclaration or self::cs-n:EnumDeclaration]");
✔32:          var manager = new XmlNamespaceManager(navigator.NameTable);
✔33:          manager.AddNamespace("cs-n", "bdd:CodeAnalysis/Node");
✔34:          query.SetContext(manager);
✔35:          var selected = navigator.Select(query);
〰36:  
✔37:          Assert.AreEqual(13, selected.Count);
〰38:  
✔39:          var rootQuery = navigator.Compile("/");
✔40:          rootQuery.SetContext(manager);
✔41:          var root = navigator.Select(rootQuery);
✔42:          Assert.AreEqual(1, root.Count);
✔43:      }
〰44:  }
〰45:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

