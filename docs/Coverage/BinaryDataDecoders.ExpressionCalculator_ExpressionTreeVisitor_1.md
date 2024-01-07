# BinaryDataDecoders.ExpressionCalculator.Visitors.ExpressionTreeVisitor`1

## Summary

| Key             | Value                                                                      |
| :-------------- | :------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ExpressionCalculator.Visitors.ExpressionTreeVisitor`1` |
| Assembly        | `BinaryDataDecoders.ExpressionCalculator`                                  |
| Coveredlines    | `40`                                                                       |
| Uncoveredlines  | `6`                                                                        |
| Coverablelines  | `46`                                                                       |
| Totallines      | `107`                                                                      |
| Linecoverage    | `86.9`                                                                     |
| Coveredbranches | `20`                                                                       |
| Totalbranches   | `34`                                                                       |
| Branchcoverage  | `58.8`                                                                     |
| Coveredmethods  | `11`                                                                       |
| Totalmethods    | `12`                                                                       |
| Methodcoverage  | `91.6`                                                                     |

## Metrics

| Complexity | Lines | Branches | Name                                |
| :--------- | :---- | :------- | :---------------------------------- |
| 1          | 100   | 100      | `cctor`                             |
| 2          | 100   | 50.0     | `VisitStart`                        |
| 1          | 0     | 100      | `VisitErrorNode`                    |
| 10         | 100   | 80.0     | `VisitExpression`                   |
| 1          | 100   | 100      | `VisitInnerExpression`              |
| 4          | 100   | 75.00    | `VisitValue`                        |
| 2          | 100   | 50.0     | `VisitVariable`                     |
| 4          | 100   | 75.00    | `VisitNumber`                       |
| 1          | 100   | 100      | `VisitUnaryOperatorLeftExpression`  |
| 1          | 100   | 100      | `VisitUnaryOperatorRightExpression` |
| 4          | 100   | 75.00    | `ChainVisit`                        |
| 8          | 28.57 | 12.50    | `EnsureChildCount`                  |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ExpressionCalculator/Parser/ExpressionTreeVisitor.cs

```CSharp
〰1:   using Antlr4.Runtime;
〰2:   using Antlr4.Runtime.Misc;
〰3:   using Antlr4.Runtime.Tree;
〰4:   using BinaryDataDecoders.ExpressionCalculator.Evaluators;
〰5:   using BinaryDataDecoders.ExpressionCalculator.Expressions;
〰6:   using System;
〰7:   using System.Linq;
〰8:   
〰9:   namespace BinaryDataDecoders.ExpressionCalculator.Visitors;
〰10:  
〰11:  public class ExpressionTreeVisitor<T> : ExpressionTreeBaseVisitor<ExpressionBase<T>>
〰12:      where T : struct, IComparable<T>, IEquatable<T>
〰13:  {
✔14:      private static readonly IExpressionEvaluator<T> _evaluator = ExpressionEvaluatorFactory.Create<T>();
〰15:  
〰16:      public override ExpressionBase<T> VisitStart([NotNull] ExpressionTreeParser.StartContext context)
〰17:      {
⚠18:          var entryPoint = Visit(context.expression()) ??
✔19:              throw new NotSupportedException($"No expression parsed: \"{context.GetText()}\"");
✔20:          EnsureChildCount(context, expected: "Expected <EOF>");
✔21:          return entryPoint;
〰22:      }
〰23:  
〰24:      public override ExpressionBase<T> VisitErrorNode(IErrorNode node) =>
‼25:          throw new NotSupportedException(node.ToString());
〰26:  
〰27:      public override ExpressionBase<T> VisitExpression([NotNull] ExpressionTreeParser.ExpressionContext context)
〰28:      {
✔29:          var op = context.@operator?.Text.AsBinaryOperators();
✔30:          if (op.HasValue && op.Value != BinaryOperators.Unknown)
〰31:          {
⚠32:              return new BinaryOperatorExpression<T>(
✔33:                  Visit(context.left) ?? throw new NotSupportedException($"Missing Left Expression: {context.GetText()}"),
✔34:                  op.Value,
✔35:                  Visit(context.right) ?? throw new NotSupportedException($"Missing Right Expression: {context.GetText()}")
✔36:                  );
〰37:          }
〰38:  
✔39:          return base.VisitExpression(context);
〰40:      }
〰41:  
〰42:      public override ExpressionBase<T> VisitInnerExpression([NotNull] ExpressionTreeParser.InnerExpressionContext context) =>
✔43:          new InnerExpression<T>(Visit(context.inner));
〰44:  
〰45:  
〰46:      public override ExpressionBase<T> VisitValue([NotNull] ExpressionTreeParser.ValueContext context)
〰47:      {
⚠48:          var result = VisitNumber(context.NUMBER()) ??
✔49:           VisitVariable(context.VARIABLE()) ??
✔50:               throw new NotSupportedException($"Unable to parse \"{context.GetText()}\"")
✔51:           ;
✔52:          EnsureChildCount(context, expected: $"Expected {nameof(context.NUMBER)}|{nameof(context.VARIABLE)}", childCount: 1);
〰53:  
✔54:          return result;
〰55:      }
〰56:  
〰57:      private ExpressionBase<T>? VisitVariable(ITerminalNode node) =>
⚠58:          node != null ? new VariableExpression<T>(node.GetText()) : null;
〰59:  
〰60:      private ExpressionBase<T>? VisitNumber(ITerminalNode node) =>
⚠61:          node != null ? new NumberExpression<T>(
✔62:              _evaluator.TryParse(node.GetText()) ??
✔63:              throw new NotSupportedException($"Unable to parse \"{node.GetText()}\" to type \"{typeof(T)}\"")
✔64:              ) : null;
〰65:  
〰66:      public override ExpressionBase<T> VisitUnaryOperatorLeftExpression([NotNull] ExpressionTreeParser.UnaryOperatorLeftExpressionContext context)
〰67:      {
✔68:          var result = new UnaryOperatorExpression<T>(
✔69:              context.@operator.Text.AsUnaryOperator(),
✔70:              ChainVisit(context.value(), context.innerExpression(), context.unaryOperatorLeftExpression())
✔71:              );
✔72:          EnsureChildCount(context, expected: $"Expected {nameof(context.value)}|{nameof(context.innerExpression)}|{nameof(context.unaryOperatorLeftExpression)}");
✔73:          return result;
〰74:      }
〰75:      public override ExpressionBase<T> VisitUnaryOperatorRightExpression([NotNull] ExpressionTreeParser.UnaryOperatorRightExpressionContext context)
〰76:      {
✔77:          var result = new UnaryOperatorExpression<T>(
✔78:                 context.@operator.Text.AsUnaryOperator(),
✔79:                 ChainVisit(context.value(), context.innerExpression(), context.unaryOperatorRightExpression())
✔80:                 );
✔81:          EnsureChildCount(context, expected: $"Expected {nameof(context.value)}|{nameof(context.innerExpression)}|{nameof(context.unaryOperatorRightExpression)}");
✔82:          return result;
〰83:      }
〰84:  
〰85:      private ExpressionBase<T> ChainVisit(params IParseTree[] nodes) =>
⚠86:          Visit(nodes.FirstOrDefault(n => n != null) ?? throw new NotSupportedException($"No non-null node provided"));
〰87:  
〰88:      private TParserRuleContext EnsureChildCount<TParserRuleContext>(TParserRuleContext context, string? expected = null, int childCount = 2)
〰89:          where TParserRuleContext : ParserRuleContext
〰90:      {
⚠91:          if (context.children.Count != childCount)
〰92:          {
‼93:              var extraChildren = context.children.Skip(1).Take(context.children.Count - childCount);
‼94:              var extras = string.Join(";", extraChildren.Select(c => c.GetText()));
〰95:  
‼96:              if (string.IsNullOrWhiteSpace(extras))
〰97:              {
‼98:                  throw new NotSupportedException($"Missing Expression");
〰99:              }
〰100:             else
〰101:             {
‼102:                 throw new NotSupportedException(string.Join(", ", new[] { expected, $"Found: {extras}" }.Where(s => !string.IsNullOrWhiteSpace(s))));
〰103:             }
〰104:         }
✔105:         return context;
〰106:     }
〰107: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

