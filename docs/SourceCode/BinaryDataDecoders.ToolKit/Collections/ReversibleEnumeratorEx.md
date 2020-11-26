# ReversibleEnumeratorEx.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.ToolKit/Collections/ReversibleEnumeratorEx.cs

## Public Static Class - ReversibleEnumeratorEx

### Comments

 <summary>
 
 </summary>
 <typeparamname="T"></typeparam>
 <paramname="current"></param>
 <returns></returns>

### Members

#### Public Static Method - Rewind

##### Comments

 <summary>
 
 </summary>
 <typeparamname="T"></typeparam>
 <paramname="current"></param>
 <returns></returns>

#####  Parameters

 - this IReversibleEnumerator < T > current 

#### Public Static Method - FastForward

##### Comments

 <summary>
 move to last element in cache
 </summary>
 <typeparamname="T"></typeparam>
 <paramname="current"></param>
 <returns></returns>

#####  Parameters

 - this IReversibleEnumerator < T > current 

#### Public Static Method - FastForwardToEnd

##### Comments

 <summary>
 move to last element in IDoubleLinkedList
 </summary>
 <typeparamname="T"></typeparam>
 <paramname="current"></param>
 <returns></returns>

#####  Parameters

 - this IReversibleEnumerator < T > current 

#### Public Static Method - Offset

##### Comments

 <summary>
 try moving to realative position
 </summary>
 <typeparamname="T"></typeparam>
 <paramname="current"></param>
 <paramname="count"></param>
 <returns></returns>

#####  Parameters

 - this IReversibleEnumerator < T > current 
 - int count 

#### Public Static Method - Back

##### Comments

 <summary>
 move backwards at least count steps
 </summary>
 <typeparamname="T"></typeparam>
 <paramname="current"></param>
 <paramname="count"></param>
 <returns></returns>

#####  Parameters

 - this IReversibleEnumerator < T > current 
 - int count 

#### Public Static Method - Forward

##### Comments

 <summary>
 move forwards at least count steps
 </summary>
 <typeparamname="T"></typeparam>
 <paramname="current"></param>
 <paramname="count"></param>
 <returns></returns>

#####  Parameters

 - this IReversibleEnumerator < T > current 
 - int count 

