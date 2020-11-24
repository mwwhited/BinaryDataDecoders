# BinaryDataDecoders.ToolKit.Xml.XPath.XPathExpressionBuilder

## Summary

| Key             | Value                                                         |
| :-------------- | :------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.XPathExpressionBuilder` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                  |
| Coveredlines    | `86`                                                          |
| Uncoveredlines  | `12`                                                          |
| Coverablelines  | `98`                                                          |
| Totallines      | `127`                                                         |
| Linecoverage    | `87.7`                                                        |
| Coveredbranches | `68`                                                          |
| Totalbranches   | `83`                                                          |
| Branchcoverage  | `81.9`                                                        |

## Metrics

| Complexity | Lines | Branches | Name                   |
| :--------- | :---- | :------- | :--------------------- |
| 1          | 100   | 100      | `BuildXPathExpression` |
| 1          | 100   | 100      | `Visit`                |
| 36         | 96.29 | 97.22    | `Visit`                |
| 1          | 100   | 100      | `Visit`                |
| 1          | 100   | 100      | `Visit`                |
| 2          | 100   | 50.0     | `Visit`                |
| 1          | 100   | 100      | `Visit`                |
| 1          | 100   | 100      | `Visit`                |
| 4          | 100   | 100      | `Visit`                |
| 4          | 83.33 | 75.00    | `Visit`                |
| 2          | 100   | 50.0     | `Visit`                |
| 2          | 100   | 100      | `Visit`                |
| 12         | 69.23 | 66.66    | `Visit`                |
| 1          | 100   | 100      | `Visit`                |
| 4          | 85.71 | 75.00    | `Visit`                |
| 6          | 100   | 100      | `Visit`                |
| 1          | 100   | 100      | `Visit`                |
| 7          | 70.0  | 57.14    | `Visit`                |
| 4          | 66.66 | 25.00    | `Visit`                |
| 1          | 100   | 100      | `Visit`                |
| 1          | 100   | 100      | `Visit`                |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\XPath\XPathExpressionBuilder.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.PathSegments;
〰2:   using System;
〰3:   using System.Linq;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Xml.XPath
〰6:   {
〰7:       public class XPathExpressionBuilder
〰8:       {
✔9:           public string BuildXPathExpression(IPathSegment path) => Visit(path);
✔10:          public string Visit(IPathSegment path) => Visit(path, null);
〰11:  
〰12:          public string Visit(IPathSegment path, IPathSegment? parent) =>
⚠13:              path switch
✔14:              {
✔15:                  LogicBinaryOperationPathSegment segment => Visit(segment, parent),
✔16:                  RelationBinaryOperationPathSegment segment => Visit(segment, parent),
✔17:                  BinaryPathSegment segment => Visit(segment, parent),
✔18:  
✔19:                  LogicOperationTypePathSegment segment => Visit(segment, parent),
✔20:                  RelationalOperationTypePathSegment segment => Visit(segment, parent),
✔21:                  PathBaseTypePathSegment segment => Visit(segment, parent),
✔22:  
✔23:                  IndexerPathSegment segment => Visit(segment, parent),
✔24:                  PathExistsPathSegment segment => Visit(segment, parent),
✔25:                  PredicatePathSegment segment => Visit(segment, parent),
✔26:                  RangePathSegment segment => Visit(segment, parent),
✔27:                  SetPathSegment segment => Visit(segment, parent),
✔28:  
✔29:                  QuotedStringPathSegment segment => Visit(segment, parent),
✔30:                  DecimalPathSegment segment => Visit(segment, parent),
✔31:                  FunctionPathSegment segment => Visit(segment, parent),
✔32:                  NumericPathSegment segment => Visit(segment, parent),
✔33:                  StringPathSegment segment => Visit(segment, parent),
✔34:  
✔35:                  DescendantsPathSegment segment => Visit(segment, parent),
✔36:                  WildcardPathSegment segment => Visit(segment, parent),
✔37:  
‼38:                  _ => throw new NotSupportedException($"{path} not supported")
✔39:              };
〰40:  
✔41:          private string Visit(WildcardPathSegment segment, IPathSegment? parent) => "*";
✔42:          private string Visit(DescendantsPathSegment segment, IPathSegment? parent) => "descendant::";
⚠43:          private string Visit(StringPathSegment segment, IPathSegment? parent) => $"{segment.Value}";
✔44:          private string Visit(NumericPathSegment segment, IPathSegment? parent) => $"{segment.Value + 1}";
✔45:          private string Visit(DecimalPathSegment segment, IPathSegment? parent) => $"{segment.Value}";
✔46:          private string Visit(QuotedStringPathSegment segment, IPathSegment? parent) => parent switch
✔47:          {
✔48:              RelationBinaryOperationPathSegment _ => $"'{segment.Value}'",
✔49:              FunctionPathSegment _ => $"'{segment.Value}'",
✔50:              _ => $"local-name()='{segment.Value}'"
✔51:          };
〰52:          private string Visit(PathBaseTypePathSegment segment, IPathSegment? parent) =>
⚠53:              segment.Value switch
✔54:              {
✔55:                  PathBaseTypes.Root => "/",
✔56:                  PathBaseTypes.Relative => "./",
‼57:                  _ => throw new NotSupportedException($"{segment}")
✔58:              };
⚠59:          private string Visit(SetPathSegment segment, IPathSegment? parent) => $"{ string.Join(" or ", segment.Set.Select(i => Visit(i, segment)))}";
〰60:          private string Visit(IndexerPathSegment segment, IPathSegment? parent) =>
✔61:             segment.Child switch
✔62:             {
✔63:                 WildcardPathSegment wild => Visit(wild, segment),
✔64:                 _ => $"*[{Visit(segment.Child, segment)}]"
✔65:             };
〰66:          private string Visit(BinaryPathSegment segment, IPathSegment? parent) =>
⚠67:              Visit(segment.Left, segment) switch
✔68:              {
‼69:                  null => Visit(segment.Right, segment),
‼70:                  string left when string.IsNullOrWhiteSpace(left) => Visit(segment.Right, segment),
✔71:                  string left => Visit(segment.Right, segment) switch
✔72:                  {
‼73:                      null => left,
‼74:                      string right when string.IsNullOrWhiteSpace(right) => left,
✔75:                      string right when new[] { '[', '/' }.Contains(right[0]) => left + right,
✔76:                      string right when new[] { ':', '/' }.Contains(left[^1]) => left + right,
✔77:                      string right => left + '/' + right
✔78:                  }
✔79:              };
✔80:          private string Visit(PredicatePathSegment segment, IPathSegment? parent) => $"[{Visit(segment.Child, segment)}]";
〰81:  
〰82:          private string Visit(FunctionPathSegment segment, IPathSegment? parent) =>
⚠83:              $@"{Visit(segment.Name, segment)}({
✔84:                  segment.Parameters switch
✔85:                  {
‼86:                      null => "",
✔87:                      SetPathSegment set => string.Join(",", set.Set.Select(i => Visit(i, segment))),
✔88:                      IPathSegment parameter => Visit(parameter, segment)
✔89:                  }})";
〰90:  
〰91:          private string Visit(RangePathSegment segment, IPathSegment? parent) =>
✔92:              string.Join(" and ",
✔93:                  new[] {
✔94:                      segment.Start != null ? $"position() >= {segment.Start.Value + 1}" : null,
✔95:                      segment.End != null ? $"position() <= {segment.End.Value + 1}" : null,
✔96:                      segment.Step != null ? $"(position() mod {segment.Step.Value})=0" : null,
✔97:                  }.Where(i => !string.IsNullOrWhiteSpace(i)));
〰98:  
✔99:          private string Visit(PathExistsPathSegment segment, IPathSegment? parent) => Visit(segment.Value, parent);
〰100: 
〰101:         private string Visit(RelationalOperationTypePathSegment segment, IPathSegment? parent) =>
⚠102:             segment.Value switch
✔103:             {
✔104:                 RelationalOperationTypes.Equal => "=",
✔105:                 RelationalOperationTypes.GreaterThan => "&gt;",
‼106:                 RelationalOperationTypes.GreaterThanOrEqual => "&gt;=",
✔107:                 RelationalOperationTypes.LessThan => "&lt;",
✔108:                 RelationalOperationTypes.LessThanOrEqual => "&lt;=",
‼109:                 RelationalOperationTypes.NotEqual => "!=",
‼110:                 _ => throw new ApplicationException(segment.Value.ToString())
✔111:             };
〰112: 
〰113:         private string Visit(LogicOperationTypePathSegment segment, IPathSegment? parent) =>
⚠114:             segment.Value switch
✔115:             {
✔116:                 LogicOperationTypes.And => "and",
‼117:                 LogicOperationTypes.Or => "or",
‼118:                 _ => throw new ApplicationException(segment.Value.ToString())
✔119:             };
〰120: 
〰121:         private string Visit(RelationBinaryOperationPathSegment segment, IPathSegment? parent) =>
✔122:             $@"{Visit(segment.Left, segment)} {Visit(segment.Operator, segment)} {Visit(segment.Right, segment)}";
〰123: 
〰124:         private string Visit(LogicBinaryOperationPathSegment segment, IPathSegment? parent) =>
✔125:             $@"{Visit(segment.Left, segment)} {Visit(segment.Operator, segment)} {Visit(segment.Right, segment)}";
〰126:     }
〰127: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

