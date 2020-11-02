# BinaryDataDecoders.ToolKit.Xml.Xsl.XsltTransformer

## Summary

| Key             | Value                                                |
| :-------------- | :--------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Xsl.XsltTransformer` |
| Assembly        | `BinaryDataDecoders.ToolKit`                         |
| Coveredlines    | `0`                                                  |
| Uncoveredlines  | `130`                                                |
| Coverablelines  | `130`                                                |
| Totallines      | `240`                                                |
| Linecoverage    | `0`                                                  |
| Coveredbranches | `0`                                                  |
| Totalbranches   | `10`                                                 |
| Branchcoverage  | `0`                                                  |

## Metrics

| Complexity | Lines | Branches | Name             |
| :--------- | :---- | :------- | :--------------- |
| 1          | 0     | 100      | `ctor`           |
| 1          | 0     | 100      | `ReadAsXml`      |
| 1          | 0     | 100      | `Transform`      |
| 4          | 0     | 0        | `Transform`      |
| 1          | 0     | 100      | `TransformAll`   |
| 4          | 0     | 0        | `TransformAll`   |
| 2          | 0     | 0        | `TransformMerge` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\Xsl\XsltTransformer.cs

```CSharp
〰1:   #define PARALLEL
〰2:   
〰3:   using BinaryDataDecoders.ToolKit.IO;
〰4:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰5:   using System;
〰6:   using System.IO;
〰7:   using System.Linq;
〰8:   using System.Threading;
〰9:   using System.Xml;
〰10:  using System.Xml.Linq;
〰11:  using System.Xml.XPath;
〰12:  using System.Xml.Xsl;
〰13:  
〰14:  //TODO: should make this async/await
〰15:  namespace BinaryDataDecoders.ToolKit.Xml.Xsl
〰16:  {
〰17:      /// <summary>
〰18:      /// Implementation of XsltTransformer
〰19:      /// </summary>
〰20:      public class XsltTransformer : IXsltTransformer
〰21:      {
〰22:          private readonly string _sandbox;
〰23:          private readonly object[] _extensions;
〰24:  
〰25:          /// <summary>
〰26:          /// create instance of XsltTransformer
〰27:          /// </summary>
〰28:          /// <param name="extensions">optional extensions for XSLT Transform</param>
‼29:          public XsltTransformer(string sandbox, params object[] extensions)
〰30:          {
‼31:              _sandbox = sandbox;
‼32:              _extensions = extensions;
‼33:          }
〰34:  
〰35:          /// <summary>
〰36:          /// Read input file as XML
〰37:          /// </summary>
〰38:          /// <param name="fileName"></param>
〰39:          /// <returns></returns>
〰40:          public IXPathNavigable ReadAsXml(string fileName)
〰41:          {
‼42:              var xmlreader = XmlReader.Create(fileName, new XmlReaderSettings
‼43:              {
‼44:                  DtdProcessing = DtdProcessing.Ignore,
‼45:                  ConformanceLevel = ConformanceLevel.Document,
‼46:                  NameTable = new NameTable(),
‼47:              });
‼48:              var xmlDocument = new XmlDocument();
‼49:              xmlDocument.Load(xmlreader);
‼50:              return xmlDocument;
〰51:          }
〰52:  
〰53:          /// <summary>
〰54:          /// Single action transform
〰55:          /// </summary>
〰56:          /// <param name="template">path for XSLT style-sheet</param>
〰57:          /// <param name="input">source XML file</param>
〰58:          /// <param name="output">resulting text content</param>
‼59:          public void Transform(string template, string input, string output) => Transform(template, input, ReadAsXml(input), output);
〰60:  
〰61:          /// <summary>
〰62:          /// Single action transform
〰63:          /// </summary>
〰64:          /// <param name="template">path for XSLT style-sheet</param>
〰65:          /// <param name="inputSource"></param>
〰66:          /// <param name="input">source XML file</param>
〰67:          /// <param name="output">resulting text content</param>
〰68:          public void Transform(string template, string inputSource, IXPathNavigable input, string output)
〰69:          {
‼70:              var xsltArgumentList = new XsltArgumentList().AddExtensions(_extensions);
〰71:  
‼72:              xsltArgumentList.XsltMessageEncountered += (sender, eventArgs) => Console.WriteLine($"\t\t[{Thread.CurrentThread.ManagedThreadId}]{eventArgs.Message}");
〰73:  
‼74:              XNamespace ns = this.GetXmlNamespace();
‼75:              xsltArgumentList.AddParam("files", "", new XElement(ns + "file",
‼76:                  new XAttribute(nameof(template), Path.GetFullPath(template)),
‼77:                  new XAttribute(nameof(input), Path.GetFullPath(inputSource)),
‼78:                  new XAttribute(nameof(input) + "Type", input.GetType().AssemblyQualifiedName),
‼79:                  new XAttribute(nameof(output), Path.GetFullPath(output)),
‼80:                  new XAttribute(nameof(output) + "Path", Path.GetDirectoryName(Path.GetFullPath(output))),
‼81:                  new XAttribute("sandbox", Path.GetFullPath(_sandbox))
‼82:                  ).ToXPathNavigable().CreateNavigator());
〰83:  
‼84:              var xslt = new XslCompiledTransform(false);
‼85:              using var xmlreader = XmlReader.Create(template, new XmlReaderSettings
‼86:              {
‼87:                  DtdProcessing = DtdProcessing.Parse,
‼88:                  ConformanceLevel = ConformanceLevel.Document,
‼89:                  NameTable = new NameTable(),
‼90:              });
‼91:              var xsltSettings = new XsltSettings(false, false);
〰92:  
‼93:              xslt.Load(xmlreader, xsltSettings, null);
〰94:  
‼95:              var outputDir = Path.GetDirectoryName(output);
‼96:              if (!Directory.Exists(outputDir)) Directory.CreateDirectory(outputDir);
‼97:              using var resultStream = File.Create(output);
〰98:  
‼99:              var currentDirectory = Environment.CurrentDirectory;
〰100:             try
〰101:             {
‼102:                 var localOutfolder = Path.GetDirectoryName(output);
‼103:                 if (!Directory.Exists(localOutfolder))
〰104:                 {
‼105:                     Directory.CreateDirectory(localOutfolder);
〰106:                 }
‼107:                 Environment.CurrentDirectory = localOutfolder;
〰108: 
‼109:                 var inputNavigator = input.CreateNavigator();
‼110:                 inputNavigator.MoveToRoot();
‼111:                 xslt.Transform(inputNavigator, xsltArgumentList, resultStream);
‼112:             }
〰113:             finally
〰114:             {
‼115:                 Environment.CurrentDirectory = currentDirectory;
‼116:             }
‼117:         }
〰118: 
〰119:         /// <summary>
〰120:         /// Multi-action transform.
〰121:         /// </summary>
〰122:         /// <param name="template">path for XSLT style-sheet</param>
〰123:         /// <param name="input">Wild card allowed for multiple files</param>
〰124:         /// <param name="output">Output and suffix per file.</param>
〰125:         public void TransformAll(string template, string input, string output) =>
‼126:             TransformAll(template, input, ReadAsXml, output);
〰127: 
〰128:         /// <summary>
〰129:         /// Multi-action transform.
〰130:         /// </summary>
〰131:         /// <param name="template">path for XSLT style-sheet</param>
〰132:         /// <param name="input">Wild card allowed for multiple files</param>
〰133:         /// <param name="inputNavigatorFactory">function to load input file into IXPathNavigable</param>
〰134:         /// <param name="output">Output and suffix per file.</param>
〰135:         public void TransformAll(string template, string input, Func<string, IXPathNavigable> inputNavigatorFactory, string output)
〰136:         {
‼137:             var inputFullPath = Path.GetFullPath(input);
‼138:             var inputDir = PathEx.GetBasePath(input);
‼139:             var inputFiles = PathEx.EnumerateFiles(input);
〰140: 
‼141:             var outputFullPath = Path.GetFullPath(output);
‼142:             var outputDir = Path.GetDirectoryName(outputFullPath);
‼143:             var outputPattern = Path.GetFileName(outputFullPath).Split('*').LastOrDefault() ?? "";
〰144: 
‼145:             Console.WriteLine($"\"{inputDir}\" => \"{outputDir}\"");
‼146:             if (!inputFiles.Any()) throw new FileNotFoundException($"input");
〰147: 
〰148:             static Exception innerMost(Exception ex) => ex.InnerException == null ? ex : innerMost(ex.InnerException);
〰149: 
〰150: #if PARALLEL
‼151:             inputFiles.AsParallel().ForAll(inputFile =>
‼152: #else
‼153:             foreach (var inputFile in inputFiles)
‼154: #endif
‼155:             {
‼156:                 var inputFileClean = inputFile.Substring(inputDir.Length).TrimStart('/', '\\');
‼157:                 var removedExt = Path.ChangeExtension(inputFileClean, null);
‼158:                 var outFileName = removedExt + outputPattern;
‼159:                 var outputFile = Path.Combine(outputDir, outFileName);
‼160: 
‼161:                 var tid = Thread.CurrentThread.ManagedThreadId;
‼162: 
‼163:                 Console.WriteLine($"\t[{tid}]\"{inputFileClean}\" => \"{outFileName}\"");
‼164: 
‼165:                 try
‼166:                 {
‼167:                     var inputNavigator = inputNavigatorFactory(inputFile);
‼168:                     Transform(template, inputFile, inputNavigator, outputFile);
‼169:                 }
‼170:                 catch (Exception ex)
‼171:                 {
‼172:                     var rex = innerMost(ex);
‼173:                     Console.Error.WriteLine($"!!! ERROR[{tid}]: \"{inputFileClean}\" => \"{outFileName}\" :: {rex.Message}");
‼174:                     try
‼175:                     {
‼176:                         File.AppendAllLines(outputFile, new[]
‼177:                         {
‼178:                             "",
‼179:                             new string('=', 60),
‼180:                            $"!!! ERROR !!!: {ex.Message}",
‼181:                             new string('=', 60),
‼182:                             ex.ToString()
‼183:                         });
‼184:                     }
‼185:                     catch
‼186:                     {
‼187:                         // Eat and errors!
‼188:                     }
‼189:                 }
‼190:             }
‼191: #if PARALLEL
‼192:             );
〰193: #endif
‼194:         }
〰195: 
〰196:         public void TransformMerge(string template, string input, Func<string, IXPathNavigable> inputNavigatorFactory, string output)
〰197:         {
〰198:             static Exception innerMost(Exception ex) => ex.InnerException == null ? ex : innerMost(ex.InnerException);
‼199:             var tid = Thread.CurrentThread.ManagedThreadId;
〰200:             try
〰201:             {
‼202:                 var inputFullPath = Path.GetFullPath(input);
‼203:                 var inputDir = PathEx.GetBasePath(input);
‼204:                 var inputFiles = PathEx.EnumerateFiles(input);
〰205: 
‼206:                 if (!inputFiles.Any()) throw new FileNotFoundException($"input");
〰207: 
‼208:                 var navigators = inputFiles.Select(f => inputNavigatorFactory(f)).ToList();
〰209: 
〰210:                 //TODO: need to figoure out why this wont navigate correctly.
‼211:                 var merged = navigators.MergeNavigators().CreateNavigator();
‼212:                 var doc = new XmlDocument();
‼213:                 doc.LoadXml(merged.OuterXml);
‼214:                 merged = doc.CreateNavigator();
‼215:                 merged.MoveToRoot();
‼216:                 Transform(template, input, merged, output);
‼217:             }
‼218:             catch (Exception ex)
〰219:             {
‼220:                 var rex = innerMost(ex);
‼221:                 Console.Error.WriteLine($"ERROR[{tid}]: \"{input}\" => \"{output}\" :: {rex.Message}");
〰222:                 try
〰223:                 {
‼224:                     File.AppendAllLines(output, new[]
‼225:                     {
‼226:                             "",
‼227:                             new string('=', 60),
‼228:                            $"!!! ERROR !!!: {ex.Message}",
‼229:                             new string('=', 60),
‼230:                             ex.ToString()
‼231:                         });
‼232:                 }
‼233:                 catch
〰234:                 {
〰235:                     // Eat and errors!
‼236:                 }
‼237:             }
‼238:         }
〰239:     }
〰240: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

