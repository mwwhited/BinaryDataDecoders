using System.ComponentModel;

namespace BinaryDataDecoders.IO.Ports
{
    public enum Parity
    {
        [Description("No parity check occurs.")]
        None = 0,
        [Description("Sets the parity bit so that the count of bits set is an odd number.")]
        Odd = 1,
        [Description("Sets the parity bit so that the count of bits set is an even number.")]
        Even = 2,
        [Description("Leaves the parity bit set to 1.")]
        Mark = 3,
        [Description("Leaves the parity bit set to 0.")]
        Space = 4
    }
}
