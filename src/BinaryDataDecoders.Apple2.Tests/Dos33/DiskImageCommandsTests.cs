using BinaryDataDecoders.Apple2.Dos33;
using BinaryDataDecoders.TestUtilities;
using BinaryDataDecoders.ToolKit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BinaryDataDecoders.Apple2.Tests.Dos33;

[TestClass]
public class DiskImageCommandsTests
{
    public TestContext TestContext { get; set; }

    [TestMethod, TestCategory(TestCategories.Unit)]
    [TestTarget(typeof(DiskImageCommands), Member = nameof(DiskImageCommands.GetCatalogs))]
    public void GetVolumeTableOfContentsTest()
    {
        //VolumeTableOfContents GetVolumeTableOfContents(Stream diskImage);
        //Stage
        using var diskImageStream = this.GetResourceStream("1983_dos33c.dsk");
        var dic = new DiskImageCommands();

        //Mock

        //Test
        var vtoc = dic.GetVolumeTableOfContents(diskImageStream);

        //Assert

        Assert.AreEqual(255, vtoc.DirectionOfAllocation);
        Assert.AreEqual(1, vtoc.DiskVolumeNumber);
        Assert.AreEqual(3, vtoc.DosReleaseNumber);
        Assert.AreEqual(15, vtoc.FirstCatalogSector);
        Assert.AreEqual(17, vtoc.FirstCatalogTrack);
        Assert.AreEqual(11, vtoc.LastAllocatedTrack);
        Assert.AreEqual(122, vtoc.MaxTrackSectorPair);
        Assert.AreEqual(256, vtoc.NumberOfBytesPerSector);
        Assert.AreEqual(16, vtoc.NumberOfSectorsPerTrack);
        Assert.AreEqual(35, vtoc.NumberOfTracksPerDisk);

        var expected = new[]
        {
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xff1f,
            0xffff,0xffff,0xffff,0xffff,0xffff,0xffff,0xff0f,0xff01,
            0xff1f,0x00,0xffff,0xff1f,0xff1f,0xff03,0x00,0x00,
            0xff1f,0x7f00,0x7f00,0xff1f,0x7f00,0xff1f,0x300,0xff1f,
            0x00,0xff1f,0x00,0x00,0x00,0x00,0x00,0x00,
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
            0x00,0x00,
        };
        Assert.IsFalse(expected.Zip(vtoc.BitmapFreeSectors).Any(i => i.First != i.Second));


        //Verify
    }

    [TestMethod, TestCategory(TestCategories.Unit)]
    [TestTarget(typeof(DiskImageCommands), Member = nameof(DiskImageCommands.GetCatalogs))]
    public void GetCatalogsTest()
    {
        // IEnumerable<CatalogEntry> GetCatalogs(Stream diskImage, VolumeTableOfContents vtoc);
        //Stage
        using var diskImageStream = this.GetResourceStream("1983_dos33c.dsk");

        //Mock

        //Test
        var dic = new DiskImageCommands();
        var catalogs = dic.GetCatalogs(diskImageStream).ToArray();

        //Output
        foreach (var catalog in catalogs)
        {
            this.TestContext.WriteLine($"{catalog}");
            foreach (var file in catalog.FileEntries)
            {
                this.TestContext.WriteLine($"~{file}");
            }
        }

        var files = from c in catalogs
                    from f in c.FileEntries
                    where f.Exists
                    select f.Name.Trim();

        //Assert
        Assert.AreEqual("HELLO|COPY|CONVERT13", string.Join("|", files));

        //Verify
    }

    [TestMethod, TestCategory(TestCategories.Unit)]
    [TestTarget(typeof(DiskImageCommands), Member = nameof(DiskImageCommands.GetTrackSectorListForFileEntry))]
    public void GetTrackSectorListForFileEntryTest()
    {
        //IEnumerable<TrackSectorList> GetTrackSectorListForFileEntry(Stream diskImage, FileEntry fileEntry)

        // IEnumerable<CatalogEntry> GetCatalogs(Stream diskImage, VolumeTableOfContents vtoc);
        //Stage
        using var diskImageStream = this.GetResourceStream("1983_dos33c.dsk");

        //Mock

        //Test
        var dic = new DiskImageCommands();
        var target = (from catalog in dic.GetCatalogs(diskImageStream)
                      from file in catalog.FileEntries
                      where file.Exists
                      select file).First();
        var results = dic.GetTrackSectorListForFileEntry(diskImageStream, target).ToArray();

        //Output
        foreach (var tsl in results)
        {
            this.TestContext.WriteLine($"{tsl.NextTrack}/{tsl.NextSector}: {tsl.SectorOffset}");
            foreach (var ts in tsl.TrackSectorPairs.Where(i => i.Track != 0 || i.Sector != 0))
            {
                this.TestContext.WriteLine($"~{ts}");
            }
        }

        //Assert
        Assert.AreEqual(19, results[0].TrackSectorPairs.ElementAt(0).Track);
        Assert.AreEqual(14, results[0].TrackSectorPairs.ElementAt(0).Sector);
        Assert.AreEqual(19, results[0].TrackSectorPairs.ElementAt(1).Track);
        Assert.AreEqual(13, results[0].TrackSectorPairs.ElementAt(1).Sector);

        //Verify
    }


    [TestMethod, TestCategory(TestCategories.Unit)]
    [TestTarget(typeof(DiskImageCommands), Member = nameof(DiskImageCommands.GetDataFileEntry))]
    public void GetDataFileEntryTest()
    {
        //Stage
        using var diskImageStream = this.GetResourceStream("1983_dos33c.dsk");

        //Mock

        //Test
        var dic = new DiskImageCommands();
        var target = (from catalog in dic.GetCatalogs(diskImageStream)
                      from file in catalog.FileEntries
                      where file.Exists
                      select file).First();
        var results = dic.GetDataFileEntry(diskImageStream, target).ToArray();

        //Output
        var base64 = Convert.ToBase64String(results, Base64FormattingOptions.InsertLineBreaks);
        this.TestContext.WriteLine(base64);

        //Assert
        var expectedBase64 = @"owEJCAoAiTqXAB4IFABEJNDnKDQpOrIgQ1RSTC1EADkIHgCiMjpBJNAiQVBQTEUgSUkiOrAxMDAw
AGoIKACiNDpBJNAiRE9TIFZFUlNJT04gMy4zICBTWVNURU0gTUFTVEVSIjqwMTAwMACMCDIAojc6
QSTQIkpBTlVBUlkgMSwgMTk4MyI6sDEwMDAAqAg8ALpEJDsiQkxPQUQgTE9BREVSLk9CSjAiAM8I
RgCMNDA5NjqyIEZBU1QgTE9BRCBJTiBJTlRFR0VSIEJBU0lDABAJUACiMTA6jMk5NTg6QSTQIkNP
UFlSSUdIVCBBUFBMRSBDT01QVVRFUixJTkMuIDE5ODAsMTk4MiI6sDEwMDAATwlaAEPQ4ijJMTEw
MSk6rUPQNsS6Op46QSTQIkJFIFNVUkUgQ0FQUyBMT0NLIElTIERPV04iOrAxMDAwOp0AXglkALrn
KDQpOyJGUCIAdQnoA7IgQ0VOVEVSIFNUUklORyBBJACVCfIDQtDTKDIwySjjKEEkKcsyKSk6rULQ
0TDEQtAxAKIJ/AOWQjq6QSQ6sQAAAIcAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=";

        var compare = Convert.FromBase64String(expectedBase64)
                       .Zip(results).Select((v, i) => new
                       {
                           IsNotMatched = v.First != v.Second,
                           Expected = v.First,
                           Found = v.Second,
                           Index = i,
                       }).Where(i => i.IsNotMatched);
        Assert.IsFalse(compare.Any());

        //Verify

    }
}
