# BinaryDataDecoders.Text.Json.Tests.JsonPath.Parser.JsonPathFactoryTests

## Summary

| Key             | Value                                                                     |
| :-------------- | :------------------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.Text.Json.Tests.JsonPath.Parser.JsonPathFactoryTests` |
| Assembly        | `BinaryDataDecoders.Text.Json.Tests`                                      |
| Coveredlines    | `19`                                                                      |
| Uncoveredlines  | `2`                                                                       |
| Coverablelines  | `21`                                                                      |
| Totallines      | `133`                                                                     |
| Linecoverage    | `90.4`                                                                    |
| Coveredbranches | `4`                                                                       |
| Totalbranches   | `8`                                                                       |
| Branchcoverage  | `50`                                                                      |
| Coveredmethods  | `2`                                                                       |
| Totalmethods    | `2`                                                                       |
| Methodcoverage  | `100`                                                                     |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 4          | 90.0  | 50.0     | `ParserTest`  |
| 4          | 90.90 | 50.0     | `ToXPathTest` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Text.Json.Tests/JsonPath/Parser/JsonPathFactoryTests.cs

```CSharp
〰1:   using Antlr4.Runtime.Misc;
〰2:   using BinaryDataDecoders.TestUtilities;
〰3:   using BinaryDataDecoders.Text.Json.JsonPath.Parser;
〰4:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰5:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰6:   using System;
〰7:   
〰8:   namespace BinaryDataDecoders.Text.Json.Tests.JsonPath.Parser
〰9:   {
〰10:      [TestClass]
〰11:      public class JsonPathFactoryTests
〰12:      {
〰13:          public TestContext TestContext { get; set; }
〰14:  
〰15:          [DataTestMethod, TestCategory(TestCategories.Unit)]
〰16:          [DataRow("$.options", ":/options")]
〰17:          [DataRow("$.options.quantity", ":/options/quantity")]
〰18:          [DataRow("$.*.quantity", ":/*/quantity")]
〰19:          [DataRow("$..quantity", ":////quantity")]
〰20:          [DataRow("$.obj.*.quantity", ":/obj/*/quantity")]
〰21:          [DataRow("$.options[0].quantity", ":/options/[0]/quantity")]
〰22:          [DataRow("$.store.book[*].author", ":/store/book/[*]/author")]
〰23:          [DataRow("$..author", ":////author")]
〰24:          [DataRow("$.store.*", ":/store/*")]
〰25:          [DataRow("$..book[2]", ":////book/[2]")]
〰26:          [DataRow("$..book[-2]", ":////book/[-2]")]
〰27:          [DataRow("$..*", ":////*")]
〰28:          [DataRow("$..book[-2", typeof(ParseCanceledException))]
〰29:          [DataRow("$.options[?(@.code=='AB1')].quantity", ":/options/{./code Equal \"AB1\"}/quantity")]
〰30:          [DataRow("$.options[?(@.code=='AB1'&&@.quantity>3)].quantity", ":/options/{./code Equal \"AB1\" And ./quantity GreaterThan 3}/quantity")]
〰31:          [DataRow("$..book[0,1]", ":////book/[0,1]")]
〰32:          [DataRow("$..book[:2]", ":////book/[:2:]")]
〰33:          [DataRow("$..book[1:2]", ":////book/[1:2:]")]
〰34:          [DataRow("$..book[-2:]", ":////book/[-2::]")]
〰35:          [DataRow("$..book[2:]", ":////book/[2::]")]
〰36:          [DataRow("@..book[2:]", ".////book/[2::]")]
〰37:          [DataRow("$..book[?(@.isbn)]", ":////book/{[./isbn]}")]
〰38:          [DataRow("$.store.book[?(@.price < 10)]", ":/store/book/{./price LessThan 10}")]
〰39:          [DataRow("$..book[?(@.price <= $['expensive'])]", ":////book/{./price LessThanOrEqual :/[\"expensive\"]}")]
〰40:          [DataRow("$.store..price", ":/store////price")]
〰41:          [DataRow("func()", "func()")]
〰42:          [DataRow("func($.options, $.*.quantity)", "func(:/options,:/*/quantity)")]
〰43:          [DataRow("$..book.length()", ":////book/length()")]
〰44:          [DataRow("func(1.0)", "func(1.0)")]
〰45:          [DataRow("func(0.12345)", "func(0.12345)")]
〰46:          [DataRow("func(-2570.764)", "func(-2570.764)")]
〰47:          [DataRow("func(func2($, @, 1, $.abc, 'xyz'), func3())", "func(func2(:,.,1,:/abc,\"xyz\"),func3())")]
〰48:  
〰49:          //[DataRow("$..book[?(@.author =~ /.*REES/i)]", "")]
〰50:          public void ParserTest(string query, object expected)
〰51:          {
〰52:              try
〰53:              {
✔54:                  var result = JsonPathFactory.Parse(query);
✔55:                  this.TestContext.WriteLine($"\"{query}\" == \"{result}\"");
〰56:  
✔57:                  Assert.AreEqual(expected, result.ToString());
✔58:              }
✔59:              catch (Exception ex)
〰60:              {
⚠61:                  if (expected is Type type && type.IsInstanceOfType(ex))
〰62:                  {
〰63:                      //Expected!
✔64:                      Assert.IsTrue(true);
〰65:                  }
〰66:                  else
〰67:                  {
‼68:                      throw;
〰69:                  }
✔70:              }
✔71:          }
〰72:  
〰73:          [DataTestMethod, TestCategory(TestCategories.Unit)]
〰74:          [DataRow("$.options", "/options")]
〰75:          [DataRow("$.options.quantity", "/options/quantity")]
〰76:          [DataRow("$.*.quantity", "/*/quantity")]
〰77:          [DataRow("$..quantity", "/descendant::quantity")]
〰78:          [DataRow("$.obj.*.quantity", "/obj/*/quantity")]
〰79:          [DataRow("$..author", "/descendant::author")]
〰80:          [DataRow("$.store.*", "/store/*")]
〰81:          [DataRow("$..*", "/descendant::*")]
〰82:          [DataRow("$..book[-2", typeof(ParseCanceledException))]
〰83:          [DataRow("$.store.book[*].author", "/store/book/*/author")]
〰84:          [DataRow("$..book[2]", "/descendant::book/*[3]")]
〰85:          [DataRow("$.options[0].quantity", "/options/*[1]/quantity")]
〰86:          [DataRow("$..book[0,1]", "/descendant::book/*[1 or 2]")]
〰87:          [DataRow("$['options']", "/*[local-name()='options']")]
〰88:          [DataRow("$['options','items']", "/*[local-name()='options' or local-name()='items']")]
〰89:          [DataRow("$.options[?(@.code=='AB1')].quantity", "/options[./code = 'AB1']/quantity")]
〰90:          [DataRow("$.options[?(@.code=='AB1'&&@.quantity>3)].quantity", "/options[./code = 'AB1' and ./quantity &gt; 3]/quantity")]
〰91:          [DataRow("$..book[?(@.isbn)]", "/descendant::book[./isbn]")]
〰92:          [DataRow("$..book[:2]", "/descendant::book/*[position() <= 3]")]
〰93:          [DataRow("$..book[1:2]", "/descendant::book/*[position() >= 2 and position() <= 3]")]
〰94:          [DataRow("$..book[::4]", "/descendant::book/*[(position() mod 4)=0]")]
〰95:          [DataRow("$..book[-2:]", "/descendant::book/*[position() >= -1]")]
〰96:          [DataRow("$..book[2:]", "/descendant::book/*[position() >= 3]")]
〰97:          [DataRow("$.store.book[?(@.price < 10)]", "/store/book[./price &lt; 10]")]
〰98:          [DataRow("$..book[?(@.price <= $['expensive'])]", "/descendant::book[./price &lt;= /*[local-name()='expensive']]")]
〰99:          [DataRow("$.store..price", "/store/descendant::price")]
〰100:         [DataRow("func()", "func()")]
〰101:         [DataRow("func($.options, $.*.quantity)", "func(/options,/*/quantity)")]
〰102:         [DataRow("$..book.length()", "/descendant::book/length()")]
〰103:         [DataRow("func(1.0)", "func(1.0)")]
〰104:         [DataRow("func(0.12345)", "func(0.12345)")]
〰105:         [DataRow("func(-2570.764)", "func(-2570.764)")]
〰106:         [DataRow("func(func2($, @, 1, $.abc, 'xyz'), func3())", "func(func2(/,./,1,/abc,'xyz'),func3())")]
〰107: 
〰108:         public void ToXPathTest(string query, object expected)
〰109:         {
〰110:             try
〰111:             {
✔112:                 var pathSegment = JsonPathFactory.Parse(query);
✔113:                 var xpath = pathSegment.ToXPathExpression();
✔114:                 this.TestContext.WriteLine($"\"{query}\" == \"{xpath}\"");
〰115: 
✔116:                 Assert.AreEqual(expected, xpath.ToString());
✔117:             }
✔118:             catch (Exception ex)
〰119:             {
⚠120:                 if (expected is Type type && type.IsInstanceOfType(ex))
〰121:                 {
〰122:                     //Expected!
✔123:                     Assert.IsTrue(true);
〰124:                 }
〰125:                 else
〰126:                 {
‼127:                     throw;
〰128:                 }
✔129:             }
✔130:         }
〰131:     }
〰132: }
〰133: //https://goessner.net/articles/JsonPath/
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

