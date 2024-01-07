# BinaryDataDecoders.CodeAnalysis.DacFx.DacPacElementNodeBuilder

## Summary

| Key             | Value                                                            |
| :-------------- | :--------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.CodeAnalysis.DacFx.DacPacElementNodeBuilder` |
| Assembly        | `BinaryDataDecoders.CodeAnalysis.DacFx`                          |
| Coveredlines    | `0`                                                              |
| Uncoveredlines  | `64`                                                             |
| Coverablelines  | `64`                                                             |
| Totallines      | `121`                                                            |
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
〰6:   using System.Linq;
〰7:   using System.Reflection;
〰8:   using System.Xml.Linq;
〰9:   
〰10:  namespace BinaryDataDecoders.CodeAnalysis.DacFx;
〰11:  
‼12:  public class DacPacElementNodeBuilder(TSqlModel sqlModel) : ReflectionElementNodeBuilder(sqlModel, true, true)
〰13:  {
〰14:      private const string NAMESPACE = "";
〰15:  
〰16:      protected override IEnumerable<(XName name, object child)>? ChildSelector(object model) =>
‼17:          (model switch
‼18:          {
‼19:              TSqlModel sql => ChildSelector(sql),
‼20:              TSqlObject sql => ChildSelector(sql),
‼21:              Identifier _ => null,
‼22:              _ => Enumerable.Empty<(XName name, object child)>()
‼23:          })?.Concat(base.ChildSelector(model) ?? Enumerable.Empty<(XName name, object child)>());
〰24:      private IEnumerable<(XName name, object child)>? ChildSelector(TSqlModel model)
〰25:      {
‼26:          foreach (var i in model.GetObjects(DacQueryScopes.Default | DacQueryScopes.SameDatabase).Where(i => i.Name.Parts.Count == 1))
〰27:          {
〰28:              // Debug.WriteLine(i.ObjectType.Name + "\t" + i.Name);
‼29:              yield return (XName.Get(i.ObjectType.Name, NAMESPACE), i);
〰30:          }
‼31:      }
〰32:      private IEnumerable<(XName name, object child)>? ChildSelector(TSqlObject model)
〰33:      {
‼34:          foreach (var i in model.GetChildren())
‼35:              yield return (XName.Get(i.ObjectType.Name, NAMESPACE), i);
〰36:  
‼37:          if (model.TryGetAst(out var ast))
‼38:              yield return (XName.Get("AST", NAMESPACE), ast);
〰39:  
‼40:          if (model.TryGetScript(out var script))
‼41:              yield return (XName.Get("SCRIPT", NAMESPACE), script);
‼42:      }
〰43:  
〰44:      private IEnumerable<(XName name, string? value)> AllAttributeSelector(object model)
〰45:      {
‼46:          yield return (XName.Get("ref-id", NAMESPACE), model?.GetHashCode().ToString());
‼47:      }
〰48:      protected override IEnumerable<(XName name, string? value)>? AttributeSelector(object model) =>
‼49:          AllAttributeSelector(model).Concat(
‼50:          model switch
‼51:          {
‼52:              TSqlModel sql => AttributeSelector(sql),
‼53:              TSqlObject sql => AttributeSelector(sql),
‼54:              Identifier ident => AttributeSelector(ident),
‼55:              Literal literal => AttributeSelector(literal),
‼56:              Type type => AttributeSelector(type),
‼57:              _ => base.AttributeSelector(model)
‼58:          } ?? Enumerable.Empty<(XName name, string? value)>());
〰59:      private IEnumerable<(XName name, string? value)>? AttributeSelector(Identifier model)
〰60:      {
‼61:          yield return (XName.Get(nameof(model.QuoteType), NAMESPACE), model.QuoteType.ToString());
‼62:      }
〰63:      private IEnumerable<(XName name, string? value)>? AttributeSelector(Literal model)
〰64:      {
‼65:          yield return (XName.Get(nameof(model.LiteralType), NAMESPACE), model.LiteralType.ToString());
‼66:          yield return (XName.Get(nameof(model.Collation), NAMESPACE), model.Collation?.ToString());
‼67:      }
〰68:      private IEnumerable<(XName name, string? value)>? AttributeSelector(TSqlModel model)
〰69:      {
‼70:          yield break;
〰71:          //yield return (XName.Get(nameof(model.), NAMESPACE), model.LiteralType.ToString());
〰72:          //yield return (XName.Get(nameof(model.Collation), NAMESPACE), model.Collation?.ToString());
〰73:      }
〰74:      private IEnumerable<(XName name, string? value)>? AttributeSelector(TSqlObject model)
〰75:      {
‼76:          yield return (XName.Get(nameof(model.Name), NAMESPACE), model.Name.ToString());
‼77:      }
〰78:      private IEnumerable<(XName name, string? value)>? AttributeSelector(Type model)
〰79:      {
〰80:          //  yield return (XName.Get(nameof(model.AssemblyQualifiedName), NAMESPACE), model.AssemblyQualifiedName);
〰81:          // yield return (XName.Get(nameof(model.Namespace), NAMESPACE), model.Namespace);
‼82:          yield break;
〰83:      }
〰84:  
‼85:      private readonly HashSet<string> _excludeProperties =
‼86:      [
‼87:          "Item", "Count",
‼88:          "StartOffset", "FragmentLength", "StartLine", "StartColumn", "FirstTokenIndex", "LastTokenIndex",
‼89:          "OwningType", "ObjectType",
‼90:          //"ExtendedProperty",
‼91:      ];
‼92:      private readonly HashSet<object> _collected = [];
〰93:      protected override bool AllowNavigate(object model, PropertyInfo property)
〰94:      {
‼95:          var check = base.AllowNavigate(model, property);
‼96:          if (!check) return false;
‼97:          if (property.PropertyType.IsInstanceOfType(typeof(ObjectIdentifier))) return false;
〰98:  
‼99:          if (_excludeProperties.Contains(property.Name)) return false;
〰100: 
‼101:         if (_collected.Contains(model))
〰102:         {
‼103:             return false;
〰104:         }
〰105: 
‼106:         _collected.Add((model, property));
‼107:         return check;
〰108:     }
〰109: 
〰110:     protected override string? ValueSelector(object model) =>
‼111:         model switch
‼112:         {
‼113:             TSqlModel _ => null,
‼114:             TSqlObject _ => null,
‼115:             Identifier ident => ident.ToString(),
‼116:             Literal literal => literal.Value,
‼117:             Type type => type.ToString(),
‼118:             _ => base.ValueSelector(model)
‼119:         };
〰120: 
〰121: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

