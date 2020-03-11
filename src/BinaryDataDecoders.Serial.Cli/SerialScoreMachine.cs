using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common;
using BinaryDataDecoders.IO.Pipelines;
using System;
using System.Buffers;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Serial.Cli
{
    public static class SerialScoreMachine
    {
        public static void Execute()
        {
            var factory = new ScoreMachineFactory(new PortProvider());

            Console.WriteLine("Favero or SG (Default SG)");
            var machine = factory.GetMachineType(Console.ReadLine());

            var parser = factory.GetParser(machine);

            var last = ScoreMachineState.Empty;
            var segmenter = factory.GetSegmenter(machine, data =>
            {
                var state = parser.Parse(data.ToArray().AsSpan());
                if (!last.Equals(state))
                {
                    var org = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"S> {state}");
                    Console.ForegroundColor = org;
                    last = state;
                }
                return Task.FromResult(0);
            });

            var ports = SerialPort.GetPortNames().OrderBy(s => s);
            foreach (var port in ports)
                Console.WriteLine(port);

            Console.WriteLine($"Enter Port: (Default { ports.FirstOrDefault()})");
            var portName = Console.ReadLine();

            using (var port = factory.GetPort(machine, !string.IsNullOrWhiteSpace(portName) ? portName : ports.FirstOrDefault()))
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
    }
}
