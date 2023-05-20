# EchoServer.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.Net/Services/EchoServer.cs

## Public Class - EchoServer

### Members

#### Public Constructor - EchoServer

#####  Parameters

 - IPAddress ? ipAddress = default 
 - ushort port = 7 

#### Async Method - MessageReceivedAsync

#####  Parameters

 - int clientId 
 - TcpClient accepted 
 - Memory < byte > message 
 - CancellationToken cancellationToken 

