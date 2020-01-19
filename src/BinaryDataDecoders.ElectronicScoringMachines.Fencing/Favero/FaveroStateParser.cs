using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common;
using BinaryDataDecoders.ToolKit;
using System;

namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Favero
{
    public class FaveroStateParser : IParseScoreMachineState
    {
        public IScoreMachineState Parse(ReadOnlySpan<byte> frame)
        {
            if (frame == null || frame.Length == 0) return null;

            //  1° byte: FFh  = Start string
            // The FFh value identifies the beginning of the string.
            if (frame[0] != 0xff)
                throw new ArgumentException("invalid prefix", nameof(frame));

            ////TODO: Fix the CRC
            ////var crc = (((int)message.Take(9).Select(b => (int)b).Sum()) & 0xff);
            ////var crc = message.Take(9).Aggregate(0, (p, i) => (((p & 0x0f) + (i & 0x0f)) & 0x0f) | (((p & 0x0f0) + (i & 0xf0)) & 0xf0));
            ////var crc = message.Take(9).Aggregate(0, (p, i) => p ^ i);
            ////var crc = message.Take(9).Aggregate(0, (p, i) => (p + i) & 0xff);
            ////if (message[9] != crc)
            ////    throw new InvalidOperationException("invalid CRC");

            //  /*		
            //10° byte:  CRC , it is the sum without carry of the 9 previous bytes.
            //*/
            //  byte crc = 0; // frame[0];
            //  for (var x = 1; x < 10; x++)
            //  {
            //      crc = (byte)(crc ^ frame[x]);
            //  }
            //  //var crc = frame.Take(9).Aggregate(0, (a, i) => a ^ i);

            // 6° byte: XXh  = Define the state of the lamps
            var lamps = ParseLights(frame[5]);

            // 7° byte: 0Xh  = Number of matches and Priority signals.
            var match = Match(frame[6]);
            var priority = ParsePriority(frame[6]);

            // 8° byte: XXh  This byte is only for our use. Do not consider this byte.

            // 9° byte:  Red and Yellow penalty cards.
            var cards = ParseCards(frame[8]);

            return new ScoreMachineState(
                left: new Fencer(
                    // 3° byte: XXh  = Left score
                    score: (byte)frame[2].AsBCD(),
                    cards: cards.left,
                    lights: lamps.left,
                    priority: priority.left),

                right: new Fencer(
                    // 2° byte: XXh  = Right score
                    score: (byte)frame[1].AsBCD(),
                    cards: cards.right,
                    lights: lamps.right,
                    priority: priority.right),

                // 4° byte: XXh  = Seconds of the time (units and tens)	
                // 5° byte: 0Xh  = Minutes of the time (only units)
                clock: new TimeSpan(0, ((byte)(frame[4] & 0x0f)).AsBCD(), frame[3].AsBCD()),
                match: match
                );

            //Bit D0 = Left white lamp
            //Bit D1 = Right white lamp
            //Bit D2 = RED lamp(left)
            //Bit D3 = GREEN lamp(right)
            //Bit D4 = Right yellow lamp
            //Bit D5 = Left yellow lamp
            //Bit D6 = 0  not used
            //Bit D7 = 0  not used
            (Lights left, Lights right) ParseLights(byte subFrame) => (
                left: (Lights)((subFrame & 0x5) | (subFrame >> 4 & 0x2)),
                right: (Lights)(((subFrame >> 1) & 0x5) | (subFrame >> 3 & 0x2))
                );

            // The D0 e D1 bits define the number of matches (from 0 to 3):
            //    D1=0 D0=0  Num.Matchs = 0
            //    D1=0 D0=1  Num.Matchs = 1
            //    D1=1 D0=0  Num.Matchs = 2
            //    D1=1 D0=1  Num.Matchs = 3
            byte Match(byte subFrame) => (byte)(subFrame & 0x3);

            //The D2 e D3 bits define the signals of Priorite:
            //   D2 = Right Priorite(if= 1 is ON)
            //   D3 = Left Priorite(if= 1 is ON)
            (bool left, bool right) ParsePriority(byte subFrame) => (
                left: (subFrame & 0x08) != 0x00,
                right: (subFrame & 0x04) != 0x00
                );

            //D0 = Right RED penalty card
            //D1 = Left RED penalty card
            //D2 = Right YELLOW penalty card
            //D3 = Left YELLOW penalty card
            (Cards left, Cards right) ParseCards(byte subFrame) => (
              left: Card((byte)((subFrame >> 1) & 0x5)),
              right: Card((byte)(subFrame & 0x5))
              );
            Cards Card(byte subFrame) => ((subFrame & 0x01) != 0 ? Cards.Red : Cards.None) | ((subFrame & 0x04) != 0 ? Cards.Yellow : Cards.None);
        }
    }
}
