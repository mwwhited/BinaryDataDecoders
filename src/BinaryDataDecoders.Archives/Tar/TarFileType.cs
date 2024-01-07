using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryDataDecoders.Archives.Tar;

public enum TarFileType : byte
{
    File = (byte)'0',
    FileOld = (byte)'\0',
    HardLink = (byte)'1',
    SymbolicLink = (byte)'2',
    CharacterDevice = (byte)'3',
    BlockDevice = (byte)'4',
    Directory = (byte)'5',
    NamedPipe = (byte)'6',
    ContiguousFile = (byte)'7',

    LongSymbolicLink = (byte)'K',
    LongName = (byte)'L',
    SparseFile = (byte)'S',
    Volume = (byte)'V',
}
