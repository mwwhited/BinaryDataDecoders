# IDiskImageCommands.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.Apple2/Dos33/IDiskImageCommands.cs

## Public Interface - IDiskImageCommands

### Comments

 <summary>
 set of commands for AppleSoft DOS 3.3 disk images.
 </summary>

### Members

#### Method - GetCatalogs

##### Comments

 <summary>
 Returns list of catalog entries with files
 </summary>
 <paramname="diskImage"></param>
 <returns></returns>

#####  Parameters

 - Stream diskImage 

#### Method - GetVolumeTableOfContents

##### Comments

 <summary>
 Retrieve Volume table of contents.
 </summary>
 <paramname="diskImage"></param>
 <returns></returns>

#####  Parameters

 - Stream diskImage 

#### Method - GetTrackSectorListForFileEntry

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

#### Method - GetDataFileEntry

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

