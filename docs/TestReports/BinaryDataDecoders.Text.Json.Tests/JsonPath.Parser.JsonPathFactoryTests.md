# BinaryDataDecoders.Text.Json.Tests.JsonPath.Parser.JsonPathFactoryTests

## ParserTest

### Categories

* Unit

### Results

| Outcome              | Duration    | Test Name                                            |
| :------------------- | ----------: | :--------------------------------------------------- |
| ✔ Passed             | 00:00:00.12 | `ParserTest`                                         |
| ✔ Passed             | 00:00:00.08 | `ParserTest ($.options,:/options)`                   |
| ✔ Passed             | 00:00:00.00 | `ParserTest ($.options.quantity,:/options/quantity)` |
| ✔ Passed             | 00:00:00.00 | `ParserTest ($.*.quantity,:/*/quantity)`             |
| ✔ Passed             | 00:00:00.00 | `ParserTest ($..quantity,:////quantity)`             |
| ✔ Passed             | 00:00:00.00 | `ParserTest ($.obj.*.quantity,:/obj/*/quantity)`     |
| ✔ Passed             | 00:00:00.00 | `ParserTest ($.options[0].quantity,:/options/[0]/quantity)` |
| ✔ Passed             | 00:00:00.00 | `ParserTest ($.store.book[*].author,:/store/book/[*]/author)` |
| ✔ Passed             | 00:00:00.00 | `ParserTest ($..author,:////author)`                 |
| ✔ Passed             | 00:00:00.00 | `ParserTest ($.store.*,:/store/*)`                   |
| ✔ Passed             | 00:00:00.00 | `ParserTest ($..book[2],:////book/[2])`              |
| ✔ Passed             | 00:00:00.00 | `ParserTest ($..book[-2],:////book/[-2])`            |
| ✔ Passed             | 00:00:00.00 | `ParserTest ($..*,:////*)`                           |
| ✔ Passed             | 00:00:00.00 | `ParserTest ($..book[-2,Antlr4.Runtime.Misc.ParseCanceledException)` |
| ✔ Passed             | 00:00:00.01 | `ParserTest ($.options[?(@.code=='AB1')].quantity,:/options/{./code Equal "AB1"}/quantity)` |
| ✔ Passed             | 00:00:00.00 | `ParserTest ($.options[?(@.code=='AB1'&&@.quantity>3)].quantity,:/options/{./code Equal "AB1" And ./quantity GreaterThan 3}/quantity)` |
| ✔ Passed             | 00:00:00.00 | `ParserTest ($..book[0,1],:////book/[0,1])`          |
| ✔ Passed             | 00:00:00.00 | `ParserTest ($..book[:2],:////book/[:2:])`           |
| ✔ Passed             | 00:00:00.00 | `ParserTest ($..book[1:2],:////book/[1:2:])`         |
| ✔ Passed             | 00:00:00.00 | `ParserTest ($..book[-2:],:////book/[-2::])`         |
| ✔ Passed             | 00:00:00.00 | `ParserTest ($..book[2:],:////book/[2::])`           |
| ✔ Passed             | 00:00:00.00 | `ParserTest (@..book[2:],.////book/[2::])`           |
| ✔ Passed             | 00:00:00.00 | `ParserTest ($..book[?(@.isbn)],:////book/{[./isbn]})` |
| ✔ Passed             | 00:00:00.00 | `ParserTest ($.store.book[?(@.price < 10)],:/store/book/{./price LessThan 10})` |
| ✔ Passed             | 00:00:00.00 | `ParserTest ($..book[?(@.price <= $['expensive'])],:////book/{./price LessThanOrEqual :/["expensive"]})` |
| ✔ Passed             | 00:00:00.00 | `ParserTest ($.store..price,:/store////price)`       |
| ✔ Passed             | 00:00:00.00 | `ParserTest (func(),func())`                         |
| ✔ Passed             | 00:00:00.00 | `ParserTest (func($.options, $.*.quantity),func(:/options,:/*/quantity))` |
| ✔ Passed             | 00:00:00.00 | `ParserTest ($..book.length(),:////book/length())`   |
| ✔ Passed             | 00:00:00.00 | `ParserTest (func(1.0),func(1.0))`                   |
| ✔ Passed             | 00:00:00.00 | `ParserTest (func(0.12345),func(0.12345))`           |
| ✔ Passed             | 00:00:00.00 | `ParserTest (func(-2570.764),func(-2570.764))`       |
| ✔ Passed             | 00:00:00.00 | `ParserTest (func(func2($, @, 1, $.abc, 'xyz'), func3()),func(func2(:,.,1,:/abc,"xyz"),func3()))` |

## ToXPathTest

### Categories

* Unit

### Results

| Outcome              | Duration    | Test Name                                            |
| :------------------- | ----------: | :--------------------------------------------------- |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest`                                        |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($.options,/options)`                   |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($.options.quantity,/options/quantity)` |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($.*.quantity,/*/quantity)`             |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($..quantity,/descendant::quantity)`    |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($.obj.*.quantity,/obj/*/quantity)`     |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($..author,/descendant::author)`        |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($.store.*,/store/*)`                   |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($..*,/descendant::*)`                  |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($..book[-2,Antlr4.Runtime.Misc.ParseCanceledException)` |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($.store.book[*].author,/store/book/*/author)` |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($..book[2],/descendant::book/*[3])`    |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($.options[0].quantity,/options/*[1]/quantity)` |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($..book[0,1],/descendant::book/*[1 or 2])` |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($['options'],/*[local-name()='options'])` |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($['options','items'],/*[local-name()='options' or local-name()='items'])` |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($.options[?(@.code=='AB1')].quantity,/options[./code = 'AB1']/quantity)` |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($.options[?(@.code=='AB1'&&@.quantity>3)].quantity,/options[./code = 'AB1' and ./quantity &gt; 3]/quantity)` |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($..book[?(@.isbn)],/descendant::book[./isbn])` |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($..book[:2],/descendant::book/*[position() <= 3])` |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($..book[1:2],/descendant::book/*[position() >= 2 and position() <= 3])` |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($..book[::4],/descendant::book/*[(position() mod 4)=0])` |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($..book[-2:],/descendant::book/*[position() >= -1])` |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($..book[2:],/descendant::book/*[position() >= 3])` |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($.store.book[?(@.price < 10)],/store/book[./price &lt; 10])` |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($..book[?(@.price <= $['expensive'])],/descendant::book[./price &lt;= /*[local-name()='expensive']])` |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($.store..price,/store/descendant::price)` |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest (func(),func())`                        |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest (func($.options, $.*.quantity),func(/options,/*/quantity))` |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest ($..book.length(),/descendant::book/length())` |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest (func(1.0),func(1.0))`                  |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest (func(0.12345),func(0.12345))`          |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest (func(-2570.764),func(-2570.764))`      |
| ✔ Passed             | 00:00:00.00 | `ToXPathTest (func(func2($, @, 1, $.abc, 'xyz'), func3()),func(func2(/,./,1,/abc,'xyz'),func3()))` |

## Links

* [Back to Summary](../Summary.md)
* [Table of Contents](../../TOC.md)
