# BinaryDataDecoders.ExpressionCalculator.Tests.Parser.UInt8ExpressionParserTests

## Check Expressions "((A+B+((C*D)+E))*F)+G+((D/H)*I)+J"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 111), (B, 40), (C, 43), (D, 203), (E, 180), (F, 202), (G, 107), (H, 86), (I, 121), (J, 184)
Parsed Result: 253
Optimized Result: 253
```

## Check Expressions "(A-B)/A"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 223), (B, 98)
Parsed Result: 0
Optimized Result: 0
```

## Check Expressions "((A/(1+(-1*(B+C))))*D)+E"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Just decimal value

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

## Check Expressions "((A+((-1*B)*(C/D)))*(E/C))+(-1*F)+G"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "((A+((B*C)+D))*E)+F+(C*G)+H"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 37), (B, 230), (C, 237), (D, 242), (E, 0), (F, 42), (G, 249), (H, 90)
Parsed Result: 9
Optimized Result: 9
```

## Check Expressions "A*1"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 98)
Parsed Result: 98
Optimized Result: 98
```

## OptimizerTests (B*1,B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "((A-(B*C))*D)+E"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 141), (B, 118), (C, 222), (D, 67), (E, 204)
Parsed Result: 183
Optimized Result: 183
```

## OptimizerTests (0-B,-B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (B+0,B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(((A-(B*C))/D)*E)+F"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 179), (B, 130), (C, 231), (D, 61), (E, 12), (F, 231)
Parsed Result: 243
Optimized Result: 243
```

## Check Expressions "(A+B)*C+D+(A+B)*E+F"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 120), (B, 251), (C, 84), (D, 132), (E, 49), (F, 233)
Parsed Result: 44
Optimized Result: 44
```

## Check Expressions "(((A-(B*C))/(1-D))*E)+F"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 247), (B, 90), (C, 50), (D, 213), (E, 15), (F, 32)
Parsed Result: 62
Optimized Result: 62
```

## Check Expressions "(A*(B/C)+D)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 13), (B, 95), (C, 225), (D, 155)
Parsed Result: 155
Optimized Result: 155
```

## Check Expressions "(((A/B)*(((C*D)*E)*F))+(C*D*G))+H"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 137), (B, 87), (C, 248), (D, 54), (E, 60), (F, 109), (G, 241), (H, 239)
Parsed Result: 255
Optimized Result: 255
```

## OptimizerTests (3!!,720)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

## Check Expressions "(A*(1+(-1*B))+C)*D+E"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "A*B"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 13), (B, 128)
Parsed Result: 128
Optimized Result: 128
```

## OptimizerTests (2+3*4^5%6/7-8,-6)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
As Optimized: 250
```

## Check Expressions "(((A*B)*C)*D)+E"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 198), (B, 120), (C, 63), (D, 160), (E, 158)
Parsed Result: 158
Optimized Result: 158
```

## Check Expressions "((A+((B*C)+D))*E)+F+((C/G)*H)+I"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 208), (B, 184), (C, 60), (D, 69), (E, 41), (F, 132), (G, 220), (H, 86), (I, 1)
Parsed Result: 2
Optimized Result: 2
```

## Check Expressions "(((A/B)*C*D)*E*F)+G"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 66), (B, 128), (C, 67), (D, 89), (E, 218), (F, 95), (G, 17)
Parsed Result: 17
Optimized Result: 17
```

## OptimizerTests ((A+(B)),A + B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (B/1,B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## PoorlyFormedExpressions (B**A)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## PoorlyFormedExpressions (B*-*A)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(((A+(-1*B))/C)*((D*E)*F)*G)+H"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## PoorlyFormedExpressions (b)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (-1*B,-B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "((A*B)*C)+D"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 205), (B, 213), (C, 125), (D, 221)
Parsed Result: 170
Optimized Result: 170
```

## Check Expressions "((A/B)*(((C*D)*E)*F))+G"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 141), (B, 110), (C, 55), (D, 201), (E, 241), (F, 207), (G, 81)
Parsed Result: 66
Optimized Result: 66
```

## OptimizerTests ((A),A)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Negative factorial

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "((A/B)*(C*D)*E)+F"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 216), (B, 204), (C, 88), (D, 49), (E, 8), (F, 167)
Parsed Result: 103
Optimized Result: 103
```

## OptimizerTests (---B,-B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## SimpleParserTests (B*--A,B * --A)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## PoorlyFormedExpressions (B/*1)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(A/(A+B))"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 189), (B, 31)
Parsed Result: 0
Optimized Result: 0
```

## Just variable

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(A*B*(C/D))+E"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 188), (B, 193), (C, 205), (D, 103), (E, 36)
Parsed Result: 224
Optimized Result: 224
```

## OptimizerTests (B/B,1)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (N!!!,N!!!)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

## Check Expressions "((((A/B)*C)+D)*((E*F)*G))+H"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 95), (B, 112), (C, 82), (D, 83), (E, 74), (F, 86), (G, 87), (H, 177)
Parsed Result: 61
Optimized Result: 61
```

## OptimizerTests (B%1,0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## PoorlyFormedExpressions (-A!)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## GetDistinctVariablesTests (A+B+C,A, B, C)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::GetDistinctVariableNames
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "((A*(B+(-1*C)))+D)+((E*(B+(-1*C)))+F)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "((A*B)+C)+((D*B)+E)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 166), (B, 108), (C, 243), (D, 135), (E, 19)
Parsed Result: 2
Optimized Result: 2
```

## OptimizerTests ((A)!,A!)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (0/B,0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## VerifyOptimizerForComplexExpressions (A!)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 1)
Parsed Result: 1
Optimized Result: 1
```

## Check Expressions "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (-3,-3)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests_WithExceptions (B%0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (A!,A!)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "((A*B)+C)+(D*E*F)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 121), (B, 43), (C, 24), (D, 33), (E, 68), (F, 19)
Parsed Result: 247
Optimized Result: 247
```

## Check Expressions "(((A/B)+(-1*C))*((D*E)*F)*G)+H"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Simple factorial

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(A+B)*C+D"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 63), (B, 142), (C, 183), (D, 200)
Parsed Result: 83
Optimized Result: 83
```

## OptimizerTests (2!!!,2)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

## Check Expressions "(((A+(-1*B))+((C*D)+E))*F)+G+(D*H)+I"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (1*B,B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (B^0,1)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (2+3,5)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(((A+(-1*B))*C)+D)+(B+(-1*A))"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "((A/B)*((C*D)*E)*F)+G"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 201), (B, 149), (C, 250), (D, 211), (E, 153), (F, 21), (G, 85)
Parsed Result: 11
Optimized Result: 11
```

## OptimizerTests (0%B,0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(A+((B*C)+D))*E+F+(A+((B*C)+D))*G+H"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 98), (B, 190), (C, 156), (D, 245), (E, 106), (F, 178), (G, 99), (H, 48)
Parsed Result: 181
Optimized Result: 181
```

## OptimizerTests (-(B),-B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## PoorlyFormedExpressions ()

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (B/-1,-B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "((A/B)*((C*D)*E))+F"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 215), (B, 3), (C, 151), (D, 128), (E, 46), (F, 180)
Parsed Result: 180
Optimized Result: 180
```

## OptimizerTests (N!!,N!!)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

## Simple test with variable

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "((((A*B)+C)/D)*E)+F"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 1), (B, 58), (C, 111), (D, 14), (E, 122), (F, 204)
Parsed Result: 132
Optimized Result: 132
```

## Check Expressions "(A*B)+C"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 69), (B, 139), (C, 246)
Parsed Result: 109
Optimized Result: 109
```

## Check Expressions "A*(B/C)+D"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 19), (B, 252), (C, 33), (D, 136)
Parsed Result: 13
Optimized Result: 13
```

## Check Expressions "((A/B)*C)+D"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 250), (B, 10), (C, 69), (D, 150)
Parsed Result: 83
Optimized Result: 83
```

## OptimizerTests (--B,B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(((A/B)*((C*D)*E)*F)*G)+H"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 235), (B, 250), (C, 165), (D, 67), (E, 22), (F, 213), (G, 194), (H, 38)
Parsed Result: 38
Optimized Result: 38
```

## Check Expressions "(A/B)-(C+D+E+F)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 195), (B, 127), (C, 47), (D, 206), (E, 101), (F, 56)
Parsed Result: 103
Optimized Result: 103
```

## Check Expressions "(A*B)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 251), (B, 61)
Parsed Result: 207
Optimized Result: 207
```

## Check Expressions "((A/B)*C*D*E)+F"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 212), (B, 128), (C, 145), (D, 76), (E, 219), (F, 217)
Parsed Result: 29
Optimized Result: 29
```

## Check Expressions "(((A/B)+(-1*C))*D*E*F)+G"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (B%-1,0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "((A-B)*C)+D"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 202), (B, 3), (C, 22), (D, 167)
Parsed Result: 193
Optimized Result: 193
```

## PoorlyFormedExpressions (B***A)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## PoorlyFormedExpressions (B**)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Parse all operators test

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (0*B,0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "A"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 9)
Parsed Result: 9
Optimized Result: 9
```

## Check Expressions "(A*1)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 137)
Parsed Result: 137
Optimized Result: 137
```

## Check Expressions "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "A+B"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 95), (B, 37)
Parsed Result: 132
Optimized Result: 132
```

## PoorlyFormedExpressions (b+1)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(((A/B)*C*D)*E)+F"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 69), (B, 35), (C, 99), (D, 245), (E, 188), (F, 163)
Parsed Result: 231
Optimized Result: 231
```

## Parse Complex Expression

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

## Check Expressions "((A*B)+C)+(-1*A)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (B*-1,-B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (-(3),-3)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(A*B*C)+D"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 8), (B, 176), (C, 63), (D, 109)
Parsed Result: 237
Optimized Result: 237
```

## Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

## OptimizerTests_WithExceptions (B/0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "A*B+C"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 42), (B, 102), (C, 133)
Parsed Result: 65
Optimized Result: 65
```

## PoorlyFormedExpressions (B*+*A)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (B*0,0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (0^B,0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(((A/B)+(-1*C))*(D*E)*F)+G"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "((A/(1-B))*C)+D"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 27), (B, 27), (C, 158), (D, 230)
Parsed Result: 230
Optimized Result: 230
```

## OptimizerTests (B^1,B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (-1*(A*B),-(A * B))

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (B-0,B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (0+B,B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "((A*B)+((A*C)-A)*D)+E"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 238), (B, 111), (C, 78), (D, 56), (E, 76)
Parsed Result: 78
Optimized Result: 78
```

## Check Expressions "(((A*B)+C)*D)+E"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 196), (B, 79), (C, 9), (D, 35), (E, 106)
Parsed Result: 153
Optimized Result: 153
```

## Check Expressions "(((A+(-1*B))/C)*(D*E)*F)+G"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 136), (B, 65), (C, 21), (D, 154), (E, 122), (F, 168), (G, 101), (H, 26)
Parsed Result: 43
Optimized Result: 43
```

## OptimizerTests (B%B,0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

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

## Links

* [Back to Summary](../Summary.md)
* [Table of Contents](../../TOC.md)
