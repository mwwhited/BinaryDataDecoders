# Reusable Input/Output Library


## StreamSegmentPipeline

When trying to handle binary streams of data often the data is transmitted asynchronously and is not natively 
usable by your application.  The intent of this component is to take I/O streams and compose them in a fashion 
where they are recomposed in a way the application may process the data.

+-----------+
|  Handler  |
+-----------+
| Segmenter |
+-----------+
|  Stream   |
+-----------+
 

## General Notes for CancelationToken

https://docs.microsoft.com/en-us/dotnet/standard/threading/cancellation-in-managed-threads