# BinaryDataDecoders.ToolKit.Xml.XPath.EnumerableXPathNodeIterator

## Summary

| Key             | Value                                                              |
| :-------------- | :----------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.EnumerableXPathNodeIterator` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                       |
| Coveredlines    | `0`                                                                |
| Uncoveredlines  | `14`                                                               |
| Coverablelines  | `14`                                                               |
| Totallines      | `41`                                                               |
| Linecoverage    | `0`                                                                |
| Coveredbranches | `0`                                                                |
| Totalbranches   | `6`                                                                |
| Branchcoverage  | `0`                                                                |

## Metrics

| Complexity | Lines | Branches | Name                  |
| :--------- | :---- | :------- | :-------------------- |
| 1          | 0     | 100      | `ctor`                |
| 1          | 0     | 100      | `get_Current`         |
| 1          | 0     | 100      | `get_CurrentPosition` |
| 4          | 0     | 0        | `Clone`               |
| 2          | 0     | 0        | `MoveNext`            |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\XPath\EnumerableXPathNodeIterator.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Linq;
〰4:   using System.Xml.XPath;
〰5:   
〰6:   namespace BinaryDataDecoders.ToolKit.Xml.XPath
〰7:   {
〰8:       public class EnumerableXPathNodeIterator : XPathNodeIterator
〰9:       {
〰10:          private int _pointer;
〰11:          private readonly IEnumerable<IXPathNavigable> _set;
〰12:          private readonly IEnumerator<IXPathNavigable> _enumerator;
〰13:  
‼14:          public EnumerableXPathNodeIterator(IEnumerable<IXPathNavigable> set)
〰15:          {
‼16:              _set = set.ToArray();
‼17:              _pointer = -1;
‼18:              _enumerator = set.GetEnumerator();
‼19:          }
〰20:  
‼21:          public override XPathNavigator Current => _enumerator.Current.CreateNavigator();
‼22:          public override int CurrentPosition => _pointer;
〰23:  
〰24:          public override XPathNodeIterator Clone()
〰25:          {
‼26:              var newIterator = new EnumerableXPathNodeIterator(_set);
‼27:              while (newIterator.CurrentPosition < _pointer && newIterator.MoveNext()) ;
‼28:              return newIterator;
〰29:          }
〰30:  
〰31:          public override bool MoveNext()
〰32:          {
‼33:              if (_enumerator.MoveNext())
〰34:              {
‼35:                  _pointer++;
‼36:                  return true;
〰37:              }
‼38:              return false;
〰39:          }
〰40:      }
〰41:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

