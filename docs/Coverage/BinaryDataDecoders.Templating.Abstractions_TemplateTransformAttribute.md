# BinaryDataDecoders.Templating.Abstractions.TemplateTransformAttribute

## Summary

| Key             | Value                                                                   |
| :-------------- | :---------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Templating.Abstractions.TemplateTransformAttribute` |
| Assembly        | `BinaryDataDecoders.Templating.Abstractions`                            |
| Coveredlines    | `0`                                                                     |
| Uncoveredlines  | `2`                                                                     |
| Coverablelines  | `2`                                                                     |
| Totallines      | `12`                                                                    |
| Linecoverage    | `0`                                                                     |
| Coveredbranches | `0`                                                                     |
| Totalbranches   | `0`                                                                     |
| Coveredmethods  | `0`                                                                     |
| Totalmethods    | `2`                                                                     |
| Methodcoverage  | `0`                                                                     |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 1          | 0     | 100      | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Templating.Abstractions/TemplateTransformAttribute.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.Templating.Abstractions;
〰4:   
〰5:   [AttributeUsage(AttributeTargets.Class)]
‼6:   public class TemplateTransformAttribute(int priority, params string[] targetMediaTypes) : Attribute
〰7:   {
‼8:       public TemplateTransformAttribute(params string[] targetMediaTypes) : this(0, targetMediaTypes) { }
〰9:   
〰10:      public string[] TargetMediaTypes { get; } = targetMediaTypes;
〰11:      public int Priority { get; } = priority;
〰12:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

