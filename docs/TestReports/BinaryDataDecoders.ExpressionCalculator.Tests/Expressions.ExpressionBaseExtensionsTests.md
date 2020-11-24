# BinaryDataDecoders.ExpressionCalculator.Tests.Expressions.ExpressionBaseExtensionsTests

## ParseAndReplaceVariablesTest

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::ReplaceVariables
  * BinaryDataDecoders.ExpressionCalculator, Version=0.2.0.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.01

#### Standard Out

```
TestContext Messages:
Input: A+B
As Parsed: A + B
Variables: (A, X), (B, Y)
Result: X + Y
```

## ParseAndEvaluateTest

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::Evaluate
  * BinaryDataDecoders.ExpressionCalculator, Version=0.2.0.0, Culture=neutral, PublicKeyToken=null

### Categories

* Unit

### Results

* Outcome: ✔ Passed
* Duration: 00:00:00.01

#### Standard Out

```
TestContext Messages:
Input: A+B
As Parsed: A + B
Variables: (A, 2.1), (B, 3.4)
Result: 5.5
```

## ParseAndPreEvaluateTest

### Targets

* BinaryDataDecoders.ExpressionCalculator.Expressions::ExpressionBaseExtensions::PreEvaluate
  * BinaryDataDecoders.ExpressionCalculator, Version=0.2.0.0, Culture=neutral, PublicKeyToken=null

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
Variables: (A, 2.1), (B, 3.4)
Result: 2.1 + 3.4
```

## Links

* [Back to Summary](../Summary.md)
* [Table of Contents](../../TOC.md)
