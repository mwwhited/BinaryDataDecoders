# TrackSector.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.Apple2/Dos33/TrackSector.cs

## Public Structure - TrackSector

### Comments

 <summary>
 Track/Sector point to next section of file
 </summary>

### Attributes

 - StructLayout
 - (
 - LayoutKind
 - .
 - Explicit
 - ,
 - Size
 - =
 - 2
 - )

### Members

#### Public Constructor - TrackSector

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

##### Attributes

 - FieldOffset
 - (
 - 0
 - )

##### Summary

 * Type: 

#### Public ReadOnly Field - Sector

##### Comments

 <summary>
 Sector of the first track/sector list sector
 </summary>

##### Attributes

 - FieldOffset
 - (
 - 1
 - )

##### Summary

 * Type: 

#### Public Method - ToString


