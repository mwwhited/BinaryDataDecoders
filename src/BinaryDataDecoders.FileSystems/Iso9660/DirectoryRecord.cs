using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace BinaryDataDecoders.FileSystems.Iso9660
{
    public class DirectoryRecord : IEnumerable<DirectoryRecord>
    {
        internal DirectoryRecord(byte[] buffer,
                                 int offset,
                                 Stream file,
                                 DirectoryRecord parent)
        {
            if (file != null)
                disc = file;
            this.Parent = parent;

            //1	22 
            this.BytesInRecord = buffer[offset];
            offset++;

            //1	00 
            this.SectorsInExtended = buffer[offset];
            offset++;

            //8	1B 00 00 00 - 00 00 00 1B 
            this.FirstSector = buffer.GetUInt32(ref offset, 8);

            //8	00 08 00 00 - 00 00 08 00 
            this.Size = buffer.GetUInt32(ref offset, 8);

            //1	63 
            var yearOffset = buffer[offset];
            offset++;
            //1	0B 
            var month = buffer[offset];
            offset++;
            //1	18 
            var day = buffer[offset];
            offset++;
            //1	0F 
            var hour = buffer[offset];
            offset++;
            //1	35 
            var minute = buffer[offset];
            offset++;
            //1	00 
            var second = buffer[offset];
            offset++;
            //1	00 
            var quaterHourOffset = (sbyte)(buffer[offset]);
            offset++;

            var timeOffset = quaterHourOffset * 15d;
            this.DateTime = new DateTime(yearOffset + 1900,
                                         month == 0 ? 1 : month,
                                         day == 0 ? 1 : month,
                                         hour,
                                         minute,
                                         second
                                         ).AddMinutes(timeOffset);

            //1	02 
            this.DirectoryType = (DirectoryType)(buffer[offset]);
            offset++;

            //1	00 
            this.FileUnitSize = buffer[offset];
            offset++;

            //1	00 
            this.InterlaveGapSize = buffer[offset];
            offset++;

            //4	01 00 - 00 01 
            this.VolumeSequenceNumber = buffer.GetUInt16(ref offset, 4);

            //1	01 
            this.IdentifierLength = buffer[offset];
            offset++;

            this.Identifier = buffer.GetString(ref offset,
                                               this.IdentifierLength,
                                               Encoding.ASCII);
            if (string.IsNullOrEmpty(this.Identifier))
                this.Identifier = ".";
            else if (this.Identifier == "\x01")
                this.Identifier = "..";

            //    00 
        }

        #region Properties

        // length
        // in bytes  contents
        // --------  ---------------------------------------------------------
        public byte BytesInRecord { get; protected set; }
        //    1      R, the number of bytes in the record (which must be even)
        public byte SectorsInExtended { get; protected set; }
        //    1      0 [number of sectors in extended attribute record]
        public uint FirstSector { get; protected set; }
        //    8      number of the first sector of file data or directory
        //             (zero for an empty file), as a both endian double word
        public uint Size { get; protected set; }
        //    8      number of bytes of file data or length of directory,
        //             excluding the extended attribute record,
        //             as a both endian double word

        public DateTime DateTime { get; protected set; }
        //    1      number of years since 1900
        //    1      month, where 1=January, 2=February, etc.
        //    1      day of month, in the range from 1 to 31
        //    1      hour, in the range from 0 to 23
        //    1      minute, in the range from 0 to 59
        //    1      second, in the range from 0 to 59
        //             (for DOS this is always an even number)
        //    1      offset from Greenwich Mean Time, in 15-minute intervals,
        //             as a twos complement signed number, positive for time
        //             zones east of Greenwich, and negative for time zones
        //             west of Greenwich (DOS ignores this field)

        public DirectoryType DirectoryType { get; protected set; }
        //    1      flags, with bits as follows:
        //             bit     value
        //             ------  ------------------------------------------
        //             0 (LS)  0 for a norma1 file, 1 for a hidden file
        //             1       0 for a file, 1 for a directory
        //             2       0 [1 for an associated file]
        //             3       0 [1 for record format specified]
        //             4       0 [1 for permissions specified]
        //             5       0
        //             6       0
        //             7 (MS)  0 [1 if not the final record for the file]
        public byte FileUnitSize { get; protected set; }
        //    1      0 [file unit size for an interleaved file]
        public byte InterlaveGapSize { get; protected set; }
        //    1      0 [interleave gap size for an interleaved file]
        public ushort VolumeSequenceNumber { get; protected set; }
        //    4      1, as a both endian word [volume sequence number]
        public byte IdentifierLength { get; protected set; }
        //    1      N, the identifier length

        public string Identifier { get; protected set; }
        //    N      identifier
        //    P      padding byte: if N is even, P = 1 and this field contains
        //             a zero; if N is odd, P = 0 and this field is omitted
        //R-33-N-P   unspecified field for system use; must contain an even
        //             number of bytes

        #endregion

        public override string ToString() => $"{Identifier} - {DirectoryType}";

        private IEnumerable<DirectoryRecord> GetChildren()
        {
            if (this.IsDirectory)
            {
                var sector = new byte[2048];
                var bufferLen = 0;

                lock (this.disc)
                {
                    disc.Seek(this.FirstSector * this.Size,
                            SeekOrigin.Begin);
                    bufferLen = disc.Read(sector, 0, sector.Length);

                    for (int i = 0; i < bufferLen;)
                    {
                        var directorRecord = new DirectoryRecord(sector,
                                                                 i,
                                                                 disc,
                                                                 this);
                        if (directorRecord.BytesInRecord < 34)
                            break;
                        i += directorRecord.BytesInRecord;
                        yield return directorRecord;
                    }
                }
            }
        }
        private byte[] GetBuffer()
        {
            lock (this.disc)
            {
                disc.Seek(this.FirstSector * 2048, SeekOrigin.Begin);
                var buffer = new byte[this.Size];
                var bufferLen = disc.Read(buffer, 0, (int)this.Size);
                return buffer;
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Stream disc;
        public DirectoryRecord Parent { get; protected set; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DirectoryRecord _root;
        public DirectoryRecord Root
        {
            get
            {
                if (_root == null)
                {
                    if (this.Parent == null)
                        return this;
                    _root = this.Parent.Root;
                }
                return _root;
            }
        }
        public bool IsDirectory
        {
            get { return (this.DirectoryType & DirectoryType.Directory) != 0; }
        }
        public IEnumerable<DirectoryRecord> Children
        {
            get
            {
                if (disc != null && this.IsDirectory)
                    foreach (var item in this.GetChildren())
                        yield return item;
            }
        }
        public byte[] Data
        {
            get
            {
                if (disc == null) return null;
                return this.GetBuffer();
            }
        }
        public string DataBase64
        {
            get
            {
                if (this.Data == null) return null;
                return Convert.ToBase64String(this.Data);
            }
        }

        #region IEnumerable<DirectoryRecord> Members

        public IEnumerator<DirectoryRecord> GetEnumerator()
        {
            if (this.Children == null) return null;
            return this.Children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }
}
