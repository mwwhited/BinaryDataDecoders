# BinaryDataDecoders.Nmea.StringNemaMessage

## Summary

| Key             | Value                                       |
| :-------------- | :------------------------------------------ |
| Class           | `BinaryDataDecoders.Nmea.StringNemaMessage` |
| Assembly        | `BinaryDataDecoders.Nmea`                   |
| Coveredlines    | `0`                                         |
| Uncoveredlines  | `1`                                         |
| Coverablelines  | `1`                                         |
| Totallines      | `6`                                         |
| Linecoverage    | `0`                                         |
| Coveredbranches | `0`                                         |
| Totalbranches   | `0`                                         |
| Coveredmethods  | `0`                                         |
| Totalmethods    | `1`                                         |
| Methodcoverage  | `0`                                         |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `ToString` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Nmea/StringNemaMessage.cs

```CSharp
〰1:   namespace BinaryDataDecoders.Nmea;
〰2:   
〰3:   public class StringNemaMessage(string value) : INema0183Message
〰4:   {
‼5:       public override string ToString() => value;
〰6:   }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

