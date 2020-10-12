using System.Xml.XPath;
using static System.Xml.XPath.XPathNodeType;

namespace BinaryDataDecoders.CodeAnalysis.Xml.XPath
{
    public static class XPathNodeTypeEx
    {
        public static XPathNodeType ToNodeType(this ISyntaxPointer pointer) =>
            pointer switch
            {
                SyntaxRootPointer _ => Root,
                SyntaxAttributePointer _ => Attribute,
                // SyntaxTriviaPointer _ => SignificantWhitespace,
                // SyntaxValuePointer<SyntaxTrivia> _ => SignificantWhitespace,
                ISyntaxValuePointer _ => Text,
                _ => Element
            };
    }
}
