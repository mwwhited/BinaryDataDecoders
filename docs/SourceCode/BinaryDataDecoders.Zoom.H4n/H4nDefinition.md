# H4nDefinition.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.Zoom.H4n/H4nDefinition.cs

## Public Class - H4nDefinition

### Attributes

 - SerialPort
 - (
 - 2400
 - )
 - Description
 - (
 - "Zoom H4N"
 - )
 - Export
 - (
 - typeof
 - (
 - IDeviceDefinition
 - )
 - )

### Members

#### Public Property - SegmentDefintion

##### Summary

 * Type: ISegmentBuildDefinition 

#### Public Property - Decoder

##### Summary

 * Type: IMessageDecoder < IH4nMessage > 

#### Public Property - Encoder

##### Summary

 * Type: IMessageEncoder < IH4nMessage > 

#### Public Async Method - InitializeAsync

#####  Parameters

 - IDeviceAdapter device 
 - CancellationToken token 

