# ReadOnlySpanEx.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.ToolKit/ReadOnlySpanEx.cs

## Public Static Class - ReadOnlySpanEx

### Comments

 <summary>
 Set of extension methods for ReadOnlySpan&lt;&gt;
 </summary>

### Members

#### Public Static Method - StartsWith

##### Comments

 <summary>
 simple extension to allow using ReadOnlySpan&lt;&gt;.StartsWith(...) with an array
 </summary>
 <paramname="data"></param>
 <paramname="pattern"></param>
 <returns></returns>

#####  Parameters

 - this ReadOnlySpan < byte > data 
 - params byte [  ] pattern 

#### Public Static Method - CopyWithTransform

##### Comments

 <summary>
  transform provided ReadOnlySpan<typeparamrefname="TIn"/> into a new Span<typeparamrefname="TOut"/>
 </summary>
 <typeparamname="TIn"></typeparam>
 <typeparamname="TOut"></typeparam>
 <paramname="input"></param>
 <paramname="transform"></param>
 <returns></returns>

#####  Parameters

 - this ReadOnlySpan < TIn > input 
 - Func < TIn , TOut > transform 

#### Public Static Method - CopyToWithTransform

##### Comments

 <summary>
 transform provided ReadOnlySpan<typeparamrefname="TIn"/> into Existing Span<typeparamrefname="TOut"/>
 </summary>
 <typeparamname="TIn"></typeparam>
 <typeparamname="TOut"></typeparam>
 <paramname="input"></param>
 <paramname="target"></param>
 <paramname="transform"></param>

#####  Parameters

 - this ReadOnlySpan < TIn > input 
 - Span < TOut > target 
 - Func < TIn , TOut > transform 

