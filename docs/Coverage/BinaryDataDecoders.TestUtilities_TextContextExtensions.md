# BinaryDataDecoders.TestUtilities.TextContextExtensions

## Summary

| Key             | Value                                                    |
| :-------------- | :------------------------------------------------------- |
| Class           | `BinaryDataDecoders.TestUtilities.TextContextExtensions` |
| Assembly        | `BinaryDataDecoders.TestUtilities`                       |
| Coveredlines    | `21`                                                     |
| Uncoveredlines  | `22`                                                     |
| Coverablelines  | `43`                                                     |
| Totallines      | `170`                                                    |
| Linecoverage    | `48.8`                                                   |
| Coveredbranches | `16`                                                     |
| Totalbranches   | `36`                                                     |
| Branchcoverage  | `44.4`                                                   |
| Coveredmethods  | `2`                                                      |
| Totalmethods    | `2`                                                      |
| Methodcoverage  | `100`                                                    |

## Metrics

| Complexity | Lines | Branches | Name            |
| :--------- | :---- | :------- | :-------------- |
| 34         | 41.66 | 44.11    | `AddResult`     |
| 2          | 85.71 | 50.0     | `AddResultFile` |

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
〰13:  namespace BinaryDataDecoders.TestUtilities
〰14:  {
〰15:      /// <summary>
〰16:      /// Extension methods for TestContext
〰17:      /// </summary>
〰18:      public static class TextContextExtensions
〰19:      {
〰20:          /// <summary>
〰21:          /// serialize and store results to test results folder
〰22:          /// </summary>
〰23:          /// <param name="context">test context</param>
〰24:          /// <param name="value">object to store</param>
〰25:          /// <returns>test context for chaining</returns>
〰26:          public static TestContext AddResult(this TestContext context, object value, string fileName = "")
〰27:          {
⚠28:              if (value == null) return context;
〰29:              // if (value is IXPathNavigable nav && !(value is XPathNodeIterator)) return AddResult(context, nav.CreateNavigator(), fileName);
✔30:              if (value is INode node) return AddResult(context, new ExtensibleNavigator(node, fileName), fileName);
〰31:  
✔32:              if (string.IsNullOrWhiteSpace(fileName))
〰33:              {
⚠34:                  var ext = value switch
✔35:                  {
‼36:                      byte[] _ => ".bin",
‼37:                      Stream _ => ".dat",
‼38:                      string _ => ".txt",
‼39:                      XContainer _ => ".xml",
✔40:                      IXPathNavigable _ => ".xml",
‼41:                      XPathNodeIterator _ => ".xml",
‼42:                      _ => ".data"
✔43:                  };
✔44:                  fileName = $"{value.GetType().Name}_{DateTime.Now.Ticks}{ext}".Replace('`', '_').Replace(':', '_').Replace('<', '_').Replace('>', '_');
〰45:              }
〰46:  
⚠47:              if (value is byte[] data)
〰48:              {
‼49:                  AddResultFile(context, fileName, data);
〰50:              }
⚠51:              else if (value is Stream stream)
〰52:              {
‼53:                  using var ms = new MemoryStream();
‼54:                  if (stream.CanSeek)
‼55:                      stream.Position = 0;
‼56:                  stream.CopyTo(ms);
‼57:                  AddResultFile(context, fileName, ms.ToArray());
〰58:              }
⚠59:              else if (value is string content)
〰60:              {
‼61:                  AddResultFile(context, fileName, Encoding.UTF8.GetBytes(content));
〰62:              }
⚠63:              else if (value is XContainer xcontainer)
〰64:              {
‼65:                  AddResultFile(context, fileName, Encoding.UTF8.GetBytes(xcontainer.ToString()));
〰66:              }
⚠67:              else if (value is IXPathNavigable xPathNavigator)
〰68:              {
✔69:                  AddResultFile(context, fileName, Encoding.UTF8.GetBytes(xPathNavigator.CreateNavigator().OuterXml));
〰70:              }
‼71:              else if (value is XPathNodeIterator xPathNodeIterator)
〰72:              {
‼73:                  var fragment = xPathNodeIterator.Cast<XPathNavigator>().Aggregate(new StringBuilder(), (sb, x) => sb.AppendLine(x.OuterXml));
‼74:                  AddResultFile(context, fileName, Encoding.UTF8.GetBytes(fragment.ToString()));
〰75:              }
‼76:              else if (value != null)
〰77:              {
‼78:                  var json = JsonConvert.SerializeObject(value, JsonFormatting.Indented);
‼79:                  AddResultFile(context, fileName, Encoding.UTF8.GetBytes(json));
〰80:              }
〰81:              else
〰82:              {
‼83:                  context.WriteLine("No result");
〰84:              }
✔85:              return context;
〰86:          }
〰87:          /// <summary>
〰88:          /// Write out binary content to test results folder and link to test results
〰89:          /// </summary>
〰90:          /// <param name="context">Related TestContext</param>
〰91:          /// <param name="fileName">file name for result</param>
〰92:          /// <param name="content">binary content for file</param>
〰93:          /// <returns>test context for chaining</returns>
〰94:          public static TestContext AddResultFile(this TestContext context, string fileName, byte[] content)
〰95:          {
✔96:              var outFile = Path.Combine(context.TestRunResultsDirectory, fileName);
✔97:              var dir = Path.GetDirectoryName(outFile);
⚠98:              if (!Directory.Exists(dir))
‼99:                  Directory.CreateDirectory(dir);
✔100:             File.WriteAllBytes(outFile, content);
✔101:             context.AddResultFile(outFile);
✔102:             return context;
〰103:         }
〰104: 
〰105:         //public static Stream GetTestDataAsync<T>(this TestContext context, string target )
〰106:         //{
〰107:         //    var typeQuery = from assembly in AppDomain.CurrentDomain.GetAssemblies()
〰108:         //                    from type in assembly.GetTypes()
〰109:         //                    where type.FullName == context.FullyQualifiedTestClassName
〰110:         //                    select type;
〰111:         //    var testType = typeQuery.First();
〰112:         //    var testClass = Activator.CreateInstance(typeQuery.First());
〰113:         //}
〰114: 
〰115:         //public static async Task<T> GetTestDataAsync<T>(this TestContext context, string target = null)
〰116:         //{
〰117:         //    var typeQuery = from assembly in AppDomain.CurrentDomain.GetAssemblies()
〰118:         //                    from type in assembly.GetTypes()
〰119:         //                    select type;
〰120:         //    var testType = typeQuery.FirstOrDefault(t => t.FullName == context.FullyQualifiedTestClassName);
〰121:         //    var testClass = Activator.CreateInstance(testType);
〰122:         //    var targetName = string.IsNullOrWhiteSpace(target) ? context.TestName : target;
〰123:         //    if (string.IsNullOrWhiteSpace(target))
〰124:         //        target = null;
〰125:         //    var possibleResources = target != null ? new[] {
〰126:         //      $"{testType.Name}_{context.TestName}_{target}" ,
〰127:         //      $"{testType.Name}_{context.TestName}_{target}.json",
〰128:         //      $"{testType.Name}_{target}" ,
〰129:         //      $"{testType.Name}_{target}.json",
〰130:         //      $"{context.TestName}_{target}",
〰131:         //      $"{context.TestName}_{target}.json",
〰132:         //      $"{target}",
〰133:         //      $"{target}.json",
〰134:         //    } : new[]
〰135:         //    {
〰136:         //      $"{testType.Name}_{context.TestName}",
〰137:         //      $"{testType.Name}_{context.TestName}.json",
〰138:         //      $"{context.TestName}",
〰139:         //      $"{context.TestName}.json",
〰140:         //    }.Where(i => i != null);
〰141:         //    async Task<string> getValueAsync()
〰142:         //    {
〰143:         //        foreach (var possible in possibleResources)
〰144:         //        {
〰145:         //            var result = await testClass.GetResourceAsStringAsync(possible);
〰146:         //            if (!string.IsNullOrWhiteSpace(result))
〰147:         //                return result;
〰148:         //        }
〰149:         //        return default;
〰150:         //    }
〰151:         //    var content = await getValueAsync();
〰152:         //    if (string.IsNullOrWhiteSpace(content))
〰153:         //        return default;
〰154:         //    if (typeof(T) == typeof(string))
〰155:         //        return (T)(object)content;
〰156:         //    else if (typeof(T) == typeof(JToken))
〰157:         //        return (T)(object)JToken.Parse(content);
〰158:         //    else if (typeof(T) == typeof(JObject))
〰159:         //        return (T)(object)JObject.Parse(content);
〰160:         //    else if (typeof(T) == typeof(JArray))
〰161:         //        return (T)(object)JArray.Parse(content);
〰162:         //    var services = new ServiceCollection()
〰163:         //            .AddToolkitServices()
〰164:         //            .BuildServiceProvider();
〰165:         //    var deserializer = services.GetService<IObjectDeserializer>();
〰166:         //    var result = await deserializer.DeserializeAsync<T>(content);
〰167:         //    return result;
〰168:         //}
〰169:     }
〰170: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

