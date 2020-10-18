namespace BinaryDataDecoders.Xslt.Cli
{
    public enum InputTypes
    {
        Unknown = 0,

        Xml,
        Html,
        Json,

        CSharp = 256,
        VB,

        ByExtention = 0x7fffffff,
    }
}
