# BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.XPath20Functions

## Summary

| Key             | Value                                                            |
| :-------------- | :--------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.XPath20Functions` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                     |
| Coveredlines    | `0`                                                              |
| Uncoveredlines  | `35`                                                             |
| Coverablelines  | `35`                                                             |
| Totallines      | `1093`                                                           |
| Linecoverage    | `0`                                                              |
| Coveredbranches | `0`                                                              |
| Totalbranches   | `6`                                                              |
| Branchcoverage  | `0`                                                              |
| Coveredmethods  | `0`                                                              |
| Totalmethods    | `14`                                                             |
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

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/Xsl/Extensions/XPath20Functions.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰2:   using System;
〰3:   using System.Linq;
〰4:   using System.Xml.Serialization;
〰5:   using System.Xml.XPath;
〰6:   
〰7:   namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions
〰8:   {
〰9:       [XmlRoot(Namespace = @"http://www.w3.org/2005/xpath-functions")]
〰10:      public class XPath20Functions
〰11:      {
‼12:          public decimal abs(decimal input) => Math.Abs(input);
‼13:          public decimal ceiling(decimal input) => Math.Ceiling(input);
‼14:          public decimal count(XPathNodeIterator input) =>input.AsNavigatorSet().Count();
‼15:          public decimal avg(XPathNodeIterator input) => sum(input) / count(input);
‼16:          public bool exists(XPathNodeIterator input) => input.AsNavigatorSet().Any();
‼17:          public bool empty(XPathNodeIterator input) => !exists(input);
‼18:          public bool @false() => false;
‼19:          public bool not(bool input) => !input;
‼20:          public bool @true() => true;
〰21:  
〰22:          public decimal sum(XPathNodeIterator input) =>
‼23:              (from i in input.AsNavigatorSet()
‼24:               where !string.IsNullOrWhiteSpace(i.Value)
‼25:               let d = decimal.TryParse(i.Value, out var v) ? (decimal?)v : null
‼26:               where d.HasValue
‼27:               select d).Sum() ?? 0;
〰28:  
〰29:          public decimal max(XPathNodeIterator input) =>
‼30:              (from i in input.AsNavigatorSet()
‼31:               where !string.IsNullOrWhiteSpace(i.Value)
‼32:               let d = decimal.TryParse(i.Value, out var v) ? (decimal?)v : null
‼33:               where d.HasValue
‼34:               select d).Max() ?? 0;
〰35:  
〰36:          public decimal min(XPathNodeIterator input) =>
‼37:              (from i in input.AsNavigatorSet()
‼38:               where !string.IsNullOrWhiteSpace(i.Value)
‼39:               let d = decimal.TryParse(i.Value, out var v) ? (decimal?)v : null
‼40:               where d.HasValue
‼41:               select d).Min() ?? 0;
〰42:  
〰43:          // https://www.w3.org/2005/xpath-functions/
〰44:  
〰45:          [XsltFunction("distinct-values", HideOriginalName = true)]
〰46:          public XPathNodeIterator distinct_values(XPathNodeIterator input) =>
‼47:               new EnumerableXPathNodeIterator(
‼48:                  from i in input.AsNavigatorSet()
‼49:                  group i by i.Value into grouped
‼50:                  from i in grouped
‼51:                  select grouped.First());
〰52:  
〰53:          public XPathNodeIterator apply(string xpath, XPathNodeIterator input) =>
‼54:               new EnumerableXPathNodeIterator(
‼55:                  from item in input.AsNavigatorSet()
‼56:                  let value = item.Evaluate(xpath)
‼57:                  from node in value.AsNodeSet()
‼58:                  select node
‼59:                  );
〰60:          /*
〰61:  
〰62:  Returns the absolute value of $arg.
〰63:  
〰64:  adjust-dateTime-to-timezone
〰65:  adjust-dateTime-to-timezone(xs:dateTime?) as xs:dateTime?
〰66:  
〰67:  adjust-dateTime-to-timezone(xs:dateTime?, xs:dayTimeDuration?) as xs:dateTime?
〰68:  
〰69:  Adjusts an xs:dateTime value to a specific timezone, or to no timezone at all.
〰70:  
〰71:  adjust-date-to-timezone
〰72:  adjust-date-to-timezone(xs:date?) as xs:date?
〰73:  
〰74:  adjust-date-to-timezone(xs:date?, xs:dayTimeDuration?) as xs:date?
〰75:  
〰76:  Adjusts an xs:date value to a specific timezone, or to no timezone at all; the result is the date in the target timezone that contains the starting instant of the supplied date.
〰77:  
〰78:  adjust-time-to-timezone
〰79:  adjust-time-to-timezone(xs:time?) as xs:time?
〰80:  
〰81:  adjust-time-to-timezone(xs:time?, xs:dayTimeDuration?) as xs:time?
〰82:  
〰83:  Adjusts an xs:time value to a specific timezone, or to no timezone at all.
〰84:  
〰85:  analyze-string
〰86:  analyze-string(xs:string?, xs:string) as element(fn:analyze-string-result)
〰87:  
〰88:  analyze-string(xs:string?, xs:string, xs:string) as element(fn:analyze-string-result)
〰89:  
〰90:  Analyzes a string using a regular expression, returning an XML structure that identifies which parts of the input string matched or failed to match the regular expression, and in the case of matched substrings, which substrings matched each capturing group in the regular expression.
〰91:  
〰92:  apply
〰93:  apply(function(*), array(*)) as item()*
〰94:  
〰95:  Makes a dynamic call on a function with an argument list supplied in the form of an array.
〰96:  
〰97:  available-environment-variables
〰98:  available-environment-variables() as xs:string*
〰99:  
〰100: Returns a list of environment variable names that are suitable for passing to fn:environment-variable, as a (possibly empty) sequence of strings.
〰101: 
〰102: base-uri
〰103: base-uri() as xs:anyURI?
〰104: 
〰105: base-uri(node()?) as xs:anyURI?
〰106: 
〰107: Returns the base URI of a node.
〰108: 
〰109: boolean
〰110: boolean(item()*) as xs:boolean
〰111: 
〰112: Computes the effective boolean value of the sequence $arg.
〰113: 
〰114: codepoint-equal
〰115: codepoint-equal(xs:string?, xs:string?) as xs:boolean?
〰116: 
〰117: Returns true if two strings are equal, considered codepoint-by-codepoint.
〰118: 
〰119: codepoints-to-string
〰120: codepoints-to-string(xs:integer*) as xs:string
〰121: 
〰122: Returns an xs:string whose characters have supplied codepoints.
〰123: 
〰124: collation-key
〰125: collation-key(xs:string) as xs:base64Binary
〰126: 
〰127: collation-key(xs:string, xs:string) as xs:base64Binary
〰128: 
〰129: Given a string value and a collation, generates an internal value called a collation key, with the property that the matching and ordering of collation keys reflects the matching and ordering of strings under the specified collation.
〰130: 
〰131: collection
〰132: collection() as item()*
〰133: 
〰134: collection(xs:string?) as item()*
〰135: 
〰136: Returns a sequence of items identified by a collection URI; or a default collection if no URI is supplied.
〰137: 
〰138: compare
〰139: compare(xs:string?, xs:string?) as xs:integer?
〰140: 
〰141: compare(xs:string?, xs:string?, xs:string) as xs:integer?
〰142: 
〰143: Returns -1, 0, or 1, depending on whether $comparand1 collates before, equal to, or after $comparand2 according to the rules of a selected collation.
〰144: 
〰145: concat
〰146: concat(xs:anyAtomicType?, xs:anyAtomicType?, xs:anyAtomicType?) as xs:string
〰147: 
〰148: Returns the concatenation of the string values of the arguments.
〰149: 
〰150: contains
〰151: contains(xs:string?, xs:string?) as xs:boolean
〰152: 
〰153: contains(xs:string?, xs:string?, xs:string) as xs:boolean
〰154: 
〰155: Returns true if the string $arg1 contains $arg2 as a substring, taking collations into account.
〰156: 
〰157: contains-token
〰158: contains-token(xs:string*, xs:string) as xs:boolean
〰159: 
〰160: contains-token(xs:string*, xs:string, xs:string) as xs:boolean
〰161: 
〰162: Determines whether or not any of the supplied strings, when tokenized at whitespace boundaries, contains the supplied token, under the rules of the supplied collation.
〰163: 
〰164: current-date
〰165: current-date() as xs:date
〰166: 
〰167: Returns the current date.
〰168: 
〰169: current-dateTime
〰170: current-dateTime() as xs:dateTimeStamp
〰171: 
〰172: Returns the current date and time (with timezone).
〰173: 
〰174: current-time
〰175: current-time() as xs:time
〰176: 
〰177: Returns the current time.
〰178: 
〰179: data
〰180: data() as xs:anyAtomicType*
〰181: 
〰182: data(item()*) as xs:anyAtomicType*
〰183: 
〰184: Returns the result of atomizing a sequence. This process flattens arrays, and replaces nodes by their typed values.
〰185: 
〰186: dateTime
〰187: dateTime(xs:date?, xs:time?) as xs:dateTime?
〰188: 
〰189: Returns an xs:dateTime value created by combining an xs:date and an xs:time.
〰190: 
〰191: day-from-date
〰192: day-from-date(xs:date?) as xs:integer?
〰193: 
〰194: Returns the day component of an xs:date.
〰195: 
〰196: day-from-dateTime
〰197: day-from-dateTime(xs:dateTime?) as xs:integer?
〰198: 
〰199: Returns the day component of an xs:dateTime.
〰200: 
〰201: days-from-duration
〰202: days-from-duration(xs:duration?) as xs:integer?
〰203: 
〰204: Returns the number of days in a duration.
〰205: 
〰206: deep-equal
〰207: deep-equal(item()*, item()*) as xs:boolean
〰208: 
〰209: deep-equal(item()*, item()*, xs:string) as xs:boolean
〰210: 
〰211: This function assesses whether two sequences are deep-equal to each other. To be deep-equal, they must contain items that are pairwise deep-equal; and for two items to be deep-equal, they must either be atomic values that compare equal, or nodes of the same kind, with the same name, whose children are deep-equal, or maps with matching entries, or arrays with matching members.
〰212: 
〰213: default-collation
〰214: default-collation() as xs:string
〰215: 
〰216: Returns the value of the default collation property from the static context.
〰217: 
〰218: default-language
〰219: default-language() as xs:language
〰220: 
〰221: Returns the value of the default language property from the dynamic context.
〰222: 
〰223: distinct-values
〰224: distinct-values(xs:anyAtomicType*) as xs:anyAtomicType*
〰225: 
〰226: distinct-values(xs:anyAtomicType*, xs:string) as xs:anyAtomicType*
〰227: 
〰228: Returns the values that appear in a sequence, with duplicates eliminated.
〰229: 
〰230: doc
〰231: doc(xs:string?) as document-node()?
〰232: 
〰233: Retrieves a document using a URI supplied as an xs:string, and returns the corresponding document node.
〰234: 
〰235: doc-available
〰236: doc-available(xs:string?) as xs:boolean
〰237: 
〰238: The function returns true if and only if the function call fn:doc($uri) would return a document node.
〰239: 
〰240: document-uri
〰241: document-uri() as xs:anyURI?
〰242: 
〰243: document-uri(node()?) as xs:anyURI?
〰244: 
〰245: Returns the URI of a resource where a document can be found, if available.
〰246: 
〰247: element-with-id
〰248: element-with-id(xs:string*) as element()*
〰249: 
〰250: element-with-id(xs:string*, node()) as element()*
〰251: 
〰252: Returns the sequence of element nodes that have an ID value matching the value of one or more of the IDREF values supplied in $arg.
〰253: 
〰254: 
〰255: encode-for-uri
〰256: encode-for-uri(xs:string?) as xs:string
〰257: 
〰258: Encodes reserved characters in a string that is intended to be used in the path segment of a URI.
〰259: 
〰260: ends-with
〰261: ends-with(xs:string?, xs:string?) as xs:boolean
〰262: 
〰263: ends-with(xs:string?, xs:string?, xs:string) as xs:boolean
〰264: 
〰265: Returns true if the string $arg1 contains $arg2 as a trailing substring, taking collations into account.
〰266: 
〰267: environment-variable
〰268: environment-variable(xs:string) as xs:string?
〰269: 
〰270: Returns the value of a system environment variable, if it exists.
〰271: 
〰272: error
〰273: error() as none
〰274: 
〰275: error(xs:QName?) as none
〰276: 
〰277: error(xs:QName?, xs:string) as none
〰278: 
〰279: error(xs:QName?, xs:string, item()*) as none
〰280: 
〰281: Calling the fn:error function raises an application-defined error.
〰282: 
〰283: escape-html-uri
〰284: escape-html-uri(xs:string?) as xs:string
〰285: 
〰286: Escapes a URI in the same way that HTML user agents handle attribute values expected to contain URIs.
〰287: 
〰288: exactly-one
〰289: exactly-one(item()*) as item()
〰290: 
〰291: Returns $arg if it contains exactly one item. Otherwise, raises an error.
〰292: 
〰293: 
〰294: filter
〰295: filter(item()*, function(item()) as xs:boolean) as item()*
〰296: 
〰297: Returns those items from the sequence $seq for which the supplied function $f returns true.
〰298: 
〰299: floor
〰300: floor(xs:numeric?) as xs:numeric?
〰301: 
〰302: Rounds $arg downwards to a whole number.
〰303: 
〰304: fold-left
〰305: fold-left(item()*, item()*, function(item()*, item()) as item()*) as item()*
〰306: 
〰307: Processes the supplied sequence from left to right, applying the supplied function repeatedly to each item in turn, together with an accumulated result value.
〰308: 
〰309: fold-right
〰310: fold-right(item()*, item()*, function(item(), item()*) as item()*) as item()*
〰311: 
〰312: Processes the supplied sequence from right to left, applying the supplied function repeatedly to each item in turn, together with an accumulated result value.
〰313: 
〰314: for-each
〰315: for-each(item()*, function(item()) as item()*) as item()*
〰316: 
〰317: Applies the function item $action to every item from the sequence $seq in turn, returning the concatenation of the resulting sequences in order.
〰318: 
〰319: for-each-pair
〰320: for-each-pair(item()*, item()*, function(item(), item()) as item()*) as item()*
〰321: 
〰322: Applies the function item $action to successive pairs of items taken one from $seq1 and one from $seq2, returning the concatenation of the resulting sequences in order.
〰323: 
〰324: format-date
〰325: format-date(xs:date?, xs:string) as xs:string?
〰326: 
〰327: format-date(xs:date?, xs:string, xs:string?, xs:string?, xs:string?) as xs:string?
〰328: 
〰329: Returns a string containing an xs:date value formatted for display.
〰330: 
〰331: format-dateTime
〰332: format-dateTime(xs:dateTime?, xs:string) as xs:string?
〰333: 
〰334: format-dateTime(xs:dateTime?, xs:string, xs:string?, xs:string?, xs:string?) as xs:string?
〰335: 
〰336: Returns a string containing an xs:dateTime value formatted for display.
〰337: 
〰338: format-integer
〰339: format-integer(xs:integer?, xs:string) as xs:string
〰340: 
〰341: format-integer(xs:integer?, xs:string, xs:string?) as xs:string
〰342: 
〰343: Formats an integer according to a given picture string, using the conventions of a given natural language if specified.
〰344: 
〰345: format-number
〰346: format-number(xs:numeric?, xs:string) as xs:string
〰347: 
〰348: format-number(xs:numeric?, xs:string, xs:string?) as xs:string
〰349: 
〰350: Returns a string containing a number formatted according to a given picture string, taking account of decimal formats specified in the static context.
〰351: 
〰352: format-time
〰353: format-time(xs:time?, xs:string) as xs:string?
〰354: 
〰355: format-time(xs:time?, xs:string, xs:string?, xs:string?, xs:string?) as xs:string?
〰356: 
〰357: Returns a string containing an xs:time value formatted for display.
〰358: 
〰359: function-arity
〰360: function-arity(function(*)) as xs:integer
〰361: 
〰362: Returns the arity of the function identified by a function item.
〰363: 
〰364: function-lookup
〰365: function-lookup(xs:QName, xs:integer) as function(*)?
〰366: 
〰367: Returns the function having a given name and arity, if there is one.
〰368: 
〰369: function-name
〰370: function-name(function(*)) as xs:QName?
〰371: 
〰372: Returns the name of the function identified by a function item.
〰373: 
〰374: generate-id
〰375: generate-id() as xs:string
〰376: 
〰377: generate-id(node()?) as xs:string
〰378: 
〰379: This function returns a string that uniquely identifies a given node.
〰380: 
〰381: has-children
〰382: has-children() as xs:boolean
〰383: 
〰384: has-children(node()?) as xs:boolean
〰385: 
〰386: Returns true if the supplied node has one or more child nodes (of any kind).
〰387: 
〰388: head
〰389: head(item()*) as item()?
〰390: 
〰391: Returns the first item in a sequence.
〰392: 
〰393: hours-from-dateTime
〰394: hours-from-dateTime(xs:dateTime?) as xs:integer?
〰395: 
〰396: Returns the hours component of an xs:dateTime.
〰397: 
〰398: hours-from-duration
〰399: hours-from-duration(xs:duration?) as xs:integer?
〰400: 
〰401: Returns the number of hours in a duration.
〰402: 
〰403: hours-from-time
〰404: hours-from-time(xs:time?) as xs:integer?
〰405: 
〰406: Returns the hours component of an xs:time.
〰407: 
〰408: id
〰409: id(xs:string*) as element()*
〰410: 
〰411: id(xs:string*, node()) as element()*
〰412: 
〰413: Returns the sequence of element nodes that have an ID value matching the value of one or more of the IDREF values supplied in $arg.
〰414: 
〰415: idref
〰416: idref(xs:string*) as node()*
〰417: 
〰418: idref(xs:string*, node()) as node()*
〰419: 
〰420: Returns the sequence of element or attribute nodes with an IDREF value matching the value of one or more of the ID values supplied in $arg.
〰421: 
〰422: implicit-timezone
〰423: implicit-timezone() as xs:dayTimeDuration
〰424: 
〰425: Returns the value of the implicit timezone property from the dynamic context.
〰426: 
〰427: index-of
〰428: index-of(xs:anyAtomicType*, xs:anyAtomicType) as xs:integer*
〰429: 
〰430: index-of(xs:anyAtomicType*, xs:anyAtomicType, xs:string) as xs:integer*
〰431: 
〰432: Returns a sequence of positive integers giving the positions within the sequence $seq of items that are equal to $search.
〰433: 
〰434: innermost
〰435: innermost(node()*) as node()*
〰436: 
〰437: Returns every node within the input sequence that is not an ancestor of another member of the input sequence; the nodes are returned in document order with duplicates eliminated.
〰438: 
〰439: in-scope-prefixes
〰440: in-scope-prefixes(element()) as xs:string*
〰441: 
〰442: Returns the prefixes of the in-scope namespaces for an element node.
〰443: 
〰444: insert-before
〰445: insert-before(item()*, xs:integer, item()*) as item()*
〰446: 
〰447: Returns a sequence constructed by inserting an item or a sequence of items at a given position within an existing sequence.
〰448: 
〰449: iri-to-uri
〰450: iri-to-uri(xs:string?) as xs:string
〰451: 
〰452: Converts a string containing an IRI into a URI according to the rules of [rfc3987].
〰453: 
〰454: json-doc
〰455: json-doc(xs:string?) as item()?
〰456: 
〰457: json-doc(xs:string?, map(*)) as item()?
〰458: 
〰459: Reads an external resource containing JSON, and returns the result of parsing the resource as JSON.
〰460: 
〰461: json-to-xml
〰462: json-to-xml(xs:string?) as document-node()?
〰463: 
〰464: json-to-xml(xs:string?, map(*)) as document-node()?
〰465: 
〰466: Parses a string supplied in the form of a JSON text, returning the results in the form of an XML document node.
〰467: 
〰468: lang
〰469: lang(xs:string?) as xs:boolean
〰470: 
〰471: lang(xs:string?, node()) as xs:boolean
〰472: 
〰473: This function tests whether the language of $node, or the context item if the second argument is omitted, as specified by xml:lang attributes is the same as, or is a sublanguage of, the language specified by $testlang.
〰474: 
〰475: last
〰476: last() as xs:integer
〰477: 
〰478: Returns the context size from the dynamic context.
〰479: 
〰480: load-xquery-module
〰481: load-xquery-module(xs:string) as map(*)
〰482: 
〰483: load-xquery-module(xs:string, map(*)) as map(*)
〰484: 
〰485: Provides access to the public functions and global variables of a dynamically-loaded XQuery library module.
〰486: 
〰487: local-name
〰488: local-name() as xs:string
〰489: 
〰490: local-name(node()?) as xs:string
〰491: 
〰492: Returns the local part of the name of $arg as an xs:string that is either the zero-length string, or has the lexical form of an xs:NCName.
〰493: 
〰494: local-name-from-QName
〰495: local-name-from-QName(xs:QName?) as xs:NCName?
〰496: 
〰497: Returns the local part of the supplied QName.
〰498: 
〰499: lower-case
〰500: lower-case(xs:string?) as xs:string
〰501: 
〰502: Converts a string to lower case.
〰503: 
〰504: matches
〰505: matches(xs:string?, xs:string) as xs:boolean
〰506: 
〰507: matches(xs:string?, xs:string, xs:string) as xs:boolean
〰508: 
〰509: Returns true if the supplied string matches a given regular expression.
〰510: 
〰511: 
〰512: Returns a value that is equal to the lowest value appearing in the input sequence.
〰513: 
〰514: minutes-from-dateTime
〰515: minutes-from-dateTime(xs:dateTime?) as xs:integer?
〰516: 
〰517: Returns the minute component of an xs:dateTime.
〰518: 
〰519: minutes-from-duration
〰520: minutes-from-duration(xs:duration?) as xs:integer?
〰521: 
〰522: Returns the number of minutes in a duration.
〰523: 
〰524: minutes-from-time
〰525: minutes-from-time(xs:time?) as xs:integer?
〰526: 
〰527: Returns the minutes component of an xs:time.
〰528: 
〰529: month-from-date
〰530: month-from-date(xs:date?) as xs:integer?
〰531: 
〰532: Returns the month component of an xs:date.
〰533: 
〰534: month-from-dateTime
〰535: month-from-dateTime(xs:dateTime?) as xs:integer?
〰536: 
〰537: Returns the month component of an xs:dateTime.
〰538: 
〰539: months-from-duration
〰540: months-from-duration(xs:duration?) as xs:integer?
〰541: 
〰542: Returns the number of months in a duration.
〰543: 
〰544: name
〰545: name() as xs:string
〰546: 
〰547: name(node()?) as xs:string
〰548: 
〰549: Returns the name of a node, as an xs:string that is either the zero-length string, or has the lexical form of an xs:QName.
〰550: 
〰551: namespace-uri
〰552: namespace-uri() as xs:anyURI
〰553: 
〰554: namespace-uri(node()?) as xs:anyURI
〰555: 
〰556: Returns the namespace URI part of the name of $arg, as an xs:anyURI value.
〰557: 
〰558: namespace-uri-for-prefix
〰559: namespace-uri-for-prefix(xs:string?, element()) as xs:anyURI?
〰560: 
〰561: Returns the namespace URI of one of the in-scope namespaces for $element, identified by its namespace prefix.
〰562: 
〰563: namespace-uri-from-QName
〰564: namespace-uri-from-QName(xs:QName?) as xs:anyURI?
〰565: 
〰566: Returns the namespace URI part of the supplied QName.
〰567: 
〰568: nilled
〰569: nilled() as xs:boolean?
〰570: 
〰571: nilled(node()?) as xs:boolean?
〰572: 
〰573: Returns true for an element that is nilled.
〰574: 
〰575: node-name
〰576: node-name() as xs:QName?
〰577: 
〰578: node-name(node()?) as xs:QName?
〰579: 
〰580: Returns the name of a node, as an xs:QName.
〰581: 
〰582: normalize-space
〰583: normalize-space() as xs:string
〰584: 
〰585: normalize-space(xs:string?) as xs:string
〰586: 
〰587: Returns the value of $arg with leading and trailing whitespace removed, and sequences of internal whitespace reduced to a single space character.
〰588: 
〰589: normalize-unicode
〰590: normalize-unicode(xs:string?) as xs:string
〰591: 
〰592: normalize-unicode(xs:string?, xs:string) as xs:string
〰593: 
〰594: Returns the value of $arg after applying Unicode normalization.
〰595: 
〰596: number
〰597: number() as xs:double
〰598: 
〰599: number(xs:anyAtomicType?) as xs:double
〰600: 
〰601: Returns the value indicated by $arg or, if $arg is not specified, the context item after atomization, converted to an xs:double.
〰602: 
〰603: one-or-more
〰604: one-or-more(item()*) as item()+
〰605: 
〰606: Returns $arg if it contains one or more items. Otherwise, raises an error.
〰607: 
〰608: outermost
〰609: outermost(node()*) as node()*
〰610: 
〰611: Returns every node within the input sequence that has no ancestor that is itself a member of the input sequence; the nodes are returned in document order with duplicates eliminated.
〰612: 
〰613: parse-ietf-date
〰614: parse-ietf-date(xs:string?) as xs:dateTime?
〰615: 
〰616: Parses a string containing the date and time in IETF format, returning the corresponding xs:dateTime value.
〰617: 
〰618: parse-json
〰619: parse-json(xs:string?) as item()?
〰620: 
〰621: parse-json(xs:string?, map(*)) as item()?
〰622: 
〰623: Parses a string supplied in the form of a JSON text, returning the results typically in the form of a map or array.
〰624: 
〰625: parse-xml
〰626: parse-xml(xs:string?) as document-node(element(*))?
〰627: 
〰628: This function takes as input an XML document represented as a string, and returns the document node at the root of an XDM tree representing the parsed document.
〰629: 
〰630: parse-xml-fragment
〰631: parse-xml-fragment(xs:string?) as document-node()?
〰632: 
〰633: This function takes as input an XML external entity represented as a string, and returns the document node at the root of an XDM tree representing the parsed document fragment.
〰634: 
〰635: path
〰636: path() as xs:string?
〰637: 
〰638: path(node()?) as xs:string?
〰639: 
〰640: Returns a path expression that can be used to select the supplied node relative to the root of its containing document.
〰641: 
〰642: position
〰643: position() as xs:integer
〰644: 
〰645: Returns the context position from the dynamic context.
〰646: 
〰647: prefix-from-QName
〰648: prefix-from-QName(xs:QName?) as xs:NCName?
〰649: 
〰650: Returns the prefix component of the supplied QName.
〰651: 
〰652: QName
〰653: QName(xs:string?, xs:string) as xs:QName
〰654: 
〰655: Returns an xs:QName value formed using a supplied namespace URI and lexical QName.
〰656: 
〰657: random-number-generator
〰658: random-number-generator() as map(xs:string, item())
〰659: 
〰660: random-number-generator(xs:anyAtomicType?) as map(xs:string, item())
〰661: 
〰662: Returns a random number generator, which can be used to generate sequences of random numbers.
〰663: 
〰664: remove
〰665: remove(item()*, xs:integer) as item()*
〰666: 
〰667: Returns a new sequence containing all the items of $target except the item at position $position.
〰668: 
〰669: replace
〰670: replace(xs:string?, xs:string, xs:string) as xs:string
〰671: 
〰672: replace(xs:string?, xs:string, xs:string, xs:string) as xs:string
〰673: 
〰674: Returns a string produced from the input string by replacing any substrings that match a given regular expression with a supplied replacement string.
〰675: 
〰676: resolve-QName
〰677: resolve-QName(xs:string?, element()) as xs:QName?
〰678: 
〰679: Returns an xs:QName value (that is, an expanded-QName) by taking an xs:string that has the lexical form of an xs:QName (a string in the form "prefix:local-name" or "local-name") and resolving it using the in-scope namespaces for a given element.
〰680: 
〰681: resolve-uri
〰682: resolve-uri(xs:string?) as xs:anyURI?
〰683: 
〰684: resolve-uri(xs:string?, xs:string) as xs:anyURI?
〰685: 
〰686: Resolves a relative IRI reference against an absolute IRI.
〰687: 
〰688: reverse
〰689: reverse(item()*) as item()*
〰690: 
〰691: Reverses the order of items in a sequence.
〰692: 
〰693: root
〰694: root() as node()
〰695: 
〰696: root(node()?) as node()?
〰697: 
〰698: Returns the root of the tree to which $arg belongs. This will usually, but not necessarily, be a document node.
〰699: 
〰700: round
〰701: round(xs:numeric?) as xs:numeric?
〰702: 
〰703: round(xs:numeric?, xs:integer) as xs:numeric?
〰704: 
〰705: Rounds a value to a specified number of decimal places, rounding upwards if two such values are equally near.
〰706: 
〰707: round-half-to-even
〰708: round-half-to-even(xs:numeric?) as xs:numeric?
〰709: 
〰710: round-half-to-even(xs:numeric?, xs:integer) as xs:numeric?
〰711: 
〰712: Rounds a value to a specified number of decimal places, rounding to make the last digit even if two such values are equally near.
〰713: 
〰714: seconds-from-dateTime
〰715: seconds-from-dateTime(xs:dateTime?) as xs:decimal?
〰716: 
〰717: Returns the seconds component of an xs:dateTime.
〰718: 
〰719: seconds-from-duration
〰720: seconds-from-duration(xs:duration?) as xs:decimal?
〰721: 
〰722: Returns the number of seconds in a duration.
〰723: 
〰724: seconds-from-time
〰725: seconds-from-time(xs:time?) as xs:decimal?
〰726: 
〰727: Returns the seconds component of an xs:time.
〰728: 
〰729: serialize
〰730: serialize(item()*) as xs:string
〰731: 
〰732: serialize(item()*, item()?) as xs:string
〰733: 
〰734: This function serializes the supplied input sequence $arg as described in [xslt-xquery-serialization-31], returning the serialized representation of the sequence as a string.
〰735: 
〰736: sort
〰737: sort(item()*) as item()*
〰738: 
〰739: sort(item()*, xs:string?) as item()*
〰740: 
〰741: sort(item()*, xs:string?, function(item()) as xs:anyAtomicType*) as item()*
〰742: 
〰743: Sorts a supplied sequence, based on the value of a sort key supplied as a function.
〰744: 
〰745: starts-with
〰746: starts-with(xs:string?, xs:string?) as xs:boolean
〰747: 
〰748: starts-with(xs:string?, xs:string?, xs:string) as xs:boolean
〰749: 
〰750: Returns true if the string $arg1 contains $arg2 as a leading substring, taking collations into account.
〰751: 
〰752: static-base-uri
〰753: static-base-uri() as xs:anyURI?
〰754: 
〰755: This function returns the value of the static base URI property from the static context.
〰756: 
〰757: string
〰758: string() as xs:string
〰759: 
〰760: string(item()?) as xs:string
〰761: 
〰762: Returns the value of $arg represented as an xs:string.
〰763: 
〰764: string-join
〰765: string-join(xs:anyAtomicType*) as xs:string
〰766: 
〰767: string-join(xs:anyAtomicType*, xs:string) as xs:string
〰768: 
〰769: Returns a string created by concatenating the items in a sequence, with a defined separator between adjacent items.
〰770: 
〰771: string-length
〰772: string-length() as xs:integer
〰773: 
〰774: string-length(xs:string?) as xs:integer
〰775: 
〰776: Returns the number of characters in a string.
〰777: 
〰778: string-to-codepoints
〰779: string-to-codepoints(xs:string?) as xs:integer*
〰780: 
〰781: Returns the sequence of codepoints that constitute an xs:string value.
〰782: 
〰783: subsequence
〰784: subsequence(item()*, xs:double) as item()*
〰785: 
〰786: subsequence(item()*, xs:double, xs:double) as item()*
〰787: 
〰788: Returns the contiguous sequence of items in the value of $sourceSeq beginning at the position indicated by the value of $startingLoc and continuing for the number of items indicated by the value of $length.
〰789: 
〰790: substring
〰791: substring(xs:string?, xs:double) as xs:string
〰792: 
〰793: substring(xs:string?, xs:double, xs:double) as xs:string
〰794: 
〰795: Returns the portion of the value of $sourceString beginning at the position indicated by the value of $start and continuing for the number of characters indicated by the value of $length.
〰796: 
〰797: substring-after
〰798: substring-after(xs:string?, xs:string?) as xs:string
〰799: 
〰800: substring-after(xs:string?, xs:string?, xs:string) as xs:string
〰801: 
〰802: Returns the part of $arg1 that follows the first occurrence of $arg2, taking collations into account.
〰803: 
〰804: substring-before
〰805: substring-before(xs:string?, xs:string?) as xs:string
〰806: 
〰807: substring-before(xs:string?, xs:string?, xs:string) as xs:string
〰808: 
〰809: Returns the part of $arg1 that precedes the first occurrence of $arg2, taking collations into account.
〰810: 
〰811: tail
〰812: tail(item()*) as item()*
〰813: 
〰814: Returns all but the first item in a sequence.
〰815: 
〰816: timezone-from-date
〰817: timezone-from-date(xs:date?) as xs:dayTimeDuration?
〰818: 
〰819: Returns the timezone component of an xs:date.
〰820: 
〰821: timezone-from-dateTime
〰822: timezone-from-dateTime(xs:dateTime?) as xs:dayTimeDuration?
〰823: 
〰824: Returns the timezone component of an xs:dateTime.
〰825: 
〰826: timezone-from-time
〰827: timezone-from-time(xs:time?) as xs:dayTimeDuration?
〰828: 
〰829: Returns the timezone component of an xs:time.
〰830: 
〰831: tokenize
〰832: tokenize(xs:string?) as xs:string*
〰833: 
〰834: tokenize(xs:string?, xs:string) as xs:string*
〰835: 
〰836: tokenize(xs:string?, xs:string, xs:string) as xs:string*
〰837: 
〰838: Returns a sequence of strings constructed by splitting the input wherever a separator is found; the separator is any substring that matches a given regular expression.
〰839: 
〰840: trace
〰841: trace(item()*) as item()*
〰842: 
〰843: trace(item()*, xs:string) as item()*
〰844: 
〰845: Provides an execution trace intended to be used in debugging queries.
〰846: 
〰847: transform
〰848: transform(map(*)) as map(*)
〰849: 
〰850: Invokes a transformation using a dynamically-loaded XSLT stylesheet.
〰851: 
〰852: translate
〰853: translate(xs:string?, xs:string, xs:string) as xs:string
〰854: 
〰855: Returns the value of $arg modified by replacing or removing individual characters.
〰856: 
〰857: unordered
〰858: unordered(item()*) as item()*
〰859: 
〰860: Returns the items of $sourceSeq in an implementation-dependent order.
〰861: 
〰862: unparsed-text
〰863: unparsed-text(xs:string?) as xs:string?
〰864: 
〰865: unparsed-text(xs:string?, xs:string) as xs:string?
〰866: 
〰867: The fn:unparsed-text function reads an external resource (for example, a file) and returns a string representation of the resource.
〰868: 
〰869: unparsed-text-available
〰870: unparsed-text-available(xs:string?) as xs:boolean
〰871: 
〰872: unparsed-text-available(xs:string?, xs:string) as xs:boolean
〰873: 
〰874: Because errors in evaluating the fn:unparsed-text function are non-recoverable, these two functions are provided to allow an application to determine whether a call with particular arguments would succeed.
〰875: 
〰876: unparsed-text-lines
〰877: unparsed-text-lines(xs:string?) as xs:string*
〰878: 
〰879: unparsed-text-lines(xs:string?, xs:string) as xs:string*
〰880: 
〰881: The fn:unparsed-text-lines function reads an external resource (for example, a file) and returns its contents as a sequence of strings, one for each line of text in the string representation of the resource.
〰882: 
〰883: upper-case
〰884: upper-case(xs:string?) as xs:string
〰885: 
〰886: Converts a string to upper case.
〰887: 
〰888: uri-collection
〰889: uri-collection() as xs:anyURI*
〰890: 
〰891: uri-collection(xs:string?) as xs:anyURI*
〰892: 
〰893: Returns a sequence of xs:anyURI values representing the URIs in a URI collection.
〰894: 
〰895: xml-to-json
〰896: xml-to-json(node()?) as xs:string?
〰897: 
〰898: xml-to-json(node()?, map(*)) as xs:string?
〰899: 
〰900: Converts an XML tree, whose format corresponds to the XML representation of JSON defined in this specification, into a string conforming to the JSON grammar.
〰901: 
〰902: year-from-date
〰903: year-from-date(xs:date?) as xs:integer?
〰904: 
〰905: Returns the year component of an xs:date.
〰906: 
〰907: year-from-dateTime
〰908: year-from-dateTime(xs:dateTime?) as xs:integer?
〰909: 
〰910: Returns the year component of an xs:dateTime.
〰911: 
〰912: years-from-duration
〰913: years-from-duration(xs:duration?) as xs:integer?
〰914: 
〰915: Returns the number of years in a duration.
〰916: 
〰917: zero-or-one
〰918: zero-or-one(item()*) as item()?
〰919: 
〰920: Returns $arg if it contains zero or one items. Otherwise, raises an error.
〰921: 
〰922: 3 XSL Transformations (XSLT) Functions
〰923: This section lists all of the functions in this namespace that are defined in the [XSLT 3.0] specification.
〰924: 
〰925: The normative definitions of these functions are in the [XSLT 3.0] specification. For convenience, a very brief, non-normative summary of each function is provided. For details, follow the link on the “Summary:” introductory text below each function.
〰926: 
〰927: Note that XSLT 3.0, because it is not dependent on XPath 3.1, also reproduces some of the functions specifications that appear in XPath 3.1. For an XSLT 3.0 processor that works with XPath 3.0, the normative specification in this case is the one that appears in the XSLT 3.0 specification.
〰928: 
〰929: accumulator-after
〰930: accumulator-after(xs:string) as item()*
〰931: 
〰932: Returns the post-descent value of the selected accumulator at the context node.
〰933: 
〰934: accumulator-before
〰935: accumulator-before(xs:string) as item()*
〰936: 
〰937: Returns the pre-descent value of the selected accumulator at the context node.
〰938: 
〰939: available-system-properties
〰940: available-system-properties() as xs:QName*
〰941: 
〰942: Returns a list of system property names that are suitable for passing to the system-property function, as a sequence of QNames.
〰943: 
〰944: collation-key
〰945: collation-key(xs:string) as xs:base64Binary
〰946: 
〰947: collation-key(xs:string, xs:string) as xs:base64Binary
〰948: 
〰949: Given a string value and a collation, generates an internal value called a collation key, with the property that the matching and ordering of collation keys reflects the matching and ordering of strings under the specified collation.
〰950: 
〰951: copy-of
〰952: copy-of() as item()
〰953: 
〰954: copy-of(item()*) as item()*
〰955: 
〰956: Returns a deep copy of the sequence supplied as the $input argument, or of the context item if the argument is absent.
〰957: 
〰958: current
〰959: current() as item()
〰960: 
〰961: Returns the item that is the context item for the evaluation of the containing XPath expression
〰962: 
〰963: current-group
〰964: current-group() as item()*
〰965: 
〰966: Returns the group currently being processed by an xsl:for-each-group instruction.
〰967: 
〰968: current-grouping-key
〰969: current-grouping-key() as xs:anyAtomicType*
〰970: 
〰971: Returns the grouping key of the group currently being processed using the xsl:for-each-group instruction.
〰972: 
〰973: current-merge-group
〰974: current-merge-group() as item()*
〰975: 
〰976: current-merge-group(xs:string) as item()*
〰977: 
〰978: Returns the group of items currently being processed by an xsl:merge instruction.
〰979: 
〰980: current-merge-key
〰981: current-merge-key() as xs:anyAtomicType*
〰982: 
〰983: Returns the merge key of the merge group currently being processed using the xsl:merge instruction.
〰984: 
〰985: current-output-uri
〰986: current-output-uri() as xs:anyURI?
〰987: 
〰988: Returns the value of the .
〰989: 
〰990: deep-equal
〰991: deep-equal(item()*, item()*) as xs:boolean
〰992: 
〰993: deep-equal(item()*, item()*, xs:string) as xs:boolean
〰994: 
〰995: This function assesses whether two sequences are deep-equal to each other. The function as described here extends the definition of the XPath 3.0 deep-equal to explain how it should handle maps; it is intended to replace the existing deep-equal function at some stage in the future.
〰996: 
〰997: document
〰998: document(item()*) as node()*
〰999: 
〰1000:document(item()*, node()) as node()*
〰1001:
〰1002:Provides access to XML documents identified by a URI.
〰1003:
〰1004:element-available
〰1005:element-available(xs:string) as xs:boolean
〰1006:
〰1007:Determines whether a particular instruction is or is not available for use. The function is particularly useful for calling within an [xsl:]use-when attribute (see ) to test whether a particular is available.
〰1008:
〰1009:function-available
〰1010:function-available(xs:string) as xs:boolean
〰1011:
〰1012:function-available(xs:string, xs:integer) as xs:boolean
〰1013:
〰1014:Determines whether a particular function is or is not available for use. The function is particularly useful for calling within an [xsl:]use-when attribute (see ) to test whether a particular is available.
〰1015:
〰1016:json-to-xml
〰1017:json-to-xml(xs:string) as document-node()
〰1018:
〰1019:json-to-xml(xs:string, map(*)) as document-node()
〰1020:
〰1021:Parses a string supplied in the form of a JSON text, returning the results in the form of an XML document node.
〰1022:
〰1023:key
〰1024:key(xs:string, xs:anyAtomicType*) as node()*
〰1025:
〰1026:key(xs:string, xs:anyAtomicType*, node()) as node()*
〰1027:
〰1028:Returns the nodes that match a supplied key value.
〰1029:
〰1030:regex-group
〰1031:regex-group(xs:integer) as xs:string
〰1032:
〰1033:Returns the string captured by a parenthesized subexpression of the regular expression used during evaluation of the xsl:analyze-string instruction.
〰1034:
〰1035:snapshot
〰1036:snapshot() as item()
〰1037:
〰1038:snapshot(item()*) as item()*
〰1039:
〰1040:Returns a copy of a sequence, retaining copies of the ancestors and descendants of any node in the input sequence, together with their attributes and namespaces.
〰1041:
〰1042:stream-available
〰1043:stream-available(xs:string?) as xs:boolean
〰1044:
〰1045:Determines, as far as possible, whether a document is available for streamed processing using xsl:source-document.
〰1046:
〰1047:system-property
〰1048:system-property(xs:string) as xs:string
〰1049:
〰1050:Returns the value of a system property
〰1051:
〰1052:type-available
〰1053:type-available(xs:string) as xs:boolean
〰1054:
〰1055:Used to control how a stylesheet behaves if a particular schema type is or is not available in the static context.
〰1056:
〰1057:unparsed-entity-public-id
〰1058:unparsed-entity-public-id(xs:string) as xs:string
〰1059:
〰1060:unparsed-entity-public-id(xs:string, node()) as xs:string
〰1061:
〰1062:Returns the public identifier of an unparsed entity
〰1063:
〰1064:unparsed-entity-uri
〰1065:unparsed-entity-uri(xs:string) as xs:anyURI
〰1066:
〰1067:unparsed-entity-uri(xs:string, node()) as xs:anyURI
〰1068:
〰1069:Returns the URI (system identifier) of an unparsed entity
〰1070:
〰1071:xml-to-json
〰1072:xml-to-json(node()?) as xs:string?
〰1073:
〰1074:xml-to-json(node()?, map(*)) as xs:string?
〰1075:
〰1076:Converts an XML tree, whose format corresponds to the XML representation of JSON defined in this specification, into a string conforming to the JSON grammar.
〰1077:
〰1078:4 XQuery Update Functions
〰1079:This section lists all of the functions in this namespace that are defined in the [XQuery Update 1.0] specification.
〰1080:
〰1081:The normative definitions of these functions are in the [XQuery Update 1.0] specification. For convenience, a very brief, non-normative summary of each function is provided. For details, follow the link on the “Summary:” introductory text below each function.
〰1082:
〰1083:put
〰1084:put(node(), xs:string) as empty-sequence()
〰1085:
〰1086:Stores a document or element to the location specified by $uri. This function is normally invoked to create a resource on an external storage system such as a file system or a database.
〰1087:
〰1088:The external effects of fn:put are implementation-defined, since they occur outside the domain of XQuery. The intent is that, if fn:put is invoked on a document node and no error is raised, a subsequent query can access the stored document by invoking fn:doc with the same URI.
〰1089:
〰1090:
〰1091:        */
〰1092:    }
〰1093:}
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

