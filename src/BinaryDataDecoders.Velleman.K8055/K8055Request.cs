using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Velleman.K8055;

[StructLayout(LayoutKind.Explicit, Size = 9)]
public struct K8055Request : IK8055Object
{
    // 00-00-04-04-fd-0a-00-0b-00
    [FieldOffset(0)]
    public byte ReportId;
    [FieldOffset(1)]
    public Commands Command;
    [FieldOffset(2)]
    public DigitalOutputs Outputs;
    [FieldOffset(3)]
    public byte Analog1;
    [FieldOffset(4)]
    public byte Analog2;
    [FieldOffset(5)]
    public byte Reserved5;
    [FieldOffset(6)]
    public byte Reserved6;
    [FieldOffset(7)]
    public byte Debounce1;
    [FieldOffset(8)]
    public byte Debounce2;
}
