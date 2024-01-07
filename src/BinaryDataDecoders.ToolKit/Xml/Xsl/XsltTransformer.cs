#define PARALLEL

using BinaryDataDecoders.ToolKit.IO;
using BinaryDataDecoders.ToolKit.Xml.XPath;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;

//TODO: should make this async/await
namespace BinaryDataDecoders.ToolKit.Xml.Xsl;

/// <summary>
/// Implementation of XsltTransformer
/// </summary>
/// <remarks>
/// create instance of XsltTransformer
/// </remarks>
/// <param name="extensions">optional extensions for XSLT Transform</param>
public class XsltTransformer(string sandbox, params object[] extensions) : IXsltTransformer
{
    private readonly string _sandbox = sandbox;

    /// <summary>
    /// Read input file as XML
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public IXPathNavigable ReadAsXml(string fileName)
    {
        try
        {
            var xmlreader = XmlReader.Create(fileName, new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Ignore,
                ConformanceLevel = ConformanceLevel.Document,
                NameTable = new NameTable(),
            });
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlreader);
            return xmlDocument;
        }
        catch
        {
            return new XmlDocument();
        }
    }

    /// <summary>
    /// Single action transform
    /// </summary>
    /// <param name="template">path for XSLT style-sheet</param>
    /// <param name="input">source XML file</param>
    /// <param name="output">resulting text content</param>
    public void Transform(string template, string input, string output) => Transform(template, input, ReadAsXml(input), output);

    /// <summary>
    /// Single action transform
    /// </summary>
    /// <param name="template">path for XSLT style-sheet</param>
    /// <param name="inputSource"></param>
    /// <param name="input">source XML file</param>
    /// <param name="output">resulting text content</param>
    public void Transform(string template, string inputSource, IXPathNavigable input, string output)
    {
        template = PathEx.FixUpPath(template) ?? throw new ApplicationException($"{nameof(template)} must not be null");
        inputSource = PathEx.FixUpPath(inputSource) ?? throw new ApplicationException($"{nameof(inputSource)} must not be null");
        output = PathEx.FixUpPath(output) ?? throw new ApplicationException($"{nameof(output)} must not be null");
        string sandbox = PathEx.FixUpPath(_sandbox) ?? throw new ApplicationException($"{nameof(_sandbox)} must not be null");

        var xsltArgumentList = new XsltArgumentList().AddExtensions(extensions);

        xsltArgumentList.XsltMessageEncountered += (sender, eventArgs) => Console.WriteLine($"\t\t[{Environment.CurrentManagedThreadId}]{eventArgs.Message}");

        XNamespace ns = this.GetXmlNamespace();
        xsltArgumentList.AddParam("files", "", new XElement(ns + "file",
            new XAttribute(nameof(template), Path.GetFullPath(template) ?? ""),
            new XAttribute(nameof(input), Path.GetFullPath(inputSource) ?? ""),
            new XAttribute(nameof(input) + "Type", input.GetType().AssemblyQualifiedName ?? ""),
            new XAttribute(nameof(output), Path.GetFullPath(output) ?? ""),
            new XAttribute(nameof(output) + "Path", Path.GetDirectoryName(Path.GetFullPath(output)) ?? ""),
            new XAttribute("sandbox", Path.GetFullPath(sandbox) ?? "")
            ).ToXPathNavigable().CreateNavigator() ?? throw new ApplicationException("no files added"));

        var xslt = new XslCompiledTransform(false);
        using var xmlreader = XmlReader.Create(template, new XmlReaderSettings
        {
            DtdProcessing = DtdProcessing.Parse,
            ConformanceLevel = ConformanceLevel.Document,
            NameTable = new NameTable(),
        });
        var xsltSettings = new XsltSettings(false, false);

        xslt.Load(xmlreader, xsltSettings, null);

        var outputDir = Path.GetDirectoryName(output);
        if (outputDir != null && !Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);
        using var resultStream = File.Create(output);

        var currentDirectory = Environment.CurrentDirectory;
        try
        {
            var localOutfolder = Path.GetDirectoryName(output);
            if (localOutfolder != null && !Directory.Exists(localOutfolder))
            {
                Directory.CreateDirectory(localOutfolder);
            }
            if (localOutfolder != null)
                Environment.CurrentDirectory = localOutfolder;

            var inputNavigator = input.CreateNavigator() ?? throw new ApplicationException("navigator not created");
            inputNavigator.MoveToRoot();

            //var x = xslt.GetType();
            //var pf = x.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            //var pfc = pf.First(i => i.Name == "_command");
            //var pfv = pfc.GetValue(xslt);

            xslt.Transform(inputNavigator, xsltArgumentList, resultStream);
        }
        finally
        {
            Environment.CurrentDirectory = currentDirectory;
        }
    }

    /// <summary>
    /// Multi-action transform. 
    /// </summary>
    /// <param name="template">path for XSLT style-sheet</param>
    /// <param name="input">Wild card allowed for multiple files</param>
    /// <param name="output">Output and suffix per file.</param>
    public void TransformAll(string template, string input, string output, string? excludeInputSource = null) =>
        TransformAll(template, input, ReadAsXml, output, excludeInputSource);

    /// <summary>
    /// Multi-action transform. 
    /// </summary>
    /// <param name="template">path for XSLT style-sheet</param>
    /// <param name="input">Wild card allowed for multiple files</param>
    /// <param name="inputNavigatorFactory">function to load input file into IXPathNavigable</param>
    /// <param name="output">Output and suffix per file.</param>
    public void TransformAll(string template, string input, Func<string, IXPathNavigable> inputNavigatorFactory, string output, string? excludeInputSource = null)
    {
        var inputFullPath = Path.GetFullPath(input);
        var inputDir = PathEx.GetBasePath(input);
        var excludeFiles = PathEx.EnumerateFiles(excludeInputSource);
        var inputFiles = PathEx.EnumerateFiles(input).Select(Path.GetFullPath).Except(excludeFiles.Select(Path.GetFullPath));

        var outputFullPath = Path.GetFullPath(output);
        var outputDir = Path.GetDirectoryName(outputFullPath);
        var outputPattern = Path.GetFileName(outputFullPath).Split('*').LastOrDefault() ?? "";

        Console.WriteLine($"\"{inputDir}\" => \"{outputDir}\"");
        if (!inputFiles.Any())
            throw new FileNotFoundException($"File Not Found Exception: input");

        static Exception innerMost(Exception ex) => ex.InnerException == null ? ex : innerMost(ex.InnerException);

        var errors = new List<Exception>();
#if PARALLEL
        inputFiles.AsParallel().ForAll(inputFile =>
#else
        foreach (var inputFile in inputFiles)
#endif
        {
            var inputFileClean = inputFile[inputDir.Length..].TrimStart('/', '\\');
            var removedExt = Path.ChangeExtension(inputFileClean, null);
            var outFileName = removedExt + outputPattern;
            var outputFile = Path.Combine(outputDir, outFileName);

            var tid = Environment.CurrentManagedThreadId;

            Console.WriteLine($"\t[{tid}]\"{inputFileClean}\" => \"{outFileName}\"");

            try
            {
                var inputNavigator = inputNavigatorFactory(inputFile);
                Transform(template, inputFile, inputNavigator, outputFile);
            }
            catch (Exception ex)
            {
                var rex = innerMost(ex);
                errors.Add(rex);
                Console.Error.WriteLine($"!!! ERROR[{tid}]: \"{inputFileClean}\" => \"{outFileName}\" :: {rex.Message}");
                try
                {
                    File.AppendAllLines(outputFile, new[]
                    {
                        "",
                        new string('=', 60),
                       $"!!! ERROR !!!: {ex.Message}",
                        new string('=', 60),
                        ex.ToString()
                    });
                }
                catch
                {
                    // Eat and errors!
                }
            }
        }
#if PARALLEL
        );
#endif
        if (errors.Any())
            throw new AggregateException(errors);
    }

    public void TransformMerge(string template, string input, Func<string, IXPathNavigable?> inputNavigatorFactory, string output, string? excludeInputSource = null)
    {
        static Exception innerMost(Exception ex) => ex.InnerException == null ? ex : innerMost(ex.InnerException);
        var tid = Environment.CurrentManagedThreadId;
        try
        {
            var inputFullPath = Path.GetFullPath(input);
            var inputDir = PathEx.GetBasePath(input);
            var excludeFiles = PathEx.EnumerateFiles(excludeInputSource);
            var inputFiles = PathEx.EnumerateFiles(input).Except(excludeFiles);

            if (!inputFiles.Any())
                throw new FileNotFoundException($"input");

            //TODO: should probably add the file to the input navigator
            var navigators = inputFiles.Select(f => (f, inputNavigatorFactory(f))).ToList();

            //TODO: need to figure out why this won't navigate correctly.
            var merged = navigators.MergeNavigators().CreateNavigator();
            var doc = new XmlDocument();
            doc.LoadXml(merged.OuterXml);
            merged = doc.CreateNavigator();
            merged.MoveToRoot();
            Transform(template, input, merged, output);
        }
        catch (Exception ex)
        {
            var rex = innerMost(ex);
            Console.Error.WriteLine($"ERROR[{tid}]: \"{input}\" => \"{output}\" :: {rex.Message}");
            try
            {
                File.AppendAllLines(output, new[]
                {
                        "",
                        new string('=', 60),
                       $"!!! ERROR !!!: {ex.Message}",
                        new string('=', 60),
                        ex.ToString()
                    });
            }
            catch
            {
                // Eat and errors!
            }
            throw;
        }
    }
}
