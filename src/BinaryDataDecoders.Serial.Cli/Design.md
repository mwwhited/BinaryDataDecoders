# Generic Serial Port Console

## Summary

The intent of this project is to build an simple console app that can interact with Serail Port devices

## Design

```plantuml
interface IDeviceBuilder {    
    +SerialPort(string name) : IDeviceBuilder
    +Socket(Socket socket) : IDeviceBuilder
    +Tcp(IpAddress address, int port) : IDeviceBuilder
    +Provider<TProvider extends IDevice>() : IDeviceBuilder
    +Build() : IDevice
}

interface IDevice {
}
interface IDeviceReceiver<TResponse> {
    OnReceived() : TResponse
}
interface IDeviceTransmitter<TRequest> {
    Transmit(TRequest)
}

IDeviceBuilder o-- IDevice
IDevice <|-- IDeviceReceiver
IDevice <|-- IDeviceTransmitter

class DeviceBuilder {
    {static} +Create() : IDeviceBuilder
}
DeviceBuilder --|> IDeviceBuilder

class RadexOneDevice {
    {static} @SerialPort(9600,N,8,1)
}
IDeviceReceiver <|-- RadexOneDevice
IDeviceTransmitter <|-- RadexOneDevice

class FaveroDevice {
    {static} @SerialPort(2400,N,8,1)
}
IDeviceReceiver <|-- FaveroDevice

class SaintGeorgeDevice {
    {static} @SerialPort(9600,N,8,1)
}
IDeviceReceiver <|-- SaintGeorgeDevice

class Nmea0183Device {
    {static} @SerialPort(9600,N,8,1)
}
IDeviceReceiver <|-- Nmea0183Device

class ZStickDevice {
    {static} @SerialPort(115200,N,8,1)
}
IDeviceReceiver <|-- ZStickDevice
IDeviceTransmitter <|-- ZStickDevice

class SerialPort << (@,#FF7700) >> {
    +Baud : int
    +Parity : ParityTypes
    +DataBits: int
    +StopBits: StopBitTypes
    +ctor(Baud, Parity, DataBits, StopBits)
}

enum ParityTypes {
    None  {N}
    Odd   {O}
    Even  {E}
    Mark  {M}
    Space {S}
}
SerialPort *-- ParityTypes

enum StopBitTypes {
    None         {0}
    One          {1}
    Two          {2}
    OnePointFive {1.5}
}
SerialPort *-- StopBitTypes
```
