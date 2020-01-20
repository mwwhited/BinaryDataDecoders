namespace BinaryDataDecoders.Apple2.Dos33
{
    public class VolumeTableOfContents
    {
        public byte FirstCatalogTrack { get; internal set; }
        public byte FirstCatalogSector { get; set; }
        public byte DosReleaseNumber { get; set; }
        public byte DiskVolumeNumber { get; set; }
        public byte MaxTrackSectorPair { get; set; }
        public byte LastAllocatedTrack { get; set; }
        public byte DirectionOfAllocation { get; set; }
        public byte NumberOfTracksPerDisk { get; set; }
        public byte NumberOfSectorsPerTrack { get; set; }
        public ushort NumberOfBytesPerSector { get; set; }
    }
}