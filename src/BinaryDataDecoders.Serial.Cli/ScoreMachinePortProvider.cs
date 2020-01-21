﻿using System.IO.Ports;

namespace BinaryDataDecoders.Serial.Cli
{
    public class ScoreMachinePortProvider
    {
        public SerialPort GetFaveroPort(string portName)
        {
            return new SerialPort(portName)
            {
                BaudRate = 2400,
                DataBits = 8,
                StopBits = StopBits.One,
                Parity = Parity.None,
            };
        }
        public SerialPort GetSaintGeorgePort(string portName)
        {
            return new SerialPort(portName)
            {
                BaudRate = 9600,
                DataBits = 8,
                StopBits = StopBits.One,
                Parity = Parity.None,
            };
        }
    }
}
