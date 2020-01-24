﻿using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common;
using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Favero;
using BinaryDataDecoders.ElectronicScoringMachines.Fencing.SaintGeorge;
using BinaryDataDecoders.IO.Pipelines;
using BinaryDataDecoders.ToolKit;
using System.IO.Ports;

namespace BinaryDataDecoders.Serial.Cli
{
    public class ScoreMachineFactory
    {
        private readonly ScoreMachinePortProvider _provider;
        public ScoreMachineFactory(ScoreMachinePortProvider provider)
        {
            _provider = provider;
        }
        public MachineType GetMachineType(string machine) => machine?.ToLower().StartsWith("f") ?? false ? MachineType.Favero : MachineType.Sg;
        public SerialPort GetPort(MachineType machine, string portName) => machine == MachineType.Favero ? _provider.GetFaveroPort(portName) : _provider.GetSaintGeorgePort(portName);

        //Task OnSegmentReceived(ReadOnlySequence<byte> segment)
        internal ISegmenter GetSegmenter(MachineType machine, OnSegmentReceived received) =>
            (machine == MachineType.Favero ?
                Segment.StartsWith(0xff).AndIsLength(10) :
                Segment.StartsWith(ControlCharacters.StartOfHeading).AndEndsWith(ControlCharacters.EndOfTransmission)
            ).ThenDo(received);

        public IParseScoreMachineState GetParser(MachineType machine) => machine == MachineType.Favero ? (IParseScoreMachineState)new FaveroStateParser() : new SgStateParser();
    }
}