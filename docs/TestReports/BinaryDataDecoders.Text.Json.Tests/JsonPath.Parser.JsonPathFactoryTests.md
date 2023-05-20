# BinaryDataDecoders.Text.Json.Tests.JsonPath.Parser.JsonPathFactoryTests

## ToXPathTest ($.*.quantity,/*/quantity)

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.*.quantity" == "/*/quantity"
```

## ToXPathTest ($.options,/options)

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.options" == "/options"
```

## ParserTest ($.*.quantity,:/*/quantity)

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.*.quantity" == ":/*/quantity"
```

## ToXPathTest ($.options.quantity,/options/quantity)

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.options.quantity" == "/options/quantity"
```

## ParserTest ($.store.book[*].author,:/store/book/[*]/author)

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.store.book[*].author" == ":/store/book/[*]/author"
```

## ParserTest ($.options.quantity,:/options/quantity)

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.options.quantity" == ":/options/quantity"
```

## ToXPathTest ($.obj.*.quantity,/obj/*/quantity)

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.obj.*.quantity" == "/obj/*/quantity"
```

## ParserTest ($.options,:/options)

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.07

#### Standard Out

```
TestContext Messages:
"$.options" == ":/options"
```

## ToXPathTest ($..author,/descendant::author)

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..author" == "/descendant::author"
```

## ParserTest

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.options[0].quantity" == ":/options/[0]/quantity"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Error Out

```
line 1:10 no viable alternative at input '[-2'
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"func($.options, $.*.quantity)" == "func(:/options,:/*/quantity)"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..book[-2:]" == ":////book/[-2::]"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.options.quantity" == ":/options/quantity"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..*" == ":////*"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..book.length()" == ":////book/length()"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"func()" == "func()"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..book[2:]" == ":////book/[2::]"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.store.book[?(@.price < 10)]" == ":/store/book/{./price LessThan 10}"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.options" == ":/options"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..book[2]" == ":////book/[2]"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.options[?(@.code=='AB1')].quantity" == ":/options/{./code Equal "AB1"}/quantity"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..book[1:2]" == ":////book/[1:2:]"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..book[:2]" == ":////book/[:2:]"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..author" == ":////author"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"@..book[2:]" == ".////book/[2::]"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.*.quantity" == ":/*/quantity"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"func(1.0)" == "func(1.0)"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..book[-2]" == ":////book/[-2]"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..book[?(@.price <= $['expensive'])]" == ":////book/{./price LessThanOrEqual :/["expensive"]}"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"func(0.12345)" == "func(0.12345)"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.obj.*.quantity" == ":/obj/*/quantity"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"func(-2570.764)" == "func(-2570.764)"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.store.*" == ":/store/*"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..quantity" == ":////quantity"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.store..price" == ":/store////price"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..book[0,1]" == ":////book/[0,1]"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"func(func2($, @, 1, $.abc, 'xyz'), func3())" == "func(func2(:,.,1,:/abc,"xyz"),func3())"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.options[?(@.code=='AB1'&&@.quantity>3)].quantity" == ":/options/{./code Equal "AB1" And ./quantity GreaterThan 3}/quantity"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.store.book[*].author" == ":/store/book/[*]/author"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..book[?(@.isbn)]" == ":////book/{[./isbn]}"
```

## ParserTest ($.obj.*.quantity,:/obj/*/quantity)

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.obj.*.quantity" == ":/obj/*/quantity"
```

## ParserTest ($..book[-2],:////book/[-2])

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..book[-2]" == ":////book/[-2]"
```

## ParserTest ($.store.*,:/store/*)

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.store.*" == ":/store/*"
```

## ParserTest ($.options[0].quantity,:/options/[0]/quantity)

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.options[0].quantity" == ":/options/[0]/quantity"
```

## ToXPathTest ($..quantity,/descendant::quantity)

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..quantity" == "/descendant::quantity"
```

## ParserTest ($..book[2],:////book/[2])

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..book[2]" == ":////book/[2]"
```

## ToXPathTest ($..*,/descendant::*)

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..*" == "/descendant::*"
```

## ToXPathTest ($.store.*,/store/*)

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.store.*" == "/store/*"
```

## ToXPathTest

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Error Out

```
line 1:10 no viable alternative at input '[-2'
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..book[::4]" == "/descendant::book/*[(position() mod 4)=0]"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..book[1:2]" == "/descendant::book/*[position() >= 2 and position() <= 3]"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..author" == "/descendant::author"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..book.length()" == "/descendant::book/length()"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..book[:2]" == "/descendant::book/*[position() <= 3]"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"func()" == "func()"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$['options','items']" == "/*[local-name()='options' or local-name()='items']"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"func(func2($, @, 1, $.abc, 'xyz'), func3())" == "func(func2(/,./,1,/abc,'xyz'),func3())"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..book[2]" == "/descendant::book/*[3]"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.options[0].quantity" == "/options/*[1]/quantity"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.options[?(@.code=='AB1')].quantity" == "/options[./code = 'AB1']/quantity"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..book[-2:]" == "/descendant::book/*[position() >= -1]"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.options" == "/options"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..book[2:]" == "/descendant::book/*[position() >= 3]"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..quantity" == "/descendant::quantity"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..book[?(@.isbn)]" == "/descendant::book[./isbn]"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.obj.*.quantity" == "/obj/*/quantity"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"func($.options, $.*.quantity)" == "func(/options,/*/quantity)"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.store.book[*].author" == "/store/book/*/author"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.store.book[?(@.price < 10)]" == "/store/book[./price &lt; 10]"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..book[?(@.price <= $['expensive'])]" == "/descendant::book[./price &lt;= /*[local-name()='expensive']]"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"func(0.12345)" == "func(0.12345)"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..*" == "/descendant::*"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.store..price" == "/store/descendant::price"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$['options']" == "/*[local-name()='options']"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.options[?(@.code=='AB1'&&@.quantity>3)].quantity" == "/options[./code = 'AB1' and ./quantity &gt; 3]/quantity"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"func(-2570.764)" == "func(-2570.764)"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"func(1.0)" == "func(1.0)"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.options.quantity" == "/options/quantity"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..book[0,1]" == "/descendant::book/*[1 or 2]"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.*.quantity" == "/*/quantity"
```

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$.store.*" == "/store/*"
```

## ParserTest ($..*,:////*)

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..*" == ":////*"
```

## ParserTest ($..quantity,:////quantity)

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..quantity" == ":////quantity"
```

## ParserTest ($..author,:////author)

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
"$..author" == ":////author"
```

## Links

* [Back to Summary](../Summary.md)
* [Table of Contents](../../TOC.md)
