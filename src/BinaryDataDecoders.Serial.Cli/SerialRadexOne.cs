using BinaryDataDecoders.IO.Messages;
using BinaryDataDecoders.IO.Pipelines;
using BinaryDataDecoders.IO.Ports;
using BinaryDataDecoders.Quarta.RadexOne;
using BinaryDataDecoders.ToolKit;
using System;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Serial.Cli
{


    [SerialPort(9600)]
    public class RadexOneFactory
    {
        private readonly IMessageDecoder<IRadexObject> _decoder = new RadexOneDecoder();

        public ISegmenter GetSegmenter(OnMessageReceived<IRadexObject> received) =>
              Segment.StartsWith(0x7a)
                     .AndIsLength(12)
                     .ExtendedWithLengthAt<ushort>(4, Endianness.Little)
                     .WithOptions(SegmentionOptions.SkipInvalidSegment)
                     .ThenAs(_decoder, received);
    }

    public class SerialRadexOne
    {
        public static void Execute()
        {
            var factory = new RadexOneFactory();
            var encoder = new MessageEncoder();

            var segmenter = factory.GetSegmenter(data =>
            {
                Console.WriteLine(data);
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
                      uint x = 0;
                      while (!cts.IsCancellationRequested)
                      {
                          x++;
                          try
                          {
                              var requestObject = (x % 10) switch
                              {
                                  1 => (IRadexObject)new ReadSerialNumberRequest(x),
                                  // 2 => new ReadSerialNumberRequest(x),

                                  // 3 => new DevicePing(x),
                                  // 0 => new DevicePing(x),

                                  // 4 => new WriteSettingsRequest(x, AlarmSettings.Audio | AlarmSettings.Vibrate, 10),
                                  // 5 => new WriteSettingsRequest(x, AlarmSettings.Audio | AlarmSettings.Vibrate, 10),
                                  // 6 => new WriteSettingsRequest(x, AlarmSettings.Audio | AlarmSettings.Vibrate, 10),
                                  // 4 => new WriteSettingsRequest(x, AlarmSettings.Audio, 30),
                                  7 => new ReadSettingsRequest(x),

                                  //8 => new ResetAccumulatedRequest(x),

                                  _ => new ReadValuesRequest(x)
                              };
                              var requestBuffer = encoder.Encode(ref requestObject);

                              //7BFF 2000 _600 1800 ____ 4600 __08 _C00 F3F7
                              await port.BaseStream.WriteAsync(requestBuffer, cts.Token);
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
