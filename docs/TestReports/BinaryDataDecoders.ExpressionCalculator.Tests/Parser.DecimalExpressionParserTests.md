# BinaryDataDecoders.ExpressionCalculator.Tests.Parser.DecimalExpressionParserTests

## Check Expressions "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"

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
Input: (A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))
As Parsed: (A * (((B * C) + D) + ((E * ((F * G) + H)) + I)) + J) + (-1 * (B + (-1 * ((B * C) + D))))
As Optimized: A * (((B * C) + D) + ((E * ((F * G) + H)) + I)) + J + -(B + (-((B * C) + D)))
Variables: (A, 9454.36), (B, 6471.28), (C, 1185.67), (D, -3111.16), (E, 3047.95), (F, 4028.26), (G, 8788.68), (H, -8912.76), (I, -4562.27), (J, 6302.71)
Parsed Result: 1020005776933437.09201760
Optimized Result: 1020005776933437.09201760
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
Variables: (A, 8948.73)
Parsed Result: 8948.73
Optimized Result: 8948.73
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
Variables: (A, 1117.38), (B, -890.31)
Parsed Result: 227.07
Optimized Result: 227.07
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
Variables: (A, -4397.5), (B, -7908.5)
Parsed Result: -0.7984081864695849914724275156
Optimized Result: -0.7984081864695849914724275156
```

## OptimizerTests (B*-1,-B)

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
Input: B*-1
As Parsed: B * -1
As Optimized: -B
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
Variables: (A, 6760.31), (B, -2502.64), (C, 5377.03), (D, -6646.81), (E, -2983.06)
Parsed Result: 13683573.231966123900036257994
Optimized Result: 13683573.231966123900036257994
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

## Check Expressions "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"

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
Input: (A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)
As Parsed: (A * (((B * C) + D) + ((E * F) + G))) + (-1 * (B + (-1 * ((B * C) + D)))) + (H * (((B * I) + J) + ((E * F) + G) + (A * (((B * C) + D) + ((E * F) + G))) + (-1 * (B + (-1 * ((B * C) + D))))) + K)
As Optimized: A * (((B * C) + D) + ((E * F) + G)) + -(B + (-((B * C) + D))) + H * (((B * I) + J) + ((E * F) + G) + (A * (((B * C) + D) + ((E * F) + G))) + (-(B + (-((B * C) + D))))) + K
Variables: (A, 7913.27), (B, -2556.57), (C, 9148.09), (D, -2742.89), (E, -8907.98), (F, 1888.63), (G, 8645.08), (H, 1053.1), (I, -4684.2), (J, 879.32), (K, -9004.92)
Parsed Result: -335400757883361.3603009
Optimized Result: -335400757883361.3603009
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
Variables: (A, -5495.25), (B, 1810.9), (C, 7864.52), (D, -4778.01), (E, -4263.29), (F, 2864.91)
Parsed Result: -486135274053.17211537743663370
Optimized Result: -486135274053.17211537743663370
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
Variables: (A, 285.13), (B, -2805.41), (C, 1820.85), (D, -9352.85)
Parsed Result: -9537.913488224537589870999248
Optimized Result: -9537.913488224537589870999248
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
Variables: (A, -9392.25), (B, -6449.48), (C, -6083.61), (D, -5448.8), (E, 8281.44), (F, -824.52), (G, 5987.87), (H, 4583.06), (I, -7674.82)
Parsed Result: 324808663662.26632655482500455
Optimized Result: 324808663662.26632655482500455
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

## Parse Complex Expression

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.01

#### Standard Out

```
TestContext Messages:
Input: ((((((A-B-1*E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H
As Parsed: ((((((A - B - 1 * E - 6) / C) + 0.999999) / 1000000) * 1000000) * ((D * E) * F) * G) + H
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
Variables: (A, 7421.76), (B, 2734.49), (C, 3452.7)
Parsed Result: 20298181.2024
Optimized Result: 20298181.2024
```

## OptimizerTests (-3,-3)

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
Input: -3
As Parsed: -3
As Optimized: -3
```

## Check Expressions "(A*(1+(-1*B))+C)*D+E"

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
Input: (A*(1+(-1*B))+C)*D+E
As Parsed: (A * (1 + (-1 * B)) + C) * D + E
As Optimized: (A * (1 + (-B)) + C) * D + E
Variables: (A, 2073.19), (B, 4312.06), (C, -8538.15), (D, 7513.73), (E, -6944.93)
Parsed Result: -67219222795.419122
Optimized Result: -67219222795.419122
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
Variables: (A, 8160.23), (B, -3360.96), (C, -4689.52), (D, -6334.34), (E, -9379.07)
Parsed Result: 99785665195.631928
Optimized Result: 99785665195.631928
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
Variables: (A, -5757.93), (B, 5380.76)
Parsed Result: 15.266139936898480791155182013
Optimized Result: 15.266139936898480791155182013
```

## Check Expressions "(((A+(-1*B))*C)+D)+(B+(-1*A))"

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
Input: (((A+(-1*B))*C)+D)+(B+(-1*A))
As Parsed: (((A + (-1 * B)) * C) + D) + (B + (-1 * A))
As Optimized: (A + (-B)) * C + D + B + -A
Variables: (A, 105.36), (B, 152.96), (C, -607.28), (D, 4322.03)
Parsed Result: 33276.1580
Optimized Result: 33276.1580
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
Variables: (A, 2648.74), (B, -6760.88), (C, 3485.37), (D, -9501.39), (E, -7684.52), (F, 8168.93), (G, 3776.84), (H, -7503.39)
Parsed Result: -814555622799090.3813741867945
Optimized Result: -814555622799090.3813741867945
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

## OptimizerTests (2+3*4^5%6/7-8,-6)

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
Input: 2+3*4^5%6/7-8
As Parsed: 2 + 3 * 4 ^ 5 % 6 / 7 - 8
As Optimized: -6
```

## OptimizerTests (B/-1,-B)

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
Input: B/-1
As Parsed: B / -1
As Optimized: -B
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
Variables: (A, -8986.47), (B, -7389.94), (C, -5262.27), (D, 4779.82)
Parsed Result: 11178.090245313857236021399172
Optimized Result: 11178.090245313857236021399172
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
Variables: (A, -4020.92)
Parsed Result: -4020.92
Optimized Result: -4020.92
```

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
Variables: (A, -1476.46), (B, 9716.51), (C, 7272.81), (D, 1057.03), (E, -7614.88), (F, 453.92)
Parsed Result: 509093738.29220336981921042922
Optimized Result: 509093738.29220336981921042922
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
Variables: (A, 695.26), (B, -3853.4), (C, 9309.84), (D, 6763.59), (E, -9455.3), (F, -8494.28), (G, 9124.69), (H, -8575.63), (I, -9150.6), (J, -5485.64)
Parsed Result: -534760166599.40815796761753947
Optimized Result: -534760166599.40815796761753947
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
Variables: (A, 6089.38), (B, -5354.96), (C, 2180.82), (D, 4368.76), (E, -3817.08), (F, 7118.13), (G, 1407.42), (H, -6011.42)
Parsed Result: 81646259248124.59014272
Optimized Result: 81646259248124.59014272
```

## Check Expressions "A"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.01

#### Standard Out

```
TestContext Messages:
Input: A
As Parsed: A
As Optimized: A
Variables: (A, 9817.83)
Parsed Result: 9817.83
Optimized Result: 9817.83
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

## OptimizerTests (B%-1,0)

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
Input: B%-1
As Parsed: B % -1
As Optimized: 0
```

## OptimizerTests (0-B,-B)

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
Input: 0-B
As Parsed: 0 - B
As Optimized: -B
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
Variables: (A, -7406.88), (B, 8617), (C, 6048.48), (D, -5838.44)
Parsed Result: -386044755717.3008
Optimized Result: -386044755717.3008
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
Variables: (A, -5060.72), (B, -5463.2), (C, 8896.75), (D, 7109.35), (E, -510.04), (F, -3654.12), (G, -6576.15), (H, -9224.8)
Parsed Result: 24730789610.30630
Optimized Result: 24730789610.30630
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
Variables: (A, 7328.61), (B, 1981.3), (C, -1328.38), (D, 3958.44), (E, 6339.95), (F, 3541.84)
Parsed Result: -12508.151110382072376722354010
Optimized Result: -12508.151110382072376722354010
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
Variables: (A, 6.75)
Parsed Result: 2495.33294677734375
Optimized Result: 2495.33294677734375
```

## Check Expressions "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"

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
Input: (A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L
As Parsed: (A * ((B + (-1 * C)) * D + E + (F * G) + H)) + (-1 * (B + (-1 * C) + (-1 * ((B + (-1 * C)) * D + E)))) + I * ((B + (-1 * C)) * J + K + (F * G) + H + (A * ((((B + (-1 * C)) * D) + E) + (F * G) + H)) + (-1 * (B + (-1 * C) + (-1 * ((B + (-1 * C)) * D + E))))) + L
As Optimized: A * ((B + (-C)) * D + E + (F * G) + H) + -(B + (-C) + (-((B + (-C)) * D + E))) + I * ((B + (-C)) * J + K + (F * G) + H + (A * ((((B + (-C)) * D) + E) + (F * G) + H)) + (-(B + (-C) + (-((B + (-C)) * D + E))))) + L
Variables: (A, -5644.31), (B, 9147.47), (C, 2939.25), (D, 9392.16), (E, -5523.45), (F, 2425.01), (G, 1210.51), (H, -4301.17), (I, 2201.28), (J, -4560.35), (K, -2714.69), (L, 3315.22)
Parsed Result: -761090957813733.23225604
Optimized Result: -761090957813733.23225604
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
Variables: (A, -4318.33), (B, 8811.74), (C, 4053.08), (D, 2609.18), (E, -3533.57), (F, 5349.54), (G, 6199.87), (H, -1522.35)
Parsed Result: 95221517093.119960
Optimized Result: 95221517093.119960
```

## Check Expressions "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"

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
Input: (A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))
As Parsed: (A * ((((B + (-1 * C)) * D) + E) + ((F * ((G * H) + I)) + J)) + K) + (-1 * ((B + (-1 * C)) + (-1 * (((B + (-1 * C)) * D) + E))))
As Optimized: A * ((((B + (-C)) * D) + E) + ((F * ((G * H) + I)) + J)) + K + -((B + (-C)) + (-(((B + (-C)) * D) + E)))
Variables: (A, -9437.75), (B, -4684.98), (C, -9147.93), (D, 5660.85), (E, 222.86), (F, 9518.1), (G, 995.03), (H, 7700.83), (I, 4591.32), (J, -198.37), (K, 9367.78)
Parsed Result: -688974103322628.6269225
Optimized Result: -688974103322628.6269225
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

## OptimizerTests (---B,-B)

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
Input: ---B
As Parsed: ---B
As Optimized: -B
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

## Check Expressions "((A+((-1*B)*(C/D)))*(E/C))+(-1*F)+G"

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
Input: ((A+((-1*B)*(C/D)))*(E/C))+(-1*F)+G
As Parsed: ((A + ((-1 * B) * (C / D))) * (E / C)) + (-1 * F) + G
As Optimized: (A + ((-B) * (C / D))) * E / C + -F + G
Variables: (A, 5056.43), (B, 4391.3), (C, 107.24), (D, -5550.97), (E, -7097.18), (F, 7380.33), (G, -2173.83)
Parsed Result: -349804.91911529958737677252248
Optimized Result: -349804.91911529958737677252248
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
Variables: (A, -8530.13), (B, 4447.42), (C, 3975.66), (D, 4005.09), (E, -9106.27), (F, -4831.32)
Parsed Result: 176167220509.771276
Optimized Result: 176167220509.771276
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
Variables: (A, -1247.83), (B, -2579.22), (C, -2760.2), (D, -6096.31), (E, -3821.19)
Parsed Result: -21001671463.45416
Optimized Result: -21001671463.45416
```

## Check Expressions "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"

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
Input: (((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))
As Parsed: (((((A * B) + C) + ((D * E) + F)) * G) + H) + (-1 * ((A + (-1 * (A * B))) + C))
As Optimized: (((A * B) + C) + ((D * E) + F)) * G + H + -((A + (-(A * B))) + C)
Variables: (A, -4575.68), (B, 5160.62), (C, -7205.45), (D, -6143.56), (E, -4610.73), (F, -2749.13), (G, 7976.49), (H, -4692.03)
Parsed Result: 37489795082.733228
Optimized Result: 37489795082.733228
```

## Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"

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
Input: ((((((A-B-1*E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H
As Parsed: ((((((A - B - 1 * E - 6) / C) + 0.999999) / 1000000) * 1000000) * ((D * E) * F) * G) + H
As Optimized: (((A - B - E - 6) / C) + 0.999999) / 1000000 * 1000000 * D * E * F * G + H
Variables: (A, -5143.84), (B, 5361.04), (E, 6623.66), (C, -5135.48), (D, -7384.23), (F, 7622.87), (G, -4486.83), (H, -2353.7)
Parsed Result: 7254389001824075.6576399326213
Optimized Result: 7254389001824075.6576399326213
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
Variables: (A, -526.23), (B, -5029.88), (C, 3464.45), (D, -6386.92)
Parsed Result: 15596283.3225
Optimized Result: 15596283.3225
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
Variables: (A, -248.89), (B, -1148.93), (C, -2719.17), (D, 3474.03), (E, -4409.63), (F, 9826.91), (G, 8861.77)
Parsed Result: 88675354206721.73882640006676
Optimized Result: 88675354206721.73882640006676
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

## Check Expressions "(((A/B)+(-1*C))*((D*E)*F)*G)+H"

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
Input: (((A/B)+(-1*C))*((D*E)*F)*G)+H
As Parsed: (((A / B) + (-1 * C)) * ((D * E) * F) * G) + H
As Optimized: ((A / B) + (-C)) * D * E * F * G + H
Variables: (A, 8903.73), (B, -9961.09), (C, -2173.69), (D, 5231.52), (E, -5834.95), (F, 577.03), (G, 1712.21), (H, -8807.58)
Parsed Result: -65529889222460246.259747624844
Optimized Result: -65529889222460246.259747624844
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
Variables: (A, -2215.17), (B, 5556.69), (C, -2027.32), (D, 4387.52)
Parsed Result: 10459.088862981670382574038632
Optimized Result: 10459.088862981670382574038632
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
Variables: (A, -5244.41), (B, 6233.02), (C, -189.09), (D, -6891.9), (E, -7550.04), (F, -1628.84), (G, 8443.69)
Parsed Result: -13484452684010.293915451016682
Optimized Result: -13484452684010.293915451016682
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
Variables: (A, -1605.33), (B, 8470.58)
Parsed Result: -13598076.1914
Optimized Result: -13598076.1914
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

## Check Expressions "((A*B)+C)+(-1*A)"

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
Input: ((A*B)+C)+(-1*A)
As Parsed: ((A * B) + C) + (-1 * A)
As Optimized: A * B + C + -A
Variables: (A, -6821.45), (B, -640.46), (C, 9961.09)
Parsed Result: 4385648.4070
Optimized Result: 4385648.4070
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
Variables: (A, -1904.33), (B, 802.95), (C, 5268.78), (D, 6143.82), (E, -3470.44), (F, -257.73)
Parsed Result: 266432251493.21207819405940595
Optimized Result: 266432251493.21207819405940595
```

## Check Expressions "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"

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
Input: ((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I
As Parsed: ((A + (-1 * B)) + ((C * D) + E)) * F + G + ((A + (-1 * B)) + ((C * D) + E)) * H + I
As Optimized: ((A + (-B)) + ((C * D) + E)) * F + G + ((A + (-B)) + ((C * D) + E)) * H + I
Variables: (A, -5347.74), (B, 3206.2), (C, 6337.62), (D, -11.91), (E, -2491.77), (F, 6802.97), (G, 5482.35), (H, 9527.5), (I, 9722.48)
Parsed Result: -1413007522.135174
Optimized Result: -1413007522.135174
```

## Just decimal value

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
Input: 1.34
As Parsed: 1.34
```

## Check Expressions "(((A/B)+(-1*C))*(D*E)*F)+G"

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
Input: (((A/B)+(-1*C))*(D*E)*F)+G
As Parsed: (((A / B) + (-1 * C)) * (D * E) * F) + G
As Optimized: ((A / B) + (-C)) * D * E * F + G
Variables: (A, 2739.59), (B, -956.87), (C, -7368.06), (D, 5912.3), (E, -4515.91), (F, -4388.14), (G, 1956.77)
Parsed Result: 862912139994223.6543290832025
Optimized Result: 862912139994223.6543290832025
```

## Check Expressions "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"

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
Input: (A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)
As Parsed: (A * (((B * C) + D) + ((E * F) + G)) + H) + (-1 * (B + (-1 * ((B * C) + D)))) + (I * (((B * J) + K) + ((E * F) + G)) + L)
As Optimized: A * (((B * C) + D) + ((E * F) + G)) + H + -(B + (-((B * C) + D))) + I * (((B * J) + K) + ((E * F) + G)) + L
Variables: (A, -2284.5), (B, 7442.46), (C, 3607.03), (D, -9673.02), (E, 2995.74), (F, -7684.57), (G, 2292.14), (H, 5741.57), (I, -4140.12), (J, 9165.53), (K, 8068.67), (L, 3272.59)
Parsed Result: -195840513707.033040
Optimized Result: -195840513707.033040
```

## Check Expressions "(((A+(-1*B))/C)*((D*E)*F)*G)+H"

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
Input: (((A+(-1*B))/C)*((D*E)*F)*G)+H
As Parsed: (((A + (-1 * B)) / C) * ((D * E) * F) * G) + H
As Optimized: (A + (-B)) / C * D * E * F * G + H
Variables: (A, -537.58), (B, -8846.14), (C, 2507.79), (D, 5454.31), (E, -2090.17), (F, 8046.99), (G, 9292.42), (H, 4866.52)
Parsed Result: -2824348699566243.6556689974080
Optimized Result: -2824348699566243.6556689974080
```

## Check Expressions "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"

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
Input: (A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))
As Parsed: (A * ((B + (-1 * C)) + ((D * (B + (-1 * C))) + E) + ((F * G) + H)) + ((D * (B + (-1 * C))) + E))
As Optimized: A * ((B + (-C)) + ((D * (B + (-C))) + E) + ((F * G) + H)) + D * (B + (-C)) + E
Variables: (A, -4238.95), (B, -132.07), (C, 2846.19), (D, -5048.16), (E, 1664.94), (F, 7104.7), (G, -3534.61), (H, 1370.12)
Parsed Result: 42733283355.678930
Optimized Result: 42733283355.678930
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
Variables: (A, 7744.76), (B, -7185.61), (C, 1086), (D, -2983.57), (E, -9017.63), (F, -4615.54)
Parsed Result: -168202028.38074798580224362090
Optimized Result: -168202028.38074798580224362090
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
Variables: (A, 9418.24), (B, -4551.32), (C, 468.79), (D, 6959.97), (E, -7498.89), (F, 671.46)
Parsed Result: 50630833512.929953186258052608
Optimized Result: 50630833512.929953186258052608
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
Variables: (A, 7592.05), (B, -5532.28), (C, 3467.31), (D, -2234.98)
Parsed Result: -14348.505001802550103682681964
Optimized Result: -14348.505001802550103682681964
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
Variables: (A, 3278.83), (B, 8144.39), (C, -640.74), (D, -2365.03), (E, -146.4)
Parsed Result: 7441556.4420
Optimized Result: 7441556.4420
```

## Parse all operators test

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.02

#### Standard Out

```
TestContext Messages:
Input: 2+3*4^5%6/7-8
As Parsed: 2 + 3 * 4 ^ 5 % 6 / 7 - 8
```

## PoorlyFormedExpressions (-A!)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.05

#### Standard Out

```
TestContext Messages:
Input: -A!
The parse operation was cancelled.
Antlr4.Runtime.Misc.ParseCanceledException
```

## Check Expressions "(((A+(-1*B))/C)*(D*E)*F)+G"

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
Input: (((A+(-1*B))/C)*(D*E)*F)+G
As Parsed: (((A + (-1 * B)) / C) * (D * E) * F) + G
As Optimized: (A + (-B)) / C * D * E * F + G
Variables: (A, 2317.64), (B, -1520.86), (C, 1255.76), (D, 6870.13), (E, -4565.37), (F, -8641.93), (G, 2245.94)
Parsed Result: 828526837864.9287838603714086
Optimized Result: 828526837864.9287838603714086
```

## OptimizerTests (-(3),-3)

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
Input: -(3)
As Parsed: -(3)
As Optimized: -3
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
Variables: (A, -8678.97), (B, 4689.56), (C, -8722.05), (D, 4419.09), (E, -9309.55), (F, 476.16)
Parsed Result: 71940340.6060
Optimized Result: 71940340.6060
```

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
Variables: (A, -1727.38), (B, -7700.46), (C, 9117.41), (D, 4873.66), (E, -1778.32), (F, -9651.8)
Parsed Result: -17725891239.818923403661599433
Optimized Result: -17725891239.818923403661599433
```

## OptimizerTests (-(B),-B)

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
Input: -(B)
As Parsed: -(B)
As Optimized: -B
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
Variables: (A, 3180.63), (B, 787.21), (C, 3969.1), (D, -2663.35), (E, 2993.39)
Parsed Result: -6679127073.149705
Optimized Result: -6679127073.149705
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

## Check Expressions "((A*(B+(-1*C)))+D)+((E*(B+(-1*C)))+F)"

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
Input: ((A*(B+(-1*C)))+D)+((E*(B+(-1*C)))+F)
As Parsed: ((A * (B + (-1 * C))) + D) + ((E * (B + (-1 * C))) + F)
As Optimized: A * (B + (-C)) + D + E * (B + (-C)) + F
Variables: (A, -9569.99), (B, -1743.18), (C, 6994.19), (D, 3917.18), (E, 6807.67), (F, 7521.99)
Parsed Result: 24146851.0684
Optimized Result: 24146851.0684
```

## Check Expressions "(((A/B)+(-1*C))*D*E*F)+G"

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
Input: (((A/B)+(-1*C))*D*E*F)+G
As Parsed: (((A / B) + (-1 * C)) * D * E * F) + G
As Optimized: ((A / B) + (-C)) * D * E * F + G
Variables: (A, -9432.54), (B, -2232.62), (C, -7438.86), (D, -8905.06), (E, 6295.34), (F, -9544.52), (G, -4251.03)
Parsed Result: 3982567122826150.9040821290975
Optimized Result: 3982567122826150.9040821290975
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

## OptimizerTests (-1*(A*B),-(A * B))

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
Input: -1*(A*B)
As Parsed: -1 * (A * B)
As Optimized: -(A * B)
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
Variables: (A, 7443.16), (B, -579.42), (C, 3637.35), (D, -6183.78)
Parsed Result: 24959640.9090
Optimized Result: 24959640.9090
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

## Check Expressions "((((A/B)*C)+D)*((E*F)*G))+H"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.12.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.03

#### Standard Out

```
TestContext Messages:
Input: ((((A/B)*C)+D)*((E*F)*G))+H
As Parsed: ((((A / B) * C) + D) * ((E * F) * G)) + H
As Optimized: (((A / B) * C) + D) * E * F * G + H
Variables: (A, 1435.6), (B, 3527.59), (C, -245.45), (D, 9749.05), (E, 6235.48), (F, 1795.07), (G, -7998.65), (H, -5624.9)
Parsed Result: -863888153300790.3239484546759
Optimized Result: -863888153300790.3239484546759
```

## Check Expressions "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"

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
Input: (A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)
As Parsed: (A * ((B + (-1 * C)) + ((D * E) + F)) + G) + (H * ((B + (-1 * C)) + ((D * E) + F) + (A * ((B + (-1 * C)) + ((D * E) + F)) + G)) + I)
As Optimized: A * ((B + (-C)) + ((D * E) + F)) + G + H * ((B + (-C)) + ((D * E) + F) + (A * ((B + (-C)) + ((D * E) + F)) + G)) + I
Variables: (A, -3460.25), (B, 7742.09), (C, -4427), (D, 6038.43), (E, -8356.71), (F, -3682.95), (G, 56.48), (H, -7333.9), (I, 1338.4)
Parsed Result: -1279805642800084.3401225
Optimized Result: -1279805642800084.3401225
```

## Check Expressions "(((A+(-1*B))+((C*D)+E))*F)+G+(D*H)+I"

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
Input: (((A+(-1*B))+((C*D)+E))*F)+G+(D*H)+I
As Parsed: (((A + (-1 * B)) + ((C * D) + E)) * F) + G + (D * H) + I
As Optimized: ((A + (-B)) + ((C * D) + E)) * F + G + D * H + I
Variables: (A, -7296.04), (B, -5371.88), (C, 6774.49), (D, -6781.16), (E, 2232.89), (F, 5028.4), (G, 1668.31), (H, -5280.03), (I, -3502.91)
Parsed Result: -230961812507.71176
Optimized Result: -230961812507.71176
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

## OptimizerTests (-1*B,-B)

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
Input: -1*B
As Parsed: -1 * B
As Optimized: -B
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
Variables: (A, 299.26), (B, 404.12), (C, 8729.45), (D, -561.83)
Parsed Result: 1055712506.822840
Optimized Result: 1055712506.822840
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
Variables: (A, 2299.09), (B, -4563.95), (C, -7733.51), (D, 3485.59), (E, 8236.62), (F, -9443.73)
Parsed Result: 83413706.02471553037803586648
Optimized Result: 83413706.02471553037803586648
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
Variables: (A, -7669.89), (B, 2206.79), (C, 6097.06)
Parsed Result: -16919739.4931
Optimized Result: -16919739.4931
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
Variables: (A, -1894.54), (B, 2040.64), (C, -7546.61), (D, -2422.9), (E, -6577.89), (F, -2209.03), (G, 3977.85)
Parsed Result: -246668107036356.88674468678553
Optimized Result: -246668107036356.88674468678553
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
Variables: (A, 7204.01), (B, -8528.87), (C, -352.82), (D, 5895.09), (E, -1207.12)
Parsed Result: 127793697892357.79927606
Optimized Result: 127793697892357.79927606
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
Variables: (A, -959.72), (B, -9093.61)
Parsed Result: 8727319.3892
Optimized Result: 8727319.3892
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
Variables: (A, 1889.27), (B, 3679.64), (C, 5716.19), (D, 120.82), (E, 9045), (F, -4842.66), (G, -9754.49), (H, 1979.18)
Parsed Result: 151506512715882567.46300602867
Optimized Result: 151506512715882567.46300602867
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

## Check Expressions "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"

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
Input: ((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))
As Parsed: ((A * (((B * C) + D) + (E * F))) + (-1 * (B * (1 + (-1 * C)) + D) + G))
As Optimized: A * (((B * C) + D) + (E * F)) + -(B * (1 + (-C)) + D) + G
Variables: (A, 7744.4), (B, 7642.02), (C, 6678.35), (D, -1818.29), (E, 2796.26), (F, 9651.17), (G, 7782.75)
Parsed Result: 604280329101.62028
Optimized Result: 604280329101.62028
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

## Check Expressions "((A/(1+(-1*(B+C))))*D)+E"

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
Input: ((A/(1+(-1*(B+C))))*D)+E
As Parsed: ((A / (1 + (-1 * (B + C)))) * D) + E
As Optimized: A / (1 + (-(B + C))) * D + E
Variables: (A, -414.53), (B, -6821.66), (C, 120.82), (D, -4160.59), (E, 3561.92)
Parsed Result: 3819.2656502542585319852458429
Optimized Result: 3819.2656502542585319852458429
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

## Links

* [Back to Summary](../Summary.md)
* [Table of Contents](../../TOC.md)
