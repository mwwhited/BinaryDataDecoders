//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BinaryDataDecoders.Zoom.H4n
//{
//    public class H4nProvider : SerialPortProviderBase
//    {
//        public H4nProvider(string portName)
//            : base(portName, baudRate: 2400)
//        {
//        }

//        private ulong _missed;

//        protected override async Task Poll(Stream stream, CancellationTokenSource cts, Func<int> bytesToRead)
//        {
//            if (!StopReading)
//                stream.WriteByte(0x00);
//            if (_nextWait < DateTime.Now)
//            {
//                _missed++;
//            }

//            if (_missed % 20 == 3)
//            {
//                Console.WriteLine("H4N: Retry Data Channel");
//                await this.Startup(stream, cts, bytesToRead);
//            }

//            var recording = ScoreMachineHub.Recording;
//            if (_requested != recording)
//            {
//                _requested = recording;
//                await Send(stream, recording ? H4nRequests.Record : H4nRequests.Stop, cts);
//            }

//            await Task.FromResult(0);
//        }

//        private bool _requested;
//        private DateTime _nextWait;
//        private byte _lastMessage;
//        private H4nRequests _lastCommand = H4nRequests.None;

//        protected override async Task Received(byte[] readBuffer, Stream stream, CancellationTokenSource cts)
//        {
//            var status = string.Join(";", readBuffer.Where(b => (b & 0x7f) != 0).Select(b => (H4nStatus)(b)).Distinct());
//            if (!string.IsNullOrWhiteSpace(status))
//            {
//                _missed = 0;
//                _nextWait = DateTime.Now.AddMilliseconds(500);
//                var last = readBuffer.Last();
//                if (_lastMessage != last)
//                {
//                    Console.WriteLine($"H4N:> {status}");
//                    _lastCommand = H4nRequests.None;
//                }
//                _lastMessage = last;

//                var recording = ScoreMachineHub.Recording;
//                if (recording && ((H4nStatus)last & H4nStatus.Record) != H4nStatus.Record)
//                {
//                    await Send(stream, H4nRequests.Record, cts);///this needs debounced but whateves
//                }
//                else if (!recording && ((H4nStatus)last & H4nStatus.Record) == H4nStatus.Record)
//                {
//                    await Send(stream, H4nRequests.Stop, cts);
//                }
//            }
//            await Task.FromResult(0);
//        }

//        public async Task Send(Stream stream, H4nRequests command, CancellationTokenSource cts)
//        {
//            if (command != H4nRequests.Poll)
//            {
//                if (_lastCommand == command)
//                {
//                    Console.Write('.');
//                }
//                else
//                {
//                    Console.WriteLine($"< {command}");
//                }
//                _lastCommand = command;
//            }

//            var buffer = new byte[] { (byte)(((ushort)command & 0xff00) >> 8), (byte)(((ushort)command & 0x00ff)), 0x80, 0x00 };

//            stream.WriteByte(buffer[0]);
//            await stream.FlushAsync();
//            stream.WriteByte(buffer[1]);
//            await stream.FlushAsync();
//            await Task.Delay(125);
//            stream.WriteByte(buffer[2]);
//            await stream.FlushAsync();
//            stream.WriteByte(buffer[3]);
//            await stream.FlushAsync();
//        }

//        public async Task Startup(Stream stream, CancellationTokenSource cts, Func<int> bytesToRead)
//        {
//            StopReading = true;
//            do
//            {
//                do
//                {
//                    if (cts.IsCancellationRequested) return;

//                    stream.WriteByte(0x00);
//                    await stream.FlushAsync();
//                    await Task.Delay(30);
//                    Console.Write('+');
//                }
//                while (bytesToRead() < 4);
//                Console.Write('*');

//                var buffer = new byte[bytesToRead()];
//                var read = stream.Read(buffer, 0, buffer.Length);

//                if (buffer.Any(b => (0x7f & b) > 0)) break;

//                stream.WriteByte(0xa1);
//                await stream.FlushAsync();
//                stream.WriteByte(0x80);
//                await stream.FlushAsync();
//                stream.WriteByte(0x00);
//                await stream.FlushAsync();
//            } while (!cts.IsCancellationRequested);
//            Console.WriteLine('@');
//            _nextWait = DateTime.Now.AddMilliseconds(500);
//            StopReading = false;
//        }
//    }
//}
