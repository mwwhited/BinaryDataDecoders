# ExpressionBaseExtensions.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.ExpressionCalculator\Expressions\ExpressionBaseExtensions.cs

## Public Static Class - ExpressionBaseExtensions

### Members

#### Public Static Method - Optimize

#####  Parameters

 - this ExpressionBase < T > expression 

#### Public Static Method - EmptySet


#### Public Static Method - GetAllExpressions

#####  Parameters

 - this ExpressionBase < T > expression 

#### Public Static Method - Evaluate

#####  Parameters

 - this ExpressionBase < T > expression 
 - IEnumerable < ( string name , T value ) > variables 

#### Public Static Method - Evaluate

#####  Parameters

 - this ExpressionBase < T > expression 
 - params ( string name , T value ) [  ] variables 

#### Public Static Method - GetDistinctVariableNames

#####  Parameters

 - this ExpressionBase < T > expression 

#### Public Static Method - GenerateTestValues

#####  Parameters

 - this ExpressionBase < T > expression 
 - int scale = 4 
 - bool includeNegatives = false 
 - int places = 2 

#### Public Static Method - ParseAsExpression

#####  Parameters

 - this string input 

#### Public Static Method - ReplaceVariables

#####  Parameters

 - this ExpressionBase < T > expression 
 - IEnumerable < ( string input , string output ) > variables 

#### Public Static Method - ReplaceVariables

#####  Parameters

 - this ExpressionBase < T > expression 
 - params ( string input , string output ) [  ] variables 

#### Public Static Method - PreEvaluate

#####  Parameters

 - this ExpressionBase < T > expression 
 - IEnumerable < ( string name , T value ) > variables 

#### Public Static Method - PreEvaluate

#####  Parameters

 - this ExpressionBase < T > expression 
 - params ( string name , T value ) [  ] variables 

#### Public Static Method - PreEvaluate

#####  Parameters

 - this ExpressionBase < T > expression 
 - IEnumerable < ( string name , ExpressionBase < T > value ) > variables 

#### Public Static Method - PreEvaluate

#####  Parameters

 - this ExpressionBase < T > expression 
 - params ( string name , ExpressionBase < T > value ) [  ] variables 

#### Public Static Method - PreEvaluate

#####  Parameters

 - this string expression 
 - IEnumerable < ( string name , ExpressionBase < T > value ) > variables 

#### Public Static Method - PreEvaluate

#####  Parameters

 - this string expression 
 - params ( string name , ExpressionBase < T > value ) [  ] variables 

#### Public Static Method - PreEvaluate

#####  Parameters

 - this string expression 
 - IEnumerable < ( string name , ExpressionBase < decimal > value ) > variables 

#### Public Static Method - PreEvaluate

#####  Parameters

 - this string expression 
 - params ( string name , ExpressionBase < decimal > value ) [  ] variables 

