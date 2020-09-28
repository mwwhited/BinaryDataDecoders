using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BinaryDataDecoders.Apple2.Dos33
{
    /// <summary>
    /// set of commands for AppleSoft DOS 3.3 disk images.
    /// </summary>
    public class DiskImageCommands : IDiskImageCommands
    {
        /// <summary>
        /// Retrieve Volume table of contents.
        /// </summary>
        /// <param name="diskImage"></param>
        /// <returns></returns>
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
            var read = diskImage.Read(sectorSpan);

            var vtoc = new VolumeTableOfContents(sectorSpan.Slice(0, read));
            return vtoc;
        }

        /// <summary>
        /// Returns list of catalog entries with files
        /// </summary>
        /// <param name="diskImage"></param>
        /// <returns></returns>
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
            var read = diskImage.Read(catalogSpan);
            var item = new CatalogEntry(catalogSpan.Slice(0, read));
            yield return item;

            if (item.NextCatalogTrack != 0 && item.NextSectorTrack != 0)
            {
                track = item.NextCatalogTrack;
                sector = item.NextSectorTrack;
                goto next;
            }
        }

        /// <summary>
        /// Returns list of populated track/sectors for given file
        /// </summary>
        /// <param name="diskImage"></param>
        /// <param name="fileEntry"></param>
        /// <returns></returns>
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
            var read = diskImage.Read(span);
            var item = new TrackSectorList(span.Slice(0, read));
            yield return item;

            if (item.NextTrack != 0 && item.NextSector != 0)
            {
                track = item.NextTrack;
                sector = item.NextSector;
                goto next;
            }
        }

        /// <summary>
        /// retrieve binary data for input file
        /// </summary>
        /// <param name="diskImage"></param>
        /// <param name="fileEntry"></param>
        /// <returns></returns>
        public Span<byte> GetDataFileEntry(Stream diskImage, FileEntry fileEntry)
        {
            var ts = (from trackSectorList in GetTrackSectorListForFileEntry(diskImage, fileEntry)
                      from trackSector in trackSectorList.TrackSectorPairs
                      where trackSector.Track != 0 || trackSector.Sector != 0
                      select (trackSectorList, trackSector)).ToArray();

            var vtoc = GetVolumeTableOfContents(diskImage);
            var trackSectors = vtoc.NumberOfSectorsPerTrack;
            var sectorLength = vtoc.NumberOfBytesPerSector;

            var outputBuffer = new byte[sectorLength * ts.Length];
            Span<byte> outputSpan = outputBuffer;

            for (int i = 0; i < ts.Length; i++)
            {
                if (ts[i].trackSectorList.SectorOffset != 0) throw new NotSupportedException();

                var track = ts[i].trackSector.Track;
                var sector = ts[i].trackSector.Sector;
                var location = track * trackSectors * sectorLength + sector * sectorLength;
                diskImage.Position = location;

                Span<byte> sectorSpan = outputSpan.Slice(i * sectorLength, sectorLength);

                var read = diskImage.Read(sectorSpan);

            }

            return outputSpan;
        }
    }
    internal class MemorySegment<T> : ReadOnlySequenceSegment<T>
    {
        //https://www.stevejgordon.co.uk/creating-a-readonlysequence-from-array-data-in-dotnet
        public MemorySegment(ReadOnlyMemory<T> memory)
        {
            Memory = memory;
        }

        public MemorySegment<T> Append(ReadOnlyMemory<T> memory)
        {
            var segment = new MemorySegment<T>(memory)
            {
                RunningIndex = RunningIndex + Memory.Length
            };

            Next = segment;

            return segment;
        }
    }
}
