# BinaryDataDecoders.Zoom.H4n.H4nResponse

## Summary

| Key             | Value                                     |
| :-------------- | :---------------------------------------- |
| Class           | `BinaryDataDecoders.Zoom.H4n.H4nResponse` |
| Assembly        | `BinaryDataDecoders.Zoom.H4n`             |
| Coveredlines    | `0`                                       |
| Uncoveredlines  | `4`                                       |
| Coverablelines  | `4`                                       |
| Totallines      | `17`                                      |
| Linecoverage    | `0`                                       |
| Coveredbranches | `0`                                       |
| Totalbranches   | `0`                                       |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `ctor`        |
| 1          | 0     | 100      | `ToString`    |
| 1          | 0     | 100      | `Equals`      |
| 1          | 0     | 100      | `GetHashCode` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Zoom.H4n/H4nResponse.cs

```CSharp
〰1:   using System.Runtime.InteropServices;
〰2:   
〰3:   namespace BinaryDataDecoders.Zoom.H4n
〰4:   {
〰5:       [StructLayout(LayoutKind.Explicit, Size = 1)]
〰6:       public struct H4nResponse : IH4nMessage
〰7:       {
‼8:           public H4nResponse(byte response) => Response = (H4nStatus)response;
〰9:   
〰10:          [FieldOffset(0)]
〰11:          public readonly H4nStatus Response;
〰12:  
‼13:          public override string ToString() => Response.ToString();
‼14:          public override bool Equals(object obj) => Response.Equals(obj);
‼15:          public override int GetHashCode() => Response.GetHashCode();
〰16:      }
〰17:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

