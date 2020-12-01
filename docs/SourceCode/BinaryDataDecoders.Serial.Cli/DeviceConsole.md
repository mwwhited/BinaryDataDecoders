# DeviceConsole.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.Serial.Cli/DeviceConsole.cs

## Public Class - DeviceConsole

### Members

#### Field - usbHid

##### Summary

 * Type: UsbHidFactory 

#### Field - serial

##### Summary

 * Type: SerialPortFactory 

#### Public Method - UserInteractionAsync

#####  Parameters

 - IDeviceTransmitter < TMessage > transmitter 
 - Func < int , TMessage > messageFactory 
 - CancellationTokenSource cts 

#### Private Method - GetSerialPort

#####  Parameters

 - object definition 

#### Private Method - GetHidDevice

#####  Parameters

 - object definition 

#### Public Method - Execute

#####  Parameters

 - IDeviceDefinition < TMessage > definition 
 - Func < int , TMessage > messageFactory = null 

