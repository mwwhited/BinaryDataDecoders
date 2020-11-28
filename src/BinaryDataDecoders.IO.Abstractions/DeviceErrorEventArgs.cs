using System;

namespace BinaryDataDecoders.IO
{
    public class DeviceErrorEventArgs : EventArgs
    {
        public DeviceErrorEventArgs(Exception exception, ErrorHandling errorHandling)
        {
            Exception = exception;
            ErrorHandling = errorHandling;
        }

        public Exception Exception { get; }
        public ErrorHandling ErrorHandling { get; set; }
    }

}
