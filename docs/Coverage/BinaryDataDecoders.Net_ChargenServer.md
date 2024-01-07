# BinaryDataDecoders.Net.Services.ChargenServer

## Summary

| Key             | Value                                           |
| :-------------- | :---------------------------------------------- |
| Class           | `BinaryDataDecoders.Net.Services.ChargenServer` |
| Assembly        | `BinaryDataDecoders.Net`                        |
| Coveredlines    | `0`                                             |
| Uncoveredlines  | `18`                                            |
| Coverablelines  | `18`                                            |
| Totallines      | `43`                                            |
| Linecoverage    | `0`                                             |
| Coveredbranches | `0`                                             |
| Totalbranches   | `8`                                             |
| Branchcoverage  | `0`                                             |
| Coveredmethods  | `0`                                             |
| Totalmethods    | `3`                                             |
| Methodcoverage  | `0`                                             |

## Metrics

| Complexity | Lines | Branches | Name                   |
| :--------- | :---- | :------- | :--------------------- |
| 1          | 0     | 100      | `ctor`                 |
| 8          | 0     | 0        | `OnStartAsync`         |
| 1          | 0     | 100      | `MessageReceivedAsync` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Net/Services/ChargenServer.cs

```CSharp
〰1:   using BinaryDataDecoders.Net.Sockets;
〰2:   using System;
〰3:   using System.Linq;
〰4:   using System.Net;
〰5:   using System.Net.Sockets;
〰6:   using System.Threading;
〰7:   using System.Threading.Tasks;
〰8:   
〰9:   namespace BinaryDataDecoders.Net.Services;
〰10:  
‼11:  public class ChargenServer(IPAddress? ipAddress = default, ushort port = 19) : ServerBase(ipAddress, port)
〰12:  {
〰13:      protected override async Task OnStartAsync(CancellationToken cancellationToken)
〰14:      {
‼15:          var rand = new Random();
‼16:          var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
‼17:          while (!cancellationToken.IsCancellationRequested)
〰18:          {
‼19:              foreach (var client in Clients.ToArray())
〰20:              {
〰21:                  try
〰22:                  {
‼23:                      if (!client.Value.Connected)
‼24:                          continue;
〰25:  
‼26:                      if (rand.NextDouble() > 0.5)
‼27:                          continue;
‼28:                      Memory<byte> buffer = Guid.NewGuid().ToByteArray();
‼29:                      await client.Value.GetStream().WriteAsync(buffer, cts.Token);
‼30:                  }
‼31:                  catch (OperationCanceledException ocex)
〰32:                  {
‼33:                      Console.WriteLine($"{this.GetType()}::ChargenServer::Canceled: {Environment.CurrentManagedThreadId} ({ocex.Message})");
‼34:                  }
〰35:              }
〰36:  
‼37:              await Task.Delay(rand.Next(1, 10) * 100, cancellationToken);
〰38:          }
‼39:      }
〰40:  
〰41:      protected override Task MessageReceivedAsync(int clientId, TcpClient accepted, Memory<byte> message, CancellationToken cancellationToken) =>
‼42:          Task.CompletedTask;
〰43:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

