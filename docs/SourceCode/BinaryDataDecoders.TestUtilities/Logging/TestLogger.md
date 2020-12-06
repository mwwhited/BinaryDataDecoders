# TestLogger.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.TestUtilities/Logging/TestLogger.cs

## Public Class - TestLogger

### Members

#### ReadOnly Field - _context

##### Summary

 * Type: TestContext 

#### ReadOnly Field - _category

##### Summary

 * Type: 

#### Public Constructor - TestLogger

#####  Parameters

 - TestContext testContext 
 - string category = null 

#### Public Constructor - TestLogger

#####  Parameters

 - ITestContextWrapper contextWrapper 
 - string category = null 

#### Public Method - BeginScope

#####  Parameters

 - TState state 

#### Public Method - IsEnabled

#####  Parameters

 - LogLevel logLevel 

#### Public Method - Log

#####  Parameters

 - LogLevel logLevel 
 - EventId eventId 
 - TState state 
 - Exception exception 
 - Func < TState , Exception , string > formatter 

## Public Class - TestLogger

### Members

#### Public Constructor - TestLogger

#####  Parameters

 - TestContext testContext 

#### Public Constructor - TestLogger

#####  Parameters

 - ITestContextWrapper contextWrapper 

