using BinaryDataDecoders.ToolKit.PathSegments;
using System;
using System.Linq;

namespace BinaryDataDecoders.ToolKit.Xml.XPath
{
    public class XPathExpressionBuilder
    {
        public string BuildXPathExpression(IPathSegment path) => Visit(path);
        public string Visit(IPathSegment path) => Visit(path, null);

        public string Visit(IPathSegment path, IPathSegment? parent) =>
            path switch
            {
                LogicBinaryOperationPathSegment segment => Visit(segment, parent),
                RelationBinaryOperationPathSegment segment => Visit(segment, parent),
                BinaryPathSegment segment => Visit(segment, parent),

                LogicOperationTypePathSegment segment => Visit(segment, parent),
                RelationalOperationTypePathSegment segment => Visit(segment, parent),
                PathBaseTypePathSegment segment => Visit(segment, parent),

                IndexerPathSegment segment => Visit(segment, parent),
                PathExistsPathSegment segment => Visit(segment, parent),
                PredicatePathSegment segment => Visit(segment, parent),
                RangePathSegment segment => Visit(segment, parent),
                SetPathSegment segment => Visit(segment, parent),

                QuotedStringPathSegment segment => Visit(segment, parent),
                DecimalPathSegment segment => Visit(segment, parent),
                FunctionPathSegment segment => Visit(segment, parent),
                NumericPathSegment segment => Visit(segment, parent),
                StringPathSegment segment => Visit(segment, parent),

                DescendantsPathSegment segment => Visit(segment, parent),
                WildcardPathSegment segment => Visit(segment, parent),

                _ => throw new NotSupportedException($"{path} not supported")
            };

        private string Visit(WildcardPathSegment segment, IPathSegment? parent) => "*";
        private string Visit(DescendantsPathSegment segment, IPathSegment? parent) => "descendant::";
        private string Visit(StringPathSegment segment, IPathSegment? parent) => $"{segment.Value}";
        private string Visit(NumericPathSegment segment, IPathSegment? parent) => $"{segment.Value + 1}";
        private string Visit(DecimalPathSegment segment, IPathSegment? parent) => $"{segment.Value}";
        private string Visit(QuotedStringPathSegment segment, IPathSegment? parent) => parent switch
        {
            RelationBinaryOperationPathSegment _ => $"'{segment.Value}'",
            FunctionPathSegment _ => $"'{segment.Value}'",
            _ => $"local-name()='{segment.Value}'"
        };
        private string Visit(PathBaseTypePathSegment segment, IPathSegment? parent) =>
            segment.Value switch
            {
                PathBaseTypes.Root => "/",
                PathBaseTypes.Relative => "./",
                _ => throw new NotSupportedException($"{segment}")
            };
        private string Visit(SetPathSegment segment, IPathSegment? parent) => $"{ string.Join(" or ", segment.Set.Select(i => Visit(i, segment)))}";
        private string Visit(IndexerPathSegment segment, IPathSegment? parent) =>
           segment.Child switch
           {
               WildcardPathSegment wild => Visit(wild, segment),
               _ => $"*[{Visit(segment.Child, segment)}]"
           };
        private string Visit(BinaryPathSegment segment, IPathSegment? parent) =>
            Visit(segment.Left, segment) switch
            {
                null => Visit(segment.Right, segment),
                string left when string.IsNullOrWhiteSpace(left) => Visit(segment.Right, segment),
                string left => Visit(segment.Right, segment) switch
                {
                    null => left,
                    string right when string.IsNullOrWhiteSpace(right) => left,
                    string right when new[] { '[', '/' }.Contains(right[0]) => left + right,
                    string right when new[] { ':', '/' }.Contains(left[^1]) => left + right,
                    string right => left + '/' + right
                }
            };
        private string Visit(PredicatePathSegment segment, IPathSegment? parent) => $"[{Visit(segment.Child, segment)}]";

        private string Visit(FunctionPathSegment segment, IPathSegment? parent) =>
            $@"{Visit(segment.Name, segment)}({
                segment.Parameters switch
                {
                    null => "",
                    SetPathSegment set => string.Join(",", set.Set.Select(i => Visit(i, segment))),
                    IPathSegment parameter => Visit(parameter, segment)
                }})";

        private string Visit(RangePathSegment segment, IPathSegment? parent) =>
            string.Join(" and ",
                new[] {
                    segment.Start != null ? $"position() >= {segment.Start.Value + 1}" : null,
                    segment.End != null ? $"position() <= {segment.End.Value + 1}" : null,
                    segment.Step != null ? $"(position() mod {segment.Step.Value})=0" : null,
                }.Where(i => !string.IsNullOrWhiteSpace(i)));

        private string Visit(PathExistsPathSegment segment, IPathSegment? parent) => Visit(segment.Value, parent);

        private string Visit(RelationalOperationTypePathSegment segment, IPathSegment? parent) =>
            segment.Value switch
            {
                RelationalOperationTypes.Equal => "=",
                RelationalOperationTypes.GreaterThan => "&gt;",
                RelationalOperationTypes.GreaterThanOrEqual => "&gt;=",
                RelationalOperationTypes.LessThan => "&lt;",
                RelationalOperationTypes.LessThanOrEqual => "&lt;=",
                RelationalOperationTypes.NotEqual => "!=",
                _ => throw new ApplicationException(segment.Value.ToString())
            };

        private string Visit(LogicOperationTypePathSegment segment, IPathSegment? parent) =>
            segment.Value switch
            {
                LogicOperationTypes.And => "and",
                LogicOperationTypes.Or => "or",
                _ => throw new ApplicationException(segment.Value.ToString())
            };

        private string Visit(RelationBinaryOperationPathSegment segment, IPathSegment? parent) =>
            $@"{Visit(segment.Left, segment)} {Visit(segment.Operator, segment)} {Visit(segment.Right, segment)}";

        private string Visit(LogicBinaryOperationPathSegment segment, IPathSegment? parent) =>
            $@"{Visit(segment.Left, segment)} {Visit(segment.Operator, segment)} {Visit(segment.Right, segment)}";
    }
}
