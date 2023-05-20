# ServerBase.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.Net/Sockets/ServerBase.cs

## Public Class - ServerBase

### Members

#### Property - IPAddress

##### Summary

 * Type: IPAddress 

#### Property - Port

##### Summary

 * Type: ushort 

#### Constructor - ServerBase

#####  Parameters

 - IPAddress ? ipAddress = default 
 - ushort port = 65535 

#### Public Method - Start


#### Method - OnStartAsync

#####  Parameters

 - CancellationToken cancellationToken 

#### Public Async Method - StopAsync


#### Async Method - ServiceLoopAsync

#####  Parameters

 - TcpListener listener 
 - CancellationToken cancellationToken 

#### Async Method - AcceptClientAsync

#####  Parameters

 - int clientId 
 - TcpClient accepted 
 - CancellationToken cancellationToken 

#### Method - MessageReceivedAsync

#####  Parameters

 - int clientId 
 - TcpClient accepted 
 - Memory < byte > message 
 - CancellationToken cancellationToken 

#### Private Field - _cts

##### Summary

 * Type: 

#### Private Field - _listener

##### Summary

 * Type: 

#### Private Field - _task

##### Summary

 * Type: 

#### Private ReadOnly Field - _clients

##### Summary

 * Type: 

#### Private ReadOnly Field - _tasks

##### Summary

 * Type: 

#### Property - Clients

##### Summary

 * Type: IReadOnlyDictionary < int , TcpClient > 

#### Public Async Method - DisposeAsync


