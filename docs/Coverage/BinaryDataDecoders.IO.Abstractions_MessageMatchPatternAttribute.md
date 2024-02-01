# BinaryDataDecoders.IO.Messages.MessageMatchPatternAttribute

## Summary

| Key             | Value                                                         |
| :-------------- | :------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.IO.Messages.MessageMatchPatternAttribute` |
| Assembly        | `BinaryDataDecoders.IO.Abstractions`                          |
| Coveredlines    | `0`                                                           |
| Uncoveredlines  | `2`                                                           |
| Coverablelines  | `2`                                                           |
| Totallines      | `77`                                                          |
| Linecoverage    | `0`                                                           |
| Coveredbranches | `0`                                                           |
| Totalbranches   | `0`                                                           |
| Coveredmethods  | `0`                                                           |
| Totalmethods    | `2`                                                           |
| Methodcoverage  | `0`                                                           |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 1          | 0     | 100      | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Abstractions/Messages/MessageMatchPatternAttribute.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.IO.Messages;
〰4:   
〰5:   /// <summary>
〰6:   /// prefix pattern to identify decoding patterns
〰7:   /// </summary>
〰8:   /// <remarks>
〰9:   /// attribute to assign expected prefix to related structure
〰10:  /// </remarks>
〰11:  /// <param name="pattern">prefix pattern to identify decoding patterns
〰12:  /// <code>
〰13:  ///     allowed characters: matches on a nibble
〰14:  ///         0 to F hexadecimal value
〰15:  ///         period (.), asterisk (*), or question (?) may be used for wild cards
〰16:  ///         other characters are ignored
〰17:  /// </code>
〰18:  /// </param>
〰19:  [AttributeUsage(AttributeTargets.Struct, AllowMultiple = true)]
‼20:  public class MessageMatchPatternAttribute(string pattern) : Attribute
〰21:  {
〰22:  
〰23:      /// <summary>
〰24:      /// prefix pattern to identify decoding patterns
〰25:      /// </summary>
〰26:      public string Pattern { get; } = pattern;
〰27:  
〰28:      /// <summary>
〰29:      /// prefix pattern to identify decoding patterns
〰30:      /// </summary>
〰31:      public string? Mask { get; set; }
〰32:  
〰33:      /// <summary>
〰34:      /// override check order
〰35:      /// </summary>
〰36:      public int Priority { get; set; }
〰37:  
〰38:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.IO.Abstractions/Messages/MessageMatchPatternAttribute.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.IO.Messages;
〰4:   
〰5:   /// <summary>
〰6:   /// prefix pattern to identify decoding patterns
〰7:   /// </summary>
〰8:   /// <remarks>
〰9:   /// attribute to assign expected prefix to related structure
〰10:  /// </remarks>
〰11:  /// <param name="pattern">prefix pattern to identify decoding patterns
〰12:  /// <code>
〰13:  ///     allowed characters: matches on a nibble
〰14:  ///         0 to F hexadecimal value
〰15:  ///         period (.), asterisk (*), or question (?) may be used for wild cards
〰16:  ///         other characters are ignored
〰17:  /// </code>
〰18:  /// </param>
〰19:  [AttributeUsage(AttributeTargets.Struct, AllowMultiple = true)]
‼20:  public class MessageMatchPatternAttribute(string pattern) : Attribute
〰21:  {
〰22:  
〰23:      /// <summary>
〰24:      /// prefix pattern to identify decoding patterns
〰25:      /// </summary>
〰26:      public string Pattern { get; } = pattern;
〰27:  
〰28:      /// <summary>
〰29:      /// prefix pattern to identify decoding patterns
〰30:      /// </summary>
〰31:      public string? Mask { get; set; }
〰32:  
〰33:      /// <summary>
〰34:      /// override check order
〰35:      /// </summary>
〰36:      public int Priority { get; set; }
〰37:  
〰38:  }
〰39:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

