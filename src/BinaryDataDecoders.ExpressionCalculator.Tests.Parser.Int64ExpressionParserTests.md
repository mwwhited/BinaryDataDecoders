## BinaryDataDecoders.ExpressionCalculator.Tests.Parser.Int64ExpressionParserTests

### GetDistinctVariablesTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0034885 | `GetDistinctVariablesTests                         ` |
|  ✔ Passed               | 00:00:00.0032212 | `GetDistinctVariablesTests (A+B+C,A, B, C)         ` |
|  ✔ Passed               | 00:00:00.0000899 | `GetDistinctVariablesTests (A+B+B,A, B)            ` |
|  ✔ Passed               | 00:00:00.0000356 | `GetDistinctVariablesTests (Abc+XyW1,Abc, XyW1)    ` |

### OptimizerTests_WithExceptions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0016941 | `OptimizerTests_WithExceptions                     ` |
|  ✔ Passed               | 00:00:00.0009326 | `OptimizerTests_WithExceptions (B/0)               ` |
|  ✔ Passed               | 00:00:00.0005882 | `OptimizerTests_WithExceptions (B%0)               ` |

### OptimizerTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0143560 | `OptimizerTests                                    ` |
|  ✔ Passed               | 00:00:00.0026595 | `OptimizerTests ((A),A)                            ` |
|  ✔ Passed               | 00:00:00.0023324 | `OptimizerTests ((A+(B)),A + B)                    ` |
|  ✔ Passed               | 00:00:00.0002155 | `OptimizerTests (B^1,B)                            ` |
|  ✔ Passed               | 00:00:00.0000463 | `OptimizerTests (B*1,B)                            ` |
|  ✔ Passed               | 00:00:00.0000294 | `OptimizerTests (1*B,B)                            ` |
|  ✔ Passed               | 00:00:00.0013473 | `OptimizerTests (B*-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.0000969 | `OptimizerTests (-1*B,-B)                          ` |
|  ✔ Passed               | 00:00:00.0000323 | `OptimizerTests (B/1,B)                            ` |
|  ✔ Passed               | 00:00:00.0000350 | `OptimizerTests (B/-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.0000280 | `OptimizerTests (B+0,B)                            ` |
|  ✔ Passed               | 00:00:00.0000397 | `OptimizerTests (0+B,B)                            ` |
|  ✔ Passed               | 00:00:00.0000282 | `OptimizerTests (B-0,B)                            ` |
|  ✔ Passed               | 00:00:00.0000295 | `OptimizerTests (0-B,-B)                           ` |
|  ✔ Passed               | 00:00:00.0011884 | `OptimizerTests (2+3*4^5%6/7-8,-6)                 ` |
|  ✔ Passed               | 00:00:00.0001115 | `OptimizerTests (2+3,5)                            ` |
|  ✔ Passed               | 00:00:00.0006373 | `OptimizerTests (B/B,1)                            ` |
|  ✔ Passed               | 00:00:00.0000996 | `OptimizerTests (B%B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000371 | `OptimizerTests (B^0,1)                            ` |
|  ✔ Passed               | 00:00:00.0000311 | `OptimizerTests (0^B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000311 | `OptimizerTests (0*B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000303 | `OptimizerTests (B*0,0)                            ` |
|  ✔ Passed               | 00:00:00.0000301 | `OptimizerTests (0/B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000572 | `OptimizerTests (0%B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000541 | `OptimizerTests (B%1,0)                            ` |
|  ✔ Passed               | 00:00:00.0000631 | `OptimizerTests (B%-1,0)                           ` |
|  ✔ Passed               | 00:00:00.0003403 | `OptimizerTests (-(B),-B)                          ` |
|  ✔ Passed               | 00:00:00.0001703 | `OptimizerTests (-(3),-3)                          ` |
|  ✔ Passed               | 00:00:00.0000362 | `OptimizerTests (-3,-3)                            ` |
|  ✔ Passed               | 00:00:00.0002616 | `OptimizerTests (--B,B)                            ` |
|  ✔ Passed               | 00:00:00.0000567 | `OptimizerTests (---B,-B)                          ` |
|  ✔ Passed               | 00:00:00.0002276 | `OptimizerTests (-1*(A*B),-(A * B))                ` |
|  ✔ Passed               | 00:00:00.0000429 | `OptimizerTests (A!,A!)                            ` |
|  ✔ Passed               | 00:00:00.0000348 | `OptimizerTests ((A)!,A!)                          ` |
|  ✔ Passed               | 00:00:00.0026069 | `OptimizerTests (3!!,720)                          ` |
|  ✔ Passed               | 00:00:00.0000862 | `OptimizerTests (2!!!,2)                           ` |
|  ✔ Passed               | 00:00:00.0000347 | `OptimizerTests (N!!,N!!)                          ` |
|  ✔ Passed               | 00:00:00.0000428 | `OptimizerTests (N!!!,N!!!)                        ` |

### SimpleParserTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.0053275 | `SimpleParserTests                                 ` |
|  ✔ Passed               | 00:00:00.0019018 | `Parse all operators test                          ` |
|  ✔ Passed               | 00:00:00.0002081 | `Simple test with variable                         ` |
|  ✔ Passed               | 00:00:00.0000260 | `Just variable                                     ` |
|  ⚠ Inconclusive        | 00:00:00.0006905 | `Just decimal value                                ` |
|  ✔ Passed               | 00:00:00.0008000 | `Simple factorial                                  ` |
|  ✔ Passed               | 00:00:00.0005755 | `Negative factorial                                ` |
|  ⚠ Inconclusive        | 00:00:00.0007008 | `Parse Complex Expression                          ` |
|  ✔ Passed               | 00:00:00.0000859 | `SimpleParserTests (B*--A,B * --A)                 ` |

### VerifyOptimizerForComplexExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.0241223 | `VerifyOptimizerForComplexExpressions              ` |
|  ✔ Passed               | 00:00:00.0085935 | `Check Expressions "A"                             ` |
|  ✔ Passed               | 00:00:00.0002246 | `Check Expressions "A*1"                           ` |
|  ✔ Passed               | 00:00:00.0001099 | `Check Expressions "(A*B)+C"                       ` |
|  ✔ Passed               | 00:00:00.0000832 | `Check Expressions "(A*B)"                         ` |
|  ✔ Passed               | 00:00:00.0000890 | `Check Expressions "(A-B)/A"                       ` |
|  ✔ Passed               | 00:00:00.0005724 | `Check Expressions "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"` |
|  ✔ Passed               | 00:00:00.0003057 | `Check Expressions "((A+B+((C*D)+E))*F)+G+((D/H)*I)` |
|  ✔ Passed               | 00:00:00.0000902 | `Check Expressions "A*(B/C)+D"                     ` |
|  ✔ Passed               | 00:00:00.0000761 | `Check Expressions "A*B+C"                         ` |
|  ✔ Passed               | 00:00:00.0001375 | `Check Expressions "(((A-(B*C))/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.0001089 | `Check Expressions "(A/B)-(C+D+E+F)"               ` |
|  ✔ Passed               | 00:00:00.0001074 | `Check Expressions "((A*B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0001162 | `Check Expressions "(((A*B)*C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.0001977 | `Check Expressions "(((A/B)+(-1*C))*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.0001054 | `Check Expressions "(A*B*(C/D))+E"                 ` |
|  ✔ Passed               | 00:00:00.0000874 | `Check Expressions "(A*(B/C)+D)"                   ` |
|  ✔ Passed               | 00:00:00.0000457 | `Check Expressions "A+B"                           ` |
|  ✔ Passed               | 00:00:00.0001372 | `Check Expressions "((A/B)*(C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.0001644 | `Check Expressions "((A+((B*C)+D))*E)+F+(C*G)+H"   ` |
|  ✔ Passed               | 00:00:00.0001697 | `Check Expressions "(A+((B*C)+D))*E+F+(A+((B*C)+D))` |
|  ✔ Passed               | 00:00:00.0003089 | `Check Expressions "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"` |
|  ✔ Passed               | 00:00:00.0001330 | `Check Expressions "((A*B)+C)+((D*B)+E)"           ` |
|  ✔ Passed               | 00:00:00.0003990 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"` |
|  ✔ Passed               | 00:00:00.0003037 | `Check Expressions "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"` |
|  ✔ Passed               | 00:00:00.0003087 | `Check Expressions "(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)"` |
|  ✔ Passed               | 00:00:00.0006017 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"` |
|  ✔ Passed               | 00:00:00.0001168 | `Check Expressions "((A*B)+C)+(-1*A)"              ` |
|  ✔ Passed               | 00:00:00.0002098 | `Check Expressions "(((A+(-1*B))+((C*D)+E))*F)+G+(D` |
|  ✔ Passed               | 00:00:00.0002825 | `Check Expressions "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"` |
|  ✔ Passed               | 00:00:00.0002224 | `Check Expressions "((A*(B+(-1*C)))+D)+((E*(B+(-1*C` |
|  ✔ Passed               | 00:00:00.0004330 | `Check Expressions "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"` |
|  ✔ Passed               | 00:00:00.0004589 | `Check Expressions "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"` |
|  ✔ Passed               | 00:00:00.0009498 | `Check Expressions "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"` |
|  ✔ Passed               | 00:00:00.0002388 | `Check Expressions "(((A+(-1*B))*C)+D)+(B+(-1*A))" ` |
|  ✔ Passed               | 00:00:00.0002568 | `Check Expressions "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"` |
|  ✔ Passed               | 00:00:00.0002080 | `Check Expressions "((A+((B*C)+D))*E)+F+((C/G)*H)+I` |
|  ✔ Passed               | 00:00:00.0001118 | `Check Expressions "(A+B)*C+D+(A+B)*E+F"           ` |
|  ✔ Passed               | 00:00:00.0000454 | `Check Expressions "A*B"                           ` |
|  ✔ Passed               | 00:00:00.0002620 | `Check Expressions "((A+((-1*B)*(C/D)))*(E/C))+(-1*` |
|  ✔ Passed               | 00:00:00.0001437 | `Check Expressions "((A/(1-B))*C)+D"               ` |
|  ✔ Passed               | 00:00:00.0001847 | `Check Expressions "(((A-(B*C))/(1-D))*E)+F"       ` |
|  ✔ Passed               | 00:00:00.0001643 | `Check Expressions "(A*(1+(-1*B))+C)*D+E"          ` |
|  ✔ Passed               | 00:00:00.0000742 | `Check Expressions "(A+B)*C+D"                     ` |
|  ✔ Passed               | 00:00:00.0001449 | `Check Expressions "(((A/B)*C*D)*E*F)+G"           ` |
|  ✔ Passed               | 00:00:00.0000921 | `Check Expressions "((A-B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0000877 | `Check Expressions "((A/B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0001245 | `Check Expressions "((((A*B)+C)/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.0001121 | `Check Expressions "((A/B)*C*D*E)+F"               ` |
|  ✔ Passed               | 00:00:00.0000760 | `Check Expressions "(A*B*C)+D"                     ` |
|  ✔ Passed               | 00:00:00.0001177 | `Check Expressions "(((A*B)+C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.0001284 | `Check Expressions "(((A/B)*C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.0000506 | `Check Expressions "(A*1)"                         ` |
|  ✔ Passed               | 00:00:00.0001526 | `Check Expressions "(((A/B)+(-1*C))*D*E*F)+G"      ` |
|  ✔ Passed               | 00:00:00.0001217 | `Check Expressions "((A*B)+C)+(D*E*F)"             ` |
|  ✔ Passed               | 00:00:00.0001615 | `Check Expressions "((A/(1+(-1*(B+C))))*D)+E"      ` |
|  ✔ Passed               | 00:00:00.0001006 | `Check Expressions "((A-(B*C))*D)+E"               ` |
|  ✔ Passed               | 00:00:00.0001806 | `Check Expressions "(((A+(-1*B))/C)*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.0001504 | `Check Expressions "((A/B)*((C*D)*E)*F)+G"         ` |
|  ✔ Passed               | 00:00:00.0002070 | `Check Expressions "((((A/B)*C)+D)*((E*F)*G))+H"   ` |
|  ✔ Passed               | 00:00:00.0002200 | `Check Expressions "(((A/B)+(-1*C))*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.0002246 | `Check Expressions "(((A+(-1*B))/C)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.0003577 | `Check Expressions "(((A/B)*(((C*D)*E)*F))+(C*D*G))` |
|  ✔ Passed               | 00:00:00.0001881 | `Check Expressions "((A*B)+((A*C)-A)*D)+E"         ` |
|  ⚠ Inconclusive        | 00:00:00.0008201 | `Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.0003334 | `Check Expressions "(((A/B)*((C*D)*E)*F)*G)+H"     ` |
|  ✔ Passed               | 00:00:00.0002112 | `Check Expressions "((A/B)*(((C*D)*E)*F))+G"       ` |
|  ✔ Passed               | 00:00:00.0001504 | `Check Expressions "((A/B)*((C*D)*E))+F"           ` |
|  ✔ Passed               | 00:00:00.0000770 | `Check Expressions "(A/(A+B))"                     ` |
|  ✔ Passed               | 00:00:00.0000503 | `VerifyOptimizerForComplexExpressions (A!)         ` |

### PoorlyFormedExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0100684 | `PoorlyFormedExpressions                           ` |
|  ✔ Passed               | 00:00:00.0042875 | `PoorlyFormedExpressions (-A!)                     ` |
|  ✔ Passed               | 00:00:00.0007699 | `PoorlyFormedExpressions (B/*1)                    ` |
|  ✔ Passed               | 00:00:00.0004992 | `PoorlyFormedExpressions (B**)                     ` |
|  ✔ Passed               | 00:00:00.0004439 | `PoorlyFormedExpressions (B**A)                    ` |
|  ✔ Passed               | 00:00:00.0004465 | `PoorlyFormedExpressions (B***A)                   ` |
|  ✔ Passed               | 00:00:00.0004805 | `PoorlyFormedExpressions (B*+*A)                   ` |
|  ✔ Passed               | 00:00:00.0005120 | `PoorlyFormedExpressions (B*-*A)                   ` |
|  ✔ Passed               | 00:00:00.0006183 | `PoorlyFormedExpressions ()                        ` |
|  ✔ Passed               | 00:00:00.0008123 | `PoorlyFormedExpressions (b)                       ` |
|  ✔ Passed               | 00:00:00.0006204 | `PoorlyFormedExpressions (b+1)                     ` |

