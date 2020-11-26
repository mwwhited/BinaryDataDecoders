# BinaryDataDecoders.ExpressionCalculator.Tests.Parser.UInt32ExpressionParserTests

## OptimizerTests_WithExceptions

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.2.2.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

| Outcome              | Duration    | Test Name                                            |
| :------------------- | ----------: | :--------------------------------------------------- |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests_WithExceptions`                      |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests_WithExceptions (B/0)`                |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests_WithExceptions (B%0)`                |

## VerifyOptimizerForComplexExpressions

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.2.2.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

| Outcome              | Duration    | Test Name                                            |
| :------------------- | ----------: | :--------------------------------------------------- |
| ⚠ Inconclusive       | 00:00:00.03 | `VerifyOptimizerForComplexExpressions`               |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "A"`                              |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "A*1"`                            |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "(A*B)+C"`                        |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "(A*B)"`                          |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "(A-B)/A"`                        |
| ⚠ Inconclusive       | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"` |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "((A+B+((C*D)+E))*F)+G+((D/H)*I)+J"` |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "A*(B/C)+D"`                      |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "A*B+C"`                          |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "(((A-(B*C))/D)*E)+F"`            |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "(A/B)-(C+D+E+F)"`                |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "((A*B)*C)+D"`                    |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "(((A*B)*C)*D)+E"`                |
| ⚠ Inconclusive       | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*(D*E)*F)+G"`     |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "(A*B*(C/D))+E"`                  |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "(A*(B/C)+D)"`                    |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "A+B"`                            |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "((A/B)*(C*D)*E)+F"`              |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "((A+((B*C)+D))*E)+F+(C*G)+H"`    |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "(A+((B*C)+D))*E+F+(A+((B*C)+D))*G+H"` |
| ⚠ Inconclusive       | 00:00:00.00 | `Check Expressions "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"` |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "((A*B)+C)+((D*B)+E)"`            |
| ⚠ Inconclusive       | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"` |
| ⚠ Inconclusive       | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"` |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)"` |
| ⚠ Inconclusive       | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"` |
| ⚠ Inconclusive       | 00:00:00.00 | `Check Expressions "((A*B)+C)+(-1*A)"`               |
| ⚠ Inconclusive       | 00:00:00.00 | `Check Expressions "(((A+(-1*B))+((C*D)+E))*F)+G+(D*H)+I"` |
| ⚠ Inconclusive       | 00:00:00.00 | `Check Expressions "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"` |
| ⚠ Inconclusive       | 00:00:00.00 | `Check Expressions "((A*(B+(-1*C)))+D)+((E*(B+(-1*C)))+F)"` |
| ⚠ Inconclusive       | 00:00:00.00 | `Check Expressions "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"` |
| ⚠ Inconclusive       | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"` |
| ⚠ Inconclusive       | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"` |
| ⚠ Inconclusive       | 00:00:00.00 | `Check Expressions "(((A+(-1*B))*C)+D)+(B+(-1*A))"`  |
| ⚠ Inconclusive       | 00:00:00.00 | `Check Expressions "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"` |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "((A+((B*C)+D))*E)+F+((C/G)*H)+I"` |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "(A+B)*C+D+(A+B)*E+F"`            |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "A*B"`                            |
| ⚠ Inconclusive       | 00:00:00.00 | `Check Expressions "((A+((-1*B)*(C/D)))*(E/C))+(-1*F)+G"` |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "((A/(1-B))*C)+D"`                |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "(((A-(B*C))/(1-D))*E)+F"`        |
| ⚠ Inconclusive       | 00:00:00.00 | `Check Expressions "(A*(1+(-1*B))+C)*D+E"`           |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "(A+B)*C+D"`                      |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "(((A/B)*C*D)*E*F)+G"`            |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "((A-B)*C)+D"`                    |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "((A/B)*C)+D"`                    |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "((((A*B)+C)/D)*E)+F"`            |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "((A/B)*C*D*E)+F"`                |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "(A*B*C)+D"`                      |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "(((A*B)+C)*D)+E"`                |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "(((A/B)*C*D)*E)+F"`              |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "(A*1)"`                          |
| ⚠ Inconclusive       | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*D*E*F)+G"`       |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "((A*B)+C)+(D*E*F)"`              |
| ⚠ Inconclusive       | 00:00:00.00 | `Check Expressions "((A/(1+(-1*(B+C))))*D)+E"`       |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "((A-(B*C))*D)+E"`                |
| ⚠ Inconclusive       | 00:00:00.00 | `Check Expressions "(((A+(-1*B))/C)*(D*E)*F)+G"`     |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "((A/B)*((C*D)*E)*F)+G"`          |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "((((A/B)*C)+D)*((E*F)*G))+H"`    |
| ⚠ Inconclusive       | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*((D*E)*F)*G)+H"` |
| ⚠ Inconclusive       | 00:00:00.00 | `Check Expressions "(((A+(-1*B))/C)*((D*E)*F)*G)+H"` |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "(((A/B)*(((C*D)*E)*F))+(C*D*G))+H"` |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "((A*B)+((A*C)-A)*D)+E"`          |
| ⚠ Inconclusive       | 00:00:00.00 | `Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"` |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "(((A/B)*((C*D)*E)*F)*G)+H"`      |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "((A/B)*(((C*D)*E)*F))+G"`        |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "((A/B)*((C*D)*E))+F"`            |
| ✔ Passed             | 00:00:00.00 | `Check Expressions "(A/(A+B))"`                      |
| ✔ Passed             | 00:00:00.00 | `VerifyOptimizerForComplexExpressions (A!)`          |

## OptimizerTests

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.2.2.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

| Outcome              | Duration    | Test Name                                            |
| :------------------- | ----------: | :--------------------------------------------------- |
| ⚠ Inconclusive       | 00:00:00.01 | `OptimizerTests`                                     |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests ((A),A)`                             |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests ((A+(B)),A + B)`                     |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests (B^1,B)`                             |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests (B*1,B)`                             |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests (1*B,B)`                             |
| ⚠ Inconclusive       | 00:00:00.00 | `OptimizerTests (B*-1,-B)`                           |
| ⚠ Inconclusive       | 00:00:00.00 | `OptimizerTests (-1*B,-B)`                           |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests (B/1,B)`                             |
| ⚠ Inconclusive       | 00:00:00.00 | `OptimizerTests (B/-1,-B)`                           |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests (B+0,B)`                             |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests (0+B,B)`                             |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests (B-0,B)`                             |
| ⚠ Inconclusive       | 00:00:00.00 | `OptimizerTests (0-B,-B)`                            |
| ⚠ Inconclusive       | 00:00:00.00 | `OptimizerTests (2+3*4^5%6/7-8,-6)`                  |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests (2+3,5)`                             |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests (B/B,1)`                             |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests (B%B,0)`                             |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests (B^0,1)`                             |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests (0^B,0)`                             |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests (0*B,0)`                             |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests (B*0,0)`                             |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests (0/B,0)`                             |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests (0%B,0)`                             |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests (B%1,0)`                             |
| ⚠ Inconclusive       | 00:00:00.00 | `OptimizerTests (B%-1,0)`                            |
| ⚠ Inconclusive       | 00:00:00.00 | `OptimizerTests (-(B),-B)`                           |
| ⚠ Inconclusive       | 00:00:00.00 | `OptimizerTests (-(3),-3)`                           |
| ⚠ Inconclusive       | 00:00:00.00 | `OptimizerTests (-3,-3)`                             |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests (--B,B)`                             |
| ⚠ Inconclusive       | 00:00:00.00 | `OptimizerTests (---B,-B)`                           |
| ⚠ Inconclusive       | 00:00:00.00 | `OptimizerTests (-1*(A*B),-(A * B))`                 |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests (A!,A!)`                             |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests ((A)!,A!)`                           |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests (3!!,720)`                           |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests (2!!!,2)`                            |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests (N!!,N!!)`                           |
| ✔ Passed             | 00:00:00.00 | `OptimizerTests (N!!!,N!!!)`                         |

## PoorlyFormedExpressions

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.2.2.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

| Outcome              | Duration    | Test Name                                            |
| :------------------- | ----------: | :--------------------------------------------------- |
| ✔ Passed             | 00:00:00.00 | `PoorlyFormedExpressions`                            |
| ✔ Passed             | 00:00:00.00 | `PoorlyFormedExpressions (-A!)`                      |
| ✔ Passed             | 00:00:00.00 | `PoorlyFormedExpressions (B/*1)`                     |
| ✔ Passed             | 00:00:00.00 | `PoorlyFormedExpressions (B**)`                      |
| ✔ Passed             | 00:00:00.00 | `PoorlyFormedExpressions (B**A)`                     |
| ✔ Passed             | 00:00:00.00 | `PoorlyFormedExpressions (B***A)`                    |
| ✔ Passed             | 00:00:00.00 | `PoorlyFormedExpressions (B*+*A)`                    |
| ✔ Passed             | 00:00:00.00 | `PoorlyFormedExpressions (B*-*A)`                    |
| ✔ Passed             | 00:00:00.00 | `PoorlyFormedExpressions ()`                         |
| ✔ Passed             | 00:00:00.00 | `PoorlyFormedExpressions (b)`                        |
| ✔ Passed             | 00:00:00.00 | `PoorlyFormedExpressions (b+1)`                      |

## SimpleParserTests

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.2.2.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

| Outcome              | Duration    | Test Name                                            |
| :------------------- | ----------: | :--------------------------------------------------- |
| ⚠ Inconclusive       | 00:00:00.00 | `SimpleParserTests`                                  |
| ✔ Passed             | 00:00:00.00 | `Parse all operators test`                           |
| ✔ Passed             | 00:00:00.00 | `Simple test with variable`                          |
| ✔ Passed             | 00:00:00.00 | `Just variable`                                      |
| ⚠ Inconclusive       | 00:00:00.00 | `Just decimal value`                                 |
| ✔ Passed             | 00:00:00.00 | `Simple factorial`                                   |
| ✔ Passed             | 00:00:00.00 | `Negative factorial`                                 |
| ⚠ Inconclusive       | 00:00:00.00 | `Parse Complex Expression`                           |
| ✔ Passed             | 00:00:00.00 | `SimpleParserTests (B*--A,B * --A)`                  |

## GetDistinctVariablesTests

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::GetDistinctVariableNames
  * BinaryDataDecoders.ExpressionCalculator, Version=0.2.2.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

| Outcome              | Duration    | Test Name                                            |
| :------------------- | ----------: | :--------------------------------------------------- |
| ✔ Passed             | 00:00:00.00 | `GetDistinctVariablesTests`                          |
| ✔ Passed             | 00:00:00.00 | `GetDistinctVariablesTests (A+B+C,A, B, C)`          |
| ✔ Passed             | 00:00:00.00 | `GetDistinctVariablesTests (A+B+B,A, B)`             |
| ✔ Passed             | 00:00:00.00 | `GetDistinctVariablesTests (Abc+XyW1,Abc, XyW1)`     |

## Links

* [Back to Summary](../Summary.md)
* [Table of Contents](../../TOC.md)
