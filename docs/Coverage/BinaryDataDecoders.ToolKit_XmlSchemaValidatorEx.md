# BinaryDataDecoders.ToolKit.Xml.Schema.XmlSchemaValidatorEx

## Summary

| Key             | Value                                                        |
| :-------------- | :----------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Schema.XmlSchemaValidatorEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                 |
| Coveredlines    | `0`                                                          |
| Uncoveredlines  | `67`                                                         |
| Coverablelines  | `67`                                                         |
| Totallines      | `133`                                                        |
| Linecoverage    | `0`                                                          |
| Coveredbranches | `0`                                                          |
| Totalbranches   | `28`                                                         |
| Branchcoverage  | `0`                                                          |
| Coveredmethods  | `0`                                                          |
| Totalmethods    | `13`                                                         |
| Methodcoverage  | `0`                                                          |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `ctor`        |
| 2          | 0     | 0        | `ctor`        |
| 2          | 0     | 0        | `ctor`        |
| 2          | 0     | 0        | `ctor`        |
| 4          | 0     | 0        | `ctor`        |
| 4          | 0     | 0        | `ctor`        |
| 4          | 0     | 0        | `ctor`        |
| 2          | 0     | 0        | `ctor`        |
| 2          | 0     | 0        | `ctor`        |
| 2          | 0     | 0        | `IsValid`     |
| 2          | 0     | 0        | `GetErrors`   |
| 2          | 0     | 0        | `GetWarnings` |
| 1          | 0     | 100      | `GetResults`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/Schema/XmlSchemaValidatorEx.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.Linq;
〰3:   using System.Xml;
〰4:   using System.Xml.Linq;
〰5:   using System.Xml.Schema;
〰6:   
〰7:   namespace BinaryDataDecoders.ToolKit.Xml.Schema
〰8:   {
〰9:       public class XmlSchemaValidatorEx
〰10:      {
〰11:          public XmlSchemaSet XmlSchemaSet { get; private set; }
〰12:  
〰13:          public XmlSchemaValidatorEx()
〰14:          {
‼15:              this.XmlSchemaSet = new XmlSchemaSet();
‼16:          }
〰17:  
〰18:          public XmlSchemaValidatorEx(string targetNamespace, string xsdUri)
‼19:              : this()
〰20:          {
‼21:              this.XmlSchemaSet.Add(targetNamespace ?? "", xsdUri);
‼22:          }
〰23:          public XmlSchemaValidatorEx(string targetNamespace, XmlReader xmlreader)
‼24:              : this()
〰25:          {
‼26:              this.XmlSchemaSet.Add(targetNamespace ?? "", xmlreader);
‼27:          }
〰28:          public XmlSchemaValidatorEx(string targetNamespace, XNode xsd)
‼29:              : this(targetNamespace ?? "", xsd.CreateReader())
〰30:          {
‼31:          }
〰32:          public XmlSchemaValidatorEx(IEnumerable<KeyValuePair<string, string>> xsdUris)
‼33:              : this()
〰34:          {
‼35:              foreach (var xsdUri in xsdUris.Where(v => v.Value != null))
〰36:              {
‼37:                  this.XmlSchemaSet.Add(xsdUri.Key ?? "", xsdUri.Value);
〰38:              }
‼39:          }
〰40:          public XmlSchemaValidatorEx(IEnumerable<KeyValuePair<string, XmlReader>> xsdReaders)
‼41:              : this()
〰42:          {
‼43:              foreach (var xsdUri in xsdReaders.Where(v => v.Value != null))
〰44:              {
‼45:                  this.XmlSchemaSet.Add(xsdUri.Key ?? "", xsdUri.Value);
〰46:              }
‼47:          }
〰48:          public XmlSchemaValidatorEx(IEnumerable<KeyValuePair<string, XNode>> xsds)
‼49:              : this()
〰50:          {
‼51:              foreach (var xsdUri in xsds.Where(v => v.Value != null))
〰52:              {
‼53:                  this.XmlSchemaSet.Add(xsdUri.Key ?? "", xsdUri.Value.CreateReader());
〰54:              }
‼55:          }
〰56:  
〰57:          public XmlSchemaValidatorEx(IEnumerable<string> xsdUris)
‼58:              : this()
〰59:          {
‼60:              foreach (var xsdUri in xsdUris)
〰61:              {
‼62:                  var xDocument = XDocument.Load(xsdUri);
‼63:                  var xsdNs = (XNamespace)"http://www.w3.org/2001/XMLSchema";
〰64:  
‼65:                  var targetNamespace = (string)(xDocument.Element(xsdNs + "schema").Attribute("targetNamespace"));
〰66:  
‼67:                  this.XmlSchemaSet.Add(targetNamespace, xsdUri);
〰68:              }
‼69:          }
〰70:          public XmlSchemaValidatorEx(IEnumerable<XContainer> xsdContainers)
‼71:              : this()
〰72:          {
‼73:              foreach (var xsdContainer in xsdContainers)
〰74:              {
‼75:                  var xsdNs = (XNamespace)"http://www.w3.org/2001/XMLSchema";
〰76:  
‼77:                  var targetNamespace = (string)(xsdContainer.Element(xsdNs + "schema").Attribute("targetNamespace"));
〰78:  
‼79:                  this.XmlSchemaSet.Add(targetNamespace, xsdContainer.CreateReader());
〰80:              }
‼81:          }
〰82:  
〰83:          public bool IsValid(XDocument xDocument)
〰84:          {
‼85:              var result = true;
‼86:              xDocument.Validate(this.XmlSchemaSet, (sender, e) =>
‼87:              {
‼88:                  if (e.Severity == XmlSeverityType.Error)
‼89:                      result = false;
‼90:              }, false);
〰91:  
‼92:              return result;
〰93:          }
〰94:  
〰95:          public IEnumerable<string> GetErrors(XDocument xDocument)
〰96:          {
‼97:              var result = new List<string>();
‼98:              xDocument.Validate(this.XmlSchemaSet, (sender, e) =>
‼99:              {
‼100:                 if (e.Severity == XmlSeverityType.Error)
‼101:                     result.Add(e.Message);
‼102:             }, false);
〰103: 
‼104:             return result.AsReadOnly();
〰105:         }
〰106:         public IEnumerable<string> GetWarnings(XDocument xDocument)
〰107:         {
‼108:             var result = new List<string>();
‼109:             xDocument.Validate(this.XmlSchemaSet, (sender, e) =>
‼110:             {
‼111:                 if (e.Severity == XmlSeverityType.Warning)
‼112:                     result.Add(e.Message);
‼113:             }, false);
〰114: 
‼115:             return result.AsReadOnly();
〰116:         }
〰117:         public IEnumerable<XmlValidationResult> GetResults(XDocument xDocument)
〰118:         {
‼119:             var result = new List<XmlValidationResult>();
‼120:             xDocument.Validate(this.XmlSchemaSet, (sender, e) =>
‼121:             {
‼122:                 result.Add(new XmlValidationResult
‼123:                 {
‼124:                     Exception = e.Exception,
‼125:                     Message = e.Message,
‼126:                     Severity = e.Severity,
‼127:                 });
‼128:             }, false);
〰129: 
‼130:             return result.AsReadOnly();
〰131:         }
〰132:     }
〰133: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

