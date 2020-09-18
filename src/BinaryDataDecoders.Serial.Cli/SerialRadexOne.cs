using BinaryDataDecoders.IO.Pipelines;
using BinaryDataDecoders.Quarta.RadexOne;
using BinaryDataDecoders.ToolKit;
using System;
using System.Buffers;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Serial.Cli
{
    public class RadexOneFactory
    {
        public ISegmenter GetSegmenter(OnSegmentReceived received) =>
              Segment.StartsWith(0x7a).AndIsLength(12).ExtendedWithLengthAt<ushort>(4, Endianness.Little)
          .WithOptions(SegmentionOptions.SkipInvalidSegment).ThenDo(received);

    }
    public class SerialRadexOne
    {
        public static void Execute()
        {
            var factory = new RadexOneFactory();

            var segmenter = factory.GetSegmenter(data =>
           {
               var buffer = data.ToArray();
               var result = buffer.ToHexString();

               if (buffer[4] == 0x16 && buffer[5] == 0x00) // response from 0x0600:0008
               {
                   var ambient = buffer.ToDecimal(20, 100m);
                   var accumulated = buffer.ToDecimal(24, 100m);
                   var cpm = buffer.ToDecimal(28);

                   Console.WriteLine("D: " + string.Join("\t", ambient, accumulated, cpm));
               }
               else if (buffer[4] == 0x10 && buffer[5] == 0x00) // response from 0x0600:0108
               {
                   var flag = (AlarmSettings)(buffer[20]);
                   var threshhold = buffer.ToDecimal(21, 100m);

                   Console.WriteLine("\tS: " + string.Join("\t", threshhold, flag));
               }

               return Task.FromResult(0);
           });

            var ports = SerialPort.GetPortNames().OrderBy(s => s);
            foreach (var port in ports)
                Console.WriteLine(port);

            Console.WriteLine($"Enter Port: (Default { ports.FirstOrDefault()})");
            var portName = Console.ReadLine();
            var serialPort = new PortProvider().GetRadexOnePort(string.IsNullOrWhiteSpace(portName) ? ports.FirstOrDefault() : portName);

            using (var port = serialPort)
            using (var cts = new CancellationTokenSource())
            {
                port.Open();

                Console.Write("Enter to exit");

                Task.WaitAll(
                  Task.Run(async () => await Program.ReadLineAsync().ContinueWith(t => cts.Cancel(false))),
                  Task.Run(async () =>
                  {
                      while (!cts.IsCancellationRequested)
                      {
                          try
                          {
                              await port.BaseStream.Follow().With(segmenter).RunAsync(cts.Token);
                              cts.Cancel(true);
                          }
                          catch (Exception ex)
                          {
                              Console.Error.WriteLine(ex.Message);
                          }
                      }
                  }),
                  Task.Run(async () =>
                  {
                      while (!cts.IsCancellationRequested)
                      {
                          try
                          {
                              var requestBuffer = new byte[] { 0x7B, 0xFF, 0x20, 0x00, 0x06, 0x00, 0x18, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x08, 0x0C, 0x00, 0xF3, 0xF7 };

                              //7BFF 2000 _600 1800 ____ 4600 __08 _C00 F3F7
                              await port.BaseStream.WriteAsync(requestBuffer, 0, requestBuffer.Length, cts.Token);
                          }
                          catch (Exception ex)
                          {
                              Console.Error.WriteLine(ex.Message);
                          }
                          if (!cts.IsCancellationRequested)
                          {
                              await Task.Delay(1000);
                          }
                      }
                  })
                  );
            }
        }
    }
}
