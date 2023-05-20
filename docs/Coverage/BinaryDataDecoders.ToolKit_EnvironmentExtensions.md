# BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.EnvironmentExtensions

## Summary

| Key             | Value                                                                 |
| :-------------- | :-------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.EnvironmentExtensions` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                          |
| Coveredlines    | `0`                                                                   |
| Uncoveredlines  | `8`                                                                   |
| Coverablelines  | `8`                                                                   |
| Totallines      | `47`                                                                  |
| Linecoverage    | `0`                                                                   |
| Coveredbranches | `0`                                                                   |
| Totalbranches   | `2`                                                                   |
| Branchcoverage  | `0`                                                                   |
| Coveredmethods  | `0`                                                                   |
| Totalmethods    | `3`                                                                   |
| Methodcoverage  | `0`                                                                   |

## Metrics

| Complexity | Lines | Branches | Name        |
| :--------- | :---- | :------- | :---------- |
| 1          | 0     | 100      | `ctor`      |
| 2          | 0     | 0        | `GetValue`  |
| 1          | 0     | 100      | `GetValues` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/Xsl/Extensions/EnvironmentExtensions.cs

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
〰20:          public EnvironmentExtensions()
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
〰31:          public string GetValue(string variableName) =>
‼32:              Environment.GetEnvironmentVariable(variableName) ?? "";
〰33:  
〰34:          /// <summary>
〰35:          /// Retrieves all environment variable names and their values from the current process.
〰36:          /// </summary>
〰37:          /// <returns>XML element with an attribute for each current environment variable</returns>
〰38:          public XPathNavigator? GetValues()
〰39:          {
‼40:              var xml = new XElement(_ns + "variables",
‼41:                   from k in Environment.GetEnvironmentVariables().Keys.Cast<string>()
‼42:                   select new XAttribute(XmlConvert.EncodeLocalName(k), GetValue(k))
‼43:                   );
‼44:              return xml.ToXPathNavigable().CreateNavigator();
〰45:          }
〰46:      }
〰47:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

