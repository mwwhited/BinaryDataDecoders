# BinaryDataDecoders.IO.Messages.MessageEncoder`1

## Summary

| Key             | Value                                             |
| :-------------- | :------------------------------------------------ |
| Class           | `BinaryDataDecoders.IO.Messages.MessageEncoder`1` |
| Assembly        | `BinaryDataDecoders.IO.Abstractions`              |
| Coveredlines    | `0`                                               |
| Uncoveredlines  | `7`                                               |
| Coverablelines  | `7`                                               |
| Totallines      | `19`                                              |
| Linecoverage    | `0`                                               |
| Coveredbranches | `0`                                               |
| Totalbranches   | `0`                                               |
| Coveredmethods  | `0`                                               |
| Totalmethods    | `1`                                               |
| Methodcoverage  | `0`                                               |

## Metrics

| Complexity | Lines | Branches | Name     |
| :--------- | :---- | :------- | :------- |
| 1          | 0     | 100      | `Encode` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Abstractions/Messages/MessageEncoder.cs

```CSharp
〰1:   using System;
〰2:   using System.Runtime.InteropServices;
〰3:   
〰4:   namespace BinaryDataDecoders.IO.Messages
〰5:   {
〰6:       public class MessageEncoder<TMessage> : IMessageEncoder<TMessage>
〰7:       {
〰8:           public ReadOnlyMemory<byte> Encode(ref TMessage request)
〰9:           {
‼10:              var requestBuffer = new byte[Marshal.SizeOf(request)];
‼11:              IntPtr ptr = Marshal.AllocHGlobal(requestBuffer.Length);
‼12:              Marshal.StructureToPtr(request, ptr, true);
‼13:              Marshal.Copy(ptr, requestBuffer, 0, requestBuffer.Length);
‼14:              Marshal.FreeHGlobal(ptr);
‼15:              ReadOnlyMemory<byte> span = requestBuffer;
‼16:              return span;
〰17:          }
〰18:      }
〰19:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

