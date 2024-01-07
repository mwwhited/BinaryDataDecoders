# ResetAccumulatedResponse.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.Quarta.RadexOne/ResetAccumulatedResponse.cs

## Public ReadOnly Structure - ResetAccumulatedResponse

### Comments

 <summary>
 Response from device when Reset Accumulated is requested
 </summary>

### Attributes

 - MessageMatchPattern
 - (
 - "7AFF-2080-1600-00000000-0000|0308+"
 - ,
 - Mask
 - =
 - "ffff-ffff-ffff-00000000-0000|ffff+"
 - )
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

#### Private ReadOnly Field - CheckSum1

##### Attributes

 - FieldOffset
 - (
 - 16
 - )

##### Summary

 * Type: 

#### Public Method - ToString


