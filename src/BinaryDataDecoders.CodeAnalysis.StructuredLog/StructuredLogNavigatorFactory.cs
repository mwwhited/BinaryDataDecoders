using BinaryDataDecoders.ToolKit.Xml.XPath;
using Microsoft.Build.Logging.StructuredLogger;
using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.CodeAnalysis.StructuredLog;

public static class StructuredLogNavigatorFactory
{
    public static IXPathNavigable ToNavigable(this Build tree) =>
        new ExtensibleNavigator(tree.AsNode());

    public static INode AsNode(this Build build) =>
        new ExtensibleElementNode(
            "Build",
            build,

            valueSelector: n => n switch
            {
                string value => value,
                _ => null
            },

            attributeSelector: n => n switch
            {
                Build log => new (XName, object?)[] {
                    (XName.Get(nameof(log.Duration), ""), log.Duration),
                    (XName.Get(nameof(log.EndTime), ""), log.EndTime),
                    (XName.Get(nameof(log.Id), ""), log.Id),
                    (XName.Get(nameof(log.LogFilePath), ""), log.LogFilePath),
                    (XName.Get(nameof(log.Name), ""), log.Name),
                    (XName.Get(nameof(log.NodeId), ""), log.NodeId),
                    (XName.Get(nameof(log.StartTime), ""), log.StartTime),
                    (XName.Get(nameof(log.Succeeded), ""), log.Succeeded),
                    }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),

                Property log => new (XName, object?)[] {
                    (XName.Get(nameof(log.Name), ""), log.Name),
                    (XName.Get(nameof(log.ShortenedValue), ""), log.ShortenedValue),
                    (XName.Get(nameof(log.Value), ""), log.Value),
                    }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),

                Folder log => new (XName, object?)[] {
                    (XName.Get(nameof(log.Name), ""), log.Name),
                    }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),

                Item log => new (XName, object?)[] {
                    (XName.Get(nameof(log.Name), ""), log.Name),
                    (XName.Get(nameof(log.ShortenedName), ""), log.ShortenedName),
                    (XName.Get(nameof(log.Text), ""), log.Text),
                    }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),

                ProjectEvaluation log => new (XName, object?)[] {
                    (XName.Get(nameof(log.Duration), ""), log.Duration),
                    (XName.Get(nameof(log.EndTime), ""), log.EndTime),
                    (XName.Get(nameof(log.Id), ""), log.Id),
                    (XName.Get(nameof(log.Name), ""), log.Name),
                    (XName.Get(nameof(log.NodeId), ""), log.NodeId),
                    (XName.Get(nameof(log.StartTime), ""), log.StartTime),
                    }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),

                Target log => new (XName, object?)[] {
                    (XName.Get(nameof(log.Duration), ""), log.Duration),
                    (XName.Get(nameof(log.EndTime), ""), log.EndTime),
                    (XName.Get(nameof(log.Id), ""), log.Id),
                    (XName.Get(nameof(log.Name), ""), log.Name),
                    (XName.Get(nameof(log.NodeId), ""), log.NodeId),
                    (XName.Get(nameof(log.StartTime), ""), log.StartTime),
                    (XName.Get(nameof(log.DependsOnTargets), ""), log.DependsOnTargets),
                    (XName.Get(nameof(log.SourceFilePath), ""), log.SourceFilePath),
                    (XName.Get(nameof(log.Succeeded), ""), log.Succeeded),
                    (XName.Get(nameof(log.TargetBuiltReason), ""), log.TargetBuiltReason),
                    }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),

                Task log => new (XName, object?)[] {
                    (XName.Get(nameof(log.Duration), ""), log.Duration),
                    (XName.Get(nameof(log.EndTime), ""), log.EndTime),
                    (XName.Get(nameof(log.Id), ""), log.Id),
                    (XName.Get(nameof(log.Name), ""), log.Name),
                    (XName.Get(nameof(log.NodeId), ""), log.NodeId),
                    (XName.Get(nameof(log.StartTime), ""), log.StartTime),
                    (XName.Get(nameof(log.SourceFilePath), ""), log.SourceFilePath),
                    (XName.Get(nameof(log.FromAssembly), ""), log.FromAssembly),
                    (XName.Get(nameof(log.Title), ""), log.Title),
                    }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),

                Project log => new (XName, object?)[] {
                    (XName.Get(nameof(log.Duration), ""), log.Duration),
                    (XName.Get(nameof(log.EndTime), ""), log.EndTime),
                    (XName.Get(nameof(log.Id), ""), log.Id),
                    (XName.Get(nameof(log.Name), ""), log.Name),
                    (XName.Get(nameof(log.NodeId), ""), log.NodeId),
                    (XName.Get(nameof(log.StartTime), ""), log.StartTime),
                    (XName.Get(nameof(log.SourceFilePath), ""), log.SourceFilePath),
                    }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),

                EntryTarget log => new (XName, object?)[] {
                    (XName.Get(nameof(log.Name), ""), log.Name),
                    (XName.Get(nameof(log.Target), ""), log.Target),
                    }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),

                TimedNode log => new (XName, object?)[] {
                    (XName.Get(nameof(log.Duration), ""), log.Duration),
                    (XName.Get(nameof(log.EndTime), ""), log.EndTime),
                    (XName.Get(nameof(log.Id), ""), log.Id),
                    (XName.Get(nameof(log.Name), ""), log.Name),
                    (XName.Get(nameof(log.NodeId), ""), log.NodeId),
                    (XName.Get(nameof(log.StartTime), ""), log.StartTime),
                    }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),

                Message log => new (XName, object?)[] {
                    (XName.Get(nameof(log.LineNumber), ""), log.LineNumber),
                    (XName.Get(nameof(log.TypeName), ""), log.TypeName),
                    (XName.Get(nameof(log.ShortenedText), ""), log.ShortenedText),
                    (XName.Get(nameof(log.SourceFilePath), ""), log.SourceFilePath),
                    (XName.Get(nameof(log.Text), ""), log.Text),
                    (XName.Get(nameof(log.Timestamp), ""), log.Timestamp),
                    }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),

                Parameter log => new (XName, object?)[] {
                    (XName.Get(nameof(log.Name), ""), log.Name),
                    }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),

                AddItem log => new (XName, object?)[] {
                    (XName.Get(nameof(log.Name), ""), log.Name),
                    }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),

                RemoveItem log => new (XName, object?)[] {
                    (XName.Get(nameof(log.Name), ""), log.Name),
                    }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),

                Warning log => new (XName, object?)[] {
                    (XName.Get(nameof(log.TypeName), ""), log.TypeName),
                    (XName.Get(nameof(log.Code), ""), log.Code),
                    (XName.Get(nameof(log.ColumnNumber), ""), log.ColumnNumber),
                    (XName.Get(nameof(log.EndColumnNumber), ""), log.EndColumnNumber),
                    (XName.Get(nameof(log.EndLineNumber), ""), log.EndLineNumber),
                    (XName.Get(nameof(log.File), ""), log.File),
                    (XName.Get(nameof(log.LineNumber), ""), log.LineNumber),
                    (XName.Get(nameof(log.ProjectFile), ""), log.ProjectFile),
                    (XName.Get(nameof(log.ShortenedText), ""), log.ShortenedText),
                    (XName.Get(nameof(log.Subcategory), ""), log.Subcategory),
                    (XName.Get(nameof(log.Text), ""), log.Text),
                    (XName.Get(nameof(log.Timestamp), ""), log.Timestamp),
                    }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),

                Error log => new (XName, object?)[] {
                    (XName.Get(nameof(log.TypeName), ""), log.TypeName),
                    (XName.Get(nameof(log.Code), ""), log.Code),
                    (XName.Get(nameof(log.ColumnNumber), ""), log.ColumnNumber),
                    (XName.Get(nameof(log.EndColumnNumber), ""), log.EndColumnNumber),
                    (XName.Get(nameof(log.EndLineNumber), ""), log.EndLineNumber),
                    (XName.Get(nameof(log.File), ""), log.File),
                    (XName.Get(nameof(log.LineNumber), ""), log.LineNumber),
                    (XName.Get(nameof(log.ProjectFile), ""), log.ProjectFile),
                    (XName.Get(nameof(log.ShortenedText), ""), log.ShortenedText),
                    (XName.Get(nameof(log.Subcategory), ""), log.Subcategory),
                    (XName.Get(nameof(log.Text), ""), log.Text),
                    (XName.Get(nameof(log.Timestamp), ""), log.Timestamp),
                    }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),

                Metadata log => new (XName, object?)[] {
                    (XName.Get(nameof(log.Name), ""), log.Name),
                    (XName.Get(nameof(log.ShortenedValue), ""), log.ShortenedValue),
                    (XName.Get(nameof(log.Value), ""), log.Value),
                    }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),

                BaseNode log => new (XName, object?)[] {
                    (XName.Get("type", ""), log.GetType()),
                    }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),

                _ => null,
            },

            childSelector: n => n switch
            {
                Item log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),
                ProjectEvaluation log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),

                Project log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i))
                       .Concat(log.EntryTargets.Select(i => (XName.Get("EntryTarget", ""), (object)i))),

                Target log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),
                Task log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),
                Build log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),
                Folder log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),
                TimedNode log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),
                Message log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),
                EntryTarget log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),
                Parameter log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),
                AddItem log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),
                RemoveItem log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),
                Warning log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),
                Error log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),

                Metadata log => null,
                Property log => null,
                BaseNode log => null,
                string log => null,

                _ => throw new NotSupportedException($"{n.GetType()}"),
            }

          );
}