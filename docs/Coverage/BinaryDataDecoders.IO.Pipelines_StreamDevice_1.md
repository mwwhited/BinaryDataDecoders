# BinaryDataDecoders.IO.Pipelines.StreamDevice`1

## Summary

| Key             | Value                                            |
| :-------------- | :----------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.Pipelines.StreamDevice`1` |
| Assembly        | `BinaryDataDecoders.IO.Pipelines`                |
| Coveredlines    | `0`                                              |
| Uncoveredlines  | `97`                                             |
| Coverablelines  | `97`                                             |
| Totallines      | `142`                                            |
| Linecoverage    | `0`                                              |
| Coveredbranches | `0`                                              |
| Totalbranches   | `36`                                             |
| Branchcoverage  | `0`                                              |

## Metrics

| Complexity | Lines | Branches | Name                          |
| :--------- | :---- | :------- | :---------------------------- |
| 10         | 0     | 0        | `ctor`                        |
| 1          | 0     | 100      | `get_CancellationTokenSource` |
| 1          | 0     | 100      | `get_Runner`                  |
| 1          | 0     | 100      | `Transmit`                    |
| 2          | 0     | 0        | `OnMessageReceived`           |
| 8          | 0     | 0        | `Receiver`                    |
| 16         | 0     | 0        | `Transmitter`                 |
| 1          | 0     | 100      | `Dispose`                     |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Pipelines/StreamDevice.cs

```CSharp
〰1:   using BinaryDataDecoders.IO.Messages;
〰2:   using BinaryDataDecoders.IO.Segmenters;
〰3:   using System;
〰4:   using System.Collections.Concurrent;
〰5:   using System.IO;
〰6:   using System.Threading;
〰7:   using System.Threading.Tasks;
〰8:   
〰9:   namespace BinaryDataDecoders.IO.Pipelines
〰10:  {
〰11:      public class StreamDevice<TMessage> : IStreamDevice<TMessage>
〰12:      {
‼13:          private readonly IProducerConsumerCollection<TMessage> _transmissionQueue = new ConcurrentQueue<TMessage>();
〰14:  
〰15:          private readonly Stream _stream;
〰16:          private readonly ISegmentBuildDefinition _segmentDefintion;
〰17:          private readonly IMessageDecoder<TMessage> _decoder;
〰18:          private readonly IMessageEncoder<TMessage> _encoder;
〰19:          private readonly int _minimumTrasmissionDelay;
〰20:  
‼21:          public StreamDevice(
‼22:              Stream stream,
‼23:              IDeviceDefinition device,
‼24:              CancellationTokenSource? cancellationTokenSource = default,
‼25:              int minimumTrasmissionDelay = 1000
‼26:              )
〰27:          {
‼28:              CancellationTokenSource = cancellationTokenSource ?? new CancellationTokenSource();
〰29:  
‼30:              _stream = stream;
‼31:              _minimumTrasmissionDelay = minimumTrasmissionDelay;
〰32:  
‼33:              Task? messageReceiver = null;
‼34:              Task? messageTransmitter = null;
〰35:  
‼36:              if (device is IDeviceDefinitionReceiver<TMessage> receiver)
〰37:              {
‼38:                  _decoder = receiver.Decoder;
‼39:                  _segmentDefintion = receiver.SegmentDefintion;
‼40:                  messageReceiver = Receiver();
〰41:              }
‼42:              if (device is IDeviceDefinitionTransmitter<TMessage> transmitter)
〰43:              {
‼44:                  _encoder = transmitter.Encoder;
‼45:                  messageTransmitter = Transmitter();
〰46:              }
〰47:  
〰48:  
‼49:              Runner = Task.WhenAll(
‼50:                  messageReceiver ?? Task.FromResult(0),
‼51:                  messageTransmitter ?? Task.FromResult(0)
‼52:                  );
‼53:          }
〰54:  
‼55:          public CancellationTokenSource CancellationTokenSource { get; }
‼56:          public Task Runner { get; }
〰57:  
〰58:          public event EventHandler<TMessage> MessageReceived;
〰59:          public event EventHandler<DeviceErrorEventArgs> MessageReceivedError;
〰60:          public event EventHandler<DeviceErrorEventArgs> MessageTrasmitterError;
‼61:          public Task<bool> Transmit(TMessage message) => Task.FromResult(_transmissionQueue.TryAdd(message));
〰62:  
〰63:          private Task OnMessageReceived(TMessage message)
〰64:          {
‼65:              MessageReceived?.Invoke(this, message);
‼66:              return Task.FromResult(0);
〰67:          }
〰68:  
‼69:          private Task Receiver() => Task.Run(async () =>
‼70:          {
‼71:              while (!CancellationTokenSource.IsCancellationRequested)
‼72:              {
‼73:                  try
‼74:                  {
‼75:                      await _stream.Follow().With(_segmentDefintion.ThenAs(_decoder, OnMessageReceived)).RunAsync(CancellationTokenSource.Token);
‼76:                      CancellationTokenSource.Cancel(true);
‼77:                  }
‼78:                  catch (Exception ex)
‼79:                  {
‼80:                      var eventArg = new DeviceErrorEventArgs(exception: ex, errorHandling: ErrorHandling.Throw);
‼81:                      MessageReceivedError?.Invoke(_stream, eventArg);
‼82:                      switch (eventArg.ErrorHandling)
‼83:                      {
‼84:                          case ErrorHandling.Ignore:
‼85:                              break;
‼86:  
‼87:                          case ErrorHandling.Stop:
‼88:                              CancellationTokenSource.Cancel(true);
‼89:                              break;
‼90:  
‼91:                          case ErrorHandling.Throw:
‼92:                              throw new IOException(ex.Message, ex);
‼93:                      }
‼94:                  }
‼95:              }
‼96:          });
〰97:  
‼98:          private Task Transmitter() => Task.Run(async () =>
‼99:          {
‼100:             while (!CancellationTokenSource.IsCancellationRequested)
‼101:             {
‼102:                 while (_transmissionQueue.TryTake(out var item))
‼103:                 {
‼104:                     try
‼105:                     {
‼106:                         var requestBuffer = _encoder.Encode(ref item);
‼107:                         await _stream.WriteAsync(requestBuffer, CancellationTokenSource.Token);
‼108:                     }
‼109:                     catch (Exception ex)
‼110:                     {
‼111:                         var eventArg = new DeviceErrorEventArgs(exception: ex, errorHandling: ErrorHandling.Throw);
‼112:                         MessageTrasmitterError?.Invoke(_stream, eventArg);
‼113:                         switch (eventArg.ErrorHandling)
‼114:                         {
‼115:                             case ErrorHandling.Ignore:
‼116:                                 break;
‼117: 
‼118:                             case ErrorHandling.Stop:
‼119:                                 CancellationTokenSource.Cancel(true);
‼120:                                 break;
‼121: 
‼122:                             case ErrorHandling.Throw:
‼123:                                 throw new IOException(ex.Message, ex);
‼124:                         }
‼125:                     }
‼126:                 }
‼127: 
‼128:                 if (!CancellationTokenSource.IsCancellationRequested && _minimumTrasmissionDelay > 0)
‼129:                 {
‼130:                     await Task.Delay(_minimumTrasmissionDelay);
‼131:                 }
‼132:             }
‼133:         });
〰134: 
〰135:         public void Dispose()
〰136:         {
‼137:             Runner.Wait();
‼138:             CancellationTokenSource.Cancel(false);
‼139:             _stream.Dispose();
‼140:         }
〰141:     }
〰142: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

