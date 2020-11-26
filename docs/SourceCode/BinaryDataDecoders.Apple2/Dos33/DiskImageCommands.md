# DiskImageCommands.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.Apple2/Dos33/DiskImageCommands.cs

## Public Class - DiskImageCommands

### Comments

 <summary>
 set of commands for AppleSoft DOS 3.3 disk images.
 </summary>

### Members

#### Public Method - GetVolumeTableOfContents

##### Comments

 <summary>
 Retrieve Volume table of contents.
 </summary>
 <paramname="diskImage"></param>
 <returns></returns>

#####  Parameters

 - Stream diskImage 

#### Public Method - GetCatalogs

##### Comments

 <summary>
 Returns list of catalog entries with files
 </summary>
 <paramname="diskImage"></param>
 <returns></returns>

#####  Parameters

 - Stream diskImage 

#### Public Method - GetTrackSectorListForFileEntry

##### Comments

 <summary>
 Returns list of populated track/sectors for given file
 </summary>
 <paramname="diskImage"></param>
 <paramname="fileEntry"></param>
 <returns></returns>

#####  Parameters

 - Stream diskImage 
 - FileEntry fileEntry 

#### Public Method - GetDataFileEntry

##### Comments

 <summary>
 retrieve binary data for input file
 </summary>
 <paramname="diskImage"></param>
 <paramname="fileEntry"></param>
 <returns></returns>

#####  Parameters

 - Stream diskImage 
 - FileEntry fileEntry 

