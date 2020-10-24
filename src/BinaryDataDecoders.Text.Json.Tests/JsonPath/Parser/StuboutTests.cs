using Antlr4.Runtime;
using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.Text.Json.JsonPath.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.XPath;

namespace BinaryDataDecoders.Text.Json.Tests.JsonPath.Parser
{
    [TestClass]
    public class StuboutTests
    {
        public TestContext TestContext { get; set; }

        [DataTestMethod]
        [DataRow("$.options[0].quantity")]
        [DataRow("$.options[?(@.code=='AB1')].quantity")]
        [DataRow("$.options[?(@.code=='AB1'&&@.quantity>3)].quantity")]
        [DataRow("$.store.book[*].author")]
        [DataRow("$..author")]
        [DataRow("$.store.*")]
        [DataRow("$.store..price")]
        [DataRow("$..book[2]")]
        [DataRow("$..book[-2]")]
        [DataRow("$..book[0,1]")]
        [DataRow("$..book[:2]")]
        [DataRow("$..book[1:2]")]
        [DataRow("$..book[-2:]")]
        [DataRow("$..book[2:]")]
        [DataRow("$..book[?(@.isbn)]")]
        [DataRow("$.store.book[?(@.price < 10)]")]
        [DataRow("$..book[?(@.price <= $['expensive'])]")]
        [DataRow("$..book[?(@.author =~ /.*REES/i)]")]
        [DataRow("$..*")]
        [DataRow("$..book.length()")]
        public void ParserTest(string query)
        {
           var result = JsonPathFactory.Parse(query);
            this.TestContext.AddResult(result);
        }
    }
}
//https://goessner.net/articles/JsonPath/