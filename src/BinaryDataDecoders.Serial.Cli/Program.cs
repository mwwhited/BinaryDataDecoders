using System;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Serial.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            // SerialScoreMachine.Execute();
            // SerialNmea0183.Execute();
            new SerialRadexOne().Execute();
        }
    }
}
