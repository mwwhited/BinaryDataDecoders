﻿using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BinaryDataDecoders.ToolKit
{
    public static class TypeEx
    {
        public static Stream GetResourceStream(this Type classType, string filename) =>
             classType.Assembly.GetManifestResourceStream($"{classType.Namespace}.{filename}");

        public static Task<string> GetResourceAsStringAsync(this Type context, string filename) =>
            context.GetResourceStream(filename).ReadAsStringAsync();

        public static string GetXmlNamespace(this Type type)
        {
            var ns = type.GetCustomAttribute<XmlRootAttribute>()?.Namespace;
            if (string.IsNullOrWhiteSpace(ns)) return $"clr:{string.Join(',', type.AssemblyQualifiedName.Split(',').Where(s => !s.Contains('=')))}";
            return ns;
        }

        public static string GetXmlNamespaceForOutput(this Type type) =>
            type?.GetXmlNamespace() + ToolkitConstants.XmlNamespaces.OutputSuffix;
    }
}
