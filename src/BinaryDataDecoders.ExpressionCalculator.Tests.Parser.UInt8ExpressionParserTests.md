## BinaryDataDecoders.ExpressionCalculator.Tests.Parser.UInt8ExpressionParserTests

### GetDistinctVariablesTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0035146 | `GetDistinctVariablesTests                         ` |
|  ✔ Passed               | 00:00:00.0032555 | `GetDistinctVariablesTests (A+B+C,A, B, C)         ` |
|  ✔ Passed               | 00:00:00.0000837 | `GetDistinctVariablesTests (A+B+B,A, B)            ` |
|  ✔ Passed               | 00:00:00.0000312 | `GetDistinctVariablesTests (Abc+XyW1,Abc, XyW1)    ` |

### OptimizerTests_WithExceptions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0022001 | `OptimizerTests_WithExceptions                     ` |
|  ✔ Passed               | 00:00:00.0014386 | `OptimizerTests_WithExceptions (B/0)               ` |
|  ✔ Passed               | 00:00:00.0005717 | `OptimizerTests_WithExceptions (B%0)               ` |

### PoorlyFormedExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0096591 | `PoorlyFormedExpressions                           ` |
|  ✔ Passed               | 00:00:00.0045287 | `PoorlyFormedExpressions (-A!)                     ` |
|  ✔ Passed               | 00:00:00.0007822 | `PoorlyFormedExpressions (B/*1)                    ` |
|  ✔ Passed               | 00:00:00.0005448 | `PoorlyFormedExpressions (B**)                     ` |
|  ✔ Passed               | 00:00:00.0005193 | `PoorlyFormedExpressions (B**A)                    ` |
|  ✔ Passed               | 00:00:00.0005009 | `PoorlyFormedExpressions (B***A)                   ` |
|  ✔ Passed               | 00:00:00.0005134 | `PoorlyFormedExpressions (B*+*A)                   ` |
|  ✔ Passed               | 00:00:00.0005392 | `PoorlyFormedExpressions (B*-*A)                   ` |
|  ✔ Passed               | 00:00:00.0003924 | `PoorlyFormedExpressions ()                        ` |
|  ✔ Passed               | 00:00:00.0003952 | `PoorlyFormedExpressions (b)                       ` |
|  ✔ Passed               | 00:00:00.0004080 | `PoorlyFormedExpressions (b+1)                     ` |

### OptimizerTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.0241332 | `OptimizerTests                                    ` |
|  ✔ Passed               | 00:00:00.0035283 | `OptimizerTests ((A),A)                            ` |
|  ✔ Passed               | 00:00:00.0022911 | `OptimizerTests ((A+(B)),A + B)                    ` |
|  ✔ Passed               | 00:00:00.0002026 | `OptimizerTests (B^1,B)                            ` |
|  ✔ Passed               | 00:00:00.0000503 | `OptimizerTests (B*1,B)                            ` |
|  ✔ Passed               | 00:00:00.0000392 | `OptimizerTests (1*B,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.0022994 | `OptimizerTests (B*-1,-B)                          ` |
|  ⚠ Inconclusive        | 00:00:00.0007009 | `OptimizerTests (-1*B,-B)                          ` |
|  ✔ Passed               | 00:00:00.0000828 | `OptimizerTests (B/1,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.0005552 | `OptimizerTests (B/-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.0000479 | `OptimizerTests (B+0,B)                            ` |
|  ✔ Passed               | 00:00:00.0000297 | `OptimizerTests (0+B,B)                            ` |
|  ✔ Passed               | 00:00:00.0000282 | `OptimizerTests (B-0,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.0004759 | `OptimizerTests (0-B,-B)                           ` |
|  ⚠ Inconclusive        | 00:00:00.0018220 | `OptimizerTests (2+3*4^5%6/7-8,-6)                 ` |
|  ✔ Passed               | 00:00:00.0001248 | `OptimizerTests (2+3,5)                            ` |
|  ✔ Passed               | 00:00:00.0005297 | `OptimizerTests (B/B,1)                            ` |
|  ✔ Passed               | 00:00:00.0000702 | `OptimizerTests (B%B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000395 | `OptimizerTests (B^0,1)                            ` |
|  ✔ Passed               | 00:00:00.0000426 | `OptimizerTests (0^B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000303 | `OptimizerTests (0*B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000289 | `OptimizerTests (B*0,0)                            ` |
|  ✔ Passed               | 00:00:00.0000415 | `OptimizerTests (0/B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000462 | `OptimizerTests (0%B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000431 | `OptimizerTests (B%1,0)                            ` |
|  ⚠ Inconclusive        | 00:00:00.0008089 | `OptimizerTests (B%-1,0)                           ` |
|  ⚠ Inconclusive        | 00:00:00.0015382 | `OptimizerTests (-(B),-B)                          ` |
|  ⚠ Inconclusive        | 00:00:00.0014235 | `OptimizerTests (-(3),-3)                          ` |
|  ⚠ Inconclusive        | 00:00:00.0020541 | `OptimizerTests (-3,-3)                            ` |
|  ✔ Passed               | 00:00:00.0003669 | `OptimizerTests (--B,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.0006641 | `OptimizerTests (---B,-B)                          ` |
|  ⚠ Inconclusive        | 00:00:00.0009585 | `OptimizerTests (-1*(A*B),-(A * B))                ` |
|  ✔ Passed               | 00:00:00.0000692 | `OptimizerTests (A!,A!)                            ` |
|  ✔ Passed               | 00:00:00.0000352 | `OptimizerTests ((A)!,A!)                          ` |
|  ⚠ Inconclusive        | 00:00:00.0005343 | `OptimizerTests (3!!,720)                          ` |
|  ⚠ Inconclusive        | 00:00:00.0004566 | `OptimizerTests (2!!!,2)                           ` |
|  ⚠ Inconclusive        | 00:00:00.0004255 | `OptimizerTests (N!!,N!!)                          ` |
|  ⚠ Inconclusive        | 00:00:00.0003877 | `OptimizerTests (N!!!,N!!!)                        ` |

### SimpleParserTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.0049424 | `SimpleParserTests                                 ` |
|  ✔ Passed               | 00:00:00.0016775 | `Parse all operators test                          ` |
|  ✔ Passed               | 00:00:00.0001795 | `Simple test with variable                         ` |
|  ✔ Passed               | 00:00:00.0000285 | `Just variable                                     ` |
|  ⚠ Inconclusive        | 00:00:00.0007082 | `Just decimal value                                ` |
|  ✔ Passed               | 00:00:00.0007747 | `Simple factorial                                  ` |
|  ✔ Passed               | 00:00:00.0005476 | `Negative factorial                                ` |
|  ⚠ Inconclusive        | 00:00:00.0006063 | `Parse Complex Expression                          ` |
|  ✔ Passed               | 00:00:00.0001149 | `SimpleParserTests (B*--A,B * --A)                 ` |

### VerifyOptimizerForComplexExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.0611608 | `VerifyOptimizerForComplexExpressions              ` |
|  ✔ Passed               | 00:00:00.0184303 | `Check Expressions "A"                             ` |
|  ✔ Passed               | 00:00:00.0002971 | `Check Expressions "A*1"                           ` |
|  ✔ Passed               | 00:00:00.0001658 | `Check Expressions "(A*B)+C"                       ` |
|  ✔ Passed               | 00:00:00.0000973 | `Check Expressions "(A*B)"                         ` |
|  ✔ Passed               | 00:00:00.0001510 | `Check Expressions "(A-B)/A"                       ` |
|  ⚠ Inconclusive        | 00:00:00.0014561 | `Check Expressions "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"` |
|  ✔ Passed               | 00:00:00.0014047 | `Check Expressions "((A+B+((C*D)+E))*F)+G+((D/H)*I)` |
|  ✔ Passed               | 00:00:00.0001777 | `Check Expressions "A*(B/C)+D"                     ` |
|  ✔ Passed               | 00:00:00.0000955 | `Check Expressions "A*B+C"                         ` |
|  ✔ Passed               | 00:00:00.0001945 | `Check Expressions "(((A-(B*C))/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.0001187 | `Check Expressions "(A/B)-(C+D+E+F)"               ` |
|  ✔ Passed               | 00:00:00.0001239 | `Check Expressions "((A*B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0003737 | `Check Expressions "(((A*B)*C)*D)+E"               ` |
|  ⚠ Inconclusive        | 00:00:00.0014317 | `Check Expressions "(((A/B)+(-1*C))*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.0002705 | `Check Expressions "(A*B*(C/D))+E"                 ` |
|  ✔ Passed               | 00:00:00.0001421 | `Check Expressions "(A*(B/C)+D)"                   ` |
|  ✔ Passed               | 00:00:00.0000693 | `Check Expressions "A+B"                           ` |
|  ✔ Passed               | 00:00:00.0002066 | `Check Expressions "((A/B)*(C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.0002736 | `Check Expressions "((A+((B*C)+D))*E)+F+(C*G)+H"   ` |
|  ✔ Passed               | 00:00:00.0002904 | `Check Expressions "(A+((B*C)+D))*E+F+(A+((B*C)+D))` |
|  ⚠ Inconclusive        | 00:00:00.0012042 | `Check Expressions "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"` |
|  ✔ Passed               | 00:00:00.0002725 | `Check Expressions "((A*B)+C)+((D*B)+E)"           ` |
|  ⚠ Inconclusive        | 00:00:00.0013007 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"` |
|  ⚠ Inconclusive        | 00:00:00.0012420 | `Check Expressions "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"` |
|  ✔ Passed               | 00:00:00.0005863 | `Check Expressions "(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)"` |
|  ⚠ Inconclusive        | 00:00:00.0017307 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"` |
|  ⚠ Inconclusive        | 00:00:00.0011942 | `Check Expressions "((A*B)+C)+(-1*A)"              ` |
|  ⚠ Inconclusive        | 00:00:00.0011567 | `Check Expressions "(((A+(-1*B))+((C*D)+E))*F)+G+(D` |
|  ⚠ Inconclusive        | 00:00:00.0012351 | `Check Expressions "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"` |
|  ⚠ Inconclusive        | 00:00:00.0011669 | `Check Expressions "((A*(B+(-1*C)))+D)+((E*(B+(-1*C` |
|  ⚠ Inconclusive        | 00:00:00.0014165 | `Check Expressions "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"` |
|  ⚠ Inconclusive        | 00:00:00.0013846 | `Check Expressions "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"` |
|  ⚠ Inconclusive        | 00:00:00.0014823 | `Check Expressions "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"` |
|  ⚠ Inconclusive        | 00:00:00.0009024 | `Check Expressions "(((A+(-1*B))*C)+D)+(B+(-1*A))" ` |
|  ⚠ Inconclusive        | 00:00:00.0011177 | `Check Expressions "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"` |
|  ✔ Passed               | 00:00:00.0003869 | `Check Expressions "((A+((B*C)+D))*E)+F+((C/G)*H)+I` |
|  ✔ Passed               | 00:00:00.0001777 | `Check Expressions "(A+B)*C+D+(A+B)*E+F"           ` |
|  ✔ Passed               | 00:00:00.0000656 | `Check Expressions "A*B"                           ` |
|  ⚠ Inconclusive        | 00:00:00.0010617 | `Check Expressions "((A+((-1*B)*(C/D)))*(E/C))+(-1*` |
|  ✔ Passed               | 00:00:00.0002733 | `Check Expressions "((A/(1-B))*C)+D"               ` |
|  ✔ Passed               | 00:00:00.0004643 | `Check Expressions "(((A-(B*C))/(1-D))*E)+F"       ` |
|  ⚠ Inconclusive        | 00:00:00.0013249 | `Check Expressions "(A*(1+(-1*B))+C)*D+E"          ` |
|  ✔ Passed               | 00:00:00.0003146 | `Check Expressions "(A+B)*C+D"                     ` |
|  ✔ Passed               | 00:00:00.0002660 | `Check Expressions "(((A/B)*C*D)*E*F)+G"           ` |
|  ✔ Passed               | 00:00:00.0001497 | `Check Expressions "((A-B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0001954 | `Check Expressions "((A/B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0002790 | `Check Expressions "((((A*B)+C)/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.0001445 | `Check Expressions "((A/B)*C*D*E)+F"               ` |
|  ✔ Passed               | 00:00:00.0000848 | `Check Expressions "(A*B*C)+D"                     ` |
|  ✔ Passed               | 00:00:00.0001094 | `Check Expressions "(((A*B)+C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.0001504 | `Check Expressions "(((A/B)*C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.0000588 | `Check Expressions "(A*1)"                         ` |
|  ⚠ Inconclusive        | 00:00:00.0008700 | `Check Expressions "(((A/B)+(-1*C))*D*E*F)+G"      ` |
|  ✔ Passed               | 00:00:00.0001826 | `Check Expressions "((A*B)+C)+(D*E*F)"             ` |
|  ⚠ Inconclusive        | 00:00:00.0006181 | `Check Expressions "((A/(1+(-1*(B+C))))*D)+E"      ` |
|  ✔ Passed               | 00:00:00.0001353 | `Check Expressions "((A-(B*C))*D)+E"               ` |
|  ⚠ Inconclusive        | 00:00:00.0006325 | `Check Expressions "(((A+(-1*B))/C)*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.0001978 | `Check Expressions "((A/B)*((C*D)*E)*F)+G"         ` |
|  ✔ Passed               | 00:00:00.0002278 | `Check Expressions "((((A/B)*C)+D)*((E*F)*G))+H"   ` |
|  ⚠ Inconclusive        | 00:00:00.0008163 | `Check Expressions "(((A/B)+(-1*C))*((D*E)*F)*G)+H"` |
|  ⚠ Inconclusive        | 00:00:00.0019848 | `Check Expressions "(((A+(-1*B))/C)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.0003794 | `Check Expressions "(((A/B)*(((C*D)*E)*F))+(C*D*G))` |
|  ✔ Passed               | 00:00:00.0001702 | `Check Expressions "((A*B)+((A*C)-A)*D)+E"         ` |
|  ⚠ Inconclusive        | 00:00:00.0006251 | `Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.0002483 | `Check Expressions "(((A/B)*((C*D)*E)*F)*G)+H"     ` |
|  ✔ Passed               | 00:00:00.0001866 | `Check Expressions "((A/B)*(((C*D)*E)*F))+G"       ` |
|  ✔ Passed               | 00:00:00.0001528 | `Check Expressions "((A/B)*((C*D)*E))+F"           ` |
|  ✔ Passed               | 00:00:00.0000748 | `Check Expressions "(A/(A+B))"                     ` |
|  ✔ Passed               | 00:00:00.0026654 | `VerifyOptimizerForComplexExpressions (A!)         ` |

