## BinaryDataDecoders.ExpressionCalculator.Tests.Parser.DecimalExpressionParserTests

### OptimizerTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0153540 | `OptimizerTests                                    ` |
|  ✔ Passed               | 00:00:00.0034740 | `OptimizerTests ((A),A)                            ` |
|  ✔ Passed               | 00:00:00.0023350 | `OptimizerTests ((A+(B)),A + B)                    ` |
|  ✔ Passed               | 00:00:00.0002082 | `OptimizerTests (B^1,B)                            ` |
|  ✔ Passed               | 00:00:00.0000451 | `OptimizerTests (B*1,B)                            ` |
|  ✔ Passed               | 00:00:00.0000296 | `OptimizerTests (1*B,B)                            ` |
|  ✔ Passed               | 00:00:00.0018316 | `OptimizerTests (B*-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.0000870 | `OptimizerTests (-1*B,-B)                          ` |
|  ✔ Passed               | 00:00:00.0000317 | `OptimizerTests (B/1,B)                            ` |
|  ✔ Passed               | 00:00:00.0000454 | `OptimizerTests (B/-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.0000382 | `OptimizerTests (B+0,B)                            ` |
|  ✔ Passed               | 00:00:00.0000284 | `OptimizerTests (0+B,B)                            ` |
|  ✔ Passed               | 00:00:00.0000265 | `OptimizerTests (B-0,B)                            ` |
|  ✔ Passed               | 00:00:00.0000289 | `OptimizerTests (0-B,-B)                           ` |
|  ✔ Passed               | 00:00:00.0013902 | `OptimizerTests (2+3*4^5%6/7-8,-6)                 ` |
|  ✔ Passed               | 00:00:00.0000643 | `OptimizerTests (2+3,5)                            ` |
|  ✔ Passed               | 00:00:00.0004943 | `OptimizerTests (B/B,1)                            ` |
|  ✔ Passed               | 00:00:00.0000576 | `OptimizerTests (B%B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000391 | `OptimizerTests (B^0,1)                            ` |
|  ✔ Passed               | 00:00:00.0000289 | `OptimizerTests (0^B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000280 | `OptimizerTests (0*B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000278 | `OptimizerTests (B*0,0)                            ` |
|  ✔ Passed               | 00:00:00.0000278 | `OptimizerTests (0/B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000271 | `OptimizerTests (0%B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000283 | `OptimizerTests (B%1,0)                            ` |
|  ✔ Passed               | 00:00:00.0000402 | `OptimizerTests (B%-1,0)                           ` |
|  ✔ Passed               | 00:00:00.0002313 | `OptimizerTests (-(B),-B)                          ` |
|  ✔ Passed               | 00:00:00.0001413 | `OptimizerTests (-(3),-3)                          ` |
|  ✔ Passed               | 00:00:00.0000325 | `OptimizerTests (-3,-3)                            ` |
|  ✔ Passed               | 00:00:00.0001838 | `OptimizerTests (--B,B)                            ` |
|  ✔ Passed               | 00:00:00.0000371 | `OptimizerTests (---B,-B)                          ` |
|  ✔ Passed               | 00:00:00.0002801 | `OptimizerTests (-1*(A*B),-(A * B))                ` |
|  ✔ Passed               | 00:00:00.0000352 | `OptimizerTests (A!,A!)                            ` |
|  ✔ Passed               | 00:00:00.0000405 | `OptimizerTests ((A)!,A!)                          ` |
|  ✔ Passed               | 00:00:00.0028870 | `OptimizerTests (3!!,720)                          ` |
|  ✔ Passed               | 00:00:00.0000710 | `OptimizerTests (2!!!,2)                           ` |
|  ✔ Passed               | 00:00:00.0000433 | `OptimizerTests (N!!,N!!)                          ` |
|  ✔ Passed               | 00:00:00.0000299 | `OptimizerTests (N!!!,N!!!)                        ` |

### GetDistinctVariablesTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0035491 | `GetDistinctVariablesTests                         ` |
|  ✔ Passed               | 00:00:00.0032765 | `GetDistinctVariablesTests (A+B+C,A, B, C)         ` |
|  ✔ Passed               | 00:00:00.0000990 | `GetDistinctVariablesTests (A+B+B,A, B)            ` |
|  ✔ Passed               | 00:00:00.0000521 | `GetDistinctVariablesTests (Abc+XyW1,Abc, XyW1)    ` |

### VerifyOptimizerForComplexExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0368892 | `VerifyOptimizerForComplexExpressions              ` |
|  ✔ Passed               | 00:00:00.0124759 | `Check Expressions "A"                             ` |
|  ✔ Passed               | 00:00:00.0001435 | `Check Expressions "A*1"                           ` |
|  ✔ Passed               | 00:00:00.0001057 | `Check Expressions "(A*B)+C"                       ` |
|  ✔ Passed               | 00:00:00.0000549 | `Check Expressions "(A*B)"                         ` |
|  ✔ Passed               | 00:00:00.0001013 | `Check Expressions "(A-B)/A"                       ` |
|  ✔ Passed               | 00:00:00.0044077 | `Check Expressions "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"` |
|  ✔ Passed               | 00:00:00.0006770 | `Check Expressions "((A+B+((C*D)+E))*F)+G+((D/H)*I)` |
|  ✔ Passed               | 00:00:00.0000917 | `Check Expressions "A*(B/C)+D"                     ` |
|  ✔ Passed               | 00:00:00.0000510 | `Check Expressions "A*B+C"                         ` |
|  ✔ Passed               | 00:00:00.0003384 | `Check Expressions "(((A-(B*C))/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.0001000 | `Check Expressions "(A/B)-(C+D+E+F)"               ` |
|  ✔ Passed               | 00:00:00.0000898 | `Check Expressions "((A*B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0001535 | `Check Expressions "(((A*B)*C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.0001878 | `Check Expressions "(((A/B)+(-1*C))*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.0001285 | `Check Expressions "(A*B*(C/D))+E"                 ` |
|  ✔ Passed               | 00:00:00.0000742 | `Check Expressions "(A*(B/C)+D)"                   ` |
|  ✔ Passed               | 00:00:00.0000400 | `Check Expressions "A+B"                           ` |
|  ✔ Passed               | 00:00:00.0001040 | `Check Expressions "((A/B)*(C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.0001458 | `Check Expressions "((A+((B*C)+D))*E)+F+(C*G)+H"   ` |
|  ✔ Passed               | 00:00:00.0001550 | `Check Expressions "(A+((B*C)+D))*E+F+(A+((B*C)+D))` |
|  ✔ Passed               | 00:00:00.0006402 | `Check Expressions "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"` |
|  ✔ Passed               | 00:00:00.0001082 | `Check Expressions "((A*B)+C)+((D*B)+E)"           ` |
|  ✔ Passed               | 00:00:00.0007822 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"` |
|  ✔ Passed               | 00:00:00.0006334 | `Check Expressions "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"` |
|  ✔ Passed               | 00:00:00.0006292 | `Check Expressions "(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)"` |
|  ✔ Passed               | 00:00:00.0014712 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"` |
|  ✔ Passed               | 00:00:00.0001753 | `Check Expressions "((A*B)+C)+(-1*A)"              ` |
|  ✔ Passed               | 00:00:00.0003048 | `Check Expressions "(((A+(-1*B))+((C*D)+E))*F)+G+(D` |
|  ✔ Passed               | 00:00:00.0002566 | `Check Expressions "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"` |
|  ✔ Passed               | 00:00:00.0001849 | `Check Expressions "((A*(B+(-1*C)))+D)+((E*(B+(-1*C` |
|  ✔ Passed               | 00:00:00.0026663 | `Check Expressions "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"` |
|  ✔ Passed               | 00:00:00.0006961 | `Check Expressions "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"` |
|  ✔ Passed               | 00:00:00.0016208 | `Check Expressions "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"` |
|  ✔ Passed               | 00:00:00.0001821 | `Check Expressions "(((A+(-1*B))*C)+D)+(B+(-1*A))" ` |
|  ✔ Passed               | 00:00:00.0005011 | `Check Expressions "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"` |
|  ✔ Passed               | 00:00:00.0001793 | `Check Expressions "((A+((B*C)+D))*E)+F+((C/G)*H)+I` |
|  ✔ Passed               | 00:00:00.0001006 | `Check Expressions "(A+B)*C+D+(A+B)*E+F"           ` |
|  ✔ Passed               | 00:00:00.0000404 | `Check Expressions "A*B"                           ` |
|  ✔ Passed               | 00:00:00.0004927 | `Check Expressions "((A+((-1*B)*(C/D)))*(E/C))+(-1*` |
|  ✔ Passed               | 00:00:00.0001824 | `Check Expressions "((A/(1-B))*C)+D"               ` |
|  ✔ Passed               | 00:00:00.0001477 | `Check Expressions "(((A-(B*C))/(1-D))*E)+F"       ` |
|  ✔ Passed               | 00:00:00.0001211 | `Check Expressions "(A*(1+(-1*B))+C)*D+E"          ` |
|  ✔ Passed               | 00:00:00.0000655 | `Check Expressions "(A+B)*C+D"                     ` |
|  ✔ Passed               | 00:00:00.0001403 | `Check Expressions "(((A/B)*C*D)*E*F)+G"           ` |
|  ✔ Passed               | 00:00:00.0000754 | `Check Expressions "((A-B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0000809 | `Check Expressions "((A/B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0001227 | `Check Expressions "((((A*B)+C)/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.0001093 | `Check Expressions "((A/B)*C*D*E)+F"               ` |
|  ✔ Passed               | 00:00:00.0000688 | `Check Expressions "(A*B*C)+D"                     ` |
|  ✔ Passed               | 00:00:00.0000876 | `Check Expressions "(((A*B)+C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.0001271 | `Check Expressions "(((A/B)*C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.0000484 | `Check Expressions "(A*1)"                         ` |
|  ✔ Passed               | 00:00:00.0001421 | `Check Expressions "(((A/B)+(-1*C))*D*E*F)+G"      ` |
|  ✔ Passed               | 00:00:00.0001055 | `Check Expressions "((A*B)+C)+(D*E*F)"             ` |
|  ✔ Passed               | 00:00:00.0003446 | `Check Expressions "((A/(1+(-1*(B+C))))*D)+E"      ` |
|  ✔ Passed               | 00:00:00.0000913 | `Check Expressions "((A-(B*C))*D)+E"               ` |
|  ✔ Passed               | 00:00:00.0001509 | `Check Expressions "(((A+(-1*B))/C)*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.0001380 | `Check Expressions "((A/B)*((C*D)*E)*F)+G"         ` |
|  ✔ Passed               | 00:00:00.0002038 | `Check Expressions "((((A/B)*C)+D)*((E*F)*G))+H"   ` |
|  ✔ Passed               | 00:00:00.0001994 | `Check Expressions "(((A/B)+(-1*C))*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.0001842 | `Check Expressions "(((A+(-1*B))/C)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.0003042 | `Check Expressions "(((A/B)*(((C*D)*E)*F))+(C*D*G))` |
|  ✔ Passed               | 00:00:00.0001934 | `Check Expressions "((A*B)+((A*C)-A)*D)+E"         ` |
|  ✔ Passed               | 00:00:00.0002988 | `Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.0002062 | `Check Expressions "(((A/B)*((C*D)*E)*F)*G)+H"     ` |
|  ✔ Passed               | 00:00:00.0001585 | `Check Expressions "((A/B)*(((C*D)*E)*F))+G"       ` |
|  ✔ Passed               | 00:00:00.0001226 | `Check Expressions "((A/B)*((C*D)*E))+F"           ` |
|  ✔ Passed               | 00:00:00.0000660 | `Check Expressions "(A/(A+B))"                     ` |
|  ✔ Passed               | 00:00:00.0000420 | `VerifyOptimizerForComplexExpressions (A!)         ` |

### SimpleParserTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0161172 | `SimpleParserTests                                 ` |
|  ✔ Passed               | 00:00:00.0027160 | `Parse all operators test                          ` |
|  ✔ Passed               | 00:00:00.0001865 | `Simple test with variable                         ` |
|  ✔ Passed               | 00:00:00.0000484 | `Just variable                                     ` |
|  ✔ Passed               | 00:00:00.0000316 | `Just decimal value                                ` |
|  ✔ Passed               | 00:00:00.0025955 | `Simple factorial                                  ` |
|  ✔ Passed               | 00:00:00.0011233 | `Negative factorial                                ` |
|  ✔ Passed               | 00:00:00.0090766 | `Parse Complex Expression                          ` |
|  ✔ Passed               | 00:00:00.0000461 | `SimpleParserTests (B*--A,B * --A)                 ` |

### PoorlyFormedExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.1290676 | `PoorlyFormedExpressions                           ` |
|  ✔ Passed               | 00:00:00.1052859 | `PoorlyFormedExpressions (-A!)                     ` |
|  ✔ Passed               | 00:00:00.0103310 | `PoorlyFormedExpressions (B/*1)                    ` |
|  ✔ Passed               | 00:00:00.0031480 | `PoorlyFormedExpressions (B**)                     ` |
|  ✔ Passed               | 00:00:00.0003572 | `PoorlyFormedExpressions (B**A)                    ` |
|  ✔ Passed               | 00:00:00.0003668 | `PoorlyFormedExpressions (B***A)                   ` |
|  ✔ Passed               | 00:00:00.0003961 | `PoorlyFormedExpressions (B*+*A)                   ` |
|  ✔ Passed               | 00:00:00.0004031 | `PoorlyFormedExpressions (B*-*A)                   ` |
|  ✔ Passed               | 00:00:00.0003628 | `PoorlyFormedExpressions ()                        ` |
|  ✔ Passed               | 00:00:00.0026177 | `PoorlyFormedExpressions (b)                       ` |
|  ✔ Passed               | 00:00:00.0007461 | `PoorlyFormedExpressions (b+1)                     ` |

### OptimizerTests_WithExceptions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0012989 | `OptimizerTests_WithExceptions                     ` |
|  ✔ Passed               | 00:00:00.0008408 | `OptimizerTests_WithExceptions (B/0)               ` |
|  ✔ Passed               | 00:00:00.0003561 | `OptimizerTests_WithExceptions (B%0)               ` |

