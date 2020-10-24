## BinaryDataDecoders.ExpressionCalculator.Tests.Parser.Int8ExpressionParserTests

### OptimizerTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.0137782 | `OptimizerTests                                    ` |
|  ✔ Passed               | 00:00:00.0048577 | `OptimizerTests ((A),A)                            ` |
|  ✔ Passed               | 00:00:00.0021332 | `OptimizerTests ((A+(B)),A + B)                    ` |
|  ✔ Passed               | 00:00:00.0001670 | `OptimizerTests (B^1,B)                            ` |
|  ✔ Passed               | 00:00:00.0000405 | `OptimizerTests (B*1,B)                            ` |
|  ✔ Passed               | 00:00:00.0000296 | `OptimizerTests (1*B,B)                            ` |
|  ✔ Passed               | 00:00:00.0014072 | `OptimizerTests (B*-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.0000656 | `OptimizerTests (-1*B,-B)                          ` |
|  ✔ Passed               | 00:00:00.0000329 | `OptimizerTests (B/1,B)                            ` |
|  ✔ Passed               | 00:00:00.0000343 | `OptimizerTests (B/-1,-B)                          ` |
|  ✔ Passed               | 00:00:00.0000278 | `OptimizerTests (B+0,B)                            ` |
|  ✔ Passed               | 00:00:00.0000301 | `OptimizerTests (0+B,B)                            ` |
|  ✔ Passed               | 00:00:00.0000284 | `OptimizerTests (B-0,B)                            ` |
|  ✔ Passed               | 00:00:00.0000284 | `OptimizerTests (0-B,-B)                           ` |
|  ✔ Passed               | 00:00:00.0009222 | `OptimizerTests (2+3*4^5%6/7-8,-6)                 ` |
|  ✔ Passed               | 00:00:00.0000524 | `OptimizerTests (2+3,5)                            ` |
|  ✔ Passed               | 00:00:00.0003802 | `OptimizerTests (B/B,1)                            ` |
|  ✔ Passed               | 00:00:00.0000356 | `OptimizerTests (B%B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000282 | `OptimizerTests (B^0,1)                            ` |
|  ✔ Passed               | 00:00:00.0000265 | `OptimizerTests (0^B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000267 | `OptimizerTests (0*B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000267 | `OptimizerTests (B*0,0)                            ` |
|  ✔ Passed               | 00:00:00.0000263 | `OptimizerTests (0/B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000263 | `OptimizerTests (0%B,0)                            ` |
|  ✔ Passed               | 00:00:00.0000263 | `OptimizerTests (B%1,0)                            ` |
|  ✔ Passed               | 00:00:00.0000337 | `OptimizerTests (B%-1,0)                           ` |
|  ✔ Passed               | 00:00:00.0001886 | `OptimizerTests (-(B),-B)                          ` |
|  ✔ Passed               | 00:00:00.0001247 | `OptimizerTests (-(3),-3)                          ` |
|  ✔ Passed               | 00:00:00.0000357 | `OptimizerTests (-3,-3)                            ` |
|  ✔ Passed               | 00:00:00.0001890 | `OptimizerTests (--B,B)                            ` |
|  ✔ Passed               | 00:00:00.0000371 | `OptimizerTests (---B,-B)                          ` |
|  ✔ Passed               | 00:00:00.0001612 | `OptimizerTests (-1*(A*B),-(A * B))                ` |
|  ✔ Passed               | 00:00:00.0000352 | `OptimizerTests (A!,A!)                            ` |
|  ✔ Passed               | 00:00:00.0000321 | `OptimizerTests ((A)!,A!)                          ` |
|  ⚠ Inconclusive        | 00:00:00.0006227 | `OptimizerTests (3!!,720)                          ` |
|  ⚠ Inconclusive        | 00:00:00.0003688 | `OptimizerTests (2!!!,2)                           ` |
|  ⚠ Inconclusive        | 00:00:00.0003375 | `OptimizerTests (N!!,N!!)                          ` |
|  ⚠ Inconclusive        | 00:00:00.0003387 | `OptimizerTests (N!!!,N!!!)                        ` |

### SimpleParserTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.0292035 | `SimpleParserTests                                 ` |
|  ✔ Passed               | 00:00:00.0020271 | `Parse all operators test                          ` |
|  ✔ Passed               | 00:00:00.0002092 | `Simple test with variable                         ` |
|  ✔ Passed               | 00:00:00.0000317 | `Just variable                                     ` |
|  ⚠ Inconclusive        | 00:00:00.0248887 | `Just decimal value                                ` |
|  ✔ Passed               | 00:00:00.0006668 | `Simple factorial                                  ` |
|  ✔ Passed               | 00:00:00.0004089 | `Negative factorial                                ` |
|  ⚠ Inconclusive        | 00:00:00.0006065 | `Parse Complex Expression                          ` |
|  ✔ Passed               | 00:00:00.0000674 | `SimpleParserTests (B*--A,B * --A)                 ` |

### GetDistinctVariablesTests
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0049728 | `GetDistinctVariablesTests                         ` |
|  ✔ Passed               | 00:00:00.0046138 | `GetDistinctVariablesTests (A+B+C,A, B, C)         ` |
|  ✔ Passed               | 00:00:00.0001162 | `GetDistinctVariablesTests (A+B+B,A, B)            ` |
|  ✔ Passed               | 00:00:00.0000546 | `GetDistinctVariablesTests (Abc+XyW1,Abc, XyW1)    ` |

### VerifyOptimizerForComplexExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ⚠ Inconclusive        | 00:00:00.0355967 | `VerifyOptimizerForComplexExpressions              ` |
|  ✔ Passed               | 00:00:00.0172062 | `Check Expressions "A"                             ` |
|  ✔ Passed               | 00:00:00.0001736 | `Check Expressions "A*1"                           ` |
|  ✔ Passed               | 00:00:00.0000789 | `Check Expressions "(A*B)+C"                       ` |
|  ✔ Passed               | 00:00:00.0000519 | `Check Expressions "(A*B)"                         ` |
|  ✔ Passed               | 00:00:00.0000839 | `Check Expressions "(A-B)/A"                       ` |
|  ✔ Passed               | 00:00:00.0012340 | `Check Expressions "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"` |
|  ✔ Passed               | 00:00:00.0002307 | `Check Expressions "((A+B+((C*D)+E))*F)+G+((D/H)*I)` |
|  ✔ Passed               | 00:00:00.0000729 | `Check Expressions "A*(B/C)+D"                     ` |
|  ✔ Passed               | 00:00:00.0000495 | `Check Expressions "A*B+C"                         ` |
|  ✔ Passed               | 00:00:00.0001295 | `Check Expressions "(((A-(B*C))/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.0000928 | `Check Expressions "(A/B)-(C+D+E+F)"               ` |
|  ✔ Passed               | 00:00:00.0000892 | `Check Expressions "((A*B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0001203 | `Check Expressions "(((A*B)*C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.0001798 | `Check Expressions "(((A/B)+(-1*C))*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.0000944 | `Check Expressions "(A*B*(C/D))+E"                 ` |
|  ✔ Passed               | 00:00:00.0000733 | `Check Expressions "(A*(B/C)+D)"                   ` |
|  ✔ Passed               | 00:00:00.0000408 | `Check Expressions "A+B"                           ` |
|  ✔ Passed               | 00:00:00.0001273 | `Check Expressions "((A/B)*(C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.0001570 | `Check Expressions "((A+((B*C)+D))*E)+F+(C*G)+H"   ` |
|  ✔ Passed               | 00:00:00.0001877 | `Check Expressions "(A+((B*C)+D))*E+F+(A+((B*C)+D))` |
|  ✔ Passed               | 00:00:00.0002968 | `Check Expressions "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"` |
|  ✔ Passed               | 00:00:00.0001214 | `Check Expressions "((A*B)+C)+((D*B)+E)"           ` |
|  ✔ Passed               | 00:00:00.0003732 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"` |
|  ✔ Passed               | 00:00:00.0003062 | `Check Expressions "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"` |
|  ✔ Passed               | 00:00:00.0002971 | `Check Expressions "(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)"` |
|  ✔ Passed               | 00:00:00.0006071 | `Check Expressions "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"` |
|  ✔ Passed               | 00:00:00.0007541 | `Check Expressions "((A*B)+C)+(-1*A)"              ` |
|  ✔ Passed               | 00:00:00.0002212 | `Check Expressions "(((A+(-1*B))+((C*D)+E))*F)+G+(D` |
|  ✔ Passed               | 00:00:00.0002447 | `Check Expressions "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"` |
|  ✔ Passed               | 00:00:00.0002183 | `Check Expressions "((A*(B+(-1*C)))+D)+((E*(B+(-1*C` |
|  ✔ Passed               | 00:00:00.0004104 | `Check Expressions "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"` |
|  ✔ Passed               | 00:00:00.0003886 | `Check Expressions "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"` |
|  ✔ Passed               | 00:00:00.0007726 | `Check Expressions "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"` |
|  ✔ Passed               | 00:00:00.0001721 | `Check Expressions "(((A+(-1*B))*C)+D)+(B+(-1*A))" ` |
|  ✔ Passed               | 00:00:00.0002380 | `Check Expressions "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"` |
|  ✔ Passed               | 00:00:00.0002099 | `Check Expressions "((A+((B*C)+D))*E)+F+((C/G)*H)+I` |
|  ✔ Passed               | 00:00:00.0001226 | `Check Expressions "(A+B)*C+D+(A+B)*E+F"           ` |
|  ✔ Passed               | 00:00:00.0000414 | `Check Expressions "A*B"                           ` |
|  ✔ Passed               | 00:00:00.0001974 | `Check Expressions "((A+((-1*B)*(C/D)))*(E/C))+(-1*` |
|  ✔ Passed               | 00:00:00.0001001 | `Check Expressions "((A/(1-B))*C)+D"               ` |
|  ✔ Passed               | 00:00:00.0001333 | `Check Expressions "(((A-(B*C))/(1-D))*E)+F"       ` |
|  ✔ Passed               | 00:00:00.0001240 | `Check Expressions "(A*(1+(-1*B))+C)*D+E"          ` |
|  ✔ Passed               | 00:00:00.0000639 | `Check Expressions "(A+B)*C+D"                     ` |
|  ✔ Passed               | 00:00:00.0001290 | `Check Expressions "(((A/B)*C*D)*E*F)+G"           ` |
|  ✔ Passed               | 00:00:00.0000879 | `Check Expressions "((A-B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0000858 | `Check Expressions "((A/B)*C)+D"                   ` |
|  ✔ Passed               | 00:00:00.0001146 | `Check Expressions "((((A*B)+C)/D)*E)+F"           ` |
|  ✔ Passed               | 00:00:00.0001007 | `Check Expressions "((A/B)*C*D*E)+F"               ` |
|  ✔ Passed               | 00:00:00.0000658 | `Check Expressions "(A*B*C)+D"                     ` |
|  ✔ Passed               | 00:00:00.0000942 | `Check Expressions "(((A*B)+C)*D)+E"               ` |
|  ✔ Passed               | 00:00:00.0001173 | `Check Expressions "(((A/B)*C*D)*E)+F"             ` |
|  ✔ Passed               | 00:00:00.0000460 | `Check Expressions "(A*1)"                         ` |
|  ✔ Passed               | 00:00:00.0001342 | `Check Expressions "(((A/B)+(-1*C))*D*E*F)+G"      ` |
|  ✔ Passed               | 00:00:00.0001638 | `Check Expressions "((A*B)+C)+(D*E*F)"             ` |
|  ✔ Passed               | 00:00:00.0002353 | `Check Expressions "((A/(1+(-1*(B+C))))*D)+E"      ` |
|  ✔ Passed               | 00:00:00.0001422 | `Check Expressions "((A-(B*C))*D)+E"               ` |
|  ✔ Passed               | 00:00:00.0002683 | `Check Expressions "(((A+(-1*B))/C)*(D*E)*F)+G"    ` |
|  ✔ Passed               | 00:00:00.0002851 | `Check Expressions "((A/B)*((C*D)*E)*F)+G"         ` |
|  ✔ Passed               | 00:00:00.0002642 | `Check Expressions "((((A/B)*C)+D)*((E*F)*G))+H"   ` |
|  ✔ Passed               | 00:00:00.0003297 | `Check Expressions "(((A/B)+(-1*C))*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.0003663 | `Check Expressions "(((A+(-1*B))/C)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.0003466 | `Check Expressions "(((A/B)*(((C*D)*E)*F))+(C*D*G))` |
|  ✔ Passed               | 00:00:00.0001348 | `Check Expressions "((A*B)+((A*C)-A)*D)+E"         ` |
|  ⚠ Inconclusive        | 00:00:00.0007375 | `Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"` |
|  ✔ Passed               | 00:00:00.0002032 | `Check Expressions "(((A/B)*((C*D)*E)*F)*G)+H"     ` |
|  ✔ Passed               | 00:00:00.0001656 | `Check Expressions "((A/B)*(((C*D)*E)*F))+G"       ` |
|  ✔ Passed               | 00:00:00.0001212 | `Check Expressions "((A/B)*((C*D)*E))+F"           ` |
|  ✔ Passed               | 00:00:00.0000805 | `Check Expressions "(A/(A+B))"                     ` |
|  ✔ Passed               | 00:00:00.0023861 | `VerifyOptimizerForComplexExpressions (A!)         ` |

### OptimizerTests_WithExceptions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0023610 | `OptimizerTests_WithExceptions                     ` |
|  ✔ Passed               | 00:00:00.0013535 | `OptimizerTests_WithExceptions (B/0)               ` |
|  ✔ Passed               | 00:00:00.0007768 | `OptimizerTests_WithExceptions (B%0)               ` |

### PoorlyFormedExpressions
 Location: binarydatadecoders.expressioncalculator.tests.dll
| Result                   | Duration         | Test Name                                          |
| :----------------------- | ---------------: | :--------------------------------------------------- |
|  ✔ Passed               | 00:00:00.0121909 | `PoorlyFormedExpressions                           ` |
|  ✔ Passed               | 00:00:00.0050064 | `PoorlyFormedExpressions (-A!)                     ` |
|  ✔ Passed               | 00:00:00.0010787 | `PoorlyFormedExpressions (B/*1)                    ` |
|  ✔ Passed               | 00:00:00.0008444 | `PoorlyFormedExpressions (B**)                     ` |
|  ✔ Passed               | 00:00:00.0006296 | `PoorlyFormedExpressions (B**A)                    ` |
|  ✔ Passed               | 00:00:00.0004640 | `PoorlyFormedExpressions (B***A)                   ` |
|  ✔ Passed               | 00:00:00.0004387 | `PoorlyFormedExpressions (B*+*A)                   ` |
|  ✔ Passed               | 00:00:00.0005168 | `PoorlyFormedExpressions (B*-*A)                   ` |
|  ✔ Passed               | 00:00:00.0005296 | `PoorlyFormedExpressions ()                        ` |
|  ✔ Passed               | 00:00:00.0009804 | `PoorlyFormedExpressions (b)                       ` |
|  ✔ Passed               | 00:00:00.0010725 | `PoorlyFormedExpressions (b+1)                     ` |

