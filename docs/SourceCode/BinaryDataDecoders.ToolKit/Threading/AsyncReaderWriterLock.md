# AsyncReaderWriterLock.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.ToolKit/Threading/AsyncReaderWriterLock.cs

## Public Class - AsyncReaderWriterLock

### Members

#### Private ReadOnly Field - m_readerReleaser

##### Summary

 * Type: 

#### Private ReadOnly Field - m_writerReleaser

##### Summary

 * Type: 

#### Private ReadOnly Field - m_waitingWriters

##### Summary

 * Type: 

#### Private Field - m_waitingReader

##### Summary

 * Type: 

#### Private Field - m_readersWaiting

##### Summary

 * Type: 

#### Private Field - m_status

##### Summary

 * Type: 

#### Public Constructor - AsyncReaderWriterLock


#### Public Method - ReaderLockAsync


#### Private Method - ReaderRelease


#### Public Method - WriterLockAsync


#### Private Method - WriterRelease


#### Private ReadOnly Field - m_toRelease

##### Summary

 * Type: AsyncReaderWriterLock 

#### Private ReadOnly Field - m_writer

##### Summary

 * Type: 

#### Internal Constructor - Releaser

#####  Parameters

 - AsyncReaderWriterLock toRelease 
 - bool writer 

#### Public Method - Dispose


## Public ReadOnly Structure - Releaser

### Members

#### Private ReadOnly Field - m_toRelease

##### Summary

 * Type: AsyncReaderWriterLock 

#### Private ReadOnly Field - m_writer

##### Summary

 * Type: 

#### Internal Constructor - Releaser

#####  Parameters

 - AsyncReaderWriterLock toRelease 
 - bool writer 

#### Public Method - Dispose


