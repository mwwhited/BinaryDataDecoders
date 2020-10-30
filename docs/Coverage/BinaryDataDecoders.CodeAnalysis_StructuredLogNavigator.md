
# BinaryDataDecoders.CodeAnalysis.StructuredLog.StructuredLogNavigator
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.CodeAnalysis_StructuredLogNavigator.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.CodeAnalysis.StructuredLog.StructuredLogN | 
| Assembly             | BinaryDataDecoders.CodeAnalysis                              | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 2                                                            | 
| Coverablelines       | 2                                                            | 
| Totallines           | 16                                                           | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.CodeAnalysis\StructuredLog\StructuredLogNavigator.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 0     | 100      | ToNavigable | 
| 1          | 0     | 100      | ToNavigable | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.CodeAnalysis\StructuredLog\StructuredLogNavigator.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.MetaData;
〰2:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰3:   using Microsoft.Build.Logging.StructuredLogger;
〰4:   using System.IO;
〰5:   using System.Xml.XPath;
〰6:   
〰7:   namespace BinaryDataDecoders.CodeAnalysis.StructuredLog
〰8:   {
〰9:       [FileExtension(".binlog")]
〰10:      public class StructuredLogNavigator : IToXPathNavigable
〰11:      {
‼12:          public IXPathNavigable ToNavigable(string filePath) => Serialization.Read(filePath).ToNavigable();
〰13:  
‼14:          public IXPathNavigable ToNavigable(Stream stream) => Serialization.ReadBinLog(stream).ToNavigable();
〰15:      }
〰16:  }

```
## Footer 
[Return to Summary](Summary.md)

