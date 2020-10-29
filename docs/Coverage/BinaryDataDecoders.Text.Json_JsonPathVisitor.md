
# BinaryDataDecoders.Text.Json.JsonPath.Parser.JsonPathVisitor
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.Text.Json_JsonPathVisitor.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.Text.Json.JsonPath.Parser.JsonPathVisitor | 
| Assembly             | BinaryDataDecoders.Text.Json                                 | 
| Coveredlines         | 116                                                          | 
| Uncoveredlines       | 8                                                            | 
| Coverablelines       | 124                                                          | 
| Totallines           | 160                                                          | 
| Linecoverage         | 93.5                                                         | 
| Coveredbranches      | 105                                                          | 
| Totalbranches        | 138                                                          | 
| Branchcoverage       | 76                                                           | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Text.Json\JsonPath\Parser\JsonPathVisitor.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 2          | 100   | 50.0     | VisitStart | 
| 6          | 100   | 66.66    | VisitPath | 
| 1          | 100   | 100      | VisitPathBase | 
| 1          | 100   | 100      | VisitIdentity | 
| 6          | 80.0  | 66.66    | VisitOperand | 
| 1          | 100   | 100      | VisitString | 
| 1          | 100   | 100      | VisitSequenceItem | 
| 4          | 88.88 | 75.00    | VisitSequence | 
| 6          | 100   | 83.33    | VisitBracket | 
| 6          | 100   | 50.0     | VisitQueryRelational | 
| 6          | 100   | 50.0     | VisitQueryLogical | 
| 2          | 100   | 50.0     | VisitQueryPath | 
| 1          | 100   | 100      | VisitRange | 
| 2          | 100   | 50.0     | VisitFilter | 
| 4          | 100   | 75.00    | VisitFunction | 
| 2          | 100   | 50.0     | VisitFunctionParameter | 
| 2          | 100   | 100      | Visit | 
| 4          | 100   | 100      | Visit | 
| 6          | 100   | 50.0     | Visit | 
| 6          | 100   | 33.33    | VisitTerminal | 
| 2          | 100   | 100      | Visit | 
| 64         | 85.18 | 89.06    | Visit | 
| 1          | 100   | 100      | Visit | 
| 1          | 100   | 100      | Visit | 
| 1          | 100   | 100      | Visit | 
| 8          | 90.0  | 75.00    | Visit | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Text.Json\JsonPath\Parser\JsonPathVisitor.cs

```CSharp
〰1:   using Antlr4.Runtime;
〰2:   using Antlr4.Runtime.Misc;
〰3:   using Antlr4.Runtime.Tree;
〰4:   using BinaryDataDecoders.ToolKit.PathSegments;
〰5:   using System.Collections.Generic;
〰6:   using System.Data;
〰7:   using System.Linq;
〰8:   
〰9:   namespace BinaryDataDecoders.Text.Json.JsonPath.Parser
〰10:  {
〰11:      public class JsonPathVisitor : JsonPathBaseVisitor<IPathSegment?>
〰12:      {
〰13:          public override IPathSegment VisitStart([NotNull] JsonPathParser.StartContext context) =>
⚠14:              Visit(context.path()) ?? throw new JsonPathException("no path defined");
〰15:          public override IPathSegment VisitPath([NotNull] JsonPathParser.PathContext context) =>
✔16:              Visit(context.function()) switch
✔17:              {
⚠18:                  null => new BinaryPathSegment(
✔19:                  Visit<PathBaseTypes>(context.pathBase()) ?? throw new JsonPathException("missing pathBase"),
✔20:                  Visit(context.sequence()) ?? throw new JsonPathException("missing path sequence")
✔21:                  ),
✔22:                  IPathSegment function => function
✔23:              };
〰24:          public override IPathSegment? VisitPathBase([NotNull] JsonPathParser.PathBaseContext context) =>
✔25:              Visit<PathBaseTypes>(context.ROOT(), context.RELATIVE());
〰26:          public override IPathSegment? VisitIdentity([NotNull] JsonPathParser.IdentityContext context) =>
✔27:              Visit(context.IDENTITY());
〰28:          public override IPathSegment? VisitOperand([NotNull] JsonPathParser.OperandContext context) =>
⚠29:              Visit(
✔30:                  context.path(),
✔31:                  context.@string()
✔32:                  ) ??
✔33:                  Visit(context.NUMBER()) switch
✔34:                  {
‼35:                      null => null,
✔36:                      NumericPathSegment number => new DecimalPathSegment(number.Value),
‼37:                      IPathSegment passThough => passThough
✔38:                  };
〰39:          public override IPathSegment? VisitString([NotNull] JsonPathParser.StringContext context) =>
✔40:              Visit(context.QUOTED_STRING());
〰41:          public override IPathSegment? VisitSequenceItem([NotNull] JsonPathParser.SequenceItemContext context) =>
✔42:              Visit(
✔43:                  context.WILDCARD(),
✔44:                  context.identity(),
✔45:                  context.bracket(),
✔46:                  context.filter(),
✔47:                  context.function(),
✔48:                  context.DESCENDANTS()
✔49:                  );
〰50:          public override IPathSegment VisitSequence([NotNull] JsonPathParser.SequenceContext context) =>
⚠51:              Visit(context.sequenceItem()) switch
✔52:              {
‼53:                  null => throw new JsonPathException("no path segment defined"),
✔54:                  IPathSegment left => Visit(context.sequence()) switch
✔55:                  {
✔56:                      null => left,
✔57:                      IPathSegment right => new BinaryPathSegment(left, right)
✔58:                  }
✔59:              };
〰60:          public override IPathSegment VisitBracket([NotNull] JsonPathParser.BracketContext context) =>
⚠61:              new IndexerPathSegment(
✔62:                  Visit(context.WILDCARD(), context.range(), context.function()) ??
✔63:                  Visit(context.NUMBER()) ??
✔64:                  Visit(context.@string()) ??
✔65:                  throw new JsonPathException($"Invalid bracket content: {context.GetText()}")
✔66:              );
〰67:          public override IPathSegment VisitQueryRelational([NotNull] JsonPathParser.QueryRelationalContext context) =>
⚠68:              new RelationBinaryOperationPathSegment(
✔69:                  left: Visit(context.relationLeft) ?? throw new JsonPathException("no left operand defined"),
✔70:                  @operator: Visit<RelationalOperationTypes>(context.RELATIONAL()) ?? throw new JsonPathException("no relational operator defined"),
✔71:                  right: Visit(context.relationRight) ?? throw new JsonPathException("no right operand defined")
✔72:                  );
〰73:          public override IPathSegment VisitQueryLogical([NotNull] JsonPathParser.QueryLogicalContext context) =>
⚠74:              new LogicBinaryOperationPathSegment(
✔75:                  left: Visit(context.relationLeft) ?? throw new JsonPathException("no left operand defined"),
✔76:                  @operator: Visit<LogicOperationTypes>(context.LOGICAL()) ?? throw new JsonPathException("no logical operator defined"),
✔77:                  right: Visit(context.relationRight) ?? throw new JsonPathException("no right operand defined")
✔78:                  );
〰79:          public override IPathSegment VisitQueryPath([NotNull] JsonPathParser.QueryPathContext context) =>
⚠80:              new PathExistsPathSegment(
✔81:                      (Visit(context.path()) as BinaryPathSegment) ?? throw new JsonPathException("Invalid reference path")
✔82:                  );
〰83:          public override IPathSegment VisitRange([NotNull] JsonPathParser.RangeContext context) =>
✔84:              new RangePathSegment(
✔85:                  start: Visit<int>(context.rangeStart),
✔86:                  end: Visit<int>(context.rangeEnd),
✔87:                  step: Visit<int>(context.rangeStep)
✔88:                  );
〰89:          public override IPathSegment VisitFilter([NotNull] JsonPathParser.FilterContext context) =>
⚠90:              new PredicatePathSegment(
✔91:                  Visit(context.query()) ?? throw new JsonPathException("invalid query")
✔92:                  );
〰93:          public override IPathSegment VisitFunction([NotNull] JsonPathParser.FunctionContext context) =>
⚠94:              new FunctionPathSegment(
✔95:                  Visit(context.identity()) ?? throw new JsonPathException($"Unnamed functions are not allowed: {context.GetText()}"),
✔96:                  Visit(context.functionParameter()) ?? SetPathSegment.Empty
✔97:                  );
〰98:          public override IPathSegment VisitFunctionParameter([NotNull] JsonPathParser.FunctionParameterContext context) =>
⚠99:              Visit(
✔100:                 context.operand(),
✔101:                 context.pathBase(),
✔102:                 context.DECIMAL()
✔103:                 ) ?? throw new JsonPathException($"Invalid function parameter type");
〰104: 
✔105:         public override IPathSegment? Visit(IParseTree tree) => tree switch { null => null, _ => base.Visit(tree) };
〰106:         public virtual IPathSegment? Visit(IParseTree first, IParseTree second, params IParseTree[] more) =>
✔107:             Visit(first) ?? Visit(second) ?? more.Select(Visit).Where(l => l != null).FirstOrDefault();
〰108:         public virtual IPathSegment<T>? Visit<T>(IParseTree first, IParseTree second, params IParseTree[] more) =>
⚠109:             Visit(first) as IPathSegment<T> ??
✔110:             Visit(second) as IPathSegment<T> ??
✔111:             more.Select(i => Visit(i) as IPathSegment<T>)
✔112:                 .Where(i => i != null)
✔113:                 .FirstOrDefault();
〰114:         public override IPathSegment VisitTerminal(ITerminalNode node) =>
⚠115:             Visit(node?.GetText()) ?? throw new JsonPathException($"invalid terminal node \"{node?.GetText()}\"");
✔116:         public virtual IPathSegment? Visit(IToken token) => Visit(token?.Text);
〰117:         public virtual IPathSegment? Visit(string? value) =>
⚠118:             value switch
✔119:             {
✔120:                 null => null,
✔121: 
✔122:                 ".." => new DescendantsPathSegment(),
✔123:                 "*" => new WildcardPathSegment(),
✔124:                 //Note: hidden terminal "." => new PathSeperatorPathSegment(),
✔125: 
✔126:                 "$" => new PathBaseTypePathSegment(PathBaseTypes.Root),
✔127:                 "@" => new PathBaseTypePathSegment(PathBaseTypes.Relative),
✔128: 
✔129:                 "==" => new RelationalOperationTypePathSegment(RelationalOperationTypes.Equal),
‼130:                 "!=" => new RelationalOperationTypePathSegment(RelationalOperationTypes.NotEqual),
✔131:                 "<" => new RelationalOperationTypePathSegment(RelationalOperationTypes.LessThan),
✔132:                 "<=" => new RelationalOperationTypePathSegment(RelationalOperationTypes.LessThanOrEqual),
✔133:                 ">" => new RelationalOperationTypePathSegment(RelationalOperationTypes.GreaterThan),
‼134:                 ">=" => new RelationalOperationTypePathSegment(RelationalOperationTypes.GreaterThanOrEqual),
✔135: 
✔136:                 "&&" => new LogicOperationTypePathSegment(LogicOperationTypes.And),
‼137:                 "||" => new LogicOperationTypePathSegment(LogicOperationTypes.Or),
✔138: 
‼139:                 _ when value.Length == 0 => new StringPathSegment(""),
✔140:                 _ when value[0] == '\'' => new QuotedStringPathSegment(value.Trim('\'')),
✔141:                 _ when int.TryParse(value, out var number) => new NumericPathSegment(number),
✔142:                 _ when decimal.TryParse(value, out var number) => new DecimalPathSegment(number),
✔143:                 _ => new StringPathSegment(value)
✔144:             };
✔145:         public virtual IPathSegment<T>? Visit<T>(ITerminalNode node) => Visit(node) as IPathSegment<T>;
✔146:         public virtual IPathSegment<T>? Visit<T>(IToken token) => Visit(token) as IPathSegment<T>;
✔147:         public virtual IPathSegment<T>? Visit<T>(IParseTree tree) => Visit(tree) as IPathSegment<T>;
〰148:         public virtual IPathSegment? Visit(IEnumerable<IParseTree> trees) =>
⚠149:             trees?.Select(Visit).Where(i => i != null).Cast<IPathSegment>() switch
✔150:             {
‼151:                 null => null,
✔152:                 IEnumerable<IPathSegment> path => path.Count() switch
✔153:                 {
✔154:                     0 => null,
✔155:                     1 => path.First(),
✔156:                     _ => new SetPathSegment(path)
✔157:                 }
✔158:             };
〰159:     }
〰160: }

```
## Footer 
[Return to Summary](Summary.md)

