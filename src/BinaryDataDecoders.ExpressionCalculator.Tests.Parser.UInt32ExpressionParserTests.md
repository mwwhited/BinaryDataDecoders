## BinaryDataDecoders.ExpressionCalculator.Tests.Parser.UInt32ExpressionParserTests

### SimpleParserTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.0048228 | `SimpleParserTests                                 ` |
|  ✔ Passed               | 00:00:00.0017559 | `Parse all operators test                          ` |
|  ✔ Passed               | 00:00:00.0001833 | `Simple test with variable                         ` |
|  ✔ Passed               | 00:00:00.0000237 | `Just variable                                     ` |
|  ⚠ Inconclusive        | 00:00:00.0006557 | `Just decimal value                                ` |
|  ✔ Passed               | 00:00:00.0007176 | `Simple factorial                                  ` |
|  ✔ Passed               | 00:00:00.0005229 | `Negative factorial                                ` |
|  ⚠ Inconclusive        | 00:00:00.0006008 | `Parse Complex Expression                          ` |
|  ✔ Passed               | 00:00:00.0000722 | `SimpleParserTests (B*--A,B * --A)                 ` |

### OptimizerTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.0226862 | `OptimizerTests                                    ` |
|  ✔ Passed               | 00:00:00.0037330 | `OptimizerTests ((A),A)                            ` |
|  ✔ Passed               | 00:00:00.0028553 | `OptimizerTests ((A+(B)),A + B)                    ` |
|  ✔ Passed               | 00:00:00.0002345 | `OptimizerTests (B^1,B)                            ` |
|  ✔ Passed               | 00:00:00.0000472 | `OptimizerTests (B*1,B)                            ` |
|  ✔ Passed               | 00:00:00.0000305 | `OptimizerTests (1*B,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.0021702 | `OptimizerTests (B*-1,-B)                          ` |
|  ⚠ Inconclusive        | 00:00:00.0009339 | `OptimizerTests (-1*B,-B)                          ` |
|  ✔ Passed               | 00:00:00.0000782 | `OptimizerTests (B/1,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.0005274 | `OptimizerTests (B/-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.0000493 | `OptimizerTests (B+0,B)                            ` |
|  ✔ Passed               | 00:00:00.0000288 | `OptimizerTests (0+B,B)                            ` |
|  ✔ Passed               | 00:00:00.0000367 | `OptimizerTests (B-0,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.0004943 | `OptimizerTests (0-B,-B)                           ` |
|  ⚠ Inconclusive        | 00:00:00.0017593 | `OptimizerTests (2+3*4^5%6/7-8,-6)                 ` |
|  ✔ Passed               | 00:00:00.0000940 | `OptimizerTests (2+3,5)                            ` |
|  ✔ Passed               | 00:00:00.0004656 | `OptimizerTests (B/B,1)                            ` |
|  ✔ Passed               | 00:00:00.0000425 | `OptimizerTests (B%B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000307 | `OptimizerTests (B^0,1)                            ` |
|  ✔ Passed               | 00:00:00.0000278 | `OptimizerTests (0^B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000288 | `OptimizerTests (0*B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000283 | `OptimizerTests (B*0,0)                            ` |
|  ✔ Passed               | 00:00:00.0000283 | `OptimizerTests (0/B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000280 | `OptimizerTests (0%B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000279 | `OptimizerTests (B%1,0)                            ` |
|  ⚠ Inconclusive        | 00:00:00.0006285 | `OptimizerTests (B%-1,0)                           ` |
|  ⚠ Inconclusive        | 00:00:00.0008554 | `OptimizerTests (-(B),-B)                          ` |
|  ⚠ Inconclusive        | 00:00:00.0007950 | `OptimizerTests (-(3),-3)                          ` |
|  ⚠ Inconclusive        | 00:00:00.0005556 | `OptimizerTests (-3,-3)                            ` |
|  ✔ Passed               | 00:00:00.0003316 | `OptimizerTests (--B,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.0005949 | `OptimizerTests (---B,-B)                          ` |
|  ⚠ Inconclusive        | 00:00:00.0008805 | `OptimizerTests (-1*(A*B),-(A * B))                ` |
|  ✔ Passed               | 00:00:00.0000694 | `OptimizerTests (A!,A!)                            ` |
|  ✔ Passed               | 00:00:00.0000347 | `OptimizerTests ((A)!,A!)                          ` |
|  ✔ Passed               | 00:00:00.0028990 | `OptimizerTests (3!!,720)                          ` |
|  ✔ Passed               | 00:00:00.0000768 | `OptimizerTests (2!!!,2)                           ` |
|  ✔ Passed               | 00:00:00.0000331 | `OptimizerTests (N!!,N!!)                          ` |
|  ✔ Passed               | 00:00:00.0000351 | `OptimizerTests (N!!!,N!!!)                        ` |

### OptimizerTests_WithExceptions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0017883 | `OptimizerTests_WithExceptions                     ` |
|  ✔ Passed               | 00:00:00.0011545 | `OptimizerTests_WithExceptions (B/0)               ` |
|  ✔ Passed               | 00:00:00.0004732 | `OptimizerTests_WithExceptions (B%0)               ` |

### PoorlyFormedExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0129644 | `PoorlyFormedExpressions                           ` |
|  ✔ Passed               | 00:00:00.0061422 | `PoorlyFormedExpressions (-A!)                     ` |
|  ✔ Passed               | 00:00:00.0011063 | `PoorlyFormedExpressions (B/*1)                    ` |
|  ✔ Passed               | 00:00:00.0007512 | `PoorlyFormedExpressions (B**)                     ` |
|  ✔ Passed               | 00:00:00.0005897 | `PoorlyFormedExpressions (B**A)                    ` |
|  ✔ Passed               | 00:00:00.0005239 | `PoorlyFormedExpressions (B***A)                   ` |
|  ✔ Passed               | 00:00:00.0006176 | `PoorlyFormedExpressions (B*+*A)                   ` |
|  ✔ Passed               | 00:00:00.0009849 | `PoorlyFormedExpressions (B*-*A)                   ` |
|  ✔ Passed               | 00:00:00.0006847 | `PoorlyFormedExpressions ()                        ` |
|  ✔ Passed               | 00:00:00.0004862 | `PoorlyFormedExpressions (b)                       ` |
|  ✔ Passed               | 00:00:00.0004521 | `PoorlyFormedExpressions (b+1)                     ` |

### VerifyOptimizerForComplexExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.0396721 | `VerifyOptimizerForComplexExpressions              ` |
|  ✔ Passed               | 00:00:00.0088523 | `Check Expressions "A"                             ` |
|  ✔ Passed               | 00:00:00.0001703 | `Check Expressions "A*1"                           ` |
|  ✔ Passed               | 00:00:00.0001070 | `Check Expressions "(A*B)+C"                       ` |
|  ✔ Passed               | 00:00:00.0000674 | `Check Expressions "(A*B)"                         ` |
|  ✔ Passed               | 00:00:00.0000889 | `Check Expressions "(A-B)/A"                       ` |
|  ⚠ Inconclusive        | 00:00:00.0010561 | `Check Expressions "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"` |
|  ✔ Passed               | 00:00:00.0003664 | `Check Expressions "((A+B+((C*D)+E))*F)+G+((D/H)*I)` |
|  ✔ Passed               | 00:00:00.0000981 | `Check Expressions "A*(B/C)+D"                     ` |
|  ✔ Passed               | 00:00:00.0000910 | `Check Expressions "A*B+C"                         ` |
|  ✔ Passed               | 00:00:00.0001718 | `Check Expressions "(((A-(B*C))/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.0001322 | `Check Expressions "(A/B)-(C+D+E+F)"               ` |
|  ✔ Passed               | 00:00:00.0001622 | `Check Expressions "((A*B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0001441 | `Check Expressions "(((A*B)*C)*D)+E"               ` |
|  ⚠ Inconclusive        | 00:00:00.0010233 | `Check Expressions "(((A/B)+(-1*C))*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.0002392 | `Check Expressions "(A*B*(C/D))+E"                 ` |
|  ✔ Passed               | 00:00:00.0001347 | `Check Expressions "(A*(B/C)+D)"                   ` |
|  ✔ Passed               | 00:00:00.0000688 | `Check Expressions "A+B"                           ` |
|  ✔ Passed               | 00:00:00.0001901 | `Check Expressions "((A/B)*(C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.0002443 | `Check Expressions "((A+((B*C)+D))*E)+F+(C*G)+H"   ` |
|  ✔ Passed               | 00:00:00.0002327 | `Check Expressions "(A+((B*C)+D))*E+F+(A+((B*C)+D))` |
|  ⚠ Inconclusive        | 00:00:00.0034356 | `Check Expressions "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"` |
|  ✔ Passed               | 00:00:00.0002805 | `Check Expressions "((A*B)+C)+((D*B)+E)"           ` |
|  ⚠ Inconclusive        | 00:00:00.0011144 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"` |
|  ⚠ Inconclusive        | 00:00:00.0009133 | `Check Expressions "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"` |
|  ✔ Passed               | 00:00:00.0004043 | `Check Expressions "(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)"` |
|  ⚠ Inconclusive        | 00:00:00.0009869 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"` |
|  ⚠ Inconclusive        | 00:00:00.0005525 | `Check Expressions "((A*B)+C)+(-1*A)"              ` |
|  ⚠ Inconclusive        | 00:00:00.0006054 | `Check Expressions "(((A+(-1*B))+((C*D)+E))*F)+G+(D` |
|  ⚠ Inconclusive        | 00:00:00.0006363 | `Check Expressions "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"` |
|  ⚠ Inconclusive        | 00:00:00.0006036 | `Check Expressions "((A*(B+(-1*C)))+D)+((E*(B+(-1*C` |
|  ⚠ Inconclusive        | 00:00:00.0007382 | `Check Expressions "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"` |
|  ⚠ Inconclusive        | 00:00:00.0006939 | `Check Expressions "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"` |
|  ⚠ Inconclusive        | 00:00:00.0009582 | `Check Expressions "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"` |
|  ⚠ Inconclusive        | 00:00:00.0006999 | `Check Expressions "(((A+(-1*B))*C)+D)+(B+(-1*A))" ` |
|  ⚠ Inconclusive        | 00:00:00.0006245 | `Check Expressions "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"` |
|  ✔ Passed               | 00:00:00.0002522 | `Check Expressions "((A+((B*C)+D))*E)+F+((C/G)*H)+I` |
|  ✔ Passed               | 00:00:00.0001163 | `Check Expressions "(A+B)*C+D+(A+B)*E+F"           ` |
|  ✔ Passed               | 00:00:00.0000492 | `Check Expressions "A*B"                           ` |
|  ⚠ Inconclusive        | 00:00:00.0007875 | `Check Expressions "((A+((-1*B)*(C/D)))*(E/C))+(-1*` |
|  ✔ Passed               | 00:00:00.0001869 | `Check Expressions "((A/(1-B))*C)+D"               ` |
|  ✔ Passed               | 00:00:00.0001537 | `Check Expressions "(((A-(B*C))/(1-D))*E)+F"       ` |
|  ⚠ Inconclusive        | 00:00:00.0008456 | `Check Expressions "(A*(1+(-1*B))+C)*D+E"          ` |
|  ✔ Passed               | 00:00:00.0001433 | `Check Expressions "(A+B)*C+D"                     ` |
|  ✔ Passed               | 00:00:00.0002044 | `Check Expressions "(((A/B)*C*D)*E*F)+G"           ` |
|  ✔ Passed               | 00:00:00.0001182 | `Check Expressions "((A-B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0001186 | `Check Expressions "((A/B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0001885 | `Check Expressions "((((A*B)+C)/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.0001564 | `Check Expressions "((A/B)*C*D*E)+F"               ` |
|  ✔ Passed               | 00:00:00.0000997 | `Check Expressions "(A*B*C)+D"                     ` |
|  ✔ Passed               | 00:00:00.0001256 | `Check Expressions "(((A*B)+C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.0001338 | `Check Expressions "(((A/B)*C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.0000514 | `Check Expressions "(A*1)"                         ` |
|  ⚠ Inconclusive        | 00:00:00.0011657 | `Check Expressions "(((A/B)+(-1*C))*D*E*F)+G"      ` |
|  ✔ Passed               | 00:00:00.0002060 | `Check Expressions "((A*B)+C)+(D*E*F)"             ` |
|  ⚠ Inconclusive        | 00:00:00.0008438 | `Check Expressions "((A/(1+(-1*(B+C))))*D)+E"      ` |
|  ✔ Passed               | 00:00:00.0001788 | `Check Expressions "((A-(B*C))*D)+E"               ` |
|  ⚠ Inconclusive        | 00:00:00.0007816 | `Check Expressions "(((A+(-1*B))/C)*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.0002091 | `Check Expressions "((A/B)*((C*D)*E)*F)+G"         ` |
|  ✔ Passed               | 00:00:00.0001943 | `Check Expressions "((((A/B)*C)+D)*((E*F)*G))+H"   ` |
|  ⚠ Inconclusive        | 00:00:00.0007126 | `Check Expressions "(((A/B)+(-1*C))*((D*E)*F)*G)+H"` |
|  ⚠ Inconclusive        | 00:00:00.0006261 | `Check Expressions "(((A+(-1*B))/C)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.0008887 | `Check Expressions "(((A/B)*(((C*D)*E)*F))+(C*D*G))` |
|  ✔ Passed               | 00:00:00.0001598 | `Check Expressions "((A*B)+((A*C)-A)*D)+E"         ` |
|  ⚠ Inconclusive        | 00:00:00.0006328 | `Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.0002446 | `Check Expressions "(((A/B)*((C*D)*E)*F)*G)+H"     ` |
|  ✔ Passed               | 00:00:00.0001549 | `Check Expressions "((A/B)*(((C*D)*E)*F))+G"       ` |
|  ✔ Passed               | 00:00:00.0001320 | `Check Expressions "((A/B)*((C*D)*E))+F"           ` |
|  ✔ Passed               | 00:00:00.0000682 | `Check Expressions "(A/(A+B))"                     ` |
|  ✔ Passed               | 00:00:00.0000446 | `VerifyOptimizerForComplexExpressions (A!)         ` |

### GetDistinctVariablesTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0047527 | `GetDistinctVariablesTests                         ` |
|  ✔ Passed               | 00:00:00.0044209 | `GetDistinctVariablesTests (A+B+C,A, B, C)         ` |
|  ✔ Passed               | 00:00:00.0001125 | `GetDistinctVariablesTests (A+B+B,A, B)            ` |
|  ✔ Passed               | 00:00:00.0000436 | `GetDistinctVariablesTests (Abc+XyW1,Abc, XyW1)    ` |

