# BinaryDataDecoders.CodeAnalysis.DacFx.DacPacNavigatorFactory

## Summary

| Key             | Value                                                          |
| :-------------- | :------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.CodeAnalysis.DacFx.DacPacNavigatorFactory` |
| Assembly        | `BinaryDataDecoders.CodeAnalysis.DacFx`                        |
| Coveredlines    | `0`                                                            |
| Uncoveredlines  | `69`                                                           |
| Coverablelines  | `69`                                                           |
| Totallines      | `87`                                                           |
| Linecoverage    | `0`                                                            |
| Coveredbranches | `0`                                                            |
| Totalbranches   | `32`                                                           |
| Branchcoverage  | `0`                                                            |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `ToNavigable` |
| 32         | 0     | 0        | `AsNode`      |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.CodeAnalysis.DacFx\DacPacNavigatorFactory.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰2:   using Microsoft.SqlServer.Dac.Model;
〰3:   using Microsoft.SqlServer.TransactSql.ScriptDom;
〰4:   using System;
〰5:   using System.Collections;
〰6:   using System.Linq;
〰7:   using System.Xml.Linq;
〰8:   using System.Xml.XPath;
〰9:   
〰10:  namespace BinaryDataDecoders.CodeAnalysis.DacFx
〰11:  {
〰12:      public static class DacPacNavigatorFactory
〰13:      {
〰14:          public static IXPathNavigable ToNavigable(this TSqlModel tree) =>
‼15:              new ExtensibleNavigator(tree.AsNode());
〰16:  
〰17:          public static INode AsNode(this TSqlModel build) =>
‼18:              new ExtensibleElementNode(
‼19:                  "sql",
‼20:                  build,
‼21:  
‼22:                valueSelector: n => n switch
‼23:                {
‼24:                    TSqlObject model => model.TryGetScript(out var obj) ? obj : null,
‼25:                    string value => value,
‼26:  
‼27:                    _ => null
‼28:                },
‼29:  
‼30:                attributeSelector: n => n switch
‼31:                {
‼32:                    TSqlModel model => new (XName, string?)[] {
‼33:                            (XName.Get(nameof(model.EngineVersion), ""),model.EngineVersion.ToString()),
‼34:                            (XName.Get(nameof(model.Version), ""),model.Version.ToString()),
‼35:                    },
‼36:  
‼37:                    TSqlObject model => new (XName, string?)[] {
‼38:                            (XName.Get(nameof(model.Name), ""),string.Join(".",model.Name.Parts)),
‼39:                    },
‼40:  
‼41:                    //TSqlScript script => new (XName, string?)[] {
‼42:                    //        (XName.Get(nameof(script.StartLine), ""),script.StartLine.ToString()),
‼43:                    //},
‼44:  
‼45:                    //TSqlBatch batch => new (XName, string?)[] {
‼46:                    //        (XName.Get(nameof(batch.StartLine), ""),batch.StartLine.ToString()),
‼47:                    //},
‼48:  
‼49:                    //TSqlStatement statement => new (XName, string?)[] {
‼50:                    //        (XName.Get(nameof(statement.StartLine), ""),statement.StartLine.ToString()),
‼51:                    //},
‼52:  
‼53:                    TSqlParserToken token => new (XName, string?)[] {
‼54:                            (XName.Get(nameof(token.Text), ""),token.Text),
‼55:                    },
‼56:  
‼57:                    _ => null,
‼58:                },
‼59:  
‼60:                childSelector: n => n switch
‼61:                {
‼62:                    TSqlModel model => model.GetObjects(DacQueryScopes.SameDatabase | DacQueryScopes.UserDefined)
‼63:                                            .Select(i => (XName.Get(i.ObjectType.Name, ""), (object)i)),
‼64:  
‼65:                    TSqlObject model => model.GetChildren().Select(i => (XName.Get(i.ObjectType.Name, ""), (object)i))
‼66:                                             //   .Concat(model.GetReferencedRelationshipInstances())
‼67:                                             .Concat(new[] { (XName.Get("AST", ""), model.TryGetAst(out var ast) ? (object)ast : null) })
‼68:                                          ,
‼69:  
‼70:                    TSqlScript script => script.Batches?.Select(i => (XName.Get("Batch", ""), (object)i)),
‼71:                    TSqlBatch batch => batch.Statements?.Select(i => (XName.Get("Statements", ""), (object)i)),
‼72:                    TSqlStatement statement => statement.ScriptTokenStream?.Select(i => (XName.Get(i.TokenType.ToString(), ""), (object)i)),
‼73:                    TSqlParserToken token => null,
‼74:  
‼75:                    //  .Concat(model.GetReferencedRelationshipInstances().Select(i=>i.,
‼76:                    //.Concat(
‼77:                    //                from i in model.GetProperty(new ModelPropertyClass())
‼78:                    //                select (XName.Get(i.ObjectType.Name, ""), (object)i)
‼79:                    //            ),
‼80:  
‼81:  
‼82:                    _ => throw new NotSupportedException($"{n.GetType()}"),
‼83:                }
‼84:  
‼85:                );
〰86:      }
〰87:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

