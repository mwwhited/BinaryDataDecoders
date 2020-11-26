# InnerExpressionReducer.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.ExpressionCalculator/Optimizers/InnerExpressionReducer.cs

## Public Class - InnerExpressionReducer

### Comments

 <summary>
 this will remove extra wraps around the entire expression
 ((a)+(b)) => a+b
 </summary>
 <typeparamname="T"></typeparam>

### Members

#### Public Method - Optimize

#####  Parameters

 - ExpressionBase < T > expression 

#### Private Method - Optimize

#####  Parameters

 - BinaryOperatorExpression < T > expression 

#### Private Method - Optimize

#####  Parameters

 - BinaryOperators parentOperator 
 - ExpressionBase < T > expression 

#### Private Method - Optimize

#####  Parameters

 - BinaryOperators parentOperator 
 - BinaryOperatorExpression < T > expression 

