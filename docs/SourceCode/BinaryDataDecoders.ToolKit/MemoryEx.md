# MemoryEx.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.ToolKit\MemoryEx.cs

## Public Static Class - MemoryEx

### Comments

 <summary>
 Extension methods for System.Memory&lt;&gt;
 </summary>

### Members

#### Public Static Method - AsMemory

#####  Parameters

 - this IEnumerable < char > input 

#### Public Static Method - Distinct

#####  Parameters

 - this IEnumerable < Memory < T > > segments 

#### Public Static Method - BytesFromHexString

#####  Parameters

 - this Memory < char > input 

#### Public Static Method - Split

#####  Parameters

 - this Memory < byte > memory 
 - byte delimiter 
 - DelimiterOptions option = DelimiterOptions . Exclude 

#### Public Static Method - Split

#####  Parameters

 - this Memory < char > memory 
 - char delimiter 
 - DelimiterOptions option = DelimiterOptions . Exclude 

#### Public Static Method - Split

#####  Parameters

 - this Memory < T > memory 
 - T delimiter 
 - DelimiterOptions option = DelimiterOptions . Exclude 

#### Private Static Method - SplitWithExclude

#####  Parameters

 - this Memory < T > memory 
 - T delimiter 

#### Private Static Method - SplitWithReturn

#####  Parameters

 - this Memory < T > memory 
 - T delimiter 

#### Private Static Method - SplitWithCarry

#####  Parameters

 - this Memory < T > memory 
 - T delimiter 

