# BinaryDataDecoders.CodeAnalysis.DacFx.DacPacNavigator

## Summary

| Key             | Value                                                   |
| :-------------- | :------------------------------------------------------ |
| Class           | `BinaryDataDecoders.CodeAnalysis.DacFx.DacPacNavigator` |
| Assembly        | `BinaryDataDecoders.CodeAnalysis.DacFx`                 |
| Coveredlines    | `0`                                                     |
| Uncoveredlines  | `4`                                                     |
| Coverablelines  | `4`                                                     |
| Totallines      | `21`                                                    |
| Linecoverage    | `0`                                                     |
| Coveredbranches | `0`                                                     |
| Totalbranches   | `0`                                                     |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `ToNavigable` |
| 1          | 0     | 100      | `ToNavigable` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.CodeAnalysis.DacFx\DacPacNavigator.cs

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
‼13:          public IXPathNavigable ToNavigable(string filePath) => new TSqlModel(filePath).ToNavigable();
〰14:  
〰15:          public IXPathNavigable ToNavigable(Stream stream)
〰16:          {
‼17:              using var temp = stream.AsTempFile();
‼18:              return ToNavigable(temp.FilePath);
‼19:          }
〰20:      }
〰21:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

