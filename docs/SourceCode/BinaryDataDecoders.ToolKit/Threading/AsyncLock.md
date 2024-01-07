# AsyncLock.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.ToolKit/Threading/AsyncLock.cs

## Public Class - AsyncLock

### Members

#### Private ReadOnly Field - m_semaphore

##### Summary

 * Type: AsyncSemaphore 

#### Private ReadOnly Field - m_releaser

##### Summary

 * Type: 

#### Public Constructor - AsyncLock


#### Public Method - LockAsync


#### Private ReadOnly Field - m_toRelease

##### Summary

 * Type: AsyncLock 

#### Internal Constructor - Releaser

#####  Parameters

 - AsyncLock toRelease 

#### Public Method - Dispose


## Public ReadOnly Structure - Releaser

### Members

#### Private ReadOnly Field - m_toRelease

##### Summary

 * Type: AsyncLock 

#### Internal Constructor - Releaser

#####  Parameters

 - AsyncLock toRelease 

#### Public Method - Dispose


