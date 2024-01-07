using System;
using System.Collections.Generic;
using System.IO;

namespace BinaryDataDecoders.Apple2.Dos33;

/// <summary>
/// set of commands for AppleSoft DOS 3.3 disk images.
/// </summary>
public interface IDiskImageCommands
{
    /// <summary>
    /// Returns list of catalog entries with files
    /// </summary>
    /// <param name="diskImage"></param>
    /// <returns></returns>
    IEnumerable<CatalogEntry> GetCatalogs(Stream diskImage);

    /// <summary>
    /// Retrieve Volume table of contents.
    /// </summary>
    /// <param name="diskImage"></param>
    /// <returns></returns>
    VolumeTableOfContents GetVolumeTableOfContents(Stream diskImage);

    /// <summary>
    /// Returns list of populated track/sectors for given file
    /// </summary>
    /// <param name="diskImage"></param>
    /// <param name="fileEntry"></param>
    /// <returns></returns>
    IEnumerable<TrackSectorList> GetTrackSectorListForFileEntry(Stream diskImage, FileEntry fileEntry);

    /// <summary>
    /// retrieve binary data for input file
    /// </summary>
    /// <param name="diskImage"></param>
    /// <param name="fileEntry"></param>
    /// <returns></returns>
    Span<byte> GetDataFileEntry(Stream diskImage, FileEntry fileEntry);
}