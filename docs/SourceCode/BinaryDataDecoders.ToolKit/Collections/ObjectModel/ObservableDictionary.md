# ObservableDictionary.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.ToolKit/Collections/ObjectModel/ObservableDictionary.cs

## Public Class - ObservableDictionary

### Members

#### Property - Dictionary

##### Summary

 * Type: IDictionary < TKey , TValue > 

#### Public Constructor - ObservableDictionary


#### Public Constructor - ObservableDictionary

#####  Parameters

 - IDictionary < TKey , TValue > dictionary 

#### Public Constructor - ObservableDictionary

#####  Parameters

 - IEqualityComparer < TKey > comparer 

#### Public Constructor - ObservableDictionary

#####  Parameters

 - int capacity 

#### Public Constructor - ObservableDictionary

#####  Parameters

 - IDictionary < TKey , TValue > dictionary 
 - IEqualityComparer < TKey > comparer 

#### Public Constructor - ObservableDictionary

#####  Parameters

 - int capacity 
 - IEqualityComparer < TKey > comparer 

#### Public Method - Add

#####  Parameters

 - TKey key 
 - TValue value 

#### Public Method - ContainsKey

#####  Parameters

 - TKey key 

#### Public Property - Keys

##### Summary

 * Type: ICollection < TKey > 

#### Public Method - TryGetValue

#####  Parameters

 - TKey key 
 - out TValue value 

#### Public Property - Values

##### Summary

 * Type: ICollection < TValue > 

#### Public Method - Contains

#####  Parameters

 - KeyValuePair < TKey , TValue > item 

#### Public Method - CopyTo

#####  Parameters

 - KeyValuePair < TKey , TValue > [  ] array 
 - int arrayIndex 

#### Public Property - Count

##### Summary

 * Type: int 

#### Public Property - IsReadOnly

##### Summary

 * Type: bool 

#### Public Method - Remove

#####  Parameters

 - KeyValuePair < TKey , TValue > item 

#### Public Method - Remove

#####  Parameters

 - TKey key 

#### Public Method - Add

#####  Parameters

 - KeyValuePair < TKey , TValue > item 

#### Public Method - Clear


#### Public Method - GetEnumerator


#### Method - GetEnumerator


#### Public Method - AddRange

#####  Parameters

 - IDictionary < TKey , TValue > items 

#### Private Method - Insert

#####  Parameters

 - TKey key 
 - TValue value 
 - bool add 

#### Private Field - IndexerName

##### Summary

 * Type: 

#### Private Method - OnPropertyChanged


#### Method - OnPropertyChanged

#####  Parameters

 - string propertyName 

#### Private Method - OnCollectionChanged


#### Private Method - OnCollectionChanged

#####  Parameters

 - NotifyCollectionChangedAction action 
 - KeyValuePair < TKey , TValue > changedItem 

#### Private Method - OnCollectionChanged

#####  Parameters

 - NotifyCollectionChangedAction action 
 - KeyValuePair < TKey , TValue > newItem 
 - KeyValuePair < TKey , TValue > oldItem 

#### Private Method - OnCollectionChanged

#####  Parameters

 - NotifyCollectionChangedAction action 
 - IList newItems 

