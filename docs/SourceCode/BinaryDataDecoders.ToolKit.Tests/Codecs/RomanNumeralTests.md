﻿# RomanNumeralTests.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.ToolKit.Tests/Codecs/RomanNumeralTests.cs

## Public Class - RomanNumeralTests

### Attributes

 - TestClass

### Members

#### Public Property - TestContext

##### Summary

 * Type: TestContext 

#### Public Method - Convert_ToRomanNumeralTest

##### Attributes

 - DataTestMethod
 - DataRow
 - (
 - 1
 - ,
 - "I"
 - )
 - DataRow
 - (
 - 2
 - ,
 - "II"
 - )
 - DataRow
 - (
 - 4
 - ,
 - "IV"
 - )
 - DataRow
 - (
 - 5
 - ,
 - "V"
 - )
 - DataRow
 - (
 - 6
 - ,
 - "VI"
 - )
 - DataRow
 - (
 - 9
 - ,
 - "IX"
 - )
 - DataRow
 - (
 - 10
 - ,
 - "X"
 - )
 - DataRow
 - (
 - 11
 - ,
 - "XI"
 - )
 - DataRow
 - (
 - 40
 - ,
 - "XL"
 - )
 - DataRow
 - (
 - 50
 - ,
 - "L"
 - )
 - DataRow
 - (
 - 40
 - ,
 - "XL"
 - )
 - DataRow
 - (
 - 1982
 - ,
 - "MCMLXXXII"
 - )
 - DataRow
 - (
 - 2000
 - ,
 - "MM"
 - )
 - DataRow
 - (
 - 2023
 - ,
 - "MMXXIII"
 - )
 - DataRow
 - (
 - 1234567
 - ,
 - "/M/C/C/X/X/XM/VDLXVII"
 - )
 - TestMethod
 - TestCategory
 - (
 - TestCategories
 - .
 - Unit
 - )

#####  Parameters

 - int value 
 - string expected 

#### Public Method - Convert_ToNumberTest

##### Attributes

 - DataTestMethod
 - DataRow
 - (
 - "I"
 - ,
 - 1
 - )
 - DataRow
 - (
 - "II"
 - ,
 - 2
 - )
 - DataRow
 - (
 - "IV"
 - ,
 - 4
 - )
 - DataRow
 - (
 - "V"
 - ,
 - 5
 - )
 - DataRow
 - (
 - "VI"
 - ,
 - 6
 - )
 - DataRow
 - (
 - "IX"
 - ,
 - 9
 - )
 - DataRow
 - (
 - "X"
 - ,
 - 10
 - )
 - DataRow
 - (
 - "XI"
 - ,
 - 11
 - )
 - DataRow
 - (
 - "XL"
 - ,
 - 40
 - )
 - DataRow
 - (
 - "L"
 - ,
 - 50
 - )
 - DataRow
 - (
 - "XL"
 - ,
 - 40
 - )
 - DataRow
 - (
 - "MCMLXXXII"
 - ,
 - 1982
 - )
 - DataRow
 - (
 - "MM"
 - ,
 - 2000
 - )
 - DataRow
 - (
 - "MMXXIII"
 - ,
 - 2023
 - )
 - DataRow
 - (
 - "/M/C/C/X/X/XM/VDLXVII"
 - ,
 - 1234567
 - )
 - TestMethod
 - TestCategory
 - (
 - TestCategories
 - .
 - Unit
 - )

#####  Parameters

 - string value 
 - int expected 
