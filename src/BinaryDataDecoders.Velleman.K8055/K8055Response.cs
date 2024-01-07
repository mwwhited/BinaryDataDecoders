using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Velleman.K8055;

[StructLayout(LayoutKind.Explicit, Size = 9)]
public struct K8055Response : IK8055Object
{
    [FieldOffset(0)]
    public byte Reserved0; //padding offset

    [FieldOffset(1)]
    public DigitalInputs DigitalInputs;

    [FieldOffset(2)]
    public byte ReportId; 

    [FieldOffset(3)]
    public byte Analog1;
    [FieldOffset(4)]
    public byte Analog2;

    // 00-00-04-04-fd-0a-00-0b-00
    [FieldOffset(5)]
    public ushort Counter1;
    [FieldOffset(7)]
    public ushort Counter2;

    public override readonly string ToString() => new
    {
        ReportId,
        DigitalInputs,
        Analog1,
        Analog2,
        Counter1,
        Counter2,
    }.ToString();
}
