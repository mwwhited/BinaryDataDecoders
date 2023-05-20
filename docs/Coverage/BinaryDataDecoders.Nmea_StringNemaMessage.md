# BinaryDataDecoders.Nmea.StringNemaMessage

## Summary

| Key             | Value                                       |
| :-------------- | :------------------------------------------ |
| Class           | `BinaryDataDecoders.Nmea.StringNemaMessage` |
| Assembly        | `BinaryDataDecoders.Nmea`                   |
| Coveredlines    | `0`                                         |
| Uncoveredlines  | `2`                                         |
| Coverablelines  | `2`                                         |
| Totallines      | `9`                                         |
| Linecoverage    | `0`                                         |
| Coveredbranches | `0`                                         |
| Totalbranches   | `0`                                         |
| Coveredmethods  | `0`                                         |
| Totalmethods    | `2`                                         |
| Methodcoverage  | `0`                                         |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `ctor`     |
| 1          | 0     | 100      | `ToString` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Nmea/StringNemaMessage.cs

```CSharp
〰1:   namespace BinaryDataDecoders.Nmea
〰2:   {
〰3:       public class StringNemaMessage : INema0183Message
〰4:       {
〰5:           private readonly string _value;
‼6:           public StringNemaMessage(string value) => this._value = value;
‼7:           public override string ToString() => _value;
〰8:       }
〰9:   }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

