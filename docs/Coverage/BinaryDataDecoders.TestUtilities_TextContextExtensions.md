# BinaryDataDecoders.TestUtilities.TextContextExtensions

## Summary

| Key             | Value                                                    |
| :-------------- | :------------------------------------------------------- |
| Class           | `BinaryDataDecoders.TestUtilities.TextContextExtensions` |
| Assembly        | `BinaryDataDecoders.TestUtilities`                       |
| Coveredlines    | `22`                                                     |
| Uncoveredlines  | `68`                                                     |
| Coverablelines  | `90`                                                     |
| Totallines      | `343`                                                    |
| Linecoverage    | `24.4`                                                   |
| Coveredbranches | `18`                                                     |
| Totalbranches   | `76`                                                     |
| Branchcoverage  | `23.6`                                                   |
| Coveredmethods  | `2`                                                      |
| Totalmethods    | `4`                                                      |
| Methodcoverage  | `50`                                                     |

## Metrics

| Complexity | Lines | Branches | Name            |
| :--------- | :---- | :------- | :-------------- |
| 34         | 0     | 0        | `AddResult`     |
| 4          | 0     | 0        | `AddResultFile` |
| 34         | 42.10 | 44.11    | `AddResult`     |
| 4          | 85.71 | 75.00    | `AddResultFile` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.TestUtilities/TextContextExtensions.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰2:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰3:   using Newtonsoft.Json;
〰4:   using System;
〰5:   using System.IO;
〰6:   using System.Linq;
〰7:   using System.Text;
〰8:   using System.Xml;
〰9:   using System.Xml.Linq;
〰10:  using System.Xml.XPath;
〰11:  using JsonFormatting = Newtonsoft.Json.Formatting;
〰12:  
〰13:  namespace BinaryDataDecoders.TestUtilities;
〰14:  
〰15:  /// <summary>
〰16:  /// Extension methods for TestContext
〰17:  /// </summary>
〰18:  public static class TextContextExtensions
〰19:  {
〰20:      /// <summary>
〰21:      /// serialize and store results to test results folder
〰22:      /// </summary>
〰23:      /// <param name="context">test context</param>
〰24:      /// <param name="value">object to store</param>
〰25:      /// <returns>test context for chaining</returns>
〰26:      public static TestContext AddResult(this TestContext context, object value, string fileName = "")
〰27:      {
‼28:          if (value == null)
‼29:              return context;
〰30:          // if (value is IXPathNavigable nav && !(value is XPathNodeIterator)) return AddResult(context, nav.CreateNavigator(), fileName);
‼31:          if (value is INode node)
‼32:              return AddResult(context, new ExtensibleNavigator(node, fileName), fileName);
〰33:  
‼34:          if (string.IsNullOrWhiteSpace(fileName))
〰35:          {
‼36:              var ext = value switch
‼37:              {
‼38:                  byte[] _ => ".bin",
‼39:                  Stream _ => ".dat",
‼40:                  string _ => ".txt",
‼41:                  XContainer _ => ".xml",
‼42:                  IXPathNavigable _ => ".xml",
‼43:                  XPathNodeIterator _ => ".xml",
‼44:                  _ => ".data"
‼45:              };
‼46:              fileName = $"{value.GetType().Name}_{DateTime.Now.Ticks}{ext}".Replace('`', '_').Replace(':', '_').Replace('<', '_').Replace('>', '_');
〰47:          }
〰48:  
‼49:          if (value is byte[] data)
〰50:          {
‼51:              AddResultFile(context, fileName, data);
〰52:          }
‼53:          else if (value is Stream stream)
〰54:          {
‼55:              using var ms = new MemoryStream();
‼56:              if (stream.CanSeek)
‼57:                  stream.Position = 0;
‼58:              stream.CopyTo(ms);
‼59:              AddResultFile(context, fileName, ms.ToArray());
〰60:          }
‼61:          else if (value is string content)
〰62:          {
‼63:              AddResultFile(context, fileName, Encoding.UTF8.GetBytes(content));
〰64:          }
‼65:          else if (value is XContainer xcontainer)
〰66:          {
‼67:              AddResultFile(context, fileName, Encoding.UTF8.GetBytes(xcontainer.ToString()));
〰68:          }
‼69:          else if (value is IXPathNavigable xPathNavigator)
〰70:          {
‼71:              AddResultFile(context, fileName, Encoding.UTF8.GetBytes(xPathNavigator.CreateNavigator().OuterXml));
〰72:          }
‼73:          else if (value is XPathNodeIterator xPathNodeIterator)
〰74:          {
‼75:              var fragment = xPathNodeIterator.Cast<XPathNavigator>().Aggregate(new StringBuilder(), (sb, x) => sb.AppendLine(x.OuterXml));
‼76:              AddResultFile(context, fileName, Encoding.UTF8.GetBytes(fragment.ToString()));
〰77:          }
‼78:          else if (value != null)
〰79:          {
‼80:              var json = JsonConvert.SerializeObject(value, JsonFormatting.Indented);
‼81:              AddResultFile(context, fileName, Encoding.UTF8.GetBytes(json));
〰82:          }
〰83:          else
〰84:          {
‼85:              context.WriteLine("No result");
〰86:          }
‼87:          return context;
〰88:      }
〰89:      /// <summary>
〰90:      /// Write out binary content to test results folder and link to test results
〰91:      /// </summary>
〰92:      /// <param name="context">Related TestContext</param>
〰93:      /// <param name="fileName">file name for result</param>
〰94:      /// <param name="content">binary content for file</param>
〰95:      /// <returns>test context for chaining</returns>
〰96:      public static TestContext AddResultFile(this TestContext context, string fileName, byte[] content)
〰97:      {
‼98:          var outFile = Path.Combine(context.TestRunResultsDirectory, fileName);
‼99:          var dir = Path.GetDirectoryName(outFile);
‼100:         if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
‼101:             Directory.CreateDirectory(dir);
‼102:         File.WriteAllBytes(outFile, content);
‼103:         context.AddResultFile(outFile);
‼104:         return context;
〰105:     }
〰106: 
〰107:     //public static Stream GetTestDataAsync<T>(this TestContext context, string target )
〰108:     //{
〰109:     //    var typeQuery = from assembly in AppDomain.CurrentDomain.GetAssemblies()
〰110:     //                    from type in assembly.GetTypes()
〰111:     //                    where type.FullName == context.FullyQualifiedTestClassName
〰112:     //                    select type;
〰113:     //    var testType = typeQuery.First();
〰114:     //    var testClass = Activator.CreateInstance(typeQuery.First());
〰115:     //}
〰116: 
〰117:     //public static async Task<T> GetTestDataAsync<T>(this TestContext context, string target = null)
〰118:     //{
〰119:     //    var typeQuery = from assembly in AppDomain.CurrentDomain.GetAssemblies()
〰120:     //                    from type in assembly.GetTypes()
〰121:     //                    select type;
〰122:     //    var testType = typeQuery.FirstOrDefault(t => t.FullName == context.FullyQualifiedTestClassName);
〰123:     //    var testClass = Activator.CreateInstance(testType);
〰124:     //    var targetName = string.IsNullOrWhiteSpace(target) ? context.TestName : target;
〰125:     //    if (string.IsNullOrWhiteSpace(target))
〰126:     //        target = null;
〰127:     //    var possibleResources = target != null ? new[] {
〰128:     //      $"{testType.Name}_{context.TestName}_{target}" ,
〰129:     //      $"{testType.Name}_{context.TestName}_{target}.json",
〰130:     //      $"{testType.Name}_{target}" ,
〰131:     //      $"{testType.Name}_{target}.json",
〰132:     //      $"{context.TestName}_{target}",
〰133:     //      $"{context.TestName}_{target}.json",
〰134:     //      $"{target}",
〰135:     //      $"{target}.json",
〰136:     //    } : new[]
〰137:     //    {
〰138:     //      $"{testType.Name}_{context.TestName}",
〰139:     //      $"{testType.Name}_{context.TestName}.json",
〰140:     //      $"{context.TestName}",
〰141:     //      $"{context.TestName}.json",
〰142:     //    }.Where(i => i != null);
〰143:     //    async Task<string> getValueAsync()
〰144:     //    {
〰145:     //        foreach (var possible in possibleResources)
〰146:     //        {
〰147:     //            var result = await testClass.GetResourceAsStringAsync(possible);
〰148:     //            if (!string.IsNullOrWhiteSpace(result))
〰149:     //                return result;
〰150:     //        }
〰151:     //        return default;
〰152:     //    }
〰153:     //    var content = await getValueAsync();
〰154:     //    if (string.IsNullOrWhiteSpace(content))
〰155:     //        return default;
〰156:     //    if (typeof(T) == typeof(string))
〰157:     //        return (T)(object)content;
〰158:     //    else if (typeof(T) == typeof(JToken))
〰159:     //        return (T)(object)JToken.Parse(content);
〰160:     //    else if (typeof(T) == typeof(JObject))
〰161:     //        return (T)(object)JObject.Parse(content);
〰162:     //    else if (typeof(T) == typeof(JArray))
〰163:     //        return (T)(object)JArray.Parse(content);
〰164:     //    var services = new ServiceCollection()
〰165:     //            .AddToolkitServices()
〰166:     //            .BuildServiceProvider();
〰167:     //    var deserializer = services.GetService<IObjectDeserializer>();
〰168:     //    var result = await deserializer.DeserializeAsync<T>(content);
〰169:     //    return result;
〰170:     //}
〰171: }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.TestUtilities/TextContextExtensions.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰2:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰3:   using Newtonsoft.Json;
〰4:   using System;
〰5:   using System.IO;
〰6:   using System.Linq;
〰7:   using System.Text;
〰8:   using System.Xml;
〰9:   using System.Xml.Linq;
〰10:  using System.Xml.XPath;
〰11:  using JsonFormatting = Newtonsoft.Json.Formatting;
〰12:  
〰13:  namespace BinaryDataDecoders.TestUtilities;
〰14:  
〰15:  /// <summary>
〰16:  /// Extension methods for TestContext
〰17:  /// </summary>
〰18:  public static class TextContextExtensions
〰19:  {
〰20:      /// <summary>
〰21:      /// serialize and store results to test results folder
〰22:      /// </summary>
〰23:      /// <param name="context">test context</param>
〰24:      /// <param name="value">object to store</param>
〰25:      /// <returns>test context for chaining</returns>
〰26:      public static TestContext AddResult(this TestContext context, object value, string fileName = "")
〰27:      {
⚠28:          if (value == null)
‼29:              return context;
〰30:          // if (value is IXPathNavigable nav && !(value is XPathNodeIterator)) return AddResult(context, nav.CreateNavigator(), fileName);
✔31:          if (value is INode node)
✔32:              return AddResult(context, new ExtensibleNavigator(node, fileName), fileName);
〰33:  
✔34:          if (string.IsNullOrWhiteSpace(fileName))
〰35:          {
⚠36:              var ext = value switch
✔37:              {
‼38:                  byte[] _ => ".bin",
‼39:                  Stream _ => ".dat",
‼40:                  string _ => ".txt",
‼41:                  XContainer _ => ".xml",
✔42:                  IXPathNavigable _ => ".xml",
‼43:                  XPathNodeIterator _ => ".xml",
‼44:                  _ => ".data"
✔45:              };
✔46:              fileName = $"{value.GetType().Name}_{DateTime.Now.Ticks}{ext}".Replace('`', '_').Replace(':', '_').Replace('<', '_').Replace('>', '_');
〰47:          }
〰48:  
⚠49:          if (value is byte[] data)
〰50:          {
‼51:              AddResultFile(context, fileName, data);
〰52:          }
⚠53:          else if (value is Stream stream)
〰54:          {
‼55:              using var ms = new MemoryStream();
‼56:              if (stream.CanSeek)
‼57:                  stream.Position = 0;
‼58:              stream.CopyTo(ms);
‼59:              AddResultFile(context, fileName, ms.ToArray());
〰60:          }
⚠61:          else if (value is string content)
〰62:          {
‼63:              AddResultFile(context, fileName, Encoding.UTF8.GetBytes(content));
〰64:          }
⚠65:          else if (value is XContainer xcontainer)
〰66:          {
‼67:              AddResultFile(context, fileName, Encoding.UTF8.GetBytes(xcontainer.ToString()));
〰68:          }
⚠69:          else if (value is IXPathNavigable xPathNavigator)
〰70:          {
✔71:              AddResultFile(context, fileName, Encoding.UTF8.GetBytes(xPathNavigator.CreateNavigator().OuterXml));
〰72:          }
‼73:          else if (value is XPathNodeIterator xPathNodeIterator)
〰74:          {
‼75:              var fragment = xPathNodeIterator.Cast<XPathNavigator>().Aggregate(new StringBuilder(), (sb, x) => sb.AppendLine(x.OuterXml));
‼76:              AddResultFile(context, fileName, Encoding.UTF8.GetBytes(fragment.ToString()));
〰77:          }
‼78:          else if (value != null)
〰79:          {
‼80:              var json = JsonConvert.SerializeObject(value, JsonFormatting.Indented);
‼81:              AddResultFile(context, fileName, Encoding.UTF8.GetBytes(json));
〰82:          }
〰83:          else
〰84:          {
‼85:              context.WriteLine("No result");
〰86:          }
✔87:          return context;
〰88:      }
〰89:      /// <summary>
〰90:      /// Write out binary content to test results folder and link to test results
〰91:      /// </summary>
〰92:      /// <param name="context">Related TestContext</param>
〰93:      /// <param name="fileName">file name for result</param>
〰94:      /// <param name="content">binary content for file</param>
〰95:      /// <returns>test context for chaining</returns>
〰96:      public static TestContext AddResultFile(this TestContext context, string fileName, byte[] content)
〰97:      {
✔98:          var outFile = Path.Combine(context.TestRunResultsDirectory, fileName);
✔99:          var dir = Path.GetDirectoryName(outFile);
⚠100:         if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
‼101:             Directory.CreateDirectory(dir);
✔102:         File.WriteAllBytes(outFile, content);
✔103:         context.AddResultFile(outFile);
✔104:         return context;
〰105:     }
〰106: 
〰107:     //public static Stream GetTestDataAsync<T>(this TestContext context, string target )
〰108:     //{
〰109:     //    var typeQuery = from assembly in AppDomain.CurrentDomain.GetAssemblies()
〰110:     //                    from type in assembly.GetTypes()
〰111:     //                    where type.FullName == context.FullyQualifiedTestClassName
〰112:     //                    select type;
〰113:     //    var testType = typeQuery.First();
〰114:     //    var testClass = Activator.CreateInstance(typeQuery.First());
〰115:     //}
〰116: 
〰117:     //public static async Task<T> GetTestDataAsync<T>(this TestContext context, string target = null)
〰118:     //{
〰119:     //    var typeQuery = from assembly in AppDomain.CurrentDomain.GetAssemblies()
〰120:     //                    from type in assembly.GetTypes()
〰121:     //                    select type;
〰122:     //    var testType = typeQuery.FirstOrDefault(t => t.FullName == context.FullyQualifiedTestClassName);
〰123:     //    var testClass = Activator.CreateInstance(testType);
〰124:     //    var targetName = string.IsNullOrWhiteSpace(target) ? context.TestName : target;
〰125:     //    if (string.IsNullOrWhiteSpace(target))
〰126:     //        target = null;
〰127:     //    var possibleResources = target != null ? new[] {
〰128:     //      $"{testType.Name}_{context.TestName}_{target}" ,
〰129:     //      $"{testType.Name}_{context.TestName}_{target}.json",
〰130:     //      $"{testType.Name}_{target}" ,
〰131:     //      $"{testType.Name}_{target}.json",
〰132:     //      $"{context.TestName}_{target}",
〰133:     //      $"{context.TestName}_{target}.json",
〰134:     //      $"{target}",
〰135:     //      $"{target}.json",
〰136:     //    } : new[]
〰137:     //    {
〰138:     //      $"{testType.Name}_{context.TestName}",
〰139:     //      $"{testType.Name}_{context.TestName}.json",
〰140:     //      $"{context.TestName}",
〰141:     //      $"{context.TestName}.json",
〰142:     //    }.Where(i => i != null);
〰143:     //    async Task<string> getValueAsync()
〰144:     //    {
〰145:     //        foreach (var possible in possibleResources)
〰146:     //        {
〰147:     //            var result = await testClass.GetResourceAsStringAsync(possible);
〰148:     //            if (!string.IsNullOrWhiteSpace(result))
〰149:     //                return result;
〰150:     //        }
〰151:     //        return default;
〰152:     //    }
〰153:     //    var content = await getValueAsync();
〰154:     //    if (string.IsNullOrWhiteSpace(content))
〰155:     //        return default;
〰156:     //    if (typeof(T) == typeof(string))
〰157:     //        return (T)(object)content;
〰158:     //    else if (typeof(T) == typeof(JToken))
〰159:     //        return (T)(object)JToken.Parse(content);
〰160:     //    else if (typeof(T) == typeof(JObject))
〰161:     //        return (T)(object)JObject.Parse(content);
〰162:     //    else if (typeof(T) == typeof(JArray))
〰163:     //        return (T)(object)JArray.Parse(content);
〰164:     //    var services = new ServiceCollection()
〰165:     //            .AddToolkitServices()
〰166:     //            .BuildServiceProvider();
〰167:     //    var deserializer = services.GetService<IObjectDeserializer>();
〰168:     //    var result = await deserializer.DeserializeAsync<T>(content);
〰169:     //    return result;
〰170:     //}
〰171: }
〰172: 
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

