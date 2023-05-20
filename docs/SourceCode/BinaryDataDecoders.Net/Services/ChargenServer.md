# ChargenServer.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.Net/Services/ChargenServer.cs

## Public Class - ChargenServer

### Members

#### Public Constructor - ChargenServer

#####  Parameters

 - IPAddress ? ipAddress = default 
 - ushort port = 19 

#### Async Method - OnStartAsync

#####  Parameters

 - CancellationToken cancellationToken 

#### Method - MessageReceivedAsync

#####  Parameters

 - int clientId 
 - TcpClient accepted 
 - Memory < byte > message 
 - CancellationToken cancellationToken 

