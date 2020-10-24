using Antlr4.Runtime;

namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
{
    public static class JsonPathFactory
    {
        public static IPathSegment? Parse(string input) =>
            new JsonPathVisitor().Visit(
                new JsonPathParser(
                new CommonTokenStream(
                    new JsonPathLexer(
                        new AntlrInputStream(input)
                        )
                    )
                ).start()
            );
    }
}
