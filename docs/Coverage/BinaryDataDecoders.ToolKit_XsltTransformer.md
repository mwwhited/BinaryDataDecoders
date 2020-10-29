
# BinaryDataDecoders.ToolKit.Xml.Xsl.XsltTransformer
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_XsltTransformer.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.Xml.Xsl.XsltTransformer           | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 102                                                          | 
| Coverablelines       | 102                                                          | 
| Totallines           | 202                                                          | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 8                                                            | 
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
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\Xsl\XsltTransformer.cs

```CSharp
〰1:   #define PARALLEL
〰2:   
〰3:   using BinaryDataDecoders.ToolKit.IO;
〰4:   using System;
〰5:   using System.IO;
〰6:   using System.Linq;
〰7:   using System.Threading;
〰8:   using System.Xml;
〰9:   using System.Xml.Linq;
〰10:  using System.Xml.XPath;
〰11:  using System.Xml.Xsl;
〰12:  
〰13:  //TODO: should make this async/await
〰14:  namespace BinaryDataDecoders.ToolKit.Xml.Xsl
〰15:  {
〰16:      /// <summary>
〰17:      /// Implementation of XsltTransformer
〰18:      /// </summary>
〰19:      public class XsltTransformer : IXsltTransformer
〰20:      {
〰21:          private readonly string _sandbox;
〰22:          private readonly object[] _extensions;
〰23:  
〰24:          /// <summary>
〰25:          /// create instance of XsltTransformer
〰26:          /// </summary>
〰27:          /// <param name="extensions">optional extensions for XSLT Transform</param>
‼28:          public XsltTransformer(string sandbox, params object[] extensions)
〰29:          {
‼30:              _sandbox = sandbox;
‼31:              _extensions = extensions;
‼32:          }
〰33:  
〰34:          /// <summary>
〰35:          /// Read input file as XML
〰36:          /// </summary>
〰37:          /// <param name="fileName"></param>
〰38:          /// <returns></returns>
〰39:          public IXPathNavigable ReadAsXml(string fileName)
〰40:          {
‼41:              var xmlreader = XmlReader.Create(fileName, new XmlReaderSettings
‼42:              {
‼43:                  DtdProcessing = DtdProcessing.Ignore,
‼44:                  ConformanceLevel = ConformanceLevel.Document,
‼45:                  NameTable = new NameTable(),
‼46:              });
‼47:              var xmlDocument = new XmlDocument();
‼48:              xmlDocument.Load(xmlreader);
‼49:              return xmlDocument;
〰50:          }
〰51:  
〰52:          /// <summary>
〰53:          /// Single action transform
〰54:          /// </summary>
〰55:          /// <param name="template">path for XSLT style-sheet</param>
〰56:          /// <param name="input">source XML file</param>
〰57:          /// <param name="output">resulting text content</param>
‼58:          public void Transform(string template, string input, string output) => Transform(template, input, ReadAsXml(input), output);
〰59:  
〰60:          /// <summary>
〰61:          /// Single action transform
〰62:          /// </summary>
〰63:          /// <param name="template">path for XSLT style-sheet</param>
〰64:          /// <param name="inputSource"></param>
〰65:          /// <param name="input">source XML file</param>
〰66:          /// <param name="output">resulting text content</param>
〰67:          public void Transform(string template, string inputSource, IXPathNavigable input, string output)
〰68:          {
‼69:              var xsltArgumentList = new XsltArgumentList().AddExtensions(_extensions);
〰70:  
‼71:              xsltArgumentList.XsltMessageEncountered += (sender, eventArgs) => Console.WriteLine($"\t\t{eventArgs.Message}");
〰72:  
‼73:              XNamespace ns = this.GetXmlNamespace();
‼74:              xsltArgumentList.AddParam("files", "", new XElement(ns + "file",
‼75:                  new XAttribute(nameof(template), Path.GetFullPath(template)),
‼76:                  new XAttribute(nameof(input), Path.GetFullPath(inputSource)),
‼77:                  new XAttribute(nameof(input) +"Type", input.GetType().AssemblyQualifiedName),
‼78:                  new XAttribute(nameof(output), Path.GetFullPath(output)),
‼79:                  new XAttribute(nameof(output) + "Path", Path.GetDirectoryName(Path.GetFullPath(output))),
‼80:                  new XAttribute("sandbox", Path.GetFullPath(_sandbox))
‼81:                  ).ToXPathNavigable().CreateNavigator());
〰82:  
‼83:              var xslt = new XslCompiledTransform(false);
‼84:              using var xmlreader = XmlReader.Create(template, new XmlReaderSettings
‼85:              {
‼86:                  DtdProcessing = DtdProcessing.Parse,
‼87:                  ConformanceLevel = ConformanceLevel.Document,
‼88:                  NameTable = new NameTable(),
‼89:              });
‼90:              var xsltSettings = new XsltSettings(false, false);
‼91:              xslt.Load(xmlreader, xsltSettings, null);
〰92:  
‼93:              var outputDir = Path.GetDirectoryName(output);
‼94:              if (!Directory.Exists(outputDir)) Directory.CreateDirectory(outputDir);
‼95:              using var resultStream = File.Create(output);
〰96:  
‼97:              var currentDirectory = Environment.CurrentDirectory;
〰98:              try
〰99:              {
‼100:                 var localOutfolder = Path.GetDirectoryName(output);
‼101:                 if (!Directory.Exists(localOutfolder))
〰102:                 {
‼103:                     Directory.CreateDirectory(localOutfolder);
〰104:                 }
‼105:                 Environment.CurrentDirectory = localOutfolder;
〰106: 
‼107:                 var inputNavigator = input.CreateNavigator();
‼108:                 inputNavigator.MoveToRoot();
‼109:                 xslt.Transform(input, xsltArgumentList, resultStream);
‼110:             }
〰111:             finally
〰112:             {
‼113:                 Environment.CurrentDirectory = currentDirectory;
‼114:             }
‼115:         }
〰116: 
〰117:         /// <summary>
〰118:         /// Multi-action transform.
〰119:         /// </summary>
〰120:         /// <param name="template">path for XSLT style-sheet</param>
〰121:         /// <param name="input">Wild card allowed for multiple files</param>
〰122:         /// <param name="output">Output and suffix per file.</param>
〰123:         public void TransformAll(string template, string input, string output) =>
‼124:             TransformAll(template, input, ReadAsXml, output);
〰125: 
〰126:         /// <summary>
〰127:         /// Multi-action transform.
〰128:         /// </summary>
〰129:         /// <param name="template">path for XSLT style-sheet</param>
〰130:         /// <param name="input">Wild card allowed for multiple files</param>
〰131:         /// <param name="inputNavigatorFactory">function to load input file into IXPathNavigable</param>
〰132:         /// <param name="output">Output and suffix per file.</param>
〰133:         public void TransformAll(string template, string input, Func<string, IXPathNavigable> inputNavigatorFactory, string output)
〰134:         {
〰135:             //if (File.Exists(input))
〰136:             //{
〰137:             //    Console.WriteLine($"\"{Path.GetFileName(input)}\" => \"{Path.GetFileName(output)}\"");
〰138:             //    Transform(template, input, output);
〰139:             //    return;
〰140:             //}
〰141: 
‼142:             var inputFullPath = Path.GetFullPath(input);
‼143:             var inputDir = PathEx.GetBasePath(input);
‼144:             var inputFiles = PathEx.EnumerateFiles(input);
〰145: 
‼146:             var outputFullPath = Path.GetFullPath(output);
‼147:             var outputDir = Path.GetDirectoryName(outputFullPath);
‼148:             var outputPattern = Path.GetFileName(outputFullPath).Split('*').LastOrDefault() ?? "";
〰149: 
‼150:             Console.WriteLine($"\"{inputDir}\" => \"{outputDir}\"");
‼151:             if (!inputFiles.Any()) throw new FileNotFoundException($"input");
〰152: 
〰153:             static Exception innerMost(Exception ex) => ex.InnerException == null ? ex : innerMost(ex.InnerException);
〰154: 
〰155: #if PARALLEL
‼156:             inputFiles.AsParallel().ForAll(inputFile =>
‼157: #else
‼158:             foreach (var inputFile in inputFiles)
‼159: #endif
‼160:             {
‼161:                 var inputFileClean = inputFile.Substring(inputDir.Length).TrimStart('/', '\\');
‼162:                 var removedExt = Path.ChangeExtension(inputFileClean, null);
‼163:                 var outFileName = removedExt + outputPattern;
‼164:                 var outputFile = Path.Combine(outputDir, outFileName);
‼165: 
‼166: 
‼167:                 var tid = Thread.CurrentThread.ManagedThreadId;
‼168: 
‼169:                 Console.WriteLine($"\t[{tid}]\"{inputFileClean}\" => \"{outFileName}\"");
‼170: 
‼171:                 try
‼172:                 {
‼173:                     var inputNavigator = inputNavigatorFactory(inputFile);
‼174:                     Transform(template, inputFile, inputNavigator, outputFile);
‼175:                 }
‼176:                 catch (Exception ex)
‼177:                 {
‼178:                     var rex = innerMost(ex);
‼179:                     Console.Error.WriteLine($"!!bu  ! ERROR[{tid}]: \"{inputFileClean}\" => \"{outFileName}\" :: {rex.Message}");
‼180:                     try
‼181:                     {
‼182:                         File.AppendAllLines(outputFile, new[]
‼183:                         {
‼184:                             "",
‼185:                             new string('=', 60),
‼186:                            $"!!! ERROR !!!: {ex.Message}",
‼187:                             new string('=', 60),
‼188:                             ex.ToString()
‼189:                         });
‼190:                     }
‼191:                     catch
‼192:                     {
‼193:                         // Eat and errors!
‼194:                     }
‼195:                 }
‼196:             }
‼197: #if PARALLEL
‼198:             );
〰199: #endif
‼200:         }
〰201:     }
〰202: }

```
## Footer 
[Return to Summary](Summary.md)

