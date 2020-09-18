

```csharp
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO.Ports;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public static class ToolsEx
    {
        public static decimal ToNumber(this byte[] buffer, int offset, decimal mag = 1m) =>
             (
                 buffer[offset] +
                 ((buffer[offset + 1]) << 8) +
                 ((buffer[offset + 2]) << 16) +
                 ((buffer[offset + 3]) << 24)
             ) / mag;
        public static ushort ToUShort(this byte[] buffer, int offset) =>
             (ushort)(
                 buffer[offset] +
                 ((buffer[offset + 1]) << 8)
             );

        public static string ToHexString(this byte[] buffer, int length) =>
             buffer.Take(length)
                   .Aggregate(new StringBuilder(), (sb, v) => sb.Append(v.ToString("X2")))
                   .ToString();
    }
    class Program
    {
        // >: 7BFF 2000 _600 1800 ____ 4600 __08 _C00 F3F7
        // <: 7AFF 2080 1600 1800 ____ 3680 __08 ____ _C00 ____ 1200 ____ 1200 ____ 1500 ____ BAF7
        static readonly byte[] readBasic = new byte[] {
            0x7B, 0xFF, // prefix?
            0x20, 0x00, // 0x2000 = read request?
            0x06, 0x00, // 0x0600 = read data 
                0xFF, 0xFF, // index
            0x00, 0x00, // not sure
                0xFF, 0xFF, // check sum (65630 - index ... if < 65535 then --)
            0x00, 0x08, // 0x0008 get simple data request
            0x0C, 0x00, // not sure
                0xFF, 0xFF, // check sum
        };
        static readonly byte[] readConfig = new byte[] {
            0x7B, 0xFF, // prefix?
            0x20, 0x00, // 0x2000 = read request?
            0x06, 0x00, // 0x0600 = read data 
                0xFF, 0xFF, // index
            0x00, 0x00, // not sure
                0xFF, 0xFF, // check sum (65630 - index ... if < 65535 then --)
            0x01, 0x08, // 0x0108 get config data request
            0x0C, 0x00, // not sure
                0xFF, 0xFF, // check sum
        };

        // SN: 180620-0840-008344 v1.8
        // 7AFF 2080 1E00 B100 ____ 957F _100 ____ 1400 ____ 11A4 ____ 9820 ____ 1400 _612 _108 4803 _800 ____ D61D
        //                                                            8344                     0840
        static readonly byte[] readSerialNumber = new byte[] {
            0x7B, 0xFF, // prefix?
            0x20, 0x00, // 0x2000 = read request?
            0x06, 0x00, // 0x0600 = read data 
                0xFF, 0xFF, // index
            0x00, 0x00, // not sure
                0xFF, 0xFF, // check sum (65630 - index ... if < 65535 then --)
            0x01, 0x00, // 0x0100 not sure
            0x0C, 0x00, // not sure
                0xFF, 0xFF, // check sum
        };

        //7BFF 2000 1000 _E00 ____ 4600 _208 _E00 _500 ____ __0A ____ ____ EAED
        static readonly byte[] writeSettings = new byte[] {
            0x7B, 0xFF, // prefix?
            0x20, 0x00, // 0x2000 = read request?
            0x10, 0x00, // 0x1000 = write data 
                0xFF, 0xFF, // index
            0x00, 0x00, // not sure
                0xFF, 0xFF, // check sum (65630 - index ... if < 65535 then --)
            0x02, 0x08, // 0x0208 not sure
            0x0E, 0x00, // 0x0e00 not sure
            0x05, 0x00, // 0x0500 not sure
            0x00, 0x00, // not sure
                0x03, // Flags
                0xFF, 0xFF,// threshold
            0x00, // not sure
                0xFF, 0xFF, // check sum
        };

        private static byte[] WriteSettings(AlarmSettings alarm, decimal threshold)
        {
            var value = (ushort)((int)(Math.Max(Math.Min(threshold, 10), 0) * 100m) & 0xffff);

            var buffer = writeSettings.ToArray();
            buffer[20] = (byte)((int)alarm & 0x0f);
            ApplyValue(buffer, value, 21);

            var inputs =
                buffer.ToUShort(12) +
                buffer.ToUShort(14) +
                buffer.ToUShort(16) +
                buffer.ToUShort(18) +
                buffer.ToUShort(20) +
                buffer.ToUShort(22)
                ;
            var check = (65535 - inputs);
            var masked = (ushort)(check & 0xffff);

            ApplyValue(buffer, masked, 24);

            return buffer;
        }

        private static ushort CalculatePacketOffset(ushort packetNumber)
        {
            var check = 65630 - packetNumber;
            if (check <= 65536) check--;
            if (check <= 0) { check = 0; }
            return (ushort)check;
        }

        private static void ApplyValue(byte[] buffer, ushort value, int offset)
        {
            buffer[offset] = (byte)(value & 0xff);
            buffer[offset + 1] = (byte)((value & 0xff00) >> 8);
        }

        [Flags]
        public enum AlarmSettings
        {
            Off = 0x00,
            Audio = 0x02,
            Vibrate = 0x01,
        }


        static decimal threshold = 0.3m;
        static (byte[], bool) GetPacket(ushort packetNumber)
        {
            switch (packetNumber % 10)
            {
                case 4:
                case 8:
                    return (readConfig, true);

                //case 5:
                //case 6:
                //case 7:
                //    return (WriteSettings(AlarmSettings.Audio, threshold), false);

                case 9:
                    threshold = threshold + 0.1m;
                    if (threshold > 10 || threshold < 0) threshold = 0m;
                    goto default;

                default:
                    return (readBasic, true);
            }
        }

        static void Main(string[] args)
        {
            var buffer = new byte[128];

            ushort packetNumber = 0;
            using (var port = new SerialPort("COM3", 9600))
            {
                port.Open();

                while (true)
                {
                    // var request = readSerialNumber;
                    // var request = packetNumber % 5 == 0 ? readConfig : readBasic;
                    var (request, applyCheck) = GetPacket(packetNumber);

                    ApplyValue(request, packetNumber, 6);
                    var check = CalculatePacketOffset(packetNumber);
                    ApplyValue(request, check, 10);
                    //Console.Write("O: " + ((packetNumber + check) & 0xffff) + "\t");

                    if (applyCheck)
                    {
                        var checkSum = (ushort)(65535 - request.ToUShort(12) - request.ToUShort(14));
                        ApplyValue(request, checkSum, 16);
                    }

                    Console.Write("<: " + request.ToHexString(request.Length) + "\t");
                    port.Write(request, 0, request.Length);

                    var readLength = port.Read(buffer, 0, buffer.Length);
                    Console.Write(">: " + buffer.ToHexString(readLength) + "\t");

                    if (readLength > 0 &&
                        buffer[0] == 0x7a && buffer[1] == 0xff &&
                        buffer[2] == 0x20 && buffer[3] == 0x80
                        )
                    {
                        if (buffer[4] == 0x16 && buffer[5] == 0x00) // response from 0x0600:0008
                        {
                            var ambient = buffer.ToNumber(20, 100m);
                            var accumulated = buffer.ToNumber(24, 100m);
                            var cpm = buffer.ToNumber(28);

                            Console.Write("D: " + string.Join("\t", ambient, accumulated, cpm));
                        }
                        else if (buffer[4] == 0x10 && buffer[5] == 0x00) // response from 0x0600:0108
                        {
                            var flag = (AlarmSettings)(buffer[20]);
                            var threshhold = buffer.ToNumber(21, 100m);

                            Console.Write("\tS: " + string.Join("\t", threshhold, flag));
                        }

                        //FF7A 8020 __16 __18 ____ 8036 _800 ____ __0C ____ __12 ____ __12 ____ __15 ____ F7BA
                        //7aff 2080 1600 a600 0000 a87f 0008 0000 0c00 0000 0d00 0000 0000 0000 1400 0000 d2f7
                        //7aff 2080 1e00 0200 0000 4480 0100 0000 1400 0000 11a4 0000 9820 0000 1400 0612 0108 4803 0800 0000 d61d
                    }
                    Console.WriteLine();
                    Thread.Sleep(500);
                    packetNumber = (ushort)(packetNumber == ushort.MaxValue ? 1 : packetNumber + 1);
                }

            }

        }
    }
}

// SN: 180620-0840-008344 v1.8
// 7AFF 2080 1E00 B100 ____ 957F _100 ____ 1400 ____ 11A4 ____ 9820 ____ 1400 _612 _108 4803 _800 ____ D61D
//                                                            8344                     0840

```