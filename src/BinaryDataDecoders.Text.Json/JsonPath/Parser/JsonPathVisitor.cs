using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using BinaryDataDecoders.Text.Json.JsonPath.PathSegments;
using System.Linq;

namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{


    public class JsonPathVisitor : JsonPathBaseVisitor<IPathSegment?>
    {
        public override IPathSegment VisitStart([NotNull] JsonPathParser.StartContext context) => Visit(context.path()) ?? throw new JsonPathException("no path defined");
        public override IPathSegment VisitPath([NotNull] JsonPathParser.PathContext context) =>
            new PathBaseSegment(
                baseType: Visit<PathBaseTypes>(context.pathBase) ?? throw new JsonPathException("missing pathBase"),
                value: Visit(context.bracketSequence(), context.dotSequence()) ?? throw new JsonPathException("missing path sequence")
                );
        public override IPathSegment VisitDotSequence([NotNull] JsonPathParser.DotSequenceContext context) =>
            Visit(context.dotElement(), context.DESCENDANTS(), context.WILDCARD()) switch
            {
                null => throw new JsonPathException("missing path element"),
                IPathSegment left =>
                    Visit(context.dotSequence()) switch
                    {
                        null => new PathLeafSegment(left),
                        IPathSegment right => new PathBranchSegment(left, right)
                    }
            };

        public override IPathSegment VisitDotElement([NotNull] JsonPathParser.DotElementContext context)
        {
            return base.VisitDotElement(context);
        }

        public override IPathSegment? Visit(IParseTree tree) => tree switch { null => null, _ => base.Visit(tree) };
        public virtual IPathSegment? Visit(IParseTree first, IParseTree second, params IParseTree[] more) =>
            Visit(first) ?? Visit(second) ?? more.Select(Visit).FirstOrDefault();
        public virtual IPathSegment<T>? Visit<T>(IParseTree first, IParseTree second, params IParseTree[] more) =>
            Visit(first) as IPathSegment<T> ??
            Visit(second) as IPathSegment<T> ??
            more.Select(i => Visit(i) as IPathSegment<T>)
                .Where(i => i != null)
                .FirstOrDefault();
        public override IPathSegment VisitTerminal(ITerminalNode node) =>
            Visit(node?.GetText()) ?? throw new JsonPathException($"invalid terminal node \"{node?.GetText()}\"");
        public virtual IPathSegment? Visit(IToken token) => Visit(token?.Text);
        public virtual IPathSegment? Visit(string? value) =>
            value switch
            {
                null => null,

                ".." => new DescendantsPathSegment(),
                "*" => new WildcardPathSegment(),
                "." => new PathSeperatorPathSegment(),

                "$" => new PathBaseTypePathSegment(PathBaseTypes.Root),
                "@" => new PathBaseTypePathSegment(PathBaseTypes.Descendants),

                "==" => new RelationalOperationTypePathSegment(RelationalOperationTypes.Equal),
                "!=" => new RelationalOperationTypePathSegment(RelationalOperationTypes.NotEqual),
                "<" => new RelationalOperationTypePathSegment(RelationalOperationTypes.LessThan),
                "<=" => new RelationalOperationTypePathSegment(RelationalOperationTypes.LessThanOrEqual),
                ">" => new RelationalOperationTypePathSegment(RelationalOperationTypes.GreaterThan),
                ">=" => new RelationalOperationTypePathSegment(RelationalOperationTypes.GreaterThanOrEqual),

                _ when value.Length == 0 => new StringPathSegment(""),
                _ when value[0] == '\'' => new QuotedStringPathSegment(value.Trim('\'')),
                _ when int.TryParse(value, out var number) => new NumericPathSegment(number),
                _ => new StringPathSegment(value)
            };
        public virtual IPathSegment<T>? Visit<T>(ITerminalNode node) => Visit(node) as IPathSegment<T>;
        public virtual IPathSegment<T>? Visit<T>(IToken token) => Visit(token) as IPathSegment<T>;
        public virtual IPathSegment<T>? Visit<T>(IParseTree tree) => Visit(tree) as IPathSegment<T>;
    }
}
