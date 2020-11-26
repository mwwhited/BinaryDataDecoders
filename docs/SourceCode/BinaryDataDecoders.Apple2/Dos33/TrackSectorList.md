# TrackSectorList.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.Apple2/Dos33/TrackSectorList.cs

## Public Structure - TrackSectorList

### Comments

 <summary>
 Each file has associated with it a "track/sector" list sector. 
 This sector contains a list of track/sector pointer pairs that
 sequentially list the data sectors which make up the file.The
 file descriptive entry in the catalog sector points to this T/S
 list sector which, in turn, points to each sector in the file.
 The format of a Track/Sector List sector is given below.  Note
 that since even a minimal file requires one T/S List sector and
 one data sector, the least number of sectors a non-empty file can
 have is 2, the value given when the CATALOG command is done.
 Also, note that a very large file, having more than 122 data
 sectors, will need more than one Track/Sector List to hold all
 the Track/Sector pointer pairs.
 </summary>

### Members

#### Public Constructor - TrackSectorList

#####  Parameters

 - ReadOnlySpan < byte > span 

#### Private Field - Unused_0

##### Comments

 <summary>
 $00         Not used
 </summary>

##### Summary

 * Type: 

#### Public ReadOnly Field - NextTrack

##### Comments

 <summary>
 $01         Track number of next T/S List sector if one was needed or zero if no more T/S List sectors
 </summary>

##### Summary

 * Type: 

#### Public ReadOnly Field - NextSector

##### Comments

 <summary>
 $02         Sector number of next T/S List sector(if present)
 </summary>

##### Summary

 * Type: 

#### Private ReadOnly Field - Unused_3_to_4

##### Comments

 <summary>
 $03-$04     Not used
 </summary>

##### Summary

 * Type: 

#### Public ReadOnly Field - SectorOffset

##### Comments

 <summary>
 $05-$06     Sector offset in this file of the first sector described by this list (probably 0000, meaning zero bytes offset from byte $0C)
 </summary>

##### Summary

 * Type: 

#### Private ReadOnly Field - Unused_7_to_B

##### Comments

 <summary>
 $07-$0B     Not used
 </summary>

##### Summary

 * Type: 

#### Public ReadOnly Field - TrackSectorPairs

##### Comments

 <summary>
 $0C-$0D     Track and sector of first data sector or zeros
 $0E-$0F     Track and sector of second data sector or zeros
 $10-$FF Up to 120 more Track/Sector pairs
 </summary>

##### Summary

 * Type: 

