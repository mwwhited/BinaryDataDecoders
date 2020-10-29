# VolumeDescription.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.FileSystems\Iso9660\VolumeDescription.cs

## Public Class - VolumeDescription

### Members

#### Private Constructor - VolumeDescription

#####  Parameters

 - byte [  ] buffer 
 - Encoding encoding 
 - Stream reader 

#### Public Property - DescriptorSet

##### Summary

 * Type: string 

#### Public Property - SystemIdentifier

##### Summary

 * Type: string 

#### Public Property - VolumeIdentifier

##### Summary

 * Type: string 

#### Public Property - SectorCount

##### Summary

 * Type: uint 

#### Public Property - VolumeSetSize

##### Summary

 * Type: ushort 

#### Public Property - VolumeSequenceNumber

##### Summary

 * Type: ushort 

#### Public Property - SectorSize

##### Summary

 * Type: ushort 

#### Public Property - PathTableLength

##### Summary

 * Type: uint 

#### Public Property - FirstSectorFirst

##### Summary

 * Type: uint 

#### Public Property - FirstSectorSecond

##### Summary

 * Type: uint 

#### Public Property - DirectoryRecord

##### Summary

 * Type: DirectoryRecord 

#### Public Property - VolumeSetIdentifier

##### Summary

 * Type: string 

#### Public Property - PublisherIdentifier

##### Summary

 * Type: string 

#### Public Property - DataPreparerIdentifier

##### Summary

 * Type: string 

#### Public Property - ApplicationIdentifier

##### Summary

 * Type: string 

#### Public Property - CopyRightFileIdentifier

##### Summary

 * Type: string 

#### Public Property - AbstractFileIdentifier

##### Summary

 * Type: string 

#### Public Property - BibliographyFileIdentifier

##### Summary

 * Type: string 

#### Public Property - VolumeCreation

##### Summary

 * Type: DateTime 

#### Public Property - VolumeModification

##### Summary

 * Type: DateTime 

#### Public Property - VolumeExpires

##### Summary

 * Type: DateTime 

#### Public Property - VolumeEffective

##### Summary

 * Type: DateTime 

#### Public Static Method - Create

#####  Parameters

 - Stream stream 

#### Property - BaseStream

##### Summary

 * Type: Stream 

#### Public Method - GetEnumerator


#### Method - GetEnumerator


#### Public Method - Dispose


