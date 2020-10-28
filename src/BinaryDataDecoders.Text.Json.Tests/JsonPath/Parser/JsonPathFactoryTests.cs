using Antlr4.Runtime.Misc;
using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.Text.Json.JsonPath.Parser;
using BinaryDataDecoders.ToolKit.Xml.XPath;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BinaryDataDecoders.Text.Json.Tests.JsonPath.Parser
{
    [TestClass]
    public class JsonPathFactoryTests
    {
        public TestContext TestContext { get; set; }

        [DataTestMethod, TestCategory(TestCategories.Unit)]
        [DataRow("$.options", ":/options")]
        [DataRow("$.options.quantity", ":/options/quantity")]
        [DataRow("$.*.quantity", ":/*/quantity")]
        [DataRow("$..quantity", ":////quantity")]
        [DataRow("$.obj.*.quantity", ":/obj/*/quantity")]
        [DataRow("$.options[0].quantity", ":/options/[0]/quantity")]
        [DataRow("$.store.book[*].author", ":/store/book/[*]/author")]
        [DataRow("$..author", ":////author")]
        [DataRow("$.store.*", ":/store/*")]
        [DataRow("$..book[2]", ":////book/[2]")]
        [DataRow("$..book[-2]", ":////book/[-2]")]
        [DataRow("$..*", ":////*")]
        [DataRow("$..book[-2", typeof(ParseCanceledException))]
        [DataRow("$.options[?(@.code=='AB1')].quantity", ":/options/{./code Equal \"AB1\"}/quantity")]
        [DataRow("$.options[?(@.code=='AB1'&&@.quantity>3)].quantity", ":/options/{./code Equal \"AB1\" And ./quantity GreaterThan 3}/quantity")]
        [DataRow("$..book[0,1]", ":////book/[0,1]")]
        [DataRow("$..book[:2]", ":////book/[:2:]")]
        [DataRow("$..book[1:2]", ":////book/[1:2:]")]
        [DataRow("$..book[-2:]", ":////book/[-2::]")]
        [DataRow("$..book[2:]", ":////book/[2::]")]
        [DataRow("@..book[2:]", ".////book/[2::]")]
        [DataRow("$..book[?(@.isbn)]", ":////book/{[./isbn]}")]
        [DataRow("$.store.book[?(@.price < 10)]", ":/store/book/{./price LessThan 10}")]
        [DataRow("$..book[?(@.price <= $['expensive'])]", ":////book/{./price LessThanOrEqual :/[\"expensive\"]}")]
        [DataRow("$.store..price", ":/store////price")]
        [DataRow("func()", "func()")]
        [DataRow("func($.options, $.*.quantity)", "func(:/options,:/*/quantity)")]
        [DataRow("$..book.length()", ":////book/length()")]
        [DataRow("func(1.0)", "func(1.0)")]
        [DataRow("func(0.12345)", "func(0.12345)")]
        [DataRow("func(-2570.764)", "func(-2570.764)")]
        [DataRow("func(func2($, @, 1, $.abc, 'xyz'), func3())", "func(func2(:,.,1,:/abc,\"xyz\"),func3())")]

        //[DataRow("$..book[?(@.author =~ /.*REES/i)]", "")]
        public void ParserTest(string query, object expected)
        {
            try
            {
                var result = JsonPathFactory.Parse(query);
                this.TestContext.WriteLine($"\"{query}\" == \"{result}\"");

                Assert.AreEqual(expected, result.ToString());
            }
            catch (Exception ex)
            {
                if (expected is Type type && type.IsInstanceOfType(ex))
                {
                    //Expected!
                    Assert.IsTrue(true);
                }
                else
                {
                    throw;
                }
            }
        }

        [DataTestMethod, TestCategory(TestCategories.Unit)]
        [DataRow("$.options", "/options")]
        [DataRow("$.options.quantity", "/options/quantity")]
        [DataRow("$.*.quantity", "/*/quantity")]
        [DataRow("$..quantity", "/descendant::quantity")]
        [DataRow("$.obj.*.quantity", "/obj/*/quantity")]
        [DataRow("$..author", "/descendant::author")]
        [DataRow("$.store.*", "/store/*")]
        [DataRow("$..*", "/descendant::*")]
        [DataRow("$..book[-2", typeof(ParseCanceledException))]
        [DataRow("$.store.book[*].author", "/store/book/*/author")]
        [DataRow("$..book[2]", "/descendant::book/*[3]")]
        [DataRow("$.options[0].quantity", "/options/*[1]/quantity")]
        [DataRow("$..book[0,1]", "/descendant::book/*[1 or 2]")]
        [DataRow("$['options']", "/*[local-name()='options']")]
        [DataRow("$['options','items']", "/*[local-name()='options' or local-name()='items']")]
        [DataRow("$.options[?(@.code=='AB1')].quantity", "/options[./code = 'AB1']/quantity")]
        [DataRow("$.options[?(@.code=='AB1'&&@.quantity>3)].quantity", "/options[./code = 'AB1' and ./quantity &gt; 3]/quantity")]
        [DataRow("$..book[?(@.isbn)]", "/descendant::book[./isbn]")]
        [DataRow("$..book[:2]", "/descendant::book/*[position() <= 3]")]
        [DataRow("$..book[1:2]", "/descendant::book/*[position() >= 2 and position() <= 3]")]
        [DataRow("$..book[::4]", "/descendant::book/*[(position() mod 4)=0]")]
        [DataRow("$..book[-2:]", "/descendant::book/*[position() >= -1]")]
        [DataRow("$..book[2:]", "/descendant::book/*[position() >= 3]")]
        [DataRow("$.store.book[?(@.price < 10)]", "/store/book[./price &lt; 10]")]
        [DataRow("$..book[?(@.price <= $['expensive'])]", "/descendant::book[./price &lt;= /*[local-name()='expensive']]")]
        [DataRow("$.store..price", "/store/descendant::price")]
        [DataRow("func()", "func()")]
        [DataRow("func($.options, $.*.quantity)", "func(/options,/*/quantity)")]
        [DataRow("$..book.length()", "/descendant::book/length()")]
        [DataRow("func(1.0)", "func(1.0)")]
        [DataRow("func(0.12345)", "func(0.12345)")]
        [DataRow("func(-2570.764)", "func(-2570.764)")]
        [DataRow("func(func2($, @, 1, $.abc, 'xyz'), func3())", "func(func2(/,./,1,/abc,'xyz'),func3())")]

        public void ToXPathTest(string query, object expected)
        {
            try
            {
                var pathSegment = JsonPathFactory.Parse(query);
                var xpath = pathSegment.ToXPathExpression();
                this.TestContext.WriteLine($"\"{query}\" == \"{xpath}\"");

                Assert.AreEqual(expected, xpath.ToString());
            }
            catch (Exception ex)
            {
                if (expected is Type type && type.IsInstanceOfType(ex))
                {
                    //Expected!
                    Assert.IsTrue(true);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
//https://goessner.net/articles/JsonPath/