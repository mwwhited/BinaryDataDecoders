using System.Collections.Generic;
using System.IO;

namespace BinaryDataDecoders.Apple2.Dos33
{
    public interface IDiskImageCommands
    {
        IEnumerable<CatalogEntry> GetCatalogs(Stream diskImage);
        VolumeTableOfContents GetVolumeTableOfContents(Stream diskImage);
        IEnumerable<TrackSectorList> GetTrackSectorListForFileEntry(Stream diskImage, FileEntry fileEntry);
    }
}