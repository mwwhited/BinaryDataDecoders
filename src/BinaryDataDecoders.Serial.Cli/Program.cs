using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common;
using BinaryDataDecoders.ToolKit;
using System;
using System.Buffers;
using System.IO;
using System.IO.Pipelines;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Serial.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ScoreMachineFactory(new ScoreMachinePortProvider());

            Console.WriteLine("Favero or SG (Default SG)");
            var machine = factory.GetMachineType(Console.ReadLine());

            var parser = factory.GetParser(machine);

            var ports = SerialPort.GetPortNames().OrderBy(s => s);
            foreach (var port in ports)
                Console.WriteLine(port);


            Console.WriteLine($"Enter Port: (Default { ports.FirstOrDefault()})");
            var portName = Console.ReadLine();

            using (var port = factory.GetPort(machine, !string.IsNullOrWhiteSpace(portName) ? portName : ports.FirstOrDefault()))
            // using (var device = GetDevice(port, machine, parser))
            using (var cts = new CancellationTokenSource())
            {
                port.Open();

                Console.Write("Enter to exit");

                Task.WaitAll(
                    Task.Run(async () => await ReadLineAsync().ContinueWith(t => cts.Cancel(false))),
                    Task.Run(async () => await GetPipeAsync(port, parser, cts.Token, OnReceived))
                    );
            }
        }

        static IScoreMachineState last = ScoreMachineState.Empty;
        private static void OnReceived(IScoreMachineState state)
        {
            if (!last.Equals(state))
            {
                var org = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"S> {state}");
                Console.ForegroundColor = org;
                last = state;
            }
        }

        private static Task<string> ReadLineAsync()
        {
            return Task.FromResult(Console.ReadLine());
        }

        private static Task GetPipeAsync(SerialPort port, IParseScoreMachineState parser, CancellationToken cancellationToken, Action<IScoreMachineState> onReceived)
        {
            var pipe = new Pipe();
            var writerTask = FillPipeAsync(port.BaseStream, pipe.Writer, cancellationToken);
            var readerTask = ReadPipeAsync(pipe.Reader, parser, cancellationToken, onReceived);
            return Task.WhenAll(writerTask, readerTask);
        }

        private static async Task ReadPipeAsync(PipeReader reader, IParseScoreMachineState parser, CancellationToken cancellationToken, Action<IScoreMachineState> onReceived)
        {
            while (true)
            {
                var result = await reader.ReadAsync(cancellationToken);
                var buffer = result.Buffer;

                SequencePosition? startOfFrame = null;
                do
                {
                    // Look for a EOL in the buffer
                    startOfFrame = buffer.PositionOf(Bytes.Soh); //This is for SG
                    if (startOfFrame != null)
                    {
                        var packet = buffer.Slice(startOfFrame.Value);
                        var endOfPacket = packet.PositionOf(Bytes.Eotr); //This is for SG
                        if (endOfPacket != null)
                        {
                            var completeFrame = packet.Slice(0, buffer.GetPosition(1, endOfPacket.Value));
                            var state = parser.Parse(completeFrame.ToArray().AsSpan());
                            onReceived(state);

                            // Skip the line + the \n character (basically position)
                            buffer = buffer.Slice(buffer.GetPosition(1, endOfPacket.Value));
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                while (startOfFrame != null && !cancellationToken.IsCancellationRequested);

                // Tell the PipeReader how much of the buffer we have consumed
                reader.AdvanceTo(buffer.Start, buffer.End);

                // Stop reading if there's no more data coming
                if (result.IsCompleted || cancellationToken.IsCancellationRequested)
                {
                    break;
                }
            }

            // Mark the PipeReader as complete
            reader.Complete();
        }

        //https://devblogs.microsoft.com/dotnet/system-io-pipelines-high-performance-io-in-net/
        private static async Task FillPipeAsync(Stream stream, PipeWriter writer, CancellationToken cancellationToken, int minBufferSize = 512)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                // Allocate at least 512 bytes from the PipeWriter
                var memory = writer.GetMemory(minBufferSize);
                try
                {
                    var read = await stream.ReadAsync(memory, cancellationToken);
                    if (read == 0)
                    {
                        break;
                    }

                    // Tell the PipeWriter how much was read from the Socket
                    writer.Advance(read);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    break;
                }

                // Make the data available to the PipeReader
                var result = await writer.FlushAsync();
                if (result.IsCompleted)
                {
                    break;
                }
            }

            // Tell the PipeReader that there's no more data coming
            writer.Complete();
        }
    }
}
