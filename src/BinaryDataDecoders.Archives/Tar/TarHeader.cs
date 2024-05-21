namespace BinaryDataDecoders.Archives.Tar;

public class TarHeader
{
    public string FileName;
    public string FileMode;
    public string OwnerId;
    public string GroupId;
    public int FileSize;
    public int LastModifiedTime;
    public string CheckSum;
    public TarFileType FileType;
    public string LinkedFile;
}
