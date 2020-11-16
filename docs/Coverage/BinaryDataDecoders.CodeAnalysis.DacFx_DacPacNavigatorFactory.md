# BinaryDataDecoders.CodeAnalysis.DacFx.DacPacNavigatorFactory

## Summary

| Key             | Value                                                          |
| :-------------- | :------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.CodeAnalysis.DacFx.DacPacNavigatorFactory` |
| Assembly        | `BinaryDataDecoders.CodeAnalysis.DacFx`                        |
| Coveredlines    | `0`                                                            |
| Uncoveredlines  | `233`                                                          |
| Coverablelines  | `233`                                                          |
| Totallines      | `399`                                                          |
| Linecoverage    | `0`                                                            |
| Coveredbranches | `0`                                                            |
| Totalbranches   | `236`                                                          |
| Branchcoverage  | `0`                                                            |

## Metrics

| Complexity | Lines | Branches | Name               |
| :--------- | :---- | :------- | :----------------- |
| 1          | 0     | 100      | `ToNavigable`      |
| 4          | 0     | 0        | `AsNode`           |
| 10         | 0     | 0        | `SelectValue`      |
| 40         | 0     | 0        | `SelectAttributes` |
| 182        | 0     | 0        | `SelectChildren`   |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.CodeAnalysis.DacFx\DacPacNavigatorFactory.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰2:   using Microsoft.SqlServer.Dac.Model;
〰3:   using Microsoft.SqlServer.TransactSql.ScriptDom;
〰4:   using System;
〰5:   using System.Collections;
〰6:   using System.Collections.Generic;
〰7:   using System.Linq;
〰8:   using System.Xml.Linq;
〰9:   using System.Xml.XPath;
〰10:  
〰11:  namespace BinaryDataDecoders.CodeAnalysis.DacFx
〰12:  {
〰13:      public static class DacPacNavigatorFactory
〰14:      {
〰15:          private const string NAMESPACE = "";
〰16:  
〰17:          public static IXPathNavigable ToNavigable(this TSqlModel tree) =>
‼18:              new ExtensibleNavigator(tree.AsNode());
〰19:  
〰20:          public static INode AsNode(this TSqlModel build) =>
‼21:              new ExtensibleElementNode(
‼22:                  "DACPAC",
‼23:                  build,
‼24:  
‼25:                valueSelector: n => SelectValue(n)?.ToString(),
‼26:                attributeSelector: n => SelectAttributes(n).Select(i => (i.name, i.value?.ToString())),
‼27:                childSelector: SelectChildren
‼28:                );
〰29:  
〰30:          private static object? SelectValue(object arg)
〰31:          {
‼32:              return arg switch
‼33:              {
‼34:                  //  TSqlObject model => model.TryGetScript(out var obj) ? obj : null,
‼35:                  BooleanExpressionSnippet exp => exp.Script,
‼36:                  TSqlStatementSnippet snippet => snippet.Script,
‼37:                  ScalarExpressionSnippet snippet => snippet.Script,
‼38:  
‼39:                  string value => value,
‼40:                  bool value => value,
‼41:  
‼42:                  _ => null
‼43:              };
〰44:          }
〰45:  
〰46:          private static IEnumerable<(XName name, object? value)>? SelectAttributes(object input)
〰47:          {
‼48:              if (input is TSqlModel model)
〰49:              {
‼50:                  yield return (XName.Get(nameof(model.EngineVersion), NAMESPACE), model.EngineVersion);
‼51:                  yield return (XName.Get(nameof(model.Version), NAMESPACE), model.Version);
〰52:              }
‼53:              else if (input is TSqlObject obj)
〰54:              {
‼55:                  yield return (XName.Get(nameof(obj.Name), NAMESPACE), string.Join(".", obj.Name.Parts));
〰56:              }
‼57:              else if (input is TSqlScript script)
〰58:              {
‼59:                  yield return (XName.Get(nameof(script.StartLine), NAMESPACE), script.StartLine);
〰60:              }
‼61:              else if (input is TSqlBatch batch)
〰62:              {
‼63:                  yield return (XName.Get(nameof(batch.StartLine), NAMESPACE), batch.StartLine);
〰64:              }
‼65:              else if (input is TSqlStatement statement)
〰66:              {
‼67:                  yield return (XName.Get(nameof(statement.StartLine), NAMESPACE), statement.StartLine);
〰68:  
‼69:                  if (statement is TSqlStatementSnippet snippet)
〰70:                  {
〰71:                      //Note: do nothing
〰72:                  }
‼73:                  else if (statement is CreateIndexStatement index)
〰74:                  {
‼75:                      yield return (XName.Get(nameof(index.Clustered), NAMESPACE), index.Clustered);
‼76:                      yield return (XName.Get(nameof(index.Translated80SyntaxTo90), NAMESPACE), index.Translated80SyntaxTo90);
‼77:                      yield return (XName.Get(nameof(index.Unique), NAMESPACE), index.Unique);
〰78:                  }
〰79:                  else
〰80:                  {
〰81:                  }
〰82:              }
‼83:              else if (input is Identifier identifier)
〰84:              {
‼85:                  yield return (XName.Get(nameof(identifier.QuoteType), NAMESPACE), identifier.QuoteType);
‼86:                  yield return (XName.Get(nameof(identifier.Value), NAMESPACE), identifier.Value);
〰87:              }
‼88:              else if (input is SecurityPrincipal securityPrincipal)
〰89:              {
‼90:                  yield return (XName.Get(nameof(securityPrincipal.PrincipalType), NAMESPACE), securityPrincipal.PrincipalType);
〰91:              }
‼92:              else if (input is CreateTableStatement createTableStatement)
〰93:              {
‼94:                  yield return (XName.Get(nameof(createTableStatement.AsEdge), NAMESPACE), createTableStatement.AsEdge);
‼95:                  yield return (XName.Get(nameof(createTableStatement.AsFileTable), NAMESPACE), createTableStatement.AsFileTable);
‼96:                  yield return (XName.Get(nameof(createTableStatement.AsNode), NAMESPACE), createTableStatement.AsNode);
〰97:              }
‼98:              else if (input is ColumnDefinition columnDefinition)
〰99:              {
‼100:                 if (columnDefinition.GeneratedAlways.HasValue)
‼101:                     yield return (XName.Get(nameof(columnDefinition.GeneratedAlways), NAMESPACE), columnDefinition.GeneratedAlways);
〰102: 
‼103:                 yield return (XName.Get(nameof(columnDefinition.IsHidden), NAMESPACE), columnDefinition.IsHidden);
‼104:                 yield return (XName.Get(nameof(columnDefinition.IsMasked), NAMESPACE), columnDefinition.IsMasked);
‼105:                 yield return (XName.Get(nameof(columnDefinition.IsPersisted), NAMESPACE), columnDefinition.IsPersisted);
‼106:                 yield return (XName.Get(nameof(columnDefinition.IsRowGuidCol), NAMESPACE), columnDefinition.IsRowGuidCol);
〰107:             }
‼108:             else if (input is NullableConstraintDefinition nullableConstraintDefinition)
〰109:             {
‼110:                 yield return (XName.Get(nameof(nullableConstraintDefinition.Nullable), NAMESPACE), nullableConstraintDefinition.Nullable);
〰111:             }
‼112:             else if (input is SqlDataTypeReference sqlDataTypeReference)
〰113:             {
‼114:                 yield return (XName.Get(nameof(sqlDataTypeReference.SqlDataTypeOption), NAMESPACE), sqlDataTypeReference.SqlDataTypeOption);
〰115:             }
‼116:             else if (input is Literal literal)
〰117:             {
‼118:                 yield return (XName.Get(nameof(literal.LiteralType), NAMESPACE), literal.LiteralType);
‼119:                 yield return (XName.Get(nameof(literal.Value), NAMESPACE), literal.Value);
〰120:             }
‼121:             else if (input is UniqueConstraintDefinition uniqueConstraintDefinition)
〰122:             {
‼123:                 yield return (XName.Get(nameof(uniqueConstraintDefinition.Clustered), NAMESPACE), uniqueConstraintDefinition.Clustered);
‼124:                 yield return (XName.Get(nameof(uniqueConstraintDefinition.IndexType), NAMESPACE), uniqueConstraintDefinition.IndexType);
‼125:                 yield return (XName.Get(nameof(uniqueConstraintDefinition.IsEnforced), NAMESPACE), uniqueConstraintDefinition.IsEnforced);
‼126:                 yield return (XName.Get(nameof(uniqueConstraintDefinition.IsPrimaryKey), NAMESPACE), uniqueConstraintDefinition.IsPrimaryKey);
〰127:             }
‼128:             else if (input is ColumnReferenceExpression columnReferenceExpression)
〰129:             {
‼130:                 yield return (XName.Get(nameof(columnReferenceExpression.ColumnType), NAMESPACE), columnReferenceExpression.ColumnType);
〰131:             }
‼132:             else if (input is ColumnWithSortOrder columnWithSortOrder)
〰133:             {
‼134:                 yield return (XName.Get(nameof(columnWithSortOrder.SortOrder), NAMESPACE), columnWithSortOrder.SortOrder);
〰135:             }
‼136:             else if (input is DefaultConstraintDefinition defaultConstraintDefinition)
〰137:             {
‼138:                 yield return (XName.Get(nameof(defaultConstraintDefinition.WithValues), NAMESPACE), defaultConstraintDefinition.WithValues);
〰139:             }
‼140:             else if (input is ForeignKeyConstraintDefinition foreignKeyConstraintDefinition)
〰141:             {
‼142:                 yield return (XName.Get(nameof(foreignKeyConstraintDefinition.NotForReplication), NAMESPACE), foreignKeyConstraintDefinition.NotForReplication);
〰143:             }
〰144:             else
〰145:             {
〰146:             }
‼147:         }
〰148: 
〰149:         private static IEnumerable<(XName name, object child)>? SelectChildren(object input)
〰150:         {
‼151:             if (input is TSqlModel model)
〰152:             {
‼153:                 foreach (var i in model.GetObjects(DacQueryScopes.SameDatabase | DacQueryScopes.UserDefined))
‼154:                     yield return (XName.Get(i.ObjectType.Name, NAMESPACE), i);
〰155:             }
‼156:             else if (input is TSqlObject obj)
〰157:             {
‼158:                 foreach (var i in obj.GetChildren())
‼159:                     yield return (XName.Get(i.ObjectType.Name, NAMESPACE), i);
〰160: 
〰161:                 //foreach (var i in obj.GetReferenced())
〰162:                 //    yield return (XName.Get("RERERENCED", NAMESPACE), i);
〰163: 
〰164:                 //foreach (var i in obj.GetReferencing())
〰165:                 //    yield return (XName.Get("RERERENCEING", NAMESPACE), i);
〰166: 
〰167:                 //obj.GetMetadata(new ModelMetadataClass {  })
〰168:                 //obj.GetProperty(new ModelPropertyClass { });
〰169:                 //obj.GetReferenced();
〰170:                 //obj.GetReferencing();
〰171: 
‼172:                 if (obj.TryGetAst(out var ast))
‼173:                     yield return (XName.Get("AST", NAMESPACE), ast);
〰174:             }
‼175:             else if (input is TSqlScript script)
〰176:             {
‼177:                 foreach (var i in script.Batches)
‼178:                     yield return (XName.Get("BATCH", NAMESPACE), i);
〰179:             }
‼180:             else if (input is TSqlBatch batch)
〰181:             {
‼182:                 foreach (var i in batch.Statements)
‼183:                     yield return (XName.Get("STATEMENT", NAMESPACE), i);
〰184:             }
‼185:             else if (input is TSqlStatement statement)
〰186:             {
‼187:                 if (statement is TSqlStatementSnippet snippet)
〰188:                 {
〰189:                     //note: do nothing
〰190:                 }
‼191:                 else if (statement is CreateIndexStatement index)
〰192:                 {
‼193:                     yield return (XName.Get(nameof(index.FileStreamOn), NAMESPACE), index.FileStreamOn);
‼194:                     yield return (XName.Get(nameof(index.FilterPredicate), NAMESPACE), index.FilterPredicate);
‼195:                     foreach (var indexOption in index.IndexOptions)
‼196:                         yield return (XName.Get("INDEXOPTION", NAMESPACE), indexOption);
‼197:                     yield return (XName.Get(nameof(index.Name), NAMESPACE), index.Name);
‼198:                     yield return (XName.Get(nameof(index.OnFileGroupOrPartitionScheme), NAMESPACE), index.OnFileGroupOrPartitionScheme);
‼199:                     yield return (XName.Get(nameof(index.OnName), NAMESPACE), index.OnName);
〰200:                 }
‼201:                 else if (statement is GrantStatement grant)
〰202:                 {
‼203:                     yield return (XName.Get(nameof(grant.AsClause), NAMESPACE), grant.AsClause);
‼204:                     foreach (var item in grant.Permissions)
‼205:                         yield return (XName.Get("PERMISSION", NAMESPACE), item);
‼206:                     foreach (var item in grant.Principals)
‼207:                         yield return (XName.Get("PRINCIPAL", NAMESPACE), item);
〰208:                 }
‼209:                 else if (statement is CreateSchemaStatement createSchemaStatementoolExp)
〰210:                 {
‼211:                     yield return (XName.Get(nameof(createSchemaStatementoolExp.Name), NAMESPACE), createSchemaStatementoolExp.Name);
‼212:                     yield return (XName.Get(nameof(createSchemaStatementoolExp.Owner), NAMESPACE), createSchemaStatementoolExp.Owner);
‼213:                     yield return (XName.Get(nameof(createSchemaStatementoolExp.StatementList), NAMESPACE), createSchemaStatementoolExp.StatementList);
〰214:                 }
‼215:                 else if (statement is CreateTableStatement createTableStatement)
〰216:                 {
‼217:                     foreach (var item in createTableStatement.CtasColumns)
‼218:                         yield return (XName.Get("CTAS-COLUMN", NAMESPACE), item);
‼219:                     yield return (XName.Get(nameof(createTableStatement.Definition), NAMESPACE), createTableStatement.Definition);
‼220:                     yield return (XName.Get(nameof(createTableStatement.FederationScheme), NAMESPACE), createTableStatement.FederationScheme);
‼221:                     yield return (XName.Get(nameof(createTableStatement.FileStreamOn), NAMESPACE), createTableStatement.FileStreamOn);
‼222:                     yield return (XName.Get(nameof(createTableStatement.OnFileGroupOrPartitionScheme), NAMESPACE), createTableStatement.OnFileGroupOrPartitionScheme);
‼223:                     foreach (var item in createTableStatement.Options)
‼224:                         yield return (XName.Get("OPTION", NAMESPACE), item);
‼225:                     yield return (XName.Get(nameof(createTableStatement.SchemaObjectName), NAMESPACE), createTableStatement.SchemaObjectName);
‼226:                     yield return (XName.Get(nameof(createTableStatement.SelectStatement), NAMESPACE), createTableStatement.SelectStatement);
‼227:                     yield return (XName.Get(nameof(createTableStatement.TextImageOn), NAMESPACE), createTableStatement.TextImageOn);
〰228:                 }
〰229:                 else
〰230:                 {
‼231:                     throw new NotSupportedException($"{input.GetType().FullName}");
〰232:                 }
〰233: 
‼234:                 foreach (var item in statement.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
‼235:                     yield return (XName.Get("TOKEN", NAMESPACE), item);
〰236:             }
‼237:             else if (input is Identifier identifier)
〰238:             {
‼239:                 foreach (var i in identifier.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
‼240:                     yield return (XName.Get("TOKEN", NAMESPACE), i);
〰241:             }
‼242:             else if (input is SchemaObjectName schemaObjectName)
〰243:             {
〰244:                 //yield return (XName.Get(nameof(schemaObjectName.BaseIdentifier), NAMESPACE), schemaObjectName.BaseIdentifier);
〰245:                 //yield return (XName.Get(nameof(schemaObjectName.DatabaseIdentifier), NAMESPACE), schemaObjectName.DatabaseIdentifier);
〰246:                 //yield return (XName.Get(nameof(schemaObjectName.ServerIdentifier), NAMESPACE), schemaObjectName.ServerIdentifier);
‼247:                 foreach (var i in schemaObjectName.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
‼248:                     yield return (XName.Get("TOKEN", NAMESPACE), i);
〰249: 
‼250:                 foreach (var ident in schemaObjectName.Identifiers)
‼251:                     yield return (XName.Get("IDENTIFIER", NAMESPACE), ident);
〰252:             }
‼253:             else if (input is Microsoft.SqlServer.TransactSql.ScriptDom.Permission permission)
〰254:             {
‼255:                 foreach (var ident in permission.Columns)
‼256:                     yield return (XName.Get("COLUMN", NAMESPACE), ident);
‼257:                 foreach (var ident in permission.Identifiers)
‼258:                     yield return (XName.Get("IDENTIFIER", NAMESPACE), ident);
‼259:                 if (permission.ScriptTokenStream != null)
‼260:                     foreach (var i in permission.ScriptTokenStream)
‼261:                         yield return (XName.Get("TOKEN", NAMESPACE), i);
〰262:             }
‼263:             else if (input is SecurityPrincipal securityPrincipal)
〰264:             {
‼265:                 yield return (XName.Get(nameof(securityPrincipal.Identifier), NAMESPACE), securityPrincipal.Identifier);
‼266:                 foreach (var i in securityPrincipal.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
‼267:                     yield return (XName.Get("TOKEN", NAMESPACE), i);
〰268:             }
‼269:             else if (input is BooleanExpressionSnippet booleanExpressionSnippet)
〰270:             {
‼271:                 foreach (var i in booleanExpressionSnippet.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
‼272:                     yield return (XName.Get("TOKEN", NAMESPACE), i);
〰273:             }
‼274:             else if (input is StatementList statementList)
〰275:             {
‼276:                 foreach (var i in statementList.Statements ?? Enumerable.Empty<TSqlStatement>())
‼277:                     yield return (XName.Get("STATEMENT", NAMESPACE), i);
〰278:             }
‼279:             else if (input is TableDefinition tableDefinition)
〰280:             {
‼281:                 foreach (var i in tableDefinition.ColumnDefinitions)
‼282:                     yield return (XName.Get("COLUMN", NAMESPACE), i);
‼283:                 foreach (var i in tableDefinition.Indexes)
‼284:                     yield return (XName.Get("INDEX", NAMESPACE), i);
‼285:                 foreach (var i in tableDefinition.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
‼286:                     yield return (XName.Get("TOKEN", NAMESPACE), i);
‼287:                 foreach (var i in tableDefinition.TableConstraints)
‼288:                     yield return (XName.Get("CONSTRAINT", NAMESPACE), i);
〰289:             }
‼290:             else if (input is ColumnDefinition columnDefinition)
〰291:             {
‼292:                 yield return (XName.Get(nameof(columnDefinition.Collation), NAMESPACE), columnDefinition.Collation);
‼293:                 yield return (XName.Get(nameof(columnDefinition.ColumnIdentifier), NAMESPACE), columnDefinition.ColumnIdentifier);
‼294:                 yield return (XName.Get(nameof(columnDefinition.ComputedColumnExpression), NAMESPACE), columnDefinition.ComputedColumnExpression);
‼295:                 foreach (var i in columnDefinition.Constraints)
‼296:                     yield return (XName.Get("CONSTRAINT", NAMESPACE), i);
‼297:                 yield return (XName.Get(nameof(columnDefinition.DataType), NAMESPACE), columnDefinition.DataType);
‼298:                 yield return (XName.Get(nameof(columnDefinition.DefaultConstraint), NAMESPACE), columnDefinition.DefaultConstraint);
‼299:                 yield return (XName.Get(nameof(columnDefinition.Encryption), NAMESPACE), columnDefinition.Encryption);
‼300:                 yield return (XName.Get(nameof(columnDefinition.IdentityOptions), NAMESPACE), columnDefinition.IdentityOptions);
‼301:                 yield return (XName.Get(nameof(columnDefinition.Index), NAMESPACE), columnDefinition.Index);
‼302:                 yield return (XName.Get(nameof(columnDefinition.MaskingFunction), NAMESPACE), columnDefinition.MaskingFunction);
‼303:                 foreach (var i in columnDefinition.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
‼304:                     yield return (XName.Get("TOKEN", NAMESPACE), i);
‼305:                 yield return (XName.Get(nameof(columnDefinition.StorageOptions), NAMESPACE), columnDefinition.StorageOptions);
〰306:             }
‼307:             else if (input is NullableConstraintDefinition nullableConstraintDefinition)
〰308:             {
‼309:                 yield return (XName.Get(nameof(nullableConstraintDefinition.ConstraintIdentifier), NAMESPACE), nullableConstraintDefinition.ConstraintIdentifier);
‼310:                 foreach (var i in nullableConstraintDefinition.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
‼311:                     yield return (XName.Get("TOKEN", NAMESPACE), i);
〰312:             }
‼313:             else if (input is SqlDataTypeReference sqlDataTypeReference)
〰314:             {
‼315:                 yield return (XName.Get(nameof(sqlDataTypeReference.Name), NAMESPACE), sqlDataTypeReference.Name);
〰316: 
‼317:                 foreach (var i in sqlDataTypeReference.Parameters)
‼318:                     yield return (XName.Get("PARAMETER", NAMESPACE), i);
‼319:                 foreach (var i in sqlDataTypeReference.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
‼320:                     yield return (XName.Get("TOKEN", NAMESPACE), i);
〰321:             }
‼322:             else if (input is UniqueConstraintDefinition uniqueConstraintDefinition)
〰323:             {
‼324:                 foreach (var i in uniqueConstraintDefinition.Columns)
‼325:                     yield return (XName.Get("COLUMN", NAMESPACE), i);
‼326:                 yield return (XName.Get(nameof(uniqueConstraintDefinition.ConstraintIdentifier), NAMESPACE), uniqueConstraintDefinition.ConstraintIdentifier);
‼327:                 yield return (XName.Get(nameof(uniqueConstraintDefinition.FileStreamOn), NAMESPACE), uniqueConstraintDefinition.FileStreamOn);
‼328:                 foreach (var i in uniqueConstraintDefinition.IndexOptions)
‼329:                     yield return (XName.Get("OPTION", NAMESPACE), i);
‼330:                 yield return (XName.Get(nameof(uniqueConstraintDefinition.OnFileGroupOrPartitionScheme), NAMESPACE), uniqueConstraintDefinition.OnFileGroupOrPartitionScheme);
‼331:                 foreach (var i in uniqueConstraintDefinition.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
‼332:                     yield return (XName.Get("TOKEN", NAMESPACE), i);
〰333:             }
‼334:             else if (input is Literal literal)
〰335:             {
‼336:                 foreach (var i in literal.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
‼337:                     yield return (XName.Get("TOKEN", NAMESPACE), i);
〰338:             }
‼339:             else if (input is ColumnWithSortOrder columnWithSortOrder)
〰340:             {
‼341:                 yield return (XName.Get(nameof(columnWithSortOrder.Column), NAMESPACE), columnWithSortOrder.Column);
‼342:                 foreach (var i in columnWithSortOrder.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
‼343:                     yield return (XName.Get("TOKEN", NAMESPACE), i);
〰344:             }
‼345:             else if (input is ColumnReferenceExpression columnReferenceExpression)
〰346:             {
‼347:                 yield return (XName.Get(nameof(columnReferenceExpression.Collation), NAMESPACE), columnReferenceExpression.Collation);
‼348:                 yield return (XName.Get(nameof(columnReferenceExpression.MultiPartIdentifier), NAMESPACE), columnReferenceExpression.MultiPartIdentifier);
‼349:                 foreach (var i in columnReferenceExpression.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
‼350:                     yield return (XName.Get("TOKEN", NAMESPACE), i);
〰351:             }
‼352:             else if (input is MultiPartIdentifier multiPartIdentifier)
〰353:             {
‼354:                 foreach (var i in multiPartIdentifier.Identifiers)
‼355:                     yield return (XName.Get("IDENTIFIER", NAMESPACE), i);
‼356:                 foreach (var i in multiPartIdentifier.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
‼357:                     yield return (XName.Get("TOKEN", NAMESPACE), i);
〰358:             }
‼359:             else if (input is DefaultConstraintDefinition defaultConstraintDefinition)
〰360:             {
‼361:                 yield return (XName.Get(nameof(defaultConstraintDefinition.Column), NAMESPACE), defaultConstraintDefinition.Column);
‼362:                 yield return (XName.Get(nameof(defaultConstraintDefinition.ConstraintIdentifier), NAMESPACE), defaultConstraintDefinition.ConstraintIdentifier);
‼363:                 yield return (XName.Get(nameof(defaultConstraintDefinition.Expression), NAMESPACE), defaultConstraintDefinition.Expression);
〰364: 
‼365:                 foreach (var i in defaultConstraintDefinition.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
‼366:                     yield return (XName.Get("TOKEN", NAMESPACE), i);
〰367:             }
‼368:             else if (input is ScalarExpressionSnippet scalarExpressionSnippet)
〰369:             {
‼370:                 foreach (var i in scalarExpressionSnippet.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
‼371:                     yield return (XName.Get("TOKEN", NAMESPACE), i);
〰372:             }
‼373:             else if (input is ForeignKeyConstraintDefinition foreignKeyConstraintDefinition)
〰374:             {
‼375:                 yield return (XName.Get(nameof(foreignKeyConstraintDefinition.NotForReplication), NAMESPACE), foreignKeyConstraintDefinition.NotForReplication);
〰376: 
‼377:                 foreach (var i in foreignKeyConstraintDefinition.Columns)
‼378:                     yield return (XName.Get("COLUMN", NAMESPACE), i);
‼379:                 yield return (XName.Get(nameof(foreignKeyConstraintDefinition.ConstraintIdentifier), NAMESPACE), foreignKeyConstraintDefinition.ConstraintIdentifier);
‼380:                 yield return (XName.Get(nameof(foreignKeyConstraintDefinition.DeleteAction), NAMESPACE), foreignKeyConstraintDefinition.DeleteAction);
〰381: 
‼382:                 foreach (var i in foreignKeyConstraintDefinition.ReferencedTableColumns)
‼383:                     yield return (XName.Get("REFERENCE-COLUMN", NAMESPACE), i);
〰384: 
‼385:                 yield return (XName.Get(nameof(foreignKeyConstraintDefinition.ReferenceTableName), NAMESPACE), foreignKeyConstraintDefinition.ReferenceTableName);
‼386:                 yield return (XName.Get(nameof(foreignKeyConstraintDefinition.UpdateAction), NAMESPACE), foreignKeyConstraintDefinition.UpdateAction);
〰387: 
〰388: 
‼389:                 foreach (var i in foreignKeyConstraintDefinition.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
‼390:                     yield return (XName.Get("TOKEN", NAMESPACE), i);
〰391:             }
〰392:             else
〰393:             {
〰394: 
‼395:                 throw new NotSupportedException($"{input.GetType().FullName}");
〰396:             }
‼397:         }
〰398:     }
〰399: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

