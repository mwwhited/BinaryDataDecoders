# BinaryDataDecoders.Text.Json.JsonPath.Parser.JsonPathException

## Summary

| Key             | Value                                                            |
| :-------------- | :--------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Text.Json.JsonPath.Parser.JsonPathException` |
| Assembly        | `BinaryDataDecoders.Text.Json`                                   |
| Coveredlines    | `0`                                                              |
| Uncoveredlines  | `8`                                                              |
| Coverablelines  | `8`                                                              |
| Totallines      | `24`                                                             |
| Linecoverage    | `0`                                                              |
| Coveredbranches | `0`                                                              |
| Totalbranches   | `0`                                                              |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 1          | 0     | 100      | `ctor`  |
| 1          | 0     | 100      | `ctor`  |
| 1          | 0     | 100      | `ctor`  |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Text.Json\JsonPath\Parser\JsonPathException.cs

```CSharp
〰1:   using System;
〰2:   using System.Runtime.Serialization;
〰3:   
〰4:   namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
〰5:   {
〰6:       public class JsonPathException : Exception
〰7:       {
‼8:           public JsonPathException()
〰9:           {
‼10:          }
〰11:  
‼12:          public JsonPathException(string message) : base(message)
〰13:          {
‼14:          }
〰15:  
‼16:          public JsonPathException(string message, Exception innerException) : base(message, innerException)
〰17:          {
‼18:          }
〰19:  
‼20:          protected JsonPathException(SerializationInfo info, StreamingContext context) : base(info, context)
〰21:          {
‼22:          }
〰23:      }
〰24:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

