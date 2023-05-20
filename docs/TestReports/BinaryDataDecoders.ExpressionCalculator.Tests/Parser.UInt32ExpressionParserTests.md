# BinaryDataDecoders.ExpressionCalculator.Tests.Parser.UInt32ExpressionParserTests

## Just decimal value

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

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
Variables: (A, 9)
Parsed Result: 362880
Optimized Result: 362880
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
Variables: (A, 4294963290), (B, 7780), (C, 4294965974), (D, 5269), (E, 4294962378), (F, 3711), (G, 4294962911)
Parsed Result: 563046267
Optimized Result: 563046267
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
Variables: (A, 4294962525), (B, 4294959303), (C, 4294966494), (D, 4294963841), (E, 8221), (F, 1398), (G, 4294959145), (H, 5482)
Parsed Result: 3298273678
Optimized Result: 3298273678
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

## Check Expressions "((((((A-B-1E-06)/C)+0.999999)/1000000)*1000000)*((D*E)*F)*G)+H"

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Optimize
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

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
Variables: (A, 4294967208), (B, 4700), (C, 4294960269), (D, 4294958815), (E, 6016), (F, 9597)
Parsed Result: 700905597
Optimized Result: 700905597
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
Variables: (A, 5172), (B, 4294958685), (C, 4294962760), (D, 4294967158), (E, 186), (F, 2413)
Parsed Result: 2413
Optimized Result: 2413
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
Variables: (A, 5305), (B, 4294966295), (C, 4061), (D, 2), (E, 4294960311), (F, 4294964252)
Parsed Result: 4282379358
Optimized Result: 4282379358
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
Variables: (A, 7197)
Parsed Result: 7197
Optimized Result: 7197
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
As Optimized: 4294967290
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
Variables: (A, 5864), (B, 4294963817), (C, 5832), (D, 3234)
Parsed Result: 3234
Optimized Result: 3234
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
Variables: (A, 4294965471), (B, 4294966255), (C, 4489), (D, 4294960890), (E, 4115)
Parsed Result: 931279988
Optimized Result: 931279988
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
Variables: (A, 8431), (B, 8140), (C, 2731), (D, 4294958815), (E, 6162), (F, 4277), (G, 4294958058), (H, 6237)
Parsed Result: 339115210
Optimized Result: 339115210
```

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
Variables: (A, 4294959239), (B, 6450), (C, 4294958803), (D, 4294964440)
Parsed Result: 4294964440
Optimized Result: 4294964440
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
Variables: (A, 3676), (B, 5077), (C, 4294958830), (D, 4294961614)
Parsed Result: 912386038
Optimized Result: 912386038
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
Variables: (A, 8763), (B, 4294959956)
Parsed Result: 1
Optimized Result: 1
```

## OptimizerTests (N!!!,N!!!)

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
Input: N!!!
As Parsed: N!!!
As Optimized: N!!!
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

## Parse Complex Expression

### Targets

* BinaryDataDecoders.ExpressionCalculator.Parser::ExpressionParser`1::Parse
  * BinaryDataDecoders.ExpressionCalculator, Version=0.4.7.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ⚠ Inconclusive
* Duration: 00:00:00.00

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
Variables: (A, 2939), (B, 4294958936), (C, 4294962188)
Parsed Result: 4270392148
Optimized Result: 4270392148
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
Variables: (A, 4294959276), (B, 4294962599)
Parsed Result: 1
Optimized Result: 1
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
Variables: (A, 4294961427), (B, 4294963713), (C, 6092), (D, 818), (E, 2431)
Parsed Result: 147202820
Optimized Result: 147202820
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
Variables: (A, 2096), (B, 1464), (C, 2860)
Parsed Result: 3071404
Optimized Result: 3071404
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
Variables: (A, 9965), (B, 536), (C, 5173), (D, 4294962409), (E, 4294960736)
Parsed Result: 3936844181
Optimized Result: 3936844181
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

## OptimizerTests (3!!,720)

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
Input: 3!!
As Parsed: 3!!
As Optimized: 720
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
Variables: (A, 9926), (B, 4294963045), (C, 5259), (D, 4954), (E, 4294958375)
Parsed Result: 3426650669
Optimized Result: 3426650669
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
Variables: (A, 1521), (B, 4294965851), (C, 4294962697), (D, 6204), (E, 6828), (F, 7351)
Parsed Result: 7351
Optimized Result: 7351
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
Variables: (A, 4294962549), (B, 4294965037), (C, 4294963215), (D, 9440), (E, 4294966083), (F, 4002), (G, 6656), (H, 4295), (I, 4592)
Parsed Result: 173089470
Optimized Result: 173089470
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
Variables: (A, 6375)
Parsed Result: 6375
Optimized Result: 6375
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
Variables: (A, 4294964107), (B, 1964), (C, 4294959361), (D, 4294967253), (E, 5903), (F, 4294963182), (G, 4294963918), (H, 4294966148)
Parsed Result: 803472028
Optimized Result: 803472028
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
Variables: (A, 3766), (B, 4473)
Parsed Result: 16845318
Optimized Result: 16845318
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
Variables: (A, 5803), (B, 5151), (C, 4294967090), (D, 4550), (E, 4294963587), (F, 8818)
Parsed Result: 3476454518
Optimized Result: 3476454518
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
Variables: (A, 7708), (B, 8662), (C, 4294966704), (D, 4294965743), (E, 4294961061), (F, 4294961201)
Parsed Result: 1178697523
Optimized Result: 1178697523
```

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
Variables: (A, 4294964111), (B, 4294965269), (C, 4294960991), (D, 4294964891), (E, 4294958054), (F, 4294966605), (G, 6308), (H, 4294963808)
Parsed Result: 2158715400
Optimized Result: 2158715400
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
Variables: (A, 8633), (B, 4294966729), (C, 4294961524), (D, 4294957303), (E, 6096), (F, 2017), (G, 2263)
Parsed Result: 2263
Optimized Result: 2263
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
Variables: (A, 3832)
Parsed Result: 3832
Optimized Result: 3832
```

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
Variables: (A, 247), (B, 4448), (C, 4294964623), (D, 7849), (E, 4294963775), (F, 3418), (G, 4294958344), (H, 4294961432)
Parsed Result: 850112140
Optimized Result: 850112140
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
Variables: (A, 3933), (B, 8588), (C, 4294957890), (D, 4405), (E, 4294964648), (F, 4294962578)
Parsed Result: 4246403554
Optimized Result: 4246403554
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
Variables: (A, 4294957814), (B, 4294962221), (C, 4294965205), (D, 4294958490)
Parsed Result: 2525700660
Optimized Result: 2525700660
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
Variables: (A, 4294965756), (B, 4294964940), (C, 6102), (D, 4294962030), (E, 6084), (F, 5985), (G, 5401), (H, 4294962295), (I, 9133), (J, 4294958936)
Parsed Result: 969825521
Optimized Result: 969825521
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
Variables: (A, 8766), (B, 4294965069)
Parsed Result: 6539
Optimized Result: 6539
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
Variables: (A, 4294964799), (B, 4294963480), (C, 4294963716), (D, 4294963109), (E, 4294962152), (F, 3407)
Parsed Result: 9505
Optimized Result: 9505
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
Variables: (A, 4575), (B, 4294959368), (C, 4294960061), (D, 4294957866), (E, 6921)
Parsed Result: 38490126
Optimized Result: 38490126
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
Variables: (A, 4294960815), (B, 4294960732), (C, 4294959515), (D, 4294963959), (E, 2390), (F, 2699), (G, 4499), (H, 4294966671)
Parsed Result: 1750462807
Optimized Result: 1750462807
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
Variables: (A, 4294963166), (B, 4275), (C, 9611), (D, 2699), (E, 6250), (F, 5889)
Parsed Result: 5889
Optimized Result: 5889
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

## OptimizerTests (N!!,N!!)

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
Input: N!!
As Parsed: N!!
As Optimized: N!!
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
Variables: (A, 7380), (B, 4294966177), (C, 1198), (D, 4294966192)
Parsed Result: 688329060
Optimized Result: 688329060
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
Variables: (A, 4294963940), (B, 4294960261), (C, 4294961705), (D, 4294958625)
Parsed Result: 58087410
Optimized Result: 58087410
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
Variables: (A, 2582), (B, 4294959525)
Parsed Result: 4274902574
Optimized Result: 4274902574
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
Variables: (A, 4294963436), (B, 4294957995), (C, 4294964388), (D, 4294966884)
Parsed Result: 4279144456
Optimized Result: 4279144456
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

## OptimizerTests (2!!!,2)

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
Input: 2!!!
As Parsed: 2!!!
As Optimized: 2
```

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
Variables: (A, 4294957516), (B, 4294965883), (C, 4294962236), (D, 9423)
Parsed Result: 3089605055
Optimized Result: 3089605055
```

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
Variables: (A, 4294963236), (B, 4294960253), (C, 4294959132), (D, 1118), (E, 4294957653), (F, 2698), (G, 2195)
Parsed Result: 172470179
Optimized Result: 172470179
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
Variables: (A, 5615), (B, 4294959608), (C, 6433), (D, 8833), (E, 7217)
Parsed Result: 179722169
Optimized Result: 179722169
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
Variables: (A, 6531), (B, 4294967010), (C, 4294963667), (D, 4294964417), (E, 4294966757), (F, 2318)
Parsed Result: 2318
Optimized Result: 2318
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

## Links

* [Back to Summary](../Summary.md)
* [Table of Contents](../../TOC.md)
