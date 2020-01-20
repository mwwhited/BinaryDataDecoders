using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BinaryDataDecoders.Apple2.Dos33
{
    public partial class DiskImageCommands
    {
        private readonly Encoding _apple = new Apple2Encoding();

        public VolumeTableOfContents GetVolumeTabpeOfContents(Stream diskImage)
        {
            var diskTracks = 35;
            var trackSectors = 16;
            var sectorLength = 256;

            var trackNumber = 0x11;
            var sectorNumber = 0;


            var vtocLocation = trackNumber * trackSectors * sectorLength + sectorNumber * sectorLength;
            diskImage.Position = vtocLocation;
           // diskImage.rea
            var sector = new byte[sectorLength];
            diskImage.Read(sector, 0, 0);
            return new VolumeTableOfContents
            {
                //Unused0 = sectorSpan[0x00],
                FirstCatalogTrack = sector[0x01],
                FirstCatalogSector = sector[0x02],
                DosReleaseNumber = sector[0x03],
                // Unused4_5 = sectorSpan.Slice(0x04, 0x05 - 0x04 + 1).ToArray(),
                DiskVolumeNumber = sector[0x06],
                // Unused7_26 = sectorSpan.Slice(0x07, 0x26 - 0x07 + 1).ToArray(),
                MaxTrackSectorPair = sector[0x27],
                // Unused28_26 = sectorSpan.Slice(0x28, 0x2f - 0x28 + 1).ToArray(),
                LastAllocatedTrack = sector[0x30],
                DirectionOfAllocation = sector[0x31], // +1 / -1

                //  Unused32_33 = sectorSpan.Slice(0x32, 0x33 - 0x32 + 1).ToArray(),
                NumberOfTracksPerDisk = sector[0x34], //Expect 35
                NumberOfSectorsPerTrack = sector[0x35], //Expect 16
                NumberOfBytesPerSector = BitConverter.ToUInt16(sector, 0x36), //Expect 256
            };
        }

        //private byte[] _data;
        public IEnumerable<CatalogEntry> GetCatalogs(Stream diskImage, VolumeTableOfContents vtoc)
        {
            var catalogTrack = vtoc.FirstCatalogTrack;
            var catalogSector = vtoc.FirstCatalogSector;
            var trackSectors = vtoc.NumberOfSectorsPerTrack;
            var sectorLength = vtoc.NumberOfBytesPerSector;

        nextCatalog:

            var catalogLocation = catalogTrack * trackSectors * sectorLength + catalogSector * sectorLength;

            var catalogSpan = new byte[sectorLength];
            diskImage.Position = catalogLocation;
            diskImage.Read(catalogSpan, 0, 0);
            var catalog = new CatalogEntry
            {
                // Unused0 = catalogSpan[0x0],
                NextCatalogTrack = catalogSpan[0x01],
                NextSectorTrack = catalogSpan[0x02],
                //Unused3_A = sectorSpan.Slice(0x03, 0x0a - 0x03 + 1).ToArray(),

                FileEntries = GetFileEntries(diskImage, catalogSpan, 0x0b, 0x2e, 0x51, 0x74, 0x97, 0xba, 0xdd),

            };

            yield return catalog;

            Console.WriteLine($"Catalog: {catalog}");

            if (catalog.NextCatalogTrack != 0 && catalog.NextSectorTrack != 0)
            {
                catalogTrack = catalog.NextCatalogTrack;
                catalogSector = catalog.NextSectorTrack;
                goto nextCatalog;
            }
        }

        private FileEntry GetFileEntry(Stream diskImage, byte[] file)
        {
            return new FileEntry
            {
                Track = file[0x00],
                Sector = file[0x01],

                IsDeleted = file[0x00] == 0xff,
                OriginalTrack = (byte)(file[0x00] == 0xff ? file[0x20] : 0x00),

                FileType = (AppleFileType)file[0x02],
                /*                            
                   Hex 80+file type - file is locked
                       00+file type - file is not locked
                       00 - TEXT file
                       01 - INTEGER BASIC file
                       02 - APPLESOFT BASIC file
                       04 - BINARY file
                       08 - S type file
                       10 - RELOCATABLE object module file
                       20 - A type file
                       40 - B type file
                   (thus, 84 is a locked BINARY file, and 90 is a locked R type file)
                 */

                Name = _apple.GetString(file, 0x03, 30),
                //Remove the bit 0x80 from characters as they only support 7 bit ... will have to put it back to write

                FileSize = BitConverter.ToUInt16(file, 0x21),
            };
        }


        public IEnumerable<FileEntry> GetFileEntries(Stream diskImage, byte[] catalogSpan, params byte[] offsets)
        {
            foreach (var offset in offsets)
            {
                var entry = GetFileEntry(diskImage, catalogSpan.AsSpan().Slice(offset, 23).ToArray());

                yield return entry;
            }
        }
    }
}
