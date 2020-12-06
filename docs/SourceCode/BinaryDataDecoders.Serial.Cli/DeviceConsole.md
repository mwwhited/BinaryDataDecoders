# DeviceConsole.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.Serial.Cli/DeviceConsole.cs

## Public Class - DeviceConsole

### Members

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
 - Func < int , TMessage > messageFactory = null 

