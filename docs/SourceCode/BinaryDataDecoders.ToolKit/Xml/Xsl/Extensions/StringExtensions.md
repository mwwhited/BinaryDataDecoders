# StringExtensions.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.ToolKit\Xml\Xsl\Extensions\StringExtensions.cs

## Public Class - StringExtensions

### Comments

 <summary>
 A wrapper around string functions intended for use with XslCompiledTransform
 </summary>

### Attributes

 - XmlRoot
 - (
 - Namespace
 - =
 - XmlNamespaces
 - .
 - Base
 - +
 - nameof
 - (
 - StringExtensions
 - )
 - )

### Members

#### Private ReadOnly Field - _ns

##### Summary

 * Type: XNamespace 

#### Public Constructor - StringExtensions

##### Comments

 <summary>
 Create instance of StringExtensions
 </summary>


#### Public Method - TrimPerLine

##### Comments

 <summary>
 remove leading and trailing whitespace for multiline strings 
 </summary>
 <paramname="input">iput multiline string</param>
 <returns>cleaned multiline string</returns>

#####  Parameters

 - string input 

#### Public Method - PadLeft

#####  Parameters

 - string input 
 - int totalWidth 

#### Public Method - PadRight

#####  Parameters

 - string input 
 - int totalWidth 

#### Public Method - New

#####  Parameters

 - string @char 
 - int length 

