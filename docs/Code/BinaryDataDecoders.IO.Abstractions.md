# Assembly - BinaryDataDecoders.IO.Abstractions

## Type - BinaryDataDecoders.IO.Messages.MessageMatchPatternAttribute

*summary*
prefix pattern to identify decoding patterns

### Method - #ctor(System.String)

*summary*
attribute to assign expected prefix to related structure

*param*
prefix pattern to identify decoding patterns

| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | pattern                                                      | 

### Property - Mask

*summary*
prefix pattern to identify decoding patterns

### Property - Pattern

*summary*
prefix pattern to identify decoding patterns

### Property - Priority

*summary*
override check order

## Type - BinaryDataDecoders.IO.Pipelines.OnPipelineError

*summary*
Delegate declaration for Pipeline Exceptions

*param*
object that caused the exception

| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | sender                                                       | 

*param*
exception received by noted object

| Key                  | Value                                                        |
| :------------------- | :----------------------------------------------------------- |
| name                 | exception                                                    | 

*returns*
continuation option

## Type - BinaryDataDecoders.IO.Ports.Parity

*summary*
parity configuration

### Field - Even

*summary*
Sets the parity bit so that the count of bits set is an even number.

### Field - Mark

*summary*
Leaves the parity bit set to 1.

### Field - None

*summary*
No parity check occurs.

### Field - Odd

*summary*
Sets the parity bit so that the count of bits set is an odd number.

### Field - Space

*summary*
Leaves the parity bit set to 0.

## Type - BinaryDataDecoders.IO.Ports.SerialPortAttribute

*summary*
Attribute for binary decoder to detail default serial configurations

### Property - BaudRate

*summary*
Default Baud Rate

### Property - DataBits

*summary*
Default bitwidth

### Property - Parity

*summary*
Default parity bit

### Property - StopBits

*summary*
Default stop bits

## Type - BinaryDataDecoders.IO.Ports.StopBits

*summary*
Enumeration to identity stop bits

### Field - None

*summary*
No stop bits are used. This value is not supported by the System.IO.Ports.SerialPort.StopBits property.

### Field - One

*summary*
"One stop bit is used.

### Field - OnePointFive

*summary*
1.5 stop bits are used.

### Field - Two

*summary*
Two stop bits are used.

