# BinaryDataDecoders.Net.Services.DaytimeServer

## Summary

| Key             | Value                                           |
| :-------------- | :---------------------------------------------- |
| Class           | `BinaryDataDecoders.Net.Services.DaytimeServer` |
| Assembly        | `BinaryDataDecoders.Net`                        |
| Coveredlines    | `0`                                             |
| Uncoveredlines  | `4`                                             |
| Coverablelines  | `4`                                             |
| Totallines      | `18`                                            |
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
〰9:   namespace BinaryDataDecoders.Net.Services;
〰10:  
‼11:  public class DaytimeServer(IPAddress? ipAddress = default, ushort port = 13) : ServerBase(ipAddress, port)
〰12:  {
〰13:      protected override async Task MessageReceivedAsync(int clientId, TcpClient accepted, Memory<byte> message, CancellationToken cancellationToken)
〰14:      {
‼15:          Memory<byte> buffer = Encoding.UTF8.GetBytes(DateTimeOffset.Now.ToString());
‼16:          await accepted.GetStream().WriteAsync(buffer, cancellationToken);
‼17:      }
〰18:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

