# DirectoryRecord.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.FileSystems/Iso9660/DirectoryRecord.cs

## Public Class - DirectoryRecord

### Members

#### Internal Constructor - DirectoryRecord

#####  Parameters

 - byte [  ] buffer 
 - int offset 
 - Stream file 
 - DirectoryRecord parent 

#### Public Property - BytesInRecord

##### Summary

 * Type: # region  byte 

#### Public Property - SectorsInExtended

##### Summary

 * Type: byte 

#### Public Property - FirstSector

##### Summary

 * Type: uint 

#### Public Property - Size

##### Summary

 * Type: uint 

#### Public Property - DateTime

##### Summary

 * Type: DateTime 

#### Public Property - DirectoryType

##### Summary

 * Type: DirectoryType 

#### Public Property - FileUnitSize

##### Summary

 * Type: byte 

#### Public Property - InterlaveGapSize

##### Summary

 * Type: byte 

#### Public Property - VolumeSequenceNumber

##### Summary

 * Type: ushort 

#### Public Property - IdentifierLength

##### Summary

 * Type: byte 

#### Public Property - Identifier

##### Summary

 * Type: string 

#### Public Method - ToString


#### Private Method - GetChildren


#### Private Method - GetBuffer


#### Private ReadOnly Field - disc

##### Attributes

 - DebuggerBrowsable
 - (
 - DebuggerBrowsableState
 - .
 - Never
 - )

##### Summary

 * Type: Stream 

#### Public Property - Parent

##### Summary

 * Type: DirectoryRecord 

#### Private Field - _root

##### Attributes

 - DebuggerBrowsable
 - (
 - DebuggerBrowsableState
 - .
 - Never
 - )

##### Summary

 * Type: DirectoryRecord 

#### Public Property - Root

##### Summary

 * Type: DirectoryRecord 

#### Public Property - IsDirectory

##### Summary

 * Type: bool 

#### Public Property - Children

##### Summary

 * Type: IEnumerable < DirectoryRecord > 

#### Public Property - Data

##### Summary

 * Type: byte [  ] 

#### Public Property - DataBase64

##### Summary

 * Type: string 

#### Public Method - GetEnumerator


#### Method - GetEnumerator


