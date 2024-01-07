# TestTargetAttribute.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.TestUtilities/TestTargetAttribute.cs

## Public Class - TestTargetAttribute

### Comments

 <summary>
 This attribute may be used to mark what Class/Member is covered by a particular test method
 </summary>
 <remarks>
 create and instance of TestTargetAttribute
 </remarks>
 <paramname="class">type of related class</param>

### Attributes

 - AttributeUsage
 - (
 - AttributeTargets
 - .
 - Class
 - |
 - AttributeTargets
 - .
 - Method
 - )

### Members

#### Public Property - Class

##### Comments

 <summary>
 required type reference for related test
 </summary>

##### Summary

 * Type:   < summary > 
  required type reference for related test 
   </ summary > 
  Type 

#### Public Property - Member

##### Comments

 <summary>
 optional member mapping for related test
 </summary>

##### Summary

 * Type:   < summary > 
  optional member mapping for related test 
   </ summary > 
  string ? 

