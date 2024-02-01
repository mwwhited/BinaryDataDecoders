# BinaryDataDecoders.Apple2.Tests.Dos33.DiskImageCommandsTests

## Summary

| Key             | Value                                                          |
| :-------------- | :------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Apple2.Tests.Dos33.DiskImageCommandsTests` |
| Assembly        | `BinaryDataDecoders.Apple2.Tests`                              |
| Coveredlines    | `82`                                                           |
| Uncoveredlines  | `0`                                                            |
| Coverablelines  | `82`                                                           |
| Totallines      | `180`                                                          |
| Linecoverage    | `100`                                                          |
| Coveredbranches | `8`                                                            |
| Totalbranches   | `8`                                                            |
| Branchcoverage  | `100`                                                          |
| Coveredmethods  | `4`                                                            |
| Totalmethods    | `4`                                                            |
| Methodcoverage  | `100`                                                          |

## Metrics

| Complexity | Lines | Branches | Name                                 |
| :--------- | :---- | :------- | :----------------------------------- |
| 1          | 100   | 100      | `GetVolumeTableOfContentsTest`       |
| 4          | 100   | 100      | `GetCatalogsTest`                    |
| 4          | 100   | 100      | `GetTrackSectorListForFileEntryTest` |
| 1          | 100   | 100      | `GetDataFileEntryTest`               |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.Apple2.Tests/Dos33/DiskImageCommandsTests.cs

```CSharp
〰1:   using BinaryDataDecoders.Apple2.Dos33;
〰2:   using BinaryDataDecoders.TestUtilities;
〰3:   using BinaryDataDecoders.ToolKit;
〰4:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰5:   using System;
〰6:   using System.Linq;
〰7:   using System.Text;
〰8:   
〰9:   namespace BinaryDataDecoders.Apple2.Tests.Dos33;
〰10:  
〰11:  [TestClass]
〰12:  public class DiskImageCommandsTests
〰13:  {
〰14:      public TestContext TestContext { get; set; }
〰15:  
〰16:      [TestMethod, TestCategory(TestCategories.Unit)]
〰17:      [TestTarget(typeof(DiskImageCommands), Member = nameof(DiskImageCommands.GetCatalogs))]
〰18:      public void GetVolumeTableOfContentsTest()
〰19:      {
〰20:          //VolumeTableOfContents GetVolumeTableOfContents(Stream diskImage);
〰21:          //Stage
✔22:          using var diskImageStream = this.GetResourceStream("1983_dos33c.dsk");
✔23:          var dic = new DiskImageCommands();
〰24:  
〰25:          //Mock
〰26:  
〰27:          //Test
✔28:          var vtoc = dic.GetVolumeTableOfContents(diskImageStream);
〰29:  
〰30:          //Assert
〰31:  
✔32:          Assert.AreEqual(255, vtoc.DirectionOfAllocation);
✔33:          Assert.AreEqual(1, vtoc.DiskVolumeNumber);
✔34:          Assert.AreEqual(3, vtoc.DosReleaseNumber);
✔35:          Assert.AreEqual(15, vtoc.FirstCatalogSector);
✔36:          Assert.AreEqual(17, vtoc.FirstCatalogTrack);
✔37:          Assert.AreEqual(11, vtoc.LastAllocatedTrack);
✔38:          Assert.AreEqual(122, vtoc.MaxTrackSectorPair);
✔39:          Assert.AreEqual(256, vtoc.NumberOfBytesPerSector);
✔40:          Assert.AreEqual(16, vtoc.NumberOfSectorsPerTrack);
✔41:          Assert.AreEqual(35, vtoc.NumberOfTracksPerDisk);
〰42:  
✔43:          var expected = new[]
✔44:          {
✔45:              0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xff1f,
✔46:              0xffff,0xffff,0xffff,0xffff,0xffff,0xffff,0xff0f,0xff01,
✔47:              0xff1f,0x00,0xffff,0xff1f,0xff1f,0xff03,0x00,0x00,
✔48:              0xff1f,0x7f00,0x7f00,0xff1f,0x7f00,0xff1f,0x300,0xff1f,
✔49:              0x00,0xff1f,0x00,0x00,0x00,0x00,0x00,0x00,
✔50:              0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
✔51:              0x00,0x00,
✔52:          };
✔53:          Assert.IsFalse(expected.Zip(vtoc.BitmapFreeSectors).Any(i => i.First != i.Second));
〰54:  
〰55:  
〰56:          //Verify
✔57:      }
〰58:  
〰59:      [TestMethod, TestCategory(TestCategories.Unit)]
〰60:      [TestTarget(typeof(DiskImageCommands), Member = nameof(DiskImageCommands.GetCatalogs))]
〰61:      public void GetCatalogsTest()
〰62:      {
〰63:          // IEnumerable<CatalogEntry> GetCatalogs(Stream diskImage, VolumeTableOfContents vtoc);
〰64:          //Stage
✔65:          using var diskImageStream = this.GetResourceStream("1983_dos33c.dsk");
〰66:  
〰67:          //Mock
〰68:  
〰69:          //Test
✔70:          var dic = new DiskImageCommands();
✔71:          var catalogs = dic.GetCatalogs(diskImageStream).ToArray();
〰72:  
〰73:          //Output
✔74:          foreach (var catalog in catalogs)
〰75:          {
✔76:              this.TestContext.WriteLine($"{catalog}");
✔77:              foreach (var file in catalog.FileEntries)
〰78:              {
✔79:                  this.TestContext.WriteLine($"~{file}");
〰80:              }
〰81:          }
〰82:  
✔83:          var files = from c in catalogs
✔84:                      from f in c.FileEntries
✔85:                      where f.Exists
✔86:                      select f.Name.Trim();
〰87:  
〰88:          //Assert
✔89:          Assert.AreEqual("HELLO|COPY|CONVERT13", string.Join("|", files));
〰90:  
〰91:          //Verify
✔92:      }
〰93:  
〰94:      [TestMethod, TestCategory(TestCategories.Unit)]
〰95:      [TestTarget(typeof(DiskImageCommands), Member = nameof(DiskImageCommands.GetTrackSectorListForFileEntry))]
〰96:      public void GetTrackSectorListForFileEntryTest()
〰97:      {
〰98:          //IEnumerable<TrackSectorList> GetTrackSectorListForFileEntry(Stream diskImage, FileEntry fileEntry)
〰99:  
〰100:         // IEnumerable<CatalogEntry> GetCatalogs(Stream diskImage, VolumeTableOfContents vtoc);
〰101:         //Stage
✔102:         using var diskImageStream = this.GetResourceStream("1983_dos33c.dsk");
〰103: 
〰104:         //Mock
〰105: 
〰106:         //Test
✔107:         var dic = new DiskImageCommands();
✔108:         var target = (from catalog in dic.GetCatalogs(diskImageStream)
✔109:                       from file in catalog.FileEntries
✔110:                       where file.Exists
✔111:                       select file).First();
✔112:         var results = dic.GetTrackSectorListForFileEntry(diskImageStream, target).ToArray();
〰113: 
〰114:         //Output
✔115:         foreach (var tsl in results)
〰116:         {
✔117:             this.TestContext.WriteLine($"{tsl.NextTrack}/{tsl.NextSector}: {tsl.SectorOffset}");
✔118:             foreach (var ts in tsl.TrackSectorPairs.Where(i => i.Track != 0 || i.Sector != 0))
〰119:             {
✔120:                 this.TestContext.WriteLine($"~{ts}");
〰121:             }
〰122:         }
〰123: 
〰124:         //Assert
✔125:         Assert.AreEqual(19, results[0].TrackSectorPairs.ElementAt(0).Track);
✔126:         Assert.AreEqual(14, results[0].TrackSectorPairs.ElementAt(0).Sector);
✔127:         Assert.AreEqual(19, results[0].TrackSectorPairs.ElementAt(1).Track);
✔128:         Assert.AreEqual(13, results[0].TrackSectorPairs.ElementAt(1).Sector);
〰129: 
〰130:         //Verify
✔131:     }
〰132: 
〰133: 
〰134:     [TestMethod, TestCategory(TestCategories.Unit)]
〰135:     [TestTarget(typeof(DiskImageCommands), Member = nameof(DiskImageCommands.GetDataFileEntry))]
〰136:     public void GetDataFileEntryTest()
〰137:     {
〰138:         //Stage
✔139:         using var diskImageStream = this.GetResourceStream("1983_dos33c.dsk");
〰140: 
〰141:         //Mock
〰142: 
〰143:         //Test
✔144:         var dic = new DiskImageCommands();
✔145:         var target = (from catalog in dic.GetCatalogs(diskImageStream)
✔146:                       from file in catalog.FileEntries
✔147:                       where file.Exists
✔148:                       select file).First();
✔149:         var results = dic.GetDataFileEntry(diskImageStream, target).ToArray();
〰150: 
〰151:         //Output
✔152:         var base64 = Convert.ToBase64String(results, Base64FormattingOptions.InsertLineBreaks);
✔153:         this.TestContext.WriteLine(base64);
〰154: 
〰155:         //Assert
✔156:         var expectedBase64 = @"owEJCAoAiTqXAB4IFABEJNDnKDQpOrIgQ1RSTC1EADkIHgCiMjpBJNAiQVBQTEUgSUkiOrAxMDAw
✔157: AGoIKACiNDpBJNAiRE9TIFZFUlNJT04gMy4zICBTWVNURU0gTUFTVEVSIjqwMTAwMACMCDIAojc6
✔158: QSTQIkpBTlVBUlkgMSwgMTk4MyI6sDEwMDAAqAg8ALpEJDsiQkxPQUQgTE9BREVSLk9CSjAiAM8I
✔159: RgCMNDA5NjqyIEZBU1QgTE9BRCBJTiBJTlRFR0VSIEJBU0lDABAJUACiMTA6jMk5NTg6QSTQIkNP
✔160: UFlSSUdIVCBBUFBMRSBDT01QVVRFUixJTkMuIDE5ODAsMTk4MiI6sDEwMDAATwlaAEPQ4ijJMTEw
✔161: MSk6rUPQNsS6Op46QSTQIkJFIFNVUkUgQ0FQUyBMT0NLIElTIERPV04iOrAxMDAwOp0AXglkALrn
✔162: KDQpOyJGUCIAdQnoA7IgQ0VOVEVSIFNUUklORyBBJACVCfIDQtDTKDIwySjjKEEkKcsyKSk6rULQ
✔163: 0TDEQtAxAKIJ/AOWQjq6QSQ6sQAAAIcAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
✔164: AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=";
〰165: 
✔166:         var compare = Convert.FromBase64String(expectedBase64)
✔167:                        .Zip(results).Select((v, i) => new
✔168:                        {
✔169:                            IsNotMatched = v.First != v.Second,
✔170:                            Expected = v.First,
✔171:                            Found = v.Second,
✔172:                            Index = i,
✔173:                        }).Where(i => i.IsNotMatched);
✔174:         Assert.IsFalse(compare.Any());
〰175: 
〰176:         //Verify
〰177: 
✔178:     }
〰179: }
〰180: 
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

