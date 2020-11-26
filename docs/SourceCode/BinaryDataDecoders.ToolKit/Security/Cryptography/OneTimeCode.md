# OneTimeCode.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.ToolKit/Security/Cryptography/OneTimeCode.cs

## Public Class - OneTimeCode

### Members

#### Public Static ReadOnly Field - UNIX_EPOCH

##### Summary

 * Type: DateTime 

#### Public Static ReadOnly Field - Base32Encoding

##### Summary

 * Type: Base32Codec 

#### Public Method - GetCurrentCounter


#### Public Method - GenerateToken

#####  Parameters

 - string secret 
 - long iterationNumber 
 - int digits = 6 

#### Public Method - GetToken

#####  Parameters

 - string secret 
 - long ? counter = null 

#### Public Method - IsValid

#####  Parameters

 - string secret 
 - string token 
 - int checkAdjacentIntervals = 1 

#### Public Method - GenerateSecret


#### Public Method - GetKey

#####  Parameters

 - string secret 

#### Public Method - GetUri

#####  Parameters

 - string secret 
 - string issuer 
 - string account = null 
 - Types type = Types . TOTP 

## Public Enumeration - Types

