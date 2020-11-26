# ExpressionParserTests.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.ExpressionCalculator.Tests/Parser/ExpressionParserTests.cs

## Public Class - DecimalExpressionParserTests

### Attributes

 - TestClass

## Public Class - DoubleExpressionParserTests

### Attributes

 - TestClass

## Public Class - FloatExpressionParserTests

### Attributes

 - TestClass

## Public Class - Int8ExpressionParserTests

### Attributes

 - TestClass

### Members

#### Public Constructor - Int8ExpressionParserTests


## Public Class - Int16ExpressionParserTests

### Attributes

 - TestClass

### Members

#### Public Constructor - Int16ExpressionParserTests


## Public Class - Int32ExpressionParserTests

### Attributes

 - TestClass

### Members

#### Public Constructor - Int32ExpressionParserTests


## Public Class - Int64ExpressionParserTests

### Attributes

 - TestClass

### Members

#### Public Constructor - Int64ExpressionParserTests


## Public Class - UInt8ExpressionParserTests

### Attributes

 - TestClass

### Members

#### Public Constructor - UInt8ExpressionParserTests


## Public Class - UInt16ExpressionParserTests

### Attributes

 - TestClass

### Members

#### Public Constructor - UInt16ExpressionParserTests


## Public Class - UInt32ExpressionParserTests

### Attributes

 - TestClass

### Members

#### Public Constructor - UInt32ExpressionParserTests


## Public Class - UInt64ExpressionParserTests

### Attributes

 - TestClass

### Members

#### Public Constructor - UInt64ExpressionParserTests


## Public Class - ExpressionParserTests

### Members

#### Private ReadOnly Field - _skipDecimal

##### Summary

 * Type: 

#### Private ReadOnly Field - _skipNegative

##### Summary

 * Type: 

#### Private Static ReadOnly Field - _evaluator

##### Summary

 * Type: 

#### Constructor - ExpressionParserTests

#####  Parameters

 - bool skipDecimal = false 
 - bool skipNegative = false 

#### Public Property - TestContext

##### Summary

 * Type: TestContext 

#### Public Method - PoorlyFormedExpressions

##### Attributes

 - DataTestMethod
 - TestCategory
 - (
 - TestCategories
 - .
 - Unit
 - )
 - ExpectedException
 - (
 - typeof
 - (
 - ParseCanceledException
 - )
 - )
 - DataRow
 - (
 - "-A!"
 - )
 - DataRow
 - (
 - "B/*1"
 - )
 - DataRow
 - (
 - "B**"
 - )
 - DataRow
 - (
 - "B**A"
 - )
 - DataRow
 - (
 - "B***A"
 - )
 - DataRow
 - (
 - "B*+*A"
 - )
 - DataRow
 - (
 - "B*-*A"
 - )
 - DataRow
 - (
 - ""
 - )
 - DataRow
 - (
 - "b"
 - )
 - DataRow
 - (
 - "b+1"
 - )
 - TestTarget
 - (
 - typeof
 - (
 - ExpressionParser
 - <
 - 
 - >
 - )
 - ,
 - Member
 - =
 - nameof
 - (
 - ExpressionParser
 - <
 - double
 - >
 - .
 - Parse
 - )
 - )

#####  Parameters

 - string input 

#### Public Method - SimpleParserTests

##### Attributes

 - DataTestMethod
 - TestCategory
 - (
 - TestCategories
 - .
 - Unit
 - )
 - DataRow
 - (
 - "2+3*4^5%6/7-8"
 - ,
 - "2 + 3 * 4 ^ 5 % 6 / 7 - 8"
 - ,
 - DisplayName
 - =
 - "Parse all operators test"
 - )
 - DataRow
 - (
 - "A+B+1"
 - ,
 - "A + B + 1"
 - ,
 - DisplayName
 - =
 - "Simple test with variable"
 - )
 - DataRow
 - (
 - "Abc1"
 - ,
 - "Abc1"
 - ,
 - DisplayName
 - =
 - "Just variable"
 - )
 - DataRow
 - (
 - "1.34"
 - ,
 - "1.34"
 - ,
 - DisplayName
 - =
 - "Just decimal value"
 - )
 - DataRow
 - (
 - "A!"
 - ,
 - "A!"
 - ,
 - DisplayName
 - =
 - "Simple factorial"
 - )
 - DataRow
 - (
 - "-(A!)"
 - ,
 - "-(A!)"
 - ,
 - DisplayName
 - =
 - "Negative factorial"
 - )
 - DataRow
 - (
 - "((((((A-B-1*E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"
 - ,
 - "((((((A - B - 1 * E - 6) / C) + 0.999999) / 1000000) * 1000000) * ((D * E) * F) * G) + H"
 - ,
 - DisplayName
 - =
 - "Parse Complex Expression"
 - )
 - DataRow
 - (
 - "B*--A"
 - ,
 - "B * --A"
 - )
 - TestTarget
 - (
 - typeof
 - (
 - ExpressionParser
 - <
 - 
 - >
 - )
 - ,
 - Member
 - =
 - nameof
 - (
 - ExpressionParser
 - <
 - double
 - >
 - .
 - Parse
 - )
 - )

#####  Parameters

 - string input 
 - string result 

#### Public Method - OptimizerTests

##### Attributes

 - DataTestMethod
 - TestCategory
 - (
 - TestCategories
 - .
 - Unit
 - )
 - DataRow
 - (
 - "(A)"
 - ,
 - "A"
 - )
 - DataRow
 - (
 - "(A+(B))"
 - ,
 - "A + B"
 - )
 - DataRow
 - (
 - "B^1"
 - ,
 - "B"
 - )
 - DataRow
 - (
 - "B*1"
 - ,
 - "B"
 - )
 - DataRow
 - (
 - "1*B"
 - ,
 - "B"
 - )
 - DataRow
 - (
 - "B*-1"
 - ,
 - "-B"
 - )
 - DataRow
 - (
 - "-1*B"
 - ,
 - "-B"
 - )
 - DataRow
 - (
 - "B/1"
 - ,
 - "B"
 - )
 - DataRow
 - (
 - "B/-1"
 - ,
 - "-B"
 - )
 - DataRow
 - (
 - "B+0"
 - ,
 - "B"
 - )
 - DataRow
 - (
 - "0+B"
 - ,
 - "B"
 - )
 - DataRow
 - (
 - "B-0"
 - ,
 - "B"
 - )
 - DataRow
 - (
 - "0-B"
 - ,
 - "-B"
 - )
 - DataRow
 - (
 - "2+3*4^5%6/7-8"
 - ,
 - "-6"
 - )
 - DataRow
 - (
 - "2+3"
 - ,
 - "5"
 - )
 - DataRow
 - (
 - "B/B"
 - ,
 - "1"
 - )
 - DataRow
 - (
 - "B%B"
 - ,
 - "0"
 - )
 - DataRow
 - (
 - "B^0"
 - ,
 - "1"
 - )
 - DataRow
 - (
 - "0^B"
 - ,
 - "0"
 - )
 - DataRow
 - (
 - "0*B"
 - ,
 - "0"
 - )
 - DataRow
 - (
 - "B*0"
 - ,
 - "0"
 - )
 - DataRow
 - (
 - "0/B"
 - ,
 - "0"
 - )
 - DataRow
 - (
 - "0%B"
 - ,
 - "0"
 - )
 - DataRow
 - (
 - "B%1"
 - ,
 - "0"
 - )
 - DataRow
 - (
 - "B%-1"
 - ,
 - "0"
 - )
 - DataRow
 - (
 - "-(B)"
 - ,
 - "-B"
 - )
 - DataRow
 - (
 - "-(3)"
 - ,
 - "-3"
 - )
 - DataRow
 - (
 - "-3"
 - ,
 - "-3"
 - )
 - DataRow
 - (
 - "--B"
 - ,
 - "B"
 - )
 - DataRow
 - (
 - "---B"
 - ,
 - "-B"
 - )
 - DataRow
 - (
 - "-1*(A*B)"
 - ,
 - "-(A * B)"
 - )
 - DataRow
 - (
 - "A!"
 - ,
 - "A!"
 - )
 - DataRow
 - (
 - "(A)!"
 - ,
 - "A!"
 - )
 - DataRow
 - (
 - "3!!"
 - ,
 - "720"
 - )
 - DataRow
 - (
 - "2!!!"
 - ,
 - "2"
 - )
 - DataRow
 - (
 - "N!!"
 - ,
 - "N!!"
 - )
 - DataRow
 - (
 - "N!!!"
 - ,
 - "N!!!"
 - )
 - TestTarget
 - (
 - typeof
 - (
 - ExpressionBaseExtensions
 - )
 - ,
 - Member
 - =
 - nameof
 - (
 - ExpressionBaseExtensions
 - .
 - Optimize
 - )
 - )

#####  Parameters

 - string input 
 - string result 

#### Public Method - OptimizerTests_WithExceptions

##### Attributes

 - DataTestMethod
 - TestCategory
 - (
 - TestCategories
 - .
 - Unit
 - )
 - DataRow
 - (
 - "B/0"
 - )
 - DataRow
 - (
 - "B%0"
 - )
 - ExpectedException
 - (
 - typeof
 - (
 - DivideByZeroException
 - )
 - )
 - TestTarget
 - (
 - typeof
 - (
 - ExpressionBaseExtensions
 - )
 - ,
 - Member
 - =
 - nameof
 - (
 - ExpressionBaseExtensions
 - .
 - Optimize
 - )
 - )

#####  Parameters

 - string input 

#### Public Method - GetDistinctVariablesTests

##### Attributes

 - DataTestMethod
 - TestCategory
 - (
 - TestCategories
 - .
 - Unit
 - )
 - DataRow
 - (
 - "A+B+C"
 - ,
 - "A, B, C"
 - )
 - DataRow
 - (
 - "A+B+B"
 - ,
 - "A, B"
 - )
 - DataRow
 - (
 - "Abc+XyW1"
 - ,
 - "Abc, XyW1"
 - )
 - TestTarget
 - (
 - typeof
 - (
 - ExpressionBaseExtensions
 - )
 - ,
 - Member
 - =
 - nameof
 - (
 - ExpressionBaseExtensions
 - .
 - GetDistinctVariableNames
 - )
 - )

#####  Parameters

 - string input 
 - string result 

#### Public Method - VerifyOptimizerForComplexExpressions

##### Attributes

 - DataTestMethod
 - TestCategory
 - (
 - TestCategories
 - .
 - Unit
 - )
 - DataRow
 - (
 - "A"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"A\""
 - )
 - DataRow
 - (
 - "A*1"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"A*1\""
 - )
 - DataRow
 - (
 - "(A*B)+C"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(A*B)+C\""
 - )
 - DataRow
 - (
 - "(A*B)"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(A*B)\""
 - )
 - DataRow
 - (
 - "(A-B)/A"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(A-B)/A\""
 - )
 - DataRow
 - (
 - "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))\""
 - )
 - DataRow
 - (
 - "((A+B+((C*D)+E))*F)+G+((D/H)*I)+J"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"((A+B+((C*D)+E))*F)+G+((D/H)*I)+J\""
 - )
 - DataRow
 - (
 - "A*(B/C)+D"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"A*(B/C)+D\""
 - )
 - DataRow
 - (
 - "A*B+C"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"A*B+C\""
 - )
 - DataRow
 - (
 - "(((A-(B*C))/D)*E)+F"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(((A-(B*C))/D)*E)+F\""
 - )
 - DataRow
 - (
 - "(A/B)-(C+D+E+F)"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(A/B)-(C+D+E+F)\""
 - )
 - DataRow
 - (
 - "((A*B)*C)+D"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"((A*B)*C)+D\""
 - )
 - DataRow
 - (
 - "(((A*B)*C)*D)+E"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(((A*B)*C)*D)+E\""
 - )
 - DataRow
 - (
 - "(((A/B)+(-1*C))*(D*E)*F)+G"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(((A/B)+(-1*C))*(D*E)*F)+G\""
 - )
 - DataRow
 - (
 - "(A*B*(C/D))+E"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(A*B*(C/D))+E\""
 - )
 - DataRow
 - (
 - "(A*(B/C)+D)"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(A*(B/C)+D)\""
 - )
 - DataRow
 - (
 - "A+B"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"A+B\""
 - )
 - DataRow
 - (
 - "((A/B)*(C*D)*E)+F"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"((A/B)*(C*D)*E)+F\""
 - )
 - DataRow
 - (
 - "((A+((B*C)+D))*E)+F+(C*G)+H"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"((A+((B*C)+D))*E)+F+(C*G)+H\""
 - )
 - DataRow
 - (
 - "(A+((B*C)+D))*E+F+(A+((B*C)+D))*G+H"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(A+((B*C)+D))*E+F+(A+((B*C)+D))*G+H\""
 - )
 - DataRow
 - (
 - "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))\""
 - )
 - DataRow
 - (
 - "((A*B)+C)+((D*B)+E)"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"((A*B)+C)+((D*B)+E)\""
 - )
 - DataRow
 - (
 - "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)\""
 - )
 - DataRow
 - (
 - "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))\""
 - )
 - DataRow
 - (
 - "(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)\""
 - )
 - DataRow
 - (
 - "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)\""
 - )
 - DataRow
 - (
 - "((A*B)+C)+(-1*A)"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"((A*B)+C)+(-1*A)\""
 - )
 - DataRow
 - (
 - "(((A+(-1*B))+((C*D)+E))*F)+G+(D*H)+I"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(((A+(-1*B))+((C*D)+E))*F)+G+(D*H)+I\""
 - )
 - DataRow
 - (
 - "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I\""
 - )
 - DataRow
 - (
 - "((A*(B+(-1*C)))+D)+((E*(B+(-1*C)))+F)"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"((A*(B+(-1*C)))+D)+((E*(B+(-1*C)))+F)\""
 - )
 - DataRow
 - (
 - "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))\""
 - )
 - DataRow
 - (
 - "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)\""
 - )
 - DataRow
 - (
 - "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L\""
 - )
 - DataRow
 - (
 - "(((A+(-1*B))*C)+D)+(B+(-1*A))"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(((A+(-1*B))*C)+D)+(B+(-1*A))\""
 - )
 - DataRow
 - (
 - "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))\""
 - )
 - DataRow
 - (
 - "((A+((B*C)+D))*E)+F+((C/G)*H)+I"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"((A+((B*C)+D))*E)+F+((C/G)*H)+I\""
 - )
 - DataRow
 - (
 - "(A+B)*C+D+(A+B)*E+F"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(A+B)*C+D+(A+B)*E+F\""
 - )
 - DataRow
 - (
 - "A*B"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"A*B\""
 - )
 - DataRow
 - (
 - "((A+((-1*B)*(C/D)))*(E/C))+(-1*F)+G"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"((A+((-1*B)*(C/D)))*(E/C))+(-1*F)+G\""
 - )
 - DataRow
 - (
 - "((A/(1-B))*C)+D"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"((A/(1-B))*C)+D\""
 - )
 - DataRow
 - (
 - "(((A-(B*C))/(1-D))*E)+F"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(((A-(B*C))/(1-D))*E)+F\""
 - )
 - DataRow
 - (
 - "(A*(1+(-1*B))+C)*D+E"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(A*(1+(-1*B))+C)*D+E\""
 - )
 - DataRow
 - (
 - "(A+B)*C+D"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(A+B)*C+D\""
 - )
 - DataRow
 - (
 - "(((A/B)*C*D)*E*F)+G"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(((A/B)*C*D)*E*F)+G\""
 - )
 - DataRow
 - (
 - "((A-B)*C)+D"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"((A-B)*C)+D\""
 - )
 - DataRow
 - (
 - "((A/B)*C)+D"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"((A/B)*C)+D\""
 - )
 - DataRow
 - (
 - "((((A*B)+C)/D)*E)+F"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"((((A*B)+C)/D)*E)+F\""
 - )
 - DataRow
 - (
 - "((A/B)*C*D*E)+F"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"((A/B)*C*D*E)+F\""
 - )
 - DataRow
 - (
 - "(A*B*C)+D"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(A*B*C)+D\""
 - )
 - DataRow
 - (
 - "(((A*B)+C)*D)+E"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(((A*B)+C)*D)+E\""
 - )
 - DataRow
 - (
 - "(((A/B)*C*D)*E)+F"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(((A/B)*C*D)*E)+F\""
 - )
 - DataRow
 - (
 - "(A*1)"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(A*1)\""
 - )
 - DataRow
 - (
 - "(((A/B)+(-1*C))*D*E*F)+G"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(((A/B)+(-1*C))*D*E*F)+G\""
 - )
 - DataRow
 - (
 - "((A*B)+C)+(D*E*F)"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"((A*B)+C)+(D*E*F)\""
 - )
 - DataRow
 - (
 - "((A/(1+(-1*(B+C))))*D)+E"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"((A/(1+(-1*(B+C))))*D)+E\""
 - )
 - DataRow
 - (
 - "((A-(B*C))*D)+E"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"((A-(B*C))*D)+E\""
 - )
 - DataRow
 - (
 - "(((A+(-1*B))/C)*(D*E)*F)+G"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(((A+(-1*B))/C)*(D*E)*F)+G\""
 - )
 - DataRow
 - (
 - "((A/B)*((C*D)*E)*F)+G"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"((A/B)*((C*D)*E)*F)+G\""
 - )
 - DataRow
 - (
 - "((((A/B)*C)+D)*((E*F)*G))+H"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"((((A/B)*C)+D)*((E*F)*G))+H\""
 - )
 - DataRow
 - (
 - "(((A/B)+(-1*C))*((D*E)*F)*G)+H"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(((A/B)+(-1*C))*((D*E)*F)*G)+H\""
 - )
 - DataRow
 - (
 - "(((A+(-1*B))/C)*((D*E)*F)*G)+H"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(((A+(-1*B))/C)*((D*E)*F)*G)+H\""
 - )
 - DataRow
 - (
 - "(((A/B)*(((C*D)*E)*F))+(C*D*G))+H"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(((A/B)*(((C*D)*E)*F))+(C*D*G))+H\""
 - )
 - DataRow
 - (
 - "((A*B)+((A*C)-A)*D)+E"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"((A*B)+((A*C)-A)*D)+E\""
 - )
 - DataRow
 - (
 - "((((((A-B-1*E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H\""
 - )
 - DataRow
 - (
 - "(((A/B)*((C*D)*E)*F)*G)+H"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(((A/B)*((C*D)*E)*F)*G)+H\""
 - )
 - DataRow
 - (
 - "((A/B)*(((C*D)*E)*F))+G"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"((A/B)*(((C*D)*E)*F))+G\""
 - )
 - DataRow
 - (
 - "((A/B)*((C*D)*E))+F"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"((A/B)*((C*D)*E))+F\""
 - )
 - DataRow
 - (
 - "(A/(A+B))"
 - ,
 - DisplayName
 - =
 - "Check Expressions \"(A/(A+B))\""
 - )
 - DataRow
 - (
 - "A!"
 - )
 - TestTarget
 - (
 - typeof
 - (
 - ExpressionBaseExtensions
 - )
 - ,
 - Member
 - =
 - nameof
 - (
 - ExpressionBaseExtensions
 - .
 - Optimize
 - )
 - )

#####  Parameters

 - string input 

#### Public Method - TestBuilder

##### Attributes

 - TestMethod
 - Ignore


