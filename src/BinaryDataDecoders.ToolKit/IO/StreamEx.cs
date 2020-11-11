using System.IO;
using System.Threading.Tasks;

namespace BinaryDataDecoders.ToolKit.IO
{
    public static class StreamEx
    {
        public static async Task<ITempFile> AsTempFileAsync(this Stream stream)
        {
            var temp = new TempFileHandle();
            using var fs = File.OpenWrite(temp.FilePath);
            await stream.CopyToAsync(fs).ConfigureAwait(false);
            fs.Close();
            return temp;
        }

        public static ITempFile AsTempFile(this Stream stream)
        {
            var temp = new TempFileHandle();
            using var fs = File.OpenWrite(temp.FilePath);
            stream.CopyTo(fs);
            fs.Close();
            return temp;
        }
    }
}
