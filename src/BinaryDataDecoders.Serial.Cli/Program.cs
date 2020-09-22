using System;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Serial.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            Span<byte> test = new byte[] { 0x7b, 0xff, 0x20, 0x00, 0x06, 0x00 };
            var x = test.Slice(0, 2);
            ushort y = BitConverter.ToUInt16(x);

            // SerialScoreMachine.Execute();
            // SerialNmea0183.Execute();
            SerialRadexOne.Execute();
        }

        public static Task<string> ReadLineAsync()
        {
            return Task.FromResult(Console.ReadLine());
        }
    }
}
