using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryDataDecoders.IO
{
    public interface IDeviceDefinitionInitialize
    {
        Task InitializeAsync(IDeviceAdapter device, CancellationToken token);
    }
}
