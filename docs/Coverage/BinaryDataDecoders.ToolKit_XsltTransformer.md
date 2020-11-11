# BinaryDataDecoders.ToolKit.Xml.Xsl.XsltTransformer

## Summary

| Key             | Value                                                |
| :-------------- | :--------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Xsl.XsltTransformer` |
| Assembly        | `BinaryDataDecoders.ToolKit`                         |
| Coveredlines    | `0`                                                  |
| Uncoveredlines  | `132`                                                |
| Coverablelines  | `132`                                                |
| Totallines      | `249`                                                |
| Linecoverage    | `0`                                                  |
| Coveredbranches | `0`                                                  |
| Totalbranches   | `14`                                                 |
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
〰6:   using System.Dynamic;
〰7:   using System.IO;
〰8:   using System.Linq;
〰9:   using System.Linq.Expressions;
〰10:  using System.Reflection;
〰11:  using System.Threading;
〰12:  using System.Xml;
〰13:  using System.Xml.Linq;
〰14:  using System.Xml.XPath;
〰15:  using System.Xml.Xsl;
〰16:  
〰17:  //TODO: should make this async/await
〰18:  namespace BinaryDataDecoders.ToolKit.Xml.Xsl
〰19:  {
〰20:      /// <summary>
〰21:      /// Implementation of XsltTransformer
〰22:      /// </summary>
〰23:      public class XsltTransformer : IXsltTransformer
〰24:      {
〰25:          private readonly string _sandbox;
〰26:          private readonly object[] _extensions;
〰27:  
〰28:          /// <summary>
〰29:          /// create instance of XsltTransformer
〰30:          /// </summary>
〰31:          /// <param name="extensions">optional extensions for XSLT Transform</param>
‼32:          public XsltTransformer(string sandbox, params object[] extensions)
〰33:          {
‼34:              _sandbox = sandbox;
‼35:              _extensions = extensions;
‼36:          }
〰37:  
〰38:          /// <summary>
〰39:          /// Read input file as XML
〰40:          /// </summary>
〰41:          /// <param name="fileName"></param>
〰42:          /// <returns></returns>
〰43:          public IXPathNavigable ReadAsXml(string fileName)
〰44:          {
‼45:              var xmlreader = XmlReader.Create(fileName, new XmlReaderSettings
‼46:              {
‼47:                  DtdProcessing = DtdProcessing.Ignore,
‼48:                  ConformanceLevel = ConformanceLevel.Document,
‼49:                  NameTable = new NameTable(),
‼50:              });
‼51:              var xmlDocument = new XmlDocument();
‼52:              xmlDocument.Load(xmlreader);
‼53:              return xmlDocument;
〰54:          }
〰55:  
〰56:          /// <summary>
〰57:          /// Single action transform
〰58:          /// </summary>
〰59:          /// <param name="template">path for XSLT style-sheet</param>
〰60:          /// <param name="input">source XML file</param>
〰61:          /// <param name="output">resulting text content</param>
‼62:          public void Transform(string template, string input, string output) => Transform(template, input, ReadAsXml(input), output);
〰63:  
〰64:          /// <summary>
〰65:          /// Single action transform
〰66:          /// </summary>
〰67:          /// <param name="template">path for XSLT style-sheet</param>
〰68:          /// <param name="inputSource"></param>
〰69:          /// <param name="input">source XML file</param>
〰70:          /// <param name="output">resulting text content</param>
〰71:          public void Transform(string template, string inputSource, IXPathNavigable input, string output)
〰72:          {
‼73:              var xsltArgumentList = new XsltArgumentList().AddExtensions(_extensions);
〰74:  
‼75:              xsltArgumentList.XsltMessageEncountered += (sender, eventArgs) => Console.WriteLine($"\t\t[{Thread.CurrentThread.ManagedThreadId}]{eventArgs.Message}");
〰76:  
‼77:              XNamespace ns = this.GetXmlNamespace();
‼78:              xsltArgumentList.AddParam("files", "", new XElement(ns + "file",
‼79:                  new XAttribute(nameof(template), Path.GetFullPath(template)),
‼80:                  new XAttribute(nameof(input), Path.GetFullPath(inputSource)),
‼81:                  new XAttribute(nameof(input) + "Type", input.GetType().AssemblyQualifiedName),
‼82:                  new XAttribute(nameof(output), Path.GetFullPath(output)),
‼83:                  new XAttribute(nameof(output) + "Path", Path.GetDirectoryName(Path.GetFullPath(output))),
‼84:                  new XAttribute("sandbox", Path.GetFullPath(_sandbox))
‼85:                  ).ToXPathNavigable().CreateNavigator());
〰86:  
‼87:              var xslt = new XslCompiledTransform(false);
‼88:              using var xmlreader = XmlReader.Create(template, new XmlReaderSettings
‼89:              {
‼90:                  DtdProcessing = DtdProcessing.Parse,
‼91:                  ConformanceLevel = ConformanceLevel.Document,
‼92:                  NameTable = new NameTable(),
‼93:              });
‼94:              var xsltSettings = new XsltSettings(false, false);
〰95:  
‼96:              xslt.Load(xmlreader, xsltSettings, null);
〰97:  
‼98:              var outputDir = Path.GetDirectoryName(output);
‼99:              if (!Directory.Exists(outputDir)) Directory.CreateDirectory(outputDir);
‼100:             using var resultStream = File.Create(output);
〰101: 
‼102:             var currentDirectory = Environment.CurrentDirectory;
〰103:             try
〰104:             {
‼105:                 var localOutfolder = Path.GetDirectoryName(output);
‼106:                 if (!Directory.Exists(localOutfolder))
〰107:                 {
‼108:                     Directory.CreateDirectory(localOutfolder);
〰109:                 }
‼110:                 Environment.CurrentDirectory = localOutfolder;
〰111: 
‼112:                 var inputNavigator = input.CreateNavigator();
‼113:                 inputNavigator.MoveToRoot();
〰114: 
〰115:                 //var x = xslt.GetType();
〰116:                 //var pf = x.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
〰117:                 //var pfc = pf.First(i => i.Name == "_command");
〰118:                 //var pfv = pfc.GetValue(xslt);
〰119: 
‼120:                 xslt.Transform(inputNavigator, xsltArgumentList, resultStream);
‼121:             }
〰122:             finally
〰123:             {
‼124:                 Environment.CurrentDirectory = currentDirectory;
‼125:             }
‼126:         }
〰127: 
〰128:         /// <summary>
〰129:         /// Multi-action transform.
〰130:         /// </summary>
〰131:         /// <param name="template">path for XSLT style-sheet</param>
〰132:         /// <param name="input">Wild card allowed for multiple files</param>
〰133:         /// <param name="output">Output and suffix per file.</param>
〰134:         public void TransformAll(string template, string input, string output) =>
‼135:             TransformAll(template, input, ReadAsXml, output);
〰136: 
〰137:         /// <summary>
〰138:         /// Multi-action transform.
〰139:         /// </summary>
〰140:         /// <param name="template">path for XSLT style-sheet</param>
〰141:         /// <param name="input">Wild card allowed for multiple files</param>
〰142:         /// <param name="inputNavigatorFactory">function to load input file into IXPathNavigable</param>
〰143:         /// <param name="output">Output and suffix per file.</param>
〰144:         public void TransformAll(string template, string input, Func<string, IXPathNavigable> inputNavigatorFactory, string output)
〰145:         {
‼146:             var inputFullPath = Path.GetFullPath(input);
‼147:             var inputDir = PathEx.GetBasePath(input);
‼148:             var inputFiles = PathEx.EnumerateFiles(input);
〰149: 
‼150:             var outputFullPath = Path.GetFullPath(output);
‼151:             var outputDir = Path.GetDirectoryName(outputFullPath);
‼152:             var outputPattern = Path.GetFileName(outputFullPath).Split('*').LastOrDefault() ?? "";
〰153: 
‼154:             Console.WriteLine($"\"{inputDir}\" => \"{outputDir}\"");
‼155:             if (!inputFiles.Any()) throw new FileNotFoundException($"input");
〰156: 
‼157:             static Exception innerMost(Exception ex) => ex.InnerException == null ? ex : innerMost(ex.InnerException);
〰158: 
〰159: #if PARALLEL
‼160:             inputFiles.AsParallel().ForAll(inputFile =>
‼161: #else
‼162:             foreach (var inputFile in inputFiles)
‼163: #endif
‼164:             {
‼165:                 var inputFileClean = inputFile.Substring(inputDir.Length).TrimStart('/', '\\');
‼166:                 var removedExt = Path.ChangeExtension(inputFileClean, null);
‼167:                 var outFileName = removedExt + outputPattern;
‼168:                 var outputFile = Path.Combine(outputDir, outFileName);
‼169: 
‼170:                 var tid = Thread.CurrentThread.ManagedThreadId;
‼171: 
‼172:                 Console.WriteLine($"\t[{tid}]\"{inputFileClean}\" => \"{outFileName}\"");
‼173: 
‼174:                 try
‼175:                 {
‼176:                     var inputNavigator = inputNavigatorFactory(inputFile);
‼177:                     Transform(template, inputFile, inputNavigator, outputFile);
‼178:                 }
‼179:                 catch (Exception ex)
‼180:                 {
‼181:                     var rex = innerMost(ex);
‼182:                     Console.Error.WriteLine($"!!! ERROR[{tid}]: \"{inputFileClean}\" => \"{outFileName}\" :: {rex.Message}");
‼183:                     try
‼184:                     {
‼185:                         File.AppendAllLines(outputFile, new[]
‼186:                         {
‼187:                             "",
‼188:                             new string('=', 60),
‼189:                            $"!!! ERROR !!!: {ex.Message}",
‼190:                             new string('=', 60),
‼191:                             ex.ToString()
‼192:                         });
‼193:                     }
‼194:                     catch
‼195:                     {
‼196:                         // Eat and errors!
‼197:                     }
‼198:                 }
‼199:             }
‼200: #if PARALLEL
‼201:             );
〰202: #endif
‼203:         }
〰204: 
〰205:         public void TransformMerge(string template, string input, Func<string, IXPathNavigable> inputNavigatorFactory, string output)
〰206:         {
‼207:             static Exception innerMost(Exception ex) => ex.InnerException == null ? ex : innerMost(ex.InnerException);
‼208:             var tid = Thread.CurrentThread.ManagedThreadId;
〰209:             try
〰210:             {
‼211:                 var inputFullPath = Path.GetFullPath(input);
‼212:                 var inputDir = PathEx.GetBasePath(input);
‼213:                 var inputFiles = PathEx.EnumerateFiles(input);
〰214: 
‼215:                 if (!inputFiles.Any()) throw new FileNotFoundException($"input");
〰216: 
‼217:                 var navigators = inputFiles.Select(f => inputNavigatorFactory(f)).ToList();
〰218: 
〰219:                 //TODO: need to figoure out why this wont navigate correctly.
‼220:                 var merged = navigators.MergeNavigators().CreateNavigator();
‼221:                 var doc = new XmlDocument();
‼222:                 doc.LoadXml(merged.OuterXml);
‼223:                 merged = doc.CreateNavigator();
‼224:                 merged.MoveToRoot();
‼225:                 Transform(template, input, merged, output);
‼226:             }
‼227:             catch (Exception ex)
〰228:             {
‼229:                 var rex = innerMost(ex);
‼230:                 Console.Error.WriteLine($"ERROR[{tid}]: \"{input}\" => \"{output}\" :: {rex.Message}");
〰231:                 try
〰232:                 {
‼233:                     File.AppendAllLines(output, new[]
‼234:                     {
‼235:                             "",
‼236:                             new string('=', 60),
‼237:                            $"!!! ERROR !!!: {ex.Message}",
‼238:                             new string('=', 60),
‼239:                             ex.ToString()
‼240:                         });
‼241:                 }
‼242:                 catch
〰243:                 {
〰244:                     // Eat and errors!
‼245:                 }
‼246:             }
‼247:         }
〰248:     }
〰249: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

