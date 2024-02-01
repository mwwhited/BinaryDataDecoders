# BinaryDataDecoders.ToolKit.Xml.Schema.XmlSchemaValidatorEx

## Summary

| Key             | Value                                                        |
| :-------------- | :----------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Schema.XmlSchemaValidatorEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                 |
| Coveredlines    | `0`                                                          |
| Uncoveredlines  | `154`                                                        |
| Coverablelines  | `154`                                                        |
| Totallines      | `287`                                                        |
| Linecoverage    | `0`                                                          |
| Coveredbranches | `0`                                                          |
| Totalbranches   | `72`                                                         |
| Branchcoverage  | `0`                                                          |
| Coveredmethods  | `0`                                                          |
| Totalmethods    | `26`                                                         |
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
| 6          | 0     | 0        | `ctor`        |
| 6          | 0     | 0        | `ctor`        |
| 2          | 0     | 0        | `IsValid`     |
| 2          | 0     | 0        | `GetErrors`   |
| 2          | 0     | 0        | `GetWarnings` |
| 1          | 0     | 100      | `GetResults`  |
| 1          | 0     | 100      | `ctor`        |
| 2          | 0     | 0        | `ctor`        |
| 2          | 0     | 0        | `ctor`        |
| 2          | 0     | 0        | `ctor`        |
| 4          | 0     | 0        | `ctor`        |
| 4          | 0     | 0        | `ctor`        |
| 4          | 0     | 0        | `ctor`        |
| 6          | 0     | 0        | `ctor`        |
| 6          | 0     | 0        | `ctor`        |
| 2          | 0     | 0        | `IsValid`     |
| 2          | 0     | 0        | `GetErrors`   |
| 2          | 0     | 0        | `GetWarnings` |
| 1          | 0     | 100      | `GetResults`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/Schema/XmlSchemaValidatorEx.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.Linq;
〰3:   using System.Reflection.Metadata;
〰4:   using System.Xml;
〰5:   using System.Xml.Linq;
〰6:   using System.Xml.Schema;
〰7:   
〰8:   namespace BinaryDataDecoders.ToolKit.Xml.Schema;
〰9:   
〰10:  public class XmlSchemaValidatorEx
〰11:  {
〰12:      public XmlSchemaSet XmlSchemaSet { get; private set; }
〰13:  
〰14:      public XmlSchemaValidatorEx()
〰15:      {
‼16:          this.XmlSchemaSet = new XmlSchemaSet();
‼17:      }
〰18:  
〰19:      public XmlSchemaValidatorEx(string targetNamespace, string xsdUri)
‼20:          : this()
〰21:      {
‼22:          this.XmlSchemaSet.Add(targetNamespace ?? "", xsdUri);
‼23:      }
〰24:      public XmlSchemaValidatorEx(string targetNamespace, XmlReader xmlreader)
‼25:          : this()
〰26:      {
‼27:          this.XmlSchemaSet.Add(targetNamespace ?? "", xmlreader);
‼28:      }
〰29:      public XmlSchemaValidatorEx(string targetNamespace, XNode xsd)
‼30:          : this(targetNamespace ?? "", xsd.CreateReader())
〰31:      {
‼32:      }
〰33:      public XmlSchemaValidatorEx(IEnumerable<KeyValuePair<string, string>> xsdUris)
‼34:          : this()
〰35:      {
‼36:          foreach (var xsdUri in xsdUris.Where(v => v.Value != null))
〰37:          {
‼38:              this.XmlSchemaSet.Add(xsdUri.Key ?? "", xsdUri.Value);
〰39:          }
‼40:      }
〰41:      public XmlSchemaValidatorEx(IEnumerable<KeyValuePair<string, XmlReader>> xsdReaders)
‼42:          : this()
〰43:      {
‼44:          foreach (var xsdUri in xsdReaders.Where(v => v.Value != null))
〰45:          {
‼46:              this.XmlSchemaSet.Add(xsdUri.Key ?? "", xsdUri.Value);
〰47:          }
‼48:      }
〰49:      public XmlSchemaValidatorEx(IEnumerable<KeyValuePair<string, XNode>> xsds)
‼50:          : this()
〰51:      {
‼52:          foreach (var xsdUri in xsds.Where(v => v.Value != null))
〰53:          {
‼54:              this.XmlSchemaSet.Add(xsdUri.Key ?? "", xsdUri.Value.CreateReader());
〰55:          }
‼56:      }
〰57:  
〰58:      public XmlSchemaValidatorEx(IEnumerable<string> xsdUris)
‼59:          : this()
〰60:      {
‼61:          foreach (var xsdUri in xsdUris)
〰62:          {
‼63:              var xDocument = XDocument.Load(xsdUri);
‼64:              var xsdNs = (XNamespace)"http://www.w3.org/2001/XMLSchema";
〰65:  
‼66:              var targetNamespace = xDocument.Element(xsdNs + "schema").Attribute("targetNamespace") switch
‼67:              {
‼68:                  null => null,
‼69:                  XAttribute attribute => (string)attribute
‼70:              };
〰71:  
‼72:              if (targetNamespace != null)
‼73:                  this.XmlSchemaSet.Add(targetNamespace, xsdUri);
〰74:          }
‼75:      }
〰76:      public XmlSchemaValidatorEx(IEnumerable<XContainer> xsdContainers)
‼77:          : this()
〰78:      {
‼79:          foreach (var xsdContainer in xsdContainers)
〰80:          {
‼81:              var xsdNs = (XNamespace)"http://www.w3.org/2001/XMLSchema";
〰82:  
‼83:              var targetNamespace = xsdContainer.Element(xsdNs + "schema").Attribute("targetNamespace") switch
‼84:              {
‼85:                  null => null,
‼86:                  XAttribute attribute => (string)attribute
‼87:              };
〰88:  
‼89:              if (targetNamespace != null)
‼90:                  this.XmlSchemaSet.Add(targetNamespace, xsdContainer.CreateReader());
〰91:          }
‼92:      }
〰93:  
〰94:      public bool IsValid(XDocument xDocument)
〰95:      {
‼96:          var result = true;
‼97:          xDocument.Validate(this.XmlSchemaSet, (sender, e) =>
‼98:          {
‼99:              if (e.Severity == XmlSeverityType.Error)
‼100:                 result = false;
‼101:         }, false);
〰102: 
‼103:         return result;
〰104:     }
〰105: 
〰106:     public IEnumerable<string> GetErrors(XDocument xDocument)
〰107:     {
‼108:         var result = new List<string>();
‼109:         xDocument.Validate(this.XmlSchemaSet, (sender, e) =>
‼110:         {
‼111:             if (e.Severity == XmlSeverityType.Error)
‼112:                 result.Add(e.Message);
‼113:         }, false);
〰114: 
‼115:         return result.AsReadOnly();
〰116:     }
〰117:     public IEnumerable<string> GetWarnings(XDocument xDocument)
〰118:     {
‼119:         var result = new List<string>();
‼120:         xDocument.Validate(this.XmlSchemaSet, (sender, e) =>
‼121:         {
‼122:             if (e.Severity == XmlSeverityType.Warning)
‼123:                 result.Add(e.Message);
‼124:         }, false);
〰125: 
‼126:         return result.AsReadOnly();
〰127:     }
〰128:     public IEnumerable<XmlValidationResult> GetResults(XDocument xDocument)
〰129:     {
‼130:         var result = new List<XmlValidationResult>();
‼131:         xDocument.Validate(this.XmlSchemaSet, (sender, e) =>
‼132:         {
‼133:             result.Add(new XmlValidationResult
‼134:             {
‼135:                 Exception = e.Exception,
‼136:                 Message = e.Message,
‼137:                 Severity = e.Severity,
‼138:             });
‼139:         }, false);
〰140: 
‼141:         return result.AsReadOnly();
〰142:     }
〰143: }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/Xml/Schema/XmlSchemaValidatorEx.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.Linq;
〰3:   using System.Reflection.Metadata;
〰4:   using System.Xml;
〰5:   using System.Xml.Linq;
〰6:   using System.Xml.Schema;
〰7:   
〰8:   namespace BinaryDataDecoders.ToolKit.Xml.Schema;
〰9:   
〰10:  public class XmlSchemaValidatorEx
〰11:  {
〰12:      public XmlSchemaSet XmlSchemaSet { get; private set; }
〰13:  
〰14:      public XmlSchemaValidatorEx()
〰15:      {
‼16:          this.XmlSchemaSet = new XmlSchemaSet();
‼17:      }
〰18:  
〰19:      public XmlSchemaValidatorEx(string targetNamespace, string xsdUri)
‼20:          : this()
〰21:      {
‼22:          this.XmlSchemaSet.Add(targetNamespace ?? "", xsdUri);
‼23:      }
〰24:      public XmlSchemaValidatorEx(string targetNamespace, XmlReader xmlreader)
‼25:          : this()
〰26:      {
‼27:          this.XmlSchemaSet.Add(targetNamespace ?? "", xmlreader);
‼28:      }
〰29:      public XmlSchemaValidatorEx(string targetNamespace, XNode xsd)
‼30:          : this(targetNamespace ?? "", xsd.CreateReader())
〰31:      {
‼32:      }
〰33:      public XmlSchemaValidatorEx(IEnumerable<KeyValuePair<string, string>> xsdUris)
‼34:          : this()
〰35:      {
‼36:          foreach (var xsdUri in xsdUris.Where(v => v.Value != null))
〰37:          {
‼38:              this.XmlSchemaSet.Add(xsdUri.Key ?? "", xsdUri.Value);
〰39:          }
‼40:      }
〰41:      public XmlSchemaValidatorEx(IEnumerable<KeyValuePair<string, XmlReader>> xsdReaders)
‼42:          : this()
〰43:      {
‼44:          foreach (var xsdUri in xsdReaders.Where(v => v.Value != null))
〰45:          {
‼46:              this.XmlSchemaSet.Add(xsdUri.Key ?? "", xsdUri.Value);
〰47:          }
‼48:      }
〰49:      public XmlSchemaValidatorEx(IEnumerable<KeyValuePair<string, XNode>> xsds)
‼50:          : this()
〰51:      {
‼52:          foreach (var xsdUri in xsds.Where(v => v.Value != null))
〰53:          {
‼54:              this.XmlSchemaSet.Add(xsdUri.Key ?? "", xsdUri.Value.CreateReader());
〰55:          }
‼56:      }
〰57:  
〰58:      public XmlSchemaValidatorEx(IEnumerable<string> xsdUris)
‼59:          : this()
〰60:      {
‼61:          foreach (var xsdUri in xsdUris)
〰62:          {
‼63:              var xDocument = XDocument.Load(xsdUri);
‼64:              var xsdNs = (XNamespace)"http://www.w3.org/2001/XMLSchema";
〰65:  
‼66:              var targetNamespace = xDocument.Element(xsdNs + "schema").Attribute("targetNamespace") switch
‼67:              {
‼68:                  null => null,
‼69:                  XAttribute attribute => (string)attribute
‼70:              };
〰71:  
‼72:              if (targetNamespace != null)
‼73:                  this.XmlSchemaSet.Add(targetNamespace, xsdUri);
〰74:          }
‼75:      }
〰76:      public XmlSchemaValidatorEx(IEnumerable<XContainer> xsdContainers)
‼77:          : this()
〰78:      {
‼79:          foreach (var xsdContainer in xsdContainers)
〰80:          {
‼81:              var xsdNs = (XNamespace)"http://www.w3.org/2001/XMLSchema";
〰82:  
‼83:              var targetNamespace = xsdContainer.Element(xsdNs + "schema").Attribute("targetNamespace") switch
‼84:              {
‼85:                  null => null,
‼86:                  XAttribute attribute => (string)attribute
‼87:              };
〰88:  
‼89:              if (targetNamespace != null)
‼90:                  this.XmlSchemaSet.Add(targetNamespace, xsdContainer.CreateReader());
〰91:          }
‼92:      }
〰93:  
〰94:      public bool IsValid(XDocument xDocument)
〰95:      {
‼96:          var result = true;
‼97:          xDocument.Validate(this.XmlSchemaSet, (sender, e) =>
‼98:          {
‼99:              if (e.Severity == XmlSeverityType.Error)
‼100:                 result = false;
‼101:         }, false);
〰102: 
‼103:         return result;
〰104:     }
〰105: 
〰106:     public IEnumerable<string> GetErrors(XDocument xDocument)
〰107:     {
‼108:         var result = new List<string>();
‼109:         xDocument.Validate(this.XmlSchemaSet, (sender, e) =>
‼110:         {
‼111:             if (e.Severity == XmlSeverityType.Error)
‼112:                 result.Add(e.Message);
‼113:         }, false);
〰114: 
‼115:         return result.AsReadOnly();
〰116:     }
〰117:     public IEnumerable<string> GetWarnings(XDocument xDocument)
〰118:     {
‼119:         var result = new List<string>();
‼120:         xDocument.Validate(this.XmlSchemaSet, (sender, e) =>
‼121:         {
‼122:             if (e.Severity == XmlSeverityType.Warning)
‼123:                 result.Add(e.Message);
‼124:         }, false);
〰125: 
‼126:         return result.AsReadOnly();
〰127:     }
〰128:     public IEnumerable<XmlValidationResult> GetResults(XDocument xDocument)
〰129:     {
‼130:         var result = new List<XmlValidationResult>();
‼131:         xDocument.Validate(this.XmlSchemaSet, (sender, e) =>
‼132:         {
‼133:             result.Add(new XmlValidationResult
‼134:             {
‼135:                 Exception = e.Exception,
‼136:                 Message = e.Message,
‼137:                 Severity = e.Severity,
‼138:             });
‼139:         }, false);
〰140: 
‼141:         return result.AsReadOnly();
〰142:     }
〰143: }
〰144: 
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

