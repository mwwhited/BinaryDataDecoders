# CatalogEntry.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.Apple2/Dos33/CatalogEntry.cs

## Public Structure - CatalogEntry

### Comments

 <summary>
 The locations of the first catalog track and sector are held in
 bytes $01 and $02 of the VTOC.Typically the catalog resides in
 the rest of the sectors of track 17.  Typically the first set of
 seven files names are in track 17, sector 15; the second set of
 seven file names are in track 17, sector 14; and so on to track
 17, sector 1.  Thus a typical catalog can hold 7*15 names, or a
 maximum of 105 files.
 </summary>

### Members

#### Public Constructor - CatalogEntry

##### Comments

 <summary>
 create CatalogEntry from ReadOnlySpan
 </summary>
 <paramname="span"></param>

#####  Parameters

 - ReadOnlySpan < byte > span 

#### Private ReadOnly Field - Unused_0

##### Comments

 <summary>
 Not used
 </summary>

##### Summary

 * Type: 

#### Public ReadOnly Field - NextCatalogTrack

##### Comments

 <summary>
 Track number of the next catalog sector (usually $11)
 </summary>

##### Summary

 * Type: 

#### Public ReadOnly Field - NextSectorTrack

##### Comments

 <summary>
 Sector number of next catalog sector
 </summary>

##### Summary

 * Type: 

#### Private ReadOnly Field - Unused_3_to_A

##### Comments

 <summary>
 Not used
 </summary>

##### Summary

 * Type: 

#### Public ReadOnly Field - FileEntries

##### Comments

 <summary>
 $0B-$2D     First file descriptive entry
 $2E-$50     Second file descriptive entry
 $51-$73     Third file descriptive entry
 $74-$96     Fourth file descriptive entry
 $97-$B9 Fifth file descriptive entry
 $BA-$DC Sixth file descriptive entry
 $DD-$FF Seventh file descriptive entry
 </summary>

##### Summary

 * Type: 

#### Public Method - ToString


