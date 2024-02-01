# BinaryDataDecoders.ToolKit.Xml.Linq.XFragment

## Summary

| Key             | Value                                           |
| :-------------- | :---------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Linq.XFragment` |
| Assembly        | `BinaryDataDecoders.ToolKit`                    |
| Coveredlines    | `42`                                            |
| Uncoveredlines  | `84`                                            |
| Coverablelines  | `126`                                           |
| Totallines      | `267`                                           |
| Linecoverage    | `33.3`                                          |
| Coveredbranches | `14`                                            |
| Totalbranches   | `40`                                            |
| Branchcoverage  | `35`                                            |
| Coveredmethods  | `14`                                            |
| Totalmethods    | `56`                                            |
| Methodcoverage  | `25`                                            |

## Metrics

| Complexity | Lines | Branches | Name                                        |
| :--------- | :---- | :------- | :------------------------------------------ |
| 4          | 0     | 0        | `ctor`                                      |
| 2          | 0     | 0        | `ctor`                                      |
| 1          | 0     | 100      | `ctor`                                      |
| 1          | 0     | 100      | `ctor`                                      |
| 4          | 0     | 0        | `Parser`                                    |
| 4          | 0     | 0        | `Parser`                                    |
| 1          | 0     | 100      | `ToString`                                  |
| 1          | 0     | 100      | `CreateReader`                              |
| 1          | 0     | 100      | `Parse`                                     |
| 1          | 0     | 100      | `Parse`                                     |
| 2          | 0     | 0        | `GetEnumerator`                             |
| 1          | 0     | 100      | `SystemCollectionsIEnumerableGetEnumerator` |
| 1          | 0     | 100      | `get_Count`                                 |
| 1          | 0     | 100      | `get_IsReadOnly`                            |
| 1          | 0     | 100      | `get_Item`                                  |
| 1          | 0     | 100      | `set_Item`                                  |
| 1          | 0     | 100      | `IndexOf`                                   |
| 1          | 0     | 100      | `Insert`                                    |
| 1          | 0     | 100      | `RemoveAt`                                  |
| 1          | 0     | 100      | `Add`                                       |
| 1          | 0     | 100      | `Clear`                                     |
| 1          | 0     | 100      | `Contains`                                  |
| 1          | 0     | 100      | `CopyTo`                                    |
| 1          | 0     | 100      | `Remove`                                    |
| 1          | 0     | 100      | `op_Implicit`                               |
| 4          | 0     | 0        | `op_Implicit`                               |
| 1          | 0     | 100      | `op_Implicit`                               |
| 1          | 0     | 100      | `op_Implicit`                               |
| 4          | 100   | 75.00    | `ctor`                                      |
| 2          | 100   | 50.0     | `ctor`                                      |
| 1          | 100   | 100      | `ctor`                                      |
| 1          | 0     | 100      | `ctor`                                      |
| 4          | 91.66 | 75.00    | `Parser`                                    |
| 4          | 83.33 | 75.00    | `Parser`                                    |
| 1          | 100   | 100      | `ToString`                                  |
| 1          | 0     | 100      | `CreateReader`                              |
| 1          | 100   | 100      | `Parse`                                     |
| 1          | 0     | 100      | `Parse`                                     |
| 2          | 100   | 50.0     | `GetEnumerator`                             |
| 1          | 0     | 100      | `SystemCollectionsIEnumerableGetEnumerator` |
| 1          | 100   | 100      | `get_Count`                                 |
| 1          | 0     | 100      | `get_IsReadOnly`                            |
| 1          | 100   | 100      | `get_Item`                                  |
| 1          | 0     | 100      | `set_Item`                                  |
| 1          | 0     | 100      | `IndexOf`                                   |
| 1          | 0     | 100      | `Insert`                                    |
| 1          | 0     | 100      | `RemoveAt`                                  |
| 1          | 0     | 100      | `Add`                                       |
| 1          | 0     | 100      | `Clear`                                     |
| 1          | 0     | 100      | `Contains`                                  |
| 1          | 0     | 100      | `CopyTo`                                    |
| 1          | 0     | 100      | `Remove`                                    |
| 1          | 100   | 100      | `op_Implicit`                               |
| 4          | 91.66 | 75.00    | `op_Implicit`                               |
| 1          | 100   | 100      | `op_Implicit`                               |
| 1          | 100   | 100      | `op_Implicit`                               |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/Linq/XFragment.cs

```CSharp
〰1:   using System.Collections;
〰2:   using System.Collections.Generic;
〰3:   using System.IO;
〰4:   using System.Linq;
〰5:   using System.Text;
〰6:   using System.Xml;
〰7:   using System.Xml.Linq;
〰8:   
〰9:   namespace BinaryDataDecoders.ToolKit.Xml.Linq;
〰10:  
〰11:  
〰12:  public class XFragment : IList<XNode>
〰13:  {
〰14:      // https://github.com/OutOfBandDevelopment/Samples/blob/master/HandyClasses/XFragment.cs
〰15:      private IList<XNode> Nodes { get; } = new List<XNode>();
〰16:  
〰17:      public XFragment(IEnumerable<XNode> nodes)
〰18:      {
‼19:          foreach (var node in (nodes ?? Enumerable.Empty<XNode>()).Where(n => n != null))
‼20:              this.Nodes.Add(node);
‼21:      }
〰22:  
〰23:      public XFragment(XNode node, params XNode[] nodes)
‼24:          : this(new[] { node }.Concat(nodes ?? Enumerable.Empty<XNode>()))
〰25:      {
‼26:      }
〰27:  
〰28:      public XFragment(string? xml)
‼29:          : this(Parser(xml).ToArray())
〰30:      {
‼31:      }
〰32:      public XFragment(XmlReader xmlReader)
‼33:          : this(Parser(xmlReader).ToArray())
〰34:      {
‼35:      }
〰36:  
〰37:      private static IEnumerable<XNode> Parser(string? xml)
〰38:      {
‼39:          if (string.IsNullOrWhiteSpace(xml))
‼40:              yield break;
〰41:  
‼42:          var settings = new XmlReaderSettings
‼43:          {
‼44:              ConformanceLevel = ConformanceLevel.Fragment,
‼45:              IgnoreWhitespace = true
‼46:          };
〰47:  
‼48:          using var stringReader = new StringReader(xml);
‼49:          using var xmlReader = XmlReader.Create(stringReader, settings);
‼50:          foreach (var node in XFragment.Parser(xmlReader))
‼51:              yield return node;
‼52:      }
〰53:  
〰54:      private static IEnumerable<XNode> Parser(XmlReader xmlReader)
〰55:      {
‼56:          if (xmlReader == null)
‼57:              yield break;
〰58:  
‼59:          xmlReader.MoveToContent();
‼60:          while (xmlReader.ReadState != ReadState.EndOfFile)
‼61:              yield return XNode.ReadFrom(xmlReader);
‼62:      }
〰63:  
‼64:      public override string? ToString() => this;
〰65:  
‼66:      public XmlReader CreateReader() => XmlReader.Create(new StringReader(this), new XmlReaderSettings
‼67:      {
‼68:          ConformanceLevel = ConformanceLevel.Fragment,
‼69:      });
〰70:  
‼71:      public static XFragment Parse(string xml) => new(xml);
‼72:      public static XFragment Parse(XmlReader xmlReader) => new(xmlReader);
〰73:  
〰74:      #region IEnumerable
〰75:  
‼76:      public IEnumerator<XNode> GetEnumerator() => (Nodes ?? Enumerable.Empty<XNode>()).Where(n => n != null).GetEnumerator();
‼77:      IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
〰78:  
〰79:      #endregion
〰80:  
〰81:      #region IList
〰82:  
‼83:      public int Count => Nodes.Count;
‼84:      public bool IsReadOnly => Nodes.IsReadOnly;
〰85:      public XNode this[int index]
〰86:      {
‼87:          get => Nodes[index];
‼88:          set => Nodes[index] = value;
〰89:      }
〰90:  
‼91:      public int IndexOf(XNode item) => Nodes.IndexOf(item);
‼92:      public void Insert(int index, XNode item) => Nodes.Insert(index, item);
‼93:      public void RemoveAt(int index) => Nodes.RemoveAt(index);
‼94:      public void Add(XNode item) => Nodes.Add(item);
‼95:      public void Clear() => Nodes.Clear();
‼96:      public bool Contains(XNode item) => Nodes.Contains(item);
‼97:      public void CopyTo(XNode[] array, int arrayIndex) => Nodes.CopyTo(array, arrayIndex);
‼98:      public bool Remove(XNode item) => Nodes.Remove(item);
〰99:  
〰100:     #endregion
〰101: 
〰102:     #region Conversions
〰103: 
‼104:     public static implicit operator XFragment(string? xml) => new(xml);
〰105: 
〰106:     public static implicit operator string?(XFragment fragment)
〰107:     {
‼108:         if (fragment == null)
‼109:             return null;
〰110: 
‼111:         var settings = new XmlWriterSettings
‼112:         {
‼113:             OmitXmlDeclaration = true,
‼114:             ConformanceLevel = ConformanceLevel.Fragment,
‼115:         };
‼116:         var sb = new StringBuilder();
‼117:         using (var xmlwriter = XmlWriter.Create(sb, settings))
〰118:         {
‼119:             foreach (var node in fragment)
〰120:             {
‼121:                 xmlwriter.WriteNode(node.CreateReader(), false);
〰122:             }
〰123:         }
〰124: 
‼125:         return sb.ToString();
〰126:     }
〰127: 
‼128:     public static implicit operator XFragment(XNode[] nodes) => new(nodes);
〰129: 
‼130:     public static implicit operator XFragment(XNode node) => new(node);
〰131: 
〰132:     #endregion
〰133: }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/Xml/Linq/XFragment.cs

```CSharp
〰1:   using System.Collections;
〰2:   using System.Collections.Generic;
〰3:   using System.IO;
〰4:   using System.Linq;
〰5:   using System.Text;
〰6:   using System.Xml;
〰7:   using System.Xml.Linq;
〰8:   
〰9:   namespace BinaryDataDecoders.ToolKit.Xml.Linq;
〰10:  
〰11:  
〰12:  public class XFragment : IList<XNode>
〰13:  {
〰14:      // https://github.com/OutOfBandDevelopment/Samples/blob/master/HandyClasses/XFragment.cs
〰15:      private IList<XNode> Nodes { get; } = new List<XNode>();
〰16:  
〰17:      public XFragment(IEnumerable<XNode> nodes)
〰18:      {
⚠19:          foreach (var node in (nodes ?? Enumerable.Empty<XNode>()).Where(n => n != null))
✔20:              this.Nodes.Add(node);
✔21:      }
〰22:  
〰23:      public XFragment(XNode node, params XNode[] nodes)
⚠24:          : this(new[] { node }.Concat(nodes ?? Enumerable.Empty<XNode>()))
〰25:      {
✔26:      }
〰27:  
〰28:      public XFragment(string? xml)
✔29:          : this(Parser(xml).ToArray())
〰30:      {
✔31:      }
〰32:      public XFragment(XmlReader xmlReader)
‼33:          : this(Parser(xmlReader).ToArray())
〰34:      {
‼35:      }
〰36:  
〰37:      private static IEnumerable<XNode> Parser(string? xml)
〰38:      {
⚠39:          if (string.IsNullOrWhiteSpace(xml))
‼40:              yield break;
〰41:  
✔42:          var settings = new XmlReaderSettings
✔43:          {
✔44:              ConformanceLevel = ConformanceLevel.Fragment,
✔45:              IgnoreWhitespace = true
✔46:          };
〰47:  
✔48:          using var stringReader = new StringReader(xml);
✔49:          using var xmlReader = XmlReader.Create(stringReader, settings);
✔50:          foreach (var node in XFragment.Parser(xmlReader))
✔51:              yield return node;
✔52:      }
〰53:  
〰54:      private static IEnumerable<XNode> Parser(XmlReader xmlReader)
〰55:      {
⚠56:          if (xmlReader == null)
‼57:              yield break;
〰58:  
✔59:          xmlReader.MoveToContent();
✔60:          while (xmlReader.ReadState != ReadState.EndOfFile)
✔61:              yield return XNode.ReadFrom(xmlReader);
✔62:      }
〰63:  
✔64:      public override string? ToString() => this;
〰65:  
‼66:      public XmlReader CreateReader() => XmlReader.Create(new StringReader(this), new XmlReaderSettings
‼67:      {
‼68:          ConformanceLevel = ConformanceLevel.Fragment,
‼69:      });
〰70:  
✔71:      public static XFragment Parse(string xml) => new(xml);
‼72:      public static XFragment Parse(XmlReader xmlReader) => new(xmlReader);
〰73:  
〰74:      #region IEnumerable
〰75:  
⚠76:      public IEnumerator<XNode> GetEnumerator() => (Nodes ?? Enumerable.Empty<XNode>()).Where(n => n != null).GetEnumerator();
‼77:      IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
〰78:  
〰79:      #endregion
〰80:  
〰81:      #region IList
〰82:  
✔83:      public int Count => Nodes.Count;
‼84:      public bool IsReadOnly => Nodes.IsReadOnly;
〰85:      public XNode this[int index]
〰86:      {
✔87:          get => Nodes[index];
‼88:          set => Nodes[index] = value;
〰89:      }
〰90:  
‼91:      public int IndexOf(XNode item) => Nodes.IndexOf(item);
‼92:      public void Insert(int index, XNode item) => Nodes.Insert(index, item);
‼93:      public void RemoveAt(int index) => Nodes.RemoveAt(index);
‼94:      public void Add(XNode item) => Nodes.Add(item);
‼95:      public void Clear() => Nodes.Clear();
‼96:      public bool Contains(XNode item) => Nodes.Contains(item);
‼97:      public void CopyTo(XNode[] array, int arrayIndex) => Nodes.CopyTo(array, arrayIndex);
‼98:      public bool Remove(XNode item) => Nodes.Remove(item);
〰99:  
〰100:     #endregion
〰101: 
〰102:     #region Conversions
〰103: 
✔104:     public static implicit operator XFragment(string? xml) => new(xml);
〰105: 
〰106:     public static implicit operator string?(XFragment fragment)
〰107:     {
⚠108:         if (fragment == null)
‼109:             return null;
〰110: 
✔111:         var settings = new XmlWriterSettings
✔112:         {
✔113:             OmitXmlDeclaration = true,
✔114:             ConformanceLevel = ConformanceLevel.Fragment,
✔115:         };
✔116:         var sb = new StringBuilder();
✔117:         using (var xmlwriter = XmlWriter.Create(sb, settings))
〰118:         {
✔119:             foreach (var node in fragment)
〰120:             {
✔121:                 xmlwriter.WriteNode(node.CreateReader(), false);
〰122:             }
〰123:         }
〰124: 
✔125:         return sb.ToString();
〰126:     }
〰127: 
✔128:     public static implicit operator XFragment(XNode[] nodes) => new(nodes);
〰129: 
✔130:     public static implicit operator XFragment(XNode node) => new(node);
〰131: 
〰132:     #endregion
〰133: }
〰134: 
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

