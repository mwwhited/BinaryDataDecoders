using System;
using System.Collections.Generic;
using System.IO;

namespace BinaryDataDecoders.Apple2.Dos33
{
    public class DiskImageCommands : IDiskImageCommands
    {
        public VolumeTableOfContents GetVolumeTableOfContents(Stream diskImage)
        {
            //var diskTracks = 35;
            var trackSectors = 16;
            var sectorLength = 256;

            var trackNumber = 0x11;
            var sectorNumber = 0;

            var vtocLocation = trackNumber * trackSectors * sectorLength + sectorNumber * sectorLength;
            diskImage.Position = vtocLocation;
            var sector = new byte[sectorLength];
            Span<byte> sectorSpan = sector;
            diskImage.Read(sectorSpan);

            var vtoc = new VolumeTableOfContents(sectorSpan);
            return vtoc;
        }

        public IEnumerable<CatalogEntry> GetCatalogs(Stream diskImage)
        {
            var vtoc = GetVolumeTableOfContents(diskImage);

            var catalogTrack = vtoc.FirstCatalogTrack;
            var catalogSector = vtoc.FirstCatalogSector;
            var trackSectors = vtoc.NumberOfSectorsPerTrack;
            var sectorLength = vtoc.NumberOfBytesPerSector;

            var buffer = new byte[sectorLength];
        nextCatalog:

            Span<byte> catalogSpan = buffer;
            var catalogLocation = catalogTrack * trackSectors * sectorLength + catalogSector * sectorLength;

            diskImage.Position = catalogLocation;
            diskImage.Read(catalogSpan);
            var catalog = new CatalogEntry(catalogSpan);
            yield return catalog;

            if (catalog.NextCatalogTrack != 0 && catalog.NextSectorTrack != 0)
            {
                catalogTrack = catalog.NextCatalogTrack;
                catalogSector = catalog.NextSectorTrack;
                goto nextCatalog;
            }
        }
    }
}
