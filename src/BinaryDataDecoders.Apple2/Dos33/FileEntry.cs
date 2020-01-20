namespace BinaryDataDecoders.Apple2.Dos33
{
    public class FileEntry
    {
        public byte Sector { get; internal set; }
        public byte Track { get; internal set; }
        public bool IsDeleted { get; internal set; }
        public byte OriginalTrack { get; internal set; }
        public AppleFileType FileType { get; internal set; }
        public string Name { get; internal set; }
        public object FileSize { get; internal set; }
    }
}