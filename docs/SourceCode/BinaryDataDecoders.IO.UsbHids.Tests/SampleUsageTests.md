# SampleUsageTests.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.IO.UsbHids.Tests/SampleUsageTests.cs

## Public Class - SampleUsageTests

### Attributes

 - TestClass

### Members

#### Public Property - TestContext

##### Summary

 * Type: TestContext 

#### Public Method - ListDevicesTests

##### Attributes

 - TestMethod
 - TestCategory
 - (
 - TestCategories
 - .
 - DevLocal
 - )


#### Public Method - ListenToDeviceTests

##### Attributes

 - DataTestMethod
 - TestCategory
 - (
 - TestCategories
 - .
 - DevLocal
 - )
 - DataRow
 - (
 - 4451
 - ,
 - 512
 - ,
 - DisplayName
 - =
 - "DeLorme Publishing DeLorme USB Earthmate"
 - )
 - DataRow
 - (
 - 0x10cf
 - ,
 - 0x5500
 - ,
 - 0xfff8
 - ,
 - DisplayName
 - =
 - "Velleman K8055"
 - )
 - DataRow
 - (
 - 0xfc02
 - ,
 - 0x0101
 - ,
 - DisplayName
 - =
 - "Midi Controller"
 - )

#####  Parameters

 - int vendorId 
 - int productId 
 - int productMask = 0xffff 

