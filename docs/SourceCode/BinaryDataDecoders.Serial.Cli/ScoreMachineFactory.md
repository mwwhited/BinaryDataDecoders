# ScoreMachineFactory.cs

## Summary

* Language: C#
* Path: src\BinaryDataDecoders.Serial.Cli\ScoreMachineFactory.cs

## Public Class - ScoreMachineFactory

### Members

#### Private ReadOnly Field - _provider

##### Summary

 * Type: PortProvider 

#### Public Constructor - ScoreMachineFactory

#####  Parameters

 - PortProvider provider 

#### Public Method - GetMachineType

#####  Parameters

 - string machine 

#### Public Method - GetPort

#####  Parameters

 - MachineType machine 
 - string portName 

#### Public Method - GetSegmenter

#####  Parameters

 - MachineType machine 
 - OnSegmentReceived received 

#### Public Method - GetParser

#####  Parameters

 - MachineType machine 

