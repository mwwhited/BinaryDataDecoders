using System;
using System.IO;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.ToolKit.IO
{
    public sealed class TempFileHandle : ITempFile
    {
        public string FilePath { get; }

        public TempFileHandle() => FilePath = Path.GetTempFileName();

        public override string ToString() => FilePath;

        ~TempFileHandle() => Dispose(false);

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!File.Exists(FilePath)) return;

            try
            {
                File.Delete(FilePath);
            }
            catch
            {
                //Note: yeah, I don't care why it failed.
                if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    throw;

                try
                {
                    NativeWin32Methods.MoveFileEx(FilePath, null, NativeWin32Methods.MoveFileFlags.DelayUntilReboot);
                    //scheduled for reboot so good to go
                    return;
                }
                catch
                {
                    //yep, another.  it's just a temp file give up it it doesn't work.  
                }

                //something happen above so throw the original exception.
                throw;
            }
        }
    }
}
