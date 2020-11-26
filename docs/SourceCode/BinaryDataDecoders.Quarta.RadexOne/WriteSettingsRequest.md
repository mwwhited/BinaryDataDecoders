# WriteSettingsRequest.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.Quarta.RadexOne/WriteSettingsRequest.cs

## Public Structure - WriteSettingsRequest

### Comments

 <summary>
 Write Settings will allow for the current device configuratin to be updated
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
 - 28
 - )

### Members

#### Public Constructor - WriteSettingsRequest

##### Comments

 <summary>
 Write Settings will allow for the current device configuratin to be updated
 </summary>
 <paramname="packetNumber"></param>
 <paramname="alarmSetting">Flagged byte: 0x01=Vibrate | 0x02=Audio </param>
 <paramname="threshold">μSv/h  * 100: Alarm trigger threshold: range .01 to 10.00</param>

#####  Parameters

 - uint packetNumber 
 - AlarmSettings alarmSetting 
 - ushort threshold 

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

#### Private ReadOnly Field - Reserved2

##### Attributes

 - FieldOffset
 - (
 - 16
 - )

##### Summary

 * Type: 

#### Public ReadOnly Field - AlarmSetting

##### Comments

 <summary>
 Flagged byte: 0x01=Vibrate | 0x02=Audio 
 </summary>

##### Attributes

 - FieldOffset
 - (
 - 20
 - )

##### Summary

 * Type: AlarmSettings 

#### Private ReadOnly Field - Composite0

##### Attributes

 - FieldOffset
 - (
 - 20
 - )

##### Summary

 * Type: 

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

#### Private ReadOnly Field - Composite1

##### Attributes

 - FieldOffset
 - (
 - 22
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

