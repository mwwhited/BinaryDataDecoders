namespace BinaryDataDecoders.Windows.Forms
{
    public class ValidationEventArgs : EventArgs
    {
        public bool IsValid { get; init; }
        public string? Value { get; init; }
    }
}