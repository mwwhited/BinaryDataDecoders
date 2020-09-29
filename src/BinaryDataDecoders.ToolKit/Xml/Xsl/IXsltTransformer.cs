namespace BinaryDataDecoders.ToolKit.Xml.Xsl
{
    public interface IXsltTransformer
    {
        void Transform(string template, string input, string output);
        void TransformAll(string template, string input, string output);
    }
}