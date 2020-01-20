using System.Collections.Generic;

namespace BinaryDataDecoders.Apple2.Dos33
{
    public class CatalogEntry
    {
        public byte NextCatalogTrack { get; set; }
        public byte NextSectorTrack { get; set; }
        public IEnumerable<FileEntry> FileEntries { get; set; }
    }
}