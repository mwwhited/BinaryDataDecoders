
# BinaryDataDecoders.ToolKit.Xml.Xsl.XsltTransformer
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_XsltTransformer.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.Xml.Xsl.XsltTransformer           | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 130                                                          | 
| Coverablelines       | 130                                                          | 
| Totallines           | 239                                                          | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 10                                                           | 
| Branchcoverage       | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\Xsl\XsltTransformer.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 0     | 100      | ctor | 
| 1          | 0     | 100      | ReadAsXml | 
| 1          | 0     | 100      | Transform | 
| 4          | 0     | 0        | Transform | 
| 1          | 0     | 100      | TransformAll | 
| 4          | 0     | 0        | TransformAll | 
| 2          | 0     | 0        | TransformMerge | 
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
‼92:              xslt.Load(xmlreader, xsltSettings, null);
〰93:  
‼94:              var outputDir = Path.GetDirectoryName(output);
‼95:              if (!Directory.Exists(outputDir)) Directory.CreateDirectory(outputDir);
‼96:              using var resultStream = File.Create(output);
〰97:  
‼98:              var currentDirectory = Environment.CurrentDirectory;
〰99:              try
〰100:             {
‼101:                 var localOutfolder = Path.GetDirectoryName(output);
‼102:                 if (!Directory.Exists(localOutfolder))
〰103:                 {
‼104:                     Directory.CreateDirectory(localOutfolder);
〰105:                 }
‼106:                 Environment.CurrentDirectory = localOutfolder;
〰107: 
‼108:                 var inputNavigator = input.CreateNavigator();
‼109:                 inputNavigator.MoveToRoot();
‼110:                 xslt.Transform(inputNavigator, xsltArgumentList, resultStream);
‼111:             }
〰112:             finally
〰113:             {
‼114:                 Environment.CurrentDirectory = currentDirectory;
‼115:             }
‼116:         }
〰117: 
〰118:         /// <summary>
〰119:         /// Multi-action transform.
〰120:         /// </summary>
〰121:         /// <param name="template">path for XSLT style-sheet</param>
〰122:         /// <param name="input">Wild card allowed for multiple files</param>
〰123:         /// <param name="output">Output and suffix per file.</param>
〰124:         public void TransformAll(string template, string input, string output) =>
‼125:             TransformAll(template, input, ReadAsXml, output);
〰126: 
〰127:         /// <summary>
〰128:         /// Multi-action transform.
〰129:         /// </summary>
〰130:         /// <param name="template">path for XSLT style-sheet</param>
〰131:         /// <param name="input">Wild card allowed for multiple files</param>
〰132:         /// <param name="inputNavigatorFactory">function to load input file into IXPathNavigable</param>
〰133:         /// <param name="output">Output and suffix per file.</param>
〰134:         public void TransformAll(string template, string input, Func<string, IXPathNavigable> inputNavigatorFactory, string output)
〰135:         {
‼136:             var inputFullPath = Path.GetFullPath(input);
‼137:             var inputDir = PathEx.GetBasePath(input);
‼138:             var inputFiles = PathEx.EnumerateFiles(input);
〰139: 
‼140:             var outputFullPath = Path.GetFullPath(output);
‼141:             var outputDir = Path.GetDirectoryName(outputFullPath);
‼142:             var outputPattern = Path.GetFileName(outputFullPath).Split('*').LastOrDefault() ?? "";
〰143: 
‼144:             Console.WriteLine($"\"{inputDir}\" => \"{outputDir}\"");
‼145:             if (!inputFiles.Any()) throw new FileNotFoundException($"input");
〰146: 
〰147:             static Exception innerMost(Exception ex) => ex.InnerException == null ? ex : innerMost(ex.InnerException);
〰148: 
〰149: #if PARALLEL
‼150:             inputFiles.AsParallel().ForAll(inputFile =>
‼151: #else
‼152:             foreach (var inputFile in inputFiles)
‼153: #endif
‼154:             {
‼155:                 var inputFileClean = inputFile.Substring(inputDir.Length).TrimStart('/', '\\');
‼156:                 var removedExt = Path.ChangeExtension(inputFileClean, null);
‼157:                 var outFileName = removedExt + outputPattern;
‼158:                 var outputFile = Path.Combine(outputDir, outFileName);
‼159: 
‼160:                 var tid = Thread.CurrentThread.ManagedThreadId;
‼161: 
‼162:                 Console.WriteLine($"\t[{tid}]\"{inputFileClean}\" => \"{outFileName}\"");
‼163: 
‼164:                 try
‼165:                 {
‼166:                     var inputNavigator = inputNavigatorFactory(inputFile);
‼167:                     Transform(template, inputFile, inputNavigator, outputFile);
‼168:                 }
‼169:                 catch (Exception ex)
‼170:                 {
‼171:                     var rex = innerMost(ex);
‼172:                     Console.Error.WriteLine($"!!! ERROR[{tid}]: \"{inputFileClean}\" => \"{outFileName}\" :: {rex.Message}");
‼173:                     try
‼174:                     {
‼175:                         File.AppendAllLines(outputFile, new[]
‼176:                         {
‼177:                             "",
‼178:                             new string('=', 60),
‼179:                            $"!!! ERROR !!!: {ex.Message}",
‼180:                             new string('=', 60),
‼181:                             ex.ToString()
‼182:                         });
‼183:                     }
‼184:                     catch
‼185:                     {
‼186:                         // Eat and errors!
‼187:                     }
‼188:                 }
‼189:             }
‼190: #if PARALLEL
‼191:             );
〰192: #endif
‼193:         }
〰194: 
〰195:         public void TransformMerge(string template, string input, Func<string, IXPathNavigable> inputNavigatorFactory, string output)
〰196:         {
〰197:             static Exception innerMost(Exception ex) => ex.InnerException == null ? ex : innerMost(ex.InnerException);
‼198:             var tid = Thread.CurrentThread.ManagedThreadId;
〰199:             try
〰200:             {
‼201:                 var inputFullPath = Path.GetFullPath(input);
‼202:                 var inputDir = PathEx.GetBasePath(input);
‼203:                 var inputFiles = PathEx.EnumerateFiles(input);
〰204: 
‼205:                 if (!inputFiles.Any()) throw new FileNotFoundException($"input");
〰206: 
‼207:                 var navigators = inputFiles.Select(f => inputNavigatorFactory(f)).ToList();
〰208: 
〰209:                 //TODO: need to figoure out why this wont navigate correctly.
‼210:                 var merged = navigators.MergeNavigators().CreateNavigator();
‼211:                 var doc = new XmlDocument();
‼212:                 doc.LoadXml(merged.OuterXml);
‼213:                 merged = doc.CreateNavigator();
‼214:                 merged.MoveToRoot();
‼215:                 Transform(template, input, merged, output);
‼216:             }
‼217:             catch (Exception ex)
〰218:             {
‼219:                 var rex = innerMost(ex);
‼220:                 Console.Error.WriteLine($"ERROR[{tid}]: \"{input}\" => \"{output}\" :: {rex.Message}");
〰221:                 try
〰222:                 {
‼223:                     File.AppendAllLines(output, new[]
‼224:                     {
‼225:                             "",
‼226:                             new string('=', 60),
‼227:                            $"!!! ERROR !!!: {ex.Message}",
‼228:                             new string('=', 60),
‼229:                             ex.ToString()
‼230:                         });
‼231:                 }
‼232:                 catch
〰233:                 {
〰234:                     // Eat and errors!
‼235:                 }
‼236:             }
‼237:         }
〰238:     }
〰239: }

```
## Footer 
[Return to Summary](Summary.md)

