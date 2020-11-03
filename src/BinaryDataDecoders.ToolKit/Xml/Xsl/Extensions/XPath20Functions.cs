using BinaryDataDecoders.ToolKit.Xml.XPath;
using System;
using System.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions
{
    [XmlRoot(Namespace = @"http://www.w3.org/2005/xpath-functions")]
    public class XPath20Functions
    {
        public decimal abs(decimal input) => Math.Abs(input);
        public decimal ceiling(decimal input) => Math.Ceiling(input);
        public decimal count(XPathNodeIterator input) =>input.AsNavigatorSet().Count();
        public decimal avg(XPathNodeIterator input) => sum(input) / count(input);
        public bool exists(XPathNodeIterator input) => input.AsNavigatorSet().Any();
        public bool empty(XPathNodeIterator input) => !exists(input);
        public bool @false() => false;
        public bool not(bool input) => !input;
        public bool @true() => true;

        public decimal sum(XPathNodeIterator input) =>
            (from i in input.AsNavigatorSet()
             where !string.IsNullOrWhiteSpace(i.Value)
             let d = decimal.TryParse(i.Value, out var v) ? (decimal?)v : null
             where d.HasValue
             select d).Sum() ?? 0;

        public decimal max(XPathNodeIterator input) =>
            (from i in input.AsNavigatorSet()
             where !string.IsNullOrWhiteSpace(i.Value)
             let d = decimal.TryParse(i.Value, out var v) ? (decimal?)v : null
             where d.HasValue
             select d).Max() ?? 0;

        public decimal min(XPathNodeIterator input) =>
            (from i in input.AsNavigatorSet()
             where !string.IsNullOrWhiteSpace(i.Value)
             let d = decimal.TryParse(i.Value, out var v) ? (decimal?)v : null
             where d.HasValue
             select d).Min() ?? 0;

        // https://www.w3.org/2005/xpath-functions/

        [XsltFunction("distinct-values", HideOriginalName = true)]
        public XPathNodeIterator distinct_values(XPathNodeIterator input) =>
             new EnumerableXPathNodeIterator(
                from i in input.AsNavigatorSet()
                group i by i.Value into grouped
                from i in grouped
                select grouped.First());

        public XPathNodeIterator apply(string xpath, XPathNodeIterator input) =>
             new EnumerableXPathNodeIterator(
                from item in input.AsNavigatorSet()
                let value = item.Evaluate(xpath)
                from node in value.AsNodeSet()
                select node
                );
        /*

Returns the absolute value of $arg.

adjust-dateTime-to-timezone
adjust-dateTime-to-timezone(xs:dateTime?) as xs:dateTime?

adjust-dateTime-to-timezone(xs:dateTime?, xs:dayTimeDuration?) as xs:dateTime?

Adjusts an xs:dateTime value to a specific timezone, or to no timezone at all.

adjust-date-to-timezone
adjust-date-to-timezone(xs:date?) as xs:date?

adjust-date-to-timezone(xs:date?, xs:dayTimeDuration?) as xs:date?

Adjusts an xs:date value to a specific timezone, or to no timezone at all; the result is the date in the target timezone that contains the starting instant of the supplied date.

adjust-time-to-timezone
adjust-time-to-timezone(xs:time?) as xs:time?

adjust-time-to-timezone(xs:time?, xs:dayTimeDuration?) as xs:time?

Adjusts an xs:time value to a specific timezone, or to no timezone at all.

analyze-string
analyze-string(xs:string?, xs:string) as element(fn:analyze-string-result)

analyze-string(xs:string?, xs:string, xs:string) as element(fn:analyze-string-result)

Analyzes a string using a regular expression, returning an XML structure that identifies which parts of the input string matched or failed to match the regular expression, and in the case of matched substrings, which substrings matched each capturing group in the regular expression.

apply
apply(function(*), array(*)) as item()*

Makes a dynamic call on a function with an argument list supplied in the form of an array.

available-environment-variables
available-environment-variables() as xs:string*

Returns a list of environment variable names that are suitable for passing to fn:environment-variable, as a (possibly empty) sequence of strings.

base-uri
base-uri() as xs:anyURI?

base-uri(node()?) as xs:anyURI?

Returns the base URI of a node.

boolean
boolean(item()*) as xs:boolean

Computes the effective boolean value of the sequence $arg.

codepoint-equal
codepoint-equal(xs:string?, xs:string?) as xs:boolean?

Returns true if two strings are equal, considered codepoint-by-codepoint.

codepoints-to-string
codepoints-to-string(xs:integer*) as xs:string

Returns an xs:string whose characters have supplied codepoints.

collation-key
collation-key(xs:string) as xs:base64Binary

collation-key(xs:string, xs:string) as xs:base64Binary

Given a string value and a collation, generates an internal value called a collation key, with the property that the matching and ordering of collation keys reflects the matching and ordering of strings under the specified collation.

collection
collection() as item()*

collection(xs:string?) as item()*

Returns a sequence of items identified by a collection URI; or a default collection if no URI is supplied.

compare
compare(xs:string?, xs:string?) as xs:integer?

compare(xs:string?, xs:string?, xs:string) as xs:integer?

Returns -1, 0, or 1, depending on whether $comparand1 collates before, equal to, or after $comparand2 according to the rules of a selected collation.

concat
concat(xs:anyAtomicType?, xs:anyAtomicType?, xs:anyAtomicType?) as xs:string

Returns the concatenation of the string values of the arguments.

contains
contains(xs:string?, xs:string?) as xs:boolean

contains(xs:string?, xs:string?, xs:string) as xs:boolean

Returns true if the string $arg1 contains $arg2 as a substring, taking collations into account.

contains-token
contains-token(xs:string*, xs:string) as xs:boolean

contains-token(xs:string*, xs:string, xs:string) as xs:boolean

Determines whether or not any of the supplied strings, when tokenized at whitespace boundaries, contains the supplied token, under the rules of the supplied collation.

current-date
current-date() as xs:date

Returns the current date.

current-dateTime
current-dateTime() as xs:dateTimeStamp

Returns the current date and time (with timezone).

current-time
current-time() as xs:time

Returns the current time.

data
data() as xs:anyAtomicType*

data(item()*) as xs:anyAtomicType*

Returns the result of atomizing a sequence. This process flattens arrays, and replaces nodes by their typed values.

dateTime
dateTime(xs:date?, xs:time?) as xs:dateTime?

Returns an xs:dateTime value created by combining an xs:date and an xs:time.

day-from-date
day-from-date(xs:date?) as xs:integer?

Returns the day component of an xs:date.

day-from-dateTime
day-from-dateTime(xs:dateTime?) as xs:integer?

Returns the day component of an xs:dateTime.

days-from-duration
days-from-duration(xs:duration?) as xs:integer?

Returns the number of days in a duration.

deep-equal
deep-equal(item()*, item()*) as xs:boolean

deep-equal(item()*, item()*, xs:string) as xs:boolean

This function assesses whether two sequences are deep-equal to each other. To be deep-equal, they must contain items that are pairwise deep-equal; and for two items to be deep-equal, they must either be atomic values that compare equal, or nodes of the same kind, with the same name, whose children are deep-equal, or maps with matching entries, or arrays with matching members.

default-collation
default-collation() as xs:string

Returns the value of the default collation property from the static context.

default-language
default-language() as xs:language

Returns the value of the default language property from the dynamic context.

distinct-values
distinct-values(xs:anyAtomicType*) as xs:anyAtomicType*

distinct-values(xs:anyAtomicType*, xs:string) as xs:anyAtomicType*

Returns the values that appear in a sequence, with duplicates eliminated.

doc
doc(xs:string?) as document-node()?

Retrieves a document using a URI supplied as an xs:string, and returns the corresponding document node.

doc-available
doc-available(xs:string?) as xs:boolean

The function returns true if and only if the function call fn:doc($uri) would return a document node.

document-uri
document-uri() as xs:anyURI?

document-uri(node()?) as xs:anyURI?

Returns the URI of a resource where a document can be found, if available.

element-with-id
element-with-id(xs:string*) as element()*

element-with-id(xs:string*, node()) as element()*

Returns the sequence of element nodes that have an ID value matching the value of one or more of the IDREF values supplied in $arg.


encode-for-uri
encode-for-uri(xs:string?) as xs:string

Encodes reserved characters in a string that is intended to be used in the path segment of a URI.

ends-with
ends-with(xs:string?, xs:string?) as xs:boolean

ends-with(xs:string?, xs:string?, xs:string) as xs:boolean

Returns true if the string $arg1 contains $arg2 as a trailing substring, taking collations into account.

environment-variable
environment-variable(xs:string) as xs:string?

Returns the value of a system environment variable, if it exists.

error
error() as none

error(xs:QName?) as none

error(xs:QName?, xs:string) as none

error(xs:QName?, xs:string, item()*) as none

Calling the fn:error function raises an application-defined error.

escape-html-uri
escape-html-uri(xs:string?) as xs:string

Escapes a URI in the same way that HTML user agents handle attribute values expected to contain URIs.

exactly-one
exactly-one(item()*) as item()

Returns $arg if it contains exactly one item. Otherwise, raises an error.


filter
filter(item()*, function(item()) as xs:boolean) as item()*

Returns those items from the sequence $seq for which the supplied function $f returns true.

floor
floor(xs:numeric?) as xs:numeric?

Rounds $arg downwards to a whole number.

fold-left
fold-left(item()*, item()*, function(item()*, item()) as item()*) as item()*

Processes the supplied sequence from left to right, applying the supplied function repeatedly to each item in turn, together with an accumulated result value.

fold-right
fold-right(item()*, item()*, function(item(), item()*) as item()*) as item()*

Processes the supplied sequence from right to left, applying the supplied function repeatedly to each item in turn, together with an accumulated result value.

for-each
for-each(item()*, function(item()) as item()*) as item()*

Applies the function item $action to every item from the sequence $seq in turn, returning the concatenation of the resulting sequences in order.

for-each-pair
for-each-pair(item()*, item()*, function(item(), item()) as item()*) as item()*

Applies the function item $action to successive pairs of items taken one from $seq1 and one from $seq2, returning the concatenation of the resulting sequences in order.

format-date
format-date(xs:date?, xs:string) as xs:string?

format-date(xs:date?, xs:string, xs:string?, xs:string?, xs:string?) as xs:string?

Returns a string containing an xs:date value formatted for display.

format-dateTime
format-dateTime(xs:dateTime?, xs:string) as xs:string?

format-dateTime(xs:dateTime?, xs:string, xs:string?, xs:string?, xs:string?) as xs:string?

Returns a string containing an xs:dateTime value formatted for display.

format-integer
format-integer(xs:integer?, xs:string) as xs:string

format-integer(xs:integer?, xs:string, xs:string?) as xs:string

Formats an integer according to a given picture string, using the conventions of a given natural language if specified.

format-number
format-number(xs:numeric?, xs:string) as xs:string

format-number(xs:numeric?, xs:string, xs:string?) as xs:string

Returns a string containing a number formatted according to a given picture string, taking account of decimal formats specified in the static context.

format-time
format-time(xs:time?, xs:string) as xs:string?

format-time(xs:time?, xs:string, xs:string?, xs:string?, xs:string?) as xs:string?

Returns a string containing an xs:time value formatted for display.

function-arity
function-arity(function(*)) as xs:integer

Returns the arity of the function identified by a function item.

function-lookup
function-lookup(xs:QName, xs:integer) as function(*)?

Returns the function having a given name and arity, if there is one.

function-name
function-name(function(*)) as xs:QName?

Returns the name of the function identified by a function item.

generate-id
generate-id() as xs:string

generate-id(node()?) as xs:string

This function returns a string that uniquely identifies a given node.

has-children
has-children() as xs:boolean

has-children(node()?) as xs:boolean

Returns true if the supplied node has one or more child nodes (of any kind).

head
head(item()*) as item()?

Returns the first item in a sequence.

hours-from-dateTime
hours-from-dateTime(xs:dateTime?) as xs:integer?

Returns the hours component of an xs:dateTime.

hours-from-duration
hours-from-duration(xs:duration?) as xs:integer?

Returns the number of hours in a duration.

hours-from-time
hours-from-time(xs:time?) as xs:integer?

Returns the hours component of an xs:time.

id
id(xs:string*) as element()*

id(xs:string*, node()) as element()*

Returns the sequence of element nodes that have an ID value matching the value of one or more of the IDREF values supplied in $arg.

idref
idref(xs:string*) as node()*

idref(xs:string*, node()) as node()*

Returns the sequence of element or attribute nodes with an IDREF value matching the value of one or more of the ID values supplied in $arg.

implicit-timezone
implicit-timezone() as xs:dayTimeDuration

Returns the value of the implicit timezone property from the dynamic context.

index-of
index-of(xs:anyAtomicType*, xs:anyAtomicType) as xs:integer*

index-of(xs:anyAtomicType*, xs:anyAtomicType, xs:string) as xs:integer*

Returns a sequence of positive integers giving the positions within the sequence $seq of items that are equal to $search.

innermost
innermost(node()*) as node()*

Returns every node within the input sequence that is not an ancestor of another member of the input sequence; the nodes are returned in document order with duplicates eliminated.

in-scope-prefixes
in-scope-prefixes(element()) as xs:string*

Returns the prefixes of the in-scope namespaces for an element node.

insert-before
insert-before(item()*, xs:integer, item()*) as item()*

Returns a sequence constructed by inserting an item or a sequence of items at a given position within an existing sequence.

iri-to-uri
iri-to-uri(xs:string?) as xs:string

Converts a string containing an IRI into a URI according to the rules of [rfc3987].

json-doc
json-doc(xs:string?) as item()?

json-doc(xs:string?, map(*)) as item()?

Reads an external resource containing JSON, and returns the result of parsing the resource as JSON.

json-to-xml
json-to-xml(xs:string?) as document-node()?

json-to-xml(xs:string?, map(*)) as document-node()?

Parses a string supplied in the form of a JSON text, returning the results in the form of an XML document node.

lang
lang(xs:string?) as xs:boolean

lang(xs:string?, node()) as xs:boolean

This function tests whether the language of $node, or the context item if the second argument is omitted, as specified by xml:lang attributes is the same as, or is a sublanguage of, the language specified by $testlang.

last
last() as xs:integer

Returns the context size from the dynamic context.

load-xquery-module
load-xquery-module(xs:string) as map(*)

load-xquery-module(xs:string, map(*)) as map(*)

Provides access to the public functions and global variables of a dynamically-loaded XQuery library module.

local-name
local-name() as xs:string

local-name(node()?) as xs:string

Returns the local part of the name of $arg as an xs:string that is either the zero-length string, or has the lexical form of an xs:NCName.

local-name-from-QName
local-name-from-QName(xs:QName?) as xs:NCName?

Returns the local part of the supplied QName.

lower-case
lower-case(xs:string?) as xs:string

Converts a string to lower case.

matches
matches(xs:string?, xs:string) as xs:boolean

matches(xs:string?, xs:string, xs:string) as xs:boolean

Returns true if the supplied string matches a given regular expression.


Returns a value that is equal to the lowest value appearing in the input sequence.

minutes-from-dateTime
minutes-from-dateTime(xs:dateTime?) as xs:integer?

Returns the minute component of an xs:dateTime.

minutes-from-duration
minutes-from-duration(xs:duration?) as xs:integer?

Returns the number of minutes in a duration.

minutes-from-time
minutes-from-time(xs:time?) as xs:integer?

Returns the minutes component of an xs:time.

month-from-date
month-from-date(xs:date?) as xs:integer?

Returns the month component of an xs:date.

month-from-dateTime
month-from-dateTime(xs:dateTime?) as xs:integer?

Returns the month component of an xs:dateTime.

months-from-duration
months-from-duration(xs:duration?) as xs:integer?

Returns the number of months in a duration.

name
name() as xs:string

name(node()?) as xs:string

Returns the name of a node, as an xs:string that is either the zero-length string, or has the lexical form of an xs:QName.

namespace-uri
namespace-uri() as xs:anyURI

namespace-uri(node()?) as xs:anyURI

Returns the namespace URI part of the name of $arg, as an xs:anyURI value.

namespace-uri-for-prefix
namespace-uri-for-prefix(xs:string?, element()) as xs:anyURI?

Returns the namespace URI of one of the in-scope namespaces for $element, identified by its namespace prefix.

namespace-uri-from-QName
namespace-uri-from-QName(xs:QName?) as xs:anyURI?

Returns the namespace URI part of the supplied QName.

nilled
nilled() as xs:boolean?

nilled(node()?) as xs:boolean?

Returns true for an element that is nilled.

node-name
node-name() as xs:QName?

node-name(node()?) as xs:QName?

Returns the name of a node, as an xs:QName.

normalize-space
normalize-space() as xs:string

normalize-space(xs:string?) as xs:string

Returns the value of $arg with leading and trailing whitespace removed, and sequences of internal whitespace reduced to a single space character.

normalize-unicode
normalize-unicode(xs:string?) as xs:string

normalize-unicode(xs:string?, xs:string) as xs:string

Returns the value of $arg after applying Unicode normalization.

number
number() as xs:double

number(xs:anyAtomicType?) as xs:double

Returns the value indicated by $arg or, if $arg is not specified, the context item after atomization, converted to an xs:double.

one-or-more
one-or-more(item()*) as item()+

Returns $arg if it contains one or more items. Otherwise, raises an error.

outermost
outermost(node()*) as node()*

Returns every node within the input sequence that has no ancestor that is itself a member of the input sequence; the nodes are returned in document order with duplicates eliminated.

parse-ietf-date
parse-ietf-date(xs:string?) as xs:dateTime?

Parses a string containing the date and time in IETF format, returning the corresponding xs:dateTime value.

parse-json
parse-json(xs:string?) as item()?

parse-json(xs:string?, map(*)) as item()?

Parses a string supplied in the form of a JSON text, returning the results typically in the form of a map or array.

parse-xml
parse-xml(xs:string?) as document-node(element(*))?

This function takes as input an XML document represented as a string, and returns the document node at the root of an XDM tree representing the parsed document.

parse-xml-fragment
parse-xml-fragment(xs:string?) as document-node()?

This function takes as input an XML external entity represented as a string, and returns the document node at the root of an XDM tree representing the parsed document fragment.

path
path() as xs:string?

path(node()?) as xs:string?

Returns a path expression that can be used to select the supplied node relative to the root of its containing document.

position
position() as xs:integer

Returns the context position from the dynamic context.

prefix-from-QName
prefix-from-QName(xs:QName?) as xs:NCName?

Returns the prefix component of the supplied QName.

QName
QName(xs:string?, xs:string) as xs:QName

Returns an xs:QName value formed using a supplied namespace URI and lexical QName.

random-number-generator
random-number-generator() as map(xs:string, item())

random-number-generator(xs:anyAtomicType?) as map(xs:string, item())

Returns a random number generator, which can be used to generate sequences of random numbers.

remove
remove(item()*, xs:integer) as item()*

Returns a new sequence containing all the items of $target except the item at position $position.

replace
replace(xs:string?, xs:string, xs:string) as xs:string

replace(xs:string?, xs:string, xs:string, xs:string) as xs:string

Returns a string produced from the input string by replacing any substrings that match a given regular expression with a supplied replacement string.

resolve-QName
resolve-QName(xs:string?, element()) as xs:QName?

Returns an xs:QName value (that is, an expanded-QName) by taking an xs:string that has the lexical form of an xs:QName (a string in the form "prefix:local-name" or "local-name") and resolving it using the in-scope namespaces for a given element.

resolve-uri
resolve-uri(xs:string?) as xs:anyURI?

resolve-uri(xs:string?, xs:string) as xs:anyURI?

Resolves a relative IRI reference against an absolute IRI.

reverse
reverse(item()*) as item()*

Reverses the order of items in a sequence.

root
root() as node()

root(node()?) as node()?

Returns the root of the tree to which $arg belongs. This will usually, but not necessarily, be a document node.

round
round(xs:numeric?) as xs:numeric?

round(xs:numeric?, xs:integer) as xs:numeric?

Rounds a value to a specified number of decimal places, rounding upwards if two such values are equally near.

round-half-to-even
round-half-to-even(xs:numeric?) as xs:numeric?

round-half-to-even(xs:numeric?, xs:integer) as xs:numeric?

Rounds a value to a specified number of decimal places, rounding to make the last digit even if two such values are equally near.

seconds-from-dateTime
seconds-from-dateTime(xs:dateTime?) as xs:decimal?

Returns the seconds component of an xs:dateTime.

seconds-from-duration
seconds-from-duration(xs:duration?) as xs:decimal?

Returns the number of seconds in a duration.

seconds-from-time
seconds-from-time(xs:time?) as xs:decimal?

Returns the seconds component of an xs:time.

serialize
serialize(item()*) as xs:string

serialize(item()*, item()?) as xs:string

This function serializes the supplied input sequence $arg as described in [xslt-xquery-serialization-31], returning the serialized representation of the sequence as a string.

sort
sort(item()*) as item()*

sort(item()*, xs:string?) as item()*

sort(item()*, xs:string?, function(item()) as xs:anyAtomicType*) as item()*

Sorts a supplied sequence, based on the value of a sort key supplied as a function.

starts-with
starts-with(xs:string?, xs:string?) as xs:boolean

starts-with(xs:string?, xs:string?, xs:string) as xs:boolean

Returns true if the string $arg1 contains $arg2 as a leading substring, taking collations into account.

static-base-uri
static-base-uri() as xs:anyURI?

This function returns the value of the static base URI property from the static context.

string
string() as xs:string

string(item()?) as xs:string

Returns the value of $arg represented as an xs:string.

string-join
string-join(xs:anyAtomicType*) as xs:string

string-join(xs:anyAtomicType*, xs:string) as xs:string

Returns a string created by concatenating the items in a sequence, with a defined separator between adjacent items.

string-length
string-length() as xs:integer

string-length(xs:string?) as xs:integer

Returns the number of characters in a string.

string-to-codepoints
string-to-codepoints(xs:string?) as xs:integer*

Returns the sequence of codepoints that constitute an xs:string value.

subsequence
subsequence(item()*, xs:double) as item()*

subsequence(item()*, xs:double, xs:double) as item()*

Returns the contiguous sequence of items in the value of $sourceSeq beginning at the position indicated by the value of $startingLoc and continuing for the number of items indicated by the value of $length.

substring
substring(xs:string?, xs:double) as xs:string

substring(xs:string?, xs:double, xs:double) as xs:string

Returns the portion of the value of $sourceString beginning at the position indicated by the value of $start and continuing for the number of characters indicated by the value of $length.

substring-after
substring-after(xs:string?, xs:string?) as xs:string

substring-after(xs:string?, xs:string?, xs:string) as xs:string

Returns the part of $arg1 that follows the first occurrence of $arg2, taking collations into account.

substring-before
substring-before(xs:string?, xs:string?) as xs:string

substring-before(xs:string?, xs:string?, xs:string) as xs:string

Returns the part of $arg1 that precedes the first occurrence of $arg2, taking collations into account.

tail
tail(item()*) as item()*

Returns all but the first item in a sequence.

timezone-from-date
timezone-from-date(xs:date?) as xs:dayTimeDuration?

Returns the timezone component of an xs:date.

timezone-from-dateTime
timezone-from-dateTime(xs:dateTime?) as xs:dayTimeDuration?

Returns the timezone component of an xs:dateTime.

timezone-from-time
timezone-from-time(xs:time?) as xs:dayTimeDuration?

Returns the timezone component of an xs:time.

tokenize
tokenize(xs:string?) as xs:string*

tokenize(xs:string?, xs:string) as xs:string*

tokenize(xs:string?, xs:string, xs:string) as xs:string*

Returns a sequence of strings constructed by splitting the input wherever a separator is found; the separator is any substring that matches a given regular expression.

trace
trace(item()*) as item()*

trace(item()*, xs:string) as item()*

Provides an execution trace intended to be used in debugging queries.

transform
transform(map(*)) as map(*)

Invokes a transformation using a dynamically-loaded XSLT stylesheet.

translate
translate(xs:string?, xs:string, xs:string) as xs:string

Returns the value of $arg modified by replacing or removing individual characters.

unordered
unordered(item()*) as item()*

Returns the items of $sourceSeq in an implementation-dependent order.

unparsed-text
unparsed-text(xs:string?) as xs:string?

unparsed-text(xs:string?, xs:string) as xs:string?

The fn:unparsed-text function reads an external resource (for example, a file) and returns a string representation of the resource.

unparsed-text-available
unparsed-text-available(xs:string?) as xs:boolean

unparsed-text-available(xs:string?, xs:string) as xs:boolean

Because errors in evaluating the fn:unparsed-text function are non-recoverable, these two functions are provided to allow an application to determine whether a call with particular arguments would succeed.

unparsed-text-lines
unparsed-text-lines(xs:string?) as xs:string*

unparsed-text-lines(xs:string?, xs:string) as xs:string*

The fn:unparsed-text-lines function reads an external resource (for example, a file) and returns its contents as a sequence of strings, one for each line of text in the string representation of the resource.

upper-case
upper-case(xs:string?) as xs:string

Converts a string to upper case.

uri-collection
uri-collection() as xs:anyURI*

uri-collection(xs:string?) as xs:anyURI*

Returns a sequence of xs:anyURI values representing the URIs in a URI collection.

xml-to-json
xml-to-json(node()?) as xs:string?

xml-to-json(node()?, map(*)) as xs:string?

Converts an XML tree, whose format corresponds to the XML representation of JSON defined in this specification, into a string conforming to the JSON grammar.

year-from-date
year-from-date(xs:date?) as xs:integer?

Returns the year component of an xs:date.

year-from-dateTime
year-from-dateTime(xs:dateTime?) as xs:integer?

Returns the year component of an xs:dateTime.

years-from-duration
years-from-duration(xs:duration?) as xs:integer?

Returns the number of years in a duration.

zero-or-one
zero-or-one(item()*) as item()?

Returns $arg if it contains zero or one items. Otherwise, raises an error.

3 XSL Transformations (XSLT) Functions
This section lists all of the functions in this namespace that are defined in the [XSLT 3.0] specification.

The normative definitions of these functions are in the [XSLT 3.0] specification. For convenience, a very brief, non-normative summary of each function is provided. For details, follow the link on the “Summary:” introductory text below each function.

Note that XSLT 3.0, because it is not dependent on XPath 3.1, also reproduces some of the functions specifications that appear in XPath 3.1. For an XSLT 3.0 processor that works with XPath 3.0, the normative specification in this case is the one that appears in the XSLT 3.0 specification.

accumulator-after
accumulator-after(xs:string) as item()*

Returns the post-descent value of the selected accumulator at the context node.

accumulator-before
accumulator-before(xs:string) as item()*

Returns the pre-descent value of the selected accumulator at the context node.

available-system-properties
available-system-properties() as xs:QName*

Returns a list of system property names that are suitable for passing to the system-property function, as a sequence of QNames.

collation-key
collation-key(xs:string) as xs:base64Binary

collation-key(xs:string, xs:string) as xs:base64Binary

Given a string value and a collation, generates an internal value called a collation key, with the property that the matching and ordering of collation keys reflects the matching and ordering of strings under the specified collation.

copy-of
copy-of() as item()

copy-of(item()*) as item()*

Returns a deep copy of the sequence supplied as the $input argument, or of the context item if the argument is absent.

current
current() as item()

Returns the item that is the context item for the evaluation of the containing XPath expression

current-group
current-group() as item()*

Returns the group currently being processed by an xsl:for-each-group instruction.

current-grouping-key
current-grouping-key() as xs:anyAtomicType*

Returns the grouping key of the group currently being processed using the xsl:for-each-group instruction.

current-merge-group
current-merge-group() as item()*

current-merge-group(xs:string) as item()*

Returns the group of items currently being processed by an xsl:merge instruction.

current-merge-key
current-merge-key() as xs:anyAtomicType*

Returns the merge key of the merge group currently being processed using the xsl:merge instruction.

current-output-uri
current-output-uri() as xs:anyURI?

Returns the value of the .

deep-equal
deep-equal(item()*, item()*) as xs:boolean

deep-equal(item()*, item()*, xs:string) as xs:boolean

This function assesses whether two sequences are deep-equal to each other. The function as described here extends the definition of the XPath 3.0 deep-equal to explain how it should handle maps; it is intended to replace the existing deep-equal function at some stage in the future.

document
document(item()*) as node()*

document(item()*, node()) as node()*

Provides access to XML documents identified by a URI.

element-available
element-available(xs:string) as xs:boolean

Determines whether a particular instruction is or is not available for use. The function is particularly useful for calling within an [xsl:]use-when attribute (see ) to test whether a particular is available.

function-available
function-available(xs:string) as xs:boolean

function-available(xs:string, xs:integer) as xs:boolean

Determines whether a particular function is or is not available for use. The function is particularly useful for calling within an [xsl:]use-when attribute (see ) to test whether a particular is available.

json-to-xml
json-to-xml(xs:string) as document-node()

json-to-xml(xs:string, map(*)) as document-node()

Parses a string supplied in the form of a JSON text, returning the results in the form of an XML document node.

key
key(xs:string, xs:anyAtomicType*) as node()*

key(xs:string, xs:anyAtomicType*, node()) as node()*

Returns the nodes that match a supplied key value.

regex-group
regex-group(xs:integer) as xs:string

Returns the string captured by a parenthesized subexpression of the regular expression used during evaluation of the xsl:analyze-string instruction.

snapshot
snapshot() as item()

snapshot(item()*) as item()*

Returns a copy of a sequence, retaining copies of the ancestors and descendants of any node in the input sequence, together with their attributes and namespaces.

stream-available
stream-available(xs:string?) as xs:boolean

Determines, as far as possible, whether a document is available for streamed processing using xsl:source-document.

system-property
system-property(xs:string) as xs:string

Returns the value of a system property

type-available
type-available(xs:string) as xs:boolean

Used to control how a stylesheet behaves if a particular schema type is or is not available in the static context.

unparsed-entity-public-id
unparsed-entity-public-id(xs:string) as xs:string

unparsed-entity-public-id(xs:string, node()) as xs:string

Returns the public identifier of an unparsed entity

unparsed-entity-uri
unparsed-entity-uri(xs:string) as xs:anyURI

unparsed-entity-uri(xs:string, node()) as xs:anyURI

Returns the URI (system identifier) of an unparsed entity

xml-to-json
xml-to-json(node()?) as xs:string?

xml-to-json(node()?, map(*)) as xs:string?

Converts an XML tree, whose format corresponds to the XML representation of JSON defined in this specification, into a string conforming to the JSON grammar.

4 XQuery Update Functions
This section lists all of the functions in this namespace that are defined in the [XQuery Update 1.0] specification.

The normative definitions of these functions are in the [XQuery Update 1.0] specification. For convenience, a very brief, non-normative summary of each function is provided. For details, follow the link on the “Summary:” introductory text below each function.

put
put(node(), xs:string) as empty-sequence()

Stores a document or element to the location specified by $uri. This function is normally invoked to create a resource on an external storage system such as a file system or a database.

The external effects of fn:put are implementation-defined, since they occur outside the domain of XQuery. The intent is that, if fn:put is invoked on a document node and no error is raised, a subsequent query can access the stored document by invoking fn:doc with the same URI.


        */
    }
}
