## BinaryDataDecoders.ExpressionCalculator.Tests.Parser.FloatExpressionParserTests

### SimpleParserTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0047822 | `SimpleParserTests                                 ` |
|  ✔ Passed               | 00:00:00.0025319 | `Parse all operators test                          ` |
|  ✔ Passed               | 00:00:00.0002461 | `Simple test with variable                         ` |
|  ✔ Passed               | 00:00:00.0000334 | `Just variable                                     ` |
|  ✔ Passed               | 00:00:00.0000237 | `Just decimal value                                ` |
|  ✔ Passed               | 00:00:00.0008381 | `Simple factorial                                  ` |
|  ✔ Passed               | 00:00:00.0005520 | `Negative factorial                                ` |
|  ✔ Passed               | 00:00:00.0002210 | `Parse Complex Expression                          ` |
|  ✔ Passed               | 00:00:00.0000379 | `SimpleParserTests (B*--A,B * --A)                 ` |

### OptimizerTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0143263 | `OptimizerTests                                    ` |
|  ✔ Passed               | 00:00:00.0028917 | `OptimizerTests ((A),A)                            ` |
|  ✔ Passed               | 00:00:00.0028806 | `OptimizerTests ((A+(B)),A + B)                    ` |
|  ✔ Passed               | 00:00:00.0001932 | `OptimizerTests (B^1,B)                            ` |
|  ✔ Passed               | 00:00:00.0000471 | `OptimizerTests (B*1,B)                            ` |
|  ✔ Passed               | 00:00:00.0000318 | `OptimizerTests (1*B,B)                            ` |
|  ✔ Passed               | 00:00:00.0015119 | `OptimizerTests (B*-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.0000952 | `OptimizerTests (-1*B,-B)                          ` |
|  ✔ Passed               | 00:00:00.0000347 | `OptimizerTests (B/1,B)                            ` |
|  ✔ Passed               | 00:00:00.0000378 | `OptimizerTests (B/-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.0000301 | `OptimizerTests (B+0,B)                            ` |
|  ✔ Passed               | 00:00:00.0000278 | `OptimizerTests (0+B,B)                            ` |
|  ✔ Passed               | 00:00:00.0000276 | `OptimizerTests (B-0,B)                            ` |
|  ✔ Passed               | 00:00:00.0000300 | `OptimizerTests (0-B,-B)                           ` |
|  ✔ Passed               | 00:00:00.0010690 | `OptimizerTests (2+3*4^5%6/7-8,-6)                 ` |
|  ✔ Passed               | 00:00:00.0000813 | `OptimizerTests (2+3,5)                            ` |
|  ✔ Passed               | 00:00:00.0004832 | `OptimizerTests (B/B,1)                            ` |
|  ✔ Passed               | 00:00:00.0000563 | `OptimizerTests (B%B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000363 | `OptimizerTests (B^0,1)                            ` |
|  ✔ Passed               | 00:00:00.0000393 | `OptimizerTests (0^B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000304 | `OptimizerTests (0*B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000292 | `OptimizerTests (B*0,0)                            ` |
|  ✔ Passed               | 00:00:00.0000294 | `OptimizerTests (0/B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000289 | `OptimizerTests (0%B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000304 | `OptimizerTests (B%1,0)                            ` |
|  ✔ Passed               | 00:00:00.0000410 | `OptimizerTests (B%-1,0)                           ` |
|  ✔ Passed               | 00:00:00.0002561 | `OptimizerTests (-(B),-B)                          ` |
|  ✔ Passed               | 00:00:00.0001569 | `OptimizerTests (-(3),-3)                          ` |
|  ✔ Passed               | 00:00:00.0000374 | `OptimizerTests (-3,-3)                            ` |
|  ✔ Passed               | 00:00:00.0002270 | `OptimizerTests (--B,B)                            ` |
|  ✔ Passed               | 00:00:00.0000421 | `OptimizerTests (---B,-B)                          ` |
|  ✔ Passed               | 00:00:00.0001933 | `OptimizerTests (-1*(A*B),-(A * B))                ` |
|  ✔ Passed               | 00:00:00.0000414 | `OptimizerTests (A!,A!)                            ` |
|  ✔ Passed               | 00:00:00.0000343 | `OptimizerTests ((A)!,A!)                          ` |
|  ✔ Passed               | 00:00:00.0024846 | `OptimizerTests (3!!,720)                          ` |
|  ✔ Passed               | 00:00:00.0000790 | `OptimizerTests (2!!!,2)                           ` |
|  ✔ Passed               | 00:00:00.0000316 | `OptimizerTests (N!!,N!!)                          ` |
|  ✔ Passed               | 00:00:00.0000326 | `OptimizerTests (N!!!,N!!!)                        ` |

### GetDistinctVariablesTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0049767 | `GetDistinctVariablesTests                         ` |
|  ✔ Passed               | 00:00:00.0047386 | `GetDistinctVariablesTests (A+B+C,A, B, C)         ` |
|  ✔ Passed               | 00:00:00.0000792 | `GetDistinctVariablesTests (A+B+B,A, B)            ` |
|  ✔ Passed               | 00:00:00.0000292 | `GetDistinctVariablesTests (Abc+XyW1,Abc, XyW1)    ` |

### VerifyOptimizerForComplexExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0309630 | `VerifyOptimizerForComplexExpressions              ` |
|  ✔ Passed               | 00:00:00.0122234 | `Check Expressions "A"                             ` |
|  ✔ Passed               | 00:00:00.0001672 | `Check Expressions "A*1"                           ` |
|  ✔ Passed               | 00:00:00.0000857 | `Check Expressions "(A*B)+C"                       ` |
|  ✔ Passed               | 00:00:00.0000525 | `Check Expressions "(A*B)"                         ` |
|  ✔ Passed               | 00:00:00.0000866 | `Check Expressions "(A-B)/A"                       ` |
|  ✔ Passed               | 00:00:00.0012327 | `Check Expressions "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"` |
|  ✔ Passed               | 00:00:00.0003161 | `Check Expressions "((A+B+((C*D)+E))*F)+G+((D/H)*I)` |
|  ✔ Passed               | 00:00:00.0000842 | `Check Expressions "A*(B/C)+D"                     ` |
|  ✔ Passed               | 00:00:00.0000524 | `Check Expressions "A*B+C"                         ` |
|  ✔ Passed               | 00:00:00.0001480 | `Check Expressions "(((A-(B*C))/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.0001608 | `Check Expressions "(A/B)-(C+D+E+F)"               ` |
|  ✔ Passed               | 00:00:00.0001032 | `Check Expressions "((A*B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0001058 | `Check Expressions "(((A*B)*C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.0002226 | `Check Expressions "(((A/B)+(-1*C))*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.0001285 | `Check Expressions "(A*B*(C/D))+E"                 ` |
|  ✔ Passed               | 00:00:00.0000827 | `Check Expressions "(A*(B/C)+D)"                   ` |
|  ✔ Passed               | 00:00:00.0000433 | `Check Expressions "A+B"                           ` |
|  ✔ Passed               | 00:00:00.0001219 | `Check Expressions "((A/B)*(C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.0001513 | `Check Expressions "((A+((B*C)+D))*E)+F+(C*G)+H"   ` |
|  ✔ Passed               | 00:00:00.0002255 | `Check Expressions "(A+((B*C)+D))*E+F+(A+((B*C)+D))` |
|  ✔ Passed               | 00:00:00.0003476 | `Check Expressions "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"` |
|  ✔ Passed               | 00:00:00.0001536 | `Check Expressions "((A*B)+C)+((D*B)+E)"           ` |
|  ✔ Passed               | 00:00:00.0003849 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"` |
|  ✔ Passed               | 00:00:00.0003792 | `Check Expressions "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"` |
|  ✔ Passed               | 00:00:00.0003805 | `Check Expressions "(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)"` |
|  ✔ Passed               | 00:00:00.0010728 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"` |
|  ✔ Passed               | 00:00:00.0002654 | `Check Expressions "((A*B)+C)+(-1*A)"              ` |
|  ✔ Passed               | 00:00:00.0003794 | `Check Expressions "(((A+(-1*B))+((C*D)+E))*F)+G+(D` |
|  ✔ Passed               | 00:00:00.0005691 | `Check Expressions "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"` |
|  ✔ Passed               | 00:00:00.0005181 | `Check Expressions "((A*(B+(-1*C)))+D)+((E*(B+(-1*C` |
|  ✔ Passed               | 00:00:00.0010448 | `Check Expressions "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"` |
|  ✔ Passed               | 00:00:00.0008416 | `Check Expressions "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"` |
|  ✔ Passed               | 00:00:00.0014978 | `Check Expressions "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"` |
|  ✔ Passed               | 00:00:00.0002558 | `Check Expressions "(((A+(-1*B))*C)+D)+(B+(-1*A))" ` |
|  ✔ Passed               | 00:00:00.0002419 | `Check Expressions "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"` |
|  ✔ Passed               | 00:00:00.0002567 | `Check Expressions "((A+((B*C)+D))*E)+F+((C/G)*H)+I` |
|  ✔ Passed               | 00:00:00.0001133 | `Check Expressions "(A+B)*C+D+(A+B)*E+F"           ` |
|  ✔ Passed               | 00:00:00.0000451 | `Check Expressions "A*B"                           ` |
|  ✔ Passed               | 00:00:00.0002239 | `Check Expressions "((A+((-1*B)*(C/D)))*(E/C))+(-1*` |
|  ✔ Passed               | 00:00:00.0001137 | `Check Expressions "((A/(1-B))*C)+D"               ` |
|  ✔ Passed               | 00:00:00.0001923 | `Check Expressions "(((A-(B*C))/(1-D))*E)+F"       ` |
|  ✔ Passed               | 00:00:00.0002693 | `Check Expressions "(A*(1+(-1*B))+C)*D+E"          ` |
|  ✔ Passed               | 00:00:00.0000802 | `Check Expressions "(A+B)*C+D"                     ` |
|  ✔ Passed               | 00:00:00.0001390 | `Check Expressions "(((A/B)*C*D)*E*F)+G"           ` |
|  ✔ Passed               | 00:00:00.0000776 | `Check Expressions "((A-B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0001154 | `Check Expressions "((A/B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0001274 | `Check Expressions "((((A*B)+C)/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.0001343 | `Check Expressions "((A/B)*C*D*E)+F"               ` |
|  ✔ Passed               | 00:00:00.0001249 | `Check Expressions "(A*B*C)+D"                     ` |
|  ✔ Passed               | 00:00:00.0001101 | `Check Expressions "(((A*B)+C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.0001245 | `Check Expressions "(((A/B)*C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.0000716 | `Check Expressions "(A*1)"                         ` |
|  ✔ Passed               | 00:00:00.0001651 | `Check Expressions "(((A/B)+(-1*C))*D*E*F)+G"      ` |
|  ✔ Passed               | 00:00:00.0001232 | `Check Expressions "((A*B)+C)+(D*E*F)"             ` |
|  ✔ Passed               | 00:00:00.0002069 | `Check Expressions "((A/(1+(-1*(B+C))))*D)+E"      ` |
|  ✔ Passed               | 00:00:00.0001037 | `Check Expressions "((A-(B*C))*D)+E"               ` |
|  ✔ Passed               | 00:00:00.0001724 | `Check Expressions "(((A+(-1*B))/C)*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.0001442 | `Check Expressions "((A/B)*((C*D)*E)*F)+G"         ` |
|  ✔ Passed               | 00:00:00.0001828 | `Check Expressions "((((A/B)*C)+D)*((E*F)*G))+H"   ` |
|  ✔ Passed               | 00:00:00.0002017 | `Check Expressions "(((A/B)+(-1*C))*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.0002526 | `Check Expressions "(((A+(-1*B))/C)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.0002507 | `Check Expressions "(((A/B)*(((C*D)*E)*F))+(C*D*G))` |
|  ✔ Passed               | 00:00:00.0001408 | `Check Expressions "((A*B)+((A*C)-A)*D)+E"         ` |
|  ✔ Passed               | 00:00:00.0003030 | `Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.0002093 | `Check Expressions "(((A/B)*((C*D)*E)*F)*G)+H"     ` |
|  ✔ Passed               | 00:00:00.0001607 | `Check Expressions "((A/B)*(((C*D)*E)*F))+G"       ` |
|  ✔ Passed               | 00:00:00.0001372 | `Check Expressions "((A/B)*((C*D)*E))+F"           ` |
|  ✔ Passed               | 00:00:00.0000691 | `Check Expressions "(A/(A+B))"                     ` |
|  ✔ Passed               | 00:00:00.0000458 | `VerifyOptimizerForComplexExpressions (A!)         ` |

### PoorlyFormedExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0127992 | `PoorlyFormedExpressions                           ` |
|  ✔ Passed               | 00:00:00.0065286 | `PoorlyFormedExpressions (-A!)                     ` |
|  ✔ Passed               | 00:00:00.0009314 | `PoorlyFormedExpressions (B/*1)                    ` |
|  ✔ Passed               | 00:00:00.0007948 | `PoorlyFormedExpressions (B**)                     ` |
|  ✔ Passed               | 00:00:00.0007773 | `PoorlyFormedExpressions (B**A)                    ` |
|  ✔ Passed               | 00:00:00.0006897 | `PoorlyFormedExpressions (B***A)                   ` |
|  ✔ Passed               | 00:00:00.0005186 | `PoorlyFormedExpressions (B*+*A)                   ` |
|  ✔ Passed               | 00:00:00.0005585 | `PoorlyFormedExpressions (B*-*A)                   ` |
|  ✔ Passed               | 00:00:00.0004628 | `PoorlyFormedExpressions ()                        ` |
|  ✔ Passed               | 00:00:00.0005290 | `PoorlyFormedExpressions (b)                       ` |
|  ✔ Passed               | 00:00:00.0005074 | `PoorlyFormedExpressions (b+1)                     ` |

### OptimizerTests_WithExceptions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0017329 | `OptimizerTests_WithExceptions                     ` |
|  ✔ Passed               | 00:00:00.0009325 | `OptimizerTests_WithExceptions (B/0)               ` |
|  ✔ Passed               | 00:00:00.0006422 | `OptimizerTests_WithExceptions (B%0)               ` |

