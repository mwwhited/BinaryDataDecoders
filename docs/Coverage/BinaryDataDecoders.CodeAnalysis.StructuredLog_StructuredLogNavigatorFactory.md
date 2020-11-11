# BinaryDataDecoders.CodeAnalysis.StructuredLog.StructuredLogNavigatorFactory

## Summary

| Key             | Value                                                                         |
| :-------------- | :---------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.CodeAnalysis.StructuredLog.StructuredLogNavigatorFactory` |
| Assembly        | `BinaryDataDecoders.CodeAnalysis.StructuredLog`                               |
| Coveredlines    | `0`                                                                           |
| Uncoveredlines  | `192`                                                                         |
| Coverablelines  | `192`                                                                         |
| Totallines      | `208`                                                                         |
| Linecoverage    | `0`                                                                           |
| Coveredbranches | `0`                                                                           |
| Totalbranches   | `112`                                                                         |
| Branchcoverage  | `0`                                                                           |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `ToNavigable` |
| 112        | 0     | 0        | `AsNode`      |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.CodeAnalysis.StructuredLog\StructuredLogNavigatorFactory.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰2:   using Microsoft.Build.Logging.StructuredLogger;
〰3:   using System;
〰4:   using System.Linq;
〰5:   using System.Xml.Linq;
〰6:   using System.Xml.XPath;
〰7:   
〰8:   namespace BinaryDataDecoders.CodeAnalysis.StructuredLog
〰9:   {
〰10:      public static class StructuredLogNavigatorFactory
〰11:      {
〰12:          public static IXPathNavigable ToNavigable(this Build tree) =>
‼13:              new ExtensibleNavigator(tree.AsNode());
〰14:  
〰15:          public static INode AsNode(this Build build) =>
‼16:              new ExtensibleElementNode(
‼17:                  "Build",
‼18:                  build,
‼19:  
‼20:                  valueSelector: n => n switch
‼21:                  {
‼22:                      string value => value,
‼23:                      _ => null
‼24:                  },
‼25:  
‼26:                  attributeSelector: n => n switch
‼27:                  {
‼28:                      Build log => new (XName, object?)[] {
‼29:                          (XName.Get(nameof(log.Duration), ""), log.Duration),
‼30:                          (XName.Get(nameof(log.EndTime), ""), log.EndTime),
‼31:                          (XName.Get(nameof(log.Id), ""), log.Id),
‼32:                          (XName.Get(nameof(log.LogFilePath), ""), log.LogFilePath),
‼33:                          (XName.Get(nameof(log.Name), ""), log.Name),
‼34:                          (XName.Get(nameof(log.NodeId), ""), log.NodeId),
‼35:                          (XName.Get(nameof(log.StartTime), ""), log.StartTime),
‼36:                          (XName.Get(nameof(log.Succeeded), ""), log.Succeeded),
‼37:                          }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),
‼38:  
‼39:                      Property log => new (XName, object?)[] {
‼40:                          (XName.Get(nameof(log.Name), ""), log.Name),
‼41:                          (XName.Get(nameof(log.ShortenedValue), ""), log.ShortenedValue),
‼42:                          (XName.Get(nameof(log.Value), ""), log.Value),
‼43:                          }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),
‼44:  
‼45:                      Folder log => new (XName, object?)[] {
‼46:                          (XName.Get(nameof(log.Name), ""), log.Name),
‼47:                          }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),
‼48:  
‼49:                      Item log => new (XName, object?)[] {
‼50:                          (XName.Get(nameof(log.Name), ""), log.Name),
‼51:                          (XName.Get(nameof(log.ShortenedText), ""), log.ShortenedText),
‼52:                          (XName.Get(nameof(log.Text), ""), log.Text),
‼53:                          }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),
‼54:  
‼55:                      ProjectEvaluation log => new (XName, object?)[] {
‼56:                          (XName.Get(nameof(log.Duration), ""), log.Duration),
‼57:                          (XName.Get(nameof(log.EndTime), ""), log.EndTime),
‼58:                          (XName.Get(nameof(log.Id), ""), log.Id),
‼59:                          (XName.Get(nameof(log.Name), ""), log.Name),
‼60:                          (XName.Get(nameof(log.NodeId), ""), log.NodeId),
‼61:                          (XName.Get(nameof(log.StartTime), ""), log.StartTime),
‼62:                          }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),
‼63:  
‼64:                      Target log => new (XName, object?)[] {
‼65:                          (XName.Get(nameof(log.Duration), ""), log.Duration),
‼66:                          (XName.Get(nameof(log.EndTime), ""), log.EndTime),
‼67:                          (XName.Get(nameof(log.Id), ""), log.Id),
‼68:                          (XName.Get(nameof(log.Name), ""), log.Name),
‼69:                          (XName.Get(nameof(log.NodeId), ""), log.NodeId),
‼70:                          (XName.Get(nameof(log.StartTime), ""), log.StartTime),
‼71:                          (XName.Get(nameof(log.DependsOnTargets), ""), log.DependsOnTargets),
‼72:                          (XName.Get(nameof(log.SourceFilePath), ""), log.SourceFilePath),
‼73:                          (XName.Get(nameof(log.Succeeded), ""), log.Succeeded),
‼74:                          (XName.Get(nameof(log.TargetBuiltReason), ""), log.TargetBuiltReason),
‼75:                          }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),
‼76:  
‼77:                      Task log => new (XName, object?)[] {
‼78:                          (XName.Get(nameof(log.Duration), ""), log.Duration),
‼79:                          (XName.Get(nameof(log.EndTime), ""), log.EndTime),
‼80:                          (XName.Get(nameof(log.Id), ""), log.Id),
‼81:                          (XName.Get(nameof(log.Name), ""), log.Name),
‼82:                          (XName.Get(nameof(log.NodeId), ""), log.NodeId),
‼83:                          (XName.Get(nameof(log.StartTime), ""), log.StartTime),
‼84:                          (XName.Get(nameof(log.SourceFilePath), ""), log.SourceFilePath),
‼85:                          (XName.Get(nameof(log.FromAssembly), ""), log.FromAssembly),
‼86:                          (XName.Get(nameof(log.Title), ""), log.Title),
‼87:                          }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),
‼88:  
‼89:                      Project log => new (XName, object?)[] {
‼90:                          (XName.Get(nameof(log.Duration), ""), log.Duration),
‼91:                          (XName.Get(nameof(log.EndTime), ""), log.EndTime),
‼92:                          (XName.Get(nameof(log.Id), ""), log.Id),
‼93:                          (XName.Get(nameof(log.Name), ""), log.Name),
‼94:                          (XName.Get(nameof(log.NodeId), ""), log.NodeId),
‼95:                          (XName.Get(nameof(log.StartTime), ""), log.StartTime),
‼96:                          (XName.Get(nameof(log.SourceFilePath), ""), log.SourceFilePath),
‼97:                          }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),
‼98:  
‼99:                      EntryTarget log => new (XName, object?)[] {
‼100:                         (XName.Get(nameof(log.Name), ""), log.Name),
‼101:                         (XName.Get(nameof(log.Target), ""), log.Target),
‼102:                         }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),
‼103: 
‼104:                     TimedNode log => new (XName, object?)[] {
‼105:                         (XName.Get(nameof(log.Duration), ""), log.Duration),
‼106:                         (XName.Get(nameof(log.EndTime), ""), log.EndTime),
‼107:                         (XName.Get(nameof(log.Id), ""), log.Id),
‼108:                         (XName.Get(nameof(log.Name), ""), log.Name),
‼109:                         (XName.Get(nameof(log.NodeId), ""), log.NodeId),
‼110:                         (XName.Get(nameof(log.StartTime), ""), log.StartTime),
‼111:                         }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),
‼112: 
‼113:                     Message log => new (XName, object?)[] {
‼114:                         (XName.Get(nameof(log.LineNumber), ""), log.LineNumber),
‼115:                         (XName.Get(nameof(log.Name), ""), log.Name),
‼116:                         (XName.Get(nameof(log.ShortenedText), ""), log.ShortenedText),
‼117:                         (XName.Get(nameof(log.SourceFilePath), ""), log.SourceFilePath),
‼118:                         (XName.Get(nameof(log.Text), ""), log.Text),
‼119:                         (XName.Get(nameof(log.Timestamp), ""), log.Timestamp),
‼120:                         }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),
‼121: 
‼122:                     Parameter log => new (XName, object?)[] {
‼123:                         (XName.Get(nameof(log.Name), ""), log.Name),
‼124:                         }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),
‼125: 
‼126:                     AddItem log => new (XName, object?)[] {
‼127:                         (XName.Get(nameof(log.Name), ""), log.Name),
‼128:                         }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),
‼129: 
‼130:                     RemoveItem log => new (XName, object?)[] {
‼131:                         (XName.Get(nameof(log.Name), ""), log.Name),
‼132:                         }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),
‼133: 
‼134:                     Warning log => new (XName, object?)[] {
‼135:                         (XName.Get(nameof(log.Name), ""), log.Name),
‼136:                         (XName.Get(nameof(log.Code), ""), log.Code),
‼137:                         (XName.Get(nameof(log.ColumnNumber), ""), log.ColumnNumber),
‼138:                         (XName.Get(nameof(log.EndColumnNumber), ""), log.EndColumnNumber),
‼139:                         (XName.Get(nameof(log.EndLineNumber), ""), log.EndLineNumber),
‼140:                         (XName.Get(nameof(log.File), ""), log.File),
‼141:                         (XName.Get(nameof(log.LineNumber), ""), log.LineNumber),
‼142:                         (XName.Get(nameof(log.ProjectFile), ""), log.ProjectFile),
‼143:                         (XName.Get(nameof(log.ShortenedText), ""), log.ShortenedText),
‼144:                         (XName.Get(nameof(log.Subcategory), ""), log.Subcategory),
‼145:                         (XName.Get(nameof(log.Text), ""), log.Text),
‼146:                         (XName.Get(nameof(log.Timestamp), ""), log.Timestamp),
‼147:                         }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),
‼148: 
‼149:                     Error log => new (XName, object?)[] {
‼150:                         (XName.Get(nameof(log.Name), ""), log.Name),
‼151:                         (XName.Get(nameof(log.Code), ""), log.Code),
‼152:                         (XName.Get(nameof(log.ColumnNumber), ""), log.ColumnNumber),
‼153:                         (XName.Get(nameof(log.EndColumnNumber), ""), log.EndColumnNumber),
‼154:                         (XName.Get(nameof(log.EndLineNumber), ""), log.EndLineNumber),
‼155:                         (XName.Get(nameof(log.File), ""), log.File),
‼156:                         (XName.Get(nameof(log.LineNumber), ""), log.LineNumber),
‼157:                         (XName.Get(nameof(log.ProjectFile), ""), log.ProjectFile),
‼158:                         (XName.Get(nameof(log.ShortenedText), ""), log.ShortenedText),
‼159:                         (XName.Get(nameof(log.Subcategory), ""), log.Subcategory),
‼160:                         (XName.Get(nameof(log.Text), ""), log.Text),
‼161:                         (XName.Get(nameof(log.Timestamp), ""), log.Timestamp),
‼162:                         }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),
‼163: 
‼164:                     Metadata log => new (XName, object?)[] {
‼165:                         (XName.Get(nameof(log.Name), ""), log.Name),
‼166:                         (XName.Get(nameof(log.ShortenedValue), ""), log.ShortenedValue),
‼167:                         (XName.Get(nameof(log.Value), ""), log.Value),
‼168:                         }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),
‼169: 
‼170:                     BaseNode log => new (XName, object?)[] {
‼171:                         (XName.Get("type", ""), log.GetType()),
‼172:                         }.AsEnumerable().Select(i => (i.Item1, i.Item2?.ToString())),
‼173: 
‼174:                     _ => null,
‼175:                 },
‼176: 
‼177:                 childSelector: n => n switch
‼178:                 {
‼179:                     Item log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),
‼180:                     ProjectEvaluation log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),
‼181: 
‼182:                     Project log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i))
‼183:                            .Concat(log.EntryTargets.Select(i => (XName.Get("EntryTarget", ""), (object)i))),
‼184: 
‼185:                     Target log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),
‼186:                     Task log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),
‼187:                     Build log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),
‼188:                     Folder log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),
‼189:                     TimedNode log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),
‼190:                     Message log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),
‼191:                     EntryTarget log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),
‼192:                     Parameter log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),
‼193:                     AddItem log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),
‼194:                     RemoveItem log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),
‼195:                     Warning log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),
‼196:                     Error log => log.Children.Select(i => (XName.Get(i.TypeName, ""), (object)i)),
‼197: 
‼198:                     Metadata log => null,
‼199:                     Property log => null,
‼200:                     BaseNode log => null,
‼201:                     string log => null,
‼202: 
‼203:                     _ => throw new NotSupportedException($"{n.GetType()}"),
‼204:                 }
‼205: 
‼206:               );
〰207:     }
〰208: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

