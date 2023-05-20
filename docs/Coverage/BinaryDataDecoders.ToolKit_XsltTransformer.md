# BinaryDataDecoders.ToolKit.Xml.Xsl.XsltTransformer

## Summary

| Key             | Value                                                |
| :-------------- | :--------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Xsl.XsltTransformer` |
| Assembly        | `BinaryDataDecoders.ToolKit`                         |
| Coveredlines    | `0`                                                  |
| Uncoveredlines  | `147`                                                |
| Coverablelines  | `147`                                                |
| Totallines      | `271`                                                |
| Linecoverage    | `0`                                                  |
| Coveredbranches | `0`                                                  |
| Totalbranches   | `20`                                                 |
| Branchcoverage  | `0`                                                  |
| Coveredmethods  | `0`                                                  |
| Totalmethods    | `7`                                                  |
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
〰30:          public XsltTransformer(string sandbox, params object[] extensions)
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
‼110:             if (!Directory.Exists(outputDir))
‼111:                 Directory.CreateDirectory(outputDir);
‼112:             using var resultStream = File.Create(output);
〰113: 
‼114:             var currentDirectory = Environment.CurrentDirectory;
〰115:             try
〰116:             {
‼117:                 var localOutfolder = Path.GetDirectoryName(output);
‼118:                 if (!Directory.Exists(localOutfolder))
〰119:                 {
‼120:                     Directory.CreateDirectory(localOutfolder);
〰121:                 }
‼122:                 Environment.CurrentDirectory = localOutfolder;
〰123: 
‼124:                 var inputNavigator = input.CreateNavigator();
‼125:                 inputNavigator.MoveToRoot();
〰126: 
〰127:                 //var x = xslt.GetType();
〰128:                 //var pf = x.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
〰129:                 //var pfc = pf.First(i => i.Name == "_command");
〰130:                 //var pfv = pfc.GetValue(xslt);
〰131: 
‼132:                 xslt.Transform(inputNavigator, xsltArgumentList, resultStream);
‼133:             }
〰134:             finally
〰135:             {
‼136:                 Environment.CurrentDirectory = currentDirectory;
‼137:             }
‼138:         }
〰139: 
〰140:         /// <summary>
〰141:         /// Multi-action transform.
〰142:         /// </summary>
〰143:         /// <param name="template">path for XSLT style-sheet</param>
〰144:         /// <param name="input">Wild card allowed for multiple files</param>
〰145:         /// <param name="output">Output and suffix per file.</param>
〰146:         public void TransformAll(string template, string input, string output, string? excludeInputSource = null) =>
‼147:             TransformAll(template, input, ReadAsXml, output, excludeInputSource);
〰148: 
〰149:         /// <summary>
〰150:         /// Multi-action transform.
〰151:         /// </summary>
〰152:         /// <param name="template">path for XSLT style-sheet</param>
〰153:         /// <param name="input">Wild card allowed for multiple files</param>
〰154:         /// <param name="inputNavigatorFactory">function to load input file into IXPathNavigable</param>
〰155:         /// <param name="output">Output and suffix per file.</param>
〰156:         public void TransformAll(string template, string input, Func<string, IXPathNavigable> inputNavigatorFactory, string output, string? excludeInputSource = null)
〰157:         {
‼158:             var inputFullPath = Path.GetFullPath(input);
‼159:             var inputDir = PathEx.GetBasePath(input);
‼160:             var excludeFiles = PathEx.EnumerateFiles(excludeInputSource);
‼161:             var inputFiles = PathEx.EnumerateFiles(input).Select(Path.GetFullPath).Except(excludeFiles.Select(Path.GetFullPath));
〰162: 
‼163:             var outputFullPath = Path.GetFullPath(output);
‼164:             var outputDir = Path.GetDirectoryName(outputFullPath);
‼165:             var outputPattern = Path.GetFileName(outputFullPath).Split('*').LastOrDefault() ?? "";
〰166: 
‼167:             Console.WriteLine($"\"{inputDir}\" => \"{outputDir}\"");
‼168:             if (!inputFiles.Any())
‼169:                 throw new FileNotFoundException($"File Not Found Exception: input");
〰170: 
‼171:             static Exception innerMost(Exception ex) => ex.InnerException == null ? ex : innerMost(ex.InnerException);
〰172: 
‼173:             var errors = new List<Exception>();
〰174: #if PARALLEL
‼175:             inputFiles.AsParallel().ForAll(inputFile =>
‼176: #else
‼177:             foreach (var inputFile in inputFiles)
‼178: #endif
‼179:             {
‼180:                 var inputFileClean = inputFile.Substring(inputDir.Length).TrimStart('/', '\\');
‼181:                 var removedExt = Path.ChangeExtension(inputFileClean, null);
‼182:                 var outFileName = removedExt + outputPattern;
‼183:                 var outputFile = Path.Combine(outputDir, outFileName);
‼184: 
‼185:                 var tid = Thread.CurrentThread.ManagedThreadId;
‼186: 
‼187:                 Console.WriteLine($"\t[{tid}]\"{inputFileClean}\" => \"{outFileName}\"");
‼188: 
‼189:                 try
‼190:                 {
‼191:                     var inputNavigator = inputNavigatorFactory(inputFile);
‼192:                     Transform(template, inputFile, inputNavigator, outputFile);
‼193:                 }
‼194:                 catch (Exception ex)
‼195:                 {
‼196:                     var rex = innerMost(ex);
‼197:                     errors.Add(rex);
‼198:                     Console.Error.WriteLine($"!!! ERROR[{tid}]: \"{inputFileClean}\" => \"{outFileName}\" :: {rex.Message}");
‼199:                     try
‼200:                     {
‼201:                         File.AppendAllLines(outputFile, new[]
‼202:                         {
‼203:                             "",
‼204:                             new string('=', 60),
‼205:                            $"!!! ERROR !!!: {ex.Message}",
‼206:                             new string('=', 60),
‼207:                             ex.ToString()
‼208:                         });
‼209:                     }
‼210:                     catch
‼211:                     {
‼212:                         // Eat and errors!
‼213:                     }
‼214:                 }
‼215:             }
‼216: #if PARALLEL
‼217:             );
〰218: #endif
‼219:             if (errors.Any())
‼220:                 throw new AggregateException(errors);
‼221:         }
〰222: 
〰223:         public void TransformMerge(string template, string input, Func<string, IXPathNavigable> inputNavigatorFactory, string output, string? excludeInputSource = null)
〰224:         {
‼225:             static Exception innerMost(Exception ex) => ex.InnerException == null ? ex : innerMost(ex.InnerException);
‼226:             var tid = Thread.CurrentThread.ManagedThreadId;
〰227:             try
〰228:             {
‼229:                 var inputFullPath = Path.GetFullPath(input);
‼230:                 var inputDir = PathEx.GetBasePath(input);
‼231:                 var excludeFiles = PathEx.EnumerateFiles(excludeInputSource);
‼232:                 var inputFiles = PathEx.EnumerateFiles(input).Except(excludeFiles);
〰233: 
‼234:                 if (!inputFiles.Any())
‼235:                     throw new FileNotFoundException($"input");
〰236: 
〰237:                 //TODO: should probably add the file to the input navigator
‼238:                 var navigators = inputFiles.Select(f => (f, (IXPathNavigable?)inputNavigatorFactory(f))).ToList();
〰239: 
〰240:                 //TODO: need to figure out why this won't navigate correctly.
‼241:                 var merged = navigators.MergeNavigators().CreateNavigator();
‼242:                 var doc = new XmlDocument();
‼243:                 doc.LoadXml(merged.OuterXml);
‼244:                 merged = doc.CreateNavigator();
‼245:                 merged.MoveToRoot();
‼246:                 Transform(template, input, merged, output);
‼247:             }
‼248:             catch (Exception ex)
〰249:             {
‼250:                 var rex = innerMost(ex);
‼251:                 Console.Error.WriteLine($"ERROR[{tid}]: \"{input}\" => \"{output}\" :: {rex.Message}");
〰252:                 try
〰253:                 {
‼254:                     File.AppendAllLines(output, new[]
‼255:                     {
‼256:                             "",
‼257:                             new string('=', 60),
‼258:                            $"!!! ERROR !!!: {ex.Message}",
‼259:                             new string('=', 60),
‼260:                             ex.ToString()
‼261:                         });
‼262:                 }
‼263:                 catch
〰264:                 {
〰265:                     // Eat and errors!
‼266:                 }
‼267:                 throw;
〰268:             }
‼269:         }
〰270:     }
〰271: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

