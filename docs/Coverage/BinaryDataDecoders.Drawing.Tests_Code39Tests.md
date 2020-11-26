﻿# BinaryDataDecoders.Drawing.Tests.BarCodes.Code39Tests

## Summary

| Key             | Value                                                   |
| :-------------- | :------------------------------------------------------ |
| Class           | `BinaryDataDecoders.Drawing.Tests.BarCodes.Code39Tests` |
| Assembly        | `BinaryDataDecoders.Drawing.Tests`                      |
| Coveredlines    | `0`                                                     |
| Uncoveredlines  | `44`                                                    |
| Coverablelines  | `44`                                                    |
| Totallines      | `80`                                                    |
| Linecoverage    | `0`                                                     |
| Coveredbranches | `0`                                                     |
| Totalbranches   | `6`                                                     |
| Branchcoverage  | `0`                                                     |

## Metrics

| Complexity | Lines | Branches | Name              |
| :--------- | :---- | :------- | :---------------- |
| 1          | 0     | 100      | `get_TestContext` |
| 6          | 0     | 0        | `Test`            |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Drawing.Tests/BarCodes/Code39Tests.cs

```CSharp
〰1:   using BinaryDataDecoders.Drawing.Barcodes;
〰2:   using BinaryDataDecoders.TestUtilities;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   using System;
〰5:   using System.Collections.Generic;
〰6:   using System.Drawing;
〰7:   using System.Drawing.Imaging;
〰8:   using System.IO;
〰9:   using System.Linq;
〰10:  using System.Text;
〰11:  
〰12:  namespace BinaryDataDecoders.Drawing.Tests.BarCodes
〰13:  {
〰14:      [TestClass]
〰15:      public class Code39Tests
〰16:      {
‼17:          public TestContext TestContext { get; set; }
〰18:  
〰19:          [TestMethod, TestCategory(TestCategories.DevLocal)]
〰20:          public void Test()
〰21:          {
〰22:  
‼23:              var code39 = new Code39();
‼24:              using (var ms = new MemoryStream())
‼25:              using (var bmp = code39.EncodeStandard("HELLO"))
〰26:              {
‼27:                  bmp.Save(ms, ImageFormat.Png);
‼28:                  this.TestContext.AddResult(ms, "code39.EncodeStandard.png");
‼29:              }
‼30:              using (var ms = new MemoryStream())
‼31:              using (var bmp = code39.EncodeFullAscii("Hello World!"))
〰32:              {
‼33:                  bmp.Save(ms, ImageFormat.Png);
‼34:                  this.TestContext.AddResult(ms, "code39.EncodeFullAscii.png");
‼35:              }
〰36:  
〰37:              {
‼38:                  var codes = new[] {
‼39:                  "ABCDEFGHIJ",
‼40:                  "KLMNOPQRST",
‼41:                  "UVWXYZ0123",
‼42:                  "456789 -$%",
‼43:                  "./+",
‼44:              };
‼45:                  using (var ms = new MemoryStream())
‼46:                  using (var set = new Bitmap((codes[0].Length + 2) * 16, codes.Length * 16))
‼47:                  using (var graph = Graphics.FromImage(set))
〰48:                  {
‼49:                      foreach (var item in codes.Select((v, i) => new { v, i }))
‼50:                          using (var bmp = code39.EncodeStandard(item.v))
〰51:                          {
‼52:                              graph.DrawImage(bmp, new Point(0, item.i * 16));
‼53:                          }
‼54:                      set.Save(ms, ImageFormat.Png);
‼55:                      this.TestContext.AddResult(ms, "code39.Test.png");
‼56:                  }
〰57:              }
〰58:              {
‼59:                  var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 -$%./+";
‼60:                  var codes = alphabet.Select(c => "" + c).ToArray();
〰61:  
‼62:                  using (var ms = new MemoryStream())
‼63:                  using (var set = new Bitmap(((codes[0].Length + 2) * 16) + 32, codes.Length * 16))
‼64:                  using (var graph = Graphics.FromImage(set))
〰65:                  {
‼66:                      graph.FillRectangle(Brushes.White, 0, 0, set.Width, set.Height);
‼67:                      foreach (var item in codes.Select((v, i) => new { v, i }))
‼68:                          using (var bmp = code39.EncodeStandard(item.v))
〰69:                          {
‼70:                              graph.DrawString(item.v, SystemFonts.DefaultFont, Brushes.Black, new Point(0, item.i * 16));
‼71:                              graph.DrawImage(bmp, new Point(32, item.i * 16));
‼72:                          }
〰73:  
‼74:                      set.Save(ms, ImageFormat.Png);
‼75:                      this.TestContext.AddResult(ms, "code39.Test2.png");
‼76:                  }
〰77:              }
‼78:          }
〰79:      }
〰80:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

