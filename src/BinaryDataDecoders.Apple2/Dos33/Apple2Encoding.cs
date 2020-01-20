using System.Linq;
using System.Text;

namespace BinaryDataDecoders.Apple2.Dos33
{
    public partial class DiskImageCommands
    {
        public class Apple2Encoding : ASCIIEncoding
        {
            public override string GetString(byte[] bytes, int byteIndex, int byteCount)
            {
                return base.GetString(bytes.Select(c => (byte)(c & 0x7f)).ToArray(), byteIndex, byteCount);
            }
        }
    }
}
