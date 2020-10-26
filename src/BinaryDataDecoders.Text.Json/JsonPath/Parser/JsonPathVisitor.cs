using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using BinaryDataDecoders.ToolKit.PathSegments;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public class JsonPathVisitor : JsonPathBaseVisitor<IPathSegment?>
    {
        public override IPathSegment VisitStart([NotNull] JsonPathParser.StartContext context) =>
            Visit(context.path()) ?? throw new JsonPathException("no path defined");
        public override IPathSegment VisitPath([NotNull] JsonPathParser.PathContext context) =>
            Visit(context.function()) switch
            {
                null => new BinaryPathSegment(
                Visit<PathBaseTypes>(context.pathBase()) ?? throw new JsonPathException("missing pathBase"),
                Visit(context.sequence()) ?? throw new JsonPathException("missing path sequence")
                ),
                IPathSegment function => function
            };
        public override IPathSegment? VisitPathBase([NotNull] JsonPathParser.PathBaseContext context) =>
            Visit<PathBaseTypes>(context.ROOT(), context.RELATIVE());
        public override IPathSegment? VisitIdentity([NotNull] JsonPathParser.IdentityContext context) =>
            Visit(context.IDENTITY());
        public override IPathSegment? VisitOperand([NotNull] JsonPathParser.OperandContext context) =>
            Visit(context.path(), context.@string(), context.NUMBER());
        public override IPathSegment? VisitString([NotNull] JsonPathParser.StringContext context) =>
            Visit(context.QUOTED_STRING());
        public override IPathSegment? VisitSequenceItem([NotNull] JsonPathParser.SequenceItemContext context) =>
            Visit(
                context.WILDCARD(),
                context.identity(),
                context.bracket(),
                context.filter(),
                context.function(),
                context.DESCENDANTS()
                );
        public override IPathSegment VisitSequence([NotNull] JsonPathParser.SequenceContext context) =>
            Visit(context.sequenceItem()) switch
            {
                null => throw new JsonPathException("no path segment defined"),
                IPathSegment left => Visit(context.sequence()) switch
                {
                    null => left,
                    IPathSegment right => new BinaryPathSegment(left, right)
                }
            };
        public override IPathSegment VisitBracket([NotNull] JsonPathParser.BracketContext context) =>
            new IndexerPathSegment(
                Visit(context.WILDCARD(), context.range(), context.function()) ??
                Visit(context.NUMBER()) ??
                Visit(context.@string()) ??
                throw new JsonPathException($"Invalid bracket content: {context.GetText()}")
            );
        public override IPathSegment VisitQueryRelational([NotNull] JsonPathParser.QueryRelationalContext context) =>
            new RelationBinaryOperationPathSegment(
                left: Visit(context.relationLeft) ?? throw new JsonPathException("no left operand defined"),
                @operator: Visit<RelationalOperationTypes>(context.RELATIONAL()) ?? throw new JsonPathException("no relational operator defined"),
                right: Visit(context.relationRight) ?? throw new JsonPathException("no right operand defined")
                );
        public override IPathSegment VisitQueryLogical([NotNull] JsonPathParser.QueryLogicalContext context) =>
            new LogicBinaryOperationPathSegment(
                left: Visit(context.relationLeft) ?? throw new JsonPathException("no left operand defined"),
                @operator: Visit<LogicOperationTypes>(context.LOGICAL()) ?? throw new JsonPathException("no logical operator defined"),
                right: Visit(context.relationRight) ?? throw new JsonPathException("no right operand defined")
                );
        public override IPathSegment VisitQueryPath([NotNull] JsonPathParser.QueryPathContext context) =>
            new PathExistsPathSegment(
                    (Visit(context.path()) as BinaryPathSegment) ?? throw new JsonPathException("Invalid reference path")
                );
        public override IPathSegment VisitRange([NotNull] JsonPathParser.RangeContext context) =>
            new RangePathSegment(
                start: Visit<int>(context.rangeStart),
                end: Visit<int>(context.rangeEnd),
                step: Visit<int>(context.rangeStep)
                );
        public override IPathSegment VisitFilter([NotNull] JsonPathParser.FilterContext context) =>
            new PredicatePathSegment(
                Visit(context.query()) ?? throw new JsonPathException("invalid query")
                );
        public override IPathSegment VisitFunction([NotNull] JsonPathParser.FunctionContext context) =>
            new FunctionPathSegment(
                Visit(context.identity()) ?? throw new JsonPathException($"Unnamed functions are not allowed: {context.GetText()}"),
                Visit(context.functionParameter()) ?? SetPathSegment.Empty
                );
        public override IPathSegment VisitFunctionParameter([NotNull] JsonPathParser.FunctionParameterContext context) =>
            Visit(
                context.operand(),
                context.pathBase(),
                context.DECIMAL()
                ) ?? throw new JsonPathException($"Invalid function parameter type");

        public override IPathSegment? Visit(IParseTree tree) => tree switch { null => null, _ => base.Visit(tree) };
        public virtual IPathSegment? Visit(IParseTree first, IParseTree second, params IParseTree[] more) =>
            Visit(first) ?? Visit(second) ?? more.Select(Visit).Where(l => l != null).FirstOrDefault();
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
                //Note: hidden terminal "." => new PathSeperatorPathSegment(),

                "$" => new PathBaseTypePathSegment(PathBaseTypes.Root),
                "@" => new PathBaseTypePathSegment(PathBaseTypes.Relative),

                "==" => new RelationalOperationTypePathSegment(RelationalOperationTypes.Equal),
                "!=" => new RelationalOperationTypePathSegment(RelationalOperationTypes.NotEqual),
                "<" => new RelationalOperationTypePathSegment(RelationalOperationTypes.LessThan),
                "<=" => new RelationalOperationTypePathSegment(RelationalOperationTypes.LessThanOrEqual),
                ">" => new RelationalOperationTypePathSegment(RelationalOperationTypes.GreaterThan),
                ">=" => new RelationalOperationTypePathSegment(RelationalOperationTypes.GreaterThanOrEqual),

                "&&" => new LogicOperationTypePathSegment(LogicOperationTypes.And),
                "||" => new LogicOperationTypePathSegment(LogicOperationTypes.Or),

                _ when value.Length == 0 => new StringPathSegment(""),
                _ when value[0] == '\'' => new QuotedStringPathSegment(value.Trim('\'')),
                _ when int.TryParse(value, out var number) => new NumericPathSegment(number),
                _ when decimal.TryParse(value, out var number) => new DecimalPathSegment(number),
                _ => new StringPathSegment(value)
            };
        public virtual IPathSegment<T>? Visit<T>(ITerminalNode node) => Visit(node) as IPathSegment<T>;
        public virtual IPathSegment<T>? Visit<T>(IToken token) => Visit(token) as IPathSegment<T>;
        public virtual IPathSegment<T>? Visit<T>(IParseTree tree) => Visit(tree) as IPathSegment<T>;
        public virtual IPathSegment? Visit(IEnumerable<IParseTree> trees) =>
            trees?.Select(Visit).Where(i => i != null).Cast<IPathSegment>() switch
            {
                null => null,
                IEnumerable<IPathSegment> path => path.Count() switch
                {
                    0 => null,
                    1 => path.First(),
                    _ => new SetPathSegment(path)
                }
            };
    }
}
