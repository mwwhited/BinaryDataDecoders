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
        //bracket
        public override IPathSegment VisitWildcard([NotNull] JsonPathParser.WildcardContext context) => new WildcardPathSegment();

        public override IPathSegment VisitUnionNumber([NotNull] JsonPathParser.UnionNumberContext context) =>
            new IndexSetPathSegment(context.NUMBER().Select(VisitNumber));

        public override IPathSegment VisitUnionString([NotNull] JsonPathParser.UnionStringContext context) =>
            new IndexSetPathSegment(context.QUOTED_STRING().Select(VisitQuotedString));

        public override IPathSegment VisitSlicer([NotNull] JsonPathParser.SlicerContext context) =>
            new SlicerPathSegment(range: Visit(context.range()) ?? throw new ArgumentNullException("Invalid range"));

        public override IPathSegment VisitRange([NotNull] JsonPathParser.RangeContext context) =>
            new RangeIndexPathSegment(
                start: VisitNumber(context.rangeStart),
                end: VisitNumber(context.rangeEnd),
                step: VisitNumber(context.rangeStep)
                );

        public override IPathSegment VisitRelational([NotNull] JsonPathParser.RelationalContext context) =>
            new RelationPathSegment(
                left: Visit(context.relationLeft) ?? throw new ArgumentNullException("Invalid left relation"),
                operation: VisitRelationalOperation(context.RELATIONAL()),
                right: Visit(context.relationRight) ?? throw new ArgumentNullException("Invalid right relation")
                );

        public override IPathSegment VisitLogical([NotNull] JsonPathParser.LogicalContext context) =>
            new LogicPathSegment(
                left: Visit(context.relationLeft) ?? throw new ArgumentNullException("Invalid left relation"),
                operation: VisitLogicalOperation(context.LOGICAL()),
                right: Visit(context.relationRight) ?? throw new ArgumentNullException("Invalid right relation")
                );

        public override IPathSegment VisitOperand([NotNull] JsonPathParser.OperandContext context) =>
            new OperandPathSegment(
                operandBase: VisitOperandBase(context.operandBase),
                operand: Visit(context.bracketSequence()) ?? Visit(context.dotSequence())
                );

        public override IPathSegment VisitFilter([NotNull] JsonPathParser.FilterContext context) =>
            new FilterPathSegment(Visit(context.query()) ?? throw new ArgumentNullException("Invalid filter relation"));

        public override IPathSegment VisitBracketSequence([NotNull] JsonPathParser.BracketSequenceContext context) =>
            new SequencePathSegment(context?.bracket()?.Select(Visit) ?? throw new ArgumentNullException("invalid sequence"));

        public override IPathSegment VisitDotElement([NotNull] JsonPathParser.DotElementContext context) =>
            new ElementPathSegment(
                name: Visit(context.IDENTITY()) ?? throw new ArgumentNullException("invalid sequence"),
                predicate: Visit(context.bracketSequence())
                );

        public override IPathSegment VisitDotSequence([NotNull] JsonPathParser.DotSequenceContext context) =>
            new SequencePathSegment(context?.dotElement()?.Select(Visit) ?? throw new ArgumentNullException("invalid sequence"));

        public override IPathSegment VisitStart([NotNull] JsonPathParser.StartContext context) =>
            new OperandPathSegment(
                OperandBaseTypes.Root,
                Visit(context.dotSequence()) ?? 
                Visit(context.bracketSequence()) ??
                throw new ArgumentNullException("invalid sequence")
                );
        public override IPathSegment Visit(IParseTree tree) => tree switch { null => null, _ => base.Visit(tree) };

        //TerminalNodes
        public virtual OperandBaseTypes VisitOperandBase(IToken token) =>
            token switch
            {
                null => throw new ArgumentNullException("missing relational operator"),
                _ => token.Text switch
                {
                    "$" => OperandBaseTypes.Root,
                    "@" => OperandBaseTypes.Relative,
                    _ => throw new JsonPathException($"Invalid terminal content: {token.Text}")
                }
            };

        public virtual RelationalOperationTypes VisitRelationalOperation(ITerminalNode node) =>
            node switch
            {
                null => throw new ArgumentNullException("missing relational operator"),
                _ => node.GetText() switch
                {
                    "==" => RelationalOperationTypes.Equal,
                    "!=" => RelationalOperationTypes.NotEqual,
                    "<" => RelationalOperationTypes.LessThan,
                    "<=" => RelationalOperationTypes.LessThanOrEqual,
                    ">" => RelationalOperationTypes.GreaterThan,
                    ">=" => RelationalOperationTypes.GreaterThanOrEqual,
                    _ => throw new JsonPathException($"Invalid terminal content: {node.GetText()}")
                }
            };

        public virtual LogicOperationTypes VisitLogicalOperation(ITerminalNode node) =>
            node switch
            {
                null => throw new ArgumentNullException("missing relational operator"),
                _ => node.GetText() switch
                {
                    "and" => LogicOperationTypes.And,
                    "or" => LogicOperationTypes.Or,
                    _ => throw new JsonPathException($"Invalid terminal content: {node.GetText()}")
                }
            };

        public virtual IPathSegment VisitQuotedString(ITerminalNode node) =>
            node switch
            {
                null => throw new ArgumentNullException("missing quoted string"),
                _ => new StringIndexPathSegment(node.GetText())
            };
      
        public virtual IPathSegment VisitNumber(ITerminalNode node) =>
            node switch
            {
                null => throw new ArgumentNullException("missing numeric value"),
                _ when int.TryParse(node.GetText(), out var value) => new NumericIndexPathSegment(value),
                _ => throw new JsonPathException($"Invalid terminal content: {node.GetText()}")
            };
       
        public virtual IPathSegment? VisitNumber(IToken token) =>
            token switch
            {
                null => null,
                _ when int.TryParse(token.Text, out var value) => new NumericIndexPathSegment(value),
                _ => throw new JsonPathException($"Invalid terminal content: {token.Text}")
            };
    }
}
