# BinaryDataDecoders.ToolKit.Xml.Xsl.XsltTransformer

## Summary

| Key             | Value                                                |
| :-------------- | :--------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Xsl.XsltTransformer` |
| Assembly        | `BinaryDataDecoders.ToolKit`                         |
| Coveredlines    | `0`                                                  |
| Uncoveredlines  | `142`                                                |
| Coverablelines  | `142`                                                |
| Totallines      | `265`                                                |
| Linecoverage    | `0`                                                  |
| Coveredbranches | `0`                                                  |
| Totalbranches   | `16`                                                 |
| Branchcoverage  | `0`                                                  |

## Metrics

| Complexity | Lines | Branches | Name             |
| :--------- | :---- | :------- | :--------------- |
| 1          | 0     | 100      | `ctor`           |
| 1          | 0     | 100      | `ReadAsXml`      |
| 1          | 0     | 100      | `Transform`      |
| 4          | 0     | 0        | `Transform`      |
| 1          | 0     | 100      | `TransformAll`   |
| 6          | 0     | 0        | `TransformAll`   |
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
〰16:  namespace BinaryDataDecoders.ToolKit.Xml.Xsl
〰17:  {
〰18:      /// <summary>
〰19:      /// Implementation of XsltTransformer
〰20:      /// </summary>
〰21:      public class XsltTransformer : IXsltTransformer
〰22:      {
〰23:          private readonly string _sandbox;
〰24:          private readonly object[] _extensions;
〰25:  
〰26:          /// <summary>
〰27:          /// create instance of XsltTransformer
〰28:          /// </summary>
〰29:          /// <param name="extensions">optional extensions for XSLT Transform</param>
‼30:          public XsltTransformer(string sandbox, params object[] extensions)
〰31:          {
‼32:              _sandbox = sandbox;
‼33:              _extensions = extensions;
‼34:          }
〰35:  
〰36:          /// <summary>
〰37:          /// Read input file as XML
〰38:          /// </summary>
〰39:          /// <param name="fileName"></param>
〰40:          /// <returns></returns>
〰41:          public IXPathNavigable? ReadAsXml(string fileName)
〰42:          {
〰43:              try
〰44:              {
‼45:                  var xmlreader = XmlReader.Create(fileName, new XmlReaderSettings
‼46:                  {
‼47:                      DtdProcessing = DtdProcessing.Ignore,
‼48:                      ConformanceLevel = ConformanceLevel.Document,
‼49:                      NameTable = new NameTable(),
‼50:                  });
‼51:                  var xmlDocument = new XmlDocument();
‼52:                  xmlDocument.Load(xmlreader);
‼53:                  return xmlDocument;
〰54:              }
‼55:              catch
〰56:              {
‼57:                  return null;
〰58:                  //TODO: do something smart
〰59:              }
‼60:          }
〰61:  
〰62:          /// <summary>
〰63:          /// Single action transform
〰64:          /// </summary>
〰65:          /// <param name="template">path for XSLT style-sheet</param>
〰66:          /// <param name="input">source XML file</param>
〰67:          /// <param name="output">resulting text content</param>
‼68:          public void Transform(string template, string input, string output) => Transform(template, input, ReadAsXml(input), output);
〰69:  
〰70:          /// <summary>
〰71:          /// Single action transform
〰72:          /// </summary>
〰73:          /// <param name="template">path for XSLT style-sheet</param>
〰74:          /// <param name="inputSource"></param>
〰75:          /// <param name="input">source XML file</param>
〰76:          /// <param name="output">resulting text content</param>
〰77:          public void Transform(string template, string inputSource, IXPathNavigable input, string output)
〰78:          {
‼79:              template = PathEx.FixUpPath(template);
‼80:              inputSource = PathEx.FixUpPath(inputSource);
‼81:              output = PathEx.FixUpPath(output);
‼82:              var sandbox = PathEx.FixUpPath(_sandbox);
〰83:  
‼84:              var xsltArgumentList = new XsltArgumentList().AddExtensions(_extensions);
〰85:  
‼86:              xsltArgumentList.XsltMessageEncountered += (sender, eventArgs) => Console.WriteLine($"\t\t[{Thread.CurrentThread.ManagedThreadId}]{eventArgs.Message}");
〰87:  
‼88:              XNamespace ns = this.GetXmlNamespace();
‼89:              xsltArgumentList.AddParam("files", "", new XElement(ns + "file",
‼90:                  new XAttribute(nameof(template), Path.GetFullPath(template)),
‼91:                  new XAttribute(nameof(input), Path.GetFullPath(inputSource)),
‼92:                  new XAttribute(nameof(input) + "Type", input.GetType().AssemblyQualifiedName),
‼93:                  new XAttribute(nameof(output), Path.GetFullPath(output)),
‼94:                  new XAttribute(nameof(output) + "Path", Path.GetDirectoryName(Path.GetFullPath(output))),
‼95:                  new XAttribute("sandbox", Path.GetFullPath(sandbox))
‼96:                  ).ToXPathNavigable().CreateNavigator());
〰97:  
‼98:              var xslt = new XslCompiledTransform(false);
‼99:              using var xmlreader = XmlReader.Create(template, new XmlReaderSettings
‼100:             {
‼101:                 DtdProcessing = DtdProcessing.Parse,
‼102:                 ConformanceLevel = ConformanceLevel.Document,
‼103:                 NameTable = new NameTable(),
‼104:             });
‼105:             var xsltSettings = new XsltSettings(false, false);
〰106: 
‼107:             xslt.Load(xmlreader, xsltSettings, null);
〰108: 
‼109:             var outputDir = Path.GetDirectoryName(output);
‼110:             if (!Directory.Exists(outputDir)) Directory.CreateDirectory(outputDir);
‼111:             using var resultStream = File.Create(output);
〰112: 
‼113:             var currentDirectory = Environment.CurrentDirectory;
〰114:             try
〰115:             {
‼116:                 var localOutfolder = Path.GetDirectoryName(output);
‼117:                 if (!Directory.Exists(localOutfolder))
〰118:                 {
‼119:                     Directory.CreateDirectory(localOutfolder);
〰120:                 }
‼121:                 Environment.CurrentDirectory = localOutfolder;
〰122: 
‼123:                 var inputNavigator = input.CreateNavigator();
‼124:                 inputNavigator.MoveToRoot();
〰125: 
〰126:                 //var x = xslt.GetType();
〰127:                 //var pf = x.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
〰128:                 //var pfc = pf.First(i => i.Name == "_command");
〰129:                 //var pfv = pfc.GetValue(xslt);
〰130: 
‼131:                 xslt.Transform(inputNavigator, xsltArgumentList, resultStream);
‼132:             }
〰133:             finally
〰134:             {
‼135:                 Environment.CurrentDirectory = currentDirectory;
‼136:             }
‼137:         }
〰138: 
〰139:         /// <summary>
〰140:         /// Multi-action transform.
〰141:         /// </summary>
〰142:         /// <param name="template">path for XSLT style-sheet</param>
〰143:         /// <param name="input">Wild card allowed for multiple files</param>
〰144:         /// <param name="output">Output and suffix per file.</param>
〰145:         public void TransformAll(string template, string input, string output) =>
‼146:             TransformAll(template, input, ReadAsXml, output);
〰147: 
〰148:         /// <summary>
〰149:         /// Multi-action transform.
〰150:         /// </summary>
〰151:         /// <param name="template">path for XSLT style-sheet</param>
〰152:         /// <param name="input">Wild card allowed for multiple files</param>
〰153:         /// <param name="inputNavigatorFactory">function to load input file into IXPathNavigable</param>
〰154:         /// <param name="output">Output and suffix per file.</param>
〰155:         public void TransformAll(string template, string input, Func<string, IXPathNavigable> inputNavigatorFactory, string output)
〰156:         {
‼157:             var inputFullPath = Path.GetFullPath(input);
‼158:             var inputDir = PathEx.GetBasePath(input);
‼159:             var inputFiles = PathEx.EnumerateFiles(input);
〰160: 
‼161:             var outputFullPath = Path.GetFullPath(output);
‼162:             var outputDir = Path.GetDirectoryName(outputFullPath);
‼163:             var outputPattern = Path.GetFileName(outputFullPath).Split('*').LastOrDefault() ?? "";
〰164: 
‼165:             Console.WriteLine($"\"{inputDir}\" => \"{outputDir}\"");
‼166:             if (!inputFiles.Any()) throw new FileNotFoundException($"input");
〰167: 
‼168:             static Exception innerMost(Exception ex) => ex.InnerException == null ? ex : innerMost(ex.InnerException);
〰169: 
‼170:             var errors = new List<Exception>();
〰171: #if PARALLEL
‼172:             inputFiles.AsParallel().ForAll(inputFile =>
‼173: #else
‼174:             foreach (var inputFile in inputFiles)
‼175: #endif
‼176:             {
‼177:                 var inputFileClean = inputFile.Substring(inputDir.Length).TrimStart('/', '\\');
‼178:                 var removedExt = Path.ChangeExtension(inputFileClean, null);
‼179:                 var outFileName = removedExt + outputPattern;
‼180:                 var outputFile = Path.Combine(outputDir, outFileName);
‼181: 
‼182:                 var tid = Thread.CurrentThread.ManagedThreadId;
‼183: 
‼184:                 Console.WriteLine($"\t[{tid}]\"{inputFileClean}\" => \"{outFileName}\"");
‼185: 
‼186:                 try
‼187:                 {
‼188:                     var inputNavigator = inputNavigatorFactory(inputFile);
‼189:                     Transform(template, inputFile, inputNavigator, outputFile);
‼190:                 }
‼191:                 catch (Exception ex)
‼192:                 {
‼193:                     var rex = innerMost(ex);
‼194:                     errors.Add(rex);
‼195:                     Console.Error.WriteLine($"!!! ERROR[{tid}]: \"{inputFileClean}\" => \"{outFileName}\" :: {rex.Message}");
‼196:                     try
‼197:                     {
‼198:                         File.AppendAllLines(outputFile, new[]
‼199:                         {
‼200:                             "",
‼201:                             new string('=', 60),
‼202:                            $"!!! ERROR !!!: {ex.Message}",
‼203:                             new string('=', 60),
‼204:                             ex.ToString()
‼205:                         });
‼206:                     }
‼207:                     catch
‼208:                     {
‼209:                         // Eat and errors!
‼210:                     }
‼211:                 }
‼212:             }
‼213: #if PARALLEL
‼214:             );
〰215: #endif
‼216:             if (errors.Any()) throw new AggregateException(errors);
‼217:         }
〰218: 
〰219:         public void TransformMerge(string template, string input, Func<string, IXPathNavigable> inputNavigatorFactory, string output)
〰220:         {
‼221:             static Exception innerMost(Exception ex) => ex.InnerException == null ? ex : innerMost(ex.InnerException);
‼222:             var tid = Thread.CurrentThread.ManagedThreadId;
〰223:             try
〰224:             {
‼225:                 var inputFullPath = Path.GetFullPath(input);
‼226:                 var inputDir = PathEx.GetBasePath(input);
‼227:                 var inputFiles = PathEx.EnumerateFiles(input);
〰228: 
‼229:                 if (!inputFiles.Any()) throw new FileNotFoundException($"input");
〰230: 
〰231:                 //TODO: should probably add the file to the input navigator
‼232:                 var navigators = inputFiles.Select(f => (f, (IXPathNavigable?)inputNavigatorFactory(f))).ToList();
〰233: 
〰234:                 //TODO: need to figure out why this won't navigate correctly.
‼235:                 var merged = navigators.MergeNavigators().CreateNavigator();
‼236:                 var doc = new XmlDocument();
‼237:                 doc.LoadXml(merged.OuterXml);
‼238:                 merged = doc.CreateNavigator();
‼239:                 merged.MoveToRoot();
‼240:                 Transform(template, input, merged, output);
‼241:             }
‼242:             catch (Exception ex)
〰243:             {
‼244:                 var rex = innerMost(ex);
‼245:                 Console.Error.WriteLine($"ERROR[{tid}]: \"{input}\" => \"{output}\" :: {rex.Message}");
〰246:                 try
〰247:                 {
‼248:                     File.AppendAllLines(output, new[]
‼249:                     {
‼250:                             "",
‼251:                             new string('=', 60),
‼252:                            $"!!! ERROR !!!: {ex.Message}",
‼253:                             new string('=', 60),
‼254:                             ex.ToString()
‼255:                         });
‼256:                 }
‼257:                 catch
〰258:                 {
〰259:                     // Eat and errors!
‼260:                 }
‼261:                 throw;
〰262:             }
‼263:         }
〰264:     }
〰265: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

