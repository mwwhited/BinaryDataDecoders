# WriteSettingsResponse.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.Quarta.RadexOne/WriteSettingsResponse.cs

## Public Structure - WriteSettingsResponse

### Comments

 <summary>
 Response message after Write Settings is requested
 </summary>

### Attributes

 - MessageMatchPattern
 - (
 - "7AFF-2080-0600-00000000-0000|0208+"
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


