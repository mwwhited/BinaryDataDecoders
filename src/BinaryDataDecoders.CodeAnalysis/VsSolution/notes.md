


using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ReferenceScanner
{
    class Program
    {
        static void Main(string[] args)
        {
            var basePath = @"c:\tfs\Contract Management\Projects\CMS";

            var ignoredSet = Resolvers.GetIdByProjectTypeNames("Solution Folder", "Project Folders").ToArray();
            var solutions = (from solution in Directory.EnumerateFiles(basePath + @"\build", "*.sln", SearchOption.AllDirectories)
                             let solutionDir = Path.GetDirectoryName(solution)
                             select new
                             {
                                 Name = Path.GetFileNameWithoutExtension(solution),
                                 Path = solution,

                                 Projects = (from line in File.ReadLines(solution)
                                             where line.StartsWith("Project(")
                                             let projectTypeId = new Guid(line.Substring(9, 38))
                                             join projectType in Resolvers.ProjectTypes on projectTypeId equals projectType.Key
                                             where !ignoredSet.Contains(projectTypeId)
                                             let parts = line.Split('=')[1].Split(',').Select(p => p.Trim().Trim('\"')).ToArray()
                                             let projectName = parts[0]
                                             let projectPath = Path.GetFullPath(Path.Combine(solutionDir, parts[1]))
                                             let projectExists = File.Exists(projectPath)
                                             let projectId = new Guid(parts[2])

                                             let projectDetailsXml = projectExists ? XElement.Load(projectPath) : null
                                             let projectDetails = projectExists ? new
                                             {
                                                 ProjectGuid = (Guid?)projectDetailsXml.Descendants(Resolvers.ProjectNS + "ProjectGuid").First(),
                                                 OutputType = (string)projectDetailsXml.Descendants(Resolvers.ProjectNS + "OutputType").First(),
                                                 RootNamespace = (string)projectDetailsXml.Descendants(Resolvers.ProjectNS + "RootNamespace").First(),
                                                 AssemblyName = (string)projectDetailsXml.Descendants(Resolvers.ProjectNS + "AssemblyName").First(),
                                                 TargetFrameworkVersion = (string)projectDetailsXml.Descendants(Resolvers.ProjectNS + "TargetFrameworkVersion").First(),
                                                 OutputPath = (string)projectDetailsXml.Descendants(Resolvers.ProjectNS + "OutputPath").First(),
                                                 OutputPathFull = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(projectPath), (string)projectDetailsXml.Descendants(Resolvers.ProjectNS + "OutputPath").First())),

                                                 References = (from refXml in projectDetailsXml.Descendants(Resolvers.ProjectNS + "Reference")
                                                               select new
                                                               {
                                                                   Name = (string)refXml.Attribute("Include"),
                                                                   Private = (bool?)refXml.Element(Resolvers.ProjectNS + "Private"),
                                                                   SpecificVersion = (bool?)refXml.Element(Resolvers.ProjectNS + "SpecificVersion"),
                                                                   HintPath = (string)refXml.Element(Resolvers.ProjectNS + "HintPath"),
                                                               }),
                                                 ProjectReferences = (from projRef in projectDetailsXml.Descendants(Resolvers.ProjectNS + "ProjectReference")
                                                                      select new
                                                                      {
                                                                          Path = (string)projRef.Attribute("Include"),
                                                                          ProjectID = (Guid?)projRef.Element(Resolvers.ProjectNS + "Project"),
                                                                          Name = (string)projRef.Element(Resolvers.ProjectNS + "Name"),
                                                                      }),

                                                 HasPackageConfig = projectDetailsXml.Descendants(Resolvers.ProjectNS + "None")
                                                                                     .Where(x => x.Attribute("Include")?.Value == "packages.config")
                                                                                     .Any(),
                                             } : null
                                             let packagesConfigPath = (projectDetails?.HasPackageConfig ?? false) ? Path.Combine(Path.GetDirectoryName(projectPath), "packages.config") : null
                                             let nugetPackages = packagesConfigPath != null ? (from package in XElement.Load(packagesConfigPath).Elements("package")
                                                                                               select new
                                                                                               {
                                                                                                   Id = (string)package.Attribute("id"),
                                                                                                   Version = (string)package.Attribute("version"),
                                                                                                   TargetFramework = (string)package.Attribute("targetFramework"),
                                                                                               }) : null
                                             select new
                                             {
                                                 ProjectTypeID = projectTypeId,
                                                 ProjectType = projectType.Value,
                                                 Name = projectName,
                                                 Path = projectPath,
                                                 Exists = projectExists,
                                                 ProjectID = projectId,

                                                 ProjectDetails = projectDetails,
                                                 NugetPackages = nugetPackages,

                                             }),

                             });
            var xml = solutions.ToXml()
                               .SaveAs("WriteLog.xml",
                                       $"WriteLog_{DateTime.Now:yyyyMMddHHmmss}.xml");

            var reports = from report in Resolvers.GetReportStyleSheets()
                           let reportResult = xml.TransformTo(report.Stylesheet).ReadAsXml()
                           select new
                           {
                               FileName = Path.ChangeExtension(report.Name, ".xml"),
                               Result = reportResult,
                           };

            foreach (var report in reports)
                report.Result.SaveAs(report.FileName);

            //solutions.SelectMany(s => s.Projects.SelectMany(p => p.ProjectDetails.References))
            //         .Distinct()
            //         .OrderBy(i => i.Name)
            //         .ThenBy(i => i.HintPath)
            //         .ThenBy(i => i.Private)
            //         .ThenBy(i => i.SpecificVersion)
            //         .ToXml()
            //         .Save("DistinctReferences.Xml");
       
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Diagnostics.Contracts;

namespace ReferenceScanner
{
    public class Resolvers
    {
        public class StyleSheet
        {
            public StyleSheet(string name, XDocument stylesheet)
            {
                this.Name = name;
                this.Stylesheet = stylesheet;
            }
            public string Name { get; }
            public XDocument Stylesheet { get; }
        }
        public static IEnumerable<StyleSheet> GetReportStyleSheets()
        {
            Contract.Ensures(Contract.Result<IEnumerable<StyleSheet>>() != null);
            return from resourceName in ResoucesEx.XsltResources()
                   let stream = ResoucesEx.GetResourceStream(resourceName)
                   where stream != null
                   let styleSheet = stream.ReadAsXml()
                   select new StyleSheet(resourceName, styleSheet);
        }

        public static XNamespace ProjectNS { get; } = "http://schemas.microsoft.com/developer/msbuild/2003";

        public static IEnumerable<Guid> GetIdByProjectTypeNames(params string[] projectTypeNames)
        {
            Contract.Requires(projectTypeNames != null);

            return from projectTypeName in projectTypeNames
                   from kvp in Resolvers.ProjectTypes
                   where projectTypeName.Equals(kvp.Value, StringComparison.InvariantCultureIgnoreCase)
                   select kvp.Key;
        }

        //https://www.codeproject.com/reference/720512/list-of-visual-studio-project-type-guids 
        public static IDictionary<Guid, string> ProjectTypes { get; } = new Dictionary<Guid, string>
        {
            { new Guid("{8BB2217D-0F2D-49D1-97BC-3654ED321F3B}"), "ASP.NET 5" },
            { new Guid("{603C0E0B-DB56-11DC-BE95-000D561079B0}"), "ASP.NET MVC 1" },
            { new Guid("{F85E285D-A4E0-4152-9332-AB1D724D3325}"), "ASP.NET MVC 2" },
            { new Guid("{E53F8FEA-EAE0-44A6-8774-FFD645390401}"), "ASP.NET MVC 3" },
            { new Guid("{E3E379DF-F4C6-4180-9B81-6769533ABE47}"), "ASP.NET MVC 4" },
            { new Guid("{349C5851-65DF-11DA-9384-00065B846F21}"), "ASP.NET MVC 5" },
            { new Guid("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"), "C#" },
            { new Guid("{8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942}"), "C++" },
            { new Guid("{A9ACE9BB-CECE-4E62-9AA4-C7E7C5BD2124}"), "Database" },
            { new Guid("{4F174C21-8C12-11D0-8340-0000F80270F8}"), "Database (other project types)" },
            { new Guid("{3EA9E505-35AC-4774-B492-AD1749C4943A}"), "Deployment Cab" },
            { new Guid("{06A35CCD-C46D-44D5-987B-CF40FF872267}"), "Deployment Merge Module" },
            { new Guid("{978C614F-708E-4E1A-B201-565925725DBA}"), "Deployment Setup" },
            { new Guid("{AB322303-2255-48EF-A496-5904EB18DA55}"), "Deployment Smart Device Cab" },
            { new Guid("{F135691A-BF7E-435D-8960-F99683D2D49C}"), "Distributed System" },
            { new Guid("{BF6F8E12-879D-49E7-ADF0-5503146B24B8}"), "Dynamics 2012 AX C# in AOT" },
            { new Guid("{F2A71F9B-5D33-465A-A702-920D77279786}"), "F#" },
            { new Guid("{E6FDF86B-F3D1-11D4-8576-0002A516ECE8}"), "J#" },
            { new Guid("{20D4826A-C6FA-45DB-90F4-C717570B9F32}"), "Legacy (2003) Smart Device (C#)" },
            { new Guid("{CB4CE8C6-1BDB-4DC7-A4D3-65A1999772F8}"), "Legacy (2003) Smart Device (VB.NET)" },
            { new Guid("{b69e3092-b931-443c-abe7-7e7b65f2a37f}"), "Micro Framework" },
            { new Guid("{EFBA0AD7-5A72-4C68-AF49-83D382785DCF}"), "Mono for Android" },
            { new Guid("{6BC8ED88-2882-458C-8E55-DFD12B67127B}"), "MonoTouch" },
            { new Guid("{F5B4F3BC-B597-4E2B-B552-EF5D8A32436F}"), "MonoTouch Binding" },
            { new Guid("{786C830F-07A1-408B-BD7F-6EE04809D6DB}"), "Portable Class Library" },
            { new Guid("{66A26720-8FB5-11D2-AA7E-00C04F688DDE}"), "Project Folders" },
            { new Guid("{593B0543-81F6-4436-BA1E-4747859CAAE2}"), "SharePoint (C#)" },
            { new Guid("{EC05E597-79D4-47f3-ADA0-324C4F7C7484}"), "SharePoint (VB.NET)" },
            { new Guid("{F8810EC1-6754-47FC-A15F-DFABD2E3FA90}"), "SharePoint Workflow" },
            { new Guid("{A1591282-1198-4647-A2B1-27E5FF5F6F3B}"), "Silverlight" },
            { new Guid("{4D628B5B-2FBC-4AA6-8C16-197242AEB884}"), "Smart Device (C#)" },
            { new Guid("{68B1623D-7FB9-47D8-8664-7ECEA3297D4F}"), "Smart Device (VB.NET)" },
            { new Guid("{2150E333-8FDC-42A3-9474-1A3956D46DE8}"), "Solution Folder" },
            { new Guid("{3AC096D0-A1C2-E12C-1390-A8335801FDAB}"), "Test" },
            { new Guid("{A5A43C5B-DE2A-4C0C-9213-0A381AF9435A}"), "Universal Windows Class Library" },
            { new Guid("{F184B08F-C81C-45F6-A57F-5ABD9991F28F}"), "VB.NET" },
            { new Guid("{C252FEB5-A946-4202-B1D4-9916A0590387}"), "Visual Database Tools" },
            { new Guid("{54435603-DBB4-11D2-8724-00A0C9A8B90C}"), "Visual Studio 2015 Installer Project Extension" },
            { new Guid("{A860303F-1F3F-4691-B57E-529FC101A107}"), "Visual Studio Tools for Applications (VSTA)" },
            { new Guid("{BAA0C2D2-18E2-41B9-852F-F413020CAA33}"), "Visual Studio Tools for Office (VSTO)" },
            { new Guid("{E24C65DC-7377-472B-9ABA-BC803B73C61A}"), "Web Site" },
            { new Guid("{3D9AD99F-2412-4246-B90B-4EAA41C64699}"), "Windows Communication Foundation (WCF)" },
            { new Guid("{76F1466A-8B6D-4E39-A767-685A06062A39}"), "Windows Phone 8/8.1 Blank/Hub/Webview App" },
            { new Guid("{C089C8C0-30E0-4E22-80C0-CE093F111A43}"), "Windows Phone 8/8.1 App (C#)" },
            { new Guid("{DB03555F-0C8B-43BE-9FF9-57896B3C5E56}"), "Windows Phone 8/8.1 App (VB.NET)" },
            { new Guid("{60DC8134-EBA5-43B8-BCC9-BB4BC16C2548}"), "Windows Presentation Foundation (WPF)" },
            { new Guid("{BC8A1FFA-BEE3-4634-8014-F334798102B3}"), "Windows Store (Metro) Apps & Components" },
            { new Guid("{14822709-B5A1-4724-98CA-57A101D1B079}"), "Workflow (C#)" },
            { new Guid("{D59BE175-2ED0-4C54-BE3D-CDAA9F3214C8}"), "Workflow (VB.NET)" },
            { new Guid("{32F31D43-81CC-4C15-9DE6-3FC5453562B6}"), "Workflow Foundation" },
            { new Guid("{6D335F3A-9D43-41b4-9D22-F6F17C4BE596}"), "XNA (Windows)" },
            { new Guid("{2DF5C3F4-5A5F-47a9-8E94-23B4456F55E2}"), "XNA (XBox)" },
            { new Guid("{D399B71A-8929-442a-A9AC-8BEC78BB2433}"), "XNA (Zune)" },
        };
    }
}
