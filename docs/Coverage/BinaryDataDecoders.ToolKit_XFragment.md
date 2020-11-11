# BinaryDataDecoders.ToolKit.Xml.Linq.XFragment

## Summary

| Key             | Value                                           |
| :-------------- | :---------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Linq.XFragment` |
| Assembly        | `BinaryDataDecoders.ToolKit`                    |
| Coveredlines    | `0`                                             |
| Uncoveredlines  | `62`                                            |
| Coverablelines  | `62`                                            |
| Totallines      | `118`                                           |
| Linecoverage    | `0`                                             |
| Coveredbranches | `0`                                             |
| Totalbranches   | `20`                                            |
| Branchcoverage  | `0`                                             |

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
| 4          | 0     | 0        | `op_Implicit`                               |
| 1          | 0     | 100      | `op_Implicit`                               |
| 1          | 0     | 100      | `op_Implicit`                               |
| 1          | 0     | 100      | `op_Implicit`                               |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\Linq\XFragment.cs

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
〰11:      public class XFragment : IList<XNode>
〰12:      {
〰13:          //https://raw.githubusercontent.com/OutOfBandDevelopment/Samples/master/HandyClasses/XFragment.cs
〰14:  
‼15:          private readonly IList<XNode> _nodes = new List<XNode>();
〰16:  
‼17:          public XFragment(IEnumerable<XNode> nodes)
〰18:          {
‼19:              foreach (var node in nodes ?? Enumerable.Empty<XNode>().Where(n => n != null))
‼20:                  _nodes.Add(node);
‼21:          }
〰22:  
‼23:          public XFragment(XNode node, params XNode[] nodes) : this(new[] { node }.Concat(nodes ?? Enumerable.Empty<XNode>())) { }
‼24:          public XFragment(string xml) : this(Parser(xml).ToArray()) { }
‼25:          public XFragment(XmlReader xmlReader) : this(Parser(xmlReader).ToArray()) { }
〰26:  
〰27:          private static IEnumerable<XNode> Parser(string xml)
〰28:          {
‼29:              if (string.IsNullOrWhiteSpace(xml))
‼30:                  yield break;
〰31:  
‼32:              var settings = new XmlReaderSettings
‼33:              {
‼34:                  ConformanceLevel = ConformanceLevel.Fragment,
‼35:                  IgnoreWhitespace = true
‼36:              };
〰37:  
‼38:              using var stringReader = new StringReader(xml);
‼39:              using var xmlReader = XmlReader.Create(stringReader, settings);
‼40:              foreach (var node in Parser(xmlReader))
‼41:                  yield return node;
‼42:          }
〰43:  
〰44:          private static IEnumerable<XNode> Parser(XmlReader xmlReader)
〰45:          {
‼46:              if (xmlReader == null)
‼47:                  yield break;
〰48:  
‼49:              xmlReader.MoveToContent();
‼50:              while (xmlReader.ReadState != ReadState.EndOfFile)
〰51:              {
‼52:                  yield return XNode.ReadFrom(xmlReader);
〰53:              }
‼54:          }
〰55:  
‼56:          public override string ToString() => this;
‼57:          public XmlReader CreateReader() => XmlReader.Create(new StringReader(this), new XmlReaderSettings
‼58:          {
‼59:              ConformanceLevel = ConformanceLevel.Fragment,
‼60:          });
〰61:  
‼62:          public static XFragment Parse(string xml) => new XFragment(xml);
‼63:          public static XFragment Parse(XmlReader xmlReader) => new XFragment(xmlReader);
〰64:  
〰65:          #region IEnumerable
〰66:  
‼67:          public IEnumerator<XNode> GetEnumerator() => (_nodes ?? Enumerable.Empty<XNode>()).Where(n => n != null).GetEnumerator();
‼68:          IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
〰69:  
〰70:          #endregion
〰71:  
〰72:          #region IList
〰73:  
‼74:          public int Count => _nodes.Count;
‼75:          public bool IsReadOnly => _nodes.IsReadOnly;
〰76:  
〰77:          public XNode this[int index]
〰78:          {
‼79:              get => _nodes[index];
‼80:              set => _nodes[index] = value;
〰81:          }
〰82:  
‼83:          public int IndexOf(XNode item) => _nodes.IndexOf(item);
‼84:          public void Insert(int index, XNode item) => _nodes.Insert(index, item);
‼85:          public void RemoveAt(int index) => _nodes.RemoveAt(index);
‼86:          public void Add(XNode item) => _nodes.Add(item);
‼87:          public void Clear() => _nodes.Clear();
‼88:          public bool Contains(XNode item) => _nodes.Contains(item);
‼89:          public void CopyTo(XNode[] array, int arrayIndex) => _nodes.CopyTo(array, arrayIndex);
‼90:          public bool Remove(XNode item) => _nodes.Remove(item);
〰91:  
〰92:          #endregion
〰93:  
〰94:          #region Conversions
〰95:  
〰96:          public static implicit operator string(XFragment fragment)
〰97:          {
‼98:              if (fragment == null) return "";
〰99:  
‼100:             var settings = new XmlWriterSettings
‼101:             {
‼102:                 OmitXmlDeclaration = true,
‼103:                 ConformanceLevel = ConformanceLevel.Fragment,
‼104:             };
‼105:             var sb = new StringBuilder();
‼106:             using var xmlwriter = XmlWriter.Create(sb, settings);
‼107:             foreach (var node in fragment)
‼108:                 xmlwriter.WriteNode(node.CreateReader(), false);
〰109: 
‼110:             return sb.ToString();
‼111:         }
‼112:         public static implicit operator XFragment(string xml) => new XFragment(xml);
‼113:         public static implicit operator XFragment(XNode[] nodes) => new XFragment(nodes);
‼114:         public static implicit operator XFragment(XNode node) => new XFragment(node);
〰115: 
〰116:         #endregion
〰117:     }
〰118: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

