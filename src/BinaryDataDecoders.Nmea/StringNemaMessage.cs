namespace BinaryDataDecoders.Nmea
{
    public class StringNemaMessage : INema0183Message
    {
        private readonly string _value;
        public StringNemaMessage(string value) => this._value = value;
        public override string ToString() => _value;
    }
}
