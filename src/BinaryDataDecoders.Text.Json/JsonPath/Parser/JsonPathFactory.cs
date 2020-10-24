using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{

    public interface IPathSegment
    {

    }
    public class NodeSegment : IPathSegment
    {
        private readonly object _ref;
        private readonly IPathSegment _child;
        private readonly string _type;

        public NodeSegment(object @ref, IPathSegment child, string type)
        {
            _ref = @ref;
            _child = child;
            _type = type;
        }

        public override string ToString() => _child.ToString();
    }
    public class ChainSegment : IPathSegment
    {
        private readonly object _ref;
        private readonly IEnumerable<IPathSegment> _children;

        public ChainSegment(object @ref, IEnumerable<IPathSegment> children)
        {
            _ref = @ref;
            _children = children.ToArray();
        }

        public override string ToString() => string.Join('/', _children);
    }
    public class IdentifierWithQualifierSegment : IPathSegment
    {
        private readonly object _ref;
        private readonly IPathSegment _identifier;
        private readonly IPathSegment _child;

        public IdentifierWithQualifierSegment(object @ref, IPathSegment identifier, IPathSegment child)
        {
            _ref = @ref;
            _identifier = identifier;
            _child = child;
        }

        public override string ToString() => $"{_identifier}[{_child}]";
    }
    public class TerminalSegment : IPathSegment
    {
        private readonly object _ref;
        private readonly IPathSegment _child;

        public TerminalSegment(object @ref)
        {
            _ref = @ref;
        }

        public override string ToString() => _ref?.ToString();
    }

    public class JsonPathVisitor : JsonPathBaseVisitor<IPathSegment?>
    {
        public override IPathSegment Visit(IParseTree tree)
        {
            if (tree == null) return null;
            return base.Visit(tree);
        }
        public override IPathSegment? VisitJsonpath([NotNull] JsonPathParser.JsonpathContext context) =>
            context == null ? null :
            new NodeSegment(context, Visit(context.dotnotation()), "Root");

        public override IPathSegment? VisitDotnotation([NotNull] JsonPathParser.DotnotationContext context) =>
            context == null ? null :
            new ChainSegment(context, context.dotnotation_expr().Select(Visit));

        public override IPathSegment? VisitIdentifierWithQualifier([NotNull] JsonPathParser.IdentifierWithQualifierContext context) =>
            context == null ? null :
            new IdentifierWithQualifierSegment(context, Visit(context.INDENTIFIER()), Visit(context.INT()) ?? Visit(context.query_expr()));

        public override IPathSegment? VisitDotnotation_expr([NotNull] JsonPathParser.Dotnotation_exprContext context) =>
            context == null ? null :
            new NodeSegment(context, Visit(context.identifierWithQualifier()) ?? Visit(context.INDENTIFIER()), "DotExp");

        public override IPathSegment? VisitTerminal(ITerminalNode node) =>
            node == null ? null :
            new TerminalSegment(node);

        public override IPathSegment? VisitQuery_expr([NotNull] JsonPathParser.Query_exprContext context)
        {
            return base.VisitQuery_expr(context);
        }

        //public override IPathSegment Visit(IParseTree tree)
        //{
        //    return base.Visit(tree);
        //}
    }

    /*

query_expr : query_expr ('&&' query_expr)+
           | query_expr ('||' query_expr)+
           | '*'
           | '@.' INDENTIFIER
           | '@.' INDENTIFIER '>' INT
           | '@.' INDENTIFIER '<' INT
           | '@.length-' INT
           | '@.' INDENTIFIER '==' INT
           | '@.' INDENTIFIER '==\'' INDENTIFIER '\''
           ;
    */

    public static class JsonPathFactory
    {
        public static IPathSegment Parse(string input) =>
            new JsonPathVisitor().Visit(
                new JsonPathParser(
                new CommonTokenStream(
                    new JsonPathLexer(
                        new AntlrInputStream(input)
                        )
                    )
                ).jsonpath()
            );
    }
}
