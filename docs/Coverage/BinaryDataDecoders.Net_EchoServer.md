# BinaryDataDecoders.Net.Services.EchoServer

## Summary

| Key             | Value                                        |
| :-------------- | :------------------------------------------- |
| Class           | `BinaryDataDecoders.Net.Services.EchoServer` |
| Assembly        | `BinaryDataDecoders.Net`                     |
| Coveredlines    | `0`                                          |
| Uncoveredlines  | `3`                                          |
| Coverablelines  | `3`                                          |
| Totallines      | `16`                                         |
| Linecoverage    | `0`                                          |
| Coveredbranches | `0`                                          |
| Totalbranches   | `0`                                          |
| Coveredmethods  | `0`                                          |
| Totalmethods    | `2`                                          |
| Methodcoverage  | `0`                                          |

## Metrics

| Complexity | Lines | Branches | Name                   |
| :--------- | :---- | :------- | :--------------------- |
| 1          | 0     | 100      | `ctor`                 |
| 1          | 0     | 100      | `MessageReceivedAsync` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Net/Services/EchoServer.cs

```CSharp
〰1:   using BinaryDataDecoders.Net.Sockets;
〰2:   using System;
〰3:   using System.Net;
〰4:   using System.Net.Sockets;
〰5:   using System.Threading;
〰6:   using System.Threading.Tasks;
〰7:   
〰8:   namespace BinaryDataDecoders.Net.Services;
〰9:   
‼10:  public class EchoServer(IPAddress? ipAddress = default, ushort port = 7) : ServerBase(ipAddress, port)
〰11:  {
〰12:      protected override async Task MessageReceivedAsync(int clientId, TcpClient accepted, Memory<byte> message, CancellationToken cancellationToken)
〰13:      {
‼14:          await accepted.GetStream().WriteAsync(message, cancellationToken);
‼15:      }
〰16:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

