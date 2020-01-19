using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common;
using BinaryDataDecoders.ToolKit;
using System;
using System.Linq;

using static BinaryDataDecoders.ToolKit.Bytes;

namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.SaintGeorge
{
    public class SgState
    {

        public static IScoreMachineState Create(IScoreMachineState last, ReadOnlySpan<byte> frame)
        {
            if (frame == null || frame.Length == 0 || frame[0] != 0x13) return last;

            if (frame.StartsWith(Dc3, S, T, Sotx))
            {
                //i19	ST	i2	000:000	i2	0	i2	0	i2	3	i2	0

                var parts = frame.Chunk(Sotx, true).ToArray();
                var scores = parts[1].Select(i => (byte)(i - _0))
                                     .Chunk(Lf, exclude: true)
                                     .Select(i => (byte)i.Reverse().Select((v, ix) => Math.Pow(10, ix) * v).Sum())
                                     .ToArray();

                Cards? greenCards = null; // parts.Length < 3 ? (Cards?)null : (Cards)(parts[2][1] - (byte)By._0);
                Cards? redCards = null; // parts.Length < 4 ? (Cards?)null : (Cards)(parts[3][1] - (byte)By._0);

                var red = new Fencer(scores[1], redCards ?? last?.Left.Cards ?? Cards.None, last?.Left.Lights ?? Lights.None, last?.Left.Priority ?? false);
                var green = new Fencer(scores[0], greenCards ?? last?.Right.Cards ?? Cards.None, last?.Right.Lights ?? Lights.None, last?.Right.Priority ?? false);

                return new ScoreMachineState(red, green, last?.Clock ?? TimeSpan.Zero, last?.Match ?? 0);
            }
            else if (frame.Length >= 9 &&
                     frame[1] == L &&
                     frame[2] == R &&
                     frame[4] == G &&
                     frame[6] == W &&
                     frame[8] == w)
            {
                throw new NotSupportedException("These need checked");
                //TODO: fix up lights
                // i19 LR1G0W0w1
                var redLights = (Lights)((frame[3] - _0) << 1 | (frame[7] - _0));
                var red = new Fencer(last?.Left.Score ?? 0, last?.Left.Cards ?? Cards.None, redLights, last?.Left.Priority ?? false);

                var greenLights = (Lights)((frame[5] - _0) << 1 | (frame[9] - _0));
                var green = new Fencer(last?.Right.Score ?? 0, last?.Right.Cards ?? Cards.None, greenLights, last?.Right.Priority ?? false);
                return new ScoreMachineState(red, green, last?.Clock ?? TimeSpan.Zero, last?.Match ?? 0);
            }
            else if (frame.StartsWith(Dc3, R, _, F, _S, Sotx))
            {
                //i19	R_F$	i2	i16	0000__:20:00.___
                var chunks = frame.Chunk(Sotx, true)
                                  .Skip(1)
                                  .FirstOrDefault()
                                  ?.Select(i => (byte)(i - _0))
                                  .Where(i => i <= Lf)
                                  .Chunk(Lf, true)
                                  .Skip(1)
                                  .Select(i => (byte)i.Reverse().Select((v, ix) => Math.Pow(10, ix) * v).Sum())
                                  .ToArray();
                if (chunks == null) return last;
                var time = new TimeSpan(0, chunks[0], chunks[1]);
                return new ScoreMachineState(last?.Left ?? new Fencer(), last?.Right ?? new Fencer(), time, last?.Match ?? 0);
            }
            else if (frame.Length >= 3 &&
                     frame[1] == P &&
                     (frame[2] & 0xfc) == 0x30
                     )
            {
                // P?AA8G
                // 01 12 50 3f 00 02 00 41 41 48 47 04
                var redPriority = (frame[2] & Eotx) == Sotx;
                var greenPriority = (frame[2] & Eotx) == 0x01;

                var red = new Fencer(last?.Left.Score ?? 0, last?.Left.Cards ?? Cards.None, last?.Left.Lights ?? Lights.None, redPriority);
                var green = new Fencer(last?.Right.Score ?? 0, last?.Right.Cards ?? Cards.None, last?.Right.Lights ?? Lights.None, greenPriority);

                return new ScoreMachineState(red, green, last?.Clock ?? new TimeSpan(), last?.Match ?? 0);
            }

            return last;
        }
    }
}