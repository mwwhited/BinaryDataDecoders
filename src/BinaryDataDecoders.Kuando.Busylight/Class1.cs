using BinaryDataDecoders.IO.UsbHids;
using HidSharp;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Kuando.Busylight;


[UsbHid(0x04d8, 0xf848)]
public class Class1
{
    public async Task Start(CancellationTokenSource cts)
    {
        var device = DeviceList.Local
                               .GetAllDevices()
                               .OfType<HidDevice>()
                               .FirstOrDefault(d => d.VendorID == 0x04d8 && d.ProductID == 0xf848);

        if (device != null && device.TryOpen(out var stream))
        {
            var x = 0;
            while (!cts.IsCancellationRequested)
            {
                try
                {
                    // light off + stop music
                    await stream.WriteAsync(
                    [
                                    0,
                                    0x10, 0x01,
                                    0x00,0x00,0x00, //R,G,B
                                    0x01,0x00,0x80, //color change suffix
                    ], 0, 9);

                    await Task.Delay(50);
                    byte soundByte = 0; // (byte)(0x80 | (x << 3) | 0x01);
                    Debug.WriteLine($"{x}:{soundByte}:{soundByte:x2}");

                    //var bytes = new List<byte[]>()
                    //{
                    //    { new byte[]{0x00, 0x01,0x01, 0xff,0x00,0x00,  0x05, 0x00, 0x80 } },
                    //    { new byte[]{0x01, 0x00,0x01, 0x00,0xff,0x00,  0x05, 0x00, 0x80 } },
                    //};

                    //var buffer = (from c in bytes
                    //              from b in c.Concat(new byte[16]).Take(16)
                    //              select b).Concat(new byte[64]).Take(64);

                    //var request = buffer.ToArray();

                    var request = new byte[]
                    {
                        00,

                        0x01,0x01,0xff,0x00,0x00,0x05,0x00,0x00,
                        0x02,0x01,0xff,0xff,0x00,0x05,0x00,0x00,
                        0x03,0x01,0x00,0xff,0x00,0x05,0x00,0x00,
                        0x04,0x01,0x00,0xff,0xff,0x05,0x00,0x00,
                        0x05,0x01,0x00,0x00,0xff,0x05,0x00,0x00,
                        0x00,0x01,0xff,0x00,0xff,0x05,0x00,0x00,

                        0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,

                        0x06,0x04,0x55,0xff,0xff,0xff,0x86,0x0c
                    };

                    //flash green no sound
                    await stream.WriteAsync(request, 0, request.Length);

                }
                catch (Exception ex)
                {
                    await Console.Error.WriteLineAsync($"BusylightProvider: ERROR: {ex}");
                }
                x++;
                //if (x > 15)
                break;
                // await Task.Delay(1000);
            }
            Console.WriteLine("BusylightProvider: Closing");
        }
    }
}
