namespace BinaryDataDecoders.Xslt.Cli
{
    public enum InputTypes
    {
        Unknown = 0,

        Xml,
        Html,
        Json,
        Yaml,

        CSharp = 256,
        VB,
        MSBuildStructuredLog,

        Path = 512,

        ByExtention = 0x7fffffff,
    }
}
