# TaskEx.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.ToolKit/Threading/Tasks/TaskEx.cs

## Public Static Class - TaskEx

### Comments

 <summary>
 Execute's an async Task<T> method which has a void return value synchronously
 </summary>
 <paramname="task">Task<T> method to execute</param>

### Members

#### Public Static Method - RunSync

##### Comments

 <summary>
 Execute's an async Task<T> method which has a void return value synchronously
 </summary>
 <paramname="task">Task<T> method to execute</param>

#####  Parameters

 - this Func < Task > task 

#### Public Static Method - RunSync

##### Comments

 <summary>
 Execute's an async Task<T> method which has a T return type synchronously
 </summary>
 <typeparamname="T">Return Type</typeparam>
 <paramname="task">Task<T> method to execute</param>
 <returns></returns>

#####  Parameters

 - this Func < Task < T > > task 

#### Private Field - done

##### Summary

 * Type: 

#### Public Property - InnerException

##### Summary

 * Type: Exception 

#### ReadOnly Field - workItemsWaiting

##### Summary

 * Type: AutoResetEvent 

#### ReadOnly Field - items

##### Summary

 * Type: 

#### Public Method - Send

#####  Parameters

 - SendOrPostCallback d 
 - object state 

#### Public Method - Post

#####  Parameters

 - SendOrPostCallback d 
 - object state 

#### Public Method - EndMessageLoop


#### Public Method - BeginMessageLoop


#### Public Method - CreateCopy


## Private Class - ExclusiveSynchronizationContext

### Members

#### Private Field - done

##### Summary

 * Type: 

#### Public Property - InnerException

##### Summary

 * Type: Exception 

#### ReadOnly Field - workItemsWaiting

##### Summary

 * Type: AutoResetEvent 

#### ReadOnly Field - items

##### Summary

 * Type: 

#### Public Method - Send

#####  Parameters

 - SendOrPostCallback d 
 - object state 

#### Public Method - Post

#####  Parameters

 - SendOrPostCallback d 
 - object state 

#### Public Method - EndMessageLoop


#### Public Method - BeginMessageLoop


#### Public Method - CreateCopy


