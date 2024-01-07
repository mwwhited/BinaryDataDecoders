# BinaryDataDecoders.ToolKit.Xml.Linq.XFragment

## Summary

| Key             | Value                                           |
| :-------------- | :---------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Linq.XFragment` |
| Assembly        | `BinaryDataDecoders.ToolKit`                    |
| Coveredlines    | `43`                                            |
| Uncoveredlines  | `21`                                            |
| Coverablelines  | `64`                                            |
| Totallines      | `136`                                           |
| Linecoverage    | `67.1`                                          |
| Coveredbranches | `14`                                            |
| Totalbranches   | `20`                                            |
| Branchcoverage  | `70`                                            |
| Coveredmethods  | `14`                                            |
| Totalmethods    | `28`                                            |
| Methodcoverage  | `50`                                            |

## Metrics

| Complexity | Lines | Branches | Name                                        |
| :--------- | :---- | :------- | :------------------------------------------ |
| 4          | 100   | 75.00    | `ctor`                                      |
| 2          | 100   | 50.0     | `ctor`                                      |
| 1          | 100   | 100      | `ctor`                                      |
| 1          | 0     | 100      | `ctor`                                      |
| 4          | 92.30 | 75.00    | `Parser`                                    |
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
〰9:   namespace BinaryDataDecoders.ToolKit.Xml.Linq
〰10:  {
〰11:  
〰12:      public class XFragment : IList<XNode>
〰13:      {
〰14:          // https://github.com/OutOfBandDevelopment/Samples/blob/master/HandyClasses/XFragment.cs
〰15:          private IList<XNode> Nodes { get; } = new List<XNode>();
〰16:  
〰17:          public XFragment(IEnumerable<XNode> nodes)
〰18:          {
⚠19:              foreach (var node in (nodes ?? Enumerable.Empty<XNode>()).Where(n => n != null))
✔20:                  this.Nodes.Add(node);
✔21:          }
〰22:  
〰23:          public XFragment(XNode node, params XNode[] nodes)
⚠24:              : this(new[] { node }.Concat(nodes ?? Enumerable.Empty<XNode>()))
〰25:          {
✔26:          }
〰27:  
〰28:          public XFragment(string? xml)
✔29:              : this(Parser(xml).ToArray())
〰30:          {
✔31:          }
〰32:          public XFragment(XmlReader xmlReader)
‼33:              : this(Parser(xmlReader).ToArray())
〰34:          {
‼35:          }
〰36:  
〰37:          private static IEnumerable<XNode> Parser(string? xml)
〰38:          {
⚠39:              if (string.IsNullOrWhiteSpace(xml))
‼40:                  yield break;
〰41:  
✔42:              var settings = new XmlReaderSettings
✔43:              {
✔44:                  ConformanceLevel = ConformanceLevel.Fragment,
✔45:                  IgnoreWhitespace = true
✔46:              };
〰47:  
✔48:              using (var stringReader = new StringReader(xml))
✔49:              using (var xmlReader = XmlReader.Create(stringReader, settings))
〰50:              {
✔51:                  foreach (var node in XFragment.Parser(xmlReader))
✔52:                      yield return node;
✔53:              }
✔54:          }
〰55:  
〰56:          private static IEnumerable<XNode> Parser(XmlReader xmlReader)
〰57:          {
⚠58:              if (xmlReader == null)
‼59:                  yield break;
〰60:  
✔61:              xmlReader.MoveToContent();
✔62:              while (xmlReader.ReadState != ReadState.EndOfFile)
✔63:                  yield return XNode.ReadFrom(xmlReader);
✔64:          }
〰65:  
✔66:          public override string? ToString() => this;
〰67:  
‼68:          public XmlReader CreateReader() => XmlReader.Create(new StringReader(this), new XmlReaderSettings
‼69:          {
‼70:              ConformanceLevel = ConformanceLevel.Fragment,
‼71:          });
〰72:  
✔73:          public static XFragment Parse(string xml) => new(xml);
‼74:          public static XFragment Parse(XmlReader xmlReader) => new(xmlReader);
〰75:  
〰76:          #region IEnumerable
〰77:  
⚠78:          public IEnumerator<XNode> GetEnumerator() => (Nodes ?? Enumerable.Empty<XNode>()).Where(n => n != null).GetEnumerator();
‼79:          IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
〰80:  
〰81:          #endregion
〰82:  
〰83:          #region IList
〰84:  
✔85:          public int Count => Nodes.Count;
‼86:          public bool IsReadOnly => Nodes.IsReadOnly;
〰87:          public XNode this[int index]
〰88:          {
✔89:              get => Nodes[index];
‼90:              set => Nodes[index] = value;
〰91:          }
〰92:  
‼93:          public int IndexOf(XNode item) => Nodes.IndexOf(item);
‼94:          public void Insert(int index, XNode item) => Nodes.Insert(index, item);
‼95:          public void RemoveAt(int index) => Nodes.RemoveAt(index);
‼96:          public void Add(XNode item) => Nodes.Add(item);
‼97:          public void Clear() => Nodes.Clear();
‼98:          public bool Contains(XNode item) => Nodes.Contains(item);
‼99:          public void CopyTo(XNode[] array, int arrayIndex) => Nodes.CopyTo(array, arrayIndex);
‼100:         public bool Remove(XNode item) => Nodes.Remove(item);
〰101: 
〰102:         #endregion
〰103: 
〰104:         #region Conversions
〰105: 
✔106:         public static implicit operator XFragment(string? xml) => new XFragment(xml);
〰107: 
〰108:         public static implicit operator string?(XFragment fragment)
〰109:         {
⚠110:             if (fragment == null)
‼111:                 return null;
〰112: 
✔113:             var settings = new XmlWriterSettings
✔114:             {
✔115:                 OmitXmlDeclaration = true,
✔116:                 ConformanceLevel = ConformanceLevel.Fragment,
✔117:             };
✔118:             var sb = new StringBuilder();
✔119:             using (var xmlwriter = XmlWriter.Create(sb, settings))
〰120:             {
✔121:                 foreach (var node in fragment)
〰122:                 {
✔123:                     xmlwriter.WriteNode(node.CreateReader(), false);
〰124:                 }
〰125:             }
〰126: 
✔127:             return sb.ToString();
〰128:         }
〰129: 
✔130:         public static implicit operator XFragment(XNode[] nodes) => new XFragment(nodes);
〰131: 
✔132:         public static implicit operator XFragment(XNode node) => new XFragment(node);
〰133: 
〰134:         #endregion
〰135:     }
〰136: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

