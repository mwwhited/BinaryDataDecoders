using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common;
using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Favero;
using BinaryDataDecoders.ElectronicScoringMachines.Fencing.SaintGeorge;
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
        public IParseScoreMachineState GetParser(MachineType machine) => machine == MachineType.Favero ? (IParseScoreMachineState)new FaveroStateParser() : new SgStateParser();
    }
}
