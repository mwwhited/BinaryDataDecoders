# BinaryDataDecoders.ToolKit.Xml.Xsl.XsltTransformer

## Summary

| Key             | Value                                                |
| :-------------- | :--------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Xsl.XsltTransformer` |
| Assembly        | `BinaryDataDecoders.ToolKit`                         |
| Coveredlines    | `0`                                                  |
| Uncoveredlines  | `290`                                                |
| Coverablelines  | `290`                                                |
| Totallines      | `527`                                                |
| Linecoverage    | `0`                                                  |
| Coveredbranches | `0`                                                  |
| Totalbranches   | `40`                                                 |
| Branchcoverage  | `0`                                                  |
| Coveredmethods  | `0`                                                  |
| Totalmethods    | `14`                                                 |
| Methodcoverage  | `0`                                                  |

## Metrics

| Complexity | Lines | Branches | Name             |
| :--------- | :---- | :------- | :--------------- |
| 1          | 0     | 100      | `ctor`           |
| 1          | 0     | 100      | `ReadAsXml`      |
| 1          | 0     | 100      | `Transform`      |
| 4          | 0     | 0        | `Transform`      |
| 1          | 0     | 100      | `TransformAll`   |
| 10         | 0     | 0        | `TransformAll`   |
| 2          | 0     | 0        | `TransformMerge` |
| 1          | 0     | 100      | `ctor`           |
| 1          | 0     | 100      | `ReadAsXml`      |
| 1          | 0     | 100      | `Transform`      |
| 4          | 0     | 0        | `Transform`      |
| 1          | 0     | 100      | `TransformAll`   |
| 10         | 0     | 0        | `TransformAll`   |
| 2          | 0     | 0        | `TransformMerge` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/Xsl/XsltTransformer.cs

```CSharp
〰1:   #define PARALLEL
〰2:   
〰3:   using BinaryDataDecoders.ToolKit.IO;
〰4:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰5:   using System;
〰6:   using System.Collections.Generic;
〰7:   using System.IO;
〰8:   using System.Linq;
〰9:   using System.Threading;
〰10:  using System.Xml;
〰11:  using System.Xml.Linq;
〰12:  using System.Xml.XPath;
〰13:  using System.Xml.Xsl;
〰14:  
〰15:  //TODO: should make this async/await
〰16:  namespace BinaryDataDecoders.ToolKit.Xml.Xsl;
〰17:  
〰18:  /// <summary>
〰19:  /// Implementation of XsltTransformer
〰20:  /// </summary>
〰21:  /// <remarks>
〰22:  /// create instance of XsltTransformer
〰23:  /// </remarks>
〰24:  /// <param name="extensions">optional extensions for XSLT Transform</param>
〰25:  public class XsltTransformer(string sandbox, params object[] extensions) : IXsltTransformer
〰26:  {
‼27:      private readonly string _sandbox = sandbox;
〰28:  
〰29:      /// <summary>
〰30:      /// Read input file as XML
〰31:      /// </summary>
〰32:      /// <param name="fileName"></param>
〰33:      /// <returns></returns>
〰34:      public IXPathNavigable? ReadAsXml(string fileName)
〰35:      {
〰36:          try
〰37:          {
‼38:              var xmlreader = XmlReader.Create(fileName, new XmlReaderSettings
‼39:              {
‼40:                  DtdProcessing = DtdProcessing.Ignore,
‼41:                  ConformanceLevel = ConformanceLevel.Document,
‼42:                  NameTable = new NameTable(),
‼43:              });
‼44:              var xmlDocument = new XmlDocument();
‼45:              xmlDocument.Load(xmlreader);
‼46:              return xmlDocument;
〰47:          }
‼48:          catch
〰49:          {
‼50:              return null;
〰51:              //TODO: do something smart
〰52:          }
‼53:      }
〰54:  
〰55:      /// <summary>
〰56:      /// Single action transform
〰57:      /// </summary>
〰58:      /// <param name="template">path for XSLT style-sheet</param>
〰59:      /// <param name="input">source XML file</param>
〰60:      /// <param name="output">resulting text content</param>
‼61:      public void Transform(string template, string input, string output) => Transform(template, input, ReadAsXml(input), output);
〰62:  
〰63:      /// <summary>
〰64:      /// Single action transform
〰65:      /// </summary>
〰66:      /// <param name="template">path for XSLT style-sheet</param>
〰67:      /// <param name="inputSource"></param>
〰68:      /// <param name="input">source XML file</param>
〰69:      /// <param name="output">resulting text content</param>
〰70:      public void Transform(string template, string inputSource, IXPathNavigable input, string output)
〰71:      {
‼72:          template = PathEx.FixUpPath(template);
‼73:          inputSource = PathEx.FixUpPath(inputSource);
‼74:          output = PathEx.FixUpPath(output);
‼75:          var sandbox = PathEx.FixUpPath(_sandbox);
〰76:  
‼77:          var xsltArgumentList = new XsltArgumentList().AddExtensions(extensions);
〰78:  
‼79:          xsltArgumentList.XsltMessageEncountered += (sender, eventArgs) => Console.WriteLine($"\t\t[{Thread.CurrentThread.ManagedThreadId}]{eventArgs.Message}");
〰80:  
‼81:          XNamespace ns = this.GetXmlNamespace();
‼82:          xsltArgumentList.AddParam("files", "", new XElement(ns + "file",
‼83:              new XAttribute(nameof(template), Path.GetFullPath(template)),
‼84:              new XAttribute(nameof(input), Path.GetFullPath(inputSource)),
‼85:              new XAttribute(nameof(input) + "Type", input.GetType().AssemblyQualifiedName),
‼86:              new XAttribute(nameof(output), Path.GetFullPath(output)),
‼87:              new XAttribute(nameof(output) + "Path", Path.GetDirectoryName(Path.GetFullPath(output))),
‼88:              new XAttribute("sandbox", Path.GetFullPath(sandbox))
‼89:              ).ToXPathNavigable().CreateNavigator());
〰90:  
‼91:          var xslt = new XslCompiledTransform(false);
‼92:          using var xmlreader = XmlReader.Create(template, new XmlReaderSettings
‼93:          {
‼94:              DtdProcessing = DtdProcessing.Parse,
‼95:              ConformanceLevel = ConformanceLevel.Document,
‼96:              NameTable = new NameTable(),
‼97:          });
‼98:          var xsltSettings = new XsltSettings(false, false);
〰99:  
‼100:         xslt.Load(xmlreader, xsltSettings, null);
〰101: 
‼102:         var outputDir = Path.GetDirectoryName(output);
‼103:         if (!Directory.Exists(outputDir))
‼104:             Directory.CreateDirectory(outputDir);
‼105:         using var resultStream = File.Create(output);
〰106: 
‼107:         var currentDirectory = Environment.CurrentDirectory;
〰108:         try
〰109:         {
‼110:             var localOutfolder = Path.GetDirectoryName(output);
‼111:             if (!Directory.Exists(localOutfolder))
〰112:             {
‼113:                 Directory.CreateDirectory(localOutfolder);
〰114:             }
‼115:             Environment.CurrentDirectory = localOutfolder;
〰116: 
‼117:             var inputNavigator = input.CreateNavigator();
‼118:             inputNavigator.MoveToRoot();
〰119: 
〰120:             //var x = xslt.GetType();
〰121:             //var pf = x.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
〰122:             //var pfc = pf.First(i => i.Name == "_command");
〰123:             //var pfv = pfc.GetValue(xslt);
〰124: 
‼125:             xslt.Transform(inputNavigator, xsltArgumentList, resultStream);
‼126:         }
〰127:         finally
〰128:         {
‼129:             Environment.CurrentDirectory = currentDirectory;
‼130:         }
‼131:     }
〰132: 
〰133:     /// <summary>
〰134:     /// Multi-action transform.
〰135:     /// </summary>
〰136:     /// <param name="template">path for XSLT style-sheet</param>
〰137:     /// <param name="input">Wild card allowed for multiple files</param>
〰138:     /// <param name="output">Output and suffix per file.</param>
〰139:     public void TransformAll(string template, string input, string output, string? excludeInputSource = null) =>
‼140:         TransformAll(template, input, ReadAsXml, output, excludeInputSource);
〰141: 
〰142:     /// <summary>
〰143:     /// Multi-action transform.
〰144:     /// </summary>
〰145:     /// <param name="template">path for XSLT style-sheet</param>
〰146:     /// <param name="input">Wild card allowed for multiple files</param>
〰147:     /// <param name="inputNavigatorFactory">function to load input file into IXPathNavigable</param>
〰148:     /// <param name="output">Output and suffix per file.</param>
〰149:     public void TransformAll(string template, string input, Func<string, IXPathNavigable> inputNavigatorFactory, string output, string? excludeInputSource = null)
〰150:     {
‼151:         var inputFullPath = Path.GetFullPath(input);
‼152:         var inputDir = PathEx.GetBasePath(input);
‼153:         var excludeFiles = PathEx.EnumerateFiles(excludeInputSource);
‼154:         var inputFiles = PathEx.EnumerateFiles(input).Select(Path.GetFullPath).Except(excludeFiles.Select(Path.GetFullPath));
〰155: 
‼156:         var outputFullPath = Path.GetFullPath(output);
‼157:         var outputDir = Path.GetDirectoryName(outputFullPath);
‼158:         var outputPattern = Path.GetFileName(outputFullPath).Split('*').LastOrDefault() ?? "";
〰159: 
‼160:         Console.WriteLine($"\"{inputDir}\" => \"{outputDir}\"");
‼161:         if (!inputFiles.Any())
‼162:             throw new FileNotFoundException($"File Not Found Exception: input");
〰163: 
‼164:         static Exception innerMost(Exception ex) => ex.InnerException == null ? ex : innerMost(ex.InnerException);
〰165: 
‼166:         var errors = new List<Exception>();
〰167: #if PARALLEL
‼168:         inputFiles.AsParallel().ForAll(inputFile =>
‼169: #else
‼170:         foreach (var inputFile in inputFiles)
‼171: #endif
‼172:         {
‼173:             var inputFileClean = inputFile[inputDir.Length..].TrimStart('/', '\\');
‼174:             var removedExt = Path.ChangeExtension(inputFileClean, null);
‼175:             var outFileName = removedExt + outputPattern;
‼176:             var outputFile = Path.Combine(outputDir, outFileName);
‼177: 
‼178:             var tid = Thread.CurrentThread.ManagedThreadId;
‼179: 
‼180:             Console.WriteLine($"\t[{tid}]\"{inputFileClean}\" => \"{outFileName}\"");
‼181: 
‼182:             try
‼183:             {
‼184:                 var inputNavigator = inputNavigatorFactory(inputFile);
‼185:                 Transform(template, inputFile, inputNavigator, outputFile);
‼186:             }
‼187:             catch (Exception ex)
‼188:             {
‼189:                 var rex = innerMost(ex);
‼190:                 errors.Add(rex);
‼191:                 Console.Error.WriteLine($"!!! ERROR[{tid}]: \"{inputFileClean}\" => \"{outFileName}\" :: {rex.Message}");
‼192:                 try
‼193:                 {
‼194:                     File.AppendAllLines(outputFile, new[]
‼195:                     {
‼196:                         "",
‼197:                         new string('=', 60),
‼198:                        $"!!! ERROR !!!: {ex.Message}",
‼199:                         new string('=', 60),
‼200:                         ex.ToString()
‼201:                     });
‼202:                 }
‼203:                 catch
‼204:                 {
‼205:                     // Eat and errors!
‼206:                 }
‼207:             }
‼208:         }
‼209: #if PARALLEL
‼210:         );
〰211: #endif
‼212:         if (errors.Any())
‼213:             throw new AggregateException(errors);
‼214:     }
〰215: 
〰216:     public void TransformMerge(string template, string input, Func<string, IXPathNavigable> inputNavigatorFactory, string output, string? excludeInputSource = null)
〰217:     {
‼218:         static Exception innerMost(Exception ex) => ex.InnerException == null ? ex : innerMost(ex.InnerException);
‼219:         var tid = Thread.CurrentThread.ManagedThreadId;
〰220:         try
〰221:         {
‼222:             var inputFullPath = Path.GetFullPath(input);
‼223:             var inputDir = PathEx.GetBasePath(input);
‼224:             var excludeFiles = PathEx.EnumerateFiles(excludeInputSource);
‼225:             var inputFiles = PathEx.EnumerateFiles(input).Except(excludeFiles);
〰226: 
‼227:             if (!inputFiles.Any())
‼228:                 throw new FileNotFoundException($"input");
〰229: 
〰230:             //TODO: should probably add the file to the input navigator
‼231:             var navigators = inputFiles.Select(f => (f, (IXPathNavigable?)inputNavigatorFactory(f))).ToList();
〰232: 
〰233:             //TODO: need to figure out why this won't navigate correctly.
‼234:             var merged = navigators.MergeNavigators().CreateNavigator();
‼235:             var doc = new XmlDocument();
‼236:             doc.LoadXml(merged.OuterXml);
‼237:             merged = doc.CreateNavigator();
‼238:             merged.MoveToRoot();
‼239:             Transform(template, input, merged, output);
‼240:         }
‼241:         catch (Exception ex)
〰242:         {
‼243:             var rex = innerMost(ex);
‼244:             Console.Error.WriteLine($"ERROR[{tid}]: \"{input}\" => \"{output}\" :: {rex.Message}");
〰245:             try
〰246:             {
‼247:                 File.AppendAllLines(output, new[]
‼248:                 {
‼249:                         "",
‼250:                         new string('=', 60),
‼251:                        $"!!! ERROR !!!: {ex.Message}",
‼252:                         new string('=', 60),
‼253:                         ex.ToString()
‼254:                     });
‼255:             }
‼256:             catch
〰257:             {
〰258:                 // Eat and errors!
‼259:             }
‼260:             throw;
〰261:         }
‼262:     }
〰263: }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/Xml/Xsl/XsltTransformer.cs

```CSharp
〰1:   #define PARALLEL
〰2:   
〰3:   using BinaryDataDecoders.ToolKit.IO;
〰4:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰5:   using System;
〰6:   using System.Collections.Generic;
〰7:   using System.IO;
〰8:   using System.Linq;
〰9:   using System.Threading;
〰10:  using System.Xml;
〰11:  using System.Xml.Linq;
〰12:  using System.Xml.XPath;
〰13:  using System.Xml.Xsl;
〰14:  
〰15:  //TODO: should make this async/await
〰16:  namespace BinaryDataDecoders.ToolKit.Xml.Xsl;
〰17:  
〰18:  /// <summary>
〰19:  /// Implementation of XsltTransformer
〰20:  /// </summary>
〰21:  /// <remarks>
〰22:  /// create instance of XsltTransformer
〰23:  /// </remarks>
〰24:  /// <param name="extensions">optional extensions for XSLT Transform</param>
〰25:  public class XsltTransformer(string sandbox, params object[] extensions) : IXsltTransformer
〰26:  {
‼27:      private readonly string _sandbox = sandbox;
〰28:  
〰29:      /// <summary>
〰30:      /// Read input file as XML
〰31:      /// </summary>
〰32:      /// <param name="fileName"></param>
〰33:      /// <returns></returns>
〰34:      public IXPathNavigable? ReadAsXml(string fileName)
〰35:      {
〰36:          try
〰37:          {
‼38:              var xmlreader = XmlReader.Create(fileName, new XmlReaderSettings
‼39:              {
‼40:                  DtdProcessing = DtdProcessing.Ignore,
‼41:                  ConformanceLevel = ConformanceLevel.Document,
‼42:                  NameTable = new NameTable(),
‼43:              });
‼44:              var xmlDocument = new XmlDocument();
‼45:              xmlDocument.Load(xmlreader);
‼46:              return xmlDocument;
〰47:          }
‼48:          catch
〰49:          {
‼50:              return null;
〰51:              //TODO: do something smart
〰52:          }
‼53:      }
〰54:  
〰55:      /// <summary>
〰56:      /// Single action transform
〰57:      /// </summary>
〰58:      /// <param name="template">path for XSLT style-sheet</param>
〰59:      /// <param name="input">source XML file</param>
〰60:      /// <param name="output">resulting text content</param>
‼61:      public void Transform(string template, string input, string output) => Transform(template, input, ReadAsXml(input), output);
〰62:  
〰63:      /// <summary>
〰64:      /// Single action transform
〰65:      /// </summary>
〰66:      /// <param name="template">path for XSLT style-sheet</param>
〰67:      /// <param name="inputSource"></param>
〰68:      /// <param name="input">source XML file</param>
〰69:      /// <param name="output">resulting text content</param>
〰70:      public void Transform(string template, string inputSource, IXPathNavigable input, string output)
〰71:      {
‼72:          template = PathEx.FixUpPath(template);
‼73:          inputSource = PathEx.FixUpPath(inputSource);
‼74:          output = PathEx.FixUpPath(output);
‼75:          var sandbox = PathEx.FixUpPath(_sandbox);
〰76:  
‼77:          var xsltArgumentList = new XsltArgumentList().AddExtensions(extensions);
〰78:  
‼79:          xsltArgumentList.XsltMessageEncountered += (sender, eventArgs) => Console.WriteLine($"\t\t[{Thread.CurrentThread.ManagedThreadId}]{eventArgs.Message}");
〰80:  
‼81:          XNamespace ns = this.GetXmlNamespace();
‼82:          xsltArgumentList.AddParam("files", "", new XElement(ns + "file",
‼83:              new XAttribute(nameof(template), Path.GetFullPath(template)),
‼84:              new XAttribute(nameof(input), Path.GetFullPath(inputSource)),
‼85:              new XAttribute(nameof(input) + "Type", input.GetType().AssemblyQualifiedName),
‼86:              new XAttribute(nameof(output), Path.GetFullPath(output)),
‼87:              new XAttribute(nameof(output) + "Path", Path.GetDirectoryName(Path.GetFullPath(output))),
‼88:              new XAttribute("sandbox", Path.GetFullPath(sandbox))
‼89:              ).ToXPathNavigable().CreateNavigator());
〰90:  
‼91:          var xslt = new XslCompiledTransform(false);
‼92:          using var xmlreader = XmlReader.Create(template, new XmlReaderSettings
‼93:          {
‼94:              DtdProcessing = DtdProcessing.Parse,
‼95:              ConformanceLevel = ConformanceLevel.Document,
‼96:              NameTable = new NameTable(),
‼97:          });
‼98:          var xsltSettings = new XsltSettings(false, false);
〰99:  
‼100:         xslt.Load(xmlreader, xsltSettings, null);
〰101: 
‼102:         var outputDir = Path.GetDirectoryName(output);
‼103:         if (!Directory.Exists(outputDir))
‼104:             Directory.CreateDirectory(outputDir);
‼105:         using var resultStream = File.Create(output);
〰106: 
‼107:         var currentDirectory = Environment.CurrentDirectory;
〰108:         try
〰109:         {
‼110:             var localOutfolder = Path.GetDirectoryName(output);
‼111:             if (!Directory.Exists(localOutfolder))
〰112:             {
‼113:                 Directory.CreateDirectory(localOutfolder);
〰114:             }
‼115:             Environment.CurrentDirectory = localOutfolder;
〰116: 
‼117:             var inputNavigator = input.CreateNavigator();
‼118:             inputNavigator.MoveToRoot();
〰119: 
〰120:             //var x = xslt.GetType();
〰121:             //var pf = x.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
〰122:             //var pfc = pf.First(i => i.Name == "_command");
〰123:             //var pfv = pfc.GetValue(xslt);
〰124: 
‼125:             xslt.Transform(inputNavigator, xsltArgumentList, resultStream);
‼126:         }
〰127:         finally
〰128:         {
‼129:             Environment.CurrentDirectory = currentDirectory;
‼130:         }
‼131:     }
〰132: 
〰133:     /// <summary>
〰134:     /// Multi-action transform.
〰135:     /// </summary>
〰136:     /// <param name="template">path for XSLT style-sheet</param>
〰137:     /// <param name="input">Wild card allowed for multiple files</param>
〰138:     /// <param name="output">Output and suffix per file.</param>
〰139:     public void TransformAll(string template, string input, string output, string? excludeInputSource = null) =>
‼140:         TransformAll(template, input, ReadAsXml, output, excludeInputSource);
〰141: 
〰142:     /// <summary>
〰143:     /// Multi-action transform.
〰144:     /// </summary>
〰145:     /// <param name="template">path for XSLT style-sheet</param>
〰146:     /// <param name="input">Wild card allowed for multiple files</param>
〰147:     /// <param name="inputNavigatorFactory">function to load input file into IXPathNavigable</param>
〰148:     /// <param name="output">Output and suffix per file.</param>
〰149:     public void TransformAll(string template, string input, Func<string, IXPathNavigable> inputNavigatorFactory, string output, string? excludeInputSource = null)
〰150:     {
‼151:         var inputFullPath = Path.GetFullPath(input);
‼152:         var inputDir = PathEx.GetBasePath(input);
‼153:         var excludeFiles = PathEx.EnumerateFiles(excludeInputSource);
‼154:         var inputFiles = PathEx.EnumerateFiles(input).Select(Path.GetFullPath).Except(excludeFiles.Select(Path.GetFullPath));
〰155: 
‼156:         var outputFullPath = Path.GetFullPath(output);
‼157:         var outputDir = Path.GetDirectoryName(outputFullPath);
‼158:         var outputPattern = Path.GetFileName(outputFullPath).Split('*').LastOrDefault() ?? "";
〰159: 
‼160:         Console.WriteLine($"\"{inputDir}\" => \"{outputDir}\"");
‼161:         if (!inputFiles.Any())
‼162:             throw new FileNotFoundException($"File Not Found Exception: input");
〰163: 
‼164:         static Exception innerMost(Exception ex) => ex.InnerException == null ? ex : innerMost(ex.InnerException);
〰165: 
‼166:         var errors = new List<Exception>();
〰167: #if PARALLEL
‼168:         inputFiles.AsParallel().ForAll(inputFile =>
‼169: #else
‼170:         foreach (var inputFile in inputFiles)
‼171: #endif
‼172:         {
‼173:             var inputFileClean = inputFile[inputDir.Length..].TrimStart('/', '\\');
‼174:             var removedExt = Path.ChangeExtension(inputFileClean, null);
‼175:             var outFileName = removedExt + outputPattern;
‼176:             var outputFile = Path.Combine(outputDir, outFileName);
‼177: 
‼178:             var tid = Thread.CurrentThread.ManagedThreadId;
‼179: 
‼180:             Console.WriteLine($"\t[{tid}]\"{inputFileClean}\" => \"{outFileName}\"");
‼181: 
‼182:             try
‼183:             {
‼184:                 var inputNavigator = inputNavigatorFactory(inputFile);
‼185:                 Transform(template, inputFile, inputNavigator, outputFile);
‼186:             }
‼187:             catch (Exception ex)
‼188:             {
‼189:                 var rex = innerMost(ex);
‼190:                 errors.Add(rex);
‼191:                 Console.Error.WriteLine($"!!! ERROR[{tid}]: \"{inputFileClean}\" => \"{outFileName}\" :: {rex.Message}");
‼192:                 try
‼193:                 {
‼194:                     File.AppendAllLines(outputFile, new[]
‼195:                     {
‼196:                         "",
‼197:                         new string('=', 60),
‼198:                        $"!!! ERROR !!!: {ex.Message}",
‼199:                         new string('=', 60),
‼200:                         ex.ToString()
‼201:                     });
‼202:                 }
‼203:                 catch
‼204:                 {
‼205:                     // Eat and errors!
‼206:                 }
‼207:             }
‼208:         }
‼209: #if PARALLEL
‼210:         );
〰211: #endif
‼212:         if (errors.Any())
‼213:             throw new AggregateException(errors);
‼214:     }
〰215: 
〰216:     public void TransformMerge(string template, string input, Func<string, IXPathNavigable> inputNavigatorFactory, string output, string? excludeInputSource = null)
〰217:     {
‼218:         static Exception innerMost(Exception ex) => ex.InnerException == null ? ex : innerMost(ex.InnerException);
‼219:         var tid = Thread.CurrentThread.ManagedThreadId;
〰220:         try
〰221:         {
‼222:             var inputFullPath = Path.GetFullPath(input);
‼223:             var inputDir = PathEx.GetBasePath(input);
‼224:             var excludeFiles = PathEx.EnumerateFiles(excludeInputSource);
‼225:             var inputFiles = PathEx.EnumerateFiles(input).Except(excludeFiles);
〰226: 
‼227:             if (!inputFiles.Any())
‼228:                 throw new FileNotFoundException($"input");
〰229: 
〰230:             //TODO: should probably add the file to the input navigator
‼231:             var navigators = inputFiles.Select(f => (f, (IXPathNavigable?)inputNavigatorFactory(f))).ToList();
〰232: 
〰233:             //TODO: need to figure out why this won't navigate correctly.
‼234:             var merged = navigators.MergeNavigators().CreateNavigator();
‼235:             var doc = new XmlDocument();
‼236:             doc.LoadXml(merged.OuterXml);
‼237:             merged = doc.CreateNavigator();
‼238:             merged.MoveToRoot();
‼239:             Transform(template, input, merged, output);
‼240:         }
‼241:         catch (Exception ex)
〰242:         {
‼243:             var rex = innerMost(ex);
‼244:             Console.Error.WriteLine($"ERROR[{tid}]: \"{input}\" => \"{output}\" :: {rex.Message}");
〰245:             try
〰246:             {
‼247:                 File.AppendAllLines(output, new[]
‼248:                 {
‼249:                         "",
‼250:                         new string('=', 60),
‼251:                        $"!!! ERROR !!!: {ex.Message}",
‼252:                         new string('=', 60),
‼253:                         ex.ToString()
‼254:                     });
‼255:             }
‼256:             catch
〰257:             {
〰258:                 // Eat and errors!
‼259:             }
‼260:             throw;
〰261:         }
‼262:     }
〰263: }
〰264: 
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

