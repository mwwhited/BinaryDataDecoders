# Assembly - BinaryDataDecoders.ExpressionCalculator

## Type - BinaryDataDecoders.ExpressionCalculator.Optimizers.InnerExpressionReducer`1

*summary*
this will remove extra wraps around the entire expression
            ((a)+(b)) => a+b

*typeparam*


| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | T                                                            | 

## Type - IExpressionTreeVisitor`1

*summary*
This interface defines a complete generic visitor for a parse tree produced
            by

*typeparam*
The return type of the visit operation.

| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | Result                                                       | 

### Method - VisitExpression(ExpressionTreeParser.ExpressionContext)

*summary*
Visit a parse tree produced by

*param*
The parse tree.

| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | context                                                      | 

*return*
The visitor result.

### Method - VisitInnerExpression(ExpressionTreeParser.InnerExpressionContext)

*summary*
Visit a parse tree produced by

*param*
The parse tree.

| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | context                                                      | 

*return*
The visitor result.

### Method - VisitStart(ExpressionTreeParser.StartContext)

*summary*
Visit a parse tree produced by

*param*
The parse tree.

| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | context                                                      | 

*return*
The visitor result.

### Method - VisitUnaryOperatorLeftExpression(ExpressionTreeParser.UnaryOperatorLeftExpressionContext)

*summary*
Visit a parse tree produced by

*param*
The parse tree.

| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | context                                                      | 

*return*
The visitor result.

### Method - VisitUnaryOperatorRightExpression(ExpressionTreeParser.UnaryOperatorRightExpressionContext)

*summary*
Visit a parse tree produced by

*param*
The parse tree.

| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | context                                                      | 

*return*
The visitor result.

### Method - VisitValue(ExpressionTreeParser.ValueContext)

*summary*
Visit a parse tree produced by

*param*
The parse tree.

| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | context                                                      | 

*return*
The visitor result.

## Type - ExpressionTreeBaseVisitor`1

*summary*
This class provides an empty implementation of

*typeparam*
The return type of the visit operation.

| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | Result                                                       | 

### Method - VisitExpression(ExpressionTreeParser.ExpressionContext)

*summary*
Visit a parse tree produced by

*param*
The parse tree.

| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | context                                                      | 

*return*
The visitor result.

### Method - VisitInnerExpression(ExpressionTreeParser.InnerExpressionContext)

*summary*
Visit a parse tree produced by

*param*
The parse tree.

| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | context                                                      | 

*return*
The visitor result.

### Method - VisitStart(ExpressionTreeParser.StartContext)

*summary*
Visit a parse tree produced by

*param*
The parse tree.

| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | context                                                      | 

*return*
The visitor result.

### Method - VisitUnaryOperatorLeftExpression(ExpressionTreeParser.UnaryOperatorLeftExpressionContext)

*summary*
Visit a parse tree produced by

*param*
The parse tree.

| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | context                                                      | 

*return*
The visitor result.

### Method - VisitUnaryOperatorRightExpression(ExpressionTreeParser.UnaryOperatorRightExpressionContext)

*summary*
Visit a parse tree produced by

*param*
The parse tree.

| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | context                                                      | 

*return*
The visitor result.

### Method - VisitValue(ExpressionTreeParser.ValueContext)

*summary*
Visit a parse tree produced by

*param*
The parse tree.

| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | context                                                      | 

*return*
The visitor result.

