# BinaryDataDecoders.CodeAnalysis.DacFx.DacPacElementNodeBuilder

## Summary

| Key             | Value                                                            |
| :-------------- | :--------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.CodeAnalysis.DacFx.DacPacElementNodeBuilder` |
| Assembly        | `BinaryDataDecoders.CodeAnalysis.DacFx`                          |
| Coveredlines    | `0`                                                              |
| Uncoveredlines  | `65`                                                             |
| Coverablelines  | `65`                                                             |
| Totallines      | `128`                                                            |
| Linecoverage    | `0`                                                              |
| Coveredbranches | `0`                                                              |
| Totalbranches   | `50`                                                             |
| Branchcoverage  | `0`                                                              |
| Coveredmethods  | `0`                                                              |
| Totalmethods    | `13`                                                             |
| Methodcoverage  | `0`                                                              |

## Metrics

| Complexity | Lines | Branches | Name                   |
| :--------- | :---- | :------- | :--------------------- |
| 1          | 0     | 100      | `ctor`                 |
| 10         | 0     | 0        | `ChildSelector`        |
| 2          | 0     | 0        | `ChildSelector`        |
| 6          | 0     | 0        | `ChildSelector`        |
| 2          | 0     | 0        | `AllAttributeSelector` |
| 12         | 0     | 0        | `AttributeSelector`    |
| 1          | 0     | 100      | `AttributeSelector`    |
| 2          | 0     | 0        | `AttributeSelector`    |
| 1          | 0     | 100      | `AttributeSelector`    |
| 1          | 0     | 100      | `AttributeSelector`    |
| 1          | 0     | 100      | `AttributeSelector`    |
| 8          | 0     | 0        | `AllowNavigate`        |
| 10         | 0     | 0        | `ValueSelector`        |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.CodeAnalysis.DacFx/DacPacElementNodeBuilder.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Reflection;
〰2:   using Microsoft.SqlServer.Dac.Model;
〰3:   using Microsoft.SqlServer.TransactSql.ScriptDom;
〰4:   using System;
〰5:   using System.Collections.Generic;
〰6:   using System.Diagnostics;
〰7:   using System.Linq;
〰8:   using System.Reflection;
〰9:   using System.Xml.Linq;
〰10:  
〰11:  namespace BinaryDataDecoders.CodeAnalysis.DacFx
〰12:  {
〰13:      public class DacPacElementNodeBuilder : ReflectionElementNodeBuilder
〰14:      {
〰15:          private const string NAMESPACE = "";
〰16:  
〰17:          public DacPacElementNodeBuilder(TSqlModel sqlModel) :
‼18:              base(sqlModel, true, true)
〰19:          {
‼20:          }
〰21:  
〰22:          protected override IEnumerable<(XName name, object child)>? ChildSelector(object model) =>
‼23:              (model switch
‼24:              {
‼25:                  TSqlModel sql => ChildSelector(sql),
‼26:                  TSqlObject sql => ChildSelector(sql),
‼27:                  Identifier _ => null,
‼28:                  _ => Enumerable.Empty<(XName name, object child)>()
‼29:              })?.Concat(base.ChildSelector(model) ?? Enumerable.Empty<(XName name, object child)>());
〰30:          private IEnumerable<(XName name, object child)>? ChildSelector(TSqlModel model)
〰31:          {
‼32:              foreach (var i in model.GetObjects(DacQueryScopes.Default | DacQueryScopes.SameDatabase).Where(i => i.Name.Parts.Count == 1))
〰33:              {
〰34:                  // Debug.WriteLine(i.ObjectType.Name + "\t" + i.Name);
‼35:                  yield return (XName.Get(i.ObjectType.Name, NAMESPACE), i);
〰36:              }
‼37:          }
〰38:          private IEnumerable<(XName name, object child)>? ChildSelector(TSqlObject model)
〰39:          {
‼40:              foreach (var i in model.GetChildren())
‼41:                  yield return (XName.Get(i.ObjectType.Name, NAMESPACE), i);
〰42:  
‼43:              if (model.TryGetAst(out var ast))
‼44:                  yield return (XName.Get("AST", NAMESPACE), ast);
〰45:  
‼46:              if (model.TryGetScript(out var script))
‼47:                  yield return (XName.Get("SCRIPT", NAMESPACE), script);
‼48:          }
〰49:  
〰50:          private IEnumerable<(XName name, string? value)> AllAttributeSelector(object model)
〰51:          {
‼52:              yield return (XName.Get("ref-id", NAMESPACE), model?.GetHashCode().ToString());
‼53:          }
〰54:          protected override IEnumerable<(XName name, string? value)>? AttributeSelector(object model) =>
‼55:              AllAttributeSelector(model).Concat(
‼56:              model switch
‼57:              {
‼58:                  TSqlModel sql => AttributeSelector(sql),
‼59:                  TSqlObject sql => AttributeSelector(sql),
‼60:                  Identifier ident => AttributeSelector(ident),
‼61:                  Literal literal => AttributeSelector(literal),
‼62:                  Type type => AttributeSelector(type),
‼63:                  _ => base.AttributeSelector(model)
‼64:              } ?? Enumerable.Empty<(XName name, string? value)>());
〰65:          private IEnumerable<(XName name, string? value)>? AttributeSelector(Identifier model)
〰66:          {
‼67:              yield return (XName.Get(nameof(model.QuoteType), NAMESPACE), model.QuoteType.ToString());
‼68:          }
〰69:          private IEnumerable<(XName name, string? value)>? AttributeSelector(Literal model)
〰70:          {
‼71:              yield return (XName.Get(nameof(model.LiteralType), NAMESPACE), model.LiteralType.ToString());
‼72:              yield return (XName.Get(nameof(model.Collation), NAMESPACE), model.Collation?.ToString());
‼73:          }
〰74:          private IEnumerable<(XName name, string? value)>? AttributeSelector(TSqlModel model)
〰75:          {
‼76:              yield break;
〰77:              //yield return (XName.Get(nameof(model.), NAMESPACE), model.LiteralType.ToString());
〰78:              //yield return (XName.Get(nameof(model.Collation), NAMESPACE), model.Collation?.ToString());
〰79:          }
〰80:          private IEnumerable<(XName name, string? value)>? AttributeSelector(TSqlObject model)
〰81:          {
‼82:              yield return (XName.Get(nameof(model.Name), NAMESPACE), model.Name.ToString());
‼83:          }
〰84:          private IEnumerable<(XName name, string? value)>? AttributeSelector(Type model)
〰85:          {
〰86:              //  yield return (XName.Get(nameof(model.AssemblyQualifiedName), NAMESPACE), model.AssemblyQualifiedName);
〰87:              // yield return (XName.Get(nameof(model.Namespace), NAMESPACE), model.Namespace);
‼88:              yield break;
〰89:          }
〰90:  
‼91:          private HashSet<string> _excludeProperties = new HashSet<string>()
‼92:          {
‼93:              "Item", "Count",
‼94:              "StartOffset", "FragmentLength", "StartLine", "StartColumn", "FirstTokenIndex", "LastTokenIndex",
‼95:              "OwningType", "ObjectType",
‼96:              //"ExtendedProperty",
‼97:          };
‼98:          private HashSet<object> _collected = new HashSet<object>();
〰99:          protected override bool AllowNavigate(object model, PropertyInfo property)
〰100:         {
‼101:             var check = base.AllowNavigate(model, property);
‼102:             if (!check) return false;
‼103:             if (property.PropertyType.IsInstanceOfType(typeof(ObjectIdentifier))) return false;
〰104: 
‼105:             if (_excludeProperties.Contains(property.Name)) return false;
〰106: 
‼107:             if (_collected.Contains(model))
〰108:             {
‼109:                 return false;
〰110:             }
〰111: 
‼112:             _collected.Add((model, property));
‼113:             return check;
〰114:         }
〰115: 
〰116:         protected override string? ValueSelector(object model) =>
‼117:             model switch
‼118:             {
‼119:                 TSqlModel _ => null,
‼120:                 TSqlObject _ => null,
‼121:                 Identifier ident => ident.ToString(),
‼122:                 Literal literal => literal.Value,
‼123:                 Type type => type.ToString(),
‼124:                 _ => base.ValueSelector(model)
‼125:             };
〰126: 
〰127:     }
〰128: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

