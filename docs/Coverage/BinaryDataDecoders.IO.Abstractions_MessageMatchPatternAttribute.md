# BinaryDataDecoders.IO.Messages.MessageMatchPatternAttribute

## Summary

| Key             | Value                                                         |
| :-------------- | :------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.IO.Messages.MessageMatchPatternAttribute` |
| Assembly        | `BinaryDataDecoders.IO.Abstractions`                          |
| Coveredlines    | `0`                                                           |
| Uncoveredlines  | `2`                                                           |
| Coverablelines  | `2`                                                           |
| Totallines      | `43`                                                          |
| Linecoverage    | `0`                                                           |
| Coveredbranches | `0`                                                           |
| Totalbranches   | `0`                                                           |
| Coveredmethods  | `0`                                                           |
| Totalmethods    | `1`                                                           |
| Methodcoverage  | `0`                                                           |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Abstractions/Messages/MessageMatchPatternAttribute.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.IO.Messages
〰4:   {
〰5:       /// <summary>
〰6:       /// prefix pattern to identify decoding patterns
〰7:       /// </summary>
〰8:       [AttributeUsage(AttributeTargets.Struct, AllowMultiple = true)]
〰9:       public class MessageMatchPatternAttribute : Attribute
〰10:      {
〰11:          /// <summary>
〰12:          /// attribute to assign expected prefix to related structure
〰13:          /// </summary>
〰14:          /// <param name="pattern">prefix pattern to identify decoding patterns
〰15:          /// <code>
〰16:          ///     allowed characters: matches on a nibble
〰17:          ///         0 to F hexadecimal value
〰18:          ///         period (.), asterisk (*), or question (?) may be used for wild cards
〰19:          ///         other characters are ignored
〰20:          /// </code>
〰21:          /// </param>
‼22:          public MessageMatchPatternAttribute(string pattern)
〰23:          {
〰24:              Pattern = pattern;
‼25:          }
〰26:  
〰27:          /// <summary>
〰28:          /// prefix pattern to identify decoding patterns
〰29:          /// </summary>
〰30:          public string Pattern { get; }
〰31:  
〰32:          /// <summary>
〰33:          /// prefix pattern to identify decoding patterns
〰34:          /// </summary>
〰35:          public string? Mask { get; set; }
〰36:  
〰37:          /// <summary>
〰38:          /// override check order
〰39:          /// </summary>
〰40:          public int Priority { get; set; }
〰41:  
〰42:      }
〰43:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

