# BinaryDataDecoders.Net.Services.DiscardServer

## Summary

| Key             | Value                                           |
| :-------------- | :---------------------------------------------- |
| Class           | `BinaryDataDecoders.Net.Services.DiscardServer` |
| Assembly        | `BinaryDataDecoders.Net`                        |
| Coveredlines    | `0`                                             |
| Uncoveredlines  | `2`                                             |
| Coverablelines  | `2`                                             |
| Totallines      | `14`                                            |
| Linecoverage    | `0`                                             |
| Coveredbranches | `0`                                             |
| Totalbranches   | `0`                                             |
| Coveredmethods  | `0`                                             |
| Totalmethods    | `2`                                             |
| Methodcoverage  | `0`                                             |

## Metrics

| Complexity | Lines | Branches | Name                   |
| :--------- | :---- | :------- | :--------------------- |
| 1          | 0     | 100      | `ctor`                 |
| 1          | 0     | 100      | `MessageReceivedAsync` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Net/Services/DiscardServer.cs

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
‼10:  public class DiscardServer(IPAddress? ipAddress = default, ushort port = 9) : ServerBase(ipAddress, port)
〰11:  {
〰12:      protected override Task MessageReceivedAsync(int clientId, TcpClient accepted, Memory<byte> message, CancellationToken cancellationToken) =>
‼13:          Task.CompletedTask;
〰14:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

