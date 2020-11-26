# BinaryDataDecoders.Text.Json.JsonPath.Parser.JsonPathFactory

## Summary

| Key             | Value                                                          |
| :-------------- | :------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Text.Json.JsonPath.Parser.JsonPathFactory` |
| Assembly        | `BinaryDataDecoders.Text.Json`                                 |
| Coveredlines    | `12`                                                           |
| Uncoveredlines  | `0`                                                            |
| Coverablelines  | `12`                                                           |
| Totallines      | `23`                                                           |
| Linecoverage    | `100`                                                          |
| Coveredbranches | `1`                                                            |
| Totalbranches   | `2`                                                            |
| Branchcoverage  | `50`                                                           |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 2          | 100   | 50.0     | `Parse` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Text.Json/JsonPath/Parser/JsonPathFactory.cs

```CSharp
〰1:   using Antlr4.Runtime;
〰2:   using BinaryDataDecoders.ToolKit.PathSegments;
〰3:   using System;
〰4:   
〰5:   namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
〰6:   {
〰7:       public static class JsonPathFactory
〰8:       {
〰9:           public static IPathSegment Parse(string input) =>
⚠10:              new JsonPathVisitor().Visit(
✔11:                  new JsonPathParser(
✔12:                  new CommonTokenStream(
✔13:                      new JsonPathLexer(
✔14:                          new AntlrInputStream(input)
✔15:                          )
✔16:                      )
✔17:                  )
✔18:                  {
✔19:                       ErrorHandler = new BailErrorStrategy(),
✔20:                  }.start()
✔21:              ) ?? throw new JsonPathException($"Invalid JSONPath \"{input}\"");
〰22:      }
〰23:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

