# Test Run

## BinaryDataDecoders.ExpressionCalculator.Tests.Parser.Int32ExpressionParserTests

### PoorlyFormedExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions                           ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (-A!)                     ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B/*1)                    ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B**)                     ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B**A)                    ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B***A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B*+*A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B*-*A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions ()                        ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (b)                       ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (b+1)                     ` |

### GetDistinctVariablesTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests                         ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (A+B+C,A, B, C)         ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (A+B+B,A, B)            ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (Abc+XyW1,Abc, XyW1)    ` |

### SimpleParserTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.00 | `SimpleParserTests                                 ` |
|  ✔ Passed               | 00:00:00.00 | `Parse all operators test                          ` |
|  ✔ Passed               | 00:00:00.00 | `Simple test with variable                         ` |
|  ✔ Passed               | 00:00:00.00 | `Just variable                                     ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Just decimal value                                ` |
|  ✔ Passed               | 00:00:00.00 | `Simple factorial                                  ` |
|  ✔ Passed               | 00:00:00.00 | `Negative factorial                                ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Parse Complex Expression                          ` |
|  ✔ Passed               | 00:00:00.00 | `SimpleParserTests (B*--A,B * --A)                 ` |

### VerifyOptimizerForComplexExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.02 | `VerifyOptimizerForComplexExpressions              ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A"                             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*1"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B)+C"                       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B)"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A-B)/A"                       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+B+((C*D)+E))*F)+G+((D/H)*I)` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*(B/C)+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*B+C"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A-(B*C))/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A/B)-(C+D+E+F)"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A*B)*C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B*(C/D))+E"                 ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(B/C)+D)"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A+B"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*(C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((B*C)+D))*E)+F+(C*G)+H"   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+((B*C)+D))*E+F+(A+((B*C)+D))` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+((D*B)+E)"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+(-1*A)"              ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))+((C*D)+E))*F)+G+(D` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*(B+(-1*C)))+D)+((E*(B+(-1*C` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))*C)+D)+(B+(-1*A))" ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((B*C)+D))*E)+F+((C/G)*H)+I` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+B)*C+D+(A+B)*E+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*B"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((-1*B)*(C/D)))*(E/C))+(-1*` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/(1-B))*C)+D"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A-(B*C))/(1-D))*E)+F"       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(1+(-1*B))+C)*D+E"          ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+B)*C+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*C*D)*E*F)+G"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A-B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((((A*B)+C)/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*C*D*E)+F"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B*C)+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A*B)+C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*1)"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*D*E*F)+G"      ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+(D*E*F)"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/(1+(-1*(B+C))))*D)+E"      ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A-(B*C))*D)+E"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))/C)*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*((C*D)*E)*F)+G"         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((((A/B)*C)+D)*((E*F)*G))+H"   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))/C)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*(((C*D)*E)*F))+(C*D*G))` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+((A*C)-A)*D)+E"         ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*((C*D)*E)*F)*G)+H"     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*(((C*D)*E)*F))+G"       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*((C*D)*E))+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A/(A+B))"                     ` |
|  ✔ Passed               | 00:00:00.00 | `VerifyOptimizerForComplexExpressions (A!)         ` |

### OptimizerTests_WithExceptions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions                     ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions (B/0)               ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions (B%0)               ` |

### OptimizerTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.01 | `OptimizerTests                                    ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A),A)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A+(B)),A + B)                    ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B^1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (1*B,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-1*B,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B+0,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0+B,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B-0,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0-B,-B)                           ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2+3*4^5%6/7-8,-6)                 ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2+3,5)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/B,1)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B^0,1)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0^B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0*B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*0,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0/B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0%B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%1,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%-1,0)                           ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-(B),-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-(3),-3)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-3,-3)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (--B,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (---B,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-1*(A*B),-(A * B))                ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (A!,A!)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A)!,A!)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (3!!,720)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2!!!,2)                           ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (N!!,N!!)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (N!!!,N!!!)                        ` |

## BinaryDataDecoders.ExpressionCalculator.Tests.Parser.UInt64ExpressionParserTests

### PoorlyFormedExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions                           ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (-A!)                     ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B/*1)                    ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B**)                     ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B**A)                    ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B***A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B*+*A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B*-*A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions ()                        ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (b)                       ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (b+1)                     ` |

### OptimizerTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.02 | `OptimizerTests                                    ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A),A)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A+(B)),A + B)                    ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B^1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (1*B,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (B*-1,-B)                          ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (-1*B,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/1,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (B/-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B+0,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0+B,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B-0,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (0-B,-B)                           ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (2+3*4^5%6/7-8,-6)                 ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2+3,5)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/B,1)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B^0,1)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0^B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0*B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*0,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0/B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0%B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%1,0)                            ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (B%-1,0)                           ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (-(B),-B)                          ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (-(3),-3)                          ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (-3,-3)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (--B,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (---B,-B)                          ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (-1*(A*B),-(A * B))                ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (A!,A!)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A)!,A!)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (3!!,720)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2!!!,2)                           ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (N!!,N!!)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (N!!!,N!!!)                        ` |

### VerifyOptimizerForComplexExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.04 | `VerifyOptimizerForComplexExpressions              ` |
|  ✔ Passed               | 00:00:00.01 | `Check Expressions "A"                             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*1"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B)+C"                       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B)"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A-B)/A"                       ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+B+((C*D)+E))*F)+G+((D/H)*I)` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*(B/C)+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*B+C"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A-(B*C))/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A/B)-(C+D+E+F)"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A*B)*C)*D)+E"               ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B*(C/D))+E"                 ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(B/C)+D)"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A+B"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*(C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((B*C)+D))*E)+F+(C*G)+H"   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+((B*C)+D))*E+F+(A+((B*C)+D))` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+((D*B)+E)"           ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((A*B)+C)+(-1*A)"              ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A+(-1*B))+((C*D)+E))*F)+G+(D` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((A*(B+(-1*C)))+D)+((E*(B+(-1*C` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A+(-1*B))*C)+D)+(B+(-1*A))" ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((B*C)+D))*E)+F+((C/G)*H)+I` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+B)*C+D+(A+B)*E+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*B"                           ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((A+((-1*B)*(C/D)))*(E/C))+(-1*` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/(1-B))*C)+D"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A-(B*C))/(1-D))*E)+F"       ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*(1+(-1*B))+C)*D+E"          ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+B)*C+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*C*D)*E*F)+G"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A-B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((((A*B)+C)/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*C*D*E)+F"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B*C)+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A*B)+C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*1)"                         ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*D*E*F)+G"      ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+(D*E*F)"             ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((A/(1+(-1*(B+C))))*D)+E"      ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A-(B*C))*D)+E"               ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A+(-1*B))/C)*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*((C*D)*E)*F)+G"         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((((A/B)*C)+D)*((E*F)*G))+H"   ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*((D*E)*F)*G)+H"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A+(-1*B))/C)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*(((C*D)*E)*F))+(C*D*G))` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+((A*C)-A)*D)+E"         ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*((C*D)*E)*F)*G)+H"     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*(((C*D)*E)*F))+G"       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*((C*D)*E))+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A/(A+B))"                     ` |
|  ✔ Passed               | 00:00:00.00 | `VerifyOptimizerForComplexExpressions (A!)         ` |

### OptimizerTests_WithExceptions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions                     ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions (B/0)               ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions (B%0)               ` |

### GetDistinctVariablesTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests                         ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (A+B+C,A, B, C)         ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (A+B+B,A, B)            ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (Abc+XyW1,Abc, XyW1)    ` |

### SimpleParserTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.00 | `SimpleParserTests                                 ` |
|  ✔ Passed               | 00:00:00.00 | `Parse all operators test                          ` |
|  ✔ Passed               | 00:00:00.00 | `Simple test with variable                         ` |
|  ✔ Passed               | 00:00:00.00 | `Just variable                                     ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Just decimal value                                ` |
|  ✔ Passed               | 00:00:00.00 | `Simple factorial                                  ` |
|  ✔ Passed               | 00:00:00.00 | `Negative factorial                                ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Parse Complex Expression                          ` |
|  ✔ Passed               | 00:00:00.00 | `SimpleParserTests (B*--A,B * --A)                 ` |

## BinaryDataDecoders.ExpressionCalculator.Tests.Parser.Int8ExpressionParserTests

### OptimizerTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.01 | `OptimizerTests                                    ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A),A)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A+(B)),A + B)                    ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B^1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (1*B,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-1*B,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B+0,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0+B,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B-0,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0-B,-B)                           ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2+3*4^5%6/7-8,-6)                 ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2+3,5)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/B,1)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B^0,1)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0^B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0*B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*0,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0/B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0%B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%1,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%-1,0)                           ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-(B),-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-(3),-3)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-3,-3)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (--B,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (---B,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-1*(A*B),-(A * B))                ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (A!,A!)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A)!,A!)                          ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (3!!,720)                          ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (2!!!,2)                           ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (N!!,N!!)                          ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (N!!!,N!!!)                        ` |

### SimpleParserTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.03 | `SimpleParserTests                                 ` |
|  ✔ Passed               | 00:00:00.00 | `Parse all operators test                          ` |
|  ✔ Passed               | 00:00:00.00 | `Simple test with variable                         ` |
|  ✔ Passed               | 00:00:00.00 | `Just variable                                     ` |
|  ⚠ Inconclusive        | 00:00:00.02 | `Just decimal value                                ` |
|  ✔ Passed               | 00:00:00.00 | `Simple factorial                                  ` |
|  ✔ Passed               | 00:00:00.00 | `Negative factorial                                ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Parse Complex Expression                          ` |
|  ✔ Passed               | 00:00:00.00 | `SimpleParserTests (B*--A,B * --A)                 ` |

### GetDistinctVariablesTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests                         ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (A+B+C,A, B, C)         ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (A+B+B,A, B)            ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (Abc+XyW1,Abc, XyW1)    ` |

### VerifyOptimizerForComplexExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.02 | `VerifyOptimizerForComplexExpressions              ` |
|  ✔ Passed               | 00:00:00.01 | `Check Expressions "A"                             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*1"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B)+C"                       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B)"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A-B)/A"                       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+B+((C*D)+E))*F)+G+((D/H)*I)` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*(B/C)+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*B+C"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A-(B*C))/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A/B)-(C+D+E+F)"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A*B)*C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B*(C/D))+E"                 ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(B/C)+D)"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A+B"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*(C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((B*C)+D))*E)+F+(C*G)+H"   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+((B*C)+D))*E+F+(A+((B*C)+D))` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+((D*B)+E)"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+(-1*A)"              ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))+((C*D)+E))*F)+G+(D` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*(B+(-1*C)))+D)+((E*(B+(-1*C` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))*C)+D)+(B+(-1*A))" ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((B*C)+D))*E)+F+((C/G)*H)+I` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+B)*C+D+(A+B)*E+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*B"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((-1*B)*(C/D)))*(E/C))+(-1*` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/(1-B))*C)+D"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A-(B*C))/(1-D))*E)+F"       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(1+(-1*B))+C)*D+E"          ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+B)*C+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*C*D)*E*F)+G"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A-B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((((A*B)+C)/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*C*D*E)+F"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B*C)+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A*B)+C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*1)"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*D*E*F)+G"      ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+(D*E*F)"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/(1+(-1*(B+C))))*D)+E"      ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A-(B*C))*D)+E"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))/C)*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*((C*D)*E)*F)+G"         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((((A/B)*C)+D)*((E*F)*G))+H"   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))/C)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*(((C*D)*E)*F))+(C*D*G))` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+((A*C)-A)*D)+E"         ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*((C*D)*E)*F)*G)+H"     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*(((C*D)*E)*F))+G"       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*((C*D)*E))+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A/(A+B))"                     ` |
|  ✔ Passed               | 00:00:00.00 | `VerifyOptimizerForComplexExpressions (A!)         ` |

### OptimizerTests_WithExceptions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions                     ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions (B/0)               ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions (B%0)               ` |

### PoorlyFormedExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions                           ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (-A!)                     ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B/*1)                    ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B**)                     ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B**A)                    ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B***A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B*+*A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B*-*A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions ()                        ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (b)                       ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (b+1)                     ` |

## BinaryDataDecoders.ExpressionCalculator.Tests.Expressions.ExpressionBaseExtensionsTests

### ParseAndEvaluateTest
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `ParseAndEvaluateTest                              ` |

### ParseAndPreEvaluateTest
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `ParseAndPreEvaluateTest                           ` |

### ParseAndReplaceVariablesTest
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `ParseAndReplaceVariablesTest                      ` |

## BinaryDataDecoders.ExpressionCalculator.Tests.Evaluators.ExpressionEvaluatorExtensionsTests

### Sum_Test
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `Sum_Test                                          ` |

### Product_Test
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `Product_Test                                      ` |

### Sequence_Test
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `Sequence_Test                                     ` |

### Factorial_Test
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `Factorial_Test                                    ` |

## BinaryDataDecoders.ExpressionCalculator.Tests.Parser.DecimalExpressionParserTests

### OptimizerTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.02 | `OptimizerTests                                    ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A),A)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A+(B)),A + B)                    ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B^1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (1*B,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-1*B,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B+0,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0+B,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B-0,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0-B,-B)                           ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2+3*4^5%6/7-8,-6)                 ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2+3,5)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/B,1)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B^0,1)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0^B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0*B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*0,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0/B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0%B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%1,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%-1,0)                           ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-(B),-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-(3),-3)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-3,-3)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (--B,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (---B,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-1*(A*B),-(A * B))                ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (A!,A!)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A)!,A!)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (3!!,720)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2!!!,2)                           ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (N!!,N!!)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (N!!!,N!!!)                        ` |

### GetDistinctVariablesTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests                         ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (A+B+C,A, B, C)         ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (A+B+B,A, B)            ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (Abc+XyW1,Abc, XyW1)    ` |

### VerifyOptimizerForComplexExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.04 | `VerifyOptimizerForComplexExpressions              ` |
|  ✔ Passed               | 00:00:00.01 | `Check Expressions "A"                             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*1"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B)+C"                       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B)"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A-B)/A"                       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+B+((C*D)+E))*F)+G+((D/H)*I)` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*(B/C)+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*B+C"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A-(B*C))/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A/B)-(C+D+E+F)"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A*B)*C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B*(C/D))+E"                 ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(B/C)+D)"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A+B"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*(C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((B*C)+D))*E)+F+(C*G)+H"   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+((B*C)+D))*E+F+(A+((B*C)+D))` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+((D*B)+E)"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+(-1*A)"              ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))+((C*D)+E))*F)+G+(D` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*(B+(-1*C)))+D)+((E*(B+(-1*C` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))*C)+D)+(B+(-1*A))" ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((B*C)+D))*E)+F+((C/G)*H)+I` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+B)*C+D+(A+B)*E+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*B"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((-1*B)*(C/D)))*(E/C))+(-1*` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/(1-B))*C)+D"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A-(B*C))/(1-D))*E)+F"       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(1+(-1*B))+C)*D+E"          ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+B)*C+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*C*D)*E*F)+G"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A-B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((((A*B)+C)/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*C*D*E)+F"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B*C)+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A*B)+C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*1)"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*D*E*F)+G"      ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+(D*E*F)"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/(1+(-1*(B+C))))*D)+E"      ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A-(B*C))*D)+E"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))/C)*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*((C*D)*E)*F)+G"         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((((A/B)*C)+D)*((E*F)*G))+H"   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))/C)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*(((C*D)*E)*F))+(C*D*G))` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+((A*C)-A)*D)+E"         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*((C*D)*E)*F)*G)+H"     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*(((C*D)*E)*F))+G"       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*((C*D)*E))+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A/(A+B))"                     ` |
|  ✔ Passed               | 00:00:00.00 | `VerifyOptimizerForComplexExpressions (A!)         ` |

### SimpleParserTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.02 | `SimpleParserTests                                 ` |
|  ✔ Passed               | 00:00:00.01 | `Parse all operators test                          ` |
|  ✔ Passed               | 00:00:00.00 | `Simple test with variable                         ` |
|  ✔ Passed               | 00:00:00.00 | `Just variable                                     ` |
|  ✔ Passed               | 00:00:00.00 | `Just decimal value                                ` |
|  ✔ Passed               | 00:00:00.00 | `Simple factorial                                  ` |
|  ✔ Passed               | 00:00:00.00 | `Negative factorial                                ` |
|  ✔ Passed               | 00:00:00.00 | `Parse Complex Expression                          ` |
|  ✔ Passed               | 00:00:00.00 | `SimpleParserTests (B*--A,B * --A)                 ` |

### PoorlyFormedExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.10 | `PoorlyFormedExpressions                           ` |
|  ✔ Passed               | 00:00:00.08 | `PoorlyFormedExpressions (-A!)                     ` |
|  ✔ Passed               | 00:00:00.01 | `PoorlyFormedExpressions (B/*1)                    ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B**)                     ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B**A)                    ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B***A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B*+*A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B*-*A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions ()                        ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (b)                       ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (b+1)                     ` |

### OptimizerTests_WithExceptions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions                     ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions (B/0)               ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions (B%0)               ` |

## BinaryDataDecoders.ExpressionCalculator.Tests.Parser.DoubleExpressionParserTests

### PoorlyFormedExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions                           ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (-A!)                     ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B/*1)                    ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B**)                     ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B**A)                    ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B***A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B*+*A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B*-*A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions ()                        ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (b)                       ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (b+1)                     ` |

### OptimizerTests_WithExceptions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions                     ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions (B/0)               ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions (B%0)               ` |

### OptimizerTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.01 | `OptimizerTests                                    ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A),A)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A+(B)),A + B)                    ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B^1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (1*B,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-1*B,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B+0,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0+B,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B-0,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0-B,-B)                           ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2+3*4^5%6/7-8,-6)                 ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2+3,5)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/B,1)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B^0,1)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0^B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0*B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*0,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0/B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0%B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%1,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%-1,0)                           ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-(B),-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-(3),-3)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-3,-3)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (--B,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (---B,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-1*(A*B),-(A * B))                ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (A!,A!)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A)!,A!)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (3!!,720)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2!!!,2)                           ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (N!!,N!!)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (N!!!,N!!!)                        ` |

### GetDistinctVariablesTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests                         ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (A+B+C,A, B, C)         ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (A+B+B,A, B)            ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (Abc+XyW1,Abc, XyW1)    ` |

### SimpleParserTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `SimpleParserTests                                 ` |
|  ✔ Passed               | 00:00:00.00 | `Parse all operators test                          ` |
|  ✔ Passed               | 00:00:00.00 | `Simple test with variable                         ` |
|  ✔ Passed               | 00:00:00.00 | `Just variable                                     ` |
|  ✔ Passed               | 00:00:00.00 | `Just decimal value                                ` |
|  ✔ Passed               | 00:00:00.00 | `Simple factorial                                  ` |
|  ✔ Passed               | 00:00:00.00 | `Negative factorial                                ` |
|  ✔ Passed               | 00:00:00.00 | `Parse Complex Expression                          ` |
|  ✔ Passed               | 00:00:00.00 | `SimpleParserTests (B*--A,B * --A)                 ` |

### VerifyOptimizerForComplexExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.03 | `VerifyOptimizerForComplexExpressions              ` |
|  ✔ Passed               | 00:00:00.01 | `Check Expressions "A"                             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*1"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B)+C"                       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B)"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A-B)/A"                       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+B+((C*D)+E))*F)+G+((D/H)*I)` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*(B/C)+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*B+C"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A-(B*C))/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A/B)-(C+D+E+F)"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A*B)*C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B*(C/D))+E"                 ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(B/C)+D)"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A+B"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*(C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((B*C)+D))*E)+F+(C*G)+H"   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+((B*C)+D))*E+F+(A+((B*C)+D))` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+((D*B)+E)"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+(-1*A)"              ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))+((C*D)+E))*F)+G+(D` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*(B+(-1*C)))+D)+((E*(B+(-1*C` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))*C)+D)+(B+(-1*A))" ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((B*C)+D))*E)+F+((C/G)*H)+I` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+B)*C+D+(A+B)*E+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*B"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((-1*B)*(C/D)))*(E/C))+(-1*` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/(1-B))*C)+D"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A-(B*C))/(1-D))*E)+F"       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(1+(-1*B))+C)*D+E"          ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+B)*C+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*C*D)*E*F)+G"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A-B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((((A*B)+C)/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*C*D*E)+F"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B*C)+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A*B)+C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*1)"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*D*E*F)+G"      ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+(D*E*F)"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/(1+(-1*(B+C))))*D)+E"      ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A-(B*C))*D)+E"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))/C)*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*((C*D)*E)*F)+G"         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((((A/B)*C)+D)*((E*F)*G))+H"   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))/C)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*(((C*D)*E)*F))+(C*D*G))` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+((A*C)-A)*D)+E"         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*((C*D)*E)*F)*G)+H"     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*(((C*D)*E)*F))+G"       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*((C*D)*E))+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A/(A+B))"                     ` |
|  ✔ Passed               | 00:00:00.00 | `VerifyOptimizerForComplexExpressions (A!)         ` |

## BinaryDataDecoders.ExpressionCalculator.Tests.Parser.UInt16ExpressionParserTests

### VerifyOptimizerForComplexExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.05 | `VerifyOptimizerForComplexExpressions              ` |
|  ✔ Passed               | 00:00:00.01 | `Check Expressions "A"                             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*1"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B)+C"                       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B)"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A-B)/A"                       ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+B+((C*D)+E))*F)+G+((D/H)*I)` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*(B/C)+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*B+C"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A-(B*C))/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A/B)-(C+D+E+F)"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A*B)*C)*D)+E"               ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B*(C/D))+E"                 ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(B/C)+D)"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A+B"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*(C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((B*C)+D))*E)+F+(C*G)+H"   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+((B*C)+D))*E+F+(A+((B*C)+D))` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+((D*B)+E)"           ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((A*B)+C)+(-1*A)"              ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A+(-1*B))+((C*D)+E))*F)+G+(D` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((A*(B+(-1*C)))+D)+((E*(B+(-1*C` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A+(-1*B))*C)+D)+(B+(-1*A))" ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((B*C)+D))*E)+F+((C/G)*H)+I` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+B)*C+D+(A+B)*E+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*B"                           ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((A+((-1*B)*(C/D)))*(E/C))+(-1*` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/(1-B))*C)+D"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A-(B*C))/(1-D))*E)+F"       ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*(1+(-1*B))+C)*D+E"          ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+B)*C+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*C*D)*E*F)+G"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A-B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((((A*B)+C)/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*C*D*E)+F"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B*C)+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A*B)+C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*1)"                         ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*D*E*F)+G"      ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+(D*E*F)"             ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((A/(1+(-1*(B+C))))*D)+E"      ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A-(B*C))*D)+E"               ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A+(-1*B))/C)*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*((C*D)*E)*F)+G"         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((((A/B)*C)+D)*((E*F)*G))+H"   ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*((D*E)*F)*G)+H"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A+(-1*B))/C)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*(((C*D)*E)*F))+(C*D*G))` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+((A*C)-A)*D)+E"         ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*((C*D)*E)*F)*G)+H"     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*(((C*D)*E)*F))+G"       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*((C*D)*E))+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A/(A+B))"                     ` |
|  ✔ Passed               | 00:00:00.00 | `VerifyOptimizerForComplexExpressions (A!)         ` |

### OptimizerTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.02 | `OptimizerTests                                    ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A),A)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A+(B)),A + B)                    ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B^1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (1*B,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (B*-1,-B)                          ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (-1*B,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/1,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (B/-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B+0,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0+B,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B-0,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (0-B,-B)                           ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (2+3*4^5%6/7-8,-6)                 ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2+3,5)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/B,1)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B^0,1)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0^B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0*B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*0,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0/B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0%B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%1,0)                            ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (B%-1,0)                           ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (-(B),-B)                          ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (-(3),-3)                          ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (-3,-3)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (--B,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (---B,-B)                          ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (-1*(A*B),-(A * B))                ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (A!,A!)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A)!,A!)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (3!!,720)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2!!!,2)                           ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (N!!,N!!)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (N!!!,N!!!)                        ` |

### GetDistinctVariablesTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests                         ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (A+B+C,A, B, C)         ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (A+B+B,A, B)            ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (Abc+XyW1,Abc, XyW1)    ` |

### SimpleParserTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.00 | `SimpleParserTests                                 ` |
|  ✔ Passed               | 00:00:00.00 | `Parse all operators test                          ` |
|  ✔ Passed               | 00:00:00.00 | `Simple test with variable                         ` |
|  ✔ Passed               | 00:00:00.00 | `Just variable                                     ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Just decimal value                                ` |
|  ✔ Passed               | 00:00:00.00 | `Simple factorial                                  ` |
|  ✔ Passed               | 00:00:00.00 | `Negative factorial                                ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Parse Complex Expression                          ` |
|  ✔ Passed               | 00:00:00.00 | `SimpleParserTests (B*--A,B * --A)                 ` |

### PoorlyFormedExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions                           ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (-A!)                     ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B/*1)                    ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B**)                     ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B**A)                    ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B***A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B*+*A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B*-*A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions ()                        ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (b)                       ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (b+1)                     ` |

### OptimizerTests_WithExceptions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions                     ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions (B/0)               ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions (B%0)               ` |

## BinaryDataDecoders.ExpressionCalculator.Tests.Expressions.VariableExpressionTests

### Equals_DifferentValue_Test
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `Equals_DifferentValue_Test                        ` |

### Equals_DifferentString_Test
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `Equals_DifferentString_Test                       ` |

### Equals_SameReference_Test
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `Equals_SameReference_Test                         ` |

### EmptyVariableName_Test
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `EmptyVariableName_Test                            ` |

### Equals_SameString_Test
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `Equals_SameString_Test                            ` |

### NullVariableName_Test
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `NullVariableName_Test                             ` |

### Equals_SameValue_Test
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `Equals_SameValue_Test                             ` |

## BinaryDataDecoders.ExpressionCalculator.Tests.Parser.Int16ExpressionParserTests

### SimpleParserTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.01 | `SimpleParserTests                                 ` |
|  ✔ Passed               | 00:00:00.00 | `Parse all operators test                          ` |
|  ✔ Passed               | 00:00:00.00 | `Simple test with variable                         ` |
|  ✔ Passed               | 00:00:00.00 | `Just variable                                     ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Just decimal value                                ` |
|  ✔ Passed               | 00:00:00.00 | `Simple factorial                                  ` |
|  ✔ Passed               | 00:00:00.00 | `Negative factorial                                ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Parse Complex Expression                          ` |
|  ✔ Passed               | 00:00:00.00 | `SimpleParserTests (B*--A,B * --A)                 ` |

### OptimizerTests_WithExceptions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions                     ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions (B/0)               ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions (B%0)               ` |

### VerifyOptimizerForComplexExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.03 | `VerifyOptimizerForComplexExpressions              ` |
|  ✔ Passed               | 00:00:00.01 | `Check Expressions "A"                             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*1"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B)+C"                       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B)"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A-B)/A"                       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+B+((C*D)+E))*F)+G+((D/H)*I)` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*(B/C)+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*B+C"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A-(B*C))/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A/B)-(C+D+E+F)"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A*B)*C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B*(C/D))+E"                 ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(B/C)+D)"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A+B"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*(C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((B*C)+D))*E)+F+(C*G)+H"   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+((B*C)+D))*E+F+(A+((B*C)+D))` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+((D*B)+E)"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+(-1*A)"              ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))+((C*D)+E))*F)+G+(D` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*(B+(-1*C)))+D)+((E*(B+(-1*C` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))*C)+D)+(B+(-1*A))" ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((B*C)+D))*E)+F+((C/G)*H)+I` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+B)*C+D+(A+B)*E+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*B"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((-1*B)*(C/D)))*(E/C))+(-1*` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/(1-B))*C)+D"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A-(B*C))/(1-D))*E)+F"       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(1+(-1*B))+C)*D+E"          ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+B)*C+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*C*D)*E*F)+G"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A-B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((((A*B)+C)/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*C*D*E)+F"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B*C)+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A*B)+C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*1)"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*D*E*F)+G"      ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+(D*E*F)"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/(1+(-1*(B+C))))*D)+E"      ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A-(B*C))*D)+E"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))/C)*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*((C*D)*E)*F)+G"         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((((A/B)*C)+D)*((E*F)*G))+H"   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))/C)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*(((C*D)*E)*F))+(C*D*G))` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+((A*C)-A)*D)+E"         ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*((C*D)*E)*F)*G)+H"     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*(((C*D)*E)*F))+G"       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*((C*D)*E))+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A/(A+B))"                     ` |
|  ✔ Passed               | 00:00:00.00 | `VerifyOptimizerForComplexExpressions (A!)         ` |

### GetDistinctVariablesTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests                         ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (A+B+C,A, B, C)         ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (A+B+B,A, B)            ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (Abc+XyW1,Abc, XyW1)    ` |

### OptimizerTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.01 | `OptimizerTests                                    ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A),A)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A+(B)),A + B)                    ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B^1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (1*B,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-1*B,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B+0,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0+B,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B-0,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0-B,-B)                           ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2+3*4^5%6/7-8,-6)                 ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2+3,5)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/B,1)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B^0,1)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0^B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0*B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*0,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0/B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0%B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%1,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%-1,0)                           ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-(B),-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-(3),-3)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-3,-3)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (--B,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (---B,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-1*(A*B),-(A * B))                ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (A!,A!)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A)!,A!)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (3!!,720)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2!!!,2)                           ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (N!!,N!!)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (N!!!,N!!!)                        ` |

### PoorlyFormedExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions                           ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (-A!)                     ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B/*1)                    ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B**)                     ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B**A)                    ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B***A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B*+*A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B*-*A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions ()                        ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (b)                       ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (b+1)                     ` |

## BinaryDataDecoders.ExpressionCalculator.Tests.Parser.FloatExpressionParserTests

### SimpleParserTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `SimpleParserTests                                 ` |
|  ✔ Passed               | 00:00:00.00 | `Parse all operators test                          ` |
|  ✔ Passed               | 00:00:00.00 | `Simple test with variable                         ` |
|  ✔ Passed               | 00:00:00.00 | `Just variable                                     ` |
|  ✔ Passed               | 00:00:00.00 | `Just decimal value                                ` |
|  ✔ Passed               | 00:00:00.00 | `Simple factorial                                  ` |
|  ✔ Passed               | 00:00:00.00 | `Negative factorial                                ` |
|  ✔ Passed               | 00:00:00.00 | `Parse Complex Expression                          ` |
|  ✔ Passed               | 00:00:00.00 | `SimpleParserTests (B*--A,B * --A)                 ` |

### OptimizerTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.01 | `OptimizerTests                                    ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A),A)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A+(B)),A + B)                    ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B^1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (1*B,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-1*B,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B+0,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0+B,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B-0,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0-B,-B)                           ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2+3*4^5%6/7-8,-6)                 ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2+3,5)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/B,1)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B^0,1)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0^B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0*B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*0,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0/B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0%B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%1,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%-1,0)                           ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-(B),-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-(3),-3)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-3,-3)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (--B,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (---B,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-1*(A*B),-(A * B))                ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (A!,A!)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A)!,A!)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (3!!,720)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2!!!,2)                           ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (N!!,N!!)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (N!!!,N!!!)                        ` |

### GetDistinctVariablesTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests                         ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (A+B+C,A, B, C)         ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (A+B+B,A, B)            ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (Abc+XyW1,Abc, XyW1)    ` |

### VerifyOptimizerForComplexExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.03 | `VerifyOptimizerForComplexExpressions              ` |
|  ✔ Passed               | 00:00:00.01 | `Check Expressions "A"                             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*1"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B)+C"                       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B)"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A-B)/A"                       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+B+((C*D)+E))*F)+G+((D/H)*I)` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*(B/C)+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*B+C"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A-(B*C))/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A/B)-(C+D+E+F)"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A*B)*C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B*(C/D))+E"                 ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(B/C)+D)"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A+B"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*(C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((B*C)+D))*E)+F+(C*G)+H"   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+((B*C)+D))*E+F+(A+((B*C)+D))` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+((D*B)+E)"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+(-1*A)"              ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))+((C*D)+E))*F)+G+(D` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*(B+(-1*C)))+D)+((E*(B+(-1*C` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))*C)+D)+(B+(-1*A))" ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((B*C)+D))*E)+F+((C/G)*H)+I` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+B)*C+D+(A+B)*E+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*B"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((-1*B)*(C/D)))*(E/C))+(-1*` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/(1-B))*C)+D"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A-(B*C))/(1-D))*E)+F"       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(1+(-1*B))+C)*D+E"          ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+B)*C+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*C*D)*E*F)+G"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A-B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((((A*B)+C)/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*C*D*E)+F"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B*C)+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A*B)+C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*1)"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*D*E*F)+G"      ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+(D*E*F)"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/(1+(-1*(B+C))))*D)+E"      ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A-(B*C))*D)+E"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))/C)*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*((C*D)*E)*F)+G"         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((((A/B)*C)+D)*((E*F)*G))+H"   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))/C)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*(((C*D)*E)*F))+(C*D*G))` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+((A*C)-A)*D)+E"         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*((C*D)*E)*F)*G)+H"     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*(((C*D)*E)*F))+G"       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*((C*D)*E))+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A/(A+B))"                     ` |
|  ✔ Passed               | 00:00:00.00 | `VerifyOptimizerForComplexExpressions (A!)         ` |

### PoorlyFormedExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions                           ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (-A!)                     ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B/*1)                    ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B**)                     ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B**A)                    ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B***A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B*+*A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B*-*A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions ()                        ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (b)                       ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (b+1)                     ` |

### OptimizerTests_WithExceptions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions                     ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions (B/0)               ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions (B%0)               ` |

## BinaryDataDecoders.ExpressionCalculator.Tests.Parser.UInt32ExpressionParserTests

### SimpleParserTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.00 | `SimpleParserTests                                 ` |
|  ✔ Passed               | 00:00:00.00 | `Parse all operators test                          ` |
|  ✔ Passed               | 00:00:00.00 | `Simple test with variable                         ` |
|  ✔ Passed               | 00:00:00.00 | `Just variable                                     ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Just decimal value                                ` |
|  ✔ Passed               | 00:00:00.00 | `Simple factorial                                  ` |
|  ✔ Passed               | 00:00:00.00 | `Negative factorial                                ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Parse Complex Expression                          ` |
|  ✔ Passed               | 00:00:00.00 | `SimpleParserTests (B*--A,B * --A)                 ` |

### OptimizerTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.02 | `OptimizerTests                                    ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A),A)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A+(B)),A + B)                    ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B^1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (1*B,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (B*-1,-B)                          ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (-1*B,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/1,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (B/-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B+0,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0+B,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B-0,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (0-B,-B)                           ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (2+3*4^5%6/7-8,-6)                 ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2+3,5)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/B,1)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B^0,1)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0^B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0*B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*0,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0/B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0%B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%1,0)                            ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (B%-1,0)                           ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (-(B),-B)                          ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (-(3),-3)                          ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (-3,-3)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (--B,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (---B,-B)                          ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (-1*(A*B),-(A * B))                ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (A!,A!)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A)!,A!)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (3!!,720)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2!!!,2)                           ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (N!!,N!!)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (N!!!,N!!!)                        ` |

### OptimizerTests_WithExceptions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions                     ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions (B/0)               ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions (B%0)               ` |

### PoorlyFormedExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions                           ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (-A!)                     ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B/*1)                    ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B**)                     ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B**A)                    ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B***A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B*+*A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B*-*A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions ()                        ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (b)                       ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (b+1)                     ` |

### VerifyOptimizerForComplexExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.03 | `VerifyOptimizerForComplexExpressions              ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A"                             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*1"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B)+C"                       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B)"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A-B)/A"                       ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+B+((C*D)+E))*F)+G+((D/H)*I)` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*(B/C)+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*B+C"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A-(B*C))/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A/B)-(C+D+E+F)"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A*B)*C)*D)+E"               ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B*(C/D))+E"                 ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(B/C)+D)"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A+B"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*(C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((B*C)+D))*E)+F+(C*G)+H"   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+((B*C)+D))*E+F+(A+((B*C)+D))` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+((D*B)+E)"           ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((A*B)+C)+(-1*A)"              ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A+(-1*B))+((C*D)+E))*F)+G+(D` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((A*(B+(-1*C)))+D)+((E*(B+(-1*C` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A+(-1*B))*C)+D)+(B+(-1*A))" ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((B*C)+D))*E)+F+((C/G)*H)+I` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+B)*C+D+(A+B)*E+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*B"                           ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((A+((-1*B)*(C/D)))*(E/C))+(-1*` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/(1-B))*C)+D"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A-(B*C))/(1-D))*E)+F"       ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*(1+(-1*B))+C)*D+E"          ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+B)*C+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*C*D)*E*F)+G"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A-B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((((A*B)+C)/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*C*D*E)+F"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B*C)+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A*B)+C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*1)"                         ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*D*E*F)+G"      ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+(D*E*F)"             ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((A/(1+(-1*(B+C))))*D)+E"      ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A-(B*C))*D)+E"               ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A+(-1*B))/C)*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*((C*D)*E)*F)+G"         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((((A/B)*C)+D)*((E*F)*G))+H"   ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*((D*E)*F)*G)+H"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A+(-1*B))/C)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*(((C*D)*E)*F))+(C*D*G))` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+((A*C)-A)*D)+E"         ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*((C*D)*E)*F)*G)+H"     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*(((C*D)*E)*F))+G"       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*((C*D)*E))+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A/(A+B))"                     ` |
|  ✔ Passed               | 00:00:00.00 | `VerifyOptimizerForComplexExpressions (A!)         ` |

### GetDistinctVariablesTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests                         ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (A+B+C,A, B, C)         ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (A+B+B,A, B)            ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (Abc+XyW1,Abc, XyW1)    ` |

## BinaryDataDecoders.ExpressionCalculator.Tests.Expressions.NumberExpressionTests

### Equals_DifferentValue_Test
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `Equals_DifferentValue_Test                        ` |

### Equals_SameNumber_Test
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `Equals_SameNumber_Test                            ` |

### Equals_DifferentNumber_Test
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `Equals_DifferentNumber_Test                       ` |

### Equals_SameValue_Test
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `Equals_SameValue_Test                             ` |

### Equals_SameReference_Test
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `Equals_SameReference_Test                         ` |

## BinaryDataDecoders.ExpressionCalculator.Tests.Parser.Int64ExpressionParserTests

### GetDistinctVariablesTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests                         ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (A+B+C,A, B, C)         ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (A+B+B,A, B)            ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (Abc+XyW1,Abc, XyW1)    ` |

### OptimizerTests_WithExceptions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions                     ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions (B/0)               ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions (B%0)               ` |

### OptimizerTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.01 | `OptimizerTests                                    ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A),A)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A+(B)),A + B)                    ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B^1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (1*B,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-1*B,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B+0,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0+B,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B-0,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0-B,-B)                           ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2+3*4^5%6/7-8,-6)                 ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2+3,5)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/B,1)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B^0,1)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0^B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0*B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*0,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0/B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0%B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%1,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%-1,0)                           ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-(B),-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-(3),-3)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-3,-3)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (--B,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (---B,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (-1*(A*B),-(A * B))                ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (A!,A!)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A)!,A!)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (3!!,720)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2!!!,2)                           ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (N!!,N!!)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (N!!!,N!!!)                        ` |

### SimpleParserTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.00 | `SimpleParserTests                                 ` |
|  ✔ Passed               | 00:00:00.00 | `Parse all operators test                          ` |
|  ✔ Passed               | 00:00:00.00 | `Simple test with variable                         ` |
|  ✔ Passed               | 00:00:00.00 | `Just variable                                     ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Just decimal value                                ` |
|  ✔ Passed               | 00:00:00.00 | `Simple factorial                                  ` |
|  ✔ Passed               | 00:00:00.00 | `Negative factorial                                ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Parse Complex Expression                          ` |
|  ✔ Passed               | 00:00:00.00 | `SimpleParserTests (B*--A,B * --A)                 ` |

### VerifyOptimizerForComplexExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.03 | `VerifyOptimizerForComplexExpressions              ` |
|  ✔ Passed               | 00:00:00.01 | `Check Expressions "A"                             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*1"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B)+C"                       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B)"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A-B)/A"                       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+B+((C*D)+E))*F)+G+((D/H)*I)` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*(B/C)+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*B+C"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A-(B*C))/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A/B)-(C+D+E+F)"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A*B)*C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B*(C/D))+E"                 ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(B/C)+D)"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A+B"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*(C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((B*C)+D))*E)+F+(C*G)+H"   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+((B*C)+D))*E+F+(A+((B*C)+D))` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+((D*B)+E)"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+(-1*A)"              ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))+((C*D)+E))*F)+G+(D` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*(B+(-1*C)))+D)+((E*(B+(-1*C` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))*C)+D)+(B+(-1*A))" ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((B*C)+D))*E)+F+((C/G)*H)+I` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+B)*C+D+(A+B)*E+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*B"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((-1*B)*(C/D)))*(E/C))+(-1*` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/(1-B))*C)+D"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A-(B*C))/(1-D))*E)+F"       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(1+(-1*B))+C)*D+E"          ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+B)*C+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*C*D)*E*F)+G"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A-B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((((A*B)+C)/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*C*D*E)+F"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B*C)+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A*B)+C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*1)"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*D*E*F)+G"      ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+(D*E*F)"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/(1+(-1*(B+C))))*D)+E"      ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A-(B*C))*D)+E"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))/C)*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*((C*D)*E)*F)+G"         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((((A/B)*C)+D)*((E*F)*G))+H"   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A+(-1*B))/C)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*(((C*D)*E)*F))+(C*D*G))` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+((A*C)-A)*D)+E"         ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*((C*D)*E)*F)*G)+H"     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*(((C*D)*E)*F))+G"       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*((C*D)*E))+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A/(A+B))"                     ` |
|  ✔ Passed               | 00:00:00.00 | `VerifyOptimizerForComplexExpressions (A!)         ` |

### PoorlyFormedExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions                           ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (-A!)                     ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B/*1)                    ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B**)                     ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B**A)                    ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B***A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B*+*A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B*-*A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions ()                        ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (b)                       ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (b+1)                     ` |

## BinaryDataDecoders.ExpressionCalculator.Tests.Expressions.ExpressionBaseTests

### ImplicitConvertTest_OverlyComplex
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.01 | `ImplicitConvertTest_OverlyComplex                 ` |

### ImplicitConvertTest_Number
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `ImplicitConvertTest_Number                        ` |

### ImplicitConvertTest_Expression
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `ImplicitConvertTest_Expression                    ` |

### ImplicitConvertTest_WayMoreOverlyComplex
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `ImplicitConvertTest_WayMoreOverlyComplex          ` |

### ImplicitConvertTest_Variable
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `ImplicitConvertTest_Variable                      ` |

### ImplicitConvertTest_MoreOverlyComplex
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `ImplicitConvertTest_MoreOverlyComplex             ` |

## BinaryDataDecoders.ExpressionCalculator.Tests.Parser.UInt8ExpressionParserTests

### GetDistinctVariablesTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests                         ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (A+B+C,A, B, C)         ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (A+B+B,A, B)            ` |
|  ✔ Passed               | 00:00:00.00 | `GetDistinctVariablesTests (Abc+XyW1,Abc, XyW1)    ` |

### OptimizerTests_WithExceptions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions                     ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions (B/0)               ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests_WithExceptions (B%0)               ` |

### PoorlyFormedExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.01 | `PoorlyFormedExpressions                           ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (-A!)                     ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B/*1)                    ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B**)                     ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B**A)                    ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B***A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B*+*A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (B*-*A)                   ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions ()                        ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (b)                       ` |
|  ✔ Passed               | 00:00:00.00 | `PoorlyFormedExpressions (b+1)                     ` |

### OptimizerTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.02 | `OptimizerTests                                    ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A),A)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A+(B)),A + B)                    ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B^1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*1,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (1*B,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (B*-1,-B)                          ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (-1*B,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/1,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (B/-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B+0,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0+B,B)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B-0,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (0-B,-B)                           ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (2+3*4^5%6/7-8,-6)                 ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (2+3,5)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B/B,1)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B^0,1)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0^B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0*B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B*0,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0/B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (0%B,0)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (B%1,0)                            ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (B%-1,0)                           ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (-(B),-B)                          ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (-(3),-3)                          ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (-3,-3)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (--B,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (---B,-B)                          ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (-1*(A*B),-(A * B))                ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests (A!,A!)                            ` |
|  ✔ Passed               | 00:00:00.00 | `OptimizerTests ((A)!,A!)                          ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (3!!,720)                          ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (2!!!,2)                           ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (N!!,N!!)                          ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `OptimizerTests (N!!!,N!!!)                        ` |

### SimpleParserTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.01 | `SimpleParserTests                                 ` |
|  ✔ Passed               | 00:00:00.00 | `Parse all operators test                          ` |
|  ✔ Passed               | 00:00:00.00 | `Simple test with variable                         ` |
|  ✔ Passed               | 00:00:00.00 | `Just variable                                     ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Just decimal value                                ` |
|  ✔ Passed               | 00:00:00.00 | `Simple factorial                                  ` |
|  ✔ Passed               | 00:00:00.00 | `Negative factorial                                ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Parse Complex Expression                          ` |
|  ✔ Passed               | 00:00:00.00 | `SimpleParserTests (B*--A,B * --A)                 ` |

### VerifyOptimizerForComplexExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.04 | `VerifyOptimizerForComplexExpressions              ` |
|  ✔ Passed               | 00:00:00.01 | `Check Expressions "A"                             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*1"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B)+C"                       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B)"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A-B)/A"                       ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+B+((C*D)+E))*F)+G+((D/H)*I)` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*(B/C)+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*B+C"                         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A-(B*C))/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A/B)-(C+D+E+F)"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A*B)*C)*D)+E"               ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B*(C/D))+E"                 ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(B/C)+D)"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A+B"                           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*(C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((B*C)+D))*E)+F+(C*G)+H"   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+((B*C)+D))*E+F+(A+((B*C)+D))` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+((D*B)+E)"           ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((A*B)+C)+(-1*A)"              ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A+(-1*B))+((C*D)+E))*F)+G+(D` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((A*(B+(-1*C)))+D)+((E*(B+(-1*C` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A+(-1*B))*C)+D)+(B+(-1*A))" ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A+((B*C)+D))*E)+F+((C/G)*H)+I` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+B)*C+D+(A+B)*E+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "A*B"                           ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((A+((-1*B)*(C/D)))*(E/C))+(-1*` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/(1-B))*C)+D"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A-(B*C))/(1-D))*E)+F"       ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(A*(1+(-1*B))+C)*D+E"          ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A+B)*C+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*C*D)*E*F)+G"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A-B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((((A*B)+C)/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*C*D*E)+F"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*B*C)+D"                     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A*B)+C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A*1)"                         ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*D*E*F)+G"      ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+C)+(D*E*F)"             ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((A/(1+(-1*(B+C))))*D)+E"      ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A-(B*C))*D)+E"               ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A+(-1*B))/C)*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*((C*D)*E)*F)+G"         ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((((A/B)*C)+D)*((E*F)*G))+H"   ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A/B)+(-1*C))*((D*E)*F)*G)+H"` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "(((A+(-1*B))/C)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*(((C*D)*E)*F))+(C*D*G))` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A*B)+((A*C)-A)*D)+E"         ` |
|  ⚠ Inconclusive        | 00:00:00.00 | `Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(((A/B)*((C*D)*E)*F)*G)+H"     ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*(((C*D)*E)*F))+G"       ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "((A/B)*((C*D)*E))+F"           ` |
|  ✔ Passed               | 00:00:00.00 | `Check Expressions "(A/(A+B))"                     ` |
|  ✔ Passed               | 00:00:00.00 | `VerifyOptimizerForComplexExpressions (A!)         ` |

