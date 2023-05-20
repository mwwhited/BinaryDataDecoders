# VigenereTests.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.Cryptography.Tests/VigenereTests.cs

## Public Class - VigenereTests

### Attributes

 - TestClass

### Members

#### Public Property - TestContext

##### Summary

 * Type: TestContext 

#### Public Method - EncodeTest

##### Attributes

 - DataTestMethod
 - DataRow
 - (
 - "Hello World"
 - ,
 - "World"
 - ,
 - "Dscwr Kfcoz"
 - )
 - DataRow
 - (
 - "Hello, World"
 - ,
 - "world"
 - ,
 - "Dscwr, Nzuhr"
 - )
 - DataRow
 - (
 - "hello, world"
 - ,
 - "World"
 - ,
 - "dscwr, nzuhr"
 - )
 - DataRow
 - (
 - "hello world"
 - ,
 - "Hello"
 - ,
 - "oiwwc azczk"
 - )
 - TestMethod
 - TestCategory
 - (
 - TestCategories
 - .
 - Unit
 - )

#####  Parameters

 - string message 
 - string key 
 - string expected 

#### Public Method - DecodeTest

##### Attributes

 - DataTestMethod
 - DataRow
 - (
 - "Dscwr Kfcoz"
 - ,
 - "World"
 - ,
 - "Hello World"
 - )
 - DataRow
 - (
 - "Dscwr, Nzuhr"
 - ,
 - "World"
 - ,
 - "Hello, World"
 - )
 - DataRow
 - (
 - "dscwr, nzuhr"
 - ,
 - "World"
 - ,
 - "hello, world"
 - )
 - DataRow
 - (
 - "oiwwc azczk"
 - ,
 - "Hello"
 - ,
 - "hello world"
 - )
 - TestMethod
 - TestCategory
 - (
 - TestCategories
 - .
 - Unit
 - )

#####  Parameters

 - string message 
 - string key 
 - string expected 

