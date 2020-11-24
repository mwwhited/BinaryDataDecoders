# BinaryDataDecoders.ToolKit.Xml.Xsl.XsltTransformer

## Summary

| Key             | Value                                                |
| :-------------- | :--------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Xsl.XsltTransformer` |
| Assembly        | `BinaryDataDecoders.ToolKit`                         |
| Coveredlines    | `0`                                                  |
| Uncoveredlines  | `138`                                                |
| Coverablelines  | `138`                                                |
| Totallines      | `260`                                                |
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

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\Xsl\XsltTransformer.cs

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
‼79:              var xsltArgumentList = new XsltArgumentList().AddExtensions(_extensions);
〰80:  
‼81:              xsltArgumentList.XsltMessageEncountered += (sender, eventArgs) => Console.WriteLine($"\t\t[{Thread.CurrentThread.ManagedThreadId}]{eventArgs.Message}");
〰82:  
‼83:              XNamespace ns = this.GetXmlNamespace();
‼84:              xsltArgumentList.AddParam("files", "", new XElement(ns + "file",
‼85:                  new XAttribute(nameof(template), Path.GetFullPath(template)),
‼86:                  new XAttribute(nameof(input), Path.GetFullPath(inputSource)),
‼87:                  new XAttribute(nameof(input) + "Type", input.GetType().AssemblyQualifiedName),
‼88:                  new XAttribute(nameof(output), Path.GetFullPath(output)),
‼89:                  new XAttribute(nameof(output) + "Path", Path.GetDirectoryName(Path.GetFullPath(output))),
‼90:                  new XAttribute("sandbox", Path.GetFullPath(_sandbox))
‼91:                  ).ToXPathNavigable().CreateNavigator());
〰92:  
‼93:              var xslt = new XslCompiledTransform(false);
‼94:              using var xmlreader = XmlReader.Create(template, new XmlReaderSettings
‼95:              {
‼96:                  DtdProcessing = DtdProcessing.Parse,
‼97:                  ConformanceLevel = ConformanceLevel.Document,
‼98:                  NameTable = new NameTable(),
‼99:              });
‼100:             var xsltSettings = new XsltSettings(false, false);
〰101: 
‼102:             xslt.Load(xmlreader, xsltSettings, null);
〰103: 
‼104:             var outputDir = Path.GetDirectoryName(output);
‼105:             if (!Directory.Exists(outputDir)) Directory.CreateDirectory(outputDir);
‼106:             using var resultStream = File.Create(output);
〰107: 
‼108:             var currentDirectory = Environment.CurrentDirectory;
〰109:             try
〰110:             {
‼111:                 var localOutfolder = Path.GetDirectoryName(output);
‼112:                 if (!Directory.Exists(localOutfolder))
〰113:                 {
‼114:                     Directory.CreateDirectory(localOutfolder);
〰115:                 }
‼116:                 Environment.CurrentDirectory = localOutfolder;
〰117: 
‼118:                 var inputNavigator = input.CreateNavigator();
‼119:                 inputNavigator.MoveToRoot();
〰120: 
〰121:                 //var x = xslt.GetType();
〰122:                 //var pf = x.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
〰123:                 //var pfc = pf.First(i => i.Name == "_command");
〰124:                 //var pfv = pfc.GetValue(xslt);
〰125: 
‼126:                 xslt.Transform(inputNavigator, xsltArgumentList, resultStream);
‼127:             }
〰128:             finally
〰129:             {
‼130:                 Environment.CurrentDirectory = currentDirectory;
‼131:             }
‼132:         }
〰133: 
〰134:         /// <summary>
〰135:         /// Multi-action transform.
〰136:         /// </summary>
〰137:         /// <param name="template">path for XSLT style-sheet</param>
〰138:         /// <param name="input">Wild card allowed for multiple files</param>
〰139:         /// <param name="output">Output and suffix per file.</param>
〰140:         public void TransformAll(string template, string input, string output) =>
‼141:             TransformAll(template, input, ReadAsXml, output);
〰142: 
〰143:         /// <summary>
〰144:         /// Multi-action transform.
〰145:         /// </summary>
〰146:         /// <param name="template">path for XSLT style-sheet</param>
〰147:         /// <param name="input">Wild card allowed for multiple files</param>
〰148:         /// <param name="inputNavigatorFactory">function to load input file into IXPathNavigable</param>
〰149:         /// <param name="output">Output and suffix per file.</param>
〰150:         public void TransformAll(string template, string input, Func<string, IXPathNavigable> inputNavigatorFactory, string output)
〰151:         {
‼152:             var inputFullPath = Path.GetFullPath(input);
‼153:             var inputDir = PathEx.GetBasePath(input);
‼154:             var inputFiles = PathEx.EnumerateFiles(input);
〰155: 
‼156:             var outputFullPath = Path.GetFullPath(output);
‼157:             var outputDir = Path.GetDirectoryName(outputFullPath);
‼158:             var outputPattern = Path.GetFileName(outputFullPath).Split('*').LastOrDefault() ?? "";
〰159: 
‼160:             Console.WriteLine($"\"{inputDir}\" => \"{outputDir}\"");
‼161:             if (!inputFiles.Any()) throw new FileNotFoundException($"input");
〰162: 
‼163:             static Exception innerMost(Exception ex) => ex.InnerException == null ? ex : innerMost(ex.InnerException);
〰164: 
‼165:             var errors = new List<Exception>();
〰166: #if PARALLEL
‼167:             inputFiles.AsParallel().ForAll(inputFile =>
‼168: #else
‼169:             foreach (var inputFile in inputFiles)
‼170: #endif
‼171:             {
‼172:                 var inputFileClean = inputFile.Substring(inputDir.Length).TrimStart('/', '\\');
‼173:                 var removedExt = Path.ChangeExtension(inputFileClean, null);
‼174:                 var outFileName = removedExt + outputPattern;
‼175:                 var outputFile = Path.Combine(outputDir, outFileName);
‼176: 
‼177:                 var tid = Thread.CurrentThread.ManagedThreadId;
‼178: 
‼179:                 Console.WriteLine($"\t[{tid}]\"{inputFileClean}\" => \"{outFileName}\"");
‼180: 
‼181:                 try
‼182:                 {
‼183:                     var inputNavigator = inputNavigatorFactory(inputFile);
‼184:                     Transform(template, inputFile, inputNavigator, outputFile);
‼185:                 }
‼186:                 catch (Exception ex)
‼187:                 {
‼188:                     var rex = innerMost(ex);
‼189:                     errors.Add(rex);
‼190:                     Console.Error.WriteLine($"!!! ERROR[{tid}]: \"{inputFileClean}\" => \"{outFileName}\" :: {rex.Message}");
‼191:                     try
‼192:                     {
‼193:                         File.AppendAllLines(outputFile, new[]
‼194:                         {
‼195:                             "",
‼196:                             new string('=', 60),
‼197:                            $"!!! ERROR !!!: {ex.Message}",
‼198:                             new string('=', 60),
‼199:                             ex.ToString()
‼200:                         });
‼201:                     }
‼202:                     catch
‼203:                     {
‼204:                         // Eat and errors!
‼205:                     }
‼206:                 }
‼207:             }
‼208: #if PARALLEL
‼209:             );
〰210: #endif
‼211:             if (errors.Any()) throw new AggregateException(errors);
‼212:         }
〰213: 
〰214:         public void TransformMerge(string template, string input, Func<string, IXPathNavigable> inputNavigatorFactory, string output)
〰215:         {
‼216:             static Exception innerMost(Exception ex) => ex.InnerException == null ? ex : innerMost(ex.InnerException);
‼217:             var tid = Thread.CurrentThread.ManagedThreadId;
〰218:             try
〰219:             {
‼220:                 var inputFullPath = Path.GetFullPath(input);
‼221:                 var inputDir = PathEx.GetBasePath(input);
‼222:                 var inputFiles = PathEx.EnumerateFiles(input);
〰223: 
‼224:                 if (!inputFiles.Any()) throw new FileNotFoundException($"input");
〰225: 
〰226:                 //TODO: should probably add the file to the input navigator
‼227:                 var navigators = inputFiles.Select(f => (f, (IXPathNavigable?)inputNavigatorFactory(f))).ToList();
〰228: 
〰229:                 //TODO: need to figure out why this won't navigate correctly.
‼230:                 var merged = navigators.MergeNavigators().CreateNavigator();
‼231:                 var doc = new XmlDocument();
‼232:                 doc.LoadXml(merged.OuterXml);
‼233:                 merged = doc.CreateNavigator();
‼234:                 merged.MoveToRoot();
‼235:                 Transform(template, input, merged, output);
‼236:             }
‼237:             catch (Exception ex)
〰238:             {
‼239:                 var rex = innerMost(ex);
‼240:                 Console.Error.WriteLine($"ERROR[{tid}]: \"{input}\" => \"{output}\" :: {rex.Message}");
〰241:                 try
〰242:                 {
‼243:                     File.AppendAllLines(output, new[]
‼244:                     {
‼245:                             "",
‼246:                             new string('=', 60),
‼247:                            $"!!! ERROR !!!: {ex.Message}",
‼248:                             new string('=', 60),
‼249:                             ex.ToString()
‼250:                         });
‼251:                 }
‼252:                 catch
〰253:                 {
〰254:                     // Eat and errors!
‼255:                 }
‼256:                 throw;
〰257:             }
‼258:         }
〰259:     }
〰260: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

