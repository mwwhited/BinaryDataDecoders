# ReadSettingsResponse.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.Quarta.RadexOne\ReadSettingsResponse.cs

## Public Structure - ReadSettingsResponse

### Comments

 <summary>
 response from device with current settings
 </summary>

### Attributes

 - MessageMatchPattern
 - (
 - "7AFF-2080-1000-********-****|0108+"
 - )
 - StructLayout
 - (
 - LayoutKind
 - .
 - Explicit
 - ,
 - Size
 - =
 - 28
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

#### Private ReadOnly Field - Settings

##### Attributes

 - FieldOffset
 - (
 - 20
 - )

##### Summary

 * Type: 

#### Public ReadOnly Field - AlarmSetting

##### Comments

 <summary>
 Off; Audio; Vibrate; Audio|Vibrate
 </summary>

##### Attributes

 - FieldOffset
 - (
 - 20
 - )

##### Summary

 * Type: AlarmSettings 

#### Public ReadOnly Field - Threshold

##### Comments

 <summary>
 μSv/h  * 100: Alarm trigger threshold: range .01 to 10.00
 </summary>

##### Attributes

 - FieldOffset
 - (
 - 21
 - )

##### Summary

 * Type: 

#### Private ReadOnly Field - CheckSum1

##### Attributes

 - FieldOffset
 - (
 - 26
 - )

##### Summary

 * Type: 

#### Public Method - ToString


