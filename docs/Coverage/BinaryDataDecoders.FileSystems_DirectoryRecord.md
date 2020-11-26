# BinaryDataDecoders.FileSystems.Iso9660.DirectoryRecord

## Summary

| Key             | Value                                                    |
| :-------------- | :------------------------------------------------------- |
| Class           | `BinaryDataDecoders.FileSystems.Iso9660.DirectoryRecord` |
| Assembly        | `BinaryDataDecoders.FileSystems`                         |
| Coveredlines    | `0`                                                      |
| Uncoveredlines  | `106`                                                    |
| Coverablelines  | `106`                                                    |
| Totallines      | `260`                                                    |
| Linecoverage    | `0`                                                      |
| Coveredbranches | `0`                                                      |
| Totalbranches   | `32`                                                     |
| Branchcoverage  | `0`                                                      |

## Metrics

| Complexity | Lines | Branches | Name                                        |
| :--------- | :---- | :------- | :------------------------------------------ |
| 10         | 0     | 0        | `ctor`                                      |
| 1          | 0     | 100      | `get_BytesInRecord`                         |
| 1          | 0     | 100      | `get_SectorsInExtended`                     |
| 1          | 0     | 100      | `get_FirstSector`                           |
| 1          | 0     | 100      | `get_Size`                                  |
| 1          | 0     | 100      | `get_DateTime`                              |
| 1          | 0     | 100      | `get_DirectoryType`                         |
| 1          | 0     | 100      | `get_FileUnitSize`                          |
| 1          | 0     | 100      | `get_InterlaveGapSize`                      |
| 1          | 0     | 100      | `get_VolumeSequenceNumber`                  |
| 1          | 0     | 100      | `get_IdentifierLength`                      |
| 1          | 0     | 100      | `get_Identifier`                            |
| 1          | 0     | 100      | `ToString`                                  |
| 6          | 0     | 0        | `GetChildren`                               |
| 1          | 0     | 100      | `GetBuffer`                                 |
| 1          | 0     | 100      | `get_Parent`                                |
| 4          | 0     | 0        | `get_Root`                                  |
| 1          | 0     | 100      | `get_IsDirectory`                           |
| 6          | 0     | 0        | `get_Children`                              |
| 2          | 0     | 0        | `get_Data`                                  |
| 2          | 0     | 0        | `get_DataBase64`                            |
| 2          | 0     | 0        | `GetEnumerator`                             |
| 1          | 0     | 100      | `SystemCollectionsIEnumerableGetEnumerator` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.FileSystems/Iso9660/DirectoryRecord.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections;
〰3:   using System.Collections.Generic;
〰4:   using System.Diagnostics;
〰5:   using System.IO;
〰6:   using System.Text;
〰7:   
〰8:   namespace BinaryDataDecoders.FileSystems.Iso9660
〰9:   {
〰10:      public class DirectoryRecord : IEnumerable<DirectoryRecord>
〰11:      {
‼12:          internal DirectoryRecord(byte[] buffer,
‼13:                                   int offset,
‼14:                                   Stream file,
‼15:                                   DirectoryRecord parent)
〰16:          {
‼17:              if (file != null)
‼18:                  disc = file;
‼19:              this.Parent = parent;
〰20:  
〰21:              //1	22
‼22:              this.BytesInRecord = buffer[offset];
‼23:              offset++;
〰24:  
〰25:              //1	00
‼26:              this.SectorsInExtended = buffer[offset];
‼27:              offset++;
〰28:  
〰29:              //8	1B 00 00 00 - 00 00 00 1B
‼30:              this.FirstSector = buffer.GetUInt32(ref offset, 8);
〰31:  
〰32:              //8	00 08 00 00 - 00 00 08 00
‼33:              this.Size = buffer.GetUInt32(ref offset, 8);
〰34:  
〰35:              //1	63
‼36:              var yearOffset = buffer[offset];
‼37:              offset++;
〰38:              //1	0B
‼39:              var month = buffer[offset];
‼40:              offset++;
〰41:              //1	18
‼42:              var day = buffer[offset];
‼43:              offset++;
〰44:              //1	0F
‼45:              var hour = buffer[offset];
‼46:              offset++;
〰47:              //1	35
‼48:              var minute = buffer[offset];
‼49:              offset++;
〰50:              //1	00
‼51:              var second = buffer[offset];
‼52:              offset++;
〰53:              //1	00
‼54:              var quaterHourOffset = (sbyte)(buffer[offset]);
‼55:              offset++;
〰56:  
‼57:              var timeOffset = quaterHourOffset * 15d;
‼58:              this.DateTime = new DateTime(yearOffset + 1900,
‼59:                                           month == 0 ? 1 : month,
‼60:                                           day == 0 ? 1 : month,
‼61:                                           hour,
‼62:                                           minute,
‼63:                                           second
‼64:                                           ).AddMinutes(timeOffset);
〰65:  
〰66:              //1	02
‼67:              this.DirectoryType = (DirectoryType)(buffer[offset]);
‼68:              offset++;
〰69:  
〰70:              //1	00
‼71:              this.FileUnitSize = buffer[offset];
‼72:              offset++;
〰73:  
〰74:              //1	00
‼75:              this.InterlaveGapSize = buffer[offset];
‼76:              offset++;
〰77:  
〰78:              //4	01 00 - 00 01
‼79:              this.VolumeSequenceNumber = buffer.GetUInt16(ref offset, 4);
〰80:  
〰81:              //1	01
‼82:              this.IdentifierLength = buffer[offset];
‼83:              offset++;
〰84:  
‼85:              this.Identifier = buffer.GetString(ref offset,
‼86:                                                 this.IdentifierLength,
‼87:                                                 Encoding.ASCII);
‼88:              if (string.IsNullOrEmpty(this.Identifier))
‼89:                  this.Identifier = ".";
‼90:              else if (this.Identifier == "\x01")
‼91:                  this.Identifier = "..";
〰92:  
〰93:              //    00
‼94:          }
〰95:  
〰96:          #region Properties
〰97:  
〰98:          // length
〰99:          // in bytes  contents
〰100:         // --------  ---------------------------------------------------------
‼101:         public byte BytesInRecord { get; protected set; }
〰102:         //    1      R, the number of bytes in the record (which must be even)
‼103:         public byte SectorsInExtended { get; protected set; }
〰104:         //    1      0 [number of sectors in extended attribute record]
‼105:         public uint FirstSector { get; protected set; }
〰106:         //    8      number of the first sector of file data or directory
〰107:         //             (zero for an empty file), as a both endian double word
‼108:         public uint Size { get; protected set; }
〰109:         //    8      number of bytes of file data or length of directory,
〰110:         //             excluding the extended attribute record,
〰111:         //             as a both endian double word
〰112: 
‼113:         public DateTime DateTime { get; protected set; }
〰114:         //    1      number of years since 1900
〰115:         //    1      month, where 1=January, 2=February, etc.
〰116:         //    1      day of month, in the range from 1 to 31
〰117:         //    1      hour, in the range from 0 to 23
〰118:         //    1      minute, in the range from 0 to 59
〰119:         //    1      second, in the range from 0 to 59
〰120:         //             (for DOS this is always an even number)
〰121:         //    1      offset from Greenwich Mean Time, in 15-minute intervals,
〰122:         //             as a twos complement signed number, positive for time
〰123:         //             zones east of Greenwich, and negative for time zones
〰124:         //             west of Greenwich (DOS ignores this field)
〰125: 
‼126:         public DirectoryType DirectoryType { get; protected set; }
〰127:         //    1      flags, with bits as follows:
〰128:         //             bit     value
〰129:         //             ------  ------------------------------------------
〰130:         //             0 (LS)  0 for a norma1 file, 1 for a hidden file
〰131:         //             1       0 for a file, 1 for a directory
〰132:         //             2       0 [1 for an associated file]
〰133:         //             3       0 [1 for record format specified]
〰134:         //             4       0 [1 for permissions specified]
〰135:         //             5       0
〰136:         //             6       0
〰137:         //             7 (MS)  0 [1 if not the final record for the file]
‼138:         public byte FileUnitSize { get; protected set; }
〰139:         //    1      0 [file unit size for an interleaved file]
‼140:         public byte InterlaveGapSize { get; protected set; }
〰141:         //    1      0 [interleave gap size for an interleaved file]
‼142:         public ushort VolumeSequenceNumber { get; protected set; }
〰143:         //    4      1, as a both endian word [volume sequence number]
‼144:         public byte IdentifierLength { get; protected set; }
〰145:         //    1      N, the identifier length
〰146: 
‼147:         public string Identifier { get; protected set; }
〰148:         //    N      identifier
〰149:         //    P      padding byte: if N is even, P = 1 and this field contains
〰150:         //             a zero; if N is odd, P = 0 and this field is omitted
〰151:         //R-33-N-P   unspecified field for system use; must contain an even
〰152:         //             number of bytes
〰153: 
〰154:         #endregion
〰155: 
‼156:         public override string ToString() => $"{Identifier} - {DirectoryType}";
〰157: 
〰158:         private IEnumerable<DirectoryRecord> GetChildren()
〰159:         {
‼160:             if (this.IsDirectory)
〰161:             {
‼162:                 var sector = new byte[2048];
‼163:                 var bufferLen = 0;
〰164: 
‼165:                 lock (this.disc)
〰166:                 {
‼167:                     disc.Seek(this.FirstSector * this.Size,
‼168:                             SeekOrigin.Begin);
‼169:                     bufferLen = disc.Read(sector, 0, sector.Length);
〰170: 
‼171:                     for (int i = 0; i < bufferLen;)
〰172:                     {
‼173:                         var directorRecord = new DirectoryRecord(sector,
‼174:                                                                  i,
‼175:                                                                  disc,
‼176:                                                                  this);
‼177:                         if (directorRecord.BytesInRecord < 34)
〰178:                             break;
‼179:                         i += directorRecord.BytesInRecord;
‼180:                         yield return directorRecord;
〰181:                     }
‼182:                 }
‼183:             }
‼184:         }
〰185:         private byte[] GetBuffer()
〰186:         {
‼187:             lock (this.disc)
〰188:             {
‼189:                 disc.Seek(this.FirstSector * 2048, SeekOrigin.Begin);
‼190:                 var buffer = new byte[this.Size];
‼191:                 var bufferLen = disc.Read(buffer, 0, (int)this.Size);
‼192:                 return buffer;
〰193:             }
‼194:         }
〰195: 
〰196:         [DebuggerBrowsable(DebuggerBrowsableState.Never)]
〰197:         private readonly Stream disc;
‼198:         public DirectoryRecord Parent { get; protected set; }
〰199: 
〰200:         [DebuggerBrowsable(DebuggerBrowsableState.Never)]
〰201:         private DirectoryRecord _root;
〰202:         public DirectoryRecord Root
〰203:         {
〰204:             get
〰205:             {
‼206:                 if (_root == null)
〰207:                 {
‼208:                     if (this.Parent == null)
‼209:                         return this;
‼210:                     _root = this.Parent.Root;
〰211:                 }
‼212:                 return _root;
〰213:             }
〰214:         }
〰215:         public bool IsDirectory
〰216:         {
‼217:             get { return (this.DirectoryType & DirectoryType.Directory) != 0; }
〰218:         }
〰219:         public IEnumerable<DirectoryRecord> Children
〰220:         {
〰221:             get
〰222:             {
‼223:                 if (disc != null && this.IsDirectory)
‼224:                     foreach (var item in this.GetChildren())
‼225:                         yield return item;
‼226:             }
〰227:         }
〰228:         public byte[] Data
〰229:         {
〰230:             get
〰231:             {
‼232:                 if (disc == null) return null;
‼233:                 return this.GetBuffer();
〰234:             }
〰235:         }
〰236:         public string DataBase64
〰237:         {
〰238:             get
〰239:             {
‼240:                 if (this.Data == null) return null;
‼241:                 return Convert.ToBase64String(this.Data);
〰242:             }
〰243:         }
〰244: 
〰245:         #region IEnumerable<DirectoryRecord> Members
〰246: 
〰247:         public IEnumerator<DirectoryRecord> GetEnumerator()
〰248:         {
‼249:             if (this.Children == null) return null;
‼250:             return this.Children.GetEnumerator();
〰251:         }
〰252: 
〰253:         IEnumerator IEnumerable.GetEnumerator()
〰254:         {
‼255:             return this.GetEnumerator();
〰256:         }
〰257: 
〰258:         #endregion
〰259:     }
〰260: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

