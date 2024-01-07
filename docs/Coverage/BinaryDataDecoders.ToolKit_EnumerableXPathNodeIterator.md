# BinaryDataDecoders.ToolKit.Xml.XPath.EnumerableXPathNodeIterator

## Summary

| Key             | Value                                                              |
| :-------------- | :----------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.EnumerableXPathNodeIterator` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                       |
| Coveredlines    | `0`                                                                |
| Uncoveredlines  | `26`                                                               |
| Coverablelines  | `26`                                                               |
| Totallines      | `67`                                                               |
| Linecoverage    | `0`                                                                |
| Coveredbranches | `0`                                                                |
| Totalbranches   | `12`                                                               |
| Branchcoverage  | `0`                                                                |
| Coveredmethods  | `0`                                                                |
| Totalmethods    | `10`                                                               |
| Methodcoverage  | `0`                                                                |

## Metrics

| Complexity | Lines | Branches | Name                  |
| :--------- | :---- | :------- | :-------------------- |
| 1          | 0     | 100      | `ctor`                |
| 1          | 0     | 100      | `get_Current`         |
| 1          | 0     | 100      | `get_CurrentPosition` |
| 4          | 0     | 0        | `Clone`               |
| 2          | 0     | 0        | `MoveNext`            |
| 1          | 0     | 100      | `ctor`                |
| 1          | 0     | 100      | `get_Current`         |
| 1          | 0     | 100      | `get_CurrentPosition` |
| 4          | 0     | 0        | `Clone`               |
| 2          | 0     | 0        | `MoveNext`            |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/XPath/EnumerableXPathNodeIterator.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Linq;
〰4:   using System.Xml.XPath;
〰5:   
〰6:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰7:   
‼8:   public class EnumerableXPathNodeIterator(IEnumerable<IXPathNavigable> set) : XPathNodeIterator
〰9:   {
‼10:      private int _pointer = -1;
‼11:      private readonly IEnumerable<IXPathNavigable> _set = set.ToArray();
‼12:      private readonly IEnumerator<IXPathNavigable> _enumerator = set.GetEnumerator();
〰13:  
‼14:      public override XPathNavigator Current => _enumerator.Current.CreateNavigator();
‼15:      public override int CurrentPosition => _pointer;
〰16:  
〰17:      public override XPathNodeIterator Clone()
〰18:      {
‼19:          var newIterator = new EnumerableXPathNodeIterator(_set);
‼20:          while (newIterator.CurrentPosition < _pointer && newIterator.MoveNext()) ;
‼21:          return newIterator;
〰22:      }
〰23:  
〰24:      public override bool MoveNext()
〰25:      {
‼26:          if (_enumerator.MoveNext())
〰27:          {
‼28:              _pointer++;
‼29:              return true;
〰30:          }
‼31:          return false;
〰32:      }
〰33:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/Xml/XPath/EnumerableXPathNodeIterator.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Linq;
〰4:   using System.Xml.XPath;
〰5:   
〰6:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰7:   
‼8:   public class EnumerableXPathNodeIterator(IEnumerable<IXPathNavigable> set) : XPathNodeIterator
〰9:   {
‼10:      private int _pointer = -1;
‼11:      private readonly IEnumerable<IXPathNavigable> _set = set.ToArray();
‼12:      private readonly IEnumerator<IXPathNavigable> _enumerator = set.GetEnumerator();
〰13:  
‼14:      public override XPathNavigator Current => _enumerator.Current.CreateNavigator();
‼15:      public override int CurrentPosition => _pointer;
〰16:  
〰17:      public override XPathNodeIterator Clone()
〰18:      {
‼19:          var newIterator = new EnumerableXPathNodeIterator(_set);
‼20:          while (newIterator.CurrentPosition < _pointer && newIterator.MoveNext()) ;
‼21:          return newIterator;
〰22:      }
〰23:  
〰24:      public override bool MoveNext()
〰25:      {
‼26:          if (_enumerator.MoveNext())
〰27:          {
‼28:              _pointer++;
‼29:              return true;
〰30:          }
‼31:          return false;
〰32:      }
〰33:  }
〰34:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

