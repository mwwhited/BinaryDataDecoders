# VolumeTableOfContents.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.Apple2\Dos33\VolumeTableOfContents.cs

## Public Structure - VolumeTableOfContents

### Comments

 <summary>
 The catalog lies on track 17.  The beginning of track 17 is at
 offset $11000 (decimal 69632) of a 143360 byte file.Track 17's
 sector zero holds the Volume Table of Contents, and the other
 sectors hold file names
 </summary>

### Members

#### Public Constructor - VolumeTableOfContents

#####  Parameters

 - ReadOnlySpan < byte > span 

#### Private ReadOnly Field - Unused0

##### Comments

 <summary>
 $00         Not used.
 </summary>

##### Summary

 * Type: 

#### Public ReadOnly Field - FirstCatalogTrack

##### Comments

 <summary>
 $01         Track number of first catalog sector
 </summary>

##### Summary

 * Type: 

#### Public ReadOnly Field - FirstCatalogSector

##### Comments

 <summary>
 $02         Sector number of first catalog sector
 </summary>

##### Summary

 * Type: 

#### Public ReadOnly Field - DosReleaseNumber

##### Comments

 <summary>
 $03         Release number of DOS used to INIT this diskette
 </summary>

##### Summary

 * Type: 

#### Private ReadOnly Field - Unused4_5

##### Comments

 <summary>
 $04-$05     Not used
 </summary>

##### Summary

 * Type: 

#### Public ReadOnly Field - DiskVolumeNumber

##### Comments

 <summary>
 $06         Diskette volume number
 </summary>

##### Summary

 * Type: 

#### Private ReadOnly Field - Unused7_26

##### Comments

 <summary>
 $07-$26     Not used
 </summary>

##### Summary

 * Type: 

#### Public ReadOnly Field - MaxTrackSectorPair

##### Comments

 <summary>
 $27         Maximum number of track/sector pairs that will fit in one file/track sector list sector (122 for 256 byte sectors)
 </summary>

##### Summary

 * Type: 

#### Private ReadOnly Field - Unused28_2F

##### Comments

 <summary>
 $28-$2F     Not used
 </summary>

##### Summary

 * Type: 

#### Public ReadOnly Field - LastAllocatedTrack

##### Comments

 <summary>
 $30         Last track where sectors were allocated
 </summary>

##### Summary

 * Type: 

#### Public ReadOnly Field - DirectionOfAllocation

##### Comments

 <summary>
 $31         Direction of track allocation (+1 or -1)
 </summary>

##### Summary

 * Type: 

#### Private ReadOnly Field - Unused32_33

##### Comments

 <summary>
 $32-$33     Not used
 </summary>

##### Summary

 * Type: 

#### Public ReadOnly Field - NumberOfTracksPerDisk

##### Comments

 <summary>
 $34         Number of tracks per diskette (normally 35)
 </summary>

##### Summary

 * Type: 

#### Public ReadOnly Field - NumberOfSectorsPerTrack

##### Comments

 <summary>
 $35         Number of sectors per track
 </summary>

##### Summary

 * Type: 

#### Public ReadOnly Field - NumberOfBytesPerSector

##### Comments

 <summary>
 $36-$37     Number of bytes per sector (LO/HI format)
 </summary>

##### Summary

 * Type: 

#### Public Field - BitmapFreeSectors

##### Comments

 <summary>
 $38-$3B     Bit map of free sectors in track 0
 $3C-$FF     Bit maps for additional tracks if there are more
 </summary>

##### Summary

 * Type: 

