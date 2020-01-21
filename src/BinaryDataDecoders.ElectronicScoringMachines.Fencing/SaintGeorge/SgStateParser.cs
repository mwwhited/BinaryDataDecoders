using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common;
using BinaryDataDecoders.ToolKit;
using System;
using System.Linq;
using System.Text;
using static BinaryDataDecoders.ToolKit.Bytes;

namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.SaintGeorge
{
    public class SgStateParser : IParseScoreMachineState
    {
        private IScoreMachineState last = ScoreMachineState.Empty;
        public IScoreMachineState Parse(ReadOnlySpan<byte> frame)
        {
            if (frame == null || frame.Length == 0 || frame[0] != 0x01 || frame.ToArray().Last() != 0x04) return last;

            if (frame.StartsWith(Soh, Dc3, S, T, Sotx))
            {
                // ST011:00501000301300
                // Left 5, Red and yellow
                // Right 11 yellow
                //ST005:01100000301300
                // Left 11, Red and yellow
                // Right 0 none
                // ST005:011000000
                // ST005:01100000000300 no priorty
                // Left 11, none
                // Right 0 none
                //ST000:00002010000100 (right proproty)
                //ST000:00002010000100
                // Left 11, none
                // Right 0 red
                //ST000:00002010000200 (left priority)

                var data = Encoding.ASCII.GetString(frame.ToArray());
                var mem = new Memory<byte>(frame.ToArray());
                var subFrames = mem.Split(Sotx);

                var scoreSf = subFrames.ElementAt(1).Split((byte)0x3a);

                byte GetScore(Memory<byte> s)
                {
                    return (byte)((s.Span[0] - _0) * 100 + (s.Span[1] - _0) * 10 + (s.Span[2] - _0));
                }

                var scores = new[]
                {
                    GetScore(scoreSf.ElementAt(0)),//right
                    GetScore(scoreSf.ElementAt(1)), //left
                };


                Cards? greenCards = (Cards)subFrames.ElementAtOrDefault(2).Span[1] - _0; // parts.Length < 3 ? (Cards?)null : (Cards)(parts[2][1] - (byte)By._0);
                Cards? redCards = (Cards)subFrames.ElementAtOrDefault(3).Span[1] - _0; // parts.Length < 4 ? (Cards?)null : (Cards)(parts[3][1] - (byte)By._0);

                var red = new Fencer(scores[1], redCards ?? last?.Left.Cards ?? Cards.None, last?.Left.Lights ?? Lights.None, last?.Left.Priority ?? false);
                var green = new Fencer(scores[0], greenCards ?? last?.Right.Cards ?? Cards.None, last?.Right.Lights ?? Lights.None, last?.Right.Priority ?? false);

                return last = new ScoreMachineState(red, green, last?.Clock ?? TimeSpan.Zero, last?.Match ?? 0);
            }
            else if (frame.StartsWith(Soh, Dc3, L, R) && frame[5] == G && frame[7] == W && frame[9] == w)
            {
                var data = Encoding.ASCII.GetString(frame.ToArray());

                // LR0G1W0w0 Green (touch right)
                // LR1G0W0w0 Red (touch left)
                // LR0G0W0w1 green off target
                // LR0G0W1w0 red off target

                var redLights =
                    (frame[4] == _1 ? Lights.Touch : Lights.None) |
                    (frame[8] == _1 ? Lights.White : Lights.None)
                    ;

                var greenLights =
                    (frame[6] == _1 ? Lights.Touch : Lights.None) |
                    (frame[10] == _1 ? Lights.White : Lights.None)
                    ;

                var red = new Fencer(last?.Left.Score ?? 0, last?.Left.Cards ?? Cards.None, redLights, last?.Left.Priority ?? false);
                var green = new Fencer(last?.Right.Score ?? 0, last?.Right.Cards ?? Cards.None, greenLights, last?.Right.Priority ?? false);
                return last = new ScoreMachineState(red, green, last?.Clock ?? TimeSpan.Zero, last?.Match ?? 0);
            }
            else if (frame.StartsWith(Soh, Dc3, R, _, F, _S, Sotx) && frame.Length > 12)
            {
                // R_F$0000__:02:59.___
                var mem = new Memory<byte>(frame.ToArray());
                var subFrames = mem.Split(Sotx);
                var chunk = subFrames.ElementAtOrDefault(1);

                var decoded = new
                {
                    c1 = (chunk.Span[8] - _0) * 10 + chunk.Span[9] - _0,
                    c2 = (chunk.Span[11] - _0) * 10 + chunk.Span[12] - _0,
                };

                var time = new TimeSpan(0, decoded.c1, decoded.c2);
                return last = new ScoreMachineState(last?.Left ?? new Fencer(), last?.Right ?? new Fencer(), time, last?.Match ?? 0);
            }
            else if (frame.StartsWith(Soh, Dc2, P))
            {
                var data = Encoding.ASCII.GetString(frame.ToArray());
                // P?AA8G
                // 01 12 50 3f 00 02 00 41 41 48 47 04
                var redPriority = (frame[2] & Eotx) == 0x01;
                var greenPriority = (frame[2] & Eotx) == 0x01;

                var red = new Fencer(last?.Left.Score ?? 0, last?.Left.Cards ?? Cards.None, last?.Left.Lights ?? Lights.None, redPriority);
                var green = new Fencer(last?.Right.Score ?? 0, last?.Right.Cards ?? Cards.None, last?.Right.Lights ?? Lights.None, greenPriority);

                return last = new ScoreMachineState(red, green, last?.Clock ?? new TimeSpan(), last?.Match ?? 0);
            }
            else if (frame.StartsWith(Soh, Dc3, S))
            {
                //S01:06
                var mem = new Memory<byte>(frame.ToArray());
                var subFrames = mem.Split(S);
                var scoreSf = subFrames.ElementAt(1).Split(_C);
                byte GetScore(Memory<byte> s)
                {
                    return (byte)((s.Span[0] - _0) * 10 + (s.Span[1] - _0));
                }

                var scores = new[]
                {
                    GetScore(scoreSf.ElementAt(0)),//right
                    GetScore(scoreSf.ElementAt(1)), //left
                };

                var red = new Fencer(scores[1], last?.Left.Cards ?? Cards.None, last?.Left.Lights ?? Lights.None, last?.Left.Priority ?? false);
                var green = new Fencer(scores[0], last?.Right.Cards ?? Cards.None, last?.Right.Lights ?? Lights.None, last?.Right.Priority ?? false);

                return last = new ScoreMachineState(red, green, last?.Clock ?? TimeSpan.Zero, last?.Match ?? 0);
            }
            else if (frame.StartsWith(Soh, Dc3, T))
            {
                //T02:16
                var decoded = new
                {
                    c1 = (frame[3] - _0) * 10 + frame[4] - _0,
                    c2 = (frame[6] - _0) * 10 + frame[7] - _0,
                };

                var time = new TimeSpan(0, decoded.c1, decoded.c2);
                return last = new ScoreMachineState(last?.Left ?? new Fencer(), last?.Right ?? new Fencer(), time, last?.Match ?? 0);
            }
            return last;
        }
    }
}