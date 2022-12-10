# K8055Definition.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.Velleman.K8055/K8055Definition.cs

## Public Class - K8055Definition

### Attributes

 - UsbHid
 - (
 - vendorId
 - :
 - 0x10cf
 - ,
 - productId
 - :
 - 0x5500
 - ,
 - ProductMask
 - =
 - 0xfff8
 - )
 - Description
 - (
 - "Velleman K8055"
 - )
 - Export
 - (
 - typeof
 - (
 - IDeviceDefinition
 - )
 - )

### Members

#### Public Property - Encoder

##### Summary

 * Type: IMessageEncoder < IK8055Object > 

#### Public Property - SegmentDefintion

##### Summary

 * Type: ISegmentBuildDefinition 

#### Public Property - Decoder

##### Summary

 * Type: IMessageDecoder < IK8055Object > 

