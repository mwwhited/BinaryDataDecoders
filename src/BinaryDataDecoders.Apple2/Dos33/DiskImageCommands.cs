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

            var track = vtoc.FirstCatalogTrack;
            var sector = vtoc.FirstCatalogSector;
            var trackSectors = vtoc.NumberOfSectorsPerTrack;
            var sectorLength = vtoc.NumberOfBytesPerSector;

            var buffer = new byte[sectorLength];
        next:

            Span<byte> catalogSpan = buffer;
            var location = track * trackSectors * sectorLength + sector * sectorLength;

            diskImage.Position = location;
            diskImage.Read(catalogSpan);
            var item = new CatalogEntry(catalogSpan);
            yield return item;

            if (item.NextCatalogTrack != 0 && item.NextSectorTrack != 0)
            {
                track = item.NextCatalogTrack;
                sector = item.NextSectorTrack;
                goto next;
            }
        }

        public IEnumerable<TrackSectorList> GetTrackSectorListForFileEntry(Stream diskImage, FileEntry fileEntry)
        {
            var vtoc = GetVolumeTableOfContents(diskImage);

            var track = fileEntry.Track;
            var sector = fileEntry.Sector;
            var trackSectors = vtoc.NumberOfSectorsPerTrack;
            var sectorLength = vtoc.NumberOfBytesPerSector;

            var buffer = new byte[sectorLength];
        next:

            Span<byte> span = buffer;
            var location = track * trackSectors * sectorLength + sector * sectorLength;

            diskImage.Position = location;
            diskImage.Read(span);
            var item = new TrackSectorList(span);
            yield return item;

            if (item.NextTrack != 0 && item.NextSector != 0)
            {
                track = item.NextTrack;
                sector = item.NextSector;
                goto next;
            }
        }
    }
}
