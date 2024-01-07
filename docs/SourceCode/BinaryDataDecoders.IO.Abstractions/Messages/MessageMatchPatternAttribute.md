# MessageMatchPatternAttribute.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.IO.Abstractions/Messages/MessageMatchPatternAttribute.cs

## Public Class - MessageMatchPatternAttribute

### Comments

 <summary>
 prefix pattern to identify decoding patterns
 </summary>
 <remarks>
 attribute to assign expected prefix to related structure
 </remarks>
 <paramname="pattern">prefix pattern to identify decoding patterns
 <code>
     allowed characters: matches on a nibble
         0 to F hexadecimal value
         period (.), asterisk (*), or question (?) may be used for wild cards
         other characters are ignored
 </code>
 </param>

### Attributes

 - AttributeUsage
 - (
 - AttributeTargets
 - .
 - Struct
 - ,
 - AllowMultiple
 - =
 - true
 - )

### Members

#### Public Property - Pattern

##### Comments

 <summary>
 prefix pattern to identify decoding patterns
 </summary>

##### Summary

 * Type:   < summary > 
  prefix pattern to identify decoding patterns 
   </ summary > 
  string 

#### Public Property - Mask

##### Comments

 <summary>
 prefix pattern to identify decoding patterns
 </summary>

##### Summary

 * Type:   < summary > 
  prefix pattern to identify decoding patterns 
   </ summary > 
  string ? 

#### Public Property - Priority

##### Comments

 <summary>
 override check order
 </summary>

##### Summary

 * Type:   < summary > 
  override check order 
   </ summary > 
  int 

