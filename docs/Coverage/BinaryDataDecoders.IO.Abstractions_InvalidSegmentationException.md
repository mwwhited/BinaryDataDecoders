# BinaryDataDecoders.IO.Pipelines.Definitions.InvalidSegmentationException

## Summary

| Key             | Value                                                                      |
| :-------------- | :------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.Pipelines.Definitions.InvalidSegmentationException` |
| Assembly        | `BinaryDataDecoders.IO.Abstractions`                                       |
| Coveredlines    | `0`                                                                        |
| Uncoveredlines  | `8`                                                                        |
| Coverablelines  | `8`                                                                        |
| Totallines      | `25`                                                                       |
| Linecoverage    | `0`                                                                        |
| Coveredbranches | `0`                                                                        |
| Totalbranches   | `0`                                                                        |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 1          | 0     | 100      | `ctor`  |
| 1          | 0     | 100      | `ctor`  |
| 1          | 0     | 100      | `ctor`  |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.IO.Abstractions\Pipelines\Definitions\InvalidSegmentationException.cs

```CSharp
〰1:   using System;
〰2:   using System.Runtime.Serialization;
〰3:   
〰4:   namespace BinaryDataDecoders.IO.Pipelines.Definitions
〰5:   {
〰6:       [Serializable]
〰7:       public class InvalidSegmentationException : Exception
〰8:       {
‼9:           public InvalidSegmentationException()
〰10:          {
‼11:          }
〰12:  
‼13:          public InvalidSegmentationException(string message) : base(message)
〰14:          {
‼15:          }
〰16:  
‼17:          public InvalidSegmentationException(string message, Exception innerException) : base(message, innerException)
〰18:          {
‼19:          }
〰20:  
‼21:          protected InvalidSegmentationException(SerializationInfo info, StreamingContext context) : base(info, context)
〰22:          {
‼23:          }
〰24:      }
〰25:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

