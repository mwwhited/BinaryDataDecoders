namespace BinaryDataDecoders.Nmea;

public class StringNemaMessage(string value) : INema0183Message
{
    public override string ToString() => value;
}
