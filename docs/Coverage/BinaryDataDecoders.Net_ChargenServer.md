# BinaryDataDecoders.Net.Services.ChargenServer

## Summary

| Key             | Value                                           |
| :-------------- | :---------------------------------------------- |
| Class           | `BinaryDataDecoders.Net.Services.ChargenServer` |
| Assembly        | `BinaryDataDecoders.Net`                        |
| Coveredlines    | `0`                                             |
| Uncoveredlines  | `19`                                            |
| Coverablelines  | `19`                                            |
| Totallines      | `49`                                            |
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
〰9:   namespace BinaryDataDecoders.Net.Services
〰10:  {
〰11:      public class ChargenServer : ServerBase
〰12:      {
〰13:          public ChargenServer(IPAddress? ipAddress = default, ushort port = 19)
‼14:              : base(ipAddress, port)
〰15:          {
‼16:          }
〰17:  
〰18:          protected override async Task OnStartAsync(CancellationToken cancellationToken)
〰19:          {
‼20:              var rand = new Random();
‼21:              var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
‼22:              while (!cancellationToken.IsCancellationRequested)
〰23:              {
‼24:                  foreach (var client in Clients.ToArray())
〰25:                  {
〰26:                      try
〰27:                      {
‼28:                          if (!client.Value.Connected)
‼29:                              continue;
〰30:  
‼31:                          if (rand.NextDouble() > 0.5)
‼32:                              continue;
‼33:                          Memory<byte> buffer = Guid.NewGuid().ToByteArray();
‼34:                          await client.Value.GetStream().WriteAsync(buffer, cts.Token);
‼35:                      }
‼36:                      catch (OperationCanceledException ocex)
〰37:                      {
‼38:                          Console.WriteLine($"{this.GetType()}::ChargenServer::Canceled: {Thread.CurrentThread.ManagedThreadId} ({ocex.Message})");
‼39:                      }
〰40:                  }
〰41:  
‼42:                  await Task.Delay(rand.Next(1, 10) * 100);
〰43:              }
‼44:          }
〰45:  
〰46:          protected override Task MessageReceivedAsync(int clientId, TcpClient accepted, Memory<byte> message, CancellationToken cancellationToken) =>
‼47:              Task.CompletedTask;
〰48:      }
〰49:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

