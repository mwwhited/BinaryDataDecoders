using System.ComponentModel;

namespace BinaryDataDecoders.IO.Ports;

/// <summary>
/// parity configuration
/// </summary>
public enum Parity
{
    /// <summary>
    /// No parity check occurs.
    /// </summary>
    [Description("No parity check occurs.")]
    None = 0,
    /// <summary>
    /// Sets the parity bit so that the count of bits set is an odd number.
    /// </summary>
    [Description("Sets the parity bit so that the count of bits set is an odd number.")]
    Odd = 1,
    /// <summary>
    /// Sets the parity bit so that the count of bits set is an even number.
    /// </summary>
    [Description("Sets the parity bit so that the count of bits set is an even number.")]
    Even = 2,
    /// <summary>
    /// Leaves the parity bit set to 1.
    /// </summary>
    [Description("Leaves the parity bit set to 1.")]
    Mark = 3,
    /// <summary>
    /// Leaves the parity bit set to 0.
    /// </summary>
    [Description("Leaves the parity bit set to 0.")]
    Space = 4
}
