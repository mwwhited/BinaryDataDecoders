# BinaryDataDecoders.Zoom.H4n.H4nDecoder

## Summary

| Key             | Value                                    |
| :-------------- | :--------------------------------------- |
| Class           | `BinaryDataDecoders.Zoom.H4n.H4nDecoder` |
| Assembly        | `BinaryDataDecoders.Zoom.H4n`            |
| Coveredlines    | `0`                                      |
| Uncoveredlines  | `1`                                      |
| Coverablelines  | `1`                                      |
| Totallines      | `10`                                     |
| Linecoverage    | `0`                                      |
| Coveredbranches | `0`                                      |
| Totalbranches   | `0`                                      |

## Metrics

| Complexity | Lines | Branches | Name     |
| :--------- | :---- | :------- | :------- |
| 1          | 0     | 100      | `Decode` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Zoom.H4n/H4nDecoder.cs

```CSharp
〰1:   using BinaryDataDecoders.IO.Messages;
〰2:   using System.Buffers;
〰3:   
〰4:   namespace BinaryDataDecoders.Zoom.H4n
〰5:   {
〰6:       public class H4nDecoder : IMessageDecoder<IH4nMessage>
〰7:       {
‼8:           public IH4nMessage Decode(ReadOnlySequence<byte> response) => new H4nResponse(response.ToArray()[0]);
〰9:       }
〰10:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

