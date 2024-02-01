# BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.EnvironmentExtensions

## Summary

| Key             | Value                                                                 |
| :-------------- | :-------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions.EnvironmentExtensions` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                          |
| Coveredlines    | `0`                                                                   |
| Uncoveredlines  | `16`                                                                  |
| Coverablelines  | `16`                                                                  |
| Totallines      | `89`                                                                  |
| Linecoverage    | `0`                                                                   |
| Coveredbranches | `0`                                                                   |
| Totalbranches   | `4`                                                                   |
| Branchcoverage  | `0`                                                                   |
| Coveredmethods  | `0`                                                                   |
| Totalmethods    | `6`                                                                   |
| Methodcoverage  | `0`                                                                   |

## Metrics

| Complexity | Lines | Branches | Name        |
| :--------- | :---- | :------- | :---------- |
| 1          | 0     | 100      | `ctor`      |
| 2          | 0     | 0        | `GetValue`  |
| 1          | 0     | 100      | `GetValues` |
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
〰9:   namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions;
〰10:  
〰11:  /// <summary>
〰12:  /// This is a wrapper around <c>System.Environment</c> intended for use with XslCompiledTransform
〰13:  /// </summary>
〰14:  [XmlRoot(Namespace = XmlNamespaces.Base + nameof(EnvironmentExtensions))]
〰15:  public class EnvironmentExtensions
〰16:  {
〰17:      private readonly XNamespace _ns;
〰18:  
〰19:      public EnvironmentExtensions()
〰20:      {
‼21:          _ns = this.GetXmlNamespace() + XmlNamespaces.OutputSuffix;
‼22:      }
〰23:  
〰24:      /// <summary>
〰25:      /// Retrieves the value of an environment variable from the current process.
〰26:      /// </summary>
〰27:      /// <param name="variableName">The name of the environment variable.</param>
〰28:      /// <returns>The value of the environment variable specified by variable, or null if the environment variable is not found.</returns>
〰29:      public string GetValue(string variableName) =>
‼30:          Environment.GetEnvironmentVariable(variableName) ?? "";
〰31:  
〰32:      /// <summary>
〰33:      /// Retrieves all environment variable names and their values from the current process.
〰34:      /// </summary>
〰35:      /// <returns>XML element with an attribute for each current environment variable</returns>
〰36:      public XPathNavigator? GetValues()
〰37:      {
‼38:          var xml = new XElement(_ns + "variables",
‼39:               from k in Environment.GetEnvironmentVariables().Keys.Cast<string>()
‼40:               select new XAttribute(XmlConvert.EncodeLocalName(k), GetValue(k))
‼41:               );
‼42:          return xml.ToXPathNavigable().CreateNavigator();
〰43:      }
〰44:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/Xml/Xsl/Extensions/EnvironmentExtensions.cs

```CSharp
〰1:   using System;
〰2:   using System.Linq;
〰3:   using System.Xml;
〰4:   using System.Xml.Linq;
〰5:   using System.Xml.Serialization;
〰6:   using System.Xml.XPath;
〰7:   using static BinaryDataDecoders.ToolKit.ToolkitConstants;
〰8:   
〰9:   namespace BinaryDataDecoders.ToolKit.Xml.Xsl.Extensions;
〰10:  
〰11:  /// <summary>
〰12:  /// This is a wrapper around <c>System.Environment</c> intended for use with XslCompiledTransform
〰13:  /// </summary>
〰14:  [XmlRoot(Namespace = XmlNamespaces.Base + nameof(EnvironmentExtensions))]
〰15:  public class EnvironmentExtensions
〰16:  {
〰17:      private readonly XNamespace _ns;
〰18:  
〰19:      public EnvironmentExtensions()
〰20:      {
‼21:          _ns = this.GetXmlNamespace() + XmlNamespaces.OutputSuffix;
‼22:      }
〰23:  
〰24:      /// <summary>
〰25:      /// Retrieves the value of an environment variable from the current process.
〰26:      /// </summary>
〰27:      /// <param name="variableName">The name of the environment variable.</param>
〰28:      /// <returns>The value of the environment variable specified by variable, or null if the environment variable is not found.</returns>
〰29:      public string GetValue(string variableName) =>
‼30:          Environment.GetEnvironmentVariable(variableName) ?? "";
〰31:  
〰32:      /// <summary>
〰33:      /// Retrieves all environment variable names and their values from the current process.
〰34:      /// </summary>
〰35:      /// <returns>XML element with an attribute for each current environment variable</returns>
〰36:      public XPathNavigator? GetValues()
〰37:      {
‼38:          var xml = new XElement(_ns + "variables",
‼39:               from k in Environment.GetEnvironmentVariables().Keys.Cast<string>()
‼40:               select new XAttribute(XmlConvert.EncodeLocalName(k), GetValue(k))
‼41:               );
‼42:          return xml.ToXPathNavigable().CreateNavigator();
〰43:      }
〰44:  }
〰45:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

