# ReversableEnumerator.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.ToolKit/Collections/ReversableEnumerator.cs

## Public Class - ReversableEnumerator

### Comments

 <summary>
 this is a enumerator is bidirectional
 </summary>
 <typeparamname="T"></typeparam>
 <remarks>
 Wrap existing IEnumerator
 </remarks>
 <paramname="base"></param>

### Attributes

 - DebuggerDisplay
 - (
 - "{Current.ToString()}::{_position}"
 - )

### Members

#### Private Field - ResetPosition

##### Summary

 * Type: 

#### Private ReadOnly Field - _lock

##### Summary

 * Type: 

#### Private Field - _pointer

##### Summary

 * Type: 

#### Private Field - _reset

##### Summary

 * Type: 

#### Private Field - _end

##### Summary

 * Type: 

#### Private Field - _position

##### Summary

 * Type: 

#### Public Property - Position

##### Summary

 * Type: int 

#### Public Constructor - ReversableEnumerator

##### Comments

 <summary>
 Wrap existing IEnumerable
 </summary>
 <paramname="base"></param>

#####  Parameters

 - IEnumerable < T > @base 

#### Public Property - Current

##### Summary

 * Type: T 

#### Property - Current

##### Summary

 * Type: object # pragma warning disable CS8603  IEnumerator . 

#### Public Method - Dispose

##### Comments

 <summary>
 free any underlying resources
 </summary>


#### Public Method - MoveNext

##### Comments

 <summary>
 allow playing to end of current state before checking for new values in enumerable set.
 </summary>
 <returns>true if advanced</returns>


#### Public Method - MoveCurrent


#### Public Method - MovePrevious

##### Comments

 <summary>
 if the enumerator has been advanced it may be stepped back here.
 </summary>
 <returns>true if stepped back</returns>


#### Public Method - Reset

##### Comments

 <summary>
 if the rewind to the beginning.
 </summary>


