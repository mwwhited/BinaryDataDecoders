# BinaryDataDecoders.CodeAnalysis.DacFx.DacPacNavigator

## Summary

| Key             | Value                                                   |
| :-------------- | :------------------------------------------------------ |
| Class           | `BinaryDataDecoders.CodeAnalysis.DacFx.DacPacNavigator` |
| Assembly        | `BinaryDataDecoders.CodeAnalysis.DacFx`                 |
| Coveredlines    | `0`                                                     |
| Uncoveredlines  | `4`                                                     |
| Coverablelines  | `4`                                                     |
| Totallines      | `22`                                                    |
| Linecoverage    | `0`                                                     |
| Coveredbranches | `0`                                                     |
| Totalbranches   | `0`                                                     |
| Coveredmethods  | `0`                                                     |
| Totalmethods    | `2`                                                     |
| Methodcoverage  | `0`                                                     |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `ToNavigable` |
| 1          | 0     | 100      | `ToNavigable` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.CodeAnalysis.DacFx/DacPacNavigator.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.IO;
〰2:   using BinaryDataDecoders.ToolKit.MetaData;
〰3:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰4:   using Microsoft.SqlServer.Dac.Model;
〰5:   using System.IO;
〰6:   using System.Xml.XPath;
〰7:   
〰8:   namespace BinaryDataDecoders.CodeAnalysis.DacFx
〰9:   {
〰10:      [FileExtension(".dacpac")]
〰11:      public class DacPacNavigator : IToXPathNavigable
〰12:      {
〰13:          public IXPathNavigable ToNavigable(string filePath) =>
‼14:              new DacPacElementNodeBuilder(new TSqlModel(filePath)).Build().ToNavigable();
〰15:  
〰16:          public IXPathNavigable ToNavigable(Stream stream)
〰17:          {
‼18:              using var temp = stream.AsTempFile();
‼19:              return ToNavigable(temp.FilePath);
‼20:          }
〰21:      }
〰22:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

