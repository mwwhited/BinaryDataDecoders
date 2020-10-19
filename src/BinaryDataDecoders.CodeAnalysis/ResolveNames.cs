using Microsoft.CodeAnalysis;
using System.Xml.Linq;

using CS = Microsoft.CodeAnalysis.CSharp.CSharpExtensions;
using VB = Microsoft.CodeAnalysis.VisualBasic.VisualBasicExtensions;

namespace BinaryDataDecoders.CodeAnalysis
{
    public static class ResolveNames
    {
        public const string BaseUri = "bdd:CodeAnalysis/";
        public const string CsLang = "C#";
        public const string VbLang = "Visual Basic";

        public static string ToNamespaceUri(this object obj) =>
            $@"{BaseUri}{obj switch
            {
                SyntaxTree _ => "Tree",
                SyntaxNode _ => "Node",
                SyntaxNodeOrToken nodeOrToken => nodeOrToken.IsNode ? "Node" : "Token",
                SyntaxToken _ => "Token",
                SyntaxTrivia _ => "Trivia",
                _ => ""
            }}";
        public static string ToLocalName(this object obj) =>
            obj switch
            {
                SyntaxTree _ => "Tree",

                SyntaxNode node => node.Language switch
                {
                    CsLang => CS.Kind(node).ToString(),
                    VbLang => VB.Kind(node).ToString(),
                    _ => null
                },
                SyntaxNodeOrToken nodeOrToken => nodeOrToken.Language switch
                {
                    CsLang => CS.Kind(nodeOrToken).ToString(),
                    VbLang => VB.Kind(nodeOrToken).ToString(),
                    _ => null
                },
                SyntaxToken token => token.Language switch
                {
                    CsLang => CS.Kind(token).ToString(),
                    VbLang => VB.Kind(token).ToString(),
                    _ => null
                },
                SyntaxTrivia trivia => trivia.Language switch
                {
                    CsLang => CS.Kind(trivia).ToString(),
                    VbLang => VB.Kind(trivia).ToString(),
                    _ => null
                },

                _ => null
            } ?? obj.GetType().Name;

        public static XName ToXName(this object obj) => XName.Get(obj.ToLocalName(), obj.ToNamespaceUri());
    }
}
