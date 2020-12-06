# TupleConfiguration.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.TestUtilities/Configuration/TupleConfiguration.cs

## Public Class - TupleConfiguration

### Members

#### Private ReadOnly Field - _store

##### Summary

 * Type: 

#### Public Property - Key

##### Summary

 * Type: string ? 

#### Public Property - Path

##### Summary

 * Type: string ? 

#### Public Property - Value

##### Summary

 * Type: string ? 

#### Public Constructor - TupleConfiguration

#####  Parameters

 - params ( string key , string value ) [  ] settings 

#### Public Constructor - TupleConfiguration

#####  Parameters

 - IEnumerable < ( string key , string value ) > settings 
 - string ? key = null 
 - string ? path = null 

#### Public Method - GetReloadToken


#### Public Method - GetChildren


#### Public Method - GetSection

#####  Parameters

 - string key 

#### Public Property - HasChanged

##### Summary

 * Type: bool 

#### Public Property - ActiveChangeCallbacks

##### Summary

 * Type: bool 

#### Public Method - Dispose


#### Public Method - RegisterChangeCallback

#####  Parameters

 - Action < object > callback 
 - object state 

## Internal Class - ChangeToken

### Members

#### Public Property - HasChanged

##### Summary

 * Type: bool 

#### Public Property - ActiveChangeCallbacks

##### Summary

 * Type: bool 

#### Public Method - Dispose


#### Public Method - RegisterChangeCallback

#####  Parameters

 - Action < object > callback 
 - object state 

