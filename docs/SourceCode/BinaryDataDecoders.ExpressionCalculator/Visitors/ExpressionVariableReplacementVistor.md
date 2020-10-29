# ExpressionVariableReplacementVistor.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.ExpressionCalculator\Visitors\ExpressionVariableReplacementVistor.cs

## Public Class - ExpressionVariableReplacementVistor

### Members

#### Public Method - Visit

#####  Parameters

 - ExpressionBase < T > expression 
 - IEnumerable < ( string input , string output ) > variables 

#### Public Method - Visit

#####  Parameters

 - ExpressionBase < T > expression 
 - IEnumerable < ( string name , T value ) > variables 

#### Public Method - Visit

#####  Parameters

 - ExpressionBase < T > expression 
 - IEnumerable < ( string name , ExpressionBase < T > value ) > variables 

#### Private Method - CheckVariable

#####  Parameters

 - VariableExpression < T > variable 
 - IEnumerable < ( string name , T value ) > variables 

#### Private Method - CheckVariable

#####  Parameters

 - VariableExpression < T > variable 
 - IEnumerable < ( string name , ExpressionBase < T > value ) > variables 

