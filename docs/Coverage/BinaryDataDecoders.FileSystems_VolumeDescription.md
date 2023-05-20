# BinaryDataDecoders.FileSystems.Iso9660.VolumeDescription

## Summary

| Key             | Value                                                      |
| :-------------- | :--------------------------------------------------------- |
| Class           | `BinaryDataDecoders.FileSystems.Iso9660.VolumeDescription` |
| Assembly        | `BinaryDataDecoders.FileSystems`                           |
| Coveredlines    | `0`                                                        |
| Uncoveredlines  | `44`                                                       |
| Coverablelines  | `44`                                                       |
| Totallines      | `150`                                                      |
| Linecoverage    | `0`                                                        |
| Coveredbranches | `0`                                                        |
| Totalbranches   | `4`                                                        |
| Branchcoverage  | `0`                                                        |
| Coveredmethods  | `0`                                                        |
| Totalmethods    | `5`                                                        |
| Methodcoverage  | `0`                                                        |

## Metrics

| Complexity | Lines | Branches | Name                                        |
| :--------- | :---- | :------- | :------------------------------------------ |
| 1          | 0     | 100      | `ctor`                                      |
| 1          | 0     | 100      | `Create`                                    |
| 2          | 0     | 0        | `GetEnumerator`                             |
| 1          | 0     | 100      | `SystemCollectionsIEnumerableGetEnumerator` |
| 2          | 0     | 0        | `Dispose`                                   |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.FileSystems/Iso9660/VolumeDescription.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections;
〰3:   using System.Collections.Generic;
〰4:   using System.IO;
〰5:   using System.Text;
〰6:   
〰7:   namespace BinaryDataDecoders.FileSystems.Iso9660
〰8:   {
〰9:       public class VolumeDescription : IEnumerable<DirectoryRecord>, IDisposable
〰10:      {
〰11:          private VolumeDescription(byte[] buffer, Encoding encoding, Stream reader)
〰12:          {
〰13:              //  1      1
‼14:              var offset = 1;
〰15:              //  6      67, 68, 48, 48, 49 and 1, respectively (same as Volume
〰16:              //           Descriptor Set Terminator)
‼17:              this.DescriptorSet = buffer.GetString(ref offset, 6, encoding);
〰18:              //  1      0
‼19:              offset += 1;    //padding
〰20:              // 32      system identifier
‼21:              this.SystemIdentifier = buffer.GetString(ref offset, 32, encoding);
〰22:              // 32      volume identifier
‼23:              this.VolumeIdentifier = buffer.GetString(ref offset, 32, encoding);
〰24:              //  8      zeros
‼25:              offset += 8;    // padding
〰26:              //  8      total number of sectors, as a both endian double word
‼27:              this.SectorCount = buffer.GetUInt32(ref offset, 8);
〰28:              // 32      zeros
‼29:              offset += 32;   // padding
〰30:              //  4      1, as a both endian word [volume set size]
‼31:              this.VolumeSetSize = buffer.GetUInt16(ref offset, 4);
〰32:              //  4      1, as a both endian word [volume sequence number]
‼33:              this.VolumeSequenceNumber = buffer.GetUInt16(ref offset, 4);
〰34:              //  4      2048 (the sector size), as a both endian word
‼35:              this.SectorSize = buffer.GetUInt16(ref offset, 4);
〰36:              //  8      path table length in bytes, as a both endian double word
‼37:              this.PathTableLength = buffer.GetUInt32(ref offset, 8);
〰38:              //  4      number of first sector in first little endian path table,
〰39:              //           as a little endian double word
‼40:              var v1 = buffer.GetUInt32(ref offset, 4);
〰41:              //offset += 4;   // padding
〰42:              //  4      number of first sector in second little endian path table,
〰43:              //           as a little endian double word, or zero if there is no
〰44:              //           second little endian path table
‼45:              var v2 = buffer.GetUInt32(ref offset, 4);
〰46:              //offset += 4;   // padding
〰47:              //  4      number of first sector in first big endian path table,
〰48:              //           as a big endian double word
‼49:              this.FirstSectorFirst = buffer.GetUInt32(ref offset, 4);
〰50:              //  4      number of first sector in second big endian path table,
〰51:              //           as a big endian double word, or zero if there is no
〰52:              //           second big endian path table
‼53:              this.FirstSectorSecond = buffer.GetUInt32(ref offset, 4);
〰54:              // 34      root directory record, as described below
‼55:              var rootDir = new byte[34];
‼56:              Array.Copy(buffer, offset, rootDir, 0, 34);
‼57:              this.DirectoryRecord = new DirectoryRecord(rootDir, 0, reader, null);
‼58:              offset += 34;    // 4 big endian
〰59:              //128      volume set identifier
‼60:              this.VolumeSetIdentifier = buffer.GetString(ref offset, 128, encoding);
〰61:              //128      publisher identifier
‼62:              this.PublisherIdentifier = buffer.GetString(ref offset, 128, encoding);
〰63:              //128      data preparer identifier
‼64:              this.DataPreparerIdentifier = buffer.GetString(ref offset, 128, encoding);
〰65:              //128      application identifier
‼66:              this.ApplicationIdentifier = buffer.GetString(ref offset, 128, encoding);
〰67:              // 37      copyright file identifier
‼68:              this.CopyRightFileIdentifier = buffer.GetString(ref offset, 37, encoding);
〰69:              // 37      abstract file identifier
‼70:              this.AbstractFileIdentifier = buffer.GetString(ref offset, 37, encoding);
〰71:              // 37      bibliographical file identifier
‼72:              this.BibliographyFileIdentifier = buffer.GetString(ref offset, 37, encoding);
〰73:              // 17      date and time of volume creation
‼74:              this.VolumeCreation = buffer.GetDateTime(ref offset, 17);
〰75:              // 17      date and time of most recent modification
‼76:              this.VolumeModification = buffer.GetDateTime(ref offset, 17);
〰77:              // 17      date and time when volume expires
‼78:              this.VolumeExpires = buffer.GetDateTime(ref offset, 17);
〰79:              // 17      date and time when volume is effective
‼80:              this.VolumeEffective = buffer.GetDateTime(ref offset, 17);
〰81:              //  1      1
〰82:              //  1      0
〰83:              //512      reserved for application use (usually zeros)
〰84:              //653      zeros
‼85:          }
〰86:  
〰87:          public string DescriptorSet { get; protected set; }
〰88:          public string SystemIdentifier { get; protected set; }
〰89:          public string VolumeIdentifier { get; protected set; }
〰90:          public uint SectorCount { get; protected set; }
〰91:          public ushort VolumeSetSize { get; protected set; }
〰92:          public ushort VolumeSequenceNumber { get; protected set; }
〰93:          public ushort SectorSize { get; protected set; }
〰94:          public uint PathTableLength { get; protected set; }
〰95:          public uint FirstSectorFirst { get; protected set; }
〰96:          public uint FirstSectorSecond { get; protected set; }
〰97:          public DirectoryRecord DirectoryRecord { get; protected set; }
〰98:          public string VolumeSetIdentifier { get; protected set; }
〰99:          public string PublisherIdentifier { get; protected set; }
〰100:         public string DataPreparerIdentifier { get; protected set; }
〰101:         public string ApplicationIdentifier { get; protected set; }
〰102:         public string CopyRightFileIdentifier { get; protected set; }
〰103:         public string AbstractFileIdentifier { get; protected set; }
〰104:         public string BibliographyFileIdentifier { get; protected set; }
〰105:         public DateTime VolumeCreation { get; protected set; }
〰106:         public DateTime VolumeModification { get; protected set; }
〰107:         public DateTime VolumeExpires { get; protected set; }
〰108:         public DateTime VolumeEffective { get; protected set; }
〰109: 
〰110:         public static VolumeDescription Create(Stream stream)
〰111:         {
‼112:             var sector = new byte[2048];
〰113:             var bufferLen = 0;
〰114: 
‼115:             lock (stream)
〰116:             {
〰117:                 //skip the first 16 sectors
‼118:                 stream.Seek(16 * sector.Length, SeekOrigin.Begin);
‼119:                 bufferLen = stream.Read(sector, 0, sector.Length);
‼120:             }
‼121:             return new VolumeDescription(sector, Encoding.ASCII, stream);
〰122:         }
〰123:         protected Stream BaseStream { get; set; }
〰124: 
〰125:         #region IEnumerable<DirectoryRecord> Members
〰126: 
〰127:         public IEnumerator<DirectoryRecord> GetEnumerator()
〰128:         {
‼129:             if (this.DirectoryRecord == null) return null;
‼130:             return this.DirectoryRecord.GetEnumerator();
〰131:         }
〰132: 
〰133:         IEnumerator IEnumerable.GetEnumerator()
〰134:         {
‼135:             return this.GetEnumerator();
〰136:         }
〰137: 
〰138:         #endregion
〰139: 
〰140:         #region IDisposable Members
〰141: 
〰142:         public void Dispose()
〰143:         {
‼144:             if (this.BaseStream != null)
‼145:                 this.BaseStream.Dispose();
‼146:         }
〰147: 
〰148:         #endregion
〰149:     }
〰150: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

