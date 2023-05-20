# BinaryDataDecoders.Net.Services.EchoServer

## Summary

| Key             | Value                                        |
| :-------------- | :------------------------------------------- |
| Class           | `BinaryDataDecoders.Net.Services.EchoServer` |
| Assembly        | `BinaryDataDecoders.Net`                     |
| Coveredlines    | `0`                                          |
| Uncoveredlines  | `4`                                          |
| Coverablelines  | `4`                                          |
| Totallines      | `22`                                         |
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
〰8:   namespace BinaryDataDecoders.Net.Services
〰9:   {
〰10:      public class EchoServer : ServerBase
〰11:      {
〰12:          public EchoServer(IPAddress? ipAddress = default, ushort port = 7)
‼13:              : base(ipAddress, port)
〰14:          {
‼15:          }
〰16:  
〰17:          protected override async Task MessageReceivedAsync(int clientId, TcpClient accepted, Memory<byte> message, CancellationToken cancellationToken)
〰18:          {
‼19:              await accepted.GetStream().WriteAsync(message);
‼20:          }
〰21:      }
〰22:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

