# StreamDevice.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.IO.Pipelines/StreamDevice.cs

## Public Class - StreamDevice

### Members

#### Private ReadOnly Field - _transmissionQueue

##### Summary

 * Type: 

#### Private ReadOnly Field - _stream

##### Summary

 * Type: Stream 

#### Private ReadOnly Field - _segmentDefintion

##### Summary

 * Type: ISegmentBuildDefinition 

#### Private ReadOnly Field - _decoder

##### Summary

 * Type: 

#### Private ReadOnly Field - _encoder

##### Summary

 * Type: 

#### Private ReadOnly Field - _minimumTrasmissionDelay

##### Summary

 * Type: 

#### Public Constructor - StreamDevice

#####  Parameters

 - Stream stream 
 - IDeviceDefinition device 
 - CancellationTokenSource ? cancellationTokenSource = default 
 - int minimumTrasmissionDelay = 1000 

#### Public Property - CancellationTokenSource

##### Summary

 * Type: CancellationTokenSource 

#### Public Property - Runner

##### Summary

 * Type: Task 

#### Public Method - Transmit

#####  Parameters

 - TMessage message 

#### Private Method - OnMessageReceived

#####  Parameters

 - TMessage message 

#### Private Method - Receiver


#### Private Method - Transmitter


#### Public Method - Dispose


