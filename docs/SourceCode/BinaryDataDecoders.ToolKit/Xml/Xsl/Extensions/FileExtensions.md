# FileExtensions.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.ToolKit/Xml/Xsl/Extensions/FileExtensions.cs

## Public Class - FileExtensions

### Comments

 <summary>
 Sandboxable wrapper around File IO functions intended for use with XslCompiledTransform
 </summary>
 <remarks>
 </remarks>
 <paramname="sandbox">base path for sandboxing these functions</param>

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
 - FileExtensions
 - )
 - )

### Members

#### Public Method - WriteToFile

##### Comments

 <summary>
 
 </summary>
 <paramname="source">input XPathNavigator to output</param>
 <paramname="filePath">file path to write</param>
 <returns>source</returns>

#####  Parameters

 - XPathNavigator source 
 - string filePath 

#### Public Method - ReadXml

##### Comments

 <summary>
 XPathNavigator for XML content of given filePath
 </summary>
 <paramname="filePath">file path to read</param>
 <returns>xml content of provided file</returns>

#####  Parameters

 - string filePath 

