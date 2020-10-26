using Antlr4.Runtime.Misc;
using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.Text.Json.JsonPath.Parser;
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

        //[DataTestMethod]
        //[DataRow("$.options", "/options")]
        //[DataRow("$.options.quantity", "/options/quantity")]
        //[DataRow("$.*.quantity", "/*/quantity")]
        //[DataRow("$..quantity", "//quantity")]
        //[DataRow("$.obj.*.quantity", "/obj/*/quantity")]
        //[DataRow("$.options[0].quantity", "/options[1]/quantity")]
        //[DataRow("$.store.book[*].author", "/store/book/*/author")]
        //[DataRow("$..author", "//author")]
        //[DataRow("$.store.*", "/store/*")]
        //[DataRow("$..book[2]", "//book[3]")]
        ////??? [DataRow("$..book[-2]", "//book/[-2]")]
        //[DataRow("$..*", "//*")]
        //[DataRow("$..book[-2", typeof(ParseCanceledException))]
        ////[DataRow("$.options[?(@.code=='AB1')].quantity", ":/options/{./code Equal \"AB1\"}/quantity")]
        ////[DataRow("$.options[?(@.code=='AB1'&&@.quantity>3)].quantity", ":/options/{./code Equal \"AB1\" And ./quantity GreaterThan 3}/quantity")]
        ////[DataRow("$..book[0,1]", ":////book/[0,1]")]
        ////[DataRow("$..book[:2]", ":////book/[:2:]")]
        ////[DataRow("$..book[1:2]", ":////book/[1:2:]")]
        ////[DataRow("$..book[-2:]", ":////book/[-2::]")]
        ////[DataRow("$..book[2:]", ":////book/[2::]")]
        ////[DataRow("$..book[?(@.isbn)]", ":////book/{[./isbn]}")]
        ////[DataRow("$.store.book[?(@.price < 10)]", ":/store/book/{./price LessThan 10}")]
        ////[DataRow("$..book[?(@.price <= $['expensive'])]", ":////book/{./price LessThanOrEqual :/[\"expensive\"]}")]
        ////[DataRow("$.store..price", ":/store////price")]
        ////[DataRow("func()", "func()")]
        ////[DataRow("func($.options, $.*.quantity)", "func(:/options,:/*/quantity)")]
        ////[DataRow("$..book.length()", ":////book/length()")]
        ////[DataRow("func(1.0)", "func(1.0)")]
        ////[DataRow("func(0.12345)", "func(0.12345)")]
        ////[DataRow("func(-2570.764)", "func(-2570.764)")]
        ////[DataRow("func(func2($, @, 1, $.abc, 'xyz'), func3())", "func(func2(:,.,1,:/abc,\"xyz\"),func3())")]
        //public void ToXPathTest(string query, object expected)
        //{
        //    try
        //    {
        //        var pathSegment = JsonPathFactory.Parse(query);
        //        var xpath = pathSegment.ToXPath();
        //        this.TestContext.WriteLine($"\"{query}\" == \"{xpath}\"");

        //        Assert.AreEqual(expected, xpath.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        if (expected is Type type && type.IsInstanceOfType(ex))
        //        {
        //            //Expected!
        //            Assert.IsTrue(true);
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //}
    }
}
//https://goessner.net/articles/JsonPath/