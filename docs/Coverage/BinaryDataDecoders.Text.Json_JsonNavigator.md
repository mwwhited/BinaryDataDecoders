
# BinaryDataDecoders.Text.Json.JsonNavigator
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.Text.Json_JsonNavigator.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.Text.Json.JsonNavigator                   | 
| Assembly             | BinaryDataDecoders.Text.Json                                 | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 4                                                            | 
| Coverablelines       | 4                                                            | 
| Totallines           | 22                                                           | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Text.Json\JsonNavigator.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 0     | 100      | ToNavigable | 
| 1          | 0     | 100      | ToNavigable | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Text.Json\JsonNavigator.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.MetaData;
〰2:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰3:   using System.IO;
〰4:   using System.Text.Json;
〰5:   using System.Xml.XPath;
〰6:   
〰7:   namespace BinaryDataDecoders.Text.Json
〰8:   {
〰9:       [FileExtension(".json")]
〰10:      [MediaType("application/json")]
〰11:      public class JsonNavigator : IToXPathNavigable
〰12:      {
〰13:          public IXPathNavigable ToNavigable(string inputFile)
〰14:          {
‼15:              using var file = File.OpenRead(inputFile);
‼16:              return ToNavigable(file);
‼17:          }
〰18:  
〰19:          public IXPathNavigable ToNavigable(Stream inputFile) =>
‼20:              JsonDocument.Parse(inputFile).ToNavigable();
〰21:      }
〰22:  }

```
## Footer 
[Return to Summary](Summary.md)

