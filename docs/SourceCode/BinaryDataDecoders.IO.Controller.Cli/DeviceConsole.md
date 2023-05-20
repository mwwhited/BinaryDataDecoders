# DeviceConsole.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.IO.Controller.Cli/DeviceConsole.cs

## Public Class - DeviceConsole

### Members

#### Public Constructor - DeviceConsole

#####  Parameters

 - int minimumTrasmissionDelay = 1000 
 - int testCommandDelay = 1000 

#### Private Field - _minimumTrasmissionDelay

##### Summary

 * Type: 

#### Private Field - _testCommandDelay

##### Summary

 * Type: 

#### Private ReadOnly Field - usbHid

##### Summary

 * Type: UsbHidFactory 

#### Private ReadOnly Field - serial

##### Summary

 * Type: SerialPortFactory 

#### Private ReadOnly Field - _tokenSource

##### Summary

 * Type: CancellationTokenSource 

#### Private Property - _token

##### Summary

 * Type: CancellationToken 

#### Public Method - UserInteractionAsync

#####  Parameters

 - IDeviceTransmitter < TMessage > transmitter 
 - Func < int , TMessage > messageFactory 

#### Private Method - GetSerialPort

#####  Parameters

 - object definition 

#### Private Method - GetHidDevice

#####  Parameters

 - object definition 

#### Public Async Method - Execute

#####  Parameters

 - IDeviceDefinition < TMessage > definition 
 - Func < int , TMessage > ? messageFactory = null 

