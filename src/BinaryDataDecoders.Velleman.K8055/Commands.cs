namespace BinaryDataDecoders.Velleman.K8055
{
    public enum Commands : byte
    {
        None = 0x00,
        ResetCounter1 = 0x03,
        ResetCounter2 = 0x04,
        SetAnalogDigital = 0x05,
    }
}
