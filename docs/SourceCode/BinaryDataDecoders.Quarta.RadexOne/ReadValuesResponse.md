# ReadValuesResponse.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.Quarta.RadexOne/ReadValuesResponse.cs

## Public ReadOnly Structure - ReadValuesResponse

### Comments

 <summary>
 Read Values result from current device values
 </summary>

### Attributes

 - MessageMatchPattern
 - (
 - "7AFF-2080-1600-????????-????|0008+"
 - )
 - StructLayout
 - (
 - LayoutKind
 - .
 - Explicit
 - ,
 - Size
 - =
 - 32
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

#### Private ReadOnly Field - SubCommandL

##### Attributes

 - FieldOffset
 - (
 - 12
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

#### Public ReadOnly Field - Ambient

##### Comments

 <summary>
 μSv/h * 100: Stated range .05 to 999.00 (Requires 17 bits?)
 </summary>

##### Attributes

 - FieldOffset
 - (
 - 20
 - )

##### Summary

 * Type: 

#### Public ReadOnly Field - Accumulated

##### Comments

 <summary>
 μSv * 100: Stated range 0 to 9,990,000 (Requires 30 bits?)
 </summary>

##### Attributes

 - FieldOffset
 - (
 - 24
 - )

##### Summary

 * Type: 

#### Public ReadOnly Field - ClicksPerMinute

##### Comments

 <summary>
 clicks/minute: State range 0 to 99,900 (Requires 17 bits?)
 </summary>

##### Attributes

 - FieldOffset
 - (
 - 28
 - )

##### Summary

 * Type: 

#### Private ReadOnly Field - CheckSum1

##### Attributes

 - FieldOffset
 - (
 - 32
 - )

##### Summary

 * Type: 

#### Public Method - ToString


