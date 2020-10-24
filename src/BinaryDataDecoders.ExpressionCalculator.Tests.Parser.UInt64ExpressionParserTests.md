## BinaryDataDecoders.ExpressionCalculator.Tests.Parser.UInt64ExpressionParserTests

### PoorlyFormedExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0104556 | `PoorlyFormedExpressions                           ` |
|  ✔ Passed               | 00:00:00.0044262 | `PoorlyFormedExpressions (-A!)                     ` |
|  ✔ Passed               | 00:00:00.0007777 | `PoorlyFormedExpressions (B/*1)                    ` |
|  ✔ Passed               | 00:00:00.0005792 | `PoorlyFormedExpressions (B**)                     ` |
|  ✔ Passed               | 00:00:00.0005226 | `PoorlyFormedExpressions (B**A)                    ` |
|  ✔ Passed               | 00:00:00.0005110 | `PoorlyFormedExpressions (B***A)                   ` |
|  ✔ Passed               | 00:00:00.0004792 | `PoorlyFormedExpressions (B*+*A)                   ` |
|  ✔ Passed               | 00:00:00.0005240 | `PoorlyFormedExpressions (B*-*A)                   ` |
|  ✔ Passed               | 00:00:00.0004302 | `PoorlyFormedExpressions ()                        ` |
|  ✔ Passed               | 00:00:00.0007231 | `PoorlyFormedExpressions (b)                       ` |
|  ✔ Passed               | 00:00:00.0008659 | `PoorlyFormedExpressions (b+1)                     ` |

### OptimizerTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.0248728 | `OptimizerTests                                    ` |
|  ✔ Passed               | 00:00:00.0028640 | `OptimizerTests ((A),A)                            ` |
|  ✔ Passed               | 00:00:00.0022765 | `OptimizerTests ((A+(B)),A + B)                    ` |
|  ✔ Passed               | 00:00:00.0001943 | `OptimizerTests (B^1,B)                            ` |
|  ✔ Passed               | 00:00:00.0000562 | `OptimizerTests (B*1,B)                            ` |
|  ✔ Passed               | 00:00:00.0000357 | `OptimizerTests (1*B,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.0022627 | `OptimizerTests (B*-1,-B)                          ` |
|  ⚠ Inconclusive        | 00:00:00.0007318 | `OptimizerTests (-1*B,-B)                          ` |
|  ✔ Passed               | 00:00:00.0000760 | `OptimizerTests (B/1,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.0006677 | `OptimizerTests (B/-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.0000784 | `OptimizerTests (B+0,B)                            ` |
|  ✔ Passed               | 00:00:00.0000348 | `OptimizerTests (0+B,B)                            ` |
|  ✔ Passed               | 00:00:00.0000282 | `OptimizerTests (B-0,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.0006181 | `OptimizerTests (0-B,-B)                           ` |
|  ⚠ Inconclusive        | 00:00:00.0022603 | `OptimizerTests (2+3*4^5%6/7-8,-6)                 ` |
|  ✔ Passed               | 00:00:00.0001097 | `OptimizerTests (2+3,5)                            ` |
|  ✔ Passed               | 00:00:00.0007700 | `OptimizerTests (B/B,1)                            ` |
|  ✔ Passed               | 00:00:00.0001581 | `OptimizerTests (B%B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000981 | `OptimizerTests (B^0,1)                            ` |
|  ✔ Passed               | 00:00:00.0000513 | `OptimizerTests (0^B,0)                            ` |
|  ✔ Passed               | 00:00:00.0002543 | `OptimizerTests (0*B,0)                            ` |
|  ✔ Passed               | 00:00:00.0001870 | `OptimizerTests (B*0,0)                            ` |
|  ✔ Passed               | 00:00:00.0000685 | `OptimizerTests (0/B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000552 | `OptimizerTests (0%B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000458 | `OptimizerTests (B%1,0)                            ` |
|  ⚠ Inconclusive        | 00:00:00.0013288 | `OptimizerTests (B%-1,0)                           ` |
|  ⚠ Inconclusive        | 00:00:00.0010007 | `OptimizerTests (-(B),-B)                          ` |
|  ⚠ Inconclusive        | 00:00:00.0010077 | `OptimizerTests (-(3),-3)                          ` |
|  ⚠ Inconclusive        | 00:00:00.0007670 | `OptimizerTests (-3,-3)                            ` |
|  ✔ Passed               | 00:00:00.0003149 | `OptimizerTests (--B,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.0006689 | `OptimizerTests (---B,-B)                          ` |
|  ⚠ Inconclusive        | 00:00:00.0009428 | `OptimizerTests (-1*(A*B),-(A * B))                ` |
|  ✔ Passed               | 00:00:00.0000908 | `OptimizerTests (A!,A!)                            ` |
|  ✔ Passed               | 00:00:00.0000396 | `OptimizerTests ((A)!,A!)                          ` |
|  ✔ Passed               | 00:00:00.0027373 | `OptimizerTests (3!!,720)                          ` |
|  ✔ Passed               | 00:00:00.0001193 | `OptimizerTests (2!!!,2)                           ` |
|  ✔ Passed               | 00:00:00.0000508 | `OptimizerTests (N!!,N!!)                          ` |
|  ✔ Passed               | 00:00:00.0000459 | `OptimizerTests (N!!!,N!!!)                        ` |

### VerifyOptimizerForComplexExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.0461177 | `VerifyOptimizerForComplexExpressions              ` |
|  ✔ Passed               | 00:00:00.0143197 | `Check Expressions "A"                             ` |
|  ✔ Passed               | 00:00:00.0001596 | `Check Expressions "A*1"                           ` |
|  ✔ Passed               | 00:00:00.0000840 | `Check Expressions "(A*B)+C"                       ` |
|  ✔ Passed               | 00:00:00.0000740 | `Check Expressions "(A*B)"                         ` |
|  ✔ Passed               | 00:00:00.0000763 | `Check Expressions "(A-B)/A"                       ` |
|  ⚠ Inconclusive        | 00:00:00.0009338 | `Check Expressions "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"` |
|  ✔ Passed               | 00:00:00.0010985 | `Check Expressions "((A+B+((C*D)+E))*F)+G+((D/H)*I)` |
|  ✔ Passed               | 00:00:00.0001246 | `Check Expressions "A*(B/C)+D"                     ` |
|  ✔ Passed               | 00:00:00.0000784 | `Check Expressions "A*B+C"                         ` |
|  ✔ Passed               | 00:00:00.0001379 | `Check Expressions "(((A-(B*C))/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.0001468 | `Check Expressions "(A/B)-(C+D+E+F)"               ` |
|  ✔ Passed               | 00:00:00.0001021 | `Check Expressions "((A*B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0001058 | `Check Expressions "(((A*B)*C)*D)+E"               ` |
|  ⚠ Inconclusive        | 00:00:00.0007965 | `Check Expressions "(((A/B)+(-1*C))*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.0002008 | `Check Expressions "(A*B*(C/D))+E"                 ` |
|  ✔ Passed               | 00:00:00.0000834 | `Check Expressions "(A*(B/C)+D)"                   ` |
|  ✔ Passed               | 00:00:00.0000436 | `Check Expressions "A+B"                           ` |
|  ✔ Passed               | 00:00:00.0001286 | `Check Expressions "((A/B)*(C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.0001555 | `Check Expressions "((A+((B*C)+D))*E)+F+(C*G)+H"   ` |
|  ✔ Passed               | 00:00:00.0001715 | `Check Expressions "(A+((B*C)+D))*E+F+(A+((B*C)+D))` |
|  ⚠ Inconclusive        | 00:00:00.0007986 | `Check Expressions "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"` |
|  ✔ Passed               | 00:00:00.0002238 | `Check Expressions "((A*B)+C)+((D*B)+E)"           ` |
|  ⚠ Inconclusive        | 00:00:00.0009461 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"` |
|  ⚠ Inconclusive        | 00:00:00.0008464 | `Check Expressions "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"` |
|  ✔ Passed               | 00:00:00.0003897 | `Check Expressions "(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)"` |
|  ⚠ Inconclusive        | 00:00:00.0010691 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"` |
|  ⚠ Inconclusive        | 00:00:00.0007703 | `Check Expressions "((A*B)+C)+(-1*A)"              ` |
|  ⚠ Inconclusive        | 00:00:00.0007941 | `Check Expressions "(((A+(-1*B))+((C*D)+E))*F)+G+(D` |
|  ⚠ Inconclusive        | 00:00:00.0011802 | `Check Expressions "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"` |
|  ⚠ Inconclusive        | 00:00:00.0011165 | `Check Expressions "((A*(B+(-1*C)))+D)+((E*(B+(-1*C` |
|  ⚠ Inconclusive        | 00:00:00.0010867 | `Check Expressions "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"` |
|  ⚠ Inconclusive        | 00:00:00.0010257 | `Check Expressions "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"` |
|  ⚠ Inconclusive        | 00:00:00.0010897 | `Check Expressions "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"` |
|  ⚠ Inconclusive        | 00:00:00.0006688 | `Check Expressions "(((A+(-1*B))*C)+D)+(B+(-1*A))" ` |
|  ⚠ Inconclusive        | 00:00:00.0008323 | `Check Expressions "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"` |
|  ✔ Passed               | 00:00:00.0002969 | `Check Expressions "((A+((B*C)+D))*E)+F+((C/G)*H)+I` |
|  ✔ Passed               | 00:00:00.0002045 | `Check Expressions "(A+B)*C+D+(A+B)*E+F"           ` |
|  ✔ Passed               | 00:00:00.0000680 | `Check Expressions "A*B"                           ` |
|  ⚠ Inconclusive        | 00:00:00.0010992 | `Check Expressions "((A+((-1*B)*(C/D)))*(E/C))+(-1*` |
|  ✔ Passed               | 00:00:00.0002290 | `Check Expressions "((A/(1-B))*C)+D"               ` |
|  ✔ Passed               | 00:00:00.0001653 | `Check Expressions "(((A-(B*C))/(1-D))*E)+F"       ` |
|  ⚠ Inconclusive        | 00:00:00.0007466 | `Check Expressions "(A*(1+(-1*B))+C)*D+E"          ` |
|  ✔ Passed               | 00:00:00.0001539 | `Check Expressions "(A+B)*C+D"                     ` |
|  ✔ Passed               | 00:00:00.0001641 | `Check Expressions "(((A/B)*C*D)*E*F)+G"           ` |
|  ✔ Passed               | 00:00:00.0000862 | `Check Expressions "((A-B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0000923 | `Check Expressions "((A/B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0001430 | `Check Expressions "((((A*B)+C)/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.0001211 | `Check Expressions "((A/B)*C*D*E)+F"               ` |
|  ✔ Passed               | 00:00:00.0000781 | `Check Expressions "(A*B*C)+D"                     ` |
|  ✔ Passed               | 00:00:00.0001339 | `Check Expressions "(((A*B)+C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.0001578 | `Check Expressions "(((A/B)*C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.0000674 | `Check Expressions "(A*1)"                         ` |
|  ⚠ Inconclusive        | 00:00:00.0008188 | `Check Expressions "(((A/B)+(-1*C))*D*E*F)+G"      ` |
|  ✔ Passed               | 00:00:00.0002075 | `Check Expressions "((A*B)+C)+(D*E*F)"             ` |
|  ⚠ Inconclusive        | 00:00:00.0008423 | `Check Expressions "((A/(1+(-1*(B+C))))*D)+E"      ` |
|  ✔ Passed               | 00:00:00.0001869 | `Check Expressions "((A-(B*C))*D)+E"               ` |
|  ⚠ Inconclusive        | 00:00:00.0008209 | `Check Expressions "(((A+(-1*B))/C)*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.0002432 | `Check Expressions "((A/B)*((C*D)*E)*F)+G"         ` |
|  ✔ Passed               | 00:00:00.0002363 | `Check Expressions "((((A/B)*C)+D)*((E*F)*G))+H"   ` |
|  ⚠ Inconclusive        | 00:00:00.0010757 | `Check Expressions "(((A/B)+(-1*C))*((D*E)*F)*G)+H"` |
|  ⚠ Inconclusive        | 00:00:00.0013584 | `Check Expressions "(((A+(-1*B))/C)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.0005199 | `Check Expressions "(((A/B)*(((C*D)*E)*F))+(C*D*G))` |
|  ✔ Passed               | 00:00:00.0002402 | `Check Expressions "((A*B)+((A*C)-A)*D)+E"         ` |
|  ⚠ Inconclusive        | 00:00:00.0008643 | `Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.0003231 | `Check Expressions "(((A/B)*((C*D)*E)*F)*G)+H"     ` |
|  ✔ Passed               | 00:00:00.0002205 | `Check Expressions "((A/B)*(((C*D)*E)*F))+G"       ` |
|  ✔ Passed               | 00:00:00.0001704 | `Check Expressions "((A/B)*((C*D)*E))+F"           ` |
|  ✔ Passed               | 00:00:00.0001087 | `Check Expressions "(A/(A+B))"                     ` |
|  ✔ Passed               | 00:00:00.0000612 | `VerifyOptimizerForComplexExpressions (A!)         ` |

### OptimizerTests_WithExceptions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0014025 | `OptimizerTests_WithExceptions                     ` |
|  ✔ Passed               | 00:00:00.0009123 | `OptimizerTests_WithExceptions (B/0)               ` |
|  ✔ Passed               | 00:00:00.0003738 | `OptimizerTests_WithExceptions (B%0)               ` |

### GetDistinctVariablesTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0043332 | `GetDistinctVariablesTests                         ` |
|  ✔ Passed               | 00:00:00.0040455 | `GetDistinctVariablesTests (A+B+C,A, B, C)         ` |
|  ✔ Passed               | 00:00:00.0001050 | `GetDistinctVariablesTests (A+B+B,A, B)            ` |
|  ✔ Passed               | 00:00:00.0000325 | `GetDistinctVariablesTests (Abc+XyW1,Abc, XyW1)    ` |

### SimpleParserTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.0055983 | `SimpleParserTests                                 ` |
|  ✔ Passed               | 00:00:00.0023285 | `Parse all operators test                          ` |
|  ✔ Passed               | 00:00:00.0002377 | `Simple test with variable                         ` |
|  ✔ Passed               | 00:00:00.0000306 | `Just variable                                     ` |
|  ⚠ Inconclusive        | 00:00:00.0007878 | `Just decimal value                                ` |
|  ✔ Passed               | 00:00:00.0008600 | `Simple factorial                                  ` |
|  ✔ Passed               | 00:00:00.0004091 | `Negative factorial                                ` |
|  ⚠ Inconclusive        | 00:00:00.0005469 | `Parse Complex Expression                          ` |
|  ✔ Passed               | 00:00:00.0000596 | `SimpleParserTests (B*--A,B * --A)                 ` |

