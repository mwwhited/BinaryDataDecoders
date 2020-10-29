# FileEntry.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.Apple2\Dos33\FileEntry.cs

## Public Structure - FileEntry

### Comments

 <summary>
 FILE DESCRIPTIVE ENTRY FORMAT 
 
 Each file descriptive entry contains a total of 35 ($23) bytes. The relative byte is the 
 number starting at the beginning of each file descriptive entry.
 </summary>

### Members

#### Public Constructor - FileEntry

#####  Parameters

 - ReadOnlySpan < byte > span 

#### Public ReadOnly Field - Track

##### Comments

 <summary>
 Track of first track/sector list sector.  If this is a deleted file, this byte contains $FF
 and the original track number is copied to last byte of the file name field(BYTE $20).  If this
 byte contains a $00, the entry is assumed to have never been used and is available for use.
 (This means that track 0 can never be used for data entry if the DOS image is wiped off the diskette.)
 </summary>

##### Summary

 * Type: 

#### Public ReadOnly Field - Sector

##### Comments

 <summary>
 Sector of the first track/sector list sector
 </summary>

##### Summary

 * Type: 

#### Public ReadOnly Field - FileType

##### Comments

 <summary>
 File type and sector flags:
   $80 + file type - file is locked
   $00 + file type - file is not locked
   $00 - TEXT file
   $01 - INTEGER BASIC file
   $02 - APPLESOFT BASIC file
   $04 - BINARY file
   $08 - S type file
   $10 - RELOCATABLE object module file
   $20 - A type file
   $40 - B type file
   (Thus, $84 is a locked BINARY file, and $90 is a locked R type file.)
 </summary>

##### Summary

 * Type: AppleFileType 

#### Public ReadOnly Field - Name

##### Comments

 <summary>
 File name (30 characters) ... actually 29.. $20 is reserved for "OriginalTrack"
 </summary>

##### Summary

 * Type: 

#### Public ReadOnly Field - OriginalTrack

##### Comments

 <summary>
 If the file is deleted the original track location is stored here
 </summary>

##### Summary

 * Type: 

#### Public ReadOnly Field - FileSize

##### Comments

 <summary>
  Length of the file in sectors (LO/HI format). The CATALOG command will only format the
  LO byte of this length giving 1-255, but a full 65535 may be stored here.
 </summary>

##### Summary

 * Type: 

#### Public Property - IsDeleted

##### Comments

 <summary>
 Simple mapping to the deleted flag in FileType
 </summary>

##### Summary

 * Type:   < summary > 
  Simple mapping to the deleted flag in FileType 
   </ summary > 
  bool 

#### Public Property - IsLocked

##### Comments

 <summary>
 file is readonly
 </summary>

##### Summary

 * Type:   < summary > 
  file is readonly 
   </ summary > 
  bool 

#### Public Property - Exists

##### Comments

 <summary>
 file does not exist
 </summary>

##### Summary

 * Type:   < summary > 
  file does not exist 
   </ summary > 
  bool 

#### Public Method - ToString


