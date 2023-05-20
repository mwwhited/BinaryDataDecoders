# BinaryDataDecoders.Net.Services.TimeServer

## Summary

| Key             | Value                                        |
| :-------------- | :------------------------------------------- |
| Class           | `BinaryDataDecoders.Net.Services.TimeServer` |
| Assembly        | `BinaryDataDecoders.Net`                     |
| Coveredlines    | `0`                                          |
| Uncoveredlines  | `6`                                          |
| Coverablelines  | `6`                                          |
| Totallines      | `24`                                         |
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

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Net/Services/TimeServer.cs

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
〰10:      public class TimeServer : ServerBase
〰11:      {
〰12:          public TimeServer(IPAddress? ipAddress = default, ushort port = 37)
‼13:              : base(ipAddress, port)
〰14:          {
‼15:          }
〰16:  
〰17:          protected override async Task MessageReceivedAsync(int clientId, TcpClient accepted, Memory<byte> message, CancellationToken cancellationToken)
〰18:          {
‼19:              var timeDiff = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - new DateTimeOffset(1900, 1, 1, 0, 0, 0, new TimeSpan(0, 0, 0)).ToUnixTimeSeconds();
‼20:              Memory<byte> buffer = BitConverter.GetBytes((int)timeDiff);
‼21:              await accepted.GetStream().WriteAsync(buffer);
‼22:          }
〰23:      }
〰24:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

