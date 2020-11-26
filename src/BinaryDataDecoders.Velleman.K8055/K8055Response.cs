using System;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Velleman.K8055
{
    [StructLayout(LayoutKind.Explicit, Size = 9)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public struct K8055Response : IK8055Object
    {
        // 00-00-04-04-fd-0a-00-0b-00
        [FieldOffset(0)]
        public byte ReportId;
        [FieldOffset(1)]
        public DigitalInputs DigitalInputs;
        [FieldOffset(2)]
        public byte Reserved2;
        [FieldOffset(3)]
        public byte Analog1;
        [FieldOffset(4)]
        public byte Analog2;
        [FieldOffset(5)]
        public ushort Counter1;
        [FieldOffset(6)]
        public byte Reserved6;
        [FieldOffset(7)]
        public ushort Counter2;
        [FieldOffset(8)]
        public byte Reserved8;

        public override string ToString() => new
        {
            ReportId,
            DigitalInputs,
            Reserved2,
            Analog1,
            Analog2,
            Counter1,
            Reserved6,
            Counter2,
            Reserved8,
        }.ToString();
    }
}
