# BinaryDataDecoders.Net.Services.DaytimeServer

## Summary

| Key             | Value                                           |
| :-------------- | :---------------------------------------------- |
| Class           | `BinaryDataDecoders.Net.Services.DaytimeServer` |
| Assembly        | `BinaryDataDecoders.Net`                        |
| Coveredlines    | `0`                                             |
| Uncoveredlines  | `5`                                             |
| Coverablelines  | `5`                                             |
| Totallines      | `24`                                            |
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

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Net/Services/DaytimeServer.cs

```CSharp
〰1:   using BinaryDataDecoders.Net.Sockets;
〰2:   using System;
〰3:   using System.Net;
〰4:   using System.Net.Sockets;
〰5:   using System.Text;
〰6:   using System.Threading;
〰7:   using System.Threading.Tasks;
〰8:   
〰9:   namespace BinaryDataDecoders.Net.Services
〰10:  {
〰11:      public class DaytimeServer : ServerBase
〰12:      {
〰13:          public DaytimeServer(IPAddress? ipAddress = default, ushort port = 13)
‼14:              : base(ipAddress, port)
〰15:          {
‼16:          }
〰17:  
〰18:          protected override async Task MessageReceivedAsync(int clientId, TcpClient accepted, Memory<byte> message, CancellationToken cancellationToken)
〰19:          {
‼20:              Memory<byte> buffer = Encoding.UTF8.GetBytes(DateTimeOffset.Now.ToString());
‼21:              await accepted.GetStream().WriteAsync(buffer);
‼22:          }
〰23:      }
〰24:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

