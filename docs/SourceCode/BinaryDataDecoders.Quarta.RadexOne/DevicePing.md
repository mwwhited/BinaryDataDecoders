# DevicePing.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.Quarta.RadexOne/DevicePing.cs

## Public Structure - DevicePing

### Comments

 <summary>
 Empty request object for radex one.
 </summary>

### Attributes

 - MessageMatchPattern
 - (
 - "7AFF-2080-0000-********-****"
 - )
 - StructLayout
 - (
 - LayoutKind
 - .
 - Explicit
 - ,
 - Size
 - =
 - 12
 - )

### Members

#### Public Constructor - DevicePing

##### Comments

 <summary>
 Empty request object for radex one.
 </summary>
 <paramname="packetNumber">packetnumber is returned by response and may be used for correlation.</param>

#####  Parameters

 - uint packetNumber 

#### Private ReadOnly Field - Prefix

##### Attributes

 - FieldOffset
 - (
 - 0
 - )

##### Summary

 * Type: 

#### Private ReadOnly Field - Command

##### Attributes

 - FieldOffset
 - (
 - 2
 - )

##### Summary

 * Type: 

#### Private ReadOnly Field - ExtensionLength

##### Attributes

 - FieldOffset
 - (
 - 4
 - )

##### Summary

 * Type: 

#### Public ReadOnly Field - PacketNumber

##### Comments

 <summary>
 packetnumber is returned by response and may be used for correlation.
 </summary>

##### Attributes

 - FieldOffset
 - (
 - 6
 - )

##### Summary

 * Type: 

#### Private ReadOnly Field - CheckSum0

##### Attributes

 - FieldOffset
 - (
 - 10
 - )

##### Summary

 * Type: 

#### Public Method - ToString


