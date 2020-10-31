# BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.XPath20Functions

## Summary

| Key             | Value                                                            |
| :-------------- | :--------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.XPath20Functions` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                     |
| Coveredlines    | `0`                                                              |
| Uncoveredlines  | `23`                                                             |
| Coverablelines  | `23`                                                             |
| Totallines      | `1206`                                                           |
| Linecoverage    | `0`                                                              |
| Coveredbranches | `0`                                                              |
| Totalbranches   | `0`                                                              |

## Metrics

| Complexity | Lines | Branches | Name              |
| :--------- | :---- | :------- | :---------------- |
| 1          | 0     | 100      | `abs`             |
| 1          | 0     | 100      | `ceiling`         |
| 1          | 0     | 100      | `max`             |
| 1          | 0     | 100      | `min`             |
| 1          | 0     | 100      | `distinct_values` |
| 1          | 0     | 100      | `apply`           |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\Xsl\Extensions\XPath20Functions.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰2:   using System;
〰3:   using System.Linq;
〰4:   using System.Threading.Tasks.Sources;
〰5:   using System.Xml;
〰6:   using System.Xml.Serialization;
〰7:   using System.Xml.XPath;
〰8:   
〰9:   namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions
〰10:  {
〰11:      [XmlRoot(Namespace = @"http://www.w3.org/2005/xpath-functions")]
〰12:      public class XPath20Functions
〰13:      {
‼14:          public decimal abs(decimal input) => Math.Abs(input);
‼15:          public decimal ceiling(decimal input) => Math.Ceiling(input);
〰16:  
〰17:          public decimal max(XPathNodeIterator input) =>
‼18:              (from i in input.AsNavigatorSet()
‼19:               where !string.IsNullOrWhiteSpace(i.Value)
‼20:               let d = decimal.TryParse(i.Value, out var v) ? (decimal?)v : null
‼21:               where d.HasValue
‼22:               select d).Max() ?? 0;
〰23:  
〰24:          public decimal min(XPathNodeIterator input) =>
‼25:              (from i in input.AsNavigatorSet()
‼26:               where !string.IsNullOrWhiteSpace(i.Value)
‼27:               let d = decimal.TryParse(i.Value, out var v) ? (decimal?)v : null
‼28:               where d.HasValue
‼29:               select d).Min() ?? 0;
〰30:  
〰31:          // https://www.w3.org/2005/xpath-functions/
〰32:  
〰33:          public XPathNodeIterator distinct_values(XPathNodeIterator input) =>
‼34:               new EnumerableXPathNodeIterator(
‼35:                  from i in input.AsNavigatorSet()
‼36:                  group i by i.Value into grouped
‼37:                  from i in grouped
‼38:                  select grouped.First());
〰39:  
〰40:          public XPathNodeIterator apply(string xpath, XPathNodeIterator input) =>
‼41:               new EnumerableXPathNodeIterator(
‼42:                  from item in input.AsNavigatorSet()
‼43:                  let value = item.Evaluate(xpath)
‼44:                  from node in value.AsNodeSet()
‼45:                  select node
‼46:                  );
〰47:          /*
〰48:  
〰49:  ↑ Jump to Table of Contents← Collapse Sidebar
〰50:  
〰51:  W3C
〰52:  
〰53:  XQuery, XPath, and XSLT Functions and Operators Namespace Document
〰54:  21 March 2017
〰55:  Table of Contents
〰56:  1 Introduction
〰57:  2 XQuery and XPath Functions
〰58:  3 XSL Transformations (XSLT) Functions
〰59:  4 XQuery Update Functions
〰60:  5 XML Schema
〰61:  6 Normative References
〰62:  7 Non-Normative References
〰63:  1 Introduction
〰64:  This document describes the namespace http://www.w3.org/2005/xpath-functions defined by the [XPath and XQuery Functions and Operators 3.1] and [XSLT 3.0] specifications. This namespace is conventionally identified by the namespace prefix fn.
〰65:  
〰66:  In XQuery, the mapping of the prefix fn to this namespace is predefined.
〰67:  
〰68:  In XSLT, it is not necessary to use a prefix when invoking functions in this namespace, because this namespace is always the default namespace for function calls.
〰69:  
〰70:  For updated information, please refer to the latest version of the [XPath and XQuery Functions and Operators 3.1] and [XSLT 3.0] specifications.
〰71:  
〰72:  The [XQuery Update 1.0] specification defines one additional function in this namespace.
〰73:  
〰74:  Functions are uniquely identified by the combination of namespace URI, local name, and arity (number of arguments). For the purpose of this document, functions having a common namespace URI and local name can be considered to form a function family. A function family can be uniquely identified with a URI of the form: “http://www.w3.org/2005/xpath-functions#name” where name is the local name of a function, such as “max”: http://www.w3.org/2005/xpath-functions#max.
〰75:  
〰76:  This document describes the names that are defined in this namespace at the time of publication. The W3C reserves the right to define additional names in this namespace in the future. The specifications listed above are the only specifications that may amend this namespace.
〰77:  
〰78:  The specifications referenced in this document are the latest versions at time of publication. Older versions of these specifications remain in use, and depending on the context, a name in this namespace may be referring to an older version of the specification than the one cited here.
〰79:  
〰80:  This document contains a directory of links to related resources, using RDDL (as defined in [Resource Directory Description Language (RDDL)]).
〰81:  
〰82:  It is GRDDL-enabled (as defined in [Gleaning Resource Descriptions from Dialects of Languages (GRDDL)]); that is to say that a GRDDL-compliant processor can extract useful RDF (as defined in [Resource Description Framework (RDF): Concepts and Abstract Syntax]) representations of the information contained herein.
〰83:  
〰84:  2 XQuery and XPath Functions
〰85:  This section lists all of the functions in this namespace that are defined in the [XPath and XQuery Functions and Operators 3.1] specification.
〰86:  
〰87:  The normative definitions of these functions are in the [XPath and XQuery Functions and Operators 3.1] specification. For convenience, a very brief, non-normative summary of each function is provided. For details, follow the link on the “Summary:” introductory text below each function.
〰88:  
〰89:  abs
〰90:  abs(xs:numeric?) as xs:numeric?
〰91:  
〰92:  Returns the absolute value of $arg.
〰93:  
〰94:  adjust-dateTime-to-timezone
〰95:  adjust-dateTime-to-timezone(xs:dateTime?) as xs:dateTime?
〰96:  
〰97:  adjust-dateTime-to-timezone(xs:dateTime?, xs:dayTimeDuration?) as xs:dateTime?
〰98:  
〰99:  Adjusts an xs:dateTime value to a specific timezone, or to no timezone at all.
〰100: 
〰101: adjust-date-to-timezone
〰102: adjust-date-to-timezone(xs:date?) as xs:date?
〰103: 
〰104: adjust-date-to-timezone(xs:date?, xs:dayTimeDuration?) as xs:date?
〰105: 
〰106: Adjusts an xs:date value to a specific timezone, or to no timezone at all; the result is the date in the target timezone that contains the starting instant of the supplied date.
〰107: 
〰108: adjust-time-to-timezone
〰109: adjust-time-to-timezone(xs:time?) as xs:time?
〰110: 
〰111: adjust-time-to-timezone(xs:time?, xs:dayTimeDuration?) as xs:time?
〰112: 
〰113: Adjusts an xs:time value to a specific timezone, or to no timezone at all.
〰114: 
〰115: analyze-string
〰116: analyze-string(xs:string?, xs:string) as element(fn:analyze-string-result)
〰117: 
〰118: analyze-string(xs:string?, xs:string, xs:string) as element(fn:analyze-string-result)
〰119: 
〰120: Analyzes a string using a regular expression, returning an XML structure that identifies which parts of the input string matched or failed to match the regular expression, and in the case of matched substrings, which substrings matched each capturing group in the regular expression.
〰121: 
〰122: apply
〰123: apply(function(*), array(*)) as item()*
〰124: 
〰125: Makes a dynamic call on a function with an argument list supplied in the form of an array.
〰126: 
〰127: available-environment-variables
〰128: available-environment-variables() as xs:string*
〰129: 
〰130: Returns a list of environment variable names that are suitable for passing to fn:environment-variable, as a (possibly empty) sequence of strings.
〰131: 
〰132: avg
〰133: avg(xs:anyAtomicType*) as xs:anyAtomicType?
〰134: 
〰135: Returns the average of the values in the input sequence $arg, that is, the sum of the values divided by the number of values.
〰136: 
〰137: base-uri
〰138: base-uri() as xs:anyURI?
〰139: 
〰140: base-uri(node()?) as xs:anyURI?
〰141: 
〰142: Returns the base URI of a node.
〰143: 
〰144: boolean
〰145: boolean(item()*) as xs:boolean
〰146: 
〰147: Computes the effective boolean value of the sequence $arg.
〰148: 
〰149: ceiling
〰150: ceiling(xs:numeric?) as xs:numeric?
〰151: 
〰152: Rounds $arg upwards to a whole number.
〰153: 
〰154: codepoint-equal
〰155: codepoint-equal(xs:string?, xs:string?) as xs:boolean?
〰156: 
〰157: Returns true if two strings are equal, considered codepoint-by-codepoint.
〰158: 
〰159: codepoints-to-string
〰160: codepoints-to-string(xs:integer*) as xs:string
〰161: 
〰162: Returns an xs:string whose characters have supplied codepoints.
〰163: 
〰164: collation-key
〰165: collation-key(xs:string) as xs:base64Binary
〰166: 
〰167: collation-key(xs:string, xs:string) as xs:base64Binary
〰168: 
〰169: Given a string value and a collation, generates an internal value called a collation key, with the property that the matching and ordering of collation keys reflects the matching and ordering of strings under the specified collation.
〰170: 
〰171: collection
〰172: collection() as item()*
〰173: 
〰174: collection(xs:string?) as item()*
〰175: 
〰176: Returns a sequence of items identified by a collection URI; or a default collection if no URI is supplied.
〰177: 
〰178: compare
〰179: compare(xs:string?, xs:string?) as xs:integer?
〰180: 
〰181: compare(xs:string?, xs:string?, xs:string) as xs:integer?
〰182: 
〰183: Returns -1, 0, or 1, depending on whether $comparand1 collates before, equal to, or after $comparand2 according to the rules of a selected collation.
〰184: 
〰185: concat
〰186: concat(xs:anyAtomicType?, xs:anyAtomicType?, xs:anyAtomicType?) as xs:string
〰187: 
〰188: Returns the concatenation of the string values of the arguments.
〰189: 
〰190: contains
〰191: contains(xs:string?, xs:string?) as xs:boolean
〰192: 
〰193: contains(xs:string?, xs:string?, xs:string) as xs:boolean
〰194: 
〰195: Returns true if the string $arg1 contains $arg2 as a substring, taking collations into account.
〰196: 
〰197: contains-token
〰198: contains-token(xs:string*, xs:string) as xs:boolean
〰199: 
〰200: contains-token(xs:string*, xs:string, xs:string) as xs:boolean
〰201: 
〰202: Determines whether or not any of the supplied strings, when tokenized at whitespace boundaries, contains the supplied token, under the rules of the supplied collation.
〰203: 
〰204: count
〰205: count(item()*) as xs:integer
〰206: 
〰207: Returns the number of items in a sequence.
〰208: 
〰209: current-date
〰210: current-date() as xs:date
〰211: 
〰212: Returns the current date.
〰213: 
〰214: current-dateTime
〰215: current-dateTime() as xs:dateTimeStamp
〰216: 
〰217: Returns the current date and time (with timezone).
〰218: 
〰219: current-time
〰220: current-time() as xs:time
〰221: 
〰222: Returns the current time.
〰223: 
〰224: data
〰225: data() as xs:anyAtomicType*
〰226: 
〰227: data(item()*) as xs:anyAtomicType*
〰228: 
〰229: Returns the result of atomizing a sequence. This process flattens arrays, and replaces nodes by their typed values.
〰230: 
〰231: dateTime
〰232: dateTime(xs:date?, xs:time?) as xs:dateTime?
〰233: 
〰234: Returns an xs:dateTime value created by combining an xs:date and an xs:time.
〰235: 
〰236: day-from-date
〰237: day-from-date(xs:date?) as xs:integer?
〰238: 
〰239: Returns the day component of an xs:date.
〰240: 
〰241: day-from-dateTime
〰242: day-from-dateTime(xs:dateTime?) as xs:integer?
〰243: 
〰244: Returns the day component of an xs:dateTime.
〰245: 
〰246: days-from-duration
〰247: days-from-duration(xs:duration?) as xs:integer?
〰248: 
〰249: Returns the number of days in a duration.
〰250: 
〰251: deep-equal
〰252: deep-equal(item()*, item()*) as xs:boolean
〰253: 
〰254: deep-equal(item()*, item()*, xs:string) as xs:boolean
〰255: 
〰256: This function assesses whether two sequences are deep-equal to each other. To be deep-equal, they must contain items that are pairwise deep-equal; and for two items to be deep-equal, they must either be atomic values that compare equal, or nodes of the same kind, with the same name, whose children are deep-equal, or maps with matching entries, or arrays with matching members.
〰257: 
〰258: default-collation
〰259: default-collation() as xs:string
〰260: 
〰261: Returns the value of the default collation property from the static context.
〰262: 
〰263: default-language
〰264: default-language() as xs:language
〰265: 
〰266: Returns the value of the default language property from the dynamic context.
〰267: 
〰268: distinct-values
〰269: distinct-values(xs:anyAtomicType*) as xs:anyAtomicType*
〰270: 
〰271: distinct-values(xs:anyAtomicType*, xs:string) as xs:anyAtomicType*
〰272: 
〰273: Returns the values that appear in a sequence, with duplicates eliminated.
〰274: 
〰275: doc
〰276: doc(xs:string?) as document-node()?
〰277: 
〰278: Retrieves a document using a URI supplied as an xs:string, and returns the corresponding document node.
〰279: 
〰280: doc-available
〰281: doc-available(xs:string?) as xs:boolean
〰282: 
〰283: The function returns true if and only if the function call fn:doc($uri) would return a document node.
〰284: 
〰285: document-uri
〰286: document-uri() as xs:anyURI?
〰287: 
〰288: document-uri(node()?) as xs:anyURI?
〰289: 
〰290: Returns the URI of a resource where a document can be found, if available.
〰291: 
〰292: element-with-id
〰293: element-with-id(xs:string*) as element()*
〰294: 
〰295: element-with-id(xs:string*, node()) as element()*
〰296: 
〰297: Returns the sequence of element nodes that have an ID value matching the value of one or more of the IDREF values supplied in $arg.
〰298: 
〰299: empty
〰300: empty(item()*) as xs:boolean
〰301: 
〰302: Returns true if the argument is the empty sequence.
〰303: 
〰304: encode-for-uri
〰305: encode-for-uri(xs:string?) as xs:string
〰306: 
〰307: Encodes reserved characters in a string that is intended to be used in the path segment of a URI.
〰308: 
〰309: ends-with
〰310: ends-with(xs:string?, xs:string?) as xs:boolean
〰311: 
〰312: ends-with(xs:string?, xs:string?, xs:string) as xs:boolean
〰313: 
〰314: Returns true if the string $arg1 contains $arg2 as a trailing substring, taking collations into account.
〰315: 
〰316: environment-variable
〰317: environment-variable(xs:string) as xs:string?
〰318: 
〰319: Returns the value of a system environment variable, if it exists.
〰320: 
〰321: error
〰322: error() as none
〰323: 
〰324: error(xs:QName?) as none
〰325: 
〰326: error(xs:QName?, xs:string) as none
〰327: 
〰328: error(xs:QName?, xs:string, item()*) as none
〰329: 
〰330: Calling the fn:error function raises an application-defined error.
〰331: 
〰332: escape-html-uri
〰333: escape-html-uri(xs:string?) as xs:string
〰334: 
〰335: Escapes a URI in the same way that HTML user agents handle attribute values expected to contain URIs.
〰336: 
〰337: exactly-one
〰338: exactly-one(item()*) as item()
〰339: 
〰340: Returns $arg if it contains exactly one item. Otherwise, raises an error.
〰341: 
〰342: exists
〰343: exists(item()*) as xs:boolean
〰344: 
〰345: Returns true if the argument is a non-empty sequence.
〰346: 
〰347: false
〰348: false() as xs:boolean
〰349: 
〰350: Returns the xs:boolean value false.
〰351: 
〰352: filter
〰353: filter(item()*, function(item()) as xs:boolean) as item()*
〰354: 
〰355: Returns those items from the sequence $seq for which the supplied function $f returns true.
〰356: 
〰357: floor
〰358: floor(xs:numeric?) as xs:numeric?
〰359: 
〰360: Rounds $arg downwards to a whole number.
〰361: 
〰362: fold-left
〰363: fold-left(item()*, item()*, function(item()*, item()) as item()*) as item()*
〰364: 
〰365: Processes the supplied sequence from left to right, applying the supplied function repeatedly to each item in turn, together with an accumulated result value.
〰366: 
〰367: fold-right
〰368: fold-right(item()*, item()*, function(item(), item()*) as item()*) as item()*
〰369: 
〰370: Processes the supplied sequence from right to left, applying the supplied function repeatedly to each item in turn, together with an accumulated result value.
〰371: 
〰372: for-each
〰373: for-each(item()*, function(item()) as item()*) as item()*
〰374: 
〰375: Applies the function item $action to every item from the sequence $seq in turn, returning the concatenation of the resulting sequences in order.
〰376: 
〰377: for-each-pair
〰378: for-each-pair(item()*, item()*, function(item(), item()) as item()*) as item()*
〰379: 
〰380: Applies the function item $action to successive pairs of items taken one from $seq1 and one from $seq2, returning the concatenation of the resulting sequences in order.
〰381: 
〰382: format-date
〰383: format-date(xs:date?, xs:string) as xs:string?
〰384: 
〰385: format-date(xs:date?, xs:string, xs:string?, xs:string?, xs:string?) as xs:string?
〰386: 
〰387: Returns a string containing an xs:date value formatted for display.
〰388: 
〰389: format-dateTime
〰390: format-dateTime(xs:dateTime?, xs:string) as xs:string?
〰391: 
〰392: format-dateTime(xs:dateTime?, xs:string, xs:string?, xs:string?, xs:string?) as xs:string?
〰393: 
〰394: Returns a string containing an xs:dateTime value formatted for display.
〰395: 
〰396: format-integer
〰397: format-integer(xs:integer?, xs:string) as xs:string
〰398: 
〰399: format-integer(xs:integer?, xs:string, xs:string?) as xs:string
〰400: 
〰401: Formats an integer according to a given picture string, using the conventions of a given natural language if specified.
〰402: 
〰403: format-number
〰404: format-number(xs:numeric?, xs:string) as xs:string
〰405: 
〰406: format-number(xs:numeric?, xs:string, xs:string?) as xs:string
〰407: 
〰408: Returns a string containing a number formatted according to a given picture string, taking account of decimal formats specified in the static context.
〰409: 
〰410: format-time
〰411: format-time(xs:time?, xs:string) as xs:string?
〰412: 
〰413: format-time(xs:time?, xs:string, xs:string?, xs:string?, xs:string?) as xs:string?
〰414: 
〰415: Returns a string containing an xs:time value formatted for display.
〰416: 
〰417: function-arity
〰418: function-arity(function(*)) as xs:integer
〰419: 
〰420: Returns the arity of the function identified by a function item.
〰421: 
〰422: function-lookup
〰423: function-lookup(xs:QName, xs:integer) as function(*)?
〰424: 
〰425: Returns the function having a given name and arity, if there is one.
〰426: 
〰427: function-name
〰428: function-name(function(*)) as xs:QName?
〰429: 
〰430: Returns the name of the function identified by a function item.
〰431: 
〰432: generate-id
〰433: generate-id() as xs:string
〰434: 
〰435: generate-id(node()?) as xs:string
〰436: 
〰437: This function returns a string that uniquely identifies a given node.
〰438: 
〰439: has-children
〰440: has-children() as xs:boolean
〰441: 
〰442: has-children(node()?) as xs:boolean
〰443: 
〰444: Returns true if the supplied node has one or more child nodes (of any kind).
〰445: 
〰446: head
〰447: head(item()*) as item()?
〰448: 
〰449: Returns the first item in a sequence.
〰450: 
〰451: hours-from-dateTime
〰452: hours-from-dateTime(xs:dateTime?) as xs:integer?
〰453: 
〰454: Returns the hours component of an xs:dateTime.
〰455: 
〰456: hours-from-duration
〰457: hours-from-duration(xs:duration?) as xs:integer?
〰458: 
〰459: Returns the number of hours in a duration.
〰460: 
〰461: hours-from-time
〰462: hours-from-time(xs:time?) as xs:integer?
〰463: 
〰464: Returns the hours component of an xs:time.
〰465: 
〰466: id
〰467: id(xs:string*) as element()*
〰468: 
〰469: id(xs:string*, node()) as element()*
〰470: 
〰471: Returns the sequence of element nodes that have an ID value matching the value of one or more of the IDREF values supplied in $arg.
〰472: 
〰473: idref
〰474: idref(xs:string*) as node()*
〰475: 
〰476: idref(xs:string*, node()) as node()*
〰477: 
〰478: Returns the sequence of element or attribute nodes with an IDREF value matching the value of one or more of the ID values supplied in $arg.
〰479: 
〰480: implicit-timezone
〰481: implicit-timezone() as xs:dayTimeDuration
〰482: 
〰483: Returns the value of the implicit timezone property from the dynamic context.
〰484: 
〰485: index-of
〰486: index-of(xs:anyAtomicType*, xs:anyAtomicType) as xs:integer*
〰487: 
〰488: index-of(xs:anyAtomicType*, xs:anyAtomicType, xs:string) as xs:integer*
〰489: 
〰490: Returns a sequence of positive integers giving the positions within the sequence $seq of items that are equal to $search.
〰491: 
〰492: innermost
〰493: innermost(node()*) as node()*
〰494: 
〰495: Returns every node within the input sequence that is not an ancestor of another member of the input sequence; the nodes are returned in document order with duplicates eliminated.
〰496: 
〰497: in-scope-prefixes
〰498: in-scope-prefixes(element()) as xs:string*
〰499: 
〰500: Returns the prefixes of the in-scope namespaces for an element node.
〰501: 
〰502: insert-before
〰503: insert-before(item()*, xs:integer, item()*) as item()*
〰504: 
〰505: Returns a sequence constructed by inserting an item or a sequence of items at a given position within an existing sequence.
〰506: 
〰507: iri-to-uri
〰508: iri-to-uri(xs:string?) as xs:string
〰509: 
〰510: Converts a string containing an IRI into a URI according to the rules of [rfc3987].
〰511: 
〰512: json-doc
〰513: json-doc(xs:string?) as item()?
〰514: 
〰515: json-doc(xs:string?, map(*)) as item()?
〰516: 
〰517: Reads an external resource containing JSON, and returns the result of parsing the resource as JSON.
〰518: 
〰519: json-to-xml
〰520: json-to-xml(xs:string?) as document-node()?
〰521: 
〰522: json-to-xml(xs:string?, map(*)) as document-node()?
〰523: 
〰524: Parses a string supplied in the form of a JSON text, returning the results in the form of an XML document node.
〰525: 
〰526: lang
〰527: lang(xs:string?) as xs:boolean
〰528: 
〰529: lang(xs:string?, node()) as xs:boolean
〰530: 
〰531: This function tests whether the language of $node, or the context item if the second argument is omitted, as specified by xml:lang attributes is the same as, or is a sublanguage of, the language specified by $testlang.
〰532: 
〰533: last
〰534: last() as xs:integer
〰535: 
〰536: Returns the context size from the dynamic context.
〰537: 
〰538: load-xquery-module
〰539: load-xquery-module(xs:string) as map(*)
〰540: 
〰541: load-xquery-module(xs:string, map(*)) as map(*)
〰542: 
〰543: Provides access to the public functions and global variables of a dynamically-loaded XQuery library module.
〰544: 
〰545: local-name
〰546: local-name() as xs:string
〰547: 
〰548: local-name(node()?) as xs:string
〰549: 
〰550: Returns the local part of the name of $arg as an xs:string that is either the zero-length string, or has the lexical form of an xs:NCName.
〰551: 
〰552: local-name-from-QName
〰553: local-name-from-QName(xs:QName?) as xs:NCName?
〰554: 
〰555: Returns the local part of the supplied QName.
〰556: 
〰557: lower-case
〰558: lower-case(xs:string?) as xs:string
〰559: 
〰560: Converts a string to lower case.
〰561: 
〰562: matches
〰563: matches(xs:string?, xs:string) as xs:boolean
〰564: 
〰565: matches(xs:string?, xs:string, xs:string) as xs:boolean
〰566: 
〰567: Returns true if the supplied string matches a given regular expression.
〰568: 
〰569: max
〰570: max(xs:anyAtomicType*) as xs:anyAtomicType?
〰571: 
〰572: max(xs:anyAtomicType*, xs:string) as xs:anyAtomicType?
〰573: 
〰574: Returns a value that is equal to the highest value appearing in the input sequence.
〰575: 
〰576: min
〰577: min(xs:anyAtomicType*) as xs:anyAtomicType?
〰578: 
〰579: min(xs:anyAtomicType*, xs:string) as xs:anyAtomicType?
〰580: 
〰581: Returns a value that is equal to the lowest value appearing in the input sequence.
〰582: 
〰583: minutes-from-dateTime
〰584: minutes-from-dateTime(xs:dateTime?) as xs:integer?
〰585: 
〰586: Returns the minute component of an xs:dateTime.
〰587: 
〰588: minutes-from-duration
〰589: minutes-from-duration(xs:duration?) as xs:integer?
〰590: 
〰591: Returns the number of minutes in a duration.
〰592: 
〰593: minutes-from-time
〰594: minutes-from-time(xs:time?) as xs:integer?
〰595: 
〰596: Returns the minutes component of an xs:time.
〰597: 
〰598: month-from-date
〰599: month-from-date(xs:date?) as xs:integer?
〰600: 
〰601: Returns the month component of an xs:date.
〰602: 
〰603: month-from-dateTime
〰604: month-from-dateTime(xs:dateTime?) as xs:integer?
〰605: 
〰606: Returns the month component of an xs:dateTime.
〰607: 
〰608: months-from-duration
〰609: months-from-duration(xs:duration?) as xs:integer?
〰610: 
〰611: Returns the number of months in a duration.
〰612: 
〰613: name
〰614: name() as xs:string
〰615: 
〰616: name(node()?) as xs:string
〰617: 
〰618: Returns the name of a node, as an xs:string that is either the zero-length string, or has the lexical form of an xs:QName.
〰619: 
〰620: namespace-uri
〰621: namespace-uri() as xs:anyURI
〰622: 
〰623: namespace-uri(node()?) as xs:anyURI
〰624: 
〰625: Returns the namespace URI part of the name of $arg, as an xs:anyURI value.
〰626: 
〰627: namespace-uri-for-prefix
〰628: namespace-uri-for-prefix(xs:string?, element()) as xs:anyURI?
〰629: 
〰630: Returns the namespace URI of one of the in-scope namespaces for $element, identified by its namespace prefix.
〰631: 
〰632: namespace-uri-from-QName
〰633: namespace-uri-from-QName(xs:QName?) as xs:anyURI?
〰634: 
〰635: Returns the namespace URI part of the supplied QName.
〰636: 
〰637: nilled
〰638: nilled() as xs:boolean?
〰639: 
〰640: nilled(node()?) as xs:boolean?
〰641: 
〰642: Returns true for an element that is nilled.
〰643: 
〰644: node-name
〰645: node-name() as xs:QName?
〰646: 
〰647: node-name(node()?) as xs:QName?
〰648: 
〰649: Returns the name of a node, as an xs:QName.
〰650: 
〰651: normalize-space
〰652: normalize-space() as xs:string
〰653: 
〰654: normalize-space(xs:string?) as xs:string
〰655: 
〰656: Returns the value of $arg with leading and trailing whitespace removed, and sequences of internal whitespace reduced to a single space character.
〰657: 
〰658: normalize-unicode
〰659: normalize-unicode(xs:string?) as xs:string
〰660: 
〰661: normalize-unicode(xs:string?, xs:string) as xs:string
〰662: 
〰663: Returns the value of $arg after applying Unicode normalization.
〰664: 
〰665: not
〰666: not(item()*) as xs:boolean
〰667: 
〰668: Returns true if the effective boolean value of $arg is false, or false if it is true.
〰669: 
〰670: number
〰671: number() as xs:double
〰672: 
〰673: number(xs:anyAtomicType?) as xs:double
〰674: 
〰675: Returns the value indicated by $arg or, if $arg is not specified, the context item after atomization, converted to an xs:double.
〰676: 
〰677: one-or-more
〰678: one-or-more(item()*) as item()+
〰679: 
〰680: Returns $arg if it contains one or more items. Otherwise, raises an error.
〰681: 
〰682: outermost
〰683: outermost(node()*) as node()*
〰684: 
〰685: Returns every node within the input sequence that has no ancestor that is itself a member of the input sequence; the nodes are returned in document order with duplicates eliminated.
〰686: 
〰687: parse-ietf-date
〰688: parse-ietf-date(xs:string?) as xs:dateTime?
〰689: 
〰690: Parses a string containing the date and time in IETF format, returning the corresponding xs:dateTime value.
〰691: 
〰692: parse-json
〰693: parse-json(xs:string?) as item()?
〰694: 
〰695: parse-json(xs:string?, map(*)) as item()?
〰696: 
〰697: Parses a string supplied in the form of a JSON text, returning the results typically in the form of a map or array.
〰698: 
〰699: parse-xml
〰700: parse-xml(xs:string?) as document-node(element(*))?
〰701: 
〰702: This function takes as input an XML document represented as a string, and returns the document node at the root of an XDM tree representing the parsed document.
〰703: 
〰704: parse-xml-fragment
〰705: parse-xml-fragment(xs:string?) as document-node()?
〰706: 
〰707: This function takes as input an XML external entity represented as a string, and returns the document node at the root of an XDM tree representing the parsed document fragment.
〰708: 
〰709: path
〰710: path() as xs:string?
〰711: 
〰712: path(node()?) as xs:string?
〰713: 
〰714: Returns a path expression that can be used to select the supplied node relative to the root of its containing document.
〰715: 
〰716: position
〰717: position() as xs:integer
〰718: 
〰719: Returns the context position from the dynamic context.
〰720: 
〰721: prefix-from-QName
〰722: prefix-from-QName(xs:QName?) as xs:NCName?
〰723: 
〰724: Returns the prefix component of the supplied QName.
〰725: 
〰726: QName
〰727: QName(xs:string?, xs:string) as xs:QName
〰728: 
〰729: Returns an xs:QName value formed using a supplied namespace URI and lexical QName.
〰730: 
〰731: random-number-generator
〰732: random-number-generator() as map(xs:string, item())
〰733: 
〰734: random-number-generator(xs:anyAtomicType?) as map(xs:string, item())
〰735: 
〰736: Returns a random number generator, which can be used to generate sequences of random numbers.
〰737: 
〰738: remove
〰739: remove(item()*, xs:integer) as item()*
〰740: 
〰741: Returns a new sequence containing all the items of $target except the item at position $position.
〰742: 
〰743: replace
〰744: replace(xs:string?, xs:string, xs:string) as xs:string
〰745: 
〰746: replace(xs:string?, xs:string, xs:string, xs:string) as xs:string
〰747: 
〰748: Returns a string produced from the input string by replacing any substrings that match a given regular expression with a supplied replacement string.
〰749: 
〰750: resolve-QName
〰751: resolve-QName(xs:string?, element()) as xs:QName?
〰752: 
〰753: Returns an xs:QName value (that is, an expanded-QName) by taking an xs:string that has the lexical form of an xs:QName (a string in the form "prefix:local-name" or "local-name") and resolving it using the in-scope namespaces for a given element.
〰754: 
〰755: resolve-uri
〰756: resolve-uri(xs:string?) as xs:anyURI?
〰757: 
〰758: resolve-uri(xs:string?, xs:string) as xs:anyURI?
〰759: 
〰760: Resolves a relative IRI reference against an absolute IRI.
〰761: 
〰762: reverse
〰763: reverse(item()*) as item()*
〰764: 
〰765: Reverses the order of items in a sequence.
〰766: 
〰767: root
〰768: root() as node()
〰769: 
〰770: root(node()?) as node()?
〰771: 
〰772: Returns the root of the tree to which $arg belongs. This will usually, but not necessarily, be a document node.
〰773: 
〰774: round
〰775: round(xs:numeric?) as xs:numeric?
〰776: 
〰777: round(xs:numeric?, xs:integer) as xs:numeric?
〰778: 
〰779: Rounds a value to a specified number of decimal places, rounding upwards if two such values are equally near.
〰780: 
〰781: round-half-to-even
〰782: round-half-to-even(xs:numeric?) as xs:numeric?
〰783: 
〰784: round-half-to-even(xs:numeric?, xs:integer) as xs:numeric?
〰785: 
〰786: Rounds a value to a specified number of decimal places, rounding to make the last digit even if two such values are equally near.
〰787: 
〰788: seconds-from-dateTime
〰789: seconds-from-dateTime(xs:dateTime?) as xs:decimal?
〰790: 
〰791: Returns the seconds component of an xs:dateTime.
〰792: 
〰793: seconds-from-duration
〰794: seconds-from-duration(xs:duration?) as xs:decimal?
〰795: 
〰796: Returns the number of seconds in a duration.
〰797: 
〰798: seconds-from-time
〰799: seconds-from-time(xs:time?) as xs:decimal?
〰800: 
〰801: Returns the seconds component of an xs:time.
〰802: 
〰803: serialize
〰804: serialize(item()*) as xs:string
〰805: 
〰806: serialize(item()*, item()?) as xs:string
〰807: 
〰808: This function serializes the supplied input sequence $arg as described in [xslt-xquery-serialization-31], returning the serialized representation of the sequence as a string.
〰809: 
〰810: sort
〰811: sort(item()*) as item()*
〰812: 
〰813: sort(item()*, xs:string?) as item()*
〰814: 
〰815: sort(item()*, xs:string?, function(item()) as xs:anyAtomicType*) as item()*
〰816: 
〰817: Sorts a supplied sequence, based on the value of a sort key supplied as a function.
〰818: 
〰819: starts-with
〰820: starts-with(xs:string?, xs:string?) as xs:boolean
〰821: 
〰822: starts-with(xs:string?, xs:string?, xs:string) as xs:boolean
〰823: 
〰824: Returns true if the string $arg1 contains $arg2 as a leading substring, taking collations into account.
〰825: 
〰826: static-base-uri
〰827: static-base-uri() as xs:anyURI?
〰828: 
〰829: This function returns the value of the static base URI property from the static context.
〰830: 
〰831: string
〰832: string() as xs:string
〰833: 
〰834: string(item()?) as xs:string
〰835: 
〰836: Returns the value of $arg represented as an xs:string.
〰837: 
〰838: string-join
〰839: string-join(xs:anyAtomicType*) as xs:string
〰840: 
〰841: string-join(xs:anyAtomicType*, xs:string) as xs:string
〰842: 
〰843: Returns a string created by concatenating the items in a sequence, with a defined separator between adjacent items.
〰844: 
〰845: string-length
〰846: string-length() as xs:integer
〰847: 
〰848: string-length(xs:string?) as xs:integer
〰849: 
〰850: Returns the number of characters in a string.
〰851: 
〰852: string-to-codepoints
〰853: string-to-codepoints(xs:string?) as xs:integer*
〰854: 
〰855: Returns the sequence of codepoints that constitute an xs:string value.
〰856: 
〰857: subsequence
〰858: subsequence(item()*, xs:double) as item()*
〰859: 
〰860: subsequence(item()*, xs:double, xs:double) as item()*
〰861: 
〰862: Returns the contiguous sequence of items in the value of $sourceSeq beginning at the position indicated by the value of $startingLoc and continuing for the number of items indicated by the value of $length.
〰863: 
〰864: substring
〰865: substring(xs:string?, xs:double) as xs:string
〰866: 
〰867: substring(xs:string?, xs:double, xs:double) as xs:string
〰868: 
〰869: Returns the portion of the value of $sourceString beginning at the position indicated by the value of $start and continuing for the number of characters indicated by the value of $length.
〰870: 
〰871: substring-after
〰872: substring-after(xs:string?, xs:string?) as xs:string
〰873: 
〰874: substring-after(xs:string?, xs:string?, xs:string) as xs:string
〰875: 
〰876: Returns the part of $arg1 that follows the first occurrence of $arg2, taking collations into account.
〰877: 
〰878: substring-before
〰879: substring-before(xs:string?, xs:string?) as xs:string
〰880: 
〰881: substring-before(xs:string?, xs:string?, xs:string) as xs:string
〰882: 
〰883: Returns the part of $arg1 that precedes the first occurrence of $arg2, taking collations into account.
〰884: 
〰885: sum
〰886: sum(xs:anyAtomicType*) as xs:anyAtomicType
〰887: 
〰888: sum(xs:anyAtomicType*, xs:anyAtomicType?) as xs:anyAtomicType?
〰889: 
〰890: Returns a value obtained by adding together the values in $arg.
〰891: 
〰892: tail
〰893: tail(item()*) as item()*
〰894: 
〰895: Returns all but the first item in a sequence.
〰896: 
〰897: timezone-from-date
〰898: timezone-from-date(xs:date?) as xs:dayTimeDuration?
〰899: 
〰900: Returns the timezone component of an xs:date.
〰901: 
〰902: timezone-from-dateTime
〰903: timezone-from-dateTime(xs:dateTime?) as xs:dayTimeDuration?
〰904: 
〰905: Returns the timezone component of an xs:dateTime.
〰906: 
〰907: timezone-from-time
〰908: timezone-from-time(xs:time?) as xs:dayTimeDuration?
〰909: 
〰910: Returns the timezone component of an xs:time.
〰911: 
〰912: tokenize
〰913: tokenize(xs:string?) as xs:string*
〰914: 
〰915: tokenize(xs:string?, xs:string) as xs:string*
〰916: 
〰917: tokenize(xs:string?, xs:string, xs:string) as xs:string*
〰918: 
〰919: Returns a sequence of strings constructed by splitting the input wherever a separator is found; the separator is any substring that matches a given regular expression.
〰920: 
〰921: trace
〰922: trace(item()*) as item()*
〰923: 
〰924: trace(item()*, xs:string) as item()*
〰925: 
〰926: Provides an execution trace intended to be used in debugging queries.
〰927: 
〰928: transform
〰929: transform(map(*)) as map(*)
〰930: 
〰931: Invokes a transformation using a dynamically-loaded XSLT stylesheet.
〰932: 
〰933: translate
〰934: translate(xs:string?, xs:string, xs:string) as xs:string
〰935: 
〰936: Returns the value of $arg modified by replacing or removing individual characters.
〰937: 
〰938: true
〰939: true() as xs:boolean
〰940: 
〰941: Returns the xs:boolean value true.
〰942: 
〰943: unordered
〰944: unordered(item()*) as item()*
〰945: 
〰946: Returns the items of $sourceSeq in an implementation-dependent order.
〰947: 
〰948: unparsed-text
〰949: unparsed-text(xs:string?) as xs:string?
〰950: 
〰951: unparsed-text(xs:string?, xs:string) as xs:string?
〰952: 
〰953: The fn:unparsed-text function reads an external resource (for example, a file) and returns a string representation of the resource.
〰954: 
〰955: unparsed-text-available
〰956: unparsed-text-available(xs:string?) as xs:boolean
〰957: 
〰958: unparsed-text-available(xs:string?, xs:string) as xs:boolean
〰959: 
〰960: Because errors in evaluating the fn:unparsed-text function are non-recoverable, these two functions are provided to allow an application to determine whether a call with particular arguments would succeed.
〰961: 
〰962: unparsed-text-lines
〰963: unparsed-text-lines(xs:string?) as xs:string*
〰964: 
〰965: unparsed-text-lines(xs:string?, xs:string) as xs:string*
〰966: 
〰967: The fn:unparsed-text-lines function reads an external resource (for example, a file) and returns its contents as a sequence of strings, one for each line of text in the string representation of the resource.
〰968: 
〰969: upper-case
〰970: upper-case(xs:string?) as xs:string
〰971: 
〰972: Converts a string to upper case.
〰973: 
〰974: uri-collection
〰975: uri-collection() as xs:anyURI*
〰976: 
〰977: uri-collection(xs:string?) as xs:anyURI*
〰978: 
〰979: Returns a sequence of xs:anyURI values representing the URIs in a URI collection.
〰980: 
〰981: xml-to-json
〰982: xml-to-json(node()?) as xs:string?
〰983: 
〰984: xml-to-json(node()?, map(*)) as xs:string?
〰985: 
〰986: Converts an XML tree, whose format corresponds to the XML representation of JSON defined in this specification, into a string conforming to the JSON grammar.
〰987: 
〰988: year-from-date
〰989: year-from-date(xs:date?) as xs:integer?
〰990: 
〰991: Returns the year component of an xs:date.
〰992: 
〰993: year-from-dateTime
〰994: year-from-dateTime(xs:dateTime?) as xs:integer?
〰995: 
〰996: Returns the year component of an xs:dateTime.
〰997: 
〰998: years-from-duration
〰999: years-from-duration(xs:duration?) as xs:integer?
〰1000:
〰1001:Returns the number of years in a duration.
〰1002:
〰1003:zero-or-one
〰1004:zero-or-one(item()*) as item()?
〰1005:
〰1006:Returns $arg if it contains zero or one items. Otherwise, raises an error.
〰1007:
〰1008:3 XSL Transformations (XSLT) Functions
〰1009:This section lists all of the functions in this namespace that are defined in the [XSLT 3.0] specification.
〰1010:
〰1011:The normative definitions of these functions are in the [XSLT 3.0] specification. For convenience, a very brief, non-normative summary of each function is provided. For details, follow the link on the “Summary:” introductory text below each function.
〰1012:
〰1013:Note that XSLT 3.0, because it is not dependent on XPath 3.1, also reproduces some of the functions specifications that appear in XPath 3.1. For an XSLT 3.0 processor that works with XPath 3.0, the normative specification in this case is the one that appears in the XSLT 3.0 specification.
〰1014:
〰1015:accumulator-after
〰1016:accumulator-after(xs:string) as item()*
〰1017:
〰1018:Returns the post-descent value of the selected accumulator at the context node.
〰1019:
〰1020:accumulator-before
〰1021:accumulator-before(xs:string) as item()*
〰1022:
〰1023:Returns the pre-descent value of the selected accumulator at the context node.
〰1024:
〰1025:available-system-properties
〰1026:available-system-properties() as xs:QName*
〰1027:
〰1028:Returns a list of system property names that are suitable for passing to the system-property function, as a sequence of QNames.
〰1029:
〰1030:collation-key
〰1031:collation-key(xs:string) as xs:base64Binary
〰1032:
〰1033:collation-key(xs:string, xs:string) as xs:base64Binary
〰1034:
〰1035:Given a string value and a collation, generates an internal value called a collation key, with the property that the matching and ordering of collation keys reflects the matching and ordering of strings under the specified collation.
〰1036:
〰1037:copy-of
〰1038:copy-of() as item()
〰1039:
〰1040:copy-of(item()*) as item()*
〰1041:
〰1042:Returns a deep copy of the sequence supplied as the $input argument, or of the context item if the argument is absent.
〰1043:
〰1044:current
〰1045:current() as item()
〰1046:
〰1047:Returns the item that is the context item for the evaluation of the containing XPath expression
〰1048:
〰1049:current-group
〰1050:current-group() as item()*
〰1051:
〰1052:Returns the group currently being processed by an xsl:for-each-group instruction.
〰1053:
〰1054:current-grouping-key
〰1055:current-grouping-key() as xs:anyAtomicType*
〰1056:
〰1057:Returns the grouping key of the group currently being processed using the xsl:for-each-group instruction.
〰1058:
〰1059:current-merge-group
〰1060:current-merge-group() as item()*
〰1061:
〰1062:current-merge-group(xs:string) as item()*
〰1063:
〰1064:Returns the group of items currently being processed by an xsl:merge instruction.
〰1065:
〰1066:current-merge-key
〰1067:current-merge-key() as xs:anyAtomicType*
〰1068:
〰1069:Returns the merge key of the merge group currently being processed using the xsl:merge instruction.
〰1070:
〰1071:current-output-uri
〰1072:current-output-uri() as xs:anyURI?
〰1073:
〰1074:Returns the value of the .
〰1075:
〰1076:deep-equal
〰1077:deep-equal(item()*, item()*) as xs:boolean
〰1078:
〰1079:deep-equal(item()*, item()*, xs:string) as xs:boolean
〰1080:
〰1081:This function assesses whether two sequences are deep-equal to each other. The function as described here extends the definition of the XPath 3.0 deep-equal to explain how it should handle maps; it is intended to replace the existing deep-equal function at some stage in the future.
〰1082:
〰1083:document
〰1084:document(item()*) as node()*
〰1085:
〰1086:document(item()*, node()) as node()*
〰1087:
〰1088:Provides access to XML documents identified by a URI.
〰1089:
〰1090:element-available
〰1091:element-available(xs:string) as xs:boolean
〰1092:
〰1093:Determines whether a particular instruction is or is not available for use. The function is particularly useful for calling within an [xsl:]use-when attribute (see ) to test whether a particular is available.
〰1094:
〰1095:function-available
〰1096:function-available(xs:string) as xs:boolean
〰1097:
〰1098:function-available(xs:string, xs:integer) as xs:boolean
〰1099:
〰1100:Determines whether a particular function is or is not available for use. The function is particularly useful for calling within an [xsl:]use-when attribute (see ) to test whether a particular is available.
〰1101:
〰1102:json-to-xml
〰1103:json-to-xml(xs:string) as document-node()
〰1104:
〰1105:json-to-xml(xs:string, map(*)) as document-node()
〰1106:
〰1107:Parses a string supplied in the form of a JSON text, returning the results in the form of an XML document node.
〰1108:
〰1109:key
〰1110:key(xs:string, xs:anyAtomicType*) as node()*
〰1111:
〰1112:key(xs:string, xs:anyAtomicType*, node()) as node()*
〰1113:
〰1114:Returns the nodes that match a supplied key value.
〰1115:
〰1116:regex-group
〰1117:regex-group(xs:integer) as xs:string
〰1118:
〰1119:Returns the string captured by a parenthesized subexpression of the regular expression used during evaluation of the xsl:analyze-string instruction.
〰1120:
〰1121:snapshot
〰1122:snapshot() as item()
〰1123:
〰1124:snapshot(item()*) as item()*
〰1125:
〰1126:Returns a copy of a sequence, retaining copies of the ancestors and descendants of any node in the input sequence, together with their attributes and namespaces.
〰1127:
〰1128:stream-available
〰1129:stream-available(xs:string?) as xs:boolean
〰1130:
〰1131:Determines, as far as possible, whether a document is available for streamed processing using xsl:source-document.
〰1132:
〰1133:system-property
〰1134:system-property(xs:string) as xs:string
〰1135:
〰1136:Returns the value of a system property
〰1137:
〰1138:type-available
〰1139:type-available(xs:string) as xs:boolean
〰1140:
〰1141:Used to control how a stylesheet behaves if a particular schema type is or is not available in the static context.
〰1142:
〰1143:unparsed-entity-public-id
〰1144:unparsed-entity-public-id(xs:string) as xs:string
〰1145:
〰1146:unparsed-entity-public-id(xs:string, node()) as xs:string
〰1147:
〰1148:Returns the public identifier of an unparsed entity
〰1149:
〰1150:unparsed-entity-uri
〰1151:unparsed-entity-uri(xs:string) as xs:anyURI
〰1152:
〰1153:unparsed-entity-uri(xs:string, node()) as xs:anyURI
〰1154:
〰1155:Returns the URI (system identifier) of an unparsed entity
〰1156:
〰1157:xml-to-json
〰1158:xml-to-json(node()?) as xs:string?
〰1159:
〰1160:xml-to-json(node()?, map(*)) as xs:string?
〰1161:
〰1162:Converts an XML tree, whose format corresponds to the XML representation of JSON defined in this specification, into a string conforming to the JSON grammar.
〰1163:
〰1164:4 XQuery Update Functions
〰1165:This section lists all of the functions in this namespace that are defined in the [XQuery Update 1.0] specification.
〰1166:
〰1167:The normative definitions of these functions are in the [XQuery Update 1.0] specification. For convenience, a very brief, non-normative summary of each function is provided. For details, follow the link on the “Summary:” introductory text below each function.
〰1168:
〰1169:put
〰1170:put(node(), xs:string) as empty-sequence()
〰1171:
〰1172:Stores a document or element to the location specified by $uri. This function is normally invoked to create a resource on an external storage system such as a file system or a database.
〰1173:
〰1174:The external effects of fn:put are implementation-defined, since they occur outside the domain of XQuery. The intent is that, if fn:put is invoked on a document node and no error is raised, a subsequent query can access the stored document by invoking fn:doc with the same URI.
〰1175:
〰1176:5 XML Schema
〰1177:Two functions, fn:analyze-string and fn:json-to-xml, return results that are always valid according to a defined XSD schema. A third function, fn:xml-to-json, requires input that is valid according to this schema.
〰1178:
〰1179:The target namespace of these schema components is http://www.w3.org/2005/xpath-functions.
〰1180:
〰1181:The schema components are defined in a schema document located at https://www.w3.org/TR/xpath-functions-31/xpath-functions.xsd.
〰1182:
〰1183:6 Normative References
〰1184:These documents describe the names that are defined in this namespace at the time of publication. The W3C reserves the right to define additional names in this namespace in the future.
〰1185:
〰1186:XPath and XQuery Functions and Operators 3.1
〰1187:XQuery and XPath Functions and Operators 3.1 (21 March 2017 version)
〰1188:
〰1189:XSLT 3.0
〰1190:XSL Transformations (XSLT) Version 3.0 (7 February 2017 version)
〰1191:
〰1192:XQuery Update 1.0
〰1193:XQuery Update Facility 1.0 (25 January 2011 version)
〰1194:
〰1195:7 Non-Normative References
〰1196:Resource Directory Description Language (RDDL)
〰1197:Resource Directory Description Language (RDDL) (4 July 2007)
〰1198:
〰1199:Gleaning Resource Descriptions from Dialects of Languages (GRDDL)
〰1200:Gleaning Resource Descriptions from Dialects of Languages (GRDDL) (Recommendation of 11 September 2007)
〰1201:
〰1202:Resource Description Framework (RDF): Concepts and Abstract Syntax
〰1203:Resource Description Framework (RDF): Concepts and Abstract Syntax (Recommendation of 10 February 2004)
〰1204:        */
〰1205:    }
〰1206:}
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

