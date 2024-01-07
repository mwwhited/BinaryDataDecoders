using NuGet.Protocol;
using System;
using System.IO;

namespace BinaryDataDecoders.PackMan.Cli;

public class CommandLineOptions
{
    [CommandOption("s", "source", Required = false, HelpText = "input file (Directory.Packages.props)")]
    public string SourceFile { get; set; } = Path.Combine(Environment.CurrentDirectory, "Directory.Packages.props");

    [CommandOption("o", "output", Required = false, HelpText = "output file (Directory.Packages.props)")]
    public string? OutputFile { get; set; } = null;

    [CommandOption("n", "no-save", Required = false, HelpText = "Do not save changes")]
    public bool NoSave { get; set; } = false;

    [CommandOption("no-nuget", Required = false, HelpText = "Do not update nuget")]
    public bool NoNuget { get; set; } = false;

    [CommandOption("t", "target-versions", Required = false, HelpText = "Set Target Property Version (XXX,1.2.3;YYY;2.3.4)")]
    public string? TargetVersions { get; set; } = null;

    [CommandOption("nuget-url", Required = false, HelpText = "Nuget API URL (https://api.nuget.org/v3/index.json)")]
    public string NugetUrl { get; set; } = "https://api.nuget.org/v3/index.json";
    [CommandOption("nuget-feed-type", Required = false, HelpText = "Nuget API URL (https://api.nuget.org/v3/index.json)")]
    public FeedType FeedType { get; set; } = FeedType.HttpV3;

    [CommandOption("get-properties", Required = false, HelpText = "Read properties in Directory.Packages.props (and children)")]
    public bool GetProperties { get; set; } = false;

    [CommandOption("follow-imports", Required = false, HelpText = "Replace Import values with Children")]
    public bool FollowImports { get; set; } = false;

    [CommandOption("g", "get-property", Required = false, HelpText = "Read selected property")]
    public string? GetProperty { get; set; } = null;

    [CommandOption("v", "get-version", Required = false, HelpText = "Read Version")]
    public bool GetVersion { get; set; } = false;

    [CommandOption("update-projects", Required = false, HelpText = "Update project references")]
    public bool UpdateProjects { get; set; } = false;
    [CommandOption("projects", Required = false, HelpText = "Projects List")]
    public string? Projects { get; set; }
    [CommandOption("projects-path", Required = false, HelpText = "Projects Source Path")]
    public string? ProjectsPath { get; set; }
}
