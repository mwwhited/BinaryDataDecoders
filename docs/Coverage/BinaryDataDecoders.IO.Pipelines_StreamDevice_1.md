# BinaryDataDecoders.IO.Pipelines.StreamDevice`1

## Summary

| Key             | Value                                            |
| :-------------- | :----------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.Pipelines.StreamDevice`1` |
| Assembly        | `BinaryDataDecoders.IO.Pipelines`                |
| Coveredlines    | `0`                                              |
| Uncoveredlines  | `125`                                            |
| Coverablelines  | `125`                                            |
| Totallines      | `190`                                            |
| Linecoverage    | `0`                                              |
| Coveredbranches | `0`                                              |
| Totalbranches   | `20`                                             |
| Branchcoverage  | `0`                                              |

## Metrics

| Complexity | Lines | Branches | Name                 |
| :--------- | :---- | :------- | :------------------- |
| 12         | 0     | 0        | `ctor`               |
| 1          | 0     | 100      | `get__stream`        |
| 1          | 0     | 100      | `get_Runner`         |
| 1          | 0     | 100      | `Transmit`           |
| 2          | 0     | 0        | `OnMessageReceived`  |
| 2          | 0     | 0        | `ReportDeviceStatus` |
| 4          | 0     | 0        | `Initializer`        |
| 1          | 0     | 100      | `Receiver`           |
| 1          | 0     | 100      | `Transmitter`        |
| 1          | 0     | 100      | `Dispose`            |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Pipelines/StreamDevice.cs

```CSharp
〰1:   using BinaryDataDecoders.IO.Messages;
〰2:   using BinaryDataDecoders.IO.Segmenters;
〰3:   using BinaryDataDecoders.ToolKit.Threading;
〰4:   using System;
〰5:   using System.Collections.Concurrent;
〰6:   using System.IO;
〰7:   using System.Threading;
〰8:   using System.Threading.Tasks;
〰9:   
〰10:  namespace BinaryDataDecoders.IO.Pipelines
〰11:  {
〰12:      public class StreamDevice<TMessage> : IStreamDevice<TMessage>
〰13:      {
‼14:          private readonly IProducerConsumerCollection<TMessage> _transmissionQueue = new ConcurrentQueue<TMessage>();
〰15:  
‼16:          private Stream _stream => _adapter.Stream;
〰17:          private readonly IDeviceAdapter _adapter;
〰18:          private readonly IDeviceDefinition _device;
〰19:          private readonly ISegmentBuildDefinition _segmentDefintion;
〰20:          private readonly IMessageDecoder<TMessage> _decoder;
〰21:          private readonly IMessageEncoder<TMessage> _encoder;
〰22:          private readonly int _minimumTrasmissionDelay;
〰23:          private readonly CancellationToken _token;
〰24:          private readonly CancellationTokenSource _tokenSource;
〰25:  
‼26:          public StreamDevice(
‼27:              IDeviceAdapter adapter,
‼28:              IDeviceDefinition device,
‼29:              CancellationToken token = default,
‼30:              int minimumTrasmissionDelay = 1000 //TODO should this default be overideable from the devicedefinition or it's attributes?
‼31:              )
〰32:          {
‼33:              _tokenSource = CancellationTokenSource.CreateLinkedTokenSource(token);
‼34:              _token = _tokenSource.Token;
〰35:  
‼36:              _adapter = adapter;
‼37:              _device = device;
‼38:              _minimumTrasmissionDelay = minimumTrasmissionDelay;
〰39:  
‼40:              Task? messageReceiver = null;
‼41:              Task? messageTransmitter = null;
‼42:              Task? deviceInitializer = null;
〰43:  
‼44:              var mre = new AsyncManualResetEvent();
‼45:              if (_device is IDeviceDefinitionInitialize)
〰46:              {
‼47:                  mre.Reset();
‼48:                  deviceInitializer = Initializer(mre);
〰49:              }
〰50:              else
〰51:              {
〰52:                  //Assumed to start in set state but just be sure anyway
‼53:                  mre.Set();
〰54:              }
〰55:  
‼56:              if (_device is IDeviceDefinitionReceiver<TMessage> receiver)
〰57:              {
‼58:                  _decoder = receiver.Decoder;
‼59:                  _segmentDefintion = receiver.SegmentDefintion;
‼60:                  messageReceiver = Receiver(mre);
〰61:              }
‼62:              if (_device is IDeviceDefinitionTransmitter<TMessage> transmitter)
〰63:              {
‼64:                  _encoder = transmitter.Encoder;
‼65:                  messageTransmitter = Transmitter(mre);
〰66:              }
〰67:  
‼68:              Runner = Task.WhenAll(
‼69:                  deviceInitializer ?? Task.FromResult(0),
‼70:                  messageReceiver ?? Task.FromResult(0),
‼71:                  messageTransmitter ?? Task.FromResult(0)
‼72:                  );
‼73:          }
〰74:  
‼75:          public Task Runner { get; }
〰76:  
〰77:          public event EventHandler<TMessage> MessageReceived;
〰78:          public event EventHandler<StreamDeviceStatus> DeviceStatus;
〰79:          public event EventHandler<DeviceErrorEventArgs> MessageReceivedError;
〰80:          public event EventHandler<DeviceErrorEventArgs> MessageTrasmitterError;
〰81:  
‼82:          public Task<bool> Transmit(TMessage message) => Task.FromResult(_transmissionQueue.TryAdd(message));
〰83:  
〰84:          private Task OnMessageReceived(TMessage message)
〰85:          {
‼86:              MessageReceived?.Invoke(this, message);
‼87:              return Task.FromResult(0);
〰88:          }
〰89:          private Task ReportDeviceStatus(StreamDeviceStatus status)
〰90:          {
‼91:              DeviceStatus?.Invoke(this, status);
‼92:              return Task.FromResult(0);
〰93:          }
〰94:  
〰95:          private async Task Initializer(AsyncManualResetEvent mre)
〰96:          {
‼97:              if (!_token.IsCancellationRequested && _device is IDeviceDefinitionInitialize initializer)
〰98:              {
‼99:                  await ReportDeviceStatus(StreamDeviceStatus.Initializing);
‼100:                 await initializer.InitializeAsync(_adapter, _token).ConfigureAwait(false);
〰101:             }
‼102:             await ReportDeviceStatus(StreamDeviceStatus.Initialized);
‼103:             mre.Set();
‼104:         }
〰105: 
‼106:         private Task Receiver(AsyncManualResetEvent mre) => Task.Run(async () =>
‼107:         {
‼108:             while (!_token.IsCancellationRequested)
‼109:             {
‼110:                 await mre.WaitAsync();
‼111:                 try
‼112:                 {
‼113:                     await ReportDeviceStatus(StreamDeviceStatus.Receiving);
‼114:                     await _stream.Follow()
‼115:                                  .With(_segmentDefintion.ThenAs(_decoder, OnMessageReceived))
‼116:                                  .RunAsync(_token)
‼117:                                  .ConfigureAwait(false);
‼118:                     _tokenSource.Cancel(true);
‼119:                     await ReportDeviceStatus(StreamDeviceStatus.Received);
‼120:                 }
‼121:                 catch (Exception ex)
‼122:                 {
‼123:                     var eventArg = new DeviceErrorEventArgs(exception: ex, errorHandling: ErrorHandling.Throw);
‼124:                     MessageReceivedError?.Invoke(_stream, eventArg);
‼125:                     switch (eventArg.ErrorHandling)
‼126:                     {
‼127:                         case ErrorHandling.Ignore:
‼128:                             break;
‼129: 
‼130:                         case ErrorHandling.Stop:
‼131:                             _tokenSource.Cancel(true);
‼132:                             break;
‼133: 
‼134:                         default:
‼135:                         case ErrorHandling.Throw:
‼136:                             throw new IOException(ex.Message, ex);
‼137:                     }
‼138:                 }
‼139:             }
‼140:         });
〰141: 
‼142:         private Task Transmitter(AsyncManualResetEvent mre) => Task.Run(async () =>
‼143:         {
‼144:             while (!_token.IsCancellationRequested)
‼145:             {
‼146:                 await mre.WaitAsync();
‼147:                 while (_transmissionQueue.TryTake(out var item))
‼148:                 {
‼149:                     try
‼150:                     {
‼151:                         await ReportDeviceStatus(StreamDeviceStatus.Transmitting);
‼152:                         var requestBuffer = _encoder.Encode(ref item);
‼153:                         await _stream.WriteAsync(requestBuffer, _token)
‼154:                                      .ConfigureAwait(false);
‼155:                         await ReportDeviceStatus(StreamDeviceStatus.Transmitted);
‼156:                     }
‼157:                     catch (Exception ex)
‼158:                     {
‼159:                         var eventArg = new DeviceErrorEventArgs(exception: ex, errorHandling: ErrorHandling.Throw);
‼160:                         MessageTrasmitterError?.Invoke(_stream, eventArg);
‼161:                         switch (eventArg.ErrorHandling)
‼162:                         {
‼163:                             case ErrorHandling.Ignore:
‼164:                                 break;
‼165: 
‼166:                             case ErrorHandling.Stop:
‼167:                                 _tokenSource.Cancel(true);
‼168:                                 break;
‼169: 
‼170:                             case ErrorHandling.Throw:
‼171:                                 throw new IOException(ex.Message, ex);
‼172:                         }
‼173:                     }
‼174:                 }
‼175: 
‼176:                 if (!_token.IsCancellationRequested && _minimumTrasmissionDelay > 0)
‼177:                 {
‼178:                     await Task.Delay(_minimumTrasmissionDelay);
‼179:                 }
‼180:             }
‼181:         });
〰182: 
〰183:         public void Dispose()
〰184:         {
‼185:             Runner.GetAwaiter().GetResult();
‼186:             _tokenSource.Cancel(false);
‼187:             _stream.Dispose();
‼188:         }
〰189:     }
〰190: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

