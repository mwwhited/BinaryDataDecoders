using BinaryDataDecoders.IO.Ports;
using BinaryDataDecoders.IO.UsbHids;
using BinaryDataDecoders.ToolKit;
using HidSharp;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Velleman.K8055
{

    [UsbHid(vendorId: 0x10cf, productId: 0x5500, ProductMask = 0xfff8)]
    public class K8055Controller
    {
        public void Start(CancellationTokenSource cts, byte deviceAddress)
        {
            deviceAddress &= 0x03;

            while (!cts.IsCancellationRequested)
            {
                Console.WriteLine("Velleman: Starting");
                try
                {
                    // https://github.com/rm-hull/k8055/blob/598b236d807aa060f9d9ee774fa2c202c99ed3cb/README.md
                    // http://libk8055.sourceforge.net/
                    var devices = DeviceList.Local
                                           .GetAllDevices()
                                           .OfType<HidDevice>();
                    var device = devices.FirstOrDefault(d => d.VendorID == 0x10cf && d.ProductID == 0x5500 + deviceAddress);
                    //\\?\hid#vid_10cf&pid_5503#7&2ebcec2&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}

                    var writeBuffer = new byte[8];
                    writeBuffer[1] = 0x05; // CMD_SET_ANALOG_DIGITAL 
                    writeBuffer[2] = 0x01; //Output1
                    //writeBuffer[3] = 0xff;
                    //writeBuffer[4] = 0xff;
                    //writeBuffer[5] = 0xff;
                    //writeBuffer[6] = 0xff;
                    //writeBuffer[7] = 0xff;
                    //writeBuffer[8] = 0xff;

                    var readBuffer = new byte[9];
                    var last = "";

                    if (device != null && device.TryOpen(out var stream))
                    {
                        while (!cts.IsCancellationRequested)
                        {
                            stream.Write(writeBuffer);
                            var read = stream.Read(readBuffer, 0, readBuffer.Length);
                            var response = MemoryMarshal.Cast<byte, K8055Response>(readBuffer);
                            var hex = readBuffer.Take(read).ToHexString("-");
                            var ret = response[0];
                            if (hex != last)
                            {
                                Debug.WriteLine(ret.ToString());
                            }
                            last = hex;

                            /*
                            03 00 00 00 00 00 08 01  => reset counter 1 (10ms, 0ms)
                            04 00 00 00 00 00 08 01  => reset counter 2 (10ms, 0ms)
                            05 01 00 00 00 00 08 01  => digital out 1 (10ms, 0ms)
                            05 03 00 00 00 00 08 01  => digital out 1+2 (10ms, 0ms)
                            05 ff 00 00 00 00 08 01  => digital out all (10ms, 0ms)
                            05 ff ff ff 00 00 08 01  => digital out all + analog1,2 (10ms, 0ms)
                            05 ff ff 00 00 00 08 01  => digital out all + analog1 = 255,2=0 (10ms, 0ms)
                            05 ff ff 00 00 00 01 01  => digital out all + analog1 = 255,2=0 (0ms, 0ms)
                            05 ff ff 00 00 00 58 58  => digital out all + analog1 = 255,2=0 (1000ms, 1000ms)
                            06 00 00 00 00 00 08 01  => ? read ?
                            */

                            Thread.Sleep(100);
                            if (writeBuffer[2] == 0x00)
                            {
                                writeBuffer[2] = 0x01;
                            }
                            else
                            {
                                writeBuffer[2] = (byte)((writeBuffer[2] << 1) & 0xff);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"BusylightProvider: ERROR: {ex}");
                }
                //  await TaskEx.Delay(5000, cts);
            }
            Console.WriteLine("BusylightProvider: Closing");
        }
    }
}
