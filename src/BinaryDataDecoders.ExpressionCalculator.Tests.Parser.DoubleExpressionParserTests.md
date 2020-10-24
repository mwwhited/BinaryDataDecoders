## BinaryDataDecoders.ExpressionCalculator.Tests.Parser.DoubleExpressionParserTests

### PoorlyFormedExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0115116 | `PoorlyFormedExpressions                           ` |
|  ✔ Passed               | 00:00:00.0051205 | `PoorlyFormedExpressions (-A!)                     ` |
|  ✔ Passed               | 00:00:00.0009438 | `PoorlyFormedExpressions (B/*1)                    ` |
|  ✔ Passed               | 00:00:00.0005661 | `PoorlyFormedExpressions (B**)                     ` |
|  ✔ Passed               | 00:00:00.0005105 | `PoorlyFormedExpressions (B**A)                    ` |
|  ✔ Passed               | 00:00:00.0004546 | `PoorlyFormedExpressions (B***A)                   ` |
|  ✔ Passed               | 00:00:00.0006076 | `PoorlyFormedExpressions (B*+*A)                   ` |
|  ✔ Passed               | 00:00:00.0009072 | `PoorlyFormedExpressions (B*-*A)                   ` |
|  ✔ Passed               | 00:00:00.0006290 | `PoorlyFormedExpressions ()                        ` |
|  ✔ Passed               | 00:00:00.0006079 | `PoorlyFormedExpressions (b)                       ` |
|  ✔ Passed               | 00:00:00.0005704 | `PoorlyFormedExpressions (b+1)                     ` |

### OptimizerTests_WithExceptions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0013415 | `OptimizerTests_WithExceptions                     ` |
|  ✔ Passed               | 00:00:00.0008481 | `OptimizerTests_WithExceptions (B/0)               ` |
|  ✔ Passed               | 00:00:00.0003811 | `OptimizerTests_WithExceptions (B%0)               ` |

### OptimizerTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0149332 | `OptimizerTests                                    ` |
|  ✔ Passed               | 00:00:00.0027322 | `OptimizerTests ((A),A)                            ` |
|  ✔ Passed               | 00:00:00.0024358 | `OptimizerTests ((A+(B)),A + B)                    ` |
|  ✔ Passed               | 00:00:00.0002155 | `OptimizerTests (B^1,B)                            ` |
|  ✔ Passed               | 00:00:00.0000481 | `OptimizerTests (B*1,B)                            ` |
|  ✔ Passed               | 00:00:00.0000319 | `OptimizerTests (1*B,B)                            ` |
|  ✔ Passed               | 00:00:00.0015345 | `OptimizerTests (B*-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.0000914 | `OptimizerTests (-1*B,-B)                          ` |
|  ✔ Passed               | 00:00:00.0000363 | `OptimizerTests (B/1,B)                            ` |
|  ✔ Passed               | 00:00:00.0000375 | `OptimizerTests (B/-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.0000309 | `OptimizerTests (B+0,B)                            ` |
|  ✔ Passed               | 00:00:00.0000288 | `OptimizerTests (0+B,B)                            ` |
|  ✔ Passed               | 00:00:00.0000277 | `OptimizerTests (B-0,B)                            ` |
|  ✔ Passed               | 00:00:00.0000406 | `OptimizerTests (0-B,-B)                           ` |
|  ✔ Passed               | 00:00:00.0011424 | `OptimizerTests (2+3*4^5%6/7-8,-6)                 ` |
|  ✔ Passed               | 00:00:00.0000779 | `OptimizerTests (2+3,5)                            ` |
|  ✔ Passed               | 00:00:00.0004752 | `OptimizerTests (B/B,1)                            ` |
|  ✔ Passed               | 00:00:00.0000543 | `OptimizerTests (B%B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000349 | `OptimizerTests (B^0,1)                            ` |
|  ✔ Passed               | 00:00:00.0000295 | `OptimizerTests (0^B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000291 | `OptimizerTests (0*B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000292 | `OptimizerTests (B*0,0)                            ` |
|  ✔ Passed               | 00:00:00.0000385 | `OptimizerTests (0/B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000341 | `OptimizerTests (0%B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000308 | `OptimizerTests (B%1,0)                            ` |
|  ✔ Passed               | 00:00:00.0000409 | `OptimizerTests (B%-1,0)                           ` |
|  ✔ Passed               | 00:00:00.0002747 | `OptimizerTests (-(B),-B)                          ` |
|  ✔ Passed               | 00:00:00.0001612 | `OptimizerTests (-(3),-3)                          ` |
|  ✔ Passed               | 00:00:00.0000373 | `OptimizerTests (-3,-3)                            ` |
|  ✔ Passed               | 00:00:00.0002000 | `OptimizerTests (--B,B)                            ` |
|  ✔ Passed               | 00:00:00.0000413 | `OptimizerTests (---B,-B)                          ` |
|  ✔ Passed               | 00:00:00.0002017 | `OptimizerTests (-1*(A*B),-(A * B))                ` |
|  ✔ Passed               | 00:00:00.0000343 | `OptimizerTests (A!,A!)                            ` |
|  ✔ Passed               | 00:00:00.0000303 | `OptimizerTests ((A)!,A!)                          ` |
|  ✔ Passed               | 00:00:00.0035495 | `OptimizerTests (3!!,720)                          ` |
|  ✔ Passed               | 00:00:00.0000912 | `OptimizerTests (2!!!,2)                           ` |
|  ✔ Passed               | 00:00:00.0000340 | `OptimizerTests (N!!,N!!)                          ` |
|  ✔ Passed               | 00:00:00.0000359 | `OptimizerTests (N!!!,N!!!)                        ` |

### GetDistinctVariablesTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0038831 | `GetDistinctVariablesTests                         ` |
|  ✔ Passed               | 00:00:00.0036460 | `GetDistinctVariablesTests (A+B+C,A, B, C)         ` |
|  ✔ Passed               | 00:00:00.0000798 | `GetDistinctVariablesTests (A+B+B,A, B)            ` |
|  ✔ Passed               | 00:00:00.0000289 | `GetDistinctVariablesTests (Abc+XyW1,Abc, XyW1)    ` |

### SimpleParserTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0038015 | `SimpleParserTests                                 ` |
|  ✔ Passed               | 00:00:00.0019392 | `Parse all operators test                          ` |
|  ✔ Passed               | 00:00:00.0001910 | `Simple test with variable                         ` |
|  ✔ Passed               | 00:00:00.0000447 | `Just variable                                     ` |
|  ✔ Passed               | 00:00:00.0000227 | `Just decimal value                                ` |
|  ✔ Passed               | 00:00:00.0006364 | `Simple factorial                                  ` |
|  ✔ Passed               | 00:00:00.0004429 | `Negative factorial                                ` |
|  ✔ Passed               | 00:00:00.0001897 | `Parse Complex Expression                          ` |
|  ✔ Passed               | 00:00:00.0000545 | `SimpleParserTests (B*--A,B * --A)                 ` |

### VerifyOptimizerForComplexExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0306833 | `VerifyOptimizerForComplexExpressions              ` |
|  ✔ Passed               | 00:00:00.0139420 | `Check Expressions "A"                             ` |
|  ✔ Passed               | 00:00:00.0001659 | `Check Expressions "A*1"                           ` |
|  ✔ Passed               | 00:00:00.0001299 | `Check Expressions "(A*B)+C"                       ` |
|  ✔ Passed               | 00:00:00.0000576 | `Check Expressions "(A*B)"                         ` |
|  ✔ Passed               | 00:00:00.0000766 | `Check Expressions "(A-B)/A"                       ` |
|  ✔ Passed               | 00:00:00.0012954 | `Check Expressions "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"` |
|  ✔ Passed               | 00:00:00.0002526 | `Check Expressions "((A+B+((C*D)+E))*F)+G+((D/H)*I)` |
|  ✔ Passed               | 00:00:00.0000777 | `Check Expressions "A*(B/C)+D"                     ` |
|  ✔ Passed               | 00:00:00.0000552 | `Check Expressions "A*B+C"                         ` |
|  ✔ Passed               | 00:00:00.0001335 | `Check Expressions "(((A-(B*C))/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.0000986 | `Check Expressions "(A/B)-(C+D+E+F)"               ` |
|  ✔ Passed               | 00:00:00.0000986 | `Check Expressions "((A*B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0001084 | `Check Expressions "(((A*B)*C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.0001812 | `Check Expressions "(((A/B)+(-1*C))*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.0000970 | `Check Expressions "(A*B*(C/D))+E"                 ` |
|  ✔ Passed               | 00:00:00.0000916 | `Check Expressions "(A*(B/C)+D)"                   ` |
|  ✔ Passed               | 00:00:00.0000528 | `Check Expressions "A+B"                           ` |
|  ✔ Passed               | 00:00:00.0001381 | `Check Expressions "((A/B)*(C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.0001601 | `Check Expressions "((A+((B*C)+D))*E)+F+(C*G)+H"   ` |
|  ✔ Passed               | 00:00:00.0001994 | `Check Expressions "(A+((B*C)+D))*E+F+(A+((B*C)+D))` |
|  ✔ Passed               | 00:00:00.0003180 | `Check Expressions "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"` |
|  ✔ Passed               | 00:00:00.0001271 | `Check Expressions "((A*B)+C)+((D*B)+E)"           ` |
|  ✔ Passed               | 00:00:00.0003996 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"` |
|  ✔ Passed               | 00:00:00.0003100 | `Check Expressions "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"` |
|  ✔ Passed               | 00:00:00.0003017 | `Check Expressions "(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)"` |
|  ✔ Passed               | 00:00:00.0016352 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"` |
|  ✔ Passed               | 00:00:00.0001467 | `Check Expressions "((A*B)+C)+(-1*A)"              ` |
|  ✔ Passed               | 00:00:00.0002069 | `Check Expressions "(((A+(-1*B))+((C*D)+E))*F)+G+(D` |
|  ✔ Passed               | 00:00:00.0002651 | `Check Expressions "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"` |
|  ✔ Passed               | 00:00:00.0001992 | `Check Expressions "((A*(B+(-1*C)))+D)+((E*(B+(-1*C` |
|  ✔ Passed               | 00:00:00.0003959 | `Check Expressions "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"` |
|  ✔ Passed               | 00:00:00.0004113 | `Check Expressions "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"` |
|  ✔ Passed               | 00:00:00.0007486 | `Check Expressions "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"` |
|  ✔ Passed               | 00:00:00.0001698 | `Check Expressions "(((A+(-1*B))*C)+D)+(B+(-1*A))" ` |
|  ✔ Passed               | 00:00:00.0002312 | `Check Expressions "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"` |
|  ✔ Passed               | 00:00:00.0001800 | `Check Expressions "((A+((B*C)+D))*E)+F+((C/G)*H)+I` |
|  ✔ Passed               | 00:00:00.0001133 | `Check Expressions "(A+B)*C+D+(A+B)*E+F"           ` |
|  ✔ Passed               | 00:00:00.0000441 | `Check Expressions "A*B"                           ` |
|  ✔ Passed               | 00:00:00.0002930 | `Check Expressions "((A+((-1*B)*(C/D)))*(E/C))+(-1*` |
|  ✔ Passed               | 00:00:00.0002036 | `Check Expressions "((A/(1-B))*C)+D"               ` |
|  ✔ Passed               | 00:00:00.0002290 | `Check Expressions "(((A-(B*C))/(1-D))*E)+F"       ` |
|  ✔ Passed               | 00:00:00.0002131 | `Check Expressions "(A*(1+(-1*B))+C)*D+E"          ` |
|  ✔ Passed               | 00:00:00.0001127 | `Check Expressions "(A+B)*C+D"                     ` |
|  ✔ Passed               | 00:00:00.0002326 | `Check Expressions "(((A/B)*C*D)*E*F)+G"           ` |
|  ✔ Passed               | 00:00:00.0000891 | `Check Expressions "((A-B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0000836 | `Check Expressions "((A/B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0001204 | `Check Expressions "((((A*B)+C)/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.0001201 | `Check Expressions "((A/B)*C*D*E)+F"               ` |
|  ✔ Passed               | 00:00:00.0000724 | `Check Expressions "(A*B*C)+D"                     ` |
|  ✔ Passed               | 00:00:00.0001699 | `Check Expressions "(((A*B)+C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.0001912 | `Check Expressions "(((A/B)*C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.0000858 | `Check Expressions "(A*1)"                         ` |
|  ✔ Passed               | 00:00:00.0001891 | `Check Expressions "(((A/B)+(-1*C))*D*E*F)+G"      ` |
|  ✔ Passed               | 00:00:00.0001422 | `Check Expressions "((A*B)+C)+(D*E*F)"             ` |
|  ✔ Passed               | 00:00:00.0002565 | `Check Expressions "((A/(1+(-1*(B+C))))*D)+E"      ` |
|  ✔ Passed               | 00:00:00.0001239 | `Check Expressions "((A-(B*C))*D)+E"               ` |
|  ✔ Passed               | 00:00:00.0002050 | `Check Expressions "(((A+(-1*B))/C)*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.0001897 | `Check Expressions "((A/B)*((C*D)*E)*F)+G"         ` |
|  ✔ Passed               | 00:00:00.0002211 | `Check Expressions "((((A/B)*C)+D)*((E*F)*G))+H"   ` |
|  ✔ Passed               | 00:00:00.0003119 | `Check Expressions "(((A/B)+(-1*C))*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.0002531 | `Check Expressions "(((A+(-1*B))/C)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.0002916 | `Check Expressions "(((A/B)*(((C*D)*E)*F))+(C*D*G))` |
|  ✔ Passed               | 00:00:00.0001322 | `Check Expressions "((A*B)+((A*C)-A)*D)+E"         ` |
|  ✔ Passed               | 00:00:00.0005194 | `Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.0002057 | `Check Expressions "(((A/B)*((C*D)*E)*F)*G)+H"     ` |
|  ✔ Passed               | 00:00:00.0001761 | `Check Expressions "((A/B)*(((C*D)*E)*F))+G"       ` |
|  ✔ Passed               | 00:00:00.0001412 | `Check Expressions "((A/B)*((C*D)*E))+F"           ` |
|  ✔ Passed               | 00:00:00.0000718 | `Check Expressions "(A/(A+B))"                     ` |
|  ✔ Passed               | 00:00:00.0000472 | `VerifyOptimizerForComplexExpressions (A!)         ` |

