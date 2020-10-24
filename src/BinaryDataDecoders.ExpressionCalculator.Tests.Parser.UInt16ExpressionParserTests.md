## BinaryDataDecoders.ExpressionCalculator.Tests.Parser.UInt16ExpressionParserTests

### VerifyOptimizerForComplexExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.0457455 | `VerifyOptimizerForComplexExpressions              ` |
|  ✔ Passed               | 00:00:00.0142996 | `Check Expressions "A"                             ` |
|  ✔ Passed               | 00:00:00.0001768 | `Check Expressions "A*1"                           ` |
|  ✔ Passed               | 00:00:00.0000818 | `Check Expressions "(A*B)+C"                       ` |
|  ✔ Passed               | 00:00:00.0000527 | `Check Expressions "(A*B)"                         ` |
|  ✔ Passed               | 00:00:00.0000744 | `Check Expressions "(A-B)/A"                       ` |
|  ⚠ Inconclusive        | 00:00:00.0009471 | `Check Expressions "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"` |
|  ✔ Passed               | 00:00:00.0011496 | `Check Expressions "((A+B+((C*D)+E))*F)+G+((D/H)*I)` |
|  ✔ Passed               | 00:00:00.0001344 | `Check Expressions "A*(B/C)+D"                     ` |
|  ✔ Passed               | 00:00:00.0000772 | `Check Expressions "A*B+C"                         ` |
|  ✔ Passed               | 00:00:00.0001274 | `Check Expressions "(((A-(B*C))/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.0000953 | `Check Expressions "(A/B)-(C+D+E+F)"               ` |
|  ✔ Passed               | 00:00:00.0000887 | `Check Expressions "((A*B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0001048 | `Check Expressions "(((A*B)*C)*D)+E"               ` |
|  ⚠ Inconclusive        | 00:00:00.0007524 | `Check Expressions "(((A/B)+(-1*C))*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.0001406 | `Check Expressions "(A*B*(C/D))+E"                 ` |
|  ✔ Passed               | 00:00:00.0000768 | `Check Expressions "(A*(B/C)+D)"                   ` |
|  ✔ Passed               | 00:00:00.0000533 | `Check Expressions "A+B"                           ` |
|  ✔ Passed               | 00:00:00.0001140 | `Check Expressions "((A/B)*(C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.0001548 | `Check Expressions "((A+((B*C)+D))*E)+F+(C*G)+H"   ` |
|  ✔ Passed               | 00:00:00.0001809 | `Check Expressions "(A+((B*C)+D))*E+F+(A+((B*C)+D))` |
|  ⚠ Inconclusive        | 00:00:00.0007912 | `Check Expressions "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"` |
|  ✔ Passed               | 00:00:00.0001879 | `Check Expressions "((A*B)+C)+((D*B)+E)"           ` |
|  ⚠ Inconclusive        | 00:00:00.0008378 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"` |
|  ⚠ Inconclusive        | 00:00:00.0007966 | `Check Expressions "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"` |
|  ✔ Passed               | 00:00:00.0005143 | `Check Expressions "(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)"` |
|  ⚠ Inconclusive        | 00:00:00.0016749 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"` |
|  ⚠ Inconclusive        | 00:00:00.0010309 | `Check Expressions "((A*B)+C)+(-1*A)"              ` |
|  ⚠ Inconclusive        | 00:00:00.0012706 | `Check Expressions "(((A+(-1*B))+((C*D)+E))*F)+G+(D` |
|  ⚠ Inconclusive        | 00:00:00.0009455 | `Check Expressions "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"` |
|  ⚠ Inconclusive        | 00:00:00.0010035 | `Check Expressions "((A*(B+(-1*C)))+D)+((E*(B+(-1*C` |
|  ⚠ Inconclusive        | 00:00:00.0011412 | `Check Expressions "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"` |
|  ⚠ Inconclusive        | 00:00:00.0009780 | `Check Expressions "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"` |
|  ⚠ Inconclusive        | 00:00:00.0013160 | `Check Expressions "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"` |
|  ⚠ Inconclusive        | 00:00:00.0007869 | `Check Expressions "(((A+(-1*B))*C)+D)+(B+(-1*A))" ` |
|  ⚠ Inconclusive        | 00:00:00.0008872 | `Check Expressions "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"` |
|  ✔ Passed               | 00:00:00.0002994 | `Check Expressions "((A+((B*C)+D))*E)+F+((C/G)*H)+I` |
|  ✔ Passed               | 00:00:00.0001372 | `Check Expressions "(A+B)*C+D+(A+B)*E+F"           ` |
|  ✔ Passed               | 00:00:00.0000470 | `Check Expressions "A*B"                           ` |
|  ⚠ Inconclusive        | 00:00:00.0007782 | `Check Expressions "((A+((-1*B)*(C/D)))*(E/C))+(-1*` |
|  ✔ Passed               | 00:00:00.0001528 | `Check Expressions "((A/(1-B))*C)+D"               ` |
|  ✔ Passed               | 00:00:00.0001633 | `Check Expressions "(((A-(B*C))/(1-D))*E)+F"       ` |
|  ⚠ Inconclusive        | 00:00:00.0006853 | `Check Expressions "(A*(1+(-1*B))+C)*D+E"          ` |
|  ✔ Passed               | 00:00:00.0001146 | `Check Expressions "(A+B)*C+D"                     ` |
|  ✔ Passed               | 00:00:00.0001589 | `Check Expressions "(((A/B)*C*D)*E*F)+G"           ` |
|  ✔ Passed               | 00:00:00.0000831 | `Check Expressions "((A-B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0000897 | `Check Expressions "((A/B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0001388 | `Check Expressions "((((A*B)+C)/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.0001193 | `Check Expressions "((A/B)*C*D*E)+F"               ` |
|  ✔ Passed               | 00:00:00.0001596 | `Check Expressions "(A*B*C)+D"                     ` |
|  ✔ Passed               | 00:00:00.0001163 | `Check Expressions "(((A*B)+C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.0001694 | `Check Expressions "(((A/B)*C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.0000581 | `Check Expressions "(A*1)"                         ` |
|  ⚠ Inconclusive        | 00:00:00.0011334 | `Check Expressions "(((A/B)+(-1*C))*D*E*F)+G"      ` |
|  ✔ Passed               | 00:00:00.0003008 | `Check Expressions "((A*B)+C)+(D*E*F)"             ` |
|  ⚠ Inconclusive        | 00:00:00.0008779 | `Check Expressions "((A/(1+(-1*(B+C))))*D)+E"      ` |
|  ✔ Passed               | 00:00:00.0001829 | `Check Expressions "((A-(B*C))*D)+E"               ` |
|  ⚠ Inconclusive        | 00:00:00.0007944 | `Check Expressions "(((A+(-1*B))/C)*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.0002116 | `Check Expressions "((A/B)*((C*D)*E)*F)+G"         ` |
|  ✔ Passed               | 00:00:00.0002800 | `Check Expressions "((((A/B)*C)+D)*((E*F)*G))+H"   ` |
|  ⚠ Inconclusive        | 00:00:00.0010937 | `Check Expressions "(((A/B)+(-1*C))*((D*E)*F)*G)+H"` |
|  ⚠ Inconclusive        | 00:00:00.0008324 | `Check Expressions "(((A+(-1*B))/C)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.0003321 | `Check Expressions "(((A/B)*(((C*D)*E)*F))+(C*D*G))` |
|  ✔ Passed               | 00:00:00.0001792 | `Check Expressions "((A*B)+((A*C)-A)*D)+E"         ` |
|  ⚠ Inconclusive        | 00:00:00.0004354 | `Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.0002363 | `Check Expressions "(((A/B)*((C*D)*E)*F)*G)+H"     ` |
|  ✔ Passed               | 00:00:00.0002069 | `Check Expressions "((A/B)*(((C*D)*E)*F))+G"       ` |
|  ✔ Passed               | 00:00:00.0001631 | `Check Expressions "((A/B)*((C*D)*E))+F"           ` |
|  ✔ Passed               | 00:00:00.0000823 | `Check Expressions "(A/(A+B))"                     ` |
|  ✔ Passed               | 00:00:00.0000632 | `VerifyOptimizerForComplexExpressions (A!)         ` |

### OptimizerTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.0281843 | `OptimizerTests                                    ` |
|  ✔ Passed               | 00:00:00.0044714 | `OptimizerTests ((A),A)                            ` |
|  ✔ Passed               | 00:00:00.0031717 | `OptimizerTests ((A+(B)),A + B)                    ` |
|  ✔ Passed               | 00:00:00.0002110 | `OptimizerTests (B^1,B)                            ` |
|  ✔ Passed               | 00:00:00.0000706 | `OptimizerTests (B*1,B)                            ` |
|  ✔ Passed               | 00:00:00.0000463 | `OptimizerTests (1*B,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.0027363 | `OptimizerTests (B*-1,-B)                          ` |
|  ⚠ Inconclusive        | 00:00:00.0008873 | `OptimizerTests (-1*B,-B)                          ` |
|  ✔ Passed               | 00:00:00.0000891 | `OptimizerTests (B/1,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.0008550 | `OptimizerTests (B/-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.0000676 | `OptimizerTests (B+0,B)                            ` |
|  ✔ Passed               | 00:00:00.0000393 | `OptimizerTests (0+B,B)                            ` |
|  ✔ Passed               | 00:00:00.0000378 | `OptimizerTests (B-0,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.0006581 | `OptimizerTests (0-B,-B)                           ` |
|  ⚠ Inconclusive        | 00:00:00.0030526 | `OptimizerTests (2+3*4^5%6/7-8,-6)                 ` |
|  ✔ Passed               | 00:00:00.0002019 | `OptimizerTests (2+3,5)                            ` |
|  ✔ Passed               | 00:00:00.0009908 | `OptimizerTests (B/B,1)                            ` |
|  ✔ Passed               | 00:00:00.0001568 | `OptimizerTests (B%B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000721 | `OptimizerTests (B^0,1)                            ` |
|  ✔ Passed               | 00:00:00.0000583 | `OptimizerTests (0^B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000470 | `OptimizerTests (0*B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000448 | `OptimizerTests (B*0,0)                            ` |
|  ✔ Passed               | 00:00:00.0000394 | `OptimizerTests (0/B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000369 | `OptimizerTests (0%B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000370 | `OptimizerTests (B%1,0)                            ` |
|  ⚠ Inconclusive        | 00:00:00.0008880 | `OptimizerTests (B%-1,0)                           ` |
|  ⚠ Inconclusive        | 00:00:00.0009685 | `OptimizerTests (-(B),-B)                          ` |
|  ⚠ Inconclusive        | 00:00:00.0007074 | `OptimizerTests (-(3),-3)                          ` |
|  ⚠ Inconclusive        | 00:00:00.0005253 | `OptimizerTests (-3,-3)                            ` |
|  ✔ Passed               | 00:00:00.0003271 | `OptimizerTests (--B,B)                            ` |
|  ⚠ Inconclusive        | 00:00:00.0006905 | `OptimizerTests (---B,-B)                          ` |
|  ⚠ Inconclusive        | 00:00:00.0008539 | `OptimizerTests (-1*(A*B),-(A * B))                ` |
|  ✔ Passed               | 00:00:00.0000835 | `OptimizerTests (A!,A!)                            ` |
|  ✔ Passed               | 00:00:00.0000495 | `OptimizerTests ((A)!,A!)                          ` |
|  ✔ Passed               | 00:00:00.0024629 | `OptimizerTests (3!!,720)                          ` |
|  ✔ Passed               | 00:00:00.0000777 | `OptimizerTests (2!!!,2)                           ` |
|  ✔ Passed               | 00:00:00.0000305 | `OptimizerTests (N!!,N!!)                          ` |
|  ✔ Passed               | 00:00:00.0000316 | `OptimizerTests (N!!!,N!!!)                        ` |

### GetDistinctVariablesTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0035102 | `GetDistinctVariablesTests                         ` |
|  ✔ Passed               | 00:00:00.0032633 | `GetDistinctVariablesTests (A+B+C,A, B, C)         ` |
|  ✔ Passed               | 00:00:00.0000823 | `GetDistinctVariablesTests (A+B+B,A, B)            ` |
|  ✔ Passed               | 00:00:00.0000309 | `GetDistinctVariablesTests (Abc+XyW1,Abc, XyW1)    ` |

### SimpleParserTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.0053694 | `SimpleParserTests                                 ` |
|  ✔ Passed               | 00:00:00.0020184 | `Parse all operators test                          ` |
|  ✔ Passed               | 00:00:00.0002205 | `Simple test with variable                         ` |
|  ✔ Passed               | 00:00:00.0000294 | `Just variable                                     ` |
|  ⚠ Inconclusive        | 00:00:00.0007094 | `Just decimal value                                ` |
|  ✔ Passed               | 00:00:00.0008468 | `Simple factorial                                  ` |
|  ✔ Passed               | 00:00:00.0005026 | `Negative factorial                                ` |
|  ⚠ Inconclusive        | 00:00:00.0006393 | `Parse Complex Expression                          ` |
|  ✔ Passed               | 00:00:00.0000768 | `SimpleParserTests (B*--A,B * --A)                 ` |

### PoorlyFormedExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0129247 | `PoorlyFormedExpressions                           ` |
|  ✔ Passed               | 00:00:00.0062656 | `PoorlyFormedExpressions (-A!)                     ` |
|  ✔ Passed               | 00:00:00.0010561 | `PoorlyFormedExpressions (B/*1)                    ` |
|  ✔ Passed               | 00:00:00.0006131 | `PoorlyFormedExpressions (B**)                     ` |
|  ✔ Passed               | 00:00:00.0005162 | `PoorlyFormedExpressions (B**A)                    ` |
|  ✔ Passed               | 00:00:00.0006302 | `PoorlyFormedExpressions (B***A)                   ` |
|  ✔ Passed               | 00:00:00.0006406 | `PoorlyFormedExpressions (B*+*A)                   ` |
|  ✔ Passed               | 00:00:00.0007463 | `PoorlyFormedExpressions (B*-*A)                   ` |
|  ✔ Passed               | 00:00:00.0006095 | `PoorlyFormedExpressions ()                        ` |
|  ✔ Passed               | 00:00:00.0006295 | `PoorlyFormedExpressions (b)                       ` |
|  ✔ Passed               | 00:00:00.0006393 | `PoorlyFormedExpressions (b+1)                     ` |

### OptimizerTests_WithExceptions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0013945 | `OptimizerTests_WithExceptions                     ` |
|  ✔ Passed               | 00:00:00.0008675 | `OptimizerTests_WithExceptions (B/0)               ` |
|  ✔ Passed               | 00:00:00.0003929 | `OptimizerTests_WithExceptions (B%0)               ` |

