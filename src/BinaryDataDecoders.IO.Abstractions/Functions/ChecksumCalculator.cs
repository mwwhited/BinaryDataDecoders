using System;

namespace BinaryDataDecoders.IO.Functions;

/// <summary>
/// This class contains various checksum calculation algorithms
/// </summary>
public class ChecksumCalculator : IChecksumCalculator
{
    /// <summary>
    /// I'm not really sure is there is a &quot;proper&quot; name for this algorithm.
    /// 
    /// Difference of all values in Span&lt;ushort&gt;
    /// </summary>
    /// <param name="buffer">input span to calculate span over. </param>
    /// <returns>checksum value</returns>
    public ushort Simple16(ReadOnlySpan<ushort> buffer)
    {
        int sum = -1;
        foreach (var term in buffer)
            sum -= term;
        return (ushort)(sum % 0xffff);
    }
}
