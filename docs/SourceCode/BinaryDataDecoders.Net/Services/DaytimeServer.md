# DaytimeServer.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.Net/Services/DaytimeServer.cs

## Public Class - DaytimeServer

### Members

#### Public Constructor - DaytimeServer

#####  Parameters

 - IPAddress ? ipAddress = default 
 - ushort port = 13 

#### Async Method - MessageReceivedAsync

#####  Parameters

 - int clientId 
 - TcpClient accepted 
 - Memory < byte > message 
 - CancellationToken cancellationToken 

