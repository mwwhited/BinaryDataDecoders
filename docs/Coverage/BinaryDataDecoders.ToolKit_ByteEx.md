
# BinaryDataDecoders.ToolKit.ByteEx
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_ByteEx.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.ByteEx                            | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 1                                                            | 
| Coverablelines       | 1                                                            | 
| Totallines           | 20                                                           | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 4                                                            | 
| Branchcoverage       | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\ByteEx.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 4          | 0     | 0        | ToHexString | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\ByteEx.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.Linq;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit
〰5:   {
〰6:       /// <summary>
〰7:       /// Extenions for byte and IEnumerable&lt;byte&gt;
〰8:       /// </summary>
〰9:       public static class ByteEx
〰10:      {
〰11:          /// <summary>
〰12:          /// Convert enumerable byte set as
〰13:          /// </summary>
〰14:          /// <param name="data"></param>
〰15:          /// <param name="delimiter"></param>
〰16:          /// <returns></returns>
〰17:          public static string ToHexString(this IEnumerable<byte> data, string delimiter = "")=>
‼18:              string.Join(delimiter ?? "", (data ?? Enumerable.Empty<byte>()).Select(b => b.ToString("x2")));
〰19:      }
〰20:  }

```
## Footer 
[Return to Summary](Summary.md)

