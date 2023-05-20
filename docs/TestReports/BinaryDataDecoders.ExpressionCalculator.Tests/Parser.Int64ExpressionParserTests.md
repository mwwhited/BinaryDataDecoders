# BinaryDataDecoders.ExpressionCalculator.Tests.Parser.Int64ExpressionParserTests

## Check Expressions "((A*B)+C)+(D*E*F)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 6709), (B, 9905), (C, 167), (D, -8392), (E, -8035), (F, -9679)
Parsed Result: -652585807068
Optimized Result: -652585807068
```

## Check Expressions "(((A/B)*((C*D)*E)*F)*G)+H"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 1074), (B, -9297), (C, -3937), (D, 941), (E, -2944), (F, 7756), (G, -3636), (H, 4106)
Parsed Result: 4106
Optimized Result: 4106
```

## OptimizerTests (B/1,B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(((A/B)+(-1*C))*((D*E)*F)*G)+H"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 6265), (B, 3007), (C, 144), (D, 4397), (E, 643), (F, 2608), (G, -3532), (H, -3549)
Parsed Result: 3698146103150243
Optimized Result: 3698146103150243
```

## Check Expressions "((A/B)*((C*D)*E)*F)+G"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 534), (B, -3226), (C, -9653), (D, 5895), (E, -1005), (F, -400), (G, 7726)
Parsed Result: 7726
Optimized Result: 7726
```

## Check Expressions "(A/B)-(C+D+E+F)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 4595), (B, -2288), (C, -7740), (D, -1701), (E, 8595), (F, 6540)
Parsed Result: -5696
Optimized Result: -5696
```

## OptimizerTests (2+3*4^5%6/7-8,-6)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "((A*B)*C)+D"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -797), (B, 6361), (C, -9645), (D, -5824)
Parsed Result: 48897414641
Optimized Result: 48897414641
```

## Check Expressions "(A+((B*C)+D))*E+F+(A+((B*C)+D))*G+H"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -9553), (B, -9442), (C, -4326), (D, 75), (E, -3421), (F, 7437), (G, -4657), (H, 5148)
Parsed Result: -329878155307
Optimized Result: -329878155307
```

## Parse all operators test

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## PoorlyFormedExpressions (B/*1)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## GetDistinctVariablesTests (A+B+C,A, B, C)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::GetDistinctVariableNames
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.01

#### Standard Out

```
TestContext Messages:
Input: A+B+C
As Parsed: A + B + C
Variables: A, B, C
```

## OptimizerTests (-(3),-3)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (B*0,0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (B^1,B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "((A+((B*C)+D))*E)+F+(C*G)+H"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 1509), (B, 5850), (C, 6557), (D, -1220), (E, 6083), (F, -4179), (G, 1408), (H, -7959)
Parsed Result: 233345429455
Optimized Result: 233345429455
```

## Check Expressions "(((A+(-1*B))*C)+D)+(B+(-1*A))"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -2129), (B, -7906), (C, 4799), (D, -665)
Parsed Result: 27717381
Optimized Result: 27717381
```

## Check Expressions "((A*B)+((A*C)-A)*D)+E"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 9402), (B, 378), (C, -7271), (D, -6959), (E, 4235)
Parsed Result: 475799741087
Optimized Result: 475799741087
```

## Check Expressions "((A/B)*(C*D)*E)+F"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -4105), (B, -8766), (C, 7226), (D, -9304), (E, 435), (F, -7045)
Parsed Result: -7045
Optimized Result: -7045
```

## OptimizerTests (-(B),-B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (A!,A!)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "((((A*B)+C)/D)*E)+F"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 7894), (B, 6761), (C, -2413), (D, 5894), (E, 690), (F, 3067)
Parsed Result: 6250327
Optimized Result: 6250327
```

## OptimizerTests (N!!,N!!)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## PoorlyFormedExpressions (B**)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "((A*B)+C)+((D*B)+E)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -5693), (B, -4460), (C, 5432), (D, -8910), (E, 6498)
Parsed Result: 65141310
Optimized Result: 65141310
```

## OptimizerTests (B%1,0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "A+B"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -4257), (B, -2301)
Parsed Result: -6558
Optimized Result: -6558
```

## OptimizerTests (1*B,B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "((A+((B*C)+D))*E)+F+((C/G)*H)+I"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -382), (B, -1565), (C, -2624), (D, 6801), (E, -9044), (F, 4520), (G, 3710), (H, 3609), (I, -2354)
Parsed Result: -37197779910
Optimized Result: -37197779910
```

## OptimizerTests (--B,B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "((A/B)*C*D*E)+F"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 2180), (B, 225), (C, -4567), (D, 142), (E, -9736), (F, -7656)
Parsed Result: 56825383080
Optimized Result: 56825383080
```

## Check Expressions "(A*1)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -6840)
Parsed Result: -6840
Optimized Result: -6840
```

## Check Expressions "(((((A*B)+C)+((D*E)+F))*G)+H)+(-1*((A+(-1*(A*B)))+C))"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 7704), (B, 631), (C, 9613), (D, -7932), (E, -7801), (F, 9736), (G, 4331), (H, 7909)
Parsed Result: 289134204571
Optimized Result: 289134204571
```

## OptimizerTests ((A+(B)),A + B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "((A+(-1*B))+((C*D)+E))*F+G+((A+(-1*B))+((C*D)+E))*H+I"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -8457), (B, -3703), (C, -5353), (D, -20), (E, 6914), (F, 633), (G, 3340), (H, -5124), (I, 1477)
Parsed Result: -490502203
Optimized Result: -490502203
```

## Check Expressions "((A+((-1*B)*(C/D)))*(E/C))+(-1*F)+G"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -7625), (B, -4751), (C, 65), (D, -7506), (E, -544), (F, 3228), (G, -1474)
Parsed Result: 56298
Optimized Result: 56298
```

## Parse Complex Expression

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

## OptimizerTests (B+0,B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## PoorlyFormedExpressions (b)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(A*B*(C/D))+E"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 8097), (B, 1538), (C, 7113), (D, 9995), (E, -8297)
Parsed Result: -8297
Optimized Result: -8297
```

## Check Expressions "(A*((B+(-1*C))*D+E+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E))))+I*((B+(-1*C))*J+K+(F*G)+H+(A*((((B+(-1*C))*D)+E)+(F*G)+H))+(-1*(B+(-1*C)+(-1*((B+(-1*C))*D+E)))))+L"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 5792), (B, 8501), (C, 9541), (D, -2109), (E, 1443), (F, -2579), (G, 5906), (H, 5605), (I, 4494), (J, 3672), (K, -263), (L, -3594)
Parsed Result: -339342646479277
Optimized Result: -339342646479277
```

## Check Expressions "(A*B*C)+D"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -4882), (B, -4973), (C, 5597), (D, -7256)
Parsed Result: 135884999786
Optimized Result: 135884999786
```

## Check Expressions "((A/(1+(-1*(B+C))))*D)+E"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -2348), (B, -1892), (C, -9967), (D, 4378), (E, -5361)
Parsed Result: -5361
Optimized Result: -5361
```

## OptimizerTests (-1*B,-B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(((A/B)*C*D)*E)+F"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -6623), (B, -628), (C, 1580), (D, -8891), (E, 9349), (F, -682)
Parsed Result: -1313326952882
Optimized Result: -1313326952882
```

## Check Expressions "(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D))))+(H*(((B*I)+J)+((E*F)+G)+(A*(((B*C)+D)+((E*F)+G)))+(-1*(B+(-1*((B*C)+D)))))+K)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -3709), (B, -7955), (C, -8374), (D, 7687), (E, -1397), (F, 2705), (G, -8891), (H, -6575), (I, -2091), (J, 9512), (K, 4648)
Parsed Result: 1531583086837231
Optimized Result: 1531583086837231
```

## Check Expressions "((A*(B+(-1*C)))+D)+((E*(B+(-1*C)))+F)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 1031), (B, 3403), (C, -6796), (D, 4454), (E, 5571), (F, -7049)
Parsed Result: 67331203
Optimized Result: 67331203
```

## Check Expressions "((A*(((B*C)+D)+(E*F)))+(-1*(B*(1+(-1*C))+D)+G))"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 5101), (B, -6799), (C, 5695), (D, -4863), (E, -6758), (F, -8677), (G, 3481)
Parsed Result: 101542598636
Optimized Result: 101542598636
```

## Check Expressions "((A/(1-B))*C)+D"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -9008), (B, 1683), (C, 1632), (D, -3718)
Parsed Result: 4442
Optimized Result: 4442
```

## Check Expressions "(((A+(-1*B))/C)*(D*E)*F)+G"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 5510), (B, -3018), (C, -737), (D, 9859), (E, -6612), (F, -7983), (G, -9283)
Parsed Result: -5724328211887
Optimized Result: -5724328211887
```

## OptimizerTests (B/-1,-B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "A"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.02

#### Standard Out

```
TestContext Messages:
Input: A
As Parsed: A
As Optimized: A
Variables: (A, -9290)
Parsed Result: -9290
Optimized Result: -9290
```

## OptimizerTests ((A),A)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(A*((((B+(-1*C))*D)+E)+((F*((G*H)+I))+J))+K)+(-1*((B+(-1*C))+(-1*(((B+(-1*C))*D)+E))))"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -8863), (B, 7483), (C, -7629), (D, -1975), (E, 8714), (F, 8771), (G, 3630), (H, -2437), (I, 8749), (J, 8233), (K, -1885)
Parsed Result: 687273122682109
Optimized Result: 687273122682109
```

## VerifyOptimizerForComplexExpressions (A!)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 5)
Parsed Result: 120
Optimized Result: 120
```

## OptimizerTests (B^0,1)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## PoorlyFormedExpressions (B***A)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(A/(A+B))"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 4654), (B, 4792)
Parsed Result: 0
Optimized Result: 0
```

## OptimizerTests ((A)!,A!)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(A*B)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -8526), (B, -1948)
Parsed Result: 16608648
Optimized Result: 16608648
```

## OptimizerTests (B%B,0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(((A-(B*C))/(1-D))*E)+F"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -4819), (B, 3407), (C, -8643), (D, -7794), (E, -3071), (F, -9527)
Parsed Result: -11608694
Optimized Result: -11608694
```

## Check Expressions "(((A*B)+C)*D)+E"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -5215), (B, 7363), (C, 2815), (D, 9026), (E, -569)
Parsed Result: -346555346549
Optimized Result: -346555346549
```

## Check Expressions "(((A+(-1*B))+((C*D)+E))*F)+G+(D*H)+I"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -6718), (B, -2250), (C, -1488), (D, 3984), (E, 8874), (F, 7315), (G, 4882), (H, 4060), (I, 9517)
Parsed Result: -43316305151
Optimized Result: -43316305151
```

## PoorlyFormedExpressions (B*+*A)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (2!!!,2)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (-1*(A*B),-(A * B))

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(A*(B/C)+D)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 2688), (B, -616), (C, 515), (D, -8042)
Parsed Result: -10730
Optimized Result: -10730
```

## Check Expressions "(((A*B)*C)*D)+E"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -5420), (B, 3549), (C, 350), (D, -4302), (E, -972)
Parsed Result: 28963012805028
Optimized Result: 28963012805028
```

## Check Expressions "(A*(((B*C)+D)+((E*((F*G)+H))+I))+J)+(-1*(B+(-1*((B*C)+D))))"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 7180), (B, -6407), (C, 4936), (D, 9307), (E, -5340), (F, -5588), (G, -4102), (H, -5228), (I, -4956), (J, 6856)
Parsed Result: -878882685935162
Optimized Result: -878882685935162
```

## Check Expressions "(((A/B)*C*D)*E*F)+G"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 5064), (B, -9959), (C, -6720), (D, 3604), (E, 4548), (F, -1808), (G, -9836)
Parsed Result: -9836
Optimized Result: -9836
```

## OptimizerTests (0/B,0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(A*B)+C"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -1563), (B, 1876), (C, -668)
Parsed Result: -2932856
Optimized Result: -2932856
```

## OptimizerTests_WithExceptions (B%0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (-3,-3)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(((A-(B*C))/D)*E)+F"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 8060), (B, -5444), (C, -184), (D, -3286), (E, -8800), (F, -6926)
Parsed Result: -2664526
Optimized Result: -2664526
```

## OptimizerTests (N!!!,N!!!)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (B/B,1)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## SimpleParserTests (B*--A,B * --A)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(A*((B+(-1*C))+((D*(B+(-1*C)))+E)+((F*G)+H))+((D*(B+(-1*C)))+E))"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 310), (B, 9568), (C, -6914), (D, -7263), (E, -5418), (F, -5754), (G, 7108), (H, -6061)
Parsed Result: -49906704634
Optimized Result: -49906704634
```

## Check Expressions "((((A/B)*C)+D)*((E*F)*G))+H"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -325), (B, 3314), (C, -6202), (D, -8614), (E, -3877), (F, -8030), (G, -9705), (H, 5082)
Parsed Result: 2602625936494782
Optimized Result: 2602625936494782
```

## PoorlyFormedExpressions (b+1)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (2+3,5)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(A*(((B*C)+D)+((E*F)+G))+H)+(-1*(B+(-1*((B*C)+D))))+(I*(((B*J)+K)+((E*F)+G))+L)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 2308), (B, 1594), (C, 3352), (D, -1140), (E, 5353), (F, 5562), (G, 813), (H, -6563), (I, -8883), (J, -3110), (K, 6952), (L, -9487)
Parsed Result: -139456521533
Optimized Result: -139456521533
```

## OptimizerTests (0%B,0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Simple test with variable

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "((A-B)*C)+D"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -4762), (B, 9209), (C, -6636), (D, 6310)
Parsed Result: 92717866
Optimized Result: 92717866
```

## OptimizerTests (3!!,720)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.01

#### Standard Out

```
TestContext Messages:
Input: 3!!
As Parsed: 3!!
As Optimized: 720
```

## Check Expressions "A*B+C"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -5413), (B, -5075), (C, 8482)
Parsed Result: 27479457
Optimized Result: 27479457
```

## Check Expressions "((A/B)*((C*D)*E))+F"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 2627), (B, 9969), (C, -94), (D, -7760), (E, 1790), (F, 6019)
Parsed Result: 6019
Optimized Result: 6019
```

## Simple factorial

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (B*-1,-B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (0*B,0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "A*B"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -6679), (B, 2125)
Parsed Result: -14192875
Optimized Result: -14192875
```

## Check Expressions "(((A/B)+(-1*C))*D*E*F)+G"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 8588), (B, 9951), (C, 8427), (D, 6081), (E, -3120), (F, 188), (G, 3763)
Parsed Result: 30058024954483
Optimized Result: 30058024954483
```

## Check Expressions "((A*B)+C)+(-1*A)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 1423), (B, -8686), (C, 3271)
Parsed Result: -12358330
Optimized Result: -12358330
```

## Check Expressions "(A*(1+(-1*B))+C)*D+E"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 2017), (B, 1437), (C, -7862), (D, 1988), (E, -8331)
Parsed Result: -5773705043
Optimized Result: -5773705043
```

## OptimizerTests_WithExceptions (B/0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## PoorlyFormedExpressions ()

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "((A/B)*C)+D"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 6361), (B, 1206), (C, 9898), (D, -7479)
Parsed Result: 42011
Optimized Result: 42011
```

## Check Expressions "(A-B)/A"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -2644), (B, -7387)
Parsed Result: -1
Optimized Result: -1
```

## PoorlyFormedExpressions (B**A)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (---B,-B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(((A+(-1*B))/C)*((D*E)*F)*G)+H"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 3641), (B, 8404), (C, -1619), (D, -1997), (E, 1296), (F, -1424), (G, 1393), (H, -5408)
Parsed Result: 10267723560160
Optimized Result: 10267723560160
```

## Negative factorial

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(A*((B+(-1*C))+((D*E)+F))+G)+(H*((B+(-1*C))+((D*E)+F)+(A*((B+(-1*C))+((D*E)+F))+G))+I)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -8577), (B, 2015), (C, -3344), (D, -3220), (E, -9133), (F, 4866), (G, 1017), (H, 5757), (I, -1387)
Parsed Result: -1452702699302866
Optimized Result: -1452702699302866
```

## Check Expressions "(A+B)*C+D"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -4426), (B, -4183), (C, -9587), (D, -5683)
Parsed Result: 82528800
Optimized Result: 82528800
```

## Check Expressions "(((A/B)*(((C*D)*E)*F))+(C*D*G))+H"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 3367), (B, -3987), (C, 7232), (D, -5842), (E, -6402), (F, 3578), (G, 5433), (H, 1699)
Parsed Result: -229540684253
Optimized Result: -229540684253
```

## Just decimal value

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

## PoorlyFormedExpressions (-A!)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(A*(B+((C*D)+E))+F)+(G*(B+((C*D)+E)+(A*(B+((C*D)+E))+F))+H)"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 9235), (B, -4525), (C, -3857), (D, -1076), (E, -9834), (F, 5216), (G, -9755), (H, -7464)
Parsed Result: -372583341440813
Optimized Result: -372583341440813
```

## OptimizerTests (B*1,B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "((A/B)*(((C*D)*E)*F))+G"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 3951), (B, 4994), (C, -8048), (D, -5780), (E, -8425), (F, 9141), (G, 1920)
Parsed Result: 1920
Optimized Result: 1920
```

## Check Expressions "((A+B+((C*D)+E))*F)+G+((D/H)*I)+J"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 6632), (B, -4332), (C, 4604), (D, 9659), (E, -5101), (F, 2939), (G, 4720), (H, -4756), (I, -4759), (J, -8604)
Parsed Result: 130689209299
Optimized Result: 130689209299
```

## OptimizerTests (0+B,B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

## Check Expressions "A*(B/C)+D"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -2843), (B, -3358), (C, 8200), (D, -6155)
Parsed Result: -6155
Optimized Result: -6155
```

## OptimizerTests (0^B,0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 2204), (B, 7758), (C, 2278), (D, -9856), (E, -5215), (F, 8193), (G, 6395)
Parsed Result: -959293898485765
Optimized Result: -959293898485765
```

## OptimizerTests (B%-1,0)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## OptimizerTests (B-0,B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "A*1"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 2698)
Parsed Result: 2698
Optimized Result: 2698
```

## OptimizerTests (0-B,-B)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## PoorlyFormedExpressions (B*-*A)

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Just variable

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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

## Check Expressions "(A+B)*C+D+(A+B)*E+F"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, -609), (B, 1804), (C, 9173), (D, 9586), (E, 8855), (F, -5486)
Parsed Result: 21547560
Optimized Result: 21547560
```

## Check Expressions "((A-(B*C))*D)+E"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.9.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 3303), (B, 111), (C, 4484), (D, -8657), (E, -9506)
Parsed Result: 4280193091
Optimized Result: 4280193091
```

## Links

* [Back to Summary](../Summary.md)
* [Table of Contents](../../TOC.md)
