# ReadSerialNumberResponse.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.Quarta.RadexOne\ReadSerialNumberResponse.cs

## Public Structure - ReadSerialNumberResponse

### Comments

 <summary>
 packetnumber is returned by response and may be used for correlation.
 </summary>

### Attributes

 - MessageMatchPattern
 - (
 - "7AFF-2080-1E00-????????-????|0100+"
 - )
 - StructLayout
 - (
 - LayoutKind
 - .
 - Explicit
 - ,
 - Size
 - =
 - 42
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

#### Private ReadOnly Field - ReservedL1

##### Attributes

 - FieldOffset
 - (
 - 14
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

#### Private ReadOnly Field - Reserved2

##### Attributes

 - FieldOffset
 - (
 - 16
 - )

##### Summary

 * Type: 

#### Private ReadOnly Field - Reserved3

##### Attributes

 - FieldOffset
 - (
 - 18
 - )

##### Summary

 * Type: 

#### Private ReadOnly Field - Reserved4

##### Attributes

 - FieldOffset
 - (
 - 20
 - )

##### Summary

 * Type: 

#### Private ReadOnly Field - ReservedL2

##### Attributes

 - FieldOffset
 - (
 - 22
 - )

##### Summary

 * Type: 

#### Private ReadOnly Field - Reserved5

##### Attributes

 - FieldOffset
 - (
 - 22
 - )

##### Summary

 * Type: 

#### Private ReadOnly Field - Reserved6

##### Attributes

 - FieldOffset
 - (
 - 24
 - )

##### Summary

 * Type: 

#### Private ReadOnly Field - Reserved7

##### Attributes

 - FieldOffset
 - (
 - 26
 - )

##### Summary

 * Type: 

#### Private ReadOnly Field - Reserved8

##### Attributes

 - FieldOffset
 - (
 - 28
 - )

##### Summary

 * Type: 

#### Private ReadOnly Field - ReservedL3

##### Attributes

 - FieldOffset
 - (
 - 30
 - )

##### Summary

 * Type: 

#### Private ReadOnly Field - Reserved9

##### Attributes

 - FieldOffset
 - (
 - 30
 - )

##### Summary

 * Type: 

#### Private ReadOnly Field - ReservedA

##### Attributes

 - FieldOffset
 - (
 - 32
 - )

##### Summary

 * Type: 

#### Private ReadOnly Field - ReservedB

##### Attributes

 - FieldOffset
 - (
 - 34
 - )

##### Summary

 * Type: 

#### Private ReadOnly Field - ReservedC

##### Attributes

 - FieldOffset
 - (
 - 36
 - )

##### Summary

 * Type: 

#### Private ReadOnly Field - ReservedD

##### Attributes

 - FieldOffset
 - (
 - 38
 - )

##### Summary

 * Type: 

#### Private ReadOnly Field - CheckSum1

##### Attributes

 - FieldOffset
 - (
 - 40
 - )

##### Summary

 * Type: 

#### Public ReadOnly Field - Sn1

##### Attributes

 - FieldOffset
 - (
 - 31
 - )

##### Summary

 * Type: 

#### Public ReadOnly Field - Sn2

##### Attributes

 - FieldOffset
 - (
 - 30
 - )

##### Summary

 * Type: 

#### Private ReadOnly Field - Sn3

##### Attributes

 - FieldOffset
 - (
 - 29
 - )

##### Summary

 * Type: 

#### Public ReadOnly Field - Sn4

##### Attributes

 - FieldOffset
 - (
 - 28
 - )

##### Summary

 * Type: 

#### Public ReadOnly Field - Sn5

##### Attributes

 - FieldOffset
 - (
 - 34
 - )

##### Summary

 * Type: 

#### Public ReadOnly Field - Sn6

##### Attributes

 - FieldOffset
 - (
 - 24
 - )

##### Summary

 * Type: 

#### Public ReadOnly Field - Major

##### Attributes

 - FieldOffset
 - (
 - 32
 - )

##### Summary

 * Type: 

#### Public ReadOnly Field - Minor

##### Attributes

 - FieldOffset
 - (
 - 33
 - )

##### Summary

 * Type: 

#### Public Property - SerialNumber

##### Comments

 <summary>
 Formatted serial number
 </summary>

##### Summary

 * Type: # pragma warning restore CS1591    < summary > 
  Formatted serial number 
   </ summary > 
  string 

#### Public Property - Version

##### Comments

 <summary>
 Formatted version number
 </summary>

##### Summary

 * Type:   < summary > 
  Formatted version number 
   </ summary > 
  string 

#### Public Method - ToString


