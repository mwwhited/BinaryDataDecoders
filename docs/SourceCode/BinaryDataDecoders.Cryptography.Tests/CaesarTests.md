# CaesarTests.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.Cryptography.Tests/CaesarTests.cs

## Public Class - CaesarTests

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
 - 'H'
 - ,
 - "Olssv Dvysk"
 - )
 - DataRow
 - (
 - "Hello, World"
 - ,
 - 'H'
 - ,
 - "Olssv, Dvysk"
 - )
 - DataRow
 - (
 - "hello, world"
 - ,
 - 'h'
 - ,
 - "olssv, dvysk"
 - )
 - DataRow
 - (
 - "hello world"
 - ,
 - 'C'
 - ,
 - "jgnnq yqtnf"
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
 - char key 
 - string expected 

#### Public Method - DecodeTest

##### Attributes

 - DataTestMethod
 - DataRow
 - (
 - "Olssv Dvysk"
 - ,
 - 'H'
 - ,
 - "Hello World"
 - )
 - DataRow
 - (
 - "Olssv, Dvysk"
 - ,
 - 'H'
 - ,
 - "Hello, World"
 - )
 - DataRow
 - (
 - "olssv, dvysk"
 - ,
 - 'h'
 - ,
 - "hello, world"
 - )
 - DataRow
 - (
 - "jgnnq yqtnf"
 - ,
 - 'C'
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
 - char key 
 - string expected 

