using BinaryDataDecoders.Apple2.Text;
using System;

namespace BinaryDataDecoders.Apple2.Dos33;

/// <summary>
/// FILE DESCRIPTIVE ENTRY FORMAT 
/// 
/// Each file descriptive entry contains a total of 35 ($23) bytes. The relative byte is the 
/// number starting at the beginning of each file descriptive entry.
/// </summary>
public readonly struct FileEntry(ReadOnlySpan<byte> span)
{

    /// <summary>
    /// Track of first track/sector list sector.  If this is a deleted file, this byte contains $FF
    /// and the original track number is copied to last byte of the file name field(BYTE $20).  If this
    /// byte contains a $00, the entry is assumed to have never been used and is available for use.
    /// (This means that track 0 can never be used for data entry if the DOS image is wiped off the diskette.)
    /// </summary>
    public readonly byte Track = span[0x00];

    /// <summary>
    /// Sector of the first track/sector list sector
    /// </summary>
    public readonly byte Sector = span[0x01];

    /// <summary>
    /// File type and sector flags:
    ///   $80 + file type - file is locked
    ///   $00 + file type - file is not locked
    ///   $00 - TEXT file
    ///   $01 - INTEGER BASIC file
    ///   $02 - APPLESOFT BASIC file
    ///   $04 - BINARY file
    ///   $08 - S type file
    ///   $10 - RELOCATABLE object module file
    ///   $20 - A type file
    ///   $40 - B type file
    ///   (Thus, $84 is a locked BINARY file, and $90 is a locked R type file.)
    /// </summary>
    public readonly AppleFileType FileType = (AppleFileType)span[0x02];

    /// <summary>
    /// File name (30 characters) ... actually 29.. $20 is reserved for "OriginalTrack"
    /// </summary>
    public readonly string Name = Apple2Encoding.Apple2.GetString(span.Slice(0x03, 29));

    /// <summary>
    /// If the file is deleted the original track location is stored here
    /// </summary>
    public readonly byte OriginalTrack = span[0x20];

    /// <summary>
    ///  Length of the file in sectors (LO/HI format). The CATALOG command will only format the
    ///  LO byte of this length giving 1-255, but a full 65535 may be stored here.
    /// </summary>
    public readonly ushort FileSize = BitConverter.ToUInt16(span.Slice(0x21, 2));

    /// <summary>
    /// Simple mapping to the deleted flag in FileType
    /// </summary>
    public bool IsDeleted => Track == 0xff;
    /// <summary>
    /// file is readonly
    /// </summary>
    public bool IsLocked => FileType.HasFlag(AppleFileType.Locked);
    /// <summary>
    /// file does not exist
    /// </summary>
    public bool Exists => Track != 0x00 && Track != 0xff;

    public override string ToString() => $"\"{Name}\" - {FileType} ({Track}/{Sector}) {FileSize}S";
}