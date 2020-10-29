# Assembly - BinaryDataDecoders.Apple2

## Type - BinaryDataDecoders.Apple2.ApplesoftBASIC.Detokenizer

*summary*
ApplesSoft Basic detokenizer

### Method - GetLines(System.Collections.Generic.IEnumerable{System.Byte})

*summary*
transform byte data into readable AppleSoft BASIC code.

*param*


| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | input                                                        | 

*returns*


## Type - BinaryDataDecoders.Apple2.ApplesoftBASIC.TokenMap

*summary*
AppleSoft Basic token map

### Method - GetToken(System.Byte)

*summary*
Lookup token for provided byte

*param*


| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | code                                                         | 

*returns*


## Type - BinaryDataDecoders.Apple2.Dos33.CatalogEntry

*summary*
The locations of the first catalog track and sector are held in
            bytes $01 and $02 of the VTOC.Typically the catalog resides in
            the rest of the sectors of track 17.  Typically the first set of
            seven files names are in track 17, sector 15; the second set of
            seven file names are in track 17, sector 14; and so on to track
            17, sector 1.  Thus a typical catalog can hold 7*15 names, or a
            maximum of 105 files.

### Field - FileEntries

*summary*
$0B-$2D     First file descriptive entry
            $2E-$50     Second file descriptive entry
            $51-$73     Third file descriptive entry
            $74-$96     Fourth file descriptive entry
            $97-$B9 Fifth file descriptive entry
            $BA-$DC Sixth file descriptive entry
            $DD-$FF Seventh file descriptive entry

### Field - NextCatalogTrack

*summary*
Track number of the next catalog sector (usually $11)

### Field - NextSectorTrack

*summary*
Sector number of next catalog sector

### Field - Unused_0

*summary*
Not used

### Field - Unused_3_to_A

*summary*
Not used

### Method - #ctor(System.ReadOnlySpan{System.Byte})

*summary*
create CatalogEntry from ReadOnlySpan

*param*


| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | span                                                         | 

## Type - BinaryDataDecoders.Apple2.Dos33.DiskImageCommands

*summary*
set of commands for AppleSoft DOS 3.3 disk images.

### Method - GetCatalogs(System.IO.Stream)

*summary*
Returns list of catalog entries with files

*param*


| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | diskImage                                                    | 

*returns*


### Method - GetDataFileEntry(System.IO.Stream,BinaryDataDecoders.Apple2.Dos33.FileEntry)

*summary*
retrieve binary data for input file

*param*


| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | diskImage                                                    | 

*param*


| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | fileEntry                                                    | 

*returns*


### Method - GetTrackSectorListForFileEntry(System.IO.Stream,BinaryDataDecoders.Apple2.Dos33.FileEntry)

*summary*
Returns list of populated track/sectors for given file

*param*


| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | diskImage                                                    | 

*param*


| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | fileEntry                                                    | 

*returns*


### Method - GetVolumeTableOfContents(System.IO.Stream)

*summary*
Retrieve Volume table of contents.

*param*


| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | diskImage                                                    | 

*returns*


## Type - BinaryDataDecoders.Apple2.Dos33.FileEntry

*summary*
FILE DESCRIPTIVE ENTRY FORMAT 
            
            Each file descriptive entry contains a total of 35 ($23) bytes. The relative byte is the 
            number starting at the beginning of each file descriptive entry.

### Field - FileSize

*summary*
Length of the file in sectors (LO/HI format). The CATALOG command will only format the
             LO byte of this length giving 1-255, but a full 65535 may be stored here.

### Field - FileType

*summary*
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

### Field - Name

*summary*
File name (30 characters) ... actually 29.. $20 is reserved for "OriginalTrack"

### Field - OriginalTrack

*summary*
If the file is deleted the original track location is stored here

### Field - Sector

*summary*
Sector of the first track/sector list sector

### Field - Track

*summary*
Track of first track/sector list sector.  If this is a deleted file, this byte contains $FF
            and the original track number is copied to last byte of the file name field(BYTE $20).  If this
            byte contains a $00, the entry is assumed to have never been used and is available for use.
            (This means that track 0 can never be used for data entry if the DOS image is wiped off the diskette.)

### Property - Exists

*summary*
file does not exist

### Property - IsDeleted

*summary*
Simple mapping to the deleted flag in FileType

### Property - IsLocked

*summary*
file is readonly

## Type - BinaryDataDecoders.Apple2.Dos33.IDiskImageCommands

*summary*
set of commands for AppleSoft DOS 3.3 disk images.

### Method - GetCatalogs(System.IO.Stream)

*summary*
Returns list of catalog entries with files

*param*


| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | diskImage                                                    | 

*returns*


### Method - GetDataFileEntry(System.IO.Stream,BinaryDataDecoders.Apple2.Dos33.FileEntry)

*summary*
retrieve binary data for input file

*param*


| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | diskImage                                                    | 

*param*


| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | fileEntry                                                    | 

*returns*


### Method - GetTrackSectorListForFileEntry(System.IO.Stream,BinaryDataDecoders.Apple2.Dos33.FileEntry)

*summary*
Returns list of populated track/sectors for given file

*param*


| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | diskImage                                                    | 

*param*


| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | fileEntry                                                    | 

*returns*


### Method - GetVolumeTableOfContents(System.IO.Stream)

*summary*
Retrieve Volume table of contents.

*param*


| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | diskImage                                                    | 

*returns*


## Type - BinaryDataDecoders.Apple2.Dos33.TrackSector

*summary*
Track/Sector point to next section of file

### Field - Sector

*summary*
Sector of the first track/sector list sector

### Field - Track

*summary*
Track of first track/sector list sector.  If this is a deleted file, this byte contains $FF
            and the original track number is copied to last byte of the file name field(BYTE $20).  If this
            byte contains a $00, the entry is assumed to have never been used and is available for use.
            (This means that track 0 can never be used for data entry if the DOS image is wiped off the diskette.)

## Type - BinaryDataDecoders.Apple2.Dos33.TrackSectorList

*summary*
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

### Field - NextSector

*summary*
$02         Sector number of next T/S List sector(if present)

### Field - NextTrack

*summary*
$01         Track number of next T/S List sector if one was needed or zero if no more T/S List sectors

### Field - SectorOffset

*summary*
$05-$06     Sector offset in this file of the first sector described by this list (probably 0000, meaning zero bytes offset from byte $0C)

### Field - TrackSectorPairs

*summary*
$0C-$0D     Track and sector of first data sector or zeros
            $0E-$0F     Track and sector of second data sector or zeros
            $10-$FF Up to 120 more Track/Sector pairs

### Field - Unused_0

*summary*
$00         Not used

### Field - Unused_3_to_4

*summary*
$03-$04     Not used

### Field - Unused_7_to_B

*summary*
$07-$0B     Not used

## Type - BinaryDataDecoders.Apple2.Dos33.VolumeTableOfContents

*summary*
The catalog lies on track 17.  The beginning of track 17 is at
            offset $11000 (decimal 69632) of a 143360 byte file.Track 17's
            sector zero holds the Volume Table of Contents, and the other
            sectors hold file names

### Field - BitmapFreeSectors

*summary*
$38-$3B     Bit map of free sectors in track 0
            $3C-$FF     Bit maps for additional tracks if there are more

### Field - DirectionOfAllocation

*summary*
$31         Direction of track allocation (+1 or -1)

### Field - DiskVolumeNumber

*summary*
$06         Diskette volume number

### Field - DosReleaseNumber

*summary*
$03         Release number of DOS used to INIT this diskette

### Field - FirstCatalogSector

*summary*
$02         Sector number of first catalog sector

### Field - FirstCatalogTrack

*summary*
$01         Track number of first catalog sector

### Field - LastAllocatedTrack

*summary*
$30         Last track where sectors were allocated

### Field - MaxTrackSectorPair

*summary*
$27         Maximum number of track/sector pairs that will fit in one file/track sector list sector (122 for 256 byte sectors)

### Field - NumberOfBytesPerSector

*summary*
$36-$37     Number of bytes per sector (LO/HI format)

### Field - NumberOfSectorsPerTrack

*summary*
$35         Number of sectors per track

### Field - NumberOfTracksPerDisk

*summary*
$34         Number of tracks per diskette (normally 35)

### Field - Unused0

*summary*
$00         Not used.

### Field - Unused28_2F

*summary*
$28-$2F     Not used

### Field - Unused32_33

*summary*
$32-$33     Not used

### Field - Unused4_5

*summary*
$04-$05     Not used

### Field - Unused7_26

*summary*
$07-$26     Not used

## Type - BinaryDataDecoders.Apple2.Text.Apple2Encoding

*summary*
Represents Apple ][ encoding of Unicode characters

### Method - GetChars(System.Byte*,System.Int32,System.Char*,System.Int32)

*summary*
Decodes AppleIi byte array into string

*param*


| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | bytes                                                        | 

*param*


| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | byteCount                                                    | 

*param*


| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | chars                                                        | 

*param*


| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | charCount                                                    | 

*returns*


### Property - Apple2

*summary*
Get common instance of Apple2Encoding

### Property - BodyName

*summary*
Description for email tags

### Property - EncodingName

*summary*
Name for encoding

