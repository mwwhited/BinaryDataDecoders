using HidSharp;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Kuando.Busylight
{
    public class Class1
    {
        public async Task Start(CancellationTokenSource cts)
        {
            while (!cts.IsCancellationRequested)
            {
                Console.WriteLine("BusylightProvider: Starting");
                try
                {
                    var device = DeviceList.Local
                                           .GetAllDevices()
                                           .OfType<HidDevice>()
                                           .FirstOrDefault(d => d.VendorID == 0x04d8 && d.ProductID == 0xf848);

                    if (device != null && device.TryOpen(out var stream))
                    {
                       // while (!cts.IsCancellationRequested)
                        {
                            await stream.WriteAsync(new byte[]
                            {
                                0,0,0,
                                (byte)(true ? 0x11 : 0x00),0x0,0x00, //R,G,B
                                0,0,0,
                            }, 0, 8);
                            // await TaskEx.Delay(500, cts);
                        }
                    }
                }
                catch (Exception ex)
                {
                    await Console.Error.WriteLineAsync($"BusylightProvider: ERROR: {ex}");
                }
                //  await TaskEx.Delay(5000, cts);
            }
            Console.WriteLine("BusylightProvider: Closing");
        }
    }
}
