# IReversibleEnumerator.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.ToolKit\Collections\IReversibleEnumerator.cs

## Public Interface - IReversibleEnumerator

### Comments

 <summary>
 Allow an Enumerable to move forwards or backwards
 </summary>
 <typeparamname="T"></typeparam>

### Members

#### Method - MovePrevious

##### Comments

 <summary>
 step current state of enumerator to previous element
 </summary>
 <returns>true if move was possible</returns>


#### Property - Position

##### Comments

 <summary>
 current position of enumerator.  -1 if before head/reset
 </summary>

##### Summary

 * Type: int   < summary > 
  current position of enumerator.  -1 if before head/reset 
   </ summary > 
  

#### Method - MoveCurrent

##### Comments

 <summary>
 move enumerator last of previouslly read elements
 </summary>
 <returns>true if move was possible</returns>


