//using System;
//using System.IO.Ports;
//using System.Linq;
//using System.Threading.Tasks;

//namespace BinaryDataDecoders.Zoom.H4n
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //Console.WriteLine("Com port name?");
//            var comport = "com3"; // Console.ReadLine();

//            using (var h4n = new SerialPort(comport, 2400))
//            {
//                h4n.Open();

//                var doingWork = true;
//                var pauseRead = false;
//                var missed = 0;
//                byte last = 0;
//                var lastCmd = H4nRequests.None;

//                Func<H4nRequests, Task> send = async r =>
//                {
//                    if (r != H4nRequests.Poll)
//                    {
//                        if (lastCmd == r)
//                        {
//                            Console.Write($".");
//                        }
//                        else
//                        {
//                            Console.WriteLine($"< {r}");
//                        }
//                        lastCmd = r;
//                    }

//                    var buffer = new byte[] { (byte)(((ushort)r & 0xff00) >> 8), (byte)(((ushort)r & 0x00ff)), 0x80, 0x00 };

//                    h4n.BaseStream.WriteByte(buffer[0]);
//                    await h4n.BaseStream.FlushAsync();
//                    h4n.BaseStream.WriteByte(buffer[1]);
//                    await h4n.BaseStream.FlushAsync();
//                    await Task.Delay(125);
//                    h4n.BaseStream.WriteByte(buffer[2]);
//                    await h4n.BaseStream.FlushAsync();
//                    h4n.BaseStream.WriteByte(buffer[3]);
//                    await h4n.BaseStream.FlushAsync();
//                };
//                Func<Task> startup = async () =>
//                {
//                    pauseRead = true;
//                    do
//                    {
//                        do
//                        {
//                            h4n.BaseStream.WriteByte(0x00);
//                            await h4n.BaseStream.FlushAsync();
//                            await Task.Delay(30);
//                            Console.Write('+');
//                        }
//                        while (h4n.BytesToRead < 4);
//                        Console.Write('*');

//                        var buffer = new byte[h4n.BytesToRead];
//                        h4n.BaseStream.Read(buffer, 0, buffer.Length);
//                        if (buffer.Any(b => (0x7f & b) > 0)) break;

//                        h4n.BaseStream.WriteByte(0xa1);
//                        await h4n.BaseStream.FlushAsync();
//                        h4n.BaseStream.WriteByte(0x80);
//                        await h4n.BaseStream.FlushAsync();
//                        h4n.BaseStream.WriteByte(0x00);
//                        await h4n.BaseStream.FlushAsync();
//                    } while (true);
//                    Console.WriteLine('@');

//                    pauseRead = false;
//                };

//                Task.WaitAll(
//                    Task.Run(async () =>
//                    {
//                        while (doingWork)
//                        {
//                            //reader
//                            var toRead = h4n.BytesToRead;
//                            if (toRead > 0 && !pauseRead)
//                            {
//                                var buffer = new byte[toRead];
//                                var read = h4n.Read(buffer, 0, buffer.Length);
//                                var status = string.Join(";", buffer.Where(b => (b & 0x7f) != 0).Select(b => (H4nStatus)(b)).Distinct());
//                                if (string.IsNullOrWhiteSpace(status))
//                                {
//                                    await startup();
//                                }
//                                else
//                                {
//                                    missed = 0;
//                                    if (last != buffer.Last())
//                                    {
//                                        Console.WriteLine($"> {status}");
//                                        lastCmd = H4nRequests.None;
//                                    }
//                                    last = buffer.Last();
//                                }
//                            }
//                            else
//                            {
//                                missed++;
//                            }
//                            if (missed % 40 == 3)
//                            {
//                                last = 0;
//                                Console.WriteLine("Lost Contract!");
//                                lastCmd = H4nRequests.None;
//                            }
//                            await Task.Delay(250);
//                        }
//                    }),
//                    Task.Run(async () =>
//                    {
//                        while (doingWork)
//                        {
//                            if (!pauseRead)
//                                h4n.BaseStream.WriteByte(0x00);
//                            await Task.Delay(500);
//                        }
//                    }),
//                    Task.Run(async () =>
//                    {

//                        while (doingWork)
//                            switch (Console.ReadKey(true).Key)
//                            {
//                                case ConsoleKey.Escape:
//                                    doingWork = false; break;

//                                case ConsoleKey.UpArrow:
//                                    await send(H4nRequests.VolumeUp); break;
//                                case ConsoleKey.DownArrow:
//                                    await send(H4nRequests.VolumnDown); break;

//                                case ConsoleKey.LeftArrow:
//                                    await send(H4nRequests.Rewind); break;
//                                case ConsoleKey.RightArrow:
//                                    await send(H4nRequests.FastForward); break;

//                                case ConsoleKey.M:
//                                    await send(H4nRequests.Mic); break;
//                                case ConsoleKey.D1:
//                                    await send(H4nRequests.Channel1); break;
//                                case ConsoleKey.D2:
//                                    await send(H4nRequests.Channel2); break;

//                                case ConsoleKey.R:
//                                    await send(H4nRequests.Record); break;
//                                case ConsoleKey.S:
//                                    await send(H4nRequests.Stop); break;
//                                case ConsoleKey.P:
//                                    await send(H4nRequests.Play); break;

//                                case ConsoleKey.Q:
//                                    await startup();
//                                    break;

//                                case ConsoleKey.A:
//                                    {
//                                        last = 0;
//                                        h4n.BaseStream.WriteByte(0x00);
//                                        await h4n.BaseStream.FlushAsync();
//                                    }
//                                    break;

//                                default:
//                                    await send(H4nRequests.Poll);
//                                    Console.WriteLine(@"
//===== Help ======
//ESCAPE      : Exit
//UP/DOWN     : Volume Up / Down
//LEFT/RIGHT  : Rewind / Fast Forward
//M/1/2       : Mic / Channel 1 / Channel 2

//Q           : Restart Sequence
//A           : Status Poll

//");
//                                    break;
//                            }
//                        doingWork = false;
//                    })
//                );
//            }
//        }
//    }

//    [Flags]
//    public enum H4nStatus : byte
//    {
//        Record = 0x01,
//        Peak = 0x02,
//        Mic = 0x10,
//        Led1 = 0x20,
//        Led2 = 0x40,
//    }
//    public enum H4nRequests : ushort
//    {
//        None = 0,

//        Mic = 0x8001,
//        Channel1 = 0x8002,
//        Channel2 = 0x8004,
//        VolumeUp = 0x8008,
//        VolumnDown = 0x8010,
//        Record = 0x8100,
//        Play = 0x8200,
//        Stop = 0x8400,
//        FastForward = 0x8800,
//        Rewind = 0x9000,

//        Poll = 0x8000,
//    }
//}
