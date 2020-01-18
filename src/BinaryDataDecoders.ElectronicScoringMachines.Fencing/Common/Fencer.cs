using System.Diagnostics;

namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common
{
    [DebuggerDisplay("S{Score} L{Lights} C{Cards} P{Priority}")]
    public struct Fencer
    {
        public Fencer(byte score, Cards cards, Lights lights, bool priority)
        {
            Score = score;
            Cards = cards;
            Lights = lights;
            Priority = priority;
        }

        public byte Score { get; }
        public Cards Cards { get; }
        public Lights Lights { get; }
        public bool Priority { get; }

        public override string ToString()
        {
            return $"S>{Score:000} L>{Lights} C>{Cards} P>{Priority}";
        }

        public override bool Equals(object obj)
        {
            return obj is Fencer i && Score == i.Score && Cards == i.Cards && Lights == i.Lights && Priority == i.Priority;
        }

        public override int GetHashCode()
        {
            return (Score, Cards, Lights, Priority).GetHashCode();
        }

        public static bool operator ==(Fencer left, Fencer right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Fencer left, Fencer right)
        {
            return !(left == right);
        }
    }
}