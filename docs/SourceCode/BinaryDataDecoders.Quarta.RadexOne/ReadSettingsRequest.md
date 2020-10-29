# ReadSettingsRequest.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.Quarta.RadexOne\ReadSettingsRequest.cs

## Public Structure - ReadSettingsRequest

### Comments

 <summary>
 request settings from Radex One device
 </summary>

### Attributes

 - StructLayout
 - (
 - LayoutKind
 - .
 - Explicit
 - ,
 - Size
 - =
 - 18
 - )

### Members

#### Public Constructor - ReadSettingsRequest

##### Comments

 <summary>
 request settings from Radex One device
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

#### Private ReadOnly Field - SubCommand

##### Attributes

 - FieldOffset
 - (
 - 12
 - )

##### Summary

 * Type: 

#### Private ReadOnly Field - Reserved1

##### Attributes

 - FieldOffset
 - (
 - 14
 - )

##### Summary

 * Type: 

#### Private ReadOnly Field - CheckSum1

##### Attributes

 - FieldOffset
 - (
 - 16
 - )

##### Summary

 * Type: 

