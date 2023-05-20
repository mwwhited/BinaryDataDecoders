# StreamDevice.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.IO.Pipelines/StreamDevice.cs

## Public Class - StreamDevice

### Members

#### Private ReadOnly Field - _transmissionQueue

##### Summary

 * Type: 

#### Private Property - _stream

##### Summary

 * Type: Stream 

#### Private ReadOnly Field - _adapter

##### Summary

 * Type: IDeviceAdapter 

#### Private ReadOnly Field - _device

##### Summary

 * Type: IDeviceDefinition 

#### Private ReadOnly Field - _segmentDefintion

##### Summary

 * Type: 

#### Private ReadOnly Field - _decoder

##### Summary

 * Type: 

#### Private ReadOnly Field - _encoder

##### Summary

 * Type: 

#### Private ReadOnly Field - _minimumTrasmissionDelay

##### Summary

 * Type: 

#### Private ReadOnly Field - _token

##### Summary

 * Type: CancellationToken 

#### Private ReadOnly Field - _tokenSource

##### Summary

 * Type: CancellationTokenSource 

#### Public Constructor - StreamDevice

#####  Parameters

 - IDeviceAdapter adapter 
 - IDeviceDefinition device 
 - CancellationToken token = default 
 - int minimumTrasmissionDelay = 1000 

#### Public Property - Runner

##### Summary

 * Type: Task 

#### Public Method - Transmit

#####  Parameters

 - TMessage message 

#### Private Method - OnMessageReceived

#####  Parameters

 - TMessage message 

#### Private Method - ReportDeviceStatus

#####  Parameters

 - StreamDeviceStatus status 

#### Private Async Method - Initializer

#####  Parameters

 - AsyncManualResetEvent mre 

#### Private Method - Receiver

#####  Parameters

 - AsyncManualResetEvent mre 

#### Private Method - Transmitter

#####  Parameters

 - AsyncManualResetEvent mre 

#### Public Method - Dispose


