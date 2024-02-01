# BinaryDataDecoders.ExpressionCalculator.Tests.Parser.UInt64ExpressionParserTests

## Check Expressions "(((A-(B*C))/D)*E)+F"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (((A-(B*C))/D)*E)+F
As Parsed: (((A - (B * C)) / D) * E) + F
As Optimized: (A - (B * C)) / D * E + F
Variables: (A, 18446744073709542510), (B, 18446744073709548316), (C, 6418), (D, 3184), (E, 18446744073709543217), (F, 18446744073709547297)
Parsed Result: 18446744073653710745
Optimized Result: 18446744073653710745
```

## Check Expressions "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))
As Parsed: (((((A * B) + C) + ((D * E) + F)) * G) + H) + (-1 * ((A + (-1 * (A * B))) + C))
```

## Check Expressions "(A+((B*C)+D))*E+F+(A+((B*C)+D))*G+H"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (A+((B*C)+D))*E+F+(A+((B*C)+D))*G+H
As Parsed: (A + ((B * C) + D)) * E + F + (A + ((B * C) + D)) * G + H
As Optimized: (A + ((B * C) + D)) * E + F + (A + ((B * C) + D)) * G + H
Variables: (A, 8202), (B, 9466), (C, 18446744073709542967), (D, 350), (E, 18446744073709544210), (F, 251), (G, 18446744073709543079), (H, 18446744073709542825)
Parsed Result: 1305139919186
Optimized Result: 1305139919186
```

## OptimizerTests (0^B,0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: 0^B
As Parsed: 0 ^ B
As Optimized: 0
```

## Check Expressions "((A*B)+((A*C)-A)*D)+E"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: ((A*B)+((A*C)-A)*D)+E
As Parsed: ((A * B) + ((A * C) - A) * D) + E
As Optimized: A * B + ((A * C) - A) * D + E
Variables: (A, 18446744073709549932), (B, 3391), (C, 4305), (D, 18446744073709543259), (E, 4221)
Parsed Result: 60565294929
Optimized Result: 60565294929
```

## OptimizerTests (0+B,B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: 0+B
As Parsed: 0 + B
As Optimized: B
```

## OptimizerTests (B%-1,0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: B%-1
As Parsed: B % -1
```

## Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

## PoorlyFormedExpressions (-A!)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: -A!
The parse operation was cancelled.
Antlr4.Runtime.Misc.ParseCanceledException
```

## Check Expressions "(A*B*C)+D"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (A*B*C)+D
As Parsed: (A * B * C) + D
As Optimized: A * B * C + D
Variables: (A, 8628), (B, 18446744073709544430), (C, 6108), (D, 9514)
Parsed Result: 18446743695008625866
Optimized Result: 18446743695008625866
```

## OptimizerTests (B%B,0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: B%B
As Parsed: B % B
As Optimized: 0
```

## PoorlyFormedExpressions (b)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: b
The parse operation was cancelled.
Antlr4.Runtime.Misc.ParseCanceledException
```

#### Error Out

```
line 1:0 token recognition error at: 'b'
line 1:1 no viable alternative at input '<EOF>'
```

## Check Expressions "(A*(1+(-1*B))+C)*D+E"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (A*(1+(-1*B))+C)*D+E
As Parsed: (A * (1 + (-1 * B)) + C) * D + E
```

## Check Expressions "((A*B)+C)+((D*B)+E)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: ((A*B)+C)+((D*B)+E)
As Parsed: ((A * B) + C) + ((D * B) + E)
As Optimized: A * B + C + D * B + E
Variables: (A, 5276), (B, 18446744073709542838), (C, 18446744073709551104), (D, 18446744073709546467), (E, 18446744073709542458)
Parsed Result: 18446744073708427140
Optimized Result: 18446744073708427140
```

## Check Expressions "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)
As Parsed: (A * ((B + (-1 * C)) + ((D * E) + F)) + G) + (H * ((B + (-1 * C)) + ((D * E) + F) + (A * ((B + (-1 * C)) + ((D * E) + F)) + G)) + I)
```

## Parse Complex Expression

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

## OptimizerTests (B*0,0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: B*0
As Parsed: B * 0
As Optimized: 0
```

## Check Expressions "(((A+(-1*B))+((C*D)+E))*F)+G+(D*H)+I"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (((A+(-1*B))+((C*D)+E))*F)+G+(D*H)+I
As Parsed: (((A + (-1 * B)) + ((C * D) + E)) * F) + G + (D * H) + I
```

## OptimizerTests (B^1,B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: B^1
As Parsed: B ^ 1
As Optimized: B
```

## OptimizerTests (2+3*4^5%6/7-8,-6)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: 2+3*4^5%6/7-8
As Parsed: 2 + 3 * 4 ^ 5 % 6 / 7 - 8
As Optimized: 18446744073709551610
```

## Check Expressions "(((A/B)*(((C*D)*E)*F))+(C*D*G))+H"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (((A/B)*(((C*D)*E)*F))+(C*D*G))+H
As Parsed: (((A / B) * (((C * D) * E) * F)) + (C * D * G)) + H
As Optimized: A / B * C * D * E * F + C * D * G + H
Variables: (A, 4921), (B, 18446744073709547694), (C, 8744), (D, 18446744073709547615), (E, 18446744073709542877), (F, 18446744073709544434), (G, 8782), (H, 9397)
Parsed Result: 18446743766473539205
Optimized Result: 18446743766473539205
```

## Check Expressions "((A/B)*(((C*D)*E)*F))+G"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: ((A/B)*(((C*D)*E)*F))+G
As Parsed: ((A / B) * (((C * D) * E) * F)) + G
As Optimized: A / B * C * D * E * F + G
Variables: (A, 18446744073709551271), (B, 18446744073709546839), (C, 18446744073709544380), (D, 8904), (E, 9130), (F, 6609), (G, 8098)
Parsed Result: 18442856396139611234
Optimized Result: 18442856396139611234
```

## OptimizerTests_WithExceptions (B/0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: B/0
As Parsed: B / 0
```

## OptimizerTests (B^0,1)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: B^0
As Parsed: B ^ 0
As Optimized: 1
```

## Just variable

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: Abc1
As Parsed: Abc1
```

## Check Expressions "(A*B)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (A*B)
As Parsed: (A * B)
As Optimized: A * B
Variables: (A, 2998), (B, 6242)
Parsed Result: 18713516
Optimized Result: 18713516
```

## OptimizerTests (---B,-B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: ---B
As Parsed: ---B
As Optimized: -B
```

## OptimizerTests (0*B,0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: 0*B
As Parsed: 0 * B
As Optimized: 0
```

## Check Expressions "((A+((-1*B)*(C/D)))*(E/C))+(-1*F)+G"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: ((A+((-1*B)*(C/D)))*(E/C))+(-1*F)+G
As Parsed: ((A + ((-1 * B) * (C / D))) * (E / C)) + (-1 * F) + G
```

## Check Expressions "((A-(B*C))*D)+E"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: ((A-(B*C))*D)+E
As Parsed: ((A - (B * C)) * D) + E
As Optimized: (A - (B * C)) * D + E
Variables: (A, 18446744073709550581), (B, 6912), (C, 18446744073709547888), (D, 8614), (E, 6800)
Parsed Result: 221956092014
Optimized Result: 221956092014
```

## Check Expressions "(((A-(B*C))/(1-D))*E)+F"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (((A-(B*C))/(1-D))*E)+F
As Parsed: (((A - (B * C)) / (1 - D)) * E) + F
As Optimized: (A - (B * C)) / (1 - D) * E + F
Variables: (A, 6385), (B, 3764), (C, 5076), (D, 18446744073709551568), (E, 18446744073709544739), (F, 18446744073709543602)
Parsed Result: 12046853275307224050
Optimized Result: 12046853275307224050
```

## OptimizerTests (2+3,5)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: 2+3
As Parsed: 2 + 3
As Optimized: 5
```

## Check Expressions "((A*(B+(-1*C)))+D)+((E*(B+(-1*C)))+F)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: ((A*(B+(-1*C)))+D)+((E*(B+(-1*C)))+F)
As Parsed: ((A * (B + (-1 * C))) + D) + ((E * (B + (-1 * C))) + F)
```

## Check Expressions "(((A*B)+C)*D)+E"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (((A*B)+C)*D)+E
As Parsed: (((A * B) + C) * D) + E
As Optimized: ((A * B) + C) * D + E
Variables: (A, 18446744073709547110), (B, 18446744073709547549), (C, 829), (D, 1148), (E, 18446744073709545482)
Parsed Result: 21039081054
Optimized Result: 21039081054
```

## GetDistinctVariablesTests (A+B+C,A, B, C)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::GetDistinctVariableNames
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: A+B+C
As Parsed: A + B + C
Variables: A, B, C
```

## OptimizerTests (B/B,1)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: B/B
As Parsed: B / B
As Optimized: 1
```

## Check Expressions "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))
As Parsed: (A * (((B * C) + D) + ((E * ((F * G) + H)) + I)) + J) + (-1 * (B + (-1 * ((B * C) + D))))
```

## Check Expressions "A"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: A
As Parsed: A
As Optimized: A
Variables: (A, 18446744073709547069)
Parsed Result: 18446744073709547069
Optimized Result: 18446744073709547069
```

## PoorlyFormedExpressions (B*-*A)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: B*-*A
The parse operation was cancelled.
Antlr4.Runtime.Misc.ParseCanceledException
```

#### Error Out

```
line 1:3 no viable alternative at input '*'
```

## PoorlyFormedExpressions (b+1)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: b+1
The parse operation was cancelled.
Antlr4.Runtime.Misc.ParseCanceledException
```

#### Error Out

```
line 1:0 token recognition error at: 'b'
line 1:1 no viable alternative at input '+'
```

## OptimizerTests_WithExceptions (B%0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: B%0
As Parsed: B % 0
```

## PoorlyFormedExpressions (B/*1)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: B/*1
The parse operation was cancelled.
Antlr4.Runtime.Misc.ParseCanceledException
```

#### Error Out

```
line 1:2 no viable alternative at input '*'
```

## Check Expressions "(((A*B)*C)*D)+E"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (((A*B)*C)*D)+E
As Parsed: (((A * B) * C) * D) + E
As Optimized: A * B * C * D + E
Variables: (A, 18446744073709542723), (B, 18446744073709549414), (C, 2230), (D, 1957), (E, 497)
Parsed Result: 85459686566957
Optimized Result: 85459686566957
```

## OptimizerTests (-1*B,-B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: -1*B
As Parsed: -1 * B
```

## PoorlyFormedExpressions (B**A)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: B**A
The parse operation was cancelled.
Antlr4.Runtime.Misc.ParseCanceledException
```

#### Error Out

```
line 1:2 no viable alternative at input '*'
```

## Check Expressions "(((A+(-1*B))/C)*((D*E)*F)*G)+H"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (((A+(-1*B))/C)*((D*E)*F)*G)+H
As Parsed: (((A + (-1 * B)) / C) * ((D * E) * F) * G) + H
```

## Check Expressions "(((A/B)+(-1*C))*(D*E)*F)+G"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (((A/B)+(-1*C))*(D*E)*F)+G
As Parsed: (((A / B) + (-1 * C)) * (D * E) * F) + G
```

## Check Expressions "((A/B)*C*D*E)+F"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: ((A/B)*C*D*E)+F
As Parsed: ((A / B) * C * D * E) + F
As Optimized: A / B * C * D * E + F
Variables: (A, 9726), (B, 18446744073709544130), (C, 18446744073709542983), (D, 891), (E, 4598), (F, 9771)
Parsed Result: 9771
Optimized Result: 9771
```

## PoorlyFormedExpressions (B***A)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: B***A
The parse operation was cancelled.
Antlr4.Runtime.Misc.ParseCanceledException
```

#### Error Out

```
line 1:2 no viable alternative at input '*'
```

## OptimizerTests (-3,-3)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: -3
As Parsed: -3
```

## Check Expressions "(A*B*(C/D))+E"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (A*B*(C/D))+E
As Parsed: (A * B * (C / D)) + E
As Optimized: A * B * C / D + E
Variables: (A, 18446744073709547752), (B, 18446744073709548913), (C, 1369), (D, 1609), (E, 18446744073709550107)
Parsed Result: 18446744073709550107
Optimized Result: 18446744073709550107
```

## Check Expressions "(((A/B)*((C*D)*E)*F)*G)+H"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (((A/B)*((C*D)*E)*F)*G)+H
As Parsed: (((A / B) * ((C * D) * E) * F) * G) + H
As Optimized: A / B * C * D * E * F * G + H
Variables: (A, 258), (B, 18446744073709545169), (C, 9609), (D, 18446744073709550385), (E, 8238), (F, 7749), (G, 18446744073709545486), (H, 18446744073709551264)
Parsed Result: 18446744073709551264
Optimized Result: 18446744073709551264
```

## OptimizerTests ((A+(B)),A + B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (A+(B))
As Parsed: (A + (B))
As Optimized: A + B
```

## Check Expressions "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))
As Parsed: (A * ((B + (-1 * C)) + ((D * (B + (-1 * C))) + E) + ((F * G) + H)) + ((D * (B + (-1 * C))) + E))
```

## OptimizerTests (0%B,0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: 0%B
As Parsed: 0 % B
As Optimized: 0
```

## Check Expressions "(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)
As Parsed: (A * (B + ((C * D) + E)) + F) + (G * (B + ((C * D) + E) + (A * (B + ((C * D) + E)) + F)) + H)
As Optimized: A * (B + ((C * D) + E)) + F + G * (B + ((C * D) + E) + (A * (B + ((C * D) + E)) + F)) + H
Variables: (A, 18446744073709546575), (B, 18446744073709549775), (C, 8331), (D, 18446744073709543911), (E, 18446744073709544797), (F, 7498), (G, 2233), (H, 18446744073709545991)
Parsed Result: 722839902474322
Optimized Result: 722839902474322
```

## OptimizerTests (--B,B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: --B
As Parsed: --B
As Optimized: B
```

## OptimizerTests (N!!,N!!)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: N!!
As Parsed: N!!
As Optimized: N!!
```

## OptimizerTests (0-B,-B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: 0-B
As Parsed: 0 - B
As Optimized: -B
```

## Simple test with variable

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: A+B+1
As Parsed: A + B + 1
```

## Check Expressions "(((A/B)*C*D)*E*F)+G"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (((A/B)*C*D)*E*F)+G
As Parsed: (((A / B) * C * D) * E * F) + G
As Optimized: A / B * C * D * E * F + G
Variables: (A, 18446744073709545214), (B, 8884), (C, 18446744073709545305), (D, 8207), (E, 18446744073709550517), (F, 18446744073709546787), (G, 5479)
Parsed Result: 4678341114174659424
Optimized Result: 4678341114174659424
```

## Check Expressions "((A/(1-B))*C)+D"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: ((A/(1-B))*C)+D
As Parsed: ((A / (1 - B)) * C) + D
As Optimized: A / (1 - B) * C + D
Variables: (A, 18446744073709547205), (B, 18446744073709546242), (C, 18446744073709550066), (D, 18446744073709551204)
Parsed Result: 13127217875709589354
Optimized Result: 13127217875709589354
```

## OptimizerTests (B*1,B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: B*1
As Parsed: B * 1
As Optimized: B
```

## OptimizerTests (0/B,0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: 0/B
As Parsed: 0 / B
As Optimized: 0
```

## Check Expressions "((A-B)*C)+D"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: ((A-B)*C)+D
As Parsed: ((A - B) * C) + D
As Optimized: (A - B) * C + D
Variables: (A, 18446744073709541834), (B, 18446744073709546463), (C, 18446744073709546263), (D, 18446744073709546785)
Parsed Result: 24774206
Optimized Result: 24774206
```

## OptimizerTests (-1*(A*B),-(A * B))

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: -1*(A*B)
As Parsed: -1 * (A * B)
```

## OptimizerTests (B*-1,-B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: B*-1
As Parsed: B * -1
```

## OptimizerTests (B/-1,-B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: B/-1
As Parsed: B / -1
```

## Check Expressions "((A/B)*((C*D)*E)*F)+G"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: ((A/B)*((C*D)*E)*F)+G
As Parsed: ((A / B) * ((C * D) * E) * F) + G
As Optimized: A / B * C * D * E * F + G
Variables: (A, 1505), (B, 18446744073709547675), (C, 18446744073709548329), (D, 18446744073709550694), (E, 18446744073709549314), (F, 18446744073709550388), (G, 6987)
Parsed Result: 6987
Optimized Result: 6987
```

## Check Expressions "A*(B/C)+D"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: A*(B/C)+D
As Parsed: A * (B / C) + D
As Optimized: A * B / C + D
Variables: (A, 18446744073709544698), (B, 6395), (C, 2130), (D, 18446744073709550356)
Parsed Result: 18446744073709529602
Optimized Result: 18446744073709529602
```

## Check Expressions "A*B"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: A*B
As Parsed: A * B
As Optimized: A * B
Variables: (A, 6647), (B, 18446744073709549373)
Parsed Result: 18446744073694642395
Optimized Result: 18446744073694642395
```

## Check Expressions "(A*(B/C)+D)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (A*(B/C)+D)
As Parsed: (A * (B / C) + D)
As Optimized: A * B / C + D
Variables: (A, 18446744073709542058), (B, 254), (C, 18446744073709547371), (D, 18446744073709549988)
Parsed Result: 18446744073709549988
Optimized Result: 18446744073709549988
```

## OptimizerTests (A!,A!)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: A!
As Parsed: A!
As Optimized: A!
```

## Check Expressions "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))
As Parsed: (A * ((((B + (-1 * C)) * D) + E) + ((F * ((G * H) + I)) + J)) + K) + (-1 * ((B + (-1 * C)) + (-1 * (((B + (-1 * C)) * D) + E))))
```

## Check Expressions "((((A*B)+C)/D)*E)+F"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: ((((A*B)+C)/D)*E)+F
As Parsed: ((((A * B) + C) / D) * E) + F
As Optimized: ((A * B) + C) / D * E + F
Variables: (A, 18446744073709549128), (B, 1179), (C, 8809), (D, 18446744073709550967), (E, 3788), (F, 18446744073709547764)
Parsed Result: 18446744073709547764
Optimized Result: 18446744073709547764
```

## Check Expressions "A*B+C"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: A*B+C
As Parsed: A * B + C
As Optimized: A * B + C
Variables: (A, 5623), (B, 18446744073709551199), (C, 3048)
Parsed Result: 18446744073707209873
Optimized Result: 18446744073707209873
```

## Simple factorial

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: A!
As Parsed: A!
```

## Check Expressions "((A*B)+C)+(D*E*F)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: ((A*B)+C)+(D*E*F)
As Parsed: ((A * B) + C) + (D * E * F)
As Optimized: A * B + C + D * E * F
Variables: (A, 18446744073709546882), (B, 18446744073709547693), (C, 18446744073709545245), (D, 18446744073709549782), (E, 3620), (F, 18446744073709543476)
Parsed Result: 54060676311
Optimized Result: 54060676311
```

## Check Expressions "((A+((B*C)+D))*E)+F+(C*G)+H"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: ((A+((B*C)+D))*E)+F+(C*G)+H
As Parsed: ((A + ((B * C) + D)) * E) + F + (C * G) + H
As Optimized: (A + ((B * C) + D)) * E + F + C * G + H
Variables: (A, 5318), (B, 18446744073709548897), (C, 18446744073709548988), (D, 18446744073709543578), (E, 18446744073709541835), (F, 9665), (G, 1755), (H, 975)
Parsed Result: 18446744003841105944
Optimized Result: 18446744003841105944
```

## OptimizerTests (1*B,B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: 1*B
As Parsed: 1 * B
As Optimized: B
```

## Check Expressions "((A/B)*((C*D)*E))+F"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: ((A/B)*((C*D)*E))+F
As Parsed: ((A / B) * ((C * D) * E)) + F
As Optimized: A / B * C * D * E + F
Variables: (A, 18446744073709545025), (B, 18446744073709549962), (C, 7739), (D, 18446744073709548949), (E, 18446744073709544512), (F, 9051)
Parsed Result: 9051
Optimized Result: 9051
```

## Check Expressions "(A/B)-(C+D+E+F)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (A/B)-(C+D+E+F)
As Parsed: (A / B) - (C + D + E + F)
As Optimized: A / B - C + D + E + F
Variables: (A, 18446744073709550556), (B, 1208), (C, 18446744073709545965), (D, 8507), (E, 8050), (F, 18446744073709543218)
Parsed Result: 15270483504723941
Optimized Result: 15270483504723941
```

## OptimizerTests (B+0,B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: B+0
As Parsed: B + 0
As Optimized: B
```

## Check Expressions "(A-B)/A"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (A-B)/A
As Parsed: (A - B) / A
As Optimized: (A - B) / A
Variables: (A, 18446744073709543259), (B, 8375)
Parsed Result: 0
Optimized Result: 0
```

## Check Expressions "((A*B)*C)+D"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: ((A*B)*C)+D
As Parsed: ((A * B) * C) + D
As Optimized: A * B * C + D
Variables: (A, 2845), (B, 7027), (C, 18446744073709549162), (D, 6594)
Parsed Result: 18446744024649644200
Optimized Result: 18446744024649644200
```

## Check Expressions "A+B"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: A+B
As Parsed: A + B
As Optimized: A + B
Variables: (A, 18446744073709551087), (B, 1261)
Parsed Result: 732
Optimized Result: 732
```

## Check Expressions "(A+B)*C+D"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (A+B)*C+D
As Parsed: (A + B) * C + D
As Optimized: (A + B) * C + D
Variables: (A, 6755), (B, 1349), (C, 18446744073709542481), (D, 18446744073709546449)
Parsed Result: 18446744073635516409
Optimized Result: 18446744073635516409
```

## Check Expressions "((A*B)+C)+(-1*A)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: ((A*B)+C)+(-1*A)
As Parsed: ((A * B) + C) + (-1 * A)
```

## OptimizerTests (B-0,B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: B-0
As Parsed: B - 0
As Optimized: B
```

## Parse all operators test

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: 2+3*4^5%6/7-8
As Parsed: 2 + 3 * 4 ^ 5 % 6 / 7 - 8
```

## Check Expressions "(A*1)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (A*1)
As Parsed: (A * 1)
As Optimized: A
Variables: (A, 6387)
Parsed Result: 6387
Optimized Result: 6387
```

## Check Expressions "A*1"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: A*1
As Parsed: A * 1
As Optimized: A
Variables: (A, 18446744073709551184)
Parsed Result: 18446744073709551184
Optimized Result: 18446744073709551184
```

## Check Expressions "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)
As Parsed: (A * (((B * C) + D) + ((E * F) + G)) + H) + (-1 * (B + (-1 * ((B * C) + D)))) + (I * (((B * J) + K) + ((E * F) + G)) + L)
```

## OptimizerTests (N!!!,N!!!)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: N!!!
As Parsed: N!!!
As Optimized: N!!!
```

## Check Expressions "(((A+(-1*B))/C)*(D*E)*F)+G"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (((A+(-1*B))/C)*(D*E)*F)+G
As Parsed: (((A + (-1 * B)) / C) * (D * E) * F) + G
```

## OptimizerTests (-(3),-3)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: -(3)
As Parsed: -(3)
```

## Check Expressions "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: ((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I
As Parsed: ((A + (-1 * B)) + ((C * D) + E)) * F + G + ((A + (-1 * B)) + ((C * D) + E)) * H + I
```

## Just decimal value

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

## Check Expressions "(A+B)*C+D+(A+B)*E+F"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (A+B)*C+D+(A+B)*E+F
As Parsed: (A + B) * C + D + (A + B) * E + F
As Optimized: (A + B) * C + D + (A + B) * E + F
Variables: (A, 9251), (B, 18446744073709550830), (C, 3938), (D, 7192), (E, 18446744073709544158), (F, 285)
Parsed Result: 18446744073679762293
Optimized Result: 18446744073679762293
```

## Check Expressions "(((A/B)+(-1*C))*D*E*F)+G"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (((A/B)+(-1*C))*D*E*F)+G
As Parsed: (((A / B) + (-1 * C)) * D * E * F) + G
```

## OptimizerTests (3!!,720)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: 3!!
As Parsed: 3!!
As Optimized: 720
```

## OptimizerTests ((A),A)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (A)
As Parsed: (A)
As Optimized: A
```

## PoorlyFormedExpressions (B*+*A)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: B*+*A
The parse operation was cancelled.
Antlr4.Runtime.Misc.ParseCanceledException
```

#### Error Out

```
line 1:2 no viable alternative at input '+'
```

## Check Expressions "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: ((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))
As Parsed: ((A * (((B * C) + D) + (E * F))) + (-1 * (B * (1 + (-1 * C)) + D) + G))
```

## Check Expressions "(A/(A+B))"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (A/(A+B))
As Parsed: (A / (A + B))
As Optimized: A / (A + B)
Variables: (A, 18446744073709545447), (B, 4623)
Parsed Result: 0
Optimized Result: 0
```

## Check Expressions "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)
As Parsed: (A * (((B * C) + D) + ((E * F) + G))) + (-1 * (B + (-1 * ((B * C) + D)))) + (H * (((B * I) + J) + ((E * F) + G) + (A * (((B * C) + D) + ((E * F) + G))) + (-1 * (B + (-1 * ((B * C) + D))))) + K)
```

## OptimizerTests (2!!!,2)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: 2!!!
As Parsed: 2!!!
As Optimized: 2
```

## Negative factorial

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: -(A!)
As Parsed: -(A!)
```

## Check Expressions "((A+B+((C*D)+E))*F)+G+((D/H)*I)+J"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: ((A+B+((C*D)+E))*F)+G+((D/H)*I)+J
As Parsed: ((A + B + ((C * D) + E)) * F) + G + ((D / H) * I) + J
As Optimized: (A + B + ((C * D) + E)) * F + G + D / H * I + J
Variables: (A, 3485), (B, 18446744073709549433), (C, 6772), (D, 18446744073709550625), (E, 7207), (F, 18446744073709541623), (G, 18446744073709541706), (H, 18446744073709545279), (I, 9724), (J, 18446744073709541979)
Parsed Result: 66978502376
Optimized Result: 66978502376
```

## SimpleParserTests (B*--A,B * --A)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: B*--A
As Parsed: B * --A
```

## Check Expressions "((((A/B)*C)+D)*((E*F)*G))+H"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: ((((A/B)*C)+D)*((E*F)*G))+H
As Parsed: ((((A / B) * C) + D) * ((E * F) * G)) + H
As Optimized: (((A / B) * C) + D) * E * F * G + H
Variables: (A, 18446744073709544102), (B, 8932), (C, 18446744073709549513), (D, 18446744073709550200), (E, 18446744073709551433), (F, 4945), (G, 18446744073709548611), (H, 18446744073709544242)
Parsed Result: 5037132342754577058
Optimized Result: 5037132342754577058
```

## OptimizerTests ((A)!,A!)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (A)!
As Parsed: (A)!
As Optimized: A!
```

## Check Expressions "(((A/B)+(-1*C))*((D*E)*F)*G)+H"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (((A/B)+(-1*C))*((D*E)*F)*G)+H
As Parsed: (((A / B) + (-1 * C)) * ((D * E) * F) * G) + H
```

## Check Expressions "((A/(1+(-1*(B+C))))*D)+E"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: ((A/(1+(-1*(B+C))))*D)+E
As Parsed: ((A / (1 + (-1 * (B + C)))) * D) + E
```

## Check Expressions "((A/B)*C)+D"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: ((A/B)*C)+D
As Parsed: ((A / B) * C) + D
As Optimized: A / B * C + D
Variables: (A, 18446744073709543303), (B, 1453), (C, 7251), (D, 18446744073709549384)
Parsed Result: 18269005314568460354
Optimized Result: 18269005314568460354
```

## VerifyOptimizerForComplexExpressions (A!)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: A!
As Parsed: A!
As Optimized: A!
Variables: (A, 4)
Parsed Result: 24
Optimized Result: 24
```

## OptimizerTests (B%1,0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: B%1
As Parsed: B % 1
As Optimized: 0
```

## Check Expressions "((A+((B*C)+D))*E)+F+((C/G)*H)+I"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: ((A+((B*C)+D))*E)+F+((C/G)*H)+I
As Parsed: ((A + ((B * C) + D)) * E) + F + ((C / G) * H) + I
As Optimized: (A + ((B * C) + D)) * E + F + C / G * H + I
Variables: (A, 18446744073709544939), (B, 18446744073709548810), (C, 18446744073709551017), (D, 1355), (E, 18446744073709549705), (F, 2182), (G, 18446744073709547805), (H, 2354), (I, 18446744073709542440)
Parsed Result: 18446744070507719984
Optimized Result: 18446744070507719984
```

## Check Expressions "(A*B)+C"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (A*B)+C
As Parsed: (A * B) + C
As Optimized: A * B + C
Variables: (A, 18446744073709542385), (B, 18446744073709548167), (C, 18446744073709551512)
Parsed Result: 31837615
Optimized Result: 31837615
```

## PoorlyFormedExpressions (B**)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: B**
The parse operation was cancelled.
Antlr4.Runtime.Misc.ParseCanceledException
```

#### Error Out

```
line 1:2 no viable alternative at input '*'
```

## Check Expressions "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L
As Parsed: (A * ((B + (-1 * C)) * D + E + (F * G) + H)) + (-1 * (B + (-1 * C) + (-1 * ((B + (-1 * C)) * D + E)))) + I * ((B + (-1 * C)) * J + K + (F * G) + H + (A * ((((B + (-1 * C)) * D) + E) + (F * G) + H)) + (-1 * (B + (-1 * C) + (-1 * ((B + (-1 * C)) * D + E))))) + L
```

## OptimizerTests (B/1,B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: B/1
As Parsed: B / 1
As Optimized: B
```

## PoorlyFormedExpressions ()

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: 
The parse operation was cancelled.
Antlr4.Runtime.Misc.ParseCanceledException
```

#### Error Out

```
line 1:0 no viable alternative at input '<EOF>'
```

## OptimizerTests (-(B),-B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: -(B)
As Parsed: -(B)
As Optimized: -B
```

## Check Expressions "((A/B)*(C*D)*E)+F"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: ((A/B)*(C*D)*E)+F
As Parsed: ((A / B) * (C * D) * E) + F
As Optimized: A / B * C * D * E + F
Variables: (A, 3665), (B, 18446744073709544601), (C, 9599), (D, 18446744073709548266), (E, 18446744073709548784), (F, 18446744073709548096)
Parsed Result: 18446744073709548096
Optimized Result: 18446744073709548096
```

## Check Expressions "(((A+(-1*B))*C)+D)+(B+(-1*A))"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (((A+(-1*B))*C)+D)+(B+(-1*A))
As Parsed: (((A + (-1 * B)) * C) + D) + (B + (-1 * A))
```

## Check Expressions "(((A/B)*C*D)*E)+F"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.00

#### Standard Out

```
TestContext Messages:
Input: (((A/B)*C*D)*E)+F
As Parsed: (((A / B) * C * D) * E) + F
As Optimized: A / B * C * D * E + F
Variables: (A, 4697), (B, 3241), (C, 18446744073709543870), (D, 3586), (E, 18446744073709546533), (F, 18446744073709548709)
Parsed Result: 141191281041
Optimized Result: 141191281041
```

## Links

* [Back to Summary](../Summary.md)
* [Table of Contents](../../TOC.md)
