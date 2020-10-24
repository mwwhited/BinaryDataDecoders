## BinaryDataDecoders.ExpressionCalculator.Tests.Parser.Int16ExpressionParserTests

### SimpleParserTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.0054755 | `SimpleParserTests                                 ` |
|  ✔ Passed               | 00:00:00.0020498 | `Parse all operators test                          ` |
|  ✔ Passed               | 00:00:00.0002208 | `Simple test with variable                         ` |
|  ✔ Passed               | 00:00:00.0000370 | `Just variable                                     ` |
|  ⚠ Inconclusive        | 00:00:00.0008017 | `Just decimal value                                ` |
|  ✔ Passed               | 00:00:00.0007821 | `Simple factorial                                  ` |
|  ✔ Passed               | 00:00:00.0005395 | `Negative factorial                                ` |
|  ⚠ Inconclusive        | 00:00:00.0006258 | `Parse Complex Expression                          ` |
|  ✔ Passed               | 00:00:00.0000717 | `SimpleParserTests (B*--A,B * --A)                 ` |

### OptimizerTests_WithExceptions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0014008 | `OptimizerTests_WithExceptions                     ` |
|  ✔ Passed               | 00:00:00.0008544 | `OptimizerTests_WithExceptions (B/0)               ` |
|  ✔ Passed               | 00:00:00.0004167 | `OptimizerTests_WithExceptions (B%0)               ` |

### VerifyOptimizerForComplexExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.0341556 | `VerifyOptimizerForComplexExpressions              ` |
|  ✔ Passed               | 00:00:00.0131080 | `Check Expressions "A"                             ` |
|  ✔ Passed               | 00:00:00.0001547 | `Check Expressions "A*1"                           ` |
|  ✔ Passed               | 00:00:00.0000849 | `Check Expressions "(A*B)+C"                       ` |
|  ✔ Passed               | 00:00:00.0000537 | `Check Expressions "(A*B)"                         ` |
|  ✔ Passed               | 00:00:00.0000728 | `Check Expressions "(A-B)/A"                       ` |
|  ✔ Passed               | 00:00:00.0013097 | `Check Expressions "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"` |
|  ✔ Passed               | 00:00:00.0003566 | `Check Expressions "((A+B+((C*D)+E))*F)+G+((D/H)*I)` |
|  ✔ Passed               | 00:00:00.0001593 | `Check Expressions "A*(B/C)+D"                     ` |
|  ✔ Passed               | 00:00:00.0000982 | `Check Expressions "A*B+C"                         ` |
|  ✔ Passed               | 00:00:00.0002058 | `Check Expressions "(((A-(B*C))/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.0001789 | `Check Expressions "(A/B)-(C+D+E+F)"               ` |
|  ✔ Passed               | 00:00:00.0001414 | `Check Expressions "((A*B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0001738 | `Check Expressions "(((A*B)*C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.0003012 | `Check Expressions "(((A/B)+(-1*C))*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.0001774 | `Check Expressions "(A*B*(C/D))+E"                 ` |
|  ✔ Passed               | 00:00:00.0001222 | `Check Expressions "(A*(B/C)+D)"                   ` |
|  ✔ Passed               | 00:00:00.0000691 | `Check Expressions "A+B"                           ` |
|  ✔ Passed               | 00:00:00.0001756 | `Check Expressions "((A/B)*(C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.0003053 | `Check Expressions "((A+((B*C)+D))*E)+F+(C*G)+H"   ` |
|  ✔ Passed               | 00:00:00.0003102 | `Check Expressions "(A+((B*C)+D))*E+F+(A+((B*C)+D))` |
|  ✔ Passed               | 00:00:00.0004483 | `Check Expressions "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"` |
|  ✔ Passed               | 00:00:00.0001900 | `Check Expressions "((A*B)+C)+((D*B)+E)"           ` |
|  ✔ Passed               | 00:00:00.0006915 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"` |
|  ✔ Passed               | 00:00:00.0005485 | `Check Expressions "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"` |
|  ✔ Passed               | 00:00:00.0005624 | `Check Expressions "(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)"` |
|  ✔ Passed               | 00:00:00.0008756 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"` |
|  ✔ Passed               | 00:00:00.0001669 | `Check Expressions "((A*B)+C)+(-1*A)"              ` |
|  ✔ Passed               | 00:00:00.0003652 | `Check Expressions "(((A+(-1*B))+((C*D)+E))*F)+G+(D` |
|  ✔ Passed               | 00:00:00.0004550 | `Check Expressions "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"` |
|  ✔ Passed               | 00:00:00.0004537 | `Check Expressions "((A*(B+(-1*C)))+D)+((E*(B+(-1*C` |
|  ✔ Passed               | 00:00:00.0009790 | `Check Expressions "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"` |
|  ✔ Passed               | 00:00:00.0008573 | `Check Expressions "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"` |
|  ✔ Passed               | 00:00:00.0012461 | `Check Expressions "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"` |
|  ✔ Passed               | 00:00:00.0003268 | `Check Expressions "(((A+(-1*B))*C)+D)+(B+(-1*A))" ` |
|  ✔ Passed               | 00:00:00.0003668 | `Check Expressions "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"` |
|  ✔ Passed               | 00:00:00.0002940 | `Check Expressions "((A+((B*C)+D))*E)+F+((C/G)*H)+I` |
|  ✔ Passed               | 00:00:00.0001612 | `Check Expressions "(A+B)*C+D+(A+B)*E+F"           ` |
|  ✔ Passed               | 00:00:00.0000620 | `Check Expressions "A*B"                           ` |
|  ✔ Passed               | 00:00:00.0002780 | `Check Expressions "((A+((-1*B)*(C/D)))*(E/C))+(-1*` |
|  ✔ Passed               | 00:00:00.0001178 | `Check Expressions "((A/(1-B))*C)+D"               ` |
|  ✔ Passed               | 00:00:00.0001378 | `Check Expressions "(((A-(B*C))/(1-D))*E)+F"       ` |
|  ✔ Passed               | 00:00:00.0001229 | `Check Expressions "(A*(1+(-1*B))+C)*D+E"          ` |
|  ✔ Passed               | 00:00:00.0000725 | `Check Expressions "(A+B)*C+D"                     ` |
|  ✔ Passed               | 00:00:00.0001346 | `Check Expressions "(((A/B)*C*D)*E*F)+G"           ` |
|  ✔ Passed               | 00:00:00.0000753 | `Check Expressions "((A-B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0000803 | `Check Expressions "((A/B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0001342 | `Check Expressions "((((A*B)+C)/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.0001066 | `Check Expressions "((A/B)*C*D*E)+F"               ` |
|  ✔ Passed               | 00:00:00.0000697 | `Check Expressions "(A*B*C)+D"                     ` |
|  ✔ Passed               | 00:00:00.0000893 | `Check Expressions "(((A*B)+C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.0001332 | `Check Expressions "(((A/B)*C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.0000495 | `Check Expressions "(A*1)"                         ` |
|  ✔ Passed               | 00:00:00.0001413 | `Check Expressions "(((A/B)+(-1*C))*D*E*F)+G"      ` |
|  ✔ Passed               | 00:00:00.0001197 | `Check Expressions "((A*B)+C)+(D*E*F)"             ` |
|  ✔ Passed               | 00:00:00.0001821 | `Check Expressions "((A/(1+(-1*(B+C))))*D)+E"      ` |
|  ✔ Passed               | 00:00:00.0001206 | `Check Expressions "((A-(B*C))*D)+E"               ` |
|  ✔ Passed               | 00:00:00.0001815 | `Check Expressions "(((A+(-1*B))/C)*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.0001642 | `Check Expressions "((A/B)*((C*D)*E)*F)+G"         ` |
|  ✔ Passed               | 00:00:00.0002037 | `Check Expressions "((((A/B)*C)+D)*((E*F)*G))+H"   ` |
|  ✔ Passed               | 00:00:00.0002414 | `Check Expressions "(((A/B)+(-1*C))*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.0002179 | `Check Expressions "(((A+(-1*B))/C)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.0002880 | `Check Expressions "(((A/B)*(((C*D)*E)*F))+(C*D*G))` |
|  ✔ Passed               | 00:00:00.0001437 | `Check Expressions "((A*B)+((A*C)-A)*D)+E"         ` |
|  ⚠ Inconclusive        | 00:00:00.0008552 | `Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.0003415 | `Check Expressions "(((A/B)*((C*D)*E)*F)*G)+H"     ` |
|  ✔ Passed               | 00:00:00.0003317 | `Check Expressions "((A/B)*(((C*D)*E)*F))+G"       ` |
|  ✔ Passed               | 00:00:00.0002533 | `Check Expressions "((A/B)*((C*D)*E))+F"           ` |
|  ✔ Passed               | 00:00:00.0001237 | `Check Expressions "(A/(A+B))"                     ` |
|  ✔ Passed               | 00:00:00.0000718 | `VerifyOptimizerForComplexExpressions (A!)         ` |

### GetDistinctVariablesTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0046986 | `GetDistinctVariablesTests                         ` |
|  ✔ Passed               | 00:00:00.0043310 | `GetDistinctVariablesTests (A+B+C,A, B, C)         ` |
|  ✔ Passed               | 00:00:00.0001172 | `GetDistinctVariablesTests (A+B+B,A, B)            ` |
|  ✔ Passed               | 00:00:00.0000567 | `GetDistinctVariablesTests (Abc+XyW1,Abc, XyW1)    ` |

### OptimizerTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0144585 | `OptimizerTests                                    ` |
|  ✔ Passed               | 00:00:00.0026306 | `OptimizerTests ((A),A)                            ` |
|  ✔ Passed               | 00:00:00.0022677 | `OptimizerTests ((A+(B)),A + B)                    ` |
|  ✔ Passed               | 00:00:00.0002120 | `OptimizerTests (B^1,B)                            ` |
|  ✔ Passed               | 00:00:00.0000522 | `OptimizerTests (B*1,B)                            ` |
|  ✔ Passed               | 00:00:00.0000334 | `OptimizerTests (1*B,B)                            ` |
|  ✔ Passed               | 00:00:00.0020057 | `OptimizerTests (B*-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.0001319 | `OptimizerTests (-1*B,-B)                          ` |
|  ✔ Passed               | 00:00:00.0000413 | `OptimizerTests (B/1,B)                            ` |
|  ✔ Passed               | 00:00:00.0000503 | `OptimizerTests (B/-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.0000363 | `OptimizerTests (B+0,B)                            ` |
|  ✔ Passed               | 00:00:00.0000394 | `OptimizerTests (0+B,B)                            ` |
|  ✔ Passed               | 00:00:00.0000378 | `OptimizerTests (B-0,B)                            ` |
|  ✔ Passed               | 00:00:00.0000416 | `OptimizerTests (0-B,-B)                           ` |
|  ✔ Passed               | 00:00:00.0014259 | `OptimizerTests (2+3*4^5%6/7-8,-6)                 ` |
|  ✔ Passed               | 00:00:00.0000825 | `OptimizerTests (2+3,5)                            ` |
|  ✔ Passed               | 00:00:00.0004712 | `OptimizerTests (B/B,1)                            ` |
|  ✔ Passed               | 00:00:00.0000676 | `OptimizerTests (B%B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000607 | `OptimizerTests (B^0,1)                            ` |
|  ✔ Passed               | 00:00:00.0000335 | `OptimizerTests (0^B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000323 | `OptimizerTests (0*B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000395 | `OptimizerTests (B*0,0)                            ` |
|  ✔ Passed               | 00:00:00.0000320 | `OptimizerTests (0/B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000319 | `OptimizerTests (0%B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000273 | `OptimizerTests (B%1,0)                            ` |
|  ✔ Passed               | 00:00:00.0000435 | `OptimizerTests (B%-1,0)                           ` |
|  ✔ Passed               | 00:00:00.0002279 | `OptimizerTests (-(B),-B)                          ` |
|  ✔ Passed               | 00:00:00.0001379 | `OptimizerTests (-(3),-3)                          ` |
|  ✔ Passed               | 00:00:00.0000310 | `OptimizerTests (-3,-3)                            ` |
|  ✔ Passed               | 00:00:00.0002070 | `OptimizerTests (--B,B)                            ` |
|  ✔ Passed               | 00:00:00.0000429 | `OptimizerTests (---B,-B)                          ` |
|  ✔ Passed               | 00:00:00.0001763 | `OptimizerTests (-1*(A*B),-(A * B))                ` |
|  ✔ Passed               | 00:00:00.0000388 | `OptimizerTests (A!,A!)                            ` |
|  ✔ Passed               | 00:00:00.0000337 | `OptimizerTests ((A)!,A!)                          ` |
|  ✔ Passed               | 00:00:00.0024472 | `OptimizerTests (3!!,720)                          ` |
|  ✔ Passed               | 00:00:00.0000906 | `OptimizerTests (2!!!,2)                           ` |
|  ✔ Passed               | 00:00:00.0000308 | `OptimizerTests (N!!,N!!)                          ` |
|  ✔ Passed               | 00:00:00.0000368 | `OptimizerTests (N!!!,N!!!)                        ` |

### PoorlyFormedExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0097013 | `PoorlyFormedExpressions                           ` |
|  ✔ Passed               | 00:00:00.0048993 | `PoorlyFormedExpressions (-A!)                     ` |
|  ✔ Passed               | 00:00:00.0008933 | `PoorlyFormedExpressions (B/*1)                    ` |
|  ✔ Passed               | 00:00:00.0005304 | `PoorlyFormedExpressions (B**)                     ` |
|  ✔ Passed               | 00:00:00.0004806 | `PoorlyFormedExpressions (B**A)                    ` |
|  ✔ Passed               | 00:00:00.0004876 | `PoorlyFormedExpressions (B***A)                   ` |
|  ✔ Passed               | 00:00:00.0004053 | `PoorlyFormedExpressions (B*+*A)                   ` |
|  ✔ Passed               | 00:00:00.0004201 | `PoorlyFormedExpressions (B*-*A)                   ` |
|  ✔ Passed               | 00:00:00.0003392 | `PoorlyFormedExpressions ()                        ` |
|  ✔ Passed               | 00:00:00.0004268 | `PoorlyFormedExpressions (b)                       ` |
|  ✔ Passed               | 00:00:00.0003611 | `PoorlyFormedExpressions (b+1)                     ` |

