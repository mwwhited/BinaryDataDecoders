using BinaryDataDecoders.IO.UsbHids;
using HidSharp;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Kuando.Busylight
{
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
                        await stream.WriteAsync(new byte[]
                        {
                                        0,
                                        0x10, 0x01,
                                        0x00,0x00,0x00, //R,G,B
                                        0x01,0x00,0x80, //color change suffix
                        }, 0, 9);

                        await Task.Delay(50);
                        byte soundByte = 0; // (byte)(0x80 | (x << 3) | 0x01);
                        Debug.WriteLine($"{x}:{soundByte}:{soundByte:x2}");

                        var request = new byte[]
                        {
                                        0x00, //step number
                                        0x10, //next step
                                        0x00, //repeat interval    
                                        0x00, 0xff, 0x00, //R,G,B
                                        0x0f /* len on count*/,0x0f/* led off count */,
                                        soundByte,
                                        0,0,0,0,0,0,0,0
                            /*
                             * 8 = play audio = 1 for yes, 0 for no
                             * 7..4 => track to play (only values 0 to 8 are defined on my version)
                             * 3..1 => Volume (0 to 7)
                             */
                        }.Take(16)
                        .Concat(new byte[]
                        {
                                        0x01, //padding
                                        0x20, 0x00,     //color prefix?
                                        0xff, 0x00, 0x00, //R,G,B
                                        0x0f /* len on count*/,0x0f/* led off count */,
                                        soundByte,
                                        0,0,0,0,0,0,0,0
                            /*
                             * 8 = play audio = 1 for yes, 0 for no
                             * 7..4 => track to play (only values 0 to 8 are defined on my version)
                             * 3..1 => Volume (0 to 7)
                             */
                        }.Take(16))
                        .Concat(new byte[]
                        {
                                        0x02, //padding
                                        0x30, 0x00,     //color prefix?
                                        0x00, 0x00, 0xff, //R,G,B
                                        0x0f /* len on count*/,0x0f/* led off count */,
                                        soundByte,
                                        0,0,0,0,0,0,0,0
                            /*
                             * 8 = play audio = 1 for yes, 0 for no
                             * 7..4 => track to play (only values 0 to 8 are defined on my version)
                             * 3..1 => Volume (0 to 7)
                             */
                        }.Take(16))
                        .Concat(new byte[91]).Take(64).ToArray();

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
}
