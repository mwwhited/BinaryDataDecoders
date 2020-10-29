
# BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.EnvironmentExtensions
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_EnvironmentExtensions.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.EnvironmentExt | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 9                                                            | 
| Coverablelines       | 9                                                            | 
| Totallines           | 46                                                           | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 2                                                            | 
| Branchcoverage       | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\Xsl\Extensions\EnvironmentExtensions.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 0     | 100      | ctor | 
| 2          | 0     | 0        | GetValue | 
| 1          | 0     | 100      | GetValues | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\Xsl\Extensions\EnvironmentExtensions.cs

```CSharp
〰1:   using System;
〰2:   using System.Linq;
〰3:   using System.Xml;
〰4:   using System.Xml.Linq;
〰5:   using System.Xml.Serialization;
〰6:   using System.Xml.XPath;
〰7:   using static BinaryDataDecoders.ToolKit.ToolkitConstants;
〰8:   
〰9:   namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions
〰10:  {
〰11:      /// <summary>
〰12:      /// This is a wrapper around <c>System.Environment</c> intended for use with XslCompiledTransform
〰13:      /// </summary>
〰14:      [XmlRoot(Namespace = XmlNamespaces.Base + nameof(EnvironmentExtensions))]
〰15:      public class EnvironmentExtensions
〰16:      {
〰17:          private readonly XNamespace _ns;
〰18:  
〰19:  #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
‼20:          public EnvironmentExtensions()
〰21:  #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
〰22:          {
‼23:              _ns = this.GetXmlNamespace() + XmlNamespaces.OutputSuffix;
‼24:          }
〰25:  
〰26:          /// <summary>
〰27:          /// Retrieves the value of an environment variable from the current process.
〰28:          /// </summary>
〰29:          /// <param name="variableName">The name of the environment variable.</param>
〰30:          /// <returns>The value of the environment variable specified by variable, or null if the environment variable is not found.</returns>
‼31:          public string GetValue(string variableName) => Environment.GetEnvironmentVariable(variableName) ?? "";
〰32:  
〰33:          /// <summary>
〰34:          /// Retrieves all environment variable names and their values from the current process.
〰35:          /// </summary>
〰36:          /// <returns>XML element with an attribute for each current environment variable</returns>
〰37:          public XPathNavigator GetValues()
〰38:          {
‼39:              var xml = new XElement(_ns + "variables",
‼40:                   from k in Environment.GetEnvironmentVariables().Keys.Cast<string>()
‼41:                   select new XAttribute(XmlConvert.EncodeLocalName(k), GetValue(k))
‼42:                   );
‼43:              return xml.ToXPathNavigable().CreateNavigator();
〰44:          }
〰45:      }
〰46:  }

```
## Footer 
[Return to Summary](Summary.md)

