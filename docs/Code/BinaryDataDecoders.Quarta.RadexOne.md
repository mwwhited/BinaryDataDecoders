# Assembly - BinaryDataDecoders.Quarta.RadexOne

## Type - BinaryDataDecoders.Quarta.RadexOne.AlarmSettings

*summary*
Flag enumeration for setting Radex One Alarm type

### Field - Audio

*summary*
Beep

### Field - Off

*summary*
No Alarm

### Field - Vibrate

*summary*
Vibration

## Type - BinaryDataDecoders.Quarta.RadexOne.DevicePing

*summary*
Empty request object for radex one.

### Field - PacketNumber

*summary*
packetnumber is returned by response and may be used for correlation.

### Method - #ctor(System.UInt32)

*summary*
Empty request object for radex one.

*param*
packetnumber is returned by response and may be used for correlation.

| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | packetNumber                                                 | 

## Type - BinaryDataDecoders.Quarta.RadexOne.IRadexObject

*summary*
base interface for tagging RadexOne objects

## Type - BinaryDataDecoders.Quarta.RadexOne.IRadexOneDecoder

*summary*
used to convert buffered data to correct value type

## Type - BinaryDataDecoders.Quarta.RadexOne.RadexOneDecoder

*summary*
used to convert buffered data to correct value type

### Method - Decode(System.Buffers.ReadOnlySequence{System.Byte})

*summary*
used to convert buffered data to correct value type

*param*
input data type

| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | sequence                                                     | 

*returns*
converted value type

## Type - BinaryDataDecoders.Quarta.RadexOne.ReadSerialNumberRequest

*summary*
request serial number from Radex One device

### Field - PacketNumber

*summary*
packetnumber is returned by response and may be used for correlation.

### Method - #ctor(System.UInt32)

*summary*
request serial number from Radex One device

*param*
packetnumber is returned by response and may be used for correlation.

| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | packetNumber                                                 | 

## Type - BinaryDataDecoders.Quarta.RadexOne.ReadSettingsRequest

*summary*
request settings from Radex One device

### Field - PacketNumber

*summary*
packetnumber is returned by response and may be used for correlation.

### Method - #ctor(System.UInt32)

*summary*
request settings from Radex One device

*param*
packetnumber is returned by response and may be used for correlation.

| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | packetNumber                                                 | 

## Type - BinaryDataDecoders.Quarta.RadexOne.ReadSettingsResponse

*summary*
response from device with current settings

### Field - AlarmSetting

*summary*
Off; Audio; Vibrate; Audio|Vibrate

### Field - PacketNumber

*summary*
packetnumber is returned by response and may be used for correlation.

### Field - Threshold

*summary*
μSv/h  * 100: Alarm trigger threshold: range .01 to 10.00

## Type - BinaryDataDecoders.Quarta.RadexOne.ReadValuesRequest

*summary*
Read Values is used to access current device values

### Field - PacketNumber

*summary*
packetnumber is returned by response and may be used for correlation.

### Method - #ctor(System.UInt32)

*summary*
Constructor to create a new read values request

*param*
packetnumber is returned by response and may be used for correlation.

| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | packetNumber                                                 | 

## Type - BinaryDataDecoders.Quarta.RadexOne.ReadValuesResponse

*summary*
Read Values result from current device values

### Field - Accumulated

*summary*
μSv * 100: Stated range 0 to 9,990,000 (Requires 30 bits?)

### Field - Ambient

*summary*
μSv/h * 100: Stated range .05 to 999.00 (Requires 17 bits?)

### Field - ClicksPerMinute

*summary*
clicks/minute: State range 0 to 99,900 (Requires 17 bits?)

### Field - PacketNumber

*summary*
packetnumber is returned by response and may be used for correlation.

## Type - BinaryDataDecoders.Quarta.RadexOne.ResetAccumulatedRequest

*summary*
Reset Accumulated will clear the current accumulated value

### Field - PacketNumber

*summary*
packetnumber is returned by response and may be used for correlation.

### Method - #ctor(System.UInt32)

*summary*
Constructor to create a new Reset Accumulated request

*param*
packetnumber is returned by response and may be used for correlation.

| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | packetNumber                                                 | 

## Type - BinaryDataDecoders.Quarta.RadexOne.ResetAccumulatedResponse

*summary*
Response from device when Reset Accumulated is requested

### Field - PacketNumber

*summary*
packetnumber is returned by response and may be used for correlation.

## Type - BinaryDataDecoders.Quarta.RadexOne.WriteSettingsRequest

*summary*
Write Settings will allow for the current device configuration to be updated

### Field - AlarmSetting

*summary*
Flagged byte: 0x01=Vibrate | 0x02=Audio

### Field - PacketNumber

*summary*
packet number is returned by response and may be used for correlation.

### Field - Threshold

*summary*
μSv/h  * 100: Alarm trigger threshold: range .01 to 10.00

### Method - #ctor(System.UInt32,BinaryDataDecoders.Quarta.RadexOne.AlarmSettings,System.UInt16)

*summary*
Write Settings will allow for the current device configuration to be updated

*param*


| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | packetNumber                                                 | 

*param*
Flagged byte: 0x01=Vibrate | 0x02=Audio

| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | alarmSetting                                                 | 

*param*
μSv/h  * 100: Alarm trigger threshold: range .01 to 10.00

| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | threshold                                                    | 

## Type - BinaryDataDecoders.Quarta.RadexOne.WriteSettingsResponse

*summary*
Response message after Write Settings is requested

### Field - PacketNumber

*summary*
packetnumber is returned by response and may be used for correlation.

