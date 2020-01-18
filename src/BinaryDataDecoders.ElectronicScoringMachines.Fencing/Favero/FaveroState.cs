using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common;
using BinaryDataDecoders.ToolKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Favero
{
    public class FaveroState
    {
        public static IScoreMachineState Create(IScoreMachineState last, byte[] frame)
        {
            if (frame == null || frame.Length == 0 || frame[0] != 0x13) return last;

            if (frame[0] != 0xff)
                throw new ArgumentException("invalid prefix", nameof(frame));

            ////TODO: Fix the CRC
            ////var crc = (((int)message.Take(9).Select(b => (int)b).Sum()) & 0xff);
            ////var crc = message.Take(9).Aggregate(0, (p, i) => (((p & 0x0f) + (i & 0x0f)) & 0x0f) | (((p & 0x0f0) + (i & 0xf0)) & 0xf0));
            ////var crc = message.Take(9).Aggregate(0, (p, i) => p ^ i);
            ////var crc = message.Take(9).Aggregate(0, (p, i) => (p + i) & 0xff);
            ////if (message[9] != crc)
            ////    throw new InvalidOperationException("invalid CRC");

            //this.Match = (int)(frame[6] & 0x3);
            //this.Priority = (PriorityValues)(frame[6] >> 2 & 0x3);
            return new ScoreMachineState(
                red: new Fencer(
                    score: (byte)frame[1].AsBCD(),
                    cards: (Cards)(frame[8] & 0x5), 
                    lights: (Lights)(((frame[5] >> 1) & 0x5) | (frame[5] >> 3 & 0x2)),
                    priority: false
                    ),
                green: new Fencer(
                    score: (byte)frame[2].AsBCD(), 
                    cards: (Cards)(frame[8] >> 1 & 0x5),
                    lights: (Lights)((frame[5] & 0x5) | (frame[5] >> 4 & 0x2)),
                    priority: false)
                ,
                clock: new TimeSpan(0, frame[4].AsBCD(), frame[3].AsBCD())
                );
        }
    }
}
