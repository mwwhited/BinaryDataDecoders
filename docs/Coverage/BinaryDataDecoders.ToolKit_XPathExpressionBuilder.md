
# BinaryDataDecoders.ToolKit.Xml.XPath.XPathExpressionBuilder
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_XPathExpressionBuilder.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.Xml.XPath.XPathExpressionBuilder  | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 86                                                           | 
| Uncoveredlines       | 12                                                           | 
| Coverablelines       | 98                                                           | 
| Totallines           | 133                                                          | 
| Linecoverage         | 87.7                                                         | 
| Coveredbranches      | 68                                                           | 
| Totalbranches        | 83                                                           | 
| Branchcoverage       | 81.9                                                         | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\XPath\XPathExpressionBuilder.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 100   | 100      | BuildXPathExpression | 
| 1          | 100   | 100      | Visit | 
| 36         | 96.29 | 97.22    | Visit | 
| 1          | 100   | 100      | Visit | 
| 1          | 100   | 100      | Visit | 
| 2          | 100   | 50.0     | Visit | 
| 1          | 100   | 100      | Visit | 
| 1          | 100   | 100      | Visit | 
| 4          | 100   | 100      | Visit | 
| 4          | 83.33 | 75.00    | Visit | 
| 2          | 100   | 50.0     | Visit | 
| 2          | 100   | 100      | Visit | 
| 12         | 69.23 | 66.66    | Visit | 
| 1          | 100   | 100      | Visit | 
| 4          | 85.71 | 75.00    | Visit | 
| 6          | 100   | 100      | Visit | 
| 1          | 100   | 100      | Visit | 
| 7          | 70.0  | 57.14    | Visit | 
| 4          | 66.66 | 25.00    | Visit | 
| 1          | 100   | 100      | Visit | 
| 1          | 100   | 100      | Visit | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\XPath\XPathExpressionBuilder.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.PathSegments;
〰2:   using System;
〰3:   using System.Collections.Generic;
〰4:   using System.IO;
〰5:   using System.Linq;
〰6:   using System.Text;
〰7:   using System.Xml.XPath;
〰8:   
〰9:   namespace BinaryDataDecoders.ToolKit.Xml.XPath
〰10:  {
〰11:      public class XPathExpressionBuilder
〰12:      {
✔13:          public string BuildXPathExpression(IPathSegment path) => Visit(path);
✔14:          public string Visit(IPathSegment path) => Visit(path, null);
〰15:  
〰16:          public string Visit(IPathSegment path, IPathSegment? parent) =>
⚠17:              path switch
✔18:              {
✔19:                  LogicBinaryOperationPathSegment segment => Visit(segment, parent),
✔20:                  RelationBinaryOperationPathSegment segment => Visit(segment, parent),
✔21:                  BinaryPathSegment segment => Visit(segment, parent),
✔22:  
✔23:                  LogicOperationTypePathSegment segment => Visit(segment, parent),
✔24:                  RelationalOperationTypePathSegment segment => Visit(segment, parent),
✔25:                  PathBaseTypePathSegment segment => Visit(segment, parent),
✔26:  
✔27:                  IndexerPathSegment segment => Visit(segment, parent),
✔28:                  PathExistsPathSegment segment => Visit(segment, parent),
✔29:                  PredicatePathSegment segment => Visit(segment, parent),
✔30:                  RangePathSegment segment => Visit(segment, parent),
✔31:                  SetPathSegment segment => Visit(segment, parent),
✔32:  
✔33:                  QuotedStringPathSegment segment => Visit(segment, parent),
✔34:                  DecimalPathSegment segment => Visit(segment, parent),
✔35:                  FunctionPathSegment segment => Visit(segment, parent),
✔36:                  NumericPathSegment segment => Visit(segment, parent),
✔37:                  StringPathSegment segment => Visit(segment, parent),
✔38:  
✔39:                  DescendantsPathSegment segment => Visit(segment, parent),
✔40:                  WildcardPathSegment segment => Visit(segment, parent),
✔41:  
‼42:                  _ => throw new NotSupportedException($"{path} not supported")
✔43:              };
〰44:  
✔45:          private string Visit(WildcardPathSegment segment, IPathSegment? parent) => "*";
✔46:          private string Visit(DescendantsPathSegment segment, IPathSegment? parent) => "descendant::";
⚠47:          private string Visit(StringPathSegment segment, IPathSegment? parent) => $"{segment.Value}";
✔48:          private string Visit(NumericPathSegment segment, IPathSegment? parent) => $"{segment.Value + 1}";
✔49:          private string Visit(DecimalPathSegment segment, IPathSegment? parent) => $"{segment.Value}";
✔50:          private string Visit(QuotedStringPathSegment segment, IPathSegment? parent) => parent switch
✔51:          {
✔52:              RelationBinaryOperationPathSegment _ => $"'{segment.Value}'",
✔53:              FunctionPathSegment _ => $"'{segment.Value}'",
✔54:              _ => $"local-name()='{segment.Value}'"
✔55:          };
〰56:          private string Visit(PathBaseTypePathSegment segment, IPathSegment? parent) =>
⚠57:              segment.Value switch
✔58:              {
✔59:                  PathBaseTypes.Root => "/",
✔60:                  PathBaseTypes.Relative => "./",
‼61:                  _ => throw new NotSupportedException($"{segment}")
✔62:              };
⚠63:          private string Visit(SetPathSegment segment, IPathSegment? parent) => $"{ string.Join(" or ", segment.Set.Select(i => Visit(i, segment)))}";
〰64:          private string Visit(IndexerPathSegment segment, IPathSegment? parent) =>
✔65:             segment.Child switch
✔66:             {
✔67:                 WildcardPathSegment wild => Visit(wild, segment),
✔68:                 _ => $"*[{Visit(segment.Child, segment)}]"
✔69:             };
〰70:          private string Visit(BinaryPathSegment segment, IPathSegment? parent) =>
⚠71:              Visit(segment.Left, segment) switch
✔72:              {
‼73:                  null => Visit(segment.Right, segment),
‼74:                  string left when string.IsNullOrWhiteSpace(left) => Visit(segment.Right, segment),
✔75:                  string left => Visit(segment.Right, segment) switch
✔76:                  {
‼77:                      null => left,
‼78:                      string right when string.IsNullOrWhiteSpace(right) => left,
✔79:                      string right when new[] { '[', '/' }.Contains(right[0]) => left + right,
✔80:                      string right when new[] { ':', '/' }.Contains(left[^1]) => left + right,
✔81:                      string right => left + '/' + right
✔82:                  }
✔83:              };
✔84:          private string Visit(PredicatePathSegment segment, IPathSegment? parent) => $"[{Visit(segment.Child, segment)}]";
〰85:  
〰86:          private string Visit(FunctionPathSegment segment, IPathSegment? parent) =>
⚠87:              $@"{Visit(segment.Name, segment)}({
✔88:                  segment.Parameters switch
✔89:                  {
‼90:                      null => "",
✔91:                      SetPathSegment set => string.Join(",", set.Set.Select(i => Visit(i, segment))),
✔92:                      IPathSegment parameter => Visit(parameter, segment)
✔93:                  }})";
〰94:  
〰95:          private string Visit(RangePathSegment segment, IPathSegment? parent) =>
✔96:              string.Join(" and ",
✔97:                  new[] {
✔98:                      segment.Start != null ? $"position() >= {segment.Start.Value + 1}" : null,
✔99:                      segment.End != null ? $"position() <= {segment.End.Value + 1}" : null,
✔100:                     segment.Step != null ? $"(position() mod {segment.Step.Value})=0" : null,
✔101:                 }.Where(i => !string.IsNullOrWhiteSpace(i)));
〰102: 
〰103: 
✔104:         private string Visit(PathExistsPathSegment segment, IPathSegment? parent) => Visit(segment.Value, parent);
〰105: 
〰106:         private string Visit(RelationalOperationTypePathSegment segment, IPathSegment? parent) =>
⚠107:             segment.Value switch
✔108:             {
✔109:                 RelationalOperationTypes.Equal => "=",
✔110:                 RelationalOperationTypes.GreaterThan => "&gt;",
‼111:                 RelationalOperationTypes.GreaterThanOrEqual => "&gt;=",
✔112:                 RelationalOperationTypes.LessThan => "&lt;",
✔113:                 RelationalOperationTypes.LessThanOrEqual => "&lt;=",
‼114:                 RelationalOperationTypes.NotEqual => "!=",
‼115:                 _ => throw new ApplicationException(segment.Value.ToString())
✔116:             };
〰117: 
〰118:         private string Visit(LogicOperationTypePathSegment segment, IPathSegment? parent) =>
⚠119:             segment.Value switch
✔120:             {
✔121:                 LogicOperationTypes.And => "and",
‼122:                 LogicOperationTypes.Or => "or",
‼123:                 _ => throw new ApplicationException(segment.Value.ToString())
✔124:             };
〰125: 
〰126: 
〰127:         private string Visit(RelationBinaryOperationPathSegment segment, IPathSegment? parent) =>
✔128:             $@"{Visit(segment.Left, segment)} {Visit(segment.Operator, segment)} {Visit(segment.Right, segment)}";
〰129: 
〰130:         private string Visit(LogicBinaryOperationPathSegment segment, IPathSegment? parent) =>
✔131:             $@"{Visit(segment.Left, segment)} {Visit(segment.Operator, segment)} {Visit(segment.Right, segment)}";
〰132:     }
〰133: }

```
## Footer 
[Return to Summary](Summary.md)

