# BinaryDataDecoders.ToolKit.Xml.Linq.XFragment

## Summary

| Key             | Value                                           |
| :-------------- | :---------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Linq.XFragment` |
| Assembly        | `BinaryDataDecoders.ToolKit`                    |
| Coveredlines    | `43`                                            |
| Uncoveredlines  | `22`                                            |
| Coverablelines  | `65`                                            |
| Totallines      | `133`                                           |
| Linecoverage    | `66.1`                                          |
| Coveredbranches | `14`                                            |
| Totalbranches   | `20`                                            |
| Branchcoverage  | `70`                                            |

## Metrics

| Complexity | Lines | Branches | Name                                        |
| :--------- | :---- | :------- | :------------------------------------------ |
| 1          | 100   | 100      | `get_Nodes`                                 |
| 4          | 75.00 | 75.00    | `ctor`                                      |
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
〰9:   namespace BinaryDataDecoders.ToolKit.Xml.Linq
〰10:  {
〰11:  
〰12:      public class XFragment : IList<XNode>
〰13:      {
✔14:          private IList<XNode> Nodes { get; } = new List<XNode>();
〰15:  
✔16:          public XFragment(IEnumerable<XNode> nodes)
〰17:          {
‼18:              foreach (var node in nodes ?? Enumerable.Empty<XNode>().Where(n => n != null))
✔19:                  this.Nodes.Add(node);
✔20:          }
〰21:  
〰22:          public XFragment(XNode node, params XNode[] nodes)
⚠23:              : this(new[] { node }.Concat(nodes ?? Enumerable.Empty<XNode>()))
〰24:          {
✔25:          }
〰26:  
〰27:          public XFragment(string xml)
✔28:              : this(XFragment.Parser(xml).ToArray())
〰29:          {
✔30:          }
〰31:          public XFragment(XmlReader xmlReader)
‼32:              : this(XFragment.Parser(xmlReader).ToArray())
〰33:          {
‼34:          }
〰35:  
〰36:          private static IEnumerable<XNode> Parser(string xml)
〰37:          {
⚠38:              if (string.IsNullOrWhiteSpace(xml))
‼39:                  yield break;
〰40:  
✔41:              var settings = new XmlReaderSettings
✔42:              {
✔43:                  ConformanceLevel = ConformanceLevel.Fragment,
✔44:                  IgnoreWhitespace = true
✔45:              };
〰46:  
✔47:              using (var stringReader = new StringReader(xml))
✔48:              using (var xmlReader = XmlReader.Create(stringReader, settings))
✔49:                  foreach (var node in Parser(xmlReader))
✔50:                      yield return node;
✔51:          }
〰52:  
〰53:          private static IEnumerable<XNode> Parser(XmlReader xmlReader)
〰54:          {
⚠55:              if (xmlReader == null)
‼56:                  yield break;
〰57:  
✔58:              xmlReader.MoveToContent();
✔59:              while (xmlReader.ReadState != ReadState.EndOfFile)
✔60:                  yield return XNode.ReadFrom(xmlReader);
✔61:          }
〰62:  
✔63:          public override string ToString() => (string)this;
〰64:          public XmlReader CreateReader() =>
‼65:              XmlReader.Create(new StringReader(this), new XmlReaderSettings
‼66:              {
‼67:                  ConformanceLevel = ConformanceLevel.Fragment,
‼68:              });
〰69:  
✔70:          public static XFragment Parse(string xml) => new XFragment(xml);
‼71:          public static XFragment Parse(XmlReader xmlReader) => new XFragment(xmlReader);
〰72:  
〰73:          #region IEnumerable
〰74:  
〰75:          public IEnumerator<XNode> GetEnumerator() =>
⚠76:              (this.Nodes ?? Enumerable.Empty<XNode>()).Where(n => n != null).GetEnumerator();
〰77:  
‼78:          IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
〰79:  
〰80:          #endregion
〰81:  
〰82:          #region IList
〰83:  
✔84:          public int Count => this.Nodes.Count;
‼85:          public bool IsReadOnly => this.Nodes.IsReadOnly;
〰86:          public XNode this[int index]
〰87:          {
✔88:              get => this.Nodes[index];
‼89:              set => this.Nodes[index] = value;
〰90:          }
〰91:  
‼92:          public int IndexOf(XNode item) => this.Nodes.IndexOf(item);
‼93:          public void Insert(int index, XNode item) => this.Nodes.Insert(index, item);
‼94:          public void RemoveAt(int index) => this.Nodes.RemoveAt(index);
‼95:          public void Add(XNode item) => this.Nodes.Add(item);
‼96:          public void Clear() => this.Nodes.Clear();
‼97:          public bool Contains(XNode item) => this.Nodes.Contains(item);
‼98:          public void CopyTo(XNode[] array, int arrayIndex) => this.Nodes.CopyTo(array, arrayIndex);
‼99:          public bool Remove(XNode item) => this.Nodes.Remove(item);
〰100: 
〰101:         #endregion
〰102: 
〰103:         #region Conversions
〰104: 
✔105:         public static implicit operator XFragment(string xml) => new XFragment(xml);
〰106:         public static implicit operator string(XFragment fragment)
〰107:         {
⚠108:             if (fragment == null)
‼109:                 return null;
〰110: 
✔111:             var settings = new XmlWriterSettings
✔112:             {
✔113:                 OmitXmlDeclaration = true,
✔114:                 ConformanceLevel = ConformanceLevel.Fragment,
✔115:             };
✔116:             var sb = new StringBuilder();
✔117:             using (var xmlwriter = XmlWriter.Create(sb, settings))
✔118:                 foreach (var node in fragment)
〰119:                 {
✔120:                     node.WriteTo(xmlwriter);
〰121:                     //var reader = node.CreateReader();
〰122:                     //    xmlwriter.WriteNode(reader, false);
〰123:                 }
〰124: 
✔125:             return sb.ToString();
〰126:         }
〰127: 
✔128:         public static implicit operator XFragment(XNode[] nodes) => new XFragment(nodes);
✔129:         public static implicit operator XFragment(XNode node) => new XFragment(node);
〰130: 
〰131:         #endregion
〰132:     }
〰133: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

