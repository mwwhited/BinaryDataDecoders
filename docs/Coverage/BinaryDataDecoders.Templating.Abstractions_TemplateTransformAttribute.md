# BinaryDataDecoders.Templating.Abstractions.TemplateTransformAttribute

## Summary

| Key             | Value                                                                   |
| :-------------- | :---------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Templating.Abstractions.TemplateTransformAttribute` |
| Assembly        | `BinaryDataDecoders.Templating.Abstractions`                            |
| Coveredlines    | `0`                                                                     |
| Uncoveredlines  | `7`                                                                     |
| Coverablelines  | `7`                                                                     |
| Totallines      | `18`                                                                    |
| Linecoverage    | `0`                                                                     |
| Coveredbranches | `0`                                                                     |
| Totalbranches   | `0`                                                                     |

## Metrics

| Complexity | Lines | Branches | Name                   |
| :--------- | :---- | :------- | :--------------------- |
| 1          | 0     | 100      | `ctor`                 |
| 1          | 0     | 100      | `ctor`                 |
| 1          | 0     | 100      | `get_TargetMediaTypes` |
| 1          | 0     | 100      | `get_Priority`         |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Templating.Abstractions\TemplateTransformAttribute.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.Templating.Abstractions
〰4:   {
〰5:       [AttributeUsage(AttributeTargets.Class)]
〰6:       public class TemplateTransformAttribute : Attribute
〰7:       {
‼8:           public TemplateTransformAttribute(params string[] targetMediaTypes) : this(0, targetMediaTypes) { }
‼9:           public TemplateTransformAttribute(int priority, params string[] targetMediaTypes)
〰10:          {
‼11:              this.Priority = priority;
‼12:              this.TargetMediaTypes = targetMediaTypes;
‼13:          }
〰14:  
‼15:          public string[] TargetMediaTypes { get; }
‼16:          public int Priority { get; }
〰17:      }
〰18:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

