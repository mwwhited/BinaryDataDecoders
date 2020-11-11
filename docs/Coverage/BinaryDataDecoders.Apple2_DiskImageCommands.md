# BinaryDataDecoders.Apple2.Dos33.DiskImageCommands

## Summary

| Key             | Value                                               |
| :-------------- | :-------------------------------------------------- |
| Class           | `BinaryDataDecoders.Apple2.Dos33.DiskImageCommands` |
| Assembly        | `BinaryDataDecoders.Apple2`                         |
| Coveredlines    | `59`                                                |
| Uncoveredlines  | `4`                                                 |
| Coverablelines  | `63`                                                |
| Totallines      | `143`                                               |
| Linecoverage    | `93.6`                                              |
| Coveredbranches | `11`                                                |
| Totalbranches   | `14`                                                |
| Branchcoverage  | `78.5`                                              |

## Metrics

| Complexity | Lines | Branches | Name                             |
| :--------- | :---- | :------- | :------------------------------- |
| 1          | 100   | 100      | `GetVolumeTableOfContents`       |
| 4          | 100   | 100      | `GetCatalogs`                    |
| 4          | 82.35 | 50.0     | `GetTrackSectorListForFileEntry` |
| 6          | 94.44 | 83.33    | `GetDataFileEntry`               |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Apple2\Dos33\DiskImageCommands.cs

```CSharp
〰1:   using System;
〰2:   using System.Buffers;
〰3:   using System.Collections.Generic;
〰4:   using System.IO;
〰5:   using System.Linq;
〰6:   
〰7:   namespace BinaryDataDecoders.Apple2.Dos33
〰8:   {
〰9:       /// <summary>
〰10:      /// set of commands for AppleSoft DOS 3.3 disk images.
〰11:      /// </summary>
〰12:      public class DiskImageCommands : IDiskImageCommands
〰13:      {
〰14:          /// <summary>
〰15:          /// Retrieve Volume table of contents.
〰16:          /// </summary>
〰17:          /// <param name="diskImage"></param>
〰18:          /// <returns></returns>
〰19:          public VolumeTableOfContents GetVolumeTableOfContents(Stream diskImage)
〰20:          {
〰21:              //var diskTracks = 35;
✔22:              var trackSectors = 16;
✔23:              var sectorLength = 256;
〰24:  
✔25:              var trackNumber = 0x11;
✔26:              var sectorNumber = 0;
〰27:  
✔28:              var vtocLocation = trackNumber * trackSectors * sectorLength + sectorNumber * sectorLength;
✔29:              diskImage.Position = vtocLocation;
✔30:              var sector = new byte[sectorLength];
✔31:              Span<byte> sectorSpan = sector;
✔32:              var read = diskImage.Read(sectorSpan);
〰33:  
✔34:              var vtoc = new VolumeTableOfContents(sectorSpan.Slice(0, read));
✔35:              return vtoc;
〰36:          }
〰37:  
〰38:          /// <summary>
〰39:          /// Returns list of catalog entries with files
〰40:          /// </summary>
〰41:          /// <param name="diskImage"></param>
〰42:          /// <returns></returns>
〰43:          public IEnumerable<CatalogEntry> GetCatalogs(Stream diskImage)
〰44:          {
✔45:              var vtoc = GetVolumeTableOfContents(diskImage);
〰46:  
✔47:              var track = vtoc.FirstCatalogTrack;
✔48:              var sector = vtoc.FirstCatalogSector;
✔49:              var trackSectors = vtoc.NumberOfSectorsPerTrack;
✔50:              var sectorLength = vtoc.NumberOfBytesPerSector;
〰51:  
✔52:              var buffer = new byte[sectorLength];
〰53:          next:
〰54:  
✔55:              Span<byte> catalogSpan = buffer;
✔56:              var location = track * trackSectors * sectorLength + sector * sectorLength;
〰57:  
✔58:              diskImage.Position = location;
✔59:              var read = diskImage.Read(catalogSpan);
✔60:              var item = new CatalogEntry(catalogSpan.Slice(0, read));
✔61:              yield return item;
〰62:  
✔63:              if (item.NextCatalogTrack != 0 && item.NextSectorTrack != 0)
〰64:              {
✔65:                  track = item.NextCatalogTrack;
✔66:                  sector = item.NextSectorTrack;
✔67:                  goto next;
〰68:              }
✔69:          }
〰70:  
〰71:          /// <summary>
〰72:          /// Returns list of populated track/sectors for given file
〰73:          /// </summary>
〰74:          /// <param name="diskImage"></param>
〰75:          /// <param name="fileEntry"></param>
〰76:          /// <returns></returns>
〰77:          public IEnumerable<TrackSectorList> GetTrackSectorListForFileEntry(Stream diskImage, FileEntry fileEntry)
〰78:          {
✔79:              var vtoc = GetVolumeTableOfContents(diskImage);
〰80:  
✔81:              var track = fileEntry.Track;
✔82:              var sector = fileEntry.Sector;
✔83:              var trackSectors = vtoc.NumberOfSectorsPerTrack;
✔84:              var sectorLength = vtoc.NumberOfBytesPerSector;
〰85:  
✔86:              var buffer = new byte[sectorLength];
〰87:          next:
〰88:  
✔89:              Span<byte> span = buffer;
✔90:              var location = track * trackSectors * sectorLength + sector * sectorLength;
〰91:  
✔92:              diskImage.Position = location;
✔93:              var read = diskImage.Read(span);
✔94:              var item = new TrackSectorList(span.Slice(0, read));
✔95:              yield return item;
〰96:  
⚠97:              if (item.NextTrack != 0 && item.NextSector != 0)
〰98:              {
‼99:                  track = item.NextTrack;
‼100:                 sector = item.NextSector;
‼101:                 goto next;
〰102:             }
✔103:         }
〰104: 
〰105:         /// <summary>
〰106:         /// retrieve binary data for input file
〰107:         /// </summary>
〰108:         /// <param name="diskImage"></param>
〰109:         /// <param name="fileEntry"></param>
〰110:         /// <returns></returns>
〰111:         public Span<byte> GetDataFileEntry(Stream diskImage, FileEntry fileEntry)
〰112:         {
✔113:             var ts = (from trackSectorList in GetTrackSectorListForFileEntry(diskImage, fileEntry)
✔114:                       from trackSector in trackSectorList.TrackSectorPairs
✔115:                       where trackSector.Track != 0 || trackSector.Sector != 0
✔116:                       select (trackSectorList, trackSector)).ToArray();
〰117: 
✔118:             var vtoc = GetVolumeTableOfContents(diskImage);
✔119:             var trackSectors = vtoc.NumberOfSectorsPerTrack;
✔120:             var sectorLength = vtoc.NumberOfBytesPerSector;
〰121: 
✔122:             var outputBuffer = new byte[sectorLength * ts.Length];
✔123:             Span<byte> outputSpan = outputBuffer;
〰124: 
✔125:             for (int i = 0; i < ts.Length; i++)
〰126:             {
‼127:                 if (ts[i].trackSectorList.SectorOffset != 0) throw new NotSupportedException();
〰128: 
✔129:                 var track = ts[i].trackSector.Track;
✔130:                 var sector = ts[i].trackSector.Sector;
✔131:                 var location = track * trackSectors * sectorLength + sector * sectorLength;
✔132:                 diskImage.Position = location;
〰133: 
✔134:                 Span<byte> sectorSpan = outputSpan.Slice(i * sectorLength, sectorLength);
〰135: 
✔136:                 var read = diskImage.Read(sectorSpan);
〰137: 
〰138:             }
〰139: 
✔140:             return outputSpan;
〰141:         }
〰142:     }
〰143: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

