# BigEndianUShort.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.ToolKit/BigEndianUShort.cs

## Public Structure - BigEndianUShort

### Comments

 <summary>
 Structure type to support conversion from unsigned Big Endian 16bit values
 </summary>

### Attributes

 - StructLayout
 - (
 - LayoutKind
 - .
 - Explicit
 - ,
 - Size
 - =
 - 0x2
 - )

### Members

#### Public Constructor - BigEndianUShort

##### Comments

 <summary>
 convert little endian 16bit value to big endian
 </summary>
 <paramname="input"></param>

#####  Parameters

 - ushort input 

#### Public Constructor - BigEndianUShort

##### Comments

 <summary>
 create unsigned big endian 16bit from ReadOnlySpan&lt;byte&gt;
 </summary>
 <paramname="input"></param>

#####  Parameters

 - ReadOnlySpan < byte > input 

#### Public ReadOnly Field - HH

##### Comments

 <summary>
 High byte for big Endian 16bit value
 </summary>

##### Attributes

 - FieldOffset
 - (
 - 0
 - )

##### Summary

 * Type: 

#### Public ReadOnly Field - LL

##### Comments

 <summary>
 Low byte for big Endian 16bit value
 </summary>

##### Attributes

 - FieldOffset
 - (
 - 1
 - )

##### Summary

 * Type: 

#### Public Property - Value

##### Comments

 <summary>
 Converted big Endian to little Endian
 </summary>

##### Summary

 * Type:   < summary > 
  Converted big Endian to little Endian 
   </ summary > 
  ushort 

#### Public Method - ToString


#### Public Method - Equals

#####  Parameters

 - object ? obj 

#### Public Method - GetHashCode


