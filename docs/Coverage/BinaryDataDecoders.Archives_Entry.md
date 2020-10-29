
# BinaryDataDecoders.Archives.Tar.Entry
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.Archives_Entry.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.Archives.Tar.Entry                        | 
| Assembly             | BinaryDataDecoders.Archives                                  | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 78                                                           | 
| Coverablelines       | 78                                                           | 
| Totallines           | 168                                                          | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 63                                                           | 
| Branchcoverage       | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Archives\Tar\Entry.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 63         | 0     | 0        | Sample | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Archives\Tar\Entry.cs

```CSharp
〰1:   using System;
〰2:   using System.Text;
〰3:   using System.IO;
〰4:   using System.IO.Compression;
〰5:   using System.Linq;
〰6:   using System.Runtime.InteropServices;
〰7:   using Microsoft.Win32.SafeHandles;
〰8:   
〰9:   namespace BinaryDataDecoders.Archives.Tar
〰10:  {
〰11:      class Entry
〰12:      {
〰13:          static void Sample(string[] args)
〰14:          {
‼15:              var file = @"XXX.tar.gz";
〰16:  
‼17:              if (string.IsNullOrEmpty(file))
〰18:              {
‼19:                  Console.WriteLine("provide files name to decompress");
‼20:                  return;
〰21:              }
‼22:              if (!File.Exists(file))
〰23:              {
‼24:                  Console.WriteLine("file \"{0}\" not found", file);
‼25:                  return;
〰26:              }
‼27:              var basePath = Path.GetDirectoryName(file);
〰28:  
〰29:              //try
〰30:              {
‼31:                  var volumePath = basePath;
〰32:  
‼33:                  Stream infile = File.OpenRead(file);
〰34:                  try
〰35:                  {
‼36:                      var ext = Path.GetExtension(file).ToUpper();
‼37:                      if (ext == ".gz" || ext == ".tgz")
‼38:                          infile = infile.Decompress();
〰39:  
‼40:                      byte[] buffer = new byte[512];
‼41:                      TarHeader header = null;
‼42:                      bool getHeader = true;
‼43:                      Stream newFile = null;
‼44:                      int lengthWrote = 0;
‼45:                      string longName = null;
‼46:                      bool writingFile = false;
〰47:  
‼48:                      int getLength = 1;
〰49:  
‼50:                      while (getLength > 0)
〰51:                      {
‼52:                          getLength = infile.Read(buffer, 0, 512);
〰53:  
‼54:                          if (getHeader)
〰55:                          {
‼56:                              header = buffer.ToHeader();
〰57:  
‼58:                              if (!string.IsNullOrEmpty(header.FileName))
〰59:                              {
‼60:                                  Console.WriteLine("{0} \"{1}\" ({2})",
‼61:                                                    header.FileType,
‼62:                                                    header.FileName,
‼63:                                                    header.FileSize);
‼64:                                  getHeader = false;
〰65:                              }
〰66:                              else
〰67:                                  continue;
〰68:                          }
〰69:  
‼70:                          switch (header.FileType)
〰71:                          {
〰72:                              case TarFileType.File:
〰73:                              case TarFileType.FileOld:
〰74:                              case TarFileType.ContiguousFile:
〰75:                              case TarFileType.SparseFile:
〰76:                              case TarFileType.LongName:
〰77:                                  {
‼78:                                      if (header.FileSize == 0)
‼79:                                          getHeader = true;
〰80:                                      else
〰81:                                      {
‼82:                                          if (!writingFile)
〰83:                                          {
‼84:                                              lengthWrote = 0;
‼85:                                              writingFile = true;
〰86:  
‼87:                                              var innerFile = Path.Combine(volumePath, longName ?? header.FileName);
‼88:                                              if (!File.Exists(innerFile) || new FileInfo(innerFile).Length != header.FileSize)
〰89:                                              {
‼90:                                                  if (header.FileType == TarFileType.LongName)
‼91:                                                      newFile = new MemoryStream();
〰92:                                                  else
‼93:                                                      newFile = IOUtilities.OpenFileStream(innerFile, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
〰94:                                              }
〰95:                                          }
〰96:                                          else
〰97:                                          {
‼98:                                              if (header.FileType != TarFileType.LongName)
‼99:                                                  longName = null;
‼100:                                             if (newFile != null)
‼101:                                                 newFile.Write(buffer,
‼102:                                                               0,
‼103:                                                               Math.Min(buffer.Length,
‼104:                                                                        header.FileSize - lengthWrote));
‼105:                                             lengthWrote += 512;
〰106: 
‼107:                                             if (lengthWrote >= header.FileSize && writingFile)
〰108:                                             {
‼109:                                                 if (newFile != null)
〰110:                                                 {
‼111:                                                     var ms = newFile as MemoryStream;
‼112:                                                     if (ms != null)
‼113:                                                         longName = string.Format("{0}{1}", longName, Encoding.ASCII.GetString(ms.ToArray()).TrimEnd('\0'));
‼114:                                                     newFile.Flush();
‼115:                                                     newFile.Close();
〰116:                                                 }
‼117:                                                 writingFile = false;
‼118:                                                 newFile = null;
‼119:                                                 getHeader = true;
‼120:                                                 lengthWrote = 0;
〰121:                                             }
〰122:                                         }
〰123:                                     }
〰124: 
‼125:                                     break;
〰126:                                 }
〰127: 
〰128:                             default:
〰129:                             case TarFileType.HardLink:
〰130:                             case TarFileType.SymbolicLink:
〰131:                             case TarFileType.LongSymbolicLink:
〰132:                             case TarFileType.CharacterDevice:
〰133:                             case TarFileType.BlockDevice:
〰134:                             case TarFileType.NamedPipe:
‼135:                                 Console.WriteLine("Windows doesn't really care about these: {0}", header.FileType);
‼136:                                 break;
〰137: 
〰138:                             case TarFileType.Volume:
‼139:                                 var cleanName = header.FileName.Replace(':', '\\');
‼140:                                 volumePath = Path.Combine(basePath, cleanName);
‼141:                                 break;
〰142: 
〰143:                             case TarFileType.Directory:
〰144:                                 {
‼145:                                     var tarPath = Path.Combine(volumePath, longName ?? header.FileName);
‼146:                                     longName = null;
‼147:                                     if (!Directory.Exists(tarPath))
‼148:                                         Directory.CreateDirectory(tarPath);
‼149:                                     getHeader = true;
〰150:                                     break;
〰151:                                 }
〰152:                         }
〰153:                     }
‼154:                     Console.WriteLine("Decompress Complete");
‼155:                 }
〰156:                 finally
〰157:                 {
‼158:                     if (infile != null)
‼159:                         infile.Dispose();
‼160:                 }
〰161:             }
〰162:             //catch (Exception ex)
〰163:             //{
〰164:             //    Console.WriteLine(ex);
〰165:             //}
‼166:         }
〰167:     }
〰168: }

```
## Footer 
[Return to Summary](Summary.md)

