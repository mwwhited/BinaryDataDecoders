using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public class JsonPathVisitor : JsonPathBaseVisitor<IPathSegment?>
    {
        ////bracket
        //public override IPathSegment VisitWildcard([NotNull] JsonPathParser.WildcardContext context) => new WildcardPathSegment();

        //public override IPathSegment VisitUnionNumber([NotNull] JsonPathParser.UnionNumberContext context) =>
        //    new IndexSetPathSegment(context.NUMBER().Select(VisitNumber));

        //public override IPathSegment VisitUnionString([NotNull] JsonPathParser.UnionStringContext context) =>
        //    new IndexSetPathSegment(context.QUOTED_STRING().Select(VisitQuotedString));

        //public override IPathSegment VisitSlicer([NotNull] JsonPathParser.SlicerContext context) =>
        //    new SlicerPathSegment(range: Visit(context.range()) ?? throw new ArgumentNullException("Invalid range"));

        //public override IPathSegment VisitRange([NotNull] JsonPathParser.RangeContext context) =>
        //    new RangeIndexPathSegment(
        //        start: VisitNumber(context.rangeStart),
        //        end: VisitNumber(context.rangeEnd),
        //        step: VisitNumber(context.rangeStep)
        //        );

        ////public override IPathSegment VisitRelational([NotNull] JsonPathParser.RelationalContext context) =>
        ////    new RelationPathSegment(
        ////        left: Visit(context.relationLeft) ?? throw new ArgumentNullException("Invalid left relation"),
        ////        operation: VisitRelationalOperation(context.RELATIONAL()),
        ////        right: Visit(context.relationRight) ?? throw new ArgumentNullException("Invalid right relation")
        ////        );

        //public override IPathSegment VisitLogical([NotNull] JsonPathParser.LogicalContext context) =>
        //    new LogicPathSegment(
        //        left: Visit(context.relationLeft) ?? throw new ArgumentNullException("Invalid left relation"),
        //        operation: VisitLogicalOperation(context.LOGICAL()),
        //        right: Visit(context.relationRight) ?? throw new ArgumentNullException("Invalid right relation")
        //        );

        ////public override IPathSegment VisitOperand([NotNull] JsonPathParser.OperandContext context) =>
        ////    new UnaryOperatorPathSegment(
        ////        @operator: VisitOperandBase(context.operandBase),
        ////        operand: Visit(context.bracketSequence()) ?? Visit(context.dotSequence())
        ////        );

        //public override IPathSegment VisitFilter([NotNull] JsonPathParser.FilterContext context) =>
        //    new FilterPathSegment(Visit(context.query()) ?? throw new ArgumentNullException("Invalid filter relation"));

        //public override IPathSegment VisitBracketSequence([NotNull] JsonPathParser.BracketSequenceContext context) =>
        //    Visit(context.bracket()) switch
        //    {
        //        null => throw new ArgumentNullException("missing node"),
        //        IPathSegment left => Visit(context.bracketSequence()) switch
        //        {
        //            null => new ElementPathSegment(left, null),
        //            IPathSegment right => new SequencePathSegment(left, right)
        //        }
        //    };
        //public override IPathSegment VisitDotSequence([NotNull] JsonPathParser.DotSequenceContext context) =>
        //    Visit(context.dotElement()) switch
        //    {
        //        null => throw new ArgumentNullException("missing node"),
        //        IPathSegment left => Visit(context.dotSequence()) switch
        //        {
        //            null => new ElementPathSegment(left, null),
        //            IPathSegment right => new SequencePathSegment(left, right)
        //        }
        //    };

        //public override IPathSegment VisitDotElement([NotNull] JsonPathParser.DotElementContext context) =>
        //    new ElementPathSegment(
        //        name: Visit(context.property()) ?? throw new ArgumentNullException("invalid identity"),
        //        predicate: Visit(context.bracketSequence())
        //        );


        ////public override IPathSegment VisitStart([NotNull] JsonPathParser.StartContext context) =>
        ////    new OperandPathSegment(
        ////        OperandBaseTypes.Root,
        ////        Visit(context.dotSequence()) ??
        ////        Visit(context.bracketSequence()) ??
        ////        throw new ArgumentNullException("invalid sequence")
        ////        );

        //public override IPathSegment VisitProperty([NotNull] JsonPathParser.PropertyContext context) =>
        //    context switch
        //    {
        //        _ when context.WILDCARD() != null => new WildcardPathSegment(),
        //        _ when context.IDENTITY() != null => new StringPathSegment(context.IDENTITY().GetText()),
        //        _ => throw new ArgumentNullException("invaild property")
        //    };

        public override IPathSegment VisitTerminal(ITerminalNode node) =>
            node?.GetText() switch
            {
                ".." => new DescendantsPathSegment(),
                "*" => new WildcardPathSegment(),
                "." => new PathSeperatorPathSegment(),

                "$" => new OperandBaseTypePathSegment(OperandBaseTypes.Root),
                "@" => new OperandBaseTypePathSegment(OperandBaseTypes.Relative),

                "==" => new RelationalOperationTypePathSegment(RelationalOperationTypes.Equal),
                "!=" => new RelationalOperationTypePathSegment(RelationalOperationTypes.NotEqual),
                "<" => new RelationalOperationTypePathSegment(RelationalOperationTypes.LessThan),
                "<=" => new RelationalOperationTypePathSegment(RelationalOperationTypes.LessThanOrEqual),
                ">" => new RelationalOperationTypePathSegment(RelationalOperationTypes.GreaterThan),
                ">=" => new RelationalOperationTypePathSegment(RelationalOperationTypes.GreaterThanOrEqual),

                string value when value.Length == 0 => new StringPathSegment(""),

                string value when value[0] == '\'' => new QuotedStringPathSegment(value.Trim('\'')),
                string value when int.TryParse(value, out var number) => new NumericPathSegment(number),
                string value => new StringPathSegment(value),
                _ => throw new JsonPathException($"Invalid terminal content: {node?.GetText()}")
            };
    }
}
