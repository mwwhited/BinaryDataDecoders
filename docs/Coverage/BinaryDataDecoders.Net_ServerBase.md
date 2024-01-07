# BinaryDataDecoders.Net.Sockets.ServerBase

## Summary

| Key             | Value                                       |
| :-------------- | :------------------------------------------ |
| Class           | `BinaryDataDecoders.Net.Sockets.ServerBase` |
| Assembly        | `BinaryDataDecoders.Net`                    |
| Coveredlines    | `0`                                         |
| Uncoveredlines  | `85`                                        |
| Coverablelines  | `85`                                        |
| Totallines      | `164`                                       |
| Linecoverage    | `0`                                         |
| Coveredbranches | `0`                                         |
| Totalbranches   | `56`                                        |
| Branchcoverage  | `0`                                         |
| Coveredmethods  | `0`                                         |
| Totalmethods    | `9`                                         |
| Methodcoverage  | `0`                                         |

## Metrics

| Complexity | Lines | Branches | Name                |
| :--------- | :---- | :------- | :------------------ |
| 2          | 0     | 0        | `ctor`              |
| 2          | 0     | 0        | `Start`             |
| 1          | 0     | 100      | `OnStartAsync`      |
| 14         | 0     | 0        | `StopAsync`         |
| 8          | 0     | 0        | `ServiceLoopAsync`  |
| 1          | 0     | 100      | `ServiceLoopAsync`  |
| 12         | 0     | 0        | `AcceptClientAsync` |
| 1          | 0     | 100      | `get_Clients`       |
| 18         | 0     | 0        | `DisposeAsync`      |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Net/Sockets/ServerBase.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Linq;
〰4:   using System.Net;
〰5:   using System.Net.Sockets;
〰6:   using System.Text;
〰7:   using System.Threading;
〰8:   using System.Threading.Tasks;
〰9:   
〰10:  namespace BinaryDataDecoders.Net.Sockets;
〰11:  
〰12:  public abstract class ServerBase : IServerBase
〰13:  {
〰14:      protected IPAddress IPAddress { get; init; }
〰15:      protected ushort Port { get; init; }
〰16:  
〰17:      protected ServerBase(IPAddress? ipAddress = default, ushort port = 65535)
〰18:      {
‼19:          IPAddress = ipAddress ?? IPAddress.Loopback;
‼20:          Port = port;
‼21:      }
〰22:  
〰23:      public void Start()
〰24:      {
‼25:          if (_listener != null)
‼26:              throw new ApplicationException("Already Started!");
‼27:          Console.WriteLine($"{this.GetType()}::Starting: {Thread.CurrentThread.ManagedThreadId} [{IPAddress}:{Port}]");
‼28:          _listener = new TcpListener(IPAddress, Port);
‼29:          _listener.Start();
‼30:          _cts = new CancellationTokenSource();
〰31:  
‼32:          var serviceLoopTask = Task.Run(() => ServiceLoopAsync(_listener, _cts.Token));
‼33:          var startTask = Task.Run(() => OnStartAsync(_cts.Token));
〰34:  
‼35:          _task = Task.WhenAll(serviceLoopTask, startTask);
‼36:      }
〰37:  
‼38:      protected virtual Task OnStartAsync(CancellationToken cancellationToken) => Task.CompletedTask;
〰39:  
〰40:      public async Task<IAsyncDisposable> StopAsync()
〰41:      {
‼42:          _cts?.Cancel();
‼43:          await Task.Yield();
〰44:  
‼45:          foreach (var client in _clients)
〰46:          {
‼47:              if (client.Value.Connected)
〰48:              {
‼49:                  client.Value.Close();
‼50:                  await Task.Yield();
〰51:              }
〰52:          }
〰53:  
‼54:          _listener?.Stop();
‼55:          await Task.Yield();
‼56:          return this;
‼57:      }
〰58:  
〰59:      protected async Task ServiceLoopAsync(TcpListener listener, CancellationToken cancellationToken)
〰60:      {
‼61:          var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
‼62:          var clientIdSeed = 0;
‼63:          while (!cancellationToken.IsCancellationRequested)
〰64:          {
〰65:              try
〰66:              {
‼67:                  Console.WriteLine($"{this.GetType()}::ServiceLoopAsync::Listening: {Thread.CurrentThread.ManagedThreadId}");
‼68:                  var accepted = await listener.AcceptTcpClientAsync(cts.Token);
‼69:                  var clientId = clientIdSeed++;
‼70:                  _clients.Add(clientId, accepted);
〰71:  
〰72:  
‼73:                  var clientTask = Task.Run(async () =>
‼74:                  {
‼75:                      Console.WriteLine($"{this.GetType()}::ServiceLoopAsync::Accepted: {clientId}-{Thread.CurrentThread.ManagedThreadId}");
‼76:                      await AcceptClientAsync(clientId, accepted, cts.Token);
‼77:                      Console.WriteLine($"{this.GetType()}::ServiceLoopAsync::Closed:   {clientId}-{Thread.CurrentThread.ManagedThreadId}");
‼78:                  });
‼79:                  _tasks.Add(clientTask);
〰80:  
‼81:                  await Task.Yield();
〰82:  
‼83:                  var areCompleted = _tasks.Where(t => t.IsCompleted).ToArray();
‼84:                  foreach (var completed in areCompleted)
‼85:                      _tasks.Remove(completed);
〰86:  
‼87:                  var areNotCollected = _clients.Where(c => !c.Value.Connected).ToArray();
‼88:                  foreach (var notCollected in areNotCollected)
‼89:                      _clients.Remove(notCollected.Key);
‼90:              }
‼91:              catch (OperationCanceledException ocex)
〰92:              {
‼93:                  Console.WriteLine($"{this.GetType()}::ServiceLoopAsync::Canceled: {Thread.CurrentThread.ManagedThreadId} ({ocex.Message})");
‼94:              }
〰95:          }
‼96:      }
〰97:  
〰98:      protected virtual async Task AcceptClientAsync(int clientId, TcpClient accepted, CancellationToken cancellationToken)
〰99:      {
‼100:         var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
‼101:         using var stream = accepted.GetStream();
‼102:         Memory<byte> buffer = new byte[1024];
‼103:         while (!cancellationToken.IsCancellationRequested && accepted.Connected)
〰104:         {
〰105:             try
〰106:             {
‼107:                 if (stream.CanRead)
〰108:                 {
‼109:                     var readLength = await stream.ReadAsync(buffer, cts.Token);
‼110:                     if (readLength > 0)
〰111:                     {
‼112:                         var sliced = buffer[..readLength];
‼113:                         Console.WriteLine($"{this.GetType()}: {clientId}-{Thread.CurrentThread.ManagedThreadId}: {Encoding.UTF8.GetString(sliced.ToArray())}");
‼114:                         await MessageReceivedAsync(clientId, accepted, sliced, cts.Token);
〰115:                     }
‼116:                     else if (readLength <= 0)
〰117:                     {
‼118:                         break;
〰119:                     }
〰120:                 }
‼121:                 await Task.Yield();
‼122:             }
‼123:             catch (OperationCanceledException ocex)
〰124:             {
‼125:                 Console.WriteLine($"{this.GetType()}::ServiceLoopAsync::Canceled: {clientId}-{Thread.CurrentThread.ManagedThreadId} ({ocex.Message})");
‼126:             }
〰127:         }
‼128:     }
〰129: 
〰130:     protected abstract Task MessageReceivedAsync(int clientId, TcpClient accepted, Memory<byte> message, CancellationToken cancellationToken);
〰131: 
〰132:     private CancellationTokenSource? _cts;
〰133:     private TcpListener? _listener;
〰134:     private Task? _task;
‼135:     private readonly Dictionary<int, TcpClient> _clients = new();
‼136:     private readonly List<Task> _tasks = new();
〰137: 
‼138:     protected IReadOnlyDictionary<int, TcpClient> Clients => _clients;
〰139: 
〰140:     public async ValueTask DisposeAsync()
〰141:     {
‼142:         _cts?.Cancel();
‼143:         _listener?.Stop();
〰144: 
‼145:         await Task.Yield();
〰146: 
‼147:         await Task.WhenAll(
‼148:             _task ?? Task.CompletedTask,
‼149:             Task.WhenAll(_tasks)
‼150:             );
〰151: 
‼152:         await Task.Yield();
〰153: 
‼154:         foreach (var client in _clients)
〰155:         {
‼156:             client.Value.Dispose();
‼157:             await Task.Yield();
〰158:         }
〰159: 
‼160:         await Task.Yield();
〰161: 
‼162:         _cts?.Dispose();
‼163:     }
〰164: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

