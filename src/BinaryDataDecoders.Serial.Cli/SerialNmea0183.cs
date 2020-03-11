using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common;
using BinaryDataDecoders.IO.Pipelines;
using BinaryDataDecoders.Nmea;
using System;
using System.Buffers;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Serial.Cli
{
    public static class SerialNmea0183
    {
        public static void Execute()
        {
            var portProvider = new PortProvider();
            var factory = new Nmea0183Factory();
            var segmenter = factory.GetSegmenter(OnReceived);

            var ports = SerialPort.GetPortNames().OrderBy(s => s);
            foreach (var port in ports)
                Console.WriteLine(port);

            Console.WriteLine($"Enter Port: (Default { ports.LastOrDefault()})");
            var portName = Console.ReadLine();

            using (var port = portProvider.GetNmea0183Port(!string.IsNullOrWhiteSpace(portName) ? portName : ports.LastOrDefault()))
            using (var cts = new CancellationTokenSource())
            {
                port.Open();

                Console.Write("Enter to exit");

                Task.WaitAll(
                  Task.Run(async () => await Program.ReadLineAsync().ContinueWith(t => cts.Cancel(false))),
                  Task.Run(async () => await port.BaseStream.Follow().With(segmenter).RunAsync(cts.Token))
                  );
            }
        }

        private static Task OnReceived(ReadOnlySequence<byte> segment)
        {
            var data = ASCIIEncoding.ASCII.GetString(segment.ToArray());
            Console.Write(data);
            return Task.FromResult(0);
        }
    }
}
