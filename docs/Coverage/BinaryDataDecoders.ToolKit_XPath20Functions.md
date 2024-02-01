# BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.XPath20Functions

## Summary

| Key             | Value                                                            |
| :-------------- | :--------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.XPath20Functions` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                     |
| Coveredlines    | `0`                                                              |
| Uncoveredlines  | `70`                                                             |
| Coverablelines  | `70`                                                             |
| Totallines      | `2193`                                                           |
| Linecoverage    | `0`                                                              |
| Coveredbranches | `0`                                                              |
| Totalbranches   | `12`                                                             |
| Branchcoverage  | `0`                                                              |
| Coveredmethods  | `0`                                                              |
| Totalmethods    | `28`                                                             |
| Methodcoverage  | `0`                                                              |

## Metrics

| Complexity | Lines | Branches | Name              |
| :--------- | :---- | :------- | :---------------- |
| 1          | 0     | 100      | `abs`             |
| 1          | 0     | 100      | `ceiling`         |
| 1          | 0     | 100      | `count`           |
| 1          | 0     | 100      | `avg`             |
| 1          | 0     | 100      | `exists`          |
| 1          | 0     | 100      | `empty`           |
| 1          | 0     | 100      | `false`           |
| 1          | 0     | 100      | `not`             |
| 1          | 0     | 100      | `true`            |
| 2          | 0     | 0        | `sum`             |
| 2          | 0     | 0        | `max`             |
| 2          | 0     | 0        | `min`             |
| 1          | 0     | 100      | `distinct_values` |
| 1          | 0     | 100      | `apply`           |
| 1          | 0     | 100      | `abs`             |
| 1          | 0     | 100      | `ceiling`         |
| 1          | 0     | 100      | `count`           |
| 1          | 0     | 100      | `avg`             |
| 1          | 0     | 100      | `exists`          |
| 1          | 0     | 100      | `empty`           |
| 1          | 0     | 100      | `false`           |
| 1          | 0     | 100      | `not`             |
| 1          | 0     | 100      | `true`            |
| 2          | 0     | 0        | `sum`             |
| 2          | 0     | 0        | `max`             |
| 2          | 0     | 0        | `min`             |
| 1          | 0     | 100      | `distinct_values` |
| 1          | 0     | 100      | `apply`           |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/Xsl/Extensions/XPath20Functions.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰2:   using System;
〰3:   using System.Linq;
〰4:   using System.Xml.Serialization;
〰5:   using System.Xml.XPath;
〰6:   
〰7:   namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions;
〰8:   
〰9:   [XmlRoot(Namespace = @"http://www.w3.org/2005/xpath-functions")]
〰10:  public class XPath20Functions
〰11:  {
〰12:  #pragma warning disable IDE1006 // Naming Styles
‼13:      public decimal abs(decimal input) => Math.Abs(input);
‼14:      public decimal ceiling(decimal input) => Math.Ceiling(input);
‼15:      public decimal count(XPathNodeIterator input) =>input.AsNavigatorSet().Count();
‼16:      public decimal avg(XPathNodeIterator input) => sum(input) / count(input);
‼17:      public bool exists(XPathNodeIterator input) => input.AsNavigatorSet().Any();
‼18:      public bool empty(XPathNodeIterator input) => !exists(input);
‼19:      public bool @false() => false;
‼20:      public bool not(bool input) => !input;
‼21:      public bool @true() => true;
〰22:  
〰23:      public decimal sum(XPathNodeIterator input) =>
‼24:          (from i in input.AsNavigatorSet()
‼25:           where !string.IsNullOrWhiteSpace(i.Value)
‼26:           let d = decimal.TryParse(i.Value, out var v) ? (decimal?)v : null
‼27:           where d.HasValue
‼28:           select d).Sum() ?? 0;
〰29:  
〰30:      public decimal max(XPathNodeIterator input) =>
‼31:          (from i in input.AsNavigatorSet()
‼32:           where !string.IsNullOrWhiteSpace(i.Value)
‼33:           let d = decimal.TryParse(i.Value, out var v) ? (decimal?)v : null
‼34:           where d.HasValue
‼35:           select d).Max() ?? 0;
〰36:  
〰37:      public decimal min(XPathNodeIterator input) =>
‼38:          (from i in input.AsNavigatorSet()
‼39:           where !string.IsNullOrWhiteSpace(i.Value)
‼40:           let d = decimal.TryParse(i.Value, out var v) ? (decimal?)v : null
‼41:           where d.HasValue
‼42:           select d).Min() ?? 0;
〰43:  
〰44:      // https://www.w3.org/2005/xpath-functions/
〰45:  
〰46:      [XsltFunction("distinct-values", HideOriginalName = true)]
〰47:      public XPathNodeIterator distinct_values(XPathNodeIterator input) =>
‼48:           new EnumerableXPathNodeIterator(
‼49:              from i in input.AsNavigatorSet()
‼50:              group i by i.Value into grouped
‼51:              from i in grouped
‼52:              select grouped.First());
〰53:  
〰54:      public XPathNodeIterator apply(string xpath, XPathNodeIterator input) =>
‼55:           new EnumerableXPathNodeIterator(
‼56:              from item in input.AsNavigatorSet()
‼57:              let value = item.Evaluate(xpath)
‼58:              from node in value.AsNodeSet()
‼59:              select node
‼60:              );
〰61:  
〰62:  #pragma warning restore IDE1006 // Naming Styles
〰63:  
〰64:      /*
〰65:  
〰66:  Returns the absolute value of $arg.
〰67:  
〰68:  adjust-dateTime-to-timezone
〰69:  adjust-dateTime-to-timezone(xs:dateTime?) as xs:dateTime?
〰70:  
〰71:  adjust-dateTime-to-timezone(xs:dateTime?, xs:dayTimeDuration?) as xs:dateTime?
〰72:  
〰73:  Adjusts an xs:dateTime value to a specific timezone, or to no timezone at all.
〰74:  
〰75:  adjust-date-to-timezone
〰76:  adjust-date-to-timezone(xs:date?) as xs:date?
〰77:  
〰78:  adjust-date-to-timezone(xs:date?, xs:dayTimeDuration?) as xs:date?
〰79:  
〰80:  Adjusts an xs:date value to a specific timezone, or to no timezone at all; the result is the date in the target timezone that contains the starting instant of the supplied date.
〰81:  
〰82:  adjust-time-to-timezone
〰83:  adjust-time-to-timezone(xs:time?) as xs:time?
〰84:  
〰85:  adjust-time-to-timezone(xs:time?, xs:dayTimeDuration?) as xs:time?
〰86:  
〰87:  Adjusts an xs:time value to a specific timezone, or to no timezone at all.
〰88:  
〰89:  analyze-string
〰90:  analyze-string(xs:string?, xs:string) as element(fn:analyze-string-result)
〰91:  
〰92:  analyze-string(xs:string?, xs:string, xs:string) as element(fn:analyze-string-result)
〰93:  
〰94:  Analyzes a string using a regular expression, returning an XML structure that identifies which parts of the input string matched or failed to match the regular expression, and in the case of matched substrings, which substrings matched each capturing group in the regular expression.
〰95:  
〰96:  apply
〰97:  apply(function(*), array(*)) as item()*
〰98:  
〰99:  Makes a dynamic call on a function with an argument list supplied in the form of an array.
〰100: 
〰101: available-environment-variables
〰102: available-environment-variables() as xs:string*
〰103: 
〰104: Returns a list of environment variable names that are suitable for passing to fn:environment-variable, as a (possibly empty) sequence of strings.
〰105: 
〰106: base-uri
〰107: base-uri() as xs:anyURI?
〰108: 
〰109: base-uri(node()?) as xs:anyURI?
〰110: 
〰111: Returns the base URI of a node.
〰112: 
〰113: boolean
〰114: boolean(item()*) as xs:boolean
〰115: 
〰116: Computes the effective boolean value of the sequence $arg.
〰117: 
〰118: codepoint-equal
〰119: codepoint-equal(xs:string?, xs:string?) as xs:boolean?
〰120: 
〰121: Returns true if two strings are equal, considered codepoint-by-codepoint.
〰122: 
〰123: codepoints-to-string
〰124: codepoints-to-string(xs:integer*) as xs:string
〰125: 
〰126: Returns an xs:string whose characters have supplied codepoints.
〰127: 
〰128: collation-key
〰129: collation-key(xs:string) as xs:base64Binary
〰130: 
〰131: collation-key(xs:string, xs:string) as xs:base64Binary
〰132: 
〰133: Given a string value and a collation, generates an internal value called a collation key, with the property that the matching and ordering of collation keys reflects the matching and ordering of strings under the specified collation.
〰134: 
〰135: collection
〰136: collection() as item()*
〰137: 
〰138: collection(xs:string?) as item()*
〰139: 
〰140: Returns a sequence of items identified by a collection URI; or a default collection if no URI is supplied.
〰141: 
〰142: compare
〰143: compare(xs:string?, xs:string?) as xs:integer?
〰144: 
〰145: compare(xs:string?, xs:string?, xs:string) as xs:integer?
〰146: 
〰147: Returns -1, 0, or 1, depending on whether $comparand1 collates before, equal to, or after $comparand2 according to the rules of a selected collation.
〰148: 
〰149: concat
〰150: concat(xs:anyAtomicType?, xs:anyAtomicType?, xs:anyAtomicType?) as xs:string
〰151: 
〰152: Returns the concatenation of the string values of the arguments.
〰153: 
〰154: contains
〰155: contains(xs:string?, xs:string?) as xs:boolean
〰156: 
〰157: contains(xs:string?, xs:string?, xs:string) as xs:boolean
〰158: 
〰159: Returns true if the string $arg1 contains $arg2 as a substring, taking collations into account.
〰160: 
〰161: contains-token
〰162: contains-token(xs:string*, xs:string) as xs:boolean
〰163: 
〰164: contains-token(xs:string*, xs:string, xs:string) as xs:boolean
〰165: 
〰166: Determines whether or not any of the supplied strings, when tokenized at whitespace boundaries, contains the supplied token, under the rules of the supplied collation.
〰167: 
〰168: current-date
〰169: current-date() as xs:date
〰170: 
〰171: Returns the current date.
〰172: 
〰173: current-dateTime
〰174: current-dateTime() as xs:dateTimeStamp
〰175: 
〰176: Returns the current date and time (with timezone).
〰177: 
〰178: current-time
〰179: current-time() as xs:time
〰180: 
〰181: Returns the current time.
〰182: 
〰183: data
〰184: data() as xs:anyAtomicType*
〰185: 
〰186: data(item()*) as xs:anyAtomicType*
〰187: 
〰188: Returns the result of atomizing a sequence. This process flattens arrays, and replaces nodes by their typed values.
〰189: 
〰190: dateTime
〰191: dateTime(xs:date?, xs:time?) as xs:dateTime?
〰192: 
〰193: Returns an xs:dateTime value created by combining an xs:date and an xs:time.
〰194: 
〰195: day-from-date
〰196: day-from-date(xs:date?) as xs:integer?
〰197: 
〰198: Returns the day component of an xs:date.
〰199: 
〰200: day-from-dateTime
〰201: day-from-dateTime(xs:dateTime?) as xs:integer?
〰202: 
〰203: Returns the day component of an xs:dateTime.
〰204: 
〰205: days-from-duration
〰206: days-from-duration(xs:duration?) as xs:integer?
〰207: 
〰208: Returns the number of days in a duration.
〰209: 
〰210: deep-equal
〰211: deep-equal(item()*, item()*) as xs:boolean
〰212: 
〰213: deep-equal(item()*, item()*, xs:string) as xs:boolean
〰214: 
〰215: This function assesses whether two sequences are deep-equal to each other. To be deep-equal, they must contain items that are pairwise deep-equal; and for two items to be deep-equal, they must either be atomic values that compare equal, or nodes of the same kind, with the same name, whose children are deep-equal, or maps with matching entries, or arrays with matching members.
〰216: 
〰217: default-collation
〰218: default-collation() as xs:string
〰219: 
〰220: Returns the value of the default collation property from the static context.
〰221: 
〰222: default-language
〰223: default-language() as xs:language
〰224: 
〰225: Returns the value of the default language property from the dynamic context.
〰226: 
〰227: distinct-values
〰228: distinct-values(xs:anyAtomicType*) as xs:anyAtomicType*
〰229: 
〰230: distinct-values(xs:anyAtomicType*, xs:string) as xs:anyAtomicType*
〰231: 
〰232: Returns the values that appear in a sequence, with duplicates eliminated.
〰233: 
〰234: doc
〰235: doc(xs:string?) as document-node()?
〰236: 
〰237: Retrieves a document using a URI supplied as an xs:string, and returns the corresponding document node.
〰238: 
〰239: doc-available
〰240: doc-available(xs:string?) as xs:boolean
〰241: 
〰242: The function returns true if and only if the function call fn:doc($uri) would return a document node.
〰243: 
〰244: document-uri
〰245: document-uri() as xs:anyURI?
〰246: 
〰247: document-uri(node()?) as xs:anyURI?
〰248: 
〰249: Returns the URI of a resource where a document can be found, if available.
〰250: 
〰251: element-with-id
〰252: element-with-id(xs:string*) as element()*
〰253: 
〰254: element-with-id(xs:string*, node()) as element()*
〰255: 
〰256: Returns the sequence of element nodes that have an ID value matching the value of one or more of the IDREF values supplied in $arg.
〰257: 
〰258: 
〰259: encode-for-uri
〰260: encode-for-uri(xs:string?) as xs:string
〰261: 
〰262: Encodes reserved characters in a string that is intended to be used in the path segment of a URI.
〰263: 
〰264: ends-with
〰265: ends-with(xs:string?, xs:string?) as xs:boolean
〰266: 
〰267: ends-with(xs:string?, xs:string?, xs:string) as xs:boolean
〰268: 
〰269: Returns true if the string $arg1 contains $arg2 as a trailing substring, taking collations into account.
〰270: 
〰271: environment-variable
〰272: environment-variable(xs:string) as xs:string?
〰273: 
〰274: Returns the value of a system environment variable, if it exists.
〰275: 
〰276: error
〰277: error() as none
〰278: 
〰279: error(xs:QName?) as none
〰280: 
〰281: error(xs:QName?, xs:string) as none
〰282: 
〰283: error(xs:QName?, xs:string, item()*) as none
〰284: 
〰285: Calling the fn:error function raises an application-defined error.
〰286: 
〰287: escape-html-uri
〰288: escape-html-uri(xs:string?) as xs:string
〰289: 
〰290: Escapes a URI in the same way that HTML user agents handle attribute values expected to contain URIs.
〰291: 
〰292: exactly-one
〰293: exactly-one(item()*) as item()
〰294: 
〰295: Returns $arg if it contains exactly one item. Otherwise, raises an error.
〰296: 
〰297: 
〰298: filter
〰299: filter(item()*, function(item()) as xs:boolean) as item()*
〰300: 
〰301: Returns those items from the sequence $seq for which the supplied function $f returns true.
〰302: 
〰303: floor
〰304: floor(xs:numeric?) as xs:numeric?
〰305: 
〰306: Rounds $arg downwards to a whole number.
〰307: 
〰308: fold-left
〰309: fold-left(item()*, item()*, function(item()*, item()) as item()*) as item()*
〰310: 
〰311: Processes the supplied sequence from left to right, applying the supplied function repeatedly to each item in turn, together with an accumulated result value.
〰312: 
〰313: fold-right
〰314: fold-right(item()*, item()*, function(item(), item()*) as item()*) as item()*
〰315: 
〰316: Processes the supplied sequence from right to left, applying the supplied function repeatedly to each item in turn, together with an accumulated result value.
〰317: 
〰318: for-each
〰319: for-each(item()*, function(item()) as item()*) as item()*
〰320: 
〰321: Applies the function item $action to every item from the sequence $seq in turn, returning the concatenation of the resulting sequences in order.
〰322: 
〰323: for-each-pair
〰324: for-each-pair(item()*, item()*, function(item(), item()) as item()*) as item()*
〰325: 
〰326: Applies the function item $action to successive pairs of items taken one from $seq1 and one from $seq2, returning the concatenation of the resulting sequences in order.
〰327: 
〰328: format-date
〰329: format-date(xs:date?, xs:string) as xs:string?
〰330: 
〰331: format-date(xs:date?, xs:string, xs:string?, xs:string?, xs:string?) as xs:string?
〰332: 
〰333: Returns a string containing an xs:date value formatted for display.
〰334: 
〰335: format-dateTime
〰336: format-dateTime(xs:dateTime?, xs:string) as xs:string?
〰337: 
〰338: format-dateTime(xs:dateTime?, xs:string, xs:string?, xs:string?, xs:string?) as xs:string?
〰339: 
〰340: Returns a string containing an xs:dateTime value formatted for display.
〰341: 
〰342: format-integer
〰343: format-integer(xs:integer?, xs:string) as xs:string
〰344: 
〰345: format-integer(xs:integer?, xs:string, xs:string?) as xs:string
〰346: 
〰347: Formats an integer according to a given picture string, using the conventions of a given natural language if specified.
〰348: 
〰349: format-number
〰350: format-number(xs:numeric?, xs:string) as xs:string
〰351: 
〰352: format-number(xs:numeric?, xs:string, xs:string?) as xs:string
〰353: 
〰354: Returns a string containing a number formatted according to a given picture string, taking account of decimal formats specified in the static context.
〰355: 
〰356: format-time
〰357: format-time(xs:time?, xs:string) as xs:string?
〰358: 
〰359: format-time(xs:time?, xs:string, xs:string?, xs:string?, xs:string?) as xs:string?
〰360: 
〰361: Returns a string containing an xs:time value formatted for display.
〰362: 
〰363: function-arity
〰364: function-arity(function(*)) as xs:integer
〰365: 
〰366: Returns the arity of the function identified by a function item.
〰367: 
〰368: function-lookup
〰369: function-lookup(xs:QName, xs:integer) as function(*)?
〰370: 
〰371: Returns the function having a given name and arity, if there is one.
〰372: 
〰373: function-name
〰374: function-name(function(*)) as xs:QName?
〰375: 
〰376: Returns the name of the function identified by a function item.
〰377: 
〰378: generate-id
〰379: generate-id() as xs:string
〰380: 
〰381: generate-id(node()?) as xs:string
〰382: 
〰383: This function returns a string that uniquely identifies a given node.
〰384: 
〰385: has-children
〰386: has-children() as xs:boolean
〰387: 
〰388: has-children(node()?) as xs:boolean
〰389: 
〰390: Returns true if the supplied node has one or more child nodes (of any kind).
〰391: 
〰392: head
〰393: head(item()*) as item()?
〰394: 
〰395: Returns the first item in a sequence.
〰396: 
〰397: hours-from-dateTime
〰398: hours-from-dateTime(xs:dateTime?) as xs:integer?
〰399: 
〰400: Returns the hours component of an xs:dateTime.
〰401: 
〰402: hours-from-duration
〰403: hours-from-duration(xs:duration?) as xs:integer?
〰404: 
〰405: Returns the number of hours in a duration.
〰406: 
〰407: hours-from-time
〰408: hours-from-time(xs:time?) as xs:integer?
〰409: 
〰410: Returns the hours component of an xs:time.
〰411: 
〰412: id
〰413: id(xs:string*) as element()*
〰414: 
〰415: id(xs:string*, node()) as element()*
〰416: 
〰417: Returns the sequence of element nodes that have an ID value matching the value of one or more of the IDREF values supplied in $arg.
〰418: 
〰419: idref
〰420: idref(xs:string*) as node()*
〰421: 
〰422: idref(xs:string*, node()) as node()*
〰423: 
〰424: Returns the sequence of element or attribute nodes with an IDREF value matching the value of one or more of the ID values supplied in $arg.
〰425: 
〰426: implicit-timezone
〰427: implicit-timezone() as xs:dayTimeDuration
〰428: 
〰429: Returns the value of the implicit timezone property from the dynamic context.
〰430: 
〰431: index-of
〰432: index-of(xs:anyAtomicType*, xs:anyAtomicType) as xs:integer*
〰433: 
〰434: index-of(xs:anyAtomicType*, xs:anyAtomicType, xs:string) as xs:integer*
〰435: 
〰436: Returns a sequence of positive integers giving the positions within the sequence $seq of items that are equal to $search.
〰437: 
〰438: innermost
〰439: innermost(node()*) as node()*
〰440: 
〰441: Returns every node within the input sequence that is not an ancestor of another member of the input sequence; the nodes are returned in document order with duplicates eliminated.
〰442: 
〰443: in-scope-prefixes
〰444: in-scope-prefixes(element()) as xs:string*
〰445: 
〰446: Returns the prefixes of the in-scope namespaces for an element node.
〰447: 
〰448: insert-before
〰449: insert-before(item()*, xs:integer, item()*) as item()*
〰450: 
〰451: Returns a sequence constructed by inserting an item or a sequence of items at a given position within an existing sequence.
〰452: 
〰453: iri-to-uri
〰454: iri-to-uri(xs:string?) as xs:string
〰455: 
〰456: Converts a string containing an IRI into a URI according to the rules of [rfc3987].
〰457: 
〰458: json-doc
〰459: json-doc(xs:string?) as item()?
〰460: 
〰461: json-doc(xs:string?, map(*)) as item()?
〰462: 
〰463: Reads an external resource containing JSON, and returns the result of parsing the resource as JSON.
〰464: 
〰465: json-to-xml
〰466: json-to-xml(xs:string?) as document-node()?
〰467: 
〰468: json-to-xml(xs:string?, map(*)) as document-node()?
〰469: 
〰470: Parses a string supplied in the form of a JSON text, returning the results in the form of an XML document node.
〰471: 
〰472: lang
〰473: lang(xs:string?) as xs:boolean
〰474: 
〰475: lang(xs:string?, node()) as xs:boolean
〰476: 
〰477: This function tests whether the language of $node, or the context item if the second argument is omitted, as specified by xml:lang attributes is the same as, or is a sublanguage of, the language specified by $testlang.
〰478: 
〰479: last
〰480: last() as xs:integer
〰481: 
〰482: Returns the context size from the dynamic context.
〰483: 
〰484: load-xquery-module
〰485: load-xquery-module(xs:string) as map(*)
〰486: 
〰487: load-xquery-module(xs:string, map(*)) as map(*)
〰488: 
〰489: Provides access to the public functions and global variables of a dynamically-loaded XQuery library module.
〰490: 
〰491: local-name
〰492: local-name() as xs:string
〰493: 
〰494: local-name(node()?) as xs:string
〰495: 
〰496: Returns the local part of the name of $arg as an xs:string that is either the zero-length string, or has the lexical form of an xs:NCName.
〰497: 
〰498: local-name-from-QName
〰499: local-name-from-QName(xs:QName?) as xs:NCName?
〰500: 
〰501: Returns the local part of the supplied QName.
〰502: 
〰503: lower-case
〰504: lower-case(xs:string?) as xs:string
〰505: 
〰506: Converts a string to lower case.
〰507: 
〰508: matches
〰509: matches(xs:string?, xs:string) as xs:boolean
〰510: 
〰511: matches(xs:string?, xs:string, xs:string) as xs:boolean
〰512: 
〰513: Returns true if the supplied string matches a given regular expression.
〰514: 
〰515: 
〰516: Returns a value that is equal to the lowest value appearing in the input sequence.
〰517: 
〰518: minutes-from-dateTime
〰519: minutes-from-dateTime(xs:dateTime?) as xs:integer?
〰520: 
〰521: Returns the minute component of an xs:dateTime.
〰522: 
〰523: minutes-from-duration
〰524: minutes-from-duration(xs:duration?) as xs:integer?
〰525: 
〰526: Returns the number of minutes in a duration.
〰527: 
〰528: minutes-from-time
〰529: minutes-from-time(xs:time?) as xs:integer?
〰530: 
〰531: Returns the minutes component of an xs:time.
〰532: 
〰533: month-from-date
〰534: month-from-date(xs:date?) as xs:integer?
〰535: 
〰536: Returns the month component of an xs:date.
〰537: 
〰538: month-from-dateTime
〰539: month-from-dateTime(xs:dateTime?) as xs:integer?
〰540: 
〰541: Returns the month component of an xs:dateTime.
〰542: 
〰543: months-from-duration
〰544: months-from-duration(xs:duration?) as xs:integer?
〰545: 
〰546: Returns the number of months in a duration.
〰547: 
〰548: name
〰549: name() as xs:string
〰550: 
〰551: name(node()?) as xs:string
〰552: 
〰553: Returns the name of a node, as an xs:string that is either the zero-length string, or has the lexical form of an xs:QName.
〰554: 
〰555: namespace-uri
〰556: namespace-uri() as xs:anyURI
〰557: 
〰558: namespace-uri(node()?) as xs:anyURI
〰559: 
〰560: Returns the namespace URI part of the name of $arg, as an xs:anyURI value.
〰561: 
〰562: namespace-uri-for-prefix
〰563: namespace-uri-for-prefix(xs:string?, element()) as xs:anyURI?
〰564: 
〰565: Returns the namespace URI of one of the in-scope namespaces for $element, identified by its namespace prefix.
〰566: 
〰567: namespace-uri-from-QName
〰568: namespace-uri-from-QName(xs:QName?) as xs:anyURI?
〰569: 
〰570: Returns the namespace URI part of the supplied QName.
〰571: 
〰572: nilled
〰573: nilled() as xs:boolean?
〰574: 
〰575: nilled(node()?) as xs:boolean?
〰576: 
〰577: Returns true for an element that is nilled.
〰578: 
〰579: node-name
〰580: node-name() as xs:QName?
〰581: 
〰582: node-name(node()?) as xs:QName?
〰583: 
〰584: Returns the name of a node, as an xs:QName.
〰585: 
〰586: normalize-space
〰587: normalize-space() as xs:string
〰588: 
〰589: normalize-space(xs:string?) as xs:string
〰590: 
〰591: Returns the value of $arg with leading and trailing whitespace removed, and sequences of internal whitespace reduced to a single space character.
〰592: 
〰593: normalize-unicode
〰594: normalize-unicode(xs:string?) as xs:string
〰595: 
〰596: normalize-unicode(xs:string?, xs:string) as xs:string
〰597: 
〰598: Returns the value of $arg after applying Unicode normalization.
〰599: 
〰600: number
〰601: number() as xs:double
〰602: 
〰603: number(xs:anyAtomicType?) as xs:double
〰604: 
〰605: Returns the value indicated by $arg or, if $arg is not specified, the context item after atomization, converted to an xs:double.
〰606: 
〰607: one-or-more
〰608: one-or-more(item()*) as item()+
〰609: 
〰610: Returns $arg if it contains one or more items. Otherwise, raises an error.
〰611: 
〰612: outermost
〰613: outermost(node()*) as node()*
〰614: 
〰615: Returns every node within the input sequence that has no ancestor that is itself a member of the input sequence; the nodes are returned in document order with duplicates eliminated.
〰616: 
〰617: parse-ietf-date
〰618: parse-ietf-date(xs:string?) as xs:dateTime?
〰619: 
〰620: Parses a string containing the date and time in IETF format, returning the corresponding xs:dateTime value.
〰621: 
〰622: parse-json
〰623: parse-json(xs:string?) as item()?
〰624: 
〰625: parse-json(xs:string?, map(*)) as item()?
〰626: 
〰627: Parses a string supplied in the form of a JSON text, returning the results typically in the form of a map or array.
〰628: 
〰629: parse-xml
〰630: parse-xml(xs:string?) as document-node(element(*))?
〰631: 
〰632: This function takes as input an XML document represented as a string, and returns the document node at the root of an XDM tree representing the parsed document.
〰633: 
〰634: parse-xml-fragment
〰635: parse-xml-fragment(xs:string?) as document-node()?
〰636: 
〰637: This function takes as input an XML external entity represented as a string, and returns the document node at the root of an XDM tree representing the parsed document fragment.
〰638: 
〰639: path
〰640: path() as xs:string?
〰641: 
〰642: path(node()?) as xs:string?
〰643: 
〰644: Returns a path expression that can be used to select the supplied node relative to the root of its containing document.
〰645: 
〰646: position
〰647: position() as xs:integer
〰648: 
〰649: Returns the context position from the dynamic context.
〰650: 
〰651: prefix-from-QName
〰652: prefix-from-QName(xs:QName?) as xs:NCName?
〰653: 
〰654: Returns the prefix component of the supplied QName.
〰655: 
〰656: QName
〰657: QName(xs:string?, xs:string) as xs:QName
〰658: 
〰659: Returns an xs:QName value formed using a supplied namespace URI and lexical QName.
〰660: 
〰661: random-number-generator
〰662: random-number-generator() as map(xs:string, item())
〰663: 
〰664: random-number-generator(xs:anyAtomicType?) as map(xs:string, item())
〰665: 
〰666: Returns a random number generator, which can be used to generate sequences of random numbers.
〰667: 
〰668: remove
〰669: remove(item()*, xs:integer) as item()*
〰670: 
〰671: Returns a new sequence containing all the items of $target except the item at position $position.
〰672: 
〰673: replace
〰674: replace(xs:string?, xs:string, xs:string) as xs:string
〰675: 
〰676: replace(xs:string?, xs:string, xs:string, xs:string) as xs:string
〰677: 
〰678: Returns a string produced from the input string by replacing any substrings that match a given regular expression with a supplied replacement string.
〰679: 
〰680: resolve-QName
〰681: resolve-QName(xs:string?, element()) as xs:QName?
〰682: 
〰683: Returns an xs:QName value (that is, an expanded-QName) by taking an xs:string that has the lexical form of an xs:QName (a string in the form "prefix:local-name" or "local-name") and resolving it using the in-scope namespaces for a given element.
〰684: 
〰685: resolve-uri
〰686: resolve-uri(xs:string?) as xs:anyURI?
〰687: 
〰688: resolve-uri(xs:string?, xs:string) as xs:anyURI?
〰689: 
〰690: Resolves a relative IRI reference against an absolute IRI.
〰691: 
〰692: reverse
〰693: reverse(item()*) as item()*
〰694: 
〰695: Reverses the order of items in a sequence.
〰696: 
〰697: root
〰698: root() as node()
〰699: 
〰700: root(node()?) as node()?
〰701: 
〰702: Returns the root of the tree to which $arg belongs. This will usually, but not necessarily, be a document node.
〰703: 
〰704: round
〰705: round(xs:numeric?) as xs:numeric?
〰706: 
〰707: round(xs:numeric?, xs:integer) as xs:numeric?
〰708: 
〰709: Rounds a value to a specified number of decimal places, rounding upwards if two such values are equally near.
〰710: 
〰711: round-half-to-even
〰712: round-half-to-even(xs:numeric?) as xs:numeric?
〰713: 
〰714: round-half-to-even(xs:numeric?, xs:integer) as xs:numeric?
〰715: 
〰716: Rounds a value to a specified number of decimal places, rounding to make the last digit even if two such values are equally near.
〰717: 
〰718: seconds-from-dateTime
〰719: seconds-from-dateTime(xs:dateTime?) as xs:decimal?
〰720: 
〰721: Returns the seconds component of an xs:dateTime.
〰722: 
〰723: seconds-from-duration
〰724: seconds-from-duration(xs:duration?) as xs:decimal?
〰725: 
〰726: Returns the number of seconds in a duration.
〰727: 
〰728: seconds-from-time
〰729: seconds-from-time(xs:time?) as xs:decimal?
〰730: 
〰731: Returns the seconds component of an xs:time.
〰732: 
〰733: serialize
〰734: serialize(item()*) as xs:string
〰735: 
〰736: serialize(item()*, item()?) as xs:string
〰737: 
〰738: This function serializes the supplied input sequence $arg as described in [xslt-xquery-serialization-31], returning the serialized representation of the sequence as a string.
〰739: 
〰740: sort
〰741: sort(item()*) as item()*
〰742: 
〰743: sort(item()*, xs:string?) as item()*
〰744: 
〰745: sort(item()*, xs:string?, function(item()) as xs:anyAtomicType*) as item()*
〰746: 
〰747: Sorts a supplied sequence, based on the value of a sort key supplied as a function.
〰748: 
〰749: starts-with
〰750: starts-with(xs:string?, xs:string?) as xs:boolean
〰751: 
〰752: starts-with(xs:string?, xs:string?, xs:string) as xs:boolean
〰753: 
〰754: Returns true if the string $arg1 contains $arg2 as a leading substring, taking collations into account.
〰755: 
〰756: static-base-uri
〰757: static-base-uri() as xs:anyURI?
〰758: 
〰759: This function returns the value of the static base URI property from the static context.
〰760: 
〰761: string
〰762: string() as xs:string
〰763: 
〰764: string(item()?) as xs:string
〰765: 
〰766: Returns the value of $arg represented as an xs:string.
〰767: 
〰768: string-join
〰769: string-join(xs:anyAtomicType*) as xs:string
〰770: 
〰771: string-join(xs:anyAtomicType*, xs:string) as xs:string
〰772: 
〰773: Returns a string created by concatenating the items in a sequence, with a defined separator between adjacent items.
〰774: 
〰775: string-length
〰776: string-length() as xs:integer
〰777: 
〰778: string-length(xs:string?) as xs:integer
〰779: 
〰780: Returns the number of characters in a string.
〰781: 
〰782: string-to-codepoints
〰783: string-to-codepoints(xs:string?) as xs:integer*
〰784: 
〰785: Returns the sequence of codepoints that constitute an xs:string value.
〰786: 
〰787: subsequence
〰788: subsequence(item()*, xs:double) as item()*
〰789: 
〰790: subsequence(item()*, xs:double, xs:double) as item()*
〰791: 
〰792: Returns the contiguous sequence of items in the value of $sourceSeq beginning at the position indicated by the value of $startingLoc and continuing for the number of items indicated by the value of $length.
〰793: 
〰794: substring
〰795: substring(xs:string?, xs:double) as xs:string
〰796: 
〰797: substring(xs:string?, xs:double, xs:double) as xs:string
〰798: 
〰799: Returns the portion of the value of $sourceString beginning at the position indicated by the value of $start and continuing for the number of characters indicated by the value of $length.
〰800: 
〰801: substring-after
〰802: substring-after(xs:string?, xs:string?) as xs:string
〰803: 
〰804: substring-after(xs:string?, xs:string?, xs:string) as xs:string
〰805: 
〰806: Returns the part of $arg1 that follows the first occurrence of $arg2, taking collations into account.
〰807: 
〰808: substring-before
〰809: substring-before(xs:string?, xs:string?) as xs:string
〰810: 
〰811: substring-before(xs:string?, xs:string?, xs:string) as xs:string
〰812: 
〰813: Returns the part of $arg1 that precedes the first occurrence of $arg2, taking collations into account.
〰814: 
〰815: tail
〰816: tail(item()*) as item()*
〰817: 
〰818: Returns all but the first item in a sequence.
〰819: 
〰820: timezone-from-date
〰821: timezone-from-date(xs:date?) as xs:dayTimeDuration?
〰822: 
〰823: Returns the timezone component of an xs:date.
〰824: 
〰825: timezone-from-dateTime
〰826: timezone-from-dateTime(xs:dateTime?) as xs:dayTimeDuration?
〰827: 
〰828: Returns the timezone component of an xs:dateTime.
〰829: 
〰830: timezone-from-time
〰831: timezone-from-time(xs:time?) as xs:dayTimeDuration?
〰832: 
〰833: Returns the timezone component of an xs:time.
〰834: 
〰835: tokenize
〰836: tokenize(xs:string?) as xs:string*
〰837: 
〰838: tokenize(xs:string?, xs:string) as xs:string*
〰839: 
〰840: tokenize(xs:string?, xs:string, xs:string) as xs:string*
〰841: 
〰842: Returns a sequence of strings constructed by splitting the input wherever a separator is found; the separator is any substring that matches a given regular expression.
〰843: 
〰844: trace
〰845: trace(item()*) as item()*
〰846: 
〰847: trace(item()*, xs:string) as item()*
〰848: 
〰849: Provides an execution trace intended to be used in debugging queries.
〰850: 
〰851: transform
〰852: transform(map(*)) as map(*)
〰853: 
〰854: Invokes a transformation using a dynamically-loaded XSLT stylesheet.
〰855: 
〰856: translate
〰857: translate(xs:string?, xs:string, xs:string) as xs:string
〰858: 
〰859: Returns the value of $arg modified by replacing or removing individual characters.
〰860: 
〰861: unordered
〰862: unordered(item()*) as item()*
〰863: 
〰864: Returns the items of $sourceSeq in an implementation-dependent order.
〰865: 
〰866: unparsed-text
〰867: unparsed-text(xs:string?) as xs:string?
〰868: 
〰869: unparsed-text(xs:string?, xs:string) as xs:string?
〰870: 
〰871: The fn:unparsed-text function reads an external resource (for example, a file) and returns a string representation of the resource.
〰872: 
〰873: unparsed-text-available
〰874: unparsed-text-available(xs:string?) as xs:boolean
〰875: 
〰876: unparsed-text-available(xs:string?, xs:string) as xs:boolean
〰877: 
〰878: Because errors in evaluating the fn:unparsed-text function are non-recoverable, these two functions are provided to allow an application to determine whether a call with particular arguments would succeed.
〰879: 
〰880: unparsed-text-lines
〰881: unparsed-text-lines(xs:string?) as xs:string*
〰882: 
〰883: unparsed-text-lines(xs:string?, xs:string) as xs:string*
〰884: 
〰885: The fn:unparsed-text-lines function reads an external resource (for example, a file) and returns its contents as a sequence of strings, one for each line of text in the string representation of the resource.
〰886: 
〰887: upper-case
〰888: upper-case(xs:string?) as xs:string
〰889: 
〰890: Converts a string to upper case.
〰891: 
〰892: uri-collection
〰893: uri-collection() as xs:anyURI*
〰894: 
〰895: uri-collection(xs:string?) as xs:anyURI*
〰896: 
〰897: Returns a sequence of xs:anyURI values representing the URIs in a URI collection.
〰898: 
〰899: xml-to-json
〰900: xml-to-json(node()?) as xs:string?
〰901: 
〰902: xml-to-json(node()?, map(*)) as xs:string?
〰903: 
〰904: Converts an XML tree, whose format corresponds to the XML representation of JSON defined in this specification, into a string conforming to the JSON grammar.
〰905: 
〰906: year-from-date
〰907: year-from-date(xs:date?) as xs:integer?
〰908: 
〰909: Returns the year component of an xs:date.
〰910: 
〰911: year-from-dateTime
〰912: year-from-dateTime(xs:dateTime?) as xs:integer?
〰913: 
〰914: Returns the year component of an xs:dateTime.
〰915: 
〰916: years-from-duration
〰917: years-from-duration(xs:duration?) as xs:integer?
〰918: 
〰919: Returns the number of years in a duration.
〰920: 
〰921: zero-or-one
〰922: zero-or-one(item()*) as item()?
〰923: 
〰924: Returns $arg if it contains zero or one items. Otherwise, raises an error.
〰925: 
〰926: 3 XSL Transformations (XSLT) Functions
〰927: This section lists all of the functions in this namespace that are defined in the [XSLT 3.0] specification.
〰928: 
〰929: The normative definitions of these functions are in the [XSLT 3.0] specification. For convenience, a very brief, non-normative summary of each function is provided. For details, follow the link on the “Summary:” introductory text below each function.
〰930: 
〰931: Note that XSLT 3.0, because it is not dependent on XPath 3.1, also reproduces some of the functions specifications that appear in XPath 3.1. For an XSLT 3.0 processor that works with XPath 3.0, the normative specification in this case is the one that appears in the XSLT 3.0 specification.
〰932: 
〰933: accumulator-after
〰934: accumulator-after(xs:string) as item()*
〰935: 
〰936: Returns the post-descent value of the selected accumulator at the context node.
〰937: 
〰938: accumulator-before
〰939: accumulator-before(xs:string) as item()*
〰940: 
〰941: Returns the pre-descent value of the selected accumulator at the context node.
〰942: 
〰943: available-system-properties
〰944: available-system-properties() as xs:QName*
〰945: 
〰946: Returns a list of system property names that are suitable for passing to the system-property function, as a sequence of QNames.
〰947: 
〰948: collation-key
〰949: collation-key(xs:string) as xs:base64Binary
〰950: 
〰951: collation-key(xs:string, xs:string) as xs:base64Binary
〰952: 
〰953: Given a string value and a collation, generates an internal value called a collation key, with the property that the matching and ordering of collation keys reflects the matching and ordering of strings under the specified collation.
〰954: 
〰955: copy-of
〰956: copy-of() as item()
〰957: 
〰958: copy-of(item()*) as item()*
〰959: 
〰960: Returns a deep copy of the sequence supplied as the $input argument, or of the context item if the argument is absent.
〰961: 
〰962: current
〰963: current() as item()
〰964: 
〰965: Returns the item that is the context item for the evaluation of the containing XPath expression
〰966: 
〰967: current-group
〰968: current-group() as item()*
〰969: 
〰970: Returns the group currently being processed by an xsl:for-each-group instruction.
〰971: 
〰972: current-grouping-key
〰973: current-grouping-key() as xs:anyAtomicType*
〰974: 
〰975: Returns the grouping key of the group currently being processed using the xsl:for-each-group instruction.
〰976: 
〰977: current-merge-group
〰978: current-merge-group() as item()*
〰979: 
〰980: current-merge-group(xs:string) as item()*
〰981: 
〰982: Returns the group of items currently being processed by an xsl:merge instruction.
〰983: 
〰984: current-merge-key
〰985: current-merge-key() as xs:anyAtomicType*
〰986: 
〰987: Returns the merge key of the merge group currently being processed using the xsl:merge instruction.
〰988: 
〰989: current-output-uri
〰990: current-output-uri() as xs:anyURI?
〰991: 
〰992: Returns the value of the .
〰993: 
〰994: deep-equal
〰995: deep-equal(item()*, item()*) as xs:boolean
〰996: 
〰997: deep-equal(item()*, item()*, xs:string) as xs:boolean
〰998: 
〰999: This function assesses whether two sequences are deep-equal to each other. The function as described here extends the definition of the XPath 3.0 deep-equal to explain how it should handle maps; it is intended to replace the existing deep-equal function at some stage in the future.
〰1000:
〰1001:document
〰1002:document(item()*) as node()*
〰1003:
〰1004:document(item()*, node()) as node()*
〰1005:
〰1006:Provides access to XML documents identified by a URI.
〰1007:
〰1008:element-available
〰1009:element-available(xs:string) as xs:boolean
〰1010:
〰1011:Determines whether a particular instruction is or is not available for use. The function is particularly useful for calling within an [xsl:]use-when attribute (see ) to test whether a particular is available.
〰1012:
〰1013:function-available
〰1014:function-available(xs:string) as xs:boolean
〰1015:
〰1016:function-available(xs:string, xs:integer) as xs:boolean
〰1017:
〰1018:Determines whether a particular function is or is not available for use. The function is particularly useful for calling within an [xsl:]use-when attribute (see ) to test whether a particular is available.
〰1019:
〰1020:json-to-xml
〰1021:json-to-xml(xs:string) as document-node()
〰1022:
〰1023:json-to-xml(xs:string, map(*)) as document-node()
〰1024:
〰1025:Parses a string supplied in the form of a JSON text, returning the results in the form of an XML document node.
〰1026:
〰1027:key
〰1028:key(xs:string, xs:anyAtomicType*) as node()*
〰1029:
〰1030:key(xs:string, xs:anyAtomicType*, node()) as node()*
〰1031:
〰1032:Returns the nodes that match a supplied key value.
〰1033:
〰1034:regex-group
〰1035:regex-group(xs:integer) as xs:string
〰1036:
〰1037:Returns the string captured by a parenthesized subexpression of the regular expression used during evaluation of the xsl:analyze-string instruction.
〰1038:
〰1039:snapshot
〰1040:snapshot() as item()
〰1041:
〰1042:snapshot(item()*) as item()*
〰1043:
〰1044:Returns a copy of a sequence, retaining copies of the ancestors and descendants of any node in the input sequence, together with their attributes and namespaces.
〰1045:
〰1046:stream-available
〰1047:stream-available(xs:string?) as xs:boolean
〰1048:
〰1049:Determines, as far as possible, whether a document is available for streamed processing using xsl:source-document.
〰1050:
〰1051:system-property
〰1052:system-property(xs:string) as xs:string
〰1053:
〰1054:Returns the value of a system property
〰1055:
〰1056:type-available
〰1057:type-available(xs:string) as xs:boolean
〰1058:
〰1059:Used to control how a stylesheet behaves if a particular schema type is or is not available in the static context.
〰1060:
〰1061:unparsed-entity-public-id
〰1062:unparsed-entity-public-id(xs:string) as xs:string
〰1063:
〰1064:unparsed-entity-public-id(xs:string, node()) as xs:string
〰1065:
〰1066:Returns the public identifier of an unparsed entity
〰1067:
〰1068:unparsed-entity-uri
〰1069:unparsed-entity-uri(xs:string) as xs:anyURI
〰1070:
〰1071:unparsed-entity-uri(xs:string, node()) as xs:anyURI
〰1072:
〰1073:Returns the URI (system identifier) of an unparsed entity
〰1074:
〰1075:xml-to-json
〰1076:xml-to-json(node()?) as xs:string?
〰1077:
〰1078:xml-to-json(node()?, map(*)) as xs:string?
〰1079:
〰1080:Converts an XML tree, whose format corresponds to the XML representation of JSON defined in this specification, into a string conforming to the JSON grammar.
〰1081:
〰1082:4 XQuery Update Functions
〰1083:This section lists all of the functions in this namespace that are defined in the [XQuery Update 1.0] specification.
〰1084:
〰1085:The normative definitions of these functions are in the [XQuery Update 1.0] specification. For convenience, a very brief, non-normative summary of each function is provided. For details, follow the link on the “Summary:” introductory text below each function.
〰1086:
〰1087:put
〰1088:put(node(), xs:string) as empty-sequence()
〰1089:
〰1090:Stores a document or element to the location specified by $uri. This function is normally invoked to create a resource on an external storage system such as a file system or a database.
〰1091:
〰1092:The external effects of fn:put are implementation-defined, since they occur outside the domain of XQuery. The intent is that, if fn:put is invoked on a document node and no error is raised, a subsequent query can access the stored document by invoking fn:doc with the same URI.
〰1093:
〰1094:
〰1095:    */
〰1096:}
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/Xml/Xsl/Extensions/XPath20Functions.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰2:   using System;
〰3:   using System.Linq;
〰4:   using System.Xml.Serialization;
〰5:   using System.Xml.XPath;
〰6:   
〰7:   namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions;
〰8:   
〰9:   [XmlRoot(Namespace = @"http://www.w3.org/2005/xpath-functions")]
〰10:  public class XPath20Functions
〰11:  {
〰12:  #pragma warning disable IDE1006 // Naming Styles
‼13:      public decimal abs(decimal input) => Math.Abs(input);
‼14:      public decimal ceiling(decimal input) => Math.Ceiling(input);
‼15:      public decimal count(XPathNodeIterator input) =>input.AsNavigatorSet().Count();
‼16:      public decimal avg(XPathNodeIterator input) => sum(input) / count(input);
‼17:      public bool exists(XPathNodeIterator input) => input.AsNavigatorSet().Any();
‼18:      public bool empty(XPathNodeIterator input) => !exists(input);
‼19:      public bool @false() => false;
‼20:      public bool not(bool input) => !input;
‼21:      public bool @true() => true;
〰22:  
〰23:      public decimal sum(XPathNodeIterator input) =>
‼24:          (from i in input.AsNavigatorSet()
‼25:           where !string.IsNullOrWhiteSpace(i.Value)
‼26:           let d = decimal.TryParse(i.Value, out var v) ? (decimal?)v : null
‼27:           where d.HasValue
‼28:           select d).Sum() ?? 0;
〰29:  
〰30:      public decimal max(XPathNodeIterator input) =>
‼31:          (from i in input.AsNavigatorSet()
‼32:           where !string.IsNullOrWhiteSpace(i.Value)
‼33:           let d = decimal.TryParse(i.Value, out var v) ? (decimal?)v : null
‼34:           where d.HasValue
‼35:           select d).Max() ?? 0;
〰36:  
〰37:      public decimal min(XPathNodeIterator input) =>
‼38:          (from i in input.AsNavigatorSet()
‼39:           where !string.IsNullOrWhiteSpace(i.Value)
‼40:           let d = decimal.TryParse(i.Value, out var v) ? (decimal?)v : null
‼41:           where d.HasValue
‼42:           select d).Min() ?? 0;
〰43:  
〰44:      // https://www.w3.org/2005/xpath-functions/
〰45:  
〰46:      [XsltFunction("distinct-values", HideOriginalName = true)]
〰47:      public XPathNodeIterator distinct_values(XPathNodeIterator input) =>
‼48:           new EnumerableXPathNodeIterator(
‼49:              from i in input.AsNavigatorSet()
‼50:              group i by i.Value into grouped
‼51:              from i in grouped
‼52:              select grouped.First());
〰53:  
〰54:      public XPathNodeIterator apply(string xpath, XPathNodeIterator input) =>
‼55:           new EnumerableXPathNodeIterator(
‼56:              from item in input.AsNavigatorSet()
‼57:              let value = item.Evaluate(xpath)
‼58:              from node in value.AsNodeSet()
‼59:              select node
‼60:              );
〰61:  
〰62:  #pragma warning restore IDE1006 // Naming Styles
〰63:  
〰64:      /*
〰65:  
〰66:  Returns the absolute value of $arg.
〰67:  
〰68:  adjust-dateTime-to-timezone
〰69:  adjust-dateTime-to-timezone(xs:dateTime?) as xs:dateTime?
〰70:  
〰71:  adjust-dateTime-to-timezone(xs:dateTime?, xs:dayTimeDuration?) as xs:dateTime?
〰72:  
〰73:  Adjusts an xs:dateTime value to a specific timezone, or to no timezone at all.
〰74:  
〰75:  adjust-date-to-timezone
〰76:  adjust-date-to-timezone(xs:date?) as xs:date?
〰77:  
〰78:  adjust-date-to-timezone(xs:date?, xs:dayTimeDuration?) as xs:date?
〰79:  
〰80:  Adjusts an xs:date value to a specific timezone, or to no timezone at all; the result is the date in the target timezone that contains the starting instant of the supplied date.
〰81:  
〰82:  adjust-time-to-timezone
〰83:  adjust-time-to-timezone(xs:time?) as xs:time?
〰84:  
〰85:  adjust-time-to-timezone(xs:time?, xs:dayTimeDuration?) as xs:time?
〰86:  
〰87:  Adjusts an xs:time value to a specific timezone, or to no timezone at all.
〰88:  
〰89:  analyze-string
〰90:  analyze-string(xs:string?, xs:string) as element(fn:analyze-string-result)
〰91:  
〰92:  analyze-string(xs:string?, xs:string, xs:string) as element(fn:analyze-string-result)
〰93:  
〰94:  Analyzes a string using a regular expression, returning an XML structure that identifies which parts of the input string matched or failed to match the regular expression, and in the case of matched substrings, which substrings matched each capturing group in the regular expression.
〰95:  
〰96:  apply
〰97:  apply(function(*), array(*)) as item()*
〰98:  
〰99:  Makes a dynamic call on a function with an argument list supplied in the form of an array.
〰100: 
〰101: available-environment-variables
〰102: available-environment-variables() as xs:string*
〰103: 
〰104: Returns a list of environment variable names that are suitable for passing to fn:environment-variable, as a (possibly empty) sequence of strings.
〰105: 
〰106: base-uri
〰107: base-uri() as xs:anyURI?
〰108: 
〰109: base-uri(node()?) as xs:anyURI?
〰110: 
〰111: Returns the base URI of a node.
〰112: 
〰113: boolean
〰114: boolean(item()*) as xs:boolean
〰115: 
〰116: Computes the effective boolean value of the sequence $arg.
〰117: 
〰118: codepoint-equal
〰119: codepoint-equal(xs:string?, xs:string?) as xs:boolean?
〰120: 
〰121: Returns true if two strings are equal, considered codepoint-by-codepoint.
〰122: 
〰123: codepoints-to-string
〰124: codepoints-to-string(xs:integer*) as xs:string
〰125: 
〰126: Returns an xs:string whose characters have supplied codepoints.
〰127: 
〰128: collation-key
〰129: collation-key(xs:string) as xs:base64Binary
〰130: 
〰131: collation-key(xs:string, xs:string) as xs:base64Binary
〰132: 
〰133: Given a string value and a collation, generates an internal value called a collation key, with the property that the matching and ordering of collation keys reflects the matching and ordering of strings under the specified collation.
〰134: 
〰135: collection
〰136: collection() as item()*
〰137: 
〰138: collection(xs:string?) as item()*
〰139: 
〰140: Returns a sequence of items identified by a collection URI; or a default collection if no URI is supplied.
〰141: 
〰142: compare
〰143: compare(xs:string?, xs:string?) as xs:integer?
〰144: 
〰145: compare(xs:string?, xs:string?, xs:string) as xs:integer?
〰146: 
〰147: Returns -1, 0, or 1, depending on whether $comparand1 collates before, equal to, or after $comparand2 according to the rules of a selected collation.
〰148: 
〰149: concat
〰150: concat(xs:anyAtomicType?, xs:anyAtomicType?, xs:anyAtomicType?) as xs:string
〰151: 
〰152: Returns the concatenation of the string values of the arguments.
〰153: 
〰154: contains
〰155: contains(xs:string?, xs:string?) as xs:boolean
〰156: 
〰157: contains(xs:string?, xs:string?, xs:string) as xs:boolean
〰158: 
〰159: Returns true if the string $arg1 contains $arg2 as a substring, taking collations into account.
〰160: 
〰161: contains-token
〰162: contains-token(xs:string*, xs:string) as xs:boolean
〰163: 
〰164: contains-token(xs:string*, xs:string, xs:string) as xs:boolean
〰165: 
〰166: Determines whether or not any of the supplied strings, when tokenized at whitespace boundaries, contains the supplied token, under the rules of the supplied collation.
〰167: 
〰168: current-date
〰169: current-date() as xs:date
〰170: 
〰171: Returns the current date.
〰172: 
〰173: current-dateTime
〰174: current-dateTime() as xs:dateTimeStamp
〰175: 
〰176: Returns the current date and time (with timezone).
〰177: 
〰178: current-time
〰179: current-time() as xs:time
〰180: 
〰181: Returns the current time.
〰182: 
〰183: data
〰184: data() as xs:anyAtomicType*
〰185: 
〰186: data(item()*) as xs:anyAtomicType*
〰187: 
〰188: Returns the result of atomizing a sequence. This process flattens arrays, and replaces nodes by their typed values.
〰189: 
〰190: dateTime
〰191: dateTime(xs:date?, xs:time?) as xs:dateTime?
〰192: 
〰193: Returns an xs:dateTime value created by combining an xs:date and an xs:time.
〰194: 
〰195: day-from-date
〰196: day-from-date(xs:date?) as xs:integer?
〰197: 
〰198: Returns the day component of an xs:date.
〰199: 
〰200: day-from-dateTime
〰201: day-from-dateTime(xs:dateTime?) as xs:integer?
〰202: 
〰203: Returns the day component of an xs:dateTime.
〰204: 
〰205: days-from-duration
〰206: days-from-duration(xs:duration?) as xs:integer?
〰207: 
〰208: Returns the number of days in a duration.
〰209: 
〰210: deep-equal
〰211: deep-equal(item()*, item()*) as xs:boolean
〰212: 
〰213: deep-equal(item()*, item()*, xs:string) as xs:boolean
〰214: 
〰215: This function assesses whether two sequences are deep-equal to each other. To be deep-equal, they must contain items that are pairwise deep-equal; and for two items to be deep-equal, they must either be atomic values that compare equal, or nodes of the same kind, with the same name, whose children are deep-equal, or maps with matching entries, or arrays with matching members.
〰216: 
〰217: default-collation
〰218: default-collation() as xs:string
〰219: 
〰220: Returns the value of the default collation property from the static context.
〰221: 
〰222: default-language
〰223: default-language() as xs:language
〰224: 
〰225: Returns the value of the default language property from the dynamic context.
〰226: 
〰227: distinct-values
〰228: distinct-values(xs:anyAtomicType*) as xs:anyAtomicType*
〰229: 
〰230: distinct-values(xs:anyAtomicType*, xs:string) as xs:anyAtomicType*
〰231: 
〰232: Returns the values that appear in a sequence, with duplicates eliminated.
〰233: 
〰234: doc
〰235: doc(xs:string?) as document-node()?
〰236: 
〰237: Retrieves a document using a URI supplied as an xs:string, and returns the corresponding document node.
〰238: 
〰239: doc-available
〰240: doc-available(xs:string?) as xs:boolean
〰241: 
〰242: The function returns true if and only if the function call fn:doc($uri) would return a document node.
〰243: 
〰244: document-uri
〰245: document-uri() as xs:anyURI?
〰246: 
〰247: document-uri(node()?) as xs:anyURI?
〰248: 
〰249: Returns the URI of a resource where a document can be found, if available.
〰250: 
〰251: element-with-id
〰252: element-with-id(xs:string*) as element()*
〰253: 
〰254: element-with-id(xs:string*, node()) as element()*
〰255: 
〰256: Returns the sequence of element nodes that have an ID value matching the value of one or more of the IDREF values supplied in $arg.
〰257: 
〰258: 
〰259: encode-for-uri
〰260: encode-for-uri(xs:string?) as xs:string
〰261: 
〰262: Encodes reserved characters in a string that is intended to be used in the path segment of a URI.
〰263: 
〰264: ends-with
〰265: ends-with(xs:string?, xs:string?) as xs:boolean
〰266: 
〰267: ends-with(xs:string?, xs:string?, xs:string) as xs:boolean
〰268: 
〰269: Returns true if the string $arg1 contains $arg2 as a trailing substring, taking collations into account.
〰270: 
〰271: environment-variable
〰272: environment-variable(xs:string) as xs:string?
〰273: 
〰274: Returns the value of a system environment variable, if it exists.
〰275: 
〰276: error
〰277: error() as none
〰278: 
〰279: error(xs:QName?) as none
〰280: 
〰281: error(xs:QName?, xs:string) as none
〰282: 
〰283: error(xs:QName?, xs:string, item()*) as none
〰284: 
〰285: Calling the fn:error function raises an application-defined error.
〰286: 
〰287: escape-html-uri
〰288: escape-html-uri(xs:string?) as xs:string
〰289: 
〰290: Escapes a URI in the same way that HTML user agents handle attribute values expected to contain URIs.
〰291: 
〰292: exactly-one
〰293: exactly-one(item()*) as item()
〰294: 
〰295: Returns $arg if it contains exactly one item. Otherwise, raises an error.
〰296: 
〰297: 
〰298: filter
〰299: filter(item()*, function(item()) as xs:boolean) as item()*
〰300: 
〰301: Returns those items from the sequence $seq for which the supplied function $f returns true.
〰302: 
〰303: floor
〰304: floor(xs:numeric?) as xs:numeric?
〰305: 
〰306: Rounds $arg downwards to a whole number.
〰307: 
〰308: fold-left
〰309: fold-left(item()*, item()*, function(item()*, item()) as item()*) as item()*
〰310: 
〰311: Processes the supplied sequence from left to right, applying the supplied function repeatedly to each item in turn, together with an accumulated result value.
〰312: 
〰313: fold-right
〰314: fold-right(item()*, item()*, function(item(), item()*) as item()*) as item()*
〰315: 
〰316: Processes the supplied sequence from right to left, applying the supplied function repeatedly to each item in turn, together with an accumulated result value.
〰317: 
〰318: for-each
〰319: for-each(item()*, function(item()) as item()*) as item()*
〰320: 
〰321: Applies the function item $action to every item from the sequence $seq in turn, returning the concatenation of the resulting sequences in order.
〰322: 
〰323: for-each-pair
〰324: for-each-pair(item()*, item()*, function(item(), item()) as item()*) as item()*
〰325: 
〰326: Applies the function item $action to successive pairs of items taken one from $seq1 and one from $seq2, returning the concatenation of the resulting sequences in order.
〰327: 
〰328: format-date
〰329: format-date(xs:date?, xs:string) as xs:string?
〰330: 
〰331: format-date(xs:date?, xs:string, xs:string?, xs:string?, xs:string?) as xs:string?
〰332: 
〰333: Returns a string containing an xs:date value formatted for display.
〰334: 
〰335: format-dateTime
〰336: format-dateTime(xs:dateTime?, xs:string) as xs:string?
〰337: 
〰338: format-dateTime(xs:dateTime?, xs:string, xs:string?, xs:string?, xs:string?) as xs:string?
〰339: 
〰340: Returns a string containing an xs:dateTime value formatted for display.
〰341: 
〰342: format-integer
〰343: format-integer(xs:integer?, xs:string) as xs:string
〰344: 
〰345: format-integer(xs:integer?, xs:string, xs:string?) as xs:string
〰346: 
〰347: Formats an integer according to a given picture string, using the conventions of a given natural language if specified.
〰348: 
〰349: format-number
〰350: format-number(xs:numeric?, xs:string) as xs:string
〰351: 
〰352: format-number(xs:numeric?, xs:string, xs:string?) as xs:string
〰353: 
〰354: Returns a string containing a number formatted according to a given picture string, taking account of decimal formats specified in the static context.
〰355: 
〰356: format-time
〰357: format-time(xs:time?, xs:string) as xs:string?
〰358: 
〰359: format-time(xs:time?, xs:string, xs:string?, xs:string?, xs:string?) as xs:string?
〰360: 
〰361: Returns a string containing an xs:time value formatted for display.
〰362: 
〰363: function-arity
〰364: function-arity(function(*)) as xs:integer
〰365: 
〰366: Returns the arity of the function identified by a function item.
〰367: 
〰368: function-lookup
〰369: function-lookup(xs:QName, xs:integer) as function(*)?
〰370: 
〰371: Returns the function having a given name and arity, if there is one.
〰372: 
〰373: function-name
〰374: function-name(function(*)) as xs:QName?
〰375: 
〰376: Returns the name of the function identified by a function item.
〰377: 
〰378: generate-id
〰379: generate-id() as xs:string
〰380: 
〰381: generate-id(node()?) as xs:string
〰382: 
〰383: This function returns a string that uniquely identifies a given node.
〰384: 
〰385: has-children
〰386: has-children() as xs:boolean
〰387: 
〰388: has-children(node()?) as xs:boolean
〰389: 
〰390: Returns true if the supplied node has one or more child nodes (of any kind).
〰391: 
〰392: head
〰393: head(item()*) as item()?
〰394: 
〰395: Returns the first item in a sequence.
〰396: 
〰397: hours-from-dateTime
〰398: hours-from-dateTime(xs:dateTime?) as xs:integer?
〰399: 
〰400: Returns the hours component of an xs:dateTime.
〰401: 
〰402: hours-from-duration
〰403: hours-from-duration(xs:duration?) as xs:integer?
〰404: 
〰405: Returns the number of hours in a duration.
〰406: 
〰407: hours-from-time
〰408: hours-from-time(xs:time?) as xs:integer?
〰409: 
〰410: Returns the hours component of an xs:time.
〰411: 
〰412: id
〰413: id(xs:string*) as element()*
〰414: 
〰415: id(xs:string*, node()) as element()*
〰416: 
〰417: Returns the sequence of element nodes that have an ID value matching the value of one or more of the IDREF values supplied in $arg.
〰418: 
〰419: idref
〰420: idref(xs:string*) as node()*
〰421: 
〰422: idref(xs:string*, node()) as node()*
〰423: 
〰424: Returns the sequence of element or attribute nodes with an IDREF value matching the value of one or more of the ID values supplied in $arg.
〰425: 
〰426: implicit-timezone
〰427: implicit-timezone() as xs:dayTimeDuration
〰428: 
〰429: Returns the value of the implicit timezone property from the dynamic context.
〰430: 
〰431: index-of
〰432: index-of(xs:anyAtomicType*, xs:anyAtomicType) as xs:integer*
〰433: 
〰434: index-of(xs:anyAtomicType*, xs:anyAtomicType, xs:string) as xs:integer*
〰435: 
〰436: Returns a sequence of positive integers giving the positions within the sequence $seq of items that are equal to $search.
〰437: 
〰438: innermost
〰439: innermost(node()*) as node()*
〰440: 
〰441: Returns every node within the input sequence that is not an ancestor of another member of the input sequence; the nodes are returned in document order with duplicates eliminated.
〰442: 
〰443: in-scope-prefixes
〰444: in-scope-prefixes(element()) as xs:string*
〰445: 
〰446: Returns the prefixes of the in-scope namespaces for an element node.
〰447: 
〰448: insert-before
〰449: insert-before(item()*, xs:integer, item()*) as item()*
〰450: 
〰451: Returns a sequence constructed by inserting an item or a sequence of items at a given position within an existing sequence.
〰452: 
〰453: iri-to-uri
〰454: iri-to-uri(xs:string?) as xs:string
〰455: 
〰456: Converts a string containing an IRI into a URI according to the rules of [rfc3987].
〰457: 
〰458: json-doc
〰459: json-doc(xs:string?) as item()?
〰460: 
〰461: json-doc(xs:string?, map(*)) as item()?
〰462: 
〰463: Reads an external resource containing JSON, and returns the result of parsing the resource as JSON.
〰464: 
〰465: json-to-xml
〰466: json-to-xml(xs:string?) as document-node()?
〰467: 
〰468: json-to-xml(xs:string?, map(*)) as document-node()?
〰469: 
〰470: Parses a string supplied in the form of a JSON text, returning the results in the form of an XML document node.
〰471: 
〰472: lang
〰473: lang(xs:string?) as xs:boolean
〰474: 
〰475: lang(xs:string?, node()) as xs:boolean
〰476: 
〰477: This function tests whether the language of $node, or the context item if the second argument is omitted, as specified by xml:lang attributes is the same as, or is a sublanguage of, the language specified by $testlang.
〰478: 
〰479: last
〰480: last() as xs:integer
〰481: 
〰482: Returns the context size from the dynamic context.
〰483: 
〰484: load-xquery-module
〰485: load-xquery-module(xs:string) as map(*)
〰486: 
〰487: load-xquery-module(xs:string, map(*)) as map(*)
〰488: 
〰489: Provides access to the public functions and global variables of a dynamically-loaded XQuery library module.
〰490: 
〰491: local-name
〰492: local-name() as xs:string
〰493: 
〰494: local-name(node()?) as xs:string
〰495: 
〰496: Returns the local part of the name of $arg as an xs:string that is either the zero-length string, or has the lexical form of an xs:NCName.
〰497: 
〰498: local-name-from-QName
〰499: local-name-from-QName(xs:QName?) as xs:NCName?
〰500: 
〰501: Returns the local part of the supplied QName.
〰502: 
〰503: lower-case
〰504: lower-case(xs:string?) as xs:string
〰505: 
〰506: Converts a string to lower case.
〰507: 
〰508: matches
〰509: matches(xs:string?, xs:string) as xs:boolean
〰510: 
〰511: matches(xs:string?, xs:string, xs:string) as xs:boolean
〰512: 
〰513: Returns true if the supplied string matches a given regular expression.
〰514: 
〰515: 
〰516: Returns a value that is equal to the lowest value appearing in the input sequence.
〰517: 
〰518: minutes-from-dateTime
〰519: minutes-from-dateTime(xs:dateTime?) as xs:integer?
〰520: 
〰521: Returns the minute component of an xs:dateTime.
〰522: 
〰523: minutes-from-duration
〰524: minutes-from-duration(xs:duration?) as xs:integer?
〰525: 
〰526: Returns the number of minutes in a duration.
〰527: 
〰528: minutes-from-time
〰529: minutes-from-time(xs:time?) as xs:integer?
〰530: 
〰531: Returns the minutes component of an xs:time.
〰532: 
〰533: month-from-date
〰534: month-from-date(xs:date?) as xs:integer?
〰535: 
〰536: Returns the month component of an xs:date.
〰537: 
〰538: month-from-dateTime
〰539: month-from-dateTime(xs:dateTime?) as xs:integer?
〰540: 
〰541: Returns the month component of an xs:dateTime.
〰542: 
〰543: months-from-duration
〰544: months-from-duration(xs:duration?) as xs:integer?
〰545: 
〰546: Returns the number of months in a duration.
〰547: 
〰548: name
〰549: name() as xs:string
〰550: 
〰551: name(node()?) as xs:string
〰552: 
〰553: Returns the name of a node, as an xs:string that is either the zero-length string, or has the lexical form of an xs:QName.
〰554: 
〰555: namespace-uri
〰556: namespace-uri() as xs:anyURI
〰557: 
〰558: namespace-uri(node()?) as xs:anyURI
〰559: 
〰560: Returns the namespace URI part of the name of $arg, as an xs:anyURI value.
〰561: 
〰562: namespace-uri-for-prefix
〰563: namespace-uri-for-prefix(xs:string?, element()) as xs:anyURI?
〰564: 
〰565: Returns the namespace URI of one of the in-scope namespaces for $element, identified by its namespace prefix.
〰566: 
〰567: namespace-uri-from-QName
〰568: namespace-uri-from-QName(xs:QName?) as xs:anyURI?
〰569: 
〰570: Returns the namespace URI part of the supplied QName.
〰571: 
〰572: nilled
〰573: nilled() as xs:boolean?
〰574: 
〰575: nilled(node()?) as xs:boolean?
〰576: 
〰577: Returns true for an element that is nilled.
〰578: 
〰579: node-name
〰580: node-name() as xs:QName?
〰581: 
〰582: node-name(node()?) as xs:QName?
〰583: 
〰584: Returns the name of a node, as an xs:QName.
〰585: 
〰586: normalize-space
〰587: normalize-space() as xs:string
〰588: 
〰589: normalize-space(xs:string?) as xs:string
〰590: 
〰591: Returns the value of $arg with leading and trailing whitespace removed, and sequences of internal whitespace reduced to a single space character.
〰592: 
〰593: normalize-unicode
〰594: normalize-unicode(xs:string?) as xs:string
〰595: 
〰596: normalize-unicode(xs:string?, xs:string) as xs:string
〰597: 
〰598: Returns the value of $arg after applying Unicode normalization.
〰599: 
〰600: number
〰601: number() as xs:double
〰602: 
〰603: number(xs:anyAtomicType?) as xs:double
〰604: 
〰605: Returns the value indicated by $arg or, if $arg is not specified, the context item after atomization, converted to an xs:double.
〰606: 
〰607: one-or-more
〰608: one-or-more(item()*) as item()+
〰609: 
〰610: Returns $arg if it contains one or more items. Otherwise, raises an error.
〰611: 
〰612: outermost
〰613: outermost(node()*) as node()*
〰614: 
〰615: Returns every node within the input sequence that has no ancestor that is itself a member of the input sequence; the nodes are returned in document order with duplicates eliminated.
〰616: 
〰617: parse-ietf-date
〰618: parse-ietf-date(xs:string?) as xs:dateTime?
〰619: 
〰620: Parses a string containing the date and time in IETF format, returning the corresponding xs:dateTime value.
〰621: 
〰622: parse-json
〰623: parse-json(xs:string?) as item()?
〰624: 
〰625: parse-json(xs:string?, map(*)) as item()?
〰626: 
〰627: Parses a string supplied in the form of a JSON text, returning the results typically in the form of a map or array.
〰628: 
〰629: parse-xml
〰630: parse-xml(xs:string?) as document-node(element(*))?
〰631: 
〰632: This function takes as input an XML document represented as a string, and returns the document node at the root of an XDM tree representing the parsed document.
〰633: 
〰634: parse-xml-fragment
〰635: parse-xml-fragment(xs:string?) as document-node()?
〰636: 
〰637: This function takes as input an XML external entity represented as a string, and returns the document node at the root of an XDM tree representing the parsed document fragment.
〰638: 
〰639: path
〰640: path() as xs:string?
〰641: 
〰642: path(node()?) as xs:string?
〰643: 
〰644: Returns a path expression that can be used to select the supplied node relative to the root of its containing document.
〰645: 
〰646: position
〰647: position() as xs:integer
〰648: 
〰649: Returns the context position from the dynamic context.
〰650: 
〰651: prefix-from-QName
〰652: prefix-from-QName(xs:QName?) as xs:NCName?
〰653: 
〰654: Returns the prefix component of the supplied QName.
〰655: 
〰656: QName
〰657: QName(xs:string?, xs:string) as xs:QName
〰658: 
〰659: Returns an xs:QName value formed using a supplied namespace URI and lexical QName.
〰660: 
〰661: random-number-generator
〰662: random-number-generator() as map(xs:string, item())
〰663: 
〰664: random-number-generator(xs:anyAtomicType?) as map(xs:string, item())
〰665: 
〰666: Returns a random number generator, which can be used to generate sequences of random numbers.
〰667: 
〰668: remove
〰669: remove(item()*, xs:integer) as item()*
〰670: 
〰671: Returns a new sequence containing all the items of $target except the item at position $position.
〰672: 
〰673: replace
〰674: replace(xs:string?, xs:string, xs:string) as xs:string
〰675: 
〰676: replace(xs:string?, xs:string, xs:string, xs:string) as xs:string
〰677: 
〰678: Returns a string produced from the input string by replacing any substrings that match a given regular expression with a supplied replacement string.
〰679: 
〰680: resolve-QName
〰681: resolve-QName(xs:string?, element()) as xs:QName?
〰682: 
〰683: Returns an xs:QName value (that is, an expanded-QName) by taking an xs:string that has the lexical form of an xs:QName (a string in the form "prefix:local-name" or "local-name") and resolving it using the in-scope namespaces for a given element.
〰684: 
〰685: resolve-uri
〰686: resolve-uri(xs:string?) as xs:anyURI?
〰687: 
〰688: resolve-uri(xs:string?, xs:string) as xs:anyURI?
〰689: 
〰690: Resolves a relative IRI reference against an absolute IRI.
〰691: 
〰692: reverse
〰693: reverse(item()*) as item()*
〰694: 
〰695: Reverses the order of items in a sequence.
〰696: 
〰697: root
〰698: root() as node()
〰699: 
〰700: root(node()?) as node()?
〰701: 
〰702: Returns the root of the tree to which $arg belongs. This will usually, but not necessarily, be a document node.
〰703: 
〰704: round
〰705: round(xs:numeric?) as xs:numeric?
〰706: 
〰707: round(xs:numeric?, xs:integer) as xs:numeric?
〰708: 
〰709: Rounds a value to a specified number of decimal places, rounding upwards if two such values are equally near.
〰710: 
〰711: round-half-to-even
〰712: round-half-to-even(xs:numeric?) as xs:numeric?
〰713: 
〰714: round-half-to-even(xs:numeric?, xs:integer) as xs:numeric?
〰715: 
〰716: Rounds a value to a specified number of decimal places, rounding to make the last digit even if two such values are equally near.
〰717: 
〰718: seconds-from-dateTime
〰719: seconds-from-dateTime(xs:dateTime?) as xs:decimal?
〰720: 
〰721: Returns the seconds component of an xs:dateTime.
〰722: 
〰723: seconds-from-duration
〰724: seconds-from-duration(xs:duration?) as xs:decimal?
〰725: 
〰726: Returns the number of seconds in a duration.
〰727: 
〰728: seconds-from-time
〰729: seconds-from-time(xs:time?) as xs:decimal?
〰730: 
〰731: Returns the seconds component of an xs:time.
〰732: 
〰733: serialize
〰734: serialize(item()*) as xs:string
〰735: 
〰736: serialize(item()*, item()?) as xs:string
〰737: 
〰738: This function serializes the supplied input sequence $arg as described in [xslt-xquery-serialization-31], returning the serialized representation of the sequence as a string.
〰739: 
〰740: sort
〰741: sort(item()*) as item()*
〰742: 
〰743: sort(item()*, xs:string?) as item()*
〰744: 
〰745: sort(item()*, xs:string?, function(item()) as xs:anyAtomicType*) as item()*
〰746: 
〰747: Sorts a supplied sequence, based on the value of a sort key supplied as a function.
〰748: 
〰749: starts-with
〰750: starts-with(xs:string?, xs:string?) as xs:boolean
〰751: 
〰752: starts-with(xs:string?, xs:string?, xs:string) as xs:boolean
〰753: 
〰754: Returns true if the string $arg1 contains $arg2 as a leading substring, taking collations into account.
〰755: 
〰756: static-base-uri
〰757: static-base-uri() as xs:anyURI?
〰758: 
〰759: This function returns the value of the static base URI property from the static context.
〰760: 
〰761: string
〰762: string() as xs:string
〰763: 
〰764: string(item()?) as xs:string
〰765: 
〰766: Returns the value of $arg represented as an xs:string.
〰767: 
〰768: string-join
〰769: string-join(xs:anyAtomicType*) as xs:string
〰770: 
〰771: string-join(xs:anyAtomicType*, xs:string) as xs:string
〰772: 
〰773: Returns a string created by concatenating the items in a sequence, with a defined separator between adjacent items.
〰774: 
〰775: string-length
〰776: string-length() as xs:integer
〰777: 
〰778: string-length(xs:string?) as xs:integer
〰779: 
〰780: Returns the number of characters in a string.
〰781: 
〰782: string-to-codepoints
〰783: string-to-codepoints(xs:string?) as xs:integer*
〰784: 
〰785: Returns the sequence of codepoints that constitute an xs:string value.
〰786: 
〰787: subsequence
〰788: subsequence(item()*, xs:double) as item()*
〰789: 
〰790: subsequence(item()*, xs:double, xs:double) as item()*
〰791: 
〰792: Returns the contiguous sequence of items in the value of $sourceSeq beginning at the position indicated by the value of $startingLoc and continuing for the number of items indicated by the value of $length.
〰793: 
〰794: substring
〰795: substring(xs:string?, xs:double) as xs:string
〰796: 
〰797: substring(xs:string?, xs:double, xs:double) as xs:string
〰798: 
〰799: Returns the portion of the value of $sourceString beginning at the position indicated by the value of $start and continuing for the number of characters indicated by the value of $length.
〰800: 
〰801: substring-after
〰802: substring-after(xs:string?, xs:string?) as xs:string
〰803: 
〰804: substring-after(xs:string?, xs:string?, xs:string) as xs:string
〰805: 
〰806: Returns the part of $arg1 that follows the first occurrence of $arg2, taking collations into account.
〰807: 
〰808: substring-before
〰809: substring-before(xs:string?, xs:string?) as xs:string
〰810: 
〰811: substring-before(xs:string?, xs:string?, xs:string) as xs:string
〰812: 
〰813: Returns the part of $arg1 that precedes the first occurrence of $arg2, taking collations into account.
〰814: 
〰815: tail
〰816: tail(item()*) as item()*
〰817: 
〰818: Returns all but the first item in a sequence.
〰819: 
〰820: timezone-from-date
〰821: timezone-from-date(xs:date?) as xs:dayTimeDuration?
〰822: 
〰823: Returns the timezone component of an xs:date.
〰824: 
〰825: timezone-from-dateTime
〰826: timezone-from-dateTime(xs:dateTime?) as xs:dayTimeDuration?
〰827: 
〰828: Returns the timezone component of an xs:dateTime.
〰829: 
〰830: timezone-from-time
〰831: timezone-from-time(xs:time?) as xs:dayTimeDuration?
〰832: 
〰833: Returns the timezone component of an xs:time.
〰834: 
〰835: tokenize
〰836: tokenize(xs:string?) as xs:string*
〰837: 
〰838: tokenize(xs:string?, xs:string) as xs:string*
〰839: 
〰840: tokenize(xs:string?, xs:string, xs:string) as xs:string*
〰841: 
〰842: Returns a sequence of strings constructed by splitting the input wherever a separator is found; the separator is any substring that matches a given regular expression.
〰843: 
〰844: trace
〰845: trace(item()*) as item()*
〰846: 
〰847: trace(item()*, xs:string) as item()*
〰848: 
〰849: Provides an execution trace intended to be used in debugging queries.
〰850: 
〰851: transform
〰852: transform(map(*)) as map(*)
〰853: 
〰854: Invokes a transformation using a dynamically-loaded XSLT stylesheet.
〰855: 
〰856: translate
〰857: translate(xs:string?, xs:string, xs:string) as xs:string
〰858: 
〰859: Returns the value of $arg modified by replacing or removing individual characters.
〰860: 
〰861: unordered
〰862: unordered(item()*) as item()*
〰863: 
〰864: Returns the items of $sourceSeq in an implementation-dependent order.
〰865: 
〰866: unparsed-text
〰867: unparsed-text(xs:string?) as xs:string?
〰868: 
〰869: unparsed-text(xs:string?, xs:string) as xs:string?
〰870: 
〰871: The fn:unparsed-text function reads an external resource (for example, a file) and returns a string representation of the resource.
〰872: 
〰873: unparsed-text-available
〰874: unparsed-text-available(xs:string?) as xs:boolean
〰875: 
〰876: unparsed-text-available(xs:string?, xs:string) as xs:boolean
〰877: 
〰878: Because errors in evaluating the fn:unparsed-text function are non-recoverable, these two functions are provided to allow an application to determine whether a call with particular arguments would succeed.
〰879: 
〰880: unparsed-text-lines
〰881: unparsed-text-lines(xs:string?) as xs:string*
〰882: 
〰883: unparsed-text-lines(xs:string?, xs:string) as xs:string*
〰884: 
〰885: The fn:unparsed-text-lines function reads an external resource (for example, a file) and returns its contents as a sequence of strings, one for each line of text in the string representation of the resource.
〰886: 
〰887: upper-case
〰888: upper-case(xs:string?) as xs:string
〰889: 
〰890: Converts a string to upper case.
〰891: 
〰892: uri-collection
〰893: uri-collection() as xs:anyURI*
〰894: 
〰895: uri-collection(xs:string?) as xs:anyURI*
〰896: 
〰897: Returns a sequence of xs:anyURI values representing the URIs in a URI collection.
〰898: 
〰899: xml-to-json
〰900: xml-to-json(node()?) as xs:string?
〰901: 
〰902: xml-to-json(node()?, map(*)) as xs:string?
〰903: 
〰904: Converts an XML tree, whose format corresponds to the XML representation of JSON defined in this specification, into a string conforming to the JSON grammar.
〰905: 
〰906: year-from-date
〰907: year-from-date(xs:date?) as xs:integer?
〰908: 
〰909: Returns the year component of an xs:date.
〰910: 
〰911: year-from-dateTime
〰912: year-from-dateTime(xs:dateTime?) as xs:integer?
〰913: 
〰914: Returns the year component of an xs:dateTime.
〰915: 
〰916: years-from-duration
〰917: years-from-duration(xs:duration?) as xs:integer?
〰918: 
〰919: Returns the number of years in a duration.
〰920: 
〰921: zero-or-one
〰922: zero-or-one(item()*) as item()?
〰923: 
〰924: Returns $arg if it contains zero or one items. Otherwise, raises an error.
〰925: 
〰926: 3 XSL Transformations (XSLT) Functions
〰927: This section lists all of the functions in this namespace that are defined in the [XSLT 3.0] specification.
〰928: 
〰929: The normative definitions of these functions are in the [XSLT 3.0] specification. For convenience, a very brief, non-normative summary of each function is provided. For details, follow the link on the “Summary:” introductory text below each function.
〰930: 
〰931: Note that XSLT 3.0, because it is not dependent on XPath 3.1, also reproduces some of the functions specifications that appear in XPath 3.1. For an XSLT 3.0 processor that works with XPath 3.0, the normative specification in this case is the one that appears in the XSLT 3.0 specification.
〰932: 
〰933: accumulator-after
〰934: accumulator-after(xs:string) as item()*
〰935: 
〰936: Returns the post-descent value of the selected accumulator at the context node.
〰937: 
〰938: accumulator-before
〰939: accumulator-before(xs:string) as item()*
〰940: 
〰941: Returns the pre-descent value of the selected accumulator at the context node.
〰942: 
〰943: available-system-properties
〰944: available-system-properties() as xs:QName*
〰945: 
〰946: Returns a list of system property names that are suitable for passing to the system-property function, as a sequence of QNames.
〰947: 
〰948: collation-key
〰949: collation-key(xs:string) as xs:base64Binary
〰950: 
〰951: collation-key(xs:string, xs:string) as xs:base64Binary
〰952: 
〰953: Given a string value and a collation, generates an internal value called a collation key, with the property that the matching and ordering of collation keys reflects the matching and ordering of strings under the specified collation.
〰954: 
〰955: copy-of
〰956: copy-of() as item()
〰957: 
〰958: copy-of(item()*) as item()*
〰959: 
〰960: Returns a deep copy of the sequence supplied as the $input argument, or of the context item if the argument is absent.
〰961: 
〰962: current
〰963: current() as item()
〰964: 
〰965: Returns the item that is the context item for the evaluation of the containing XPath expression
〰966: 
〰967: current-group
〰968: current-group() as item()*
〰969: 
〰970: Returns the group currently being processed by an xsl:for-each-group instruction.
〰971: 
〰972: current-grouping-key
〰973: current-grouping-key() as xs:anyAtomicType*
〰974: 
〰975: Returns the grouping key of the group currently being processed using the xsl:for-each-group instruction.
〰976: 
〰977: current-merge-group
〰978: current-merge-group() as item()*
〰979: 
〰980: current-merge-group(xs:string) as item()*
〰981: 
〰982: Returns the group of items currently being processed by an xsl:merge instruction.
〰983: 
〰984: current-merge-key
〰985: current-merge-key() as xs:anyAtomicType*
〰986: 
〰987: Returns the merge key of the merge group currently being processed using the xsl:merge instruction.
〰988: 
〰989: current-output-uri
〰990: current-output-uri() as xs:anyURI?
〰991: 
〰992: Returns the value of the .
〰993: 
〰994: deep-equal
〰995: deep-equal(item()*, item()*) as xs:boolean
〰996: 
〰997: deep-equal(item()*, item()*, xs:string) as xs:boolean
〰998: 
〰999: This function assesses whether two sequences are deep-equal to each other. The function as described here extends the definition of the XPath 3.0 deep-equal to explain how it should handle maps; it is intended to replace the existing deep-equal function at some stage in the future.
〰1000:
〰1001:document
〰1002:document(item()*) as node()*
〰1003:
〰1004:document(item()*, node()) as node()*
〰1005:
〰1006:Provides access to XML documents identified by a URI.
〰1007:
〰1008:element-available
〰1009:element-available(xs:string) as xs:boolean
〰1010:
〰1011:Determines whether a particular instruction is or is not available for use. The function is particularly useful for calling within an [xsl:]use-when attribute (see ) to test whether a particular is available.
〰1012:
〰1013:function-available
〰1014:function-available(xs:string) as xs:boolean
〰1015:
〰1016:function-available(xs:string, xs:integer) as xs:boolean
〰1017:
〰1018:Determines whether a particular function is or is not available for use. The function is particularly useful for calling within an [xsl:]use-when attribute (see ) to test whether a particular is available.
〰1019:
〰1020:json-to-xml
〰1021:json-to-xml(xs:string) as document-node()
〰1022:
〰1023:json-to-xml(xs:string, map(*)) as document-node()
〰1024:
〰1025:Parses a string supplied in the form of a JSON text, returning the results in the form of an XML document node.
〰1026:
〰1027:key
〰1028:key(xs:string, xs:anyAtomicType*) as node()*
〰1029:
〰1030:key(xs:string, xs:anyAtomicType*, node()) as node()*
〰1031:
〰1032:Returns the nodes that match a supplied key value.
〰1033:
〰1034:regex-group
〰1035:regex-group(xs:integer) as xs:string
〰1036:
〰1037:Returns the string captured by a parenthesized subexpression of the regular expression used during evaluation of the xsl:analyze-string instruction.
〰1038:
〰1039:snapshot
〰1040:snapshot() as item()
〰1041:
〰1042:snapshot(item()*) as item()*
〰1043:
〰1044:Returns a copy of a sequence, retaining copies of the ancestors and descendants of any node in the input sequence, together with their attributes and namespaces.
〰1045:
〰1046:stream-available
〰1047:stream-available(xs:string?) as xs:boolean
〰1048:
〰1049:Determines, as far as possible, whether a document is available for streamed processing using xsl:source-document.
〰1050:
〰1051:system-property
〰1052:system-property(xs:string) as xs:string
〰1053:
〰1054:Returns the value of a system property
〰1055:
〰1056:type-available
〰1057:type-available(xs:string) as xs:boolean
〰1058:
〰1059:Used to control how a stylesheet behaves if a particular schema type is or is not available in the static context.
〰1060:
〰1061:unparsed-entity-public-id
〰1062:unparsed-entity-public-id(xs:string) as xs:string
〰1063:
〰1064:unparsed-entity-public-id(xs:string, node()) as xs:string
〰1065:
〰1066:Returns the public identifier of an unparsed entity
〰1067:
〰1068:unparsed-entity-uri
〰1069:unparsed-entity-uri(xs:string) as xs:anyURI
〰1070:
〰1071:unparsed-entity-uri(xs:string, node()) as xs:anyURI
〰1072:
〰1073:Returns the URI (system identifier) of an unparsed entity
〰1074:
〰1075:xml-to-json
〰1076:xml-to-json(node()?) as xs:string?
〰1077:
〰1078:xml-to-json(node()?, map(*)) as xs:string?
〰1079:
〰1080:Converts an XML tree, whose format corresponds to the XML representation of JSON defined in this specification, into a string conforming to the JSON grammar.
〰1081:
〰1082:4 XQuery Update Functions
〰1083:This section lists all of the functions in this namespace that are defined in the [XQuery Update 1.0] specification.
〰1084:
〰1085:The normative definitions of these functions are in the [XQuery Update 1.0] specification. For convenience, a very brief, non-normative summary of each function is provided. For details, follow the link on the “Summary:” introductory text below each function.
〰1086:
〰1087:put
〰1088:put(node(), xs:string) as empty-sequence()
〰1089:
〰1090:Stores a document or element to the location specified by $uri. This function is normally invoked to create a resource on an external storage system such as a file system or a database.
〰1091:
〰1092:The external effects of fn:put are implementation-defined, since they occur outside the domain of XQuery. The intent is that, if fn:put is invoked on a document node and no error is raised, a subsequent query can access the stored document by invoking fn:doc with the same URI.
〰1093:
〰1094:
〰1095:    */
〰1096:}
〰1097:
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

