using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common;
using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Favero;
using BinaryDataDecoders.ElectronicScoringMachines.Fencing.SaintGeorge;
using BinaryDataDecoders.ToolKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace BinaryDataDecoders.Serial.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var ports = SerialPort.GetPortNames().OrderBy(s => s);
            foreach (var port in ports)
                Console.WriteLine(port);

            Console.WriteLine($"Enter Port: (Default { ports.FirstOrDefault()})");
            var portName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(portName)) portName = ports.FirstOrDefault();

            Console.WriteLine("1 for Favero, 2 for SG (Default SG)");
            var machine = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(machine)) machine = "SG";

            using (var device = GetDevice(portName, machine))
            {
                device.Open();

                Console.Write("Enter to exit");
                Console.ReadLine();
            }
        }


        private static SerialPort GetDevice(string portName, string machine)
        {
            MachineType type;
            SerialPort port;
            IParseScoreMachineState parse;
            if (portName?.ToLower().StartsWith("f") ?? false)
            {
                parse = new FaveroStateParser();
                port = GetFaveroPort(portName);
                type = MachineType.Favero;
            }
            else
            {
                parse = new SgStateParser();
                port = GetSaintGeorgePort(portName);
                type = MachineType.Sg;
            }

            port.ErrorReceived += (s, e) =>
            {
                Console.Error.WriteLine($"ERROR: {e.EventType}");
            };
            IScoreMachineState last = ScoreMachineState.Empty;
            object sync = new object();

            List<byte[]> packets = new List<byte[]>();
            port.DataReceived += (s, e) =>
            {
                if (port.IsOpen)
                    lock (sync)
                    {
                        var buffer = new byte[port.ReadBufferSize];
                        var read = port.Read(buffer, 0, buffer.Length);

                        var frame = new byte[read];
                        Array.Copy(buffer, frame, read);

                        if (frame.Select(i => (int)i).Sum() == 0) return;

                        packets.Add(frame);

                        var chunks = from c in packets.SelectMany(b => b).ToArray().AsMemory().Split(Bytes.Soh, DelimiterOptions.Carry)
                                     select c.ToArray();

                        packets = chunks.ToList();

                        var removeThese = new List<byte[]>();

                        foreach (var p in packets)
                        {
                            if (p.Last() == 0x04)
                            {
                                removeThese.Add(p);
                                try
                                {
                                    var state = parse.Parse(p.AsSpan());
                                    if (!state.Equals(last))
                                    {
                                        Console.WriteLine($"D: {p.ToHexString()}\t{Encoding.ASCII.GetString(p)}");
                                        var org = Console.ForegroundColor;
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine($"S> {state}");
                                        Console.ForegroundColor = org;
                                        last = state;
                                    }
                                }
                                catch { }
                            }
                        }
                        foreach (var r in removeThese)
                        {
                            packets.Remove(r);
                        }
                    }
            };

            return port;
        }

        public static SerialPort GetFaveroPort(string portName)
        {
            return new SerialPort(portName)
            {
                BaudRate = 2400,
                DataBits = 8,
                StopBits = StopBits.One,
                Parity = Parity.None,
            };
        }
        public static SerialPort GetSaintGeorgePort(string portName)
        {
            return new SerialPort(portName)
            {
                BaudRate = 9600,
                DataBits = 8,
                StopBits = StopBits.One,
                Parity = Parity.None,
            };
        }
    }
    public enum MachineType
    {
        Sg,
        Favero,
    }
}
