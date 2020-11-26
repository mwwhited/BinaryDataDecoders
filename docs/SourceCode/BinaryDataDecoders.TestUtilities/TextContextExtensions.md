# TextContextExtensions.cs

## Summary

* Language: C#
* Path: src/BinaryDataDecoders.TestUtilities/TextContextExtensions.cs

## Public Static Class - TextContextExtensions

### Comments

 <summary>
 Extension methods for TestContext
 </summary>

### Members

#### Public Static Method - AddResult

##### Comments

 <summary>
 serialize and store results to test results folder
 </summary>
 <paramname="context">test context</param>
 <paramname="value">object to store</param>
 <returns>test context for chaining</returns>

#####  Parameters

 - this TestContext context 
 - object value 
 - string fileName = "" 

#### Public Static Method - AddResultFile

##### Comments

 <summary>
 Write out binary content to test results folder and link to test results
 </summary>
 <paramname="context">Related TestContext</param>
 <paramname="fileName">file name for result</param>
 <paramname="content">binary content for file</param>
 <returns>test context for chaining</returns>

#####  Parameters

 - this TestContext context 
 - string fileName 
 - byte [  ] content 

