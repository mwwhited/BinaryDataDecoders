# MorseCodeTests.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.ToolKit.Tests/Codecs/MorseCodeTests.cs

## Public Class - MorseCodeTests

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
 - "Hello, World!"
 - ,
 - ".... . .-.. .-.. ---  .-- --- .-. .-.. -.."
 - )
 - DataRow
 - (
 - "hello world"
 - ,
 - ".... . .-.. .-.. ---  .-- --- .-. .-.. -.."
 - )
 - DataRow
 - (
 - "abcdefghijklmnopqrstuvwxyz1234567890"
 - ,
 - ".- -... -.-. -.. . ..-. --. .... .. .--- -.- .-.. -- -. --- .--. --.- .-. ... - ..- ...- .-- -..- -.-- --.. .---- ..--- ...-- ....- ..... -.... --... ---.. ----. -----"
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
 - string expected 

#### Public Method - DecodeTest

##### Attributes

 - DataTestMethod
 - DataRow
 - (
 - ".... . .-.. .-.. ---  .-- --- .-. .-.. -.."
 - ,
 - "HELLO WORLD"
 - )
 - DataRow
 - (
 - ".- -... -.-. -.. . ..-. --. .... .. .--- -.- .-.. -- -. --- .--. --.- .-. ... - ..- ...- .-- -..- -.-- --..  .---- ..--- ...-- ....- ..... -.... --... ---.. ----. -----"
 - ,
 - "ABCDEFGHIJKLMNOPQRSTUVWXYZ 1234567890"
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
 - string expected 

