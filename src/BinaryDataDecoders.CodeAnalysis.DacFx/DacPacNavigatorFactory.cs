using BinaryDataDecoders.ToolKit.Xml.XPath;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.CodeAnalysis.DacFx
{

    public static class DacPacNavigatorFactory
    {
        private const string NAMESPACE = "";

        public static IXPathNavigable ToNavigable(this TSqlModel tree) =>
            new ExtensibleNavigator(tree.AsNode());

        public static INode AsNode(this TSqlModel build) =>
            new ExtensibleElementNode(
                "DACPAC",
                build,

              valueSelector: n => SelectValue(n)?.ToString(),
              attributeSelector: n => SelectAttributes(n).Select(i => (i.name, i.value?.ToString())),
              childSelector: SelectChildren
              );

        private static object? SelectValue(object arg)
        {
            return arg switch
            {
                //  TSqlObject model => model.TryGetScript(out var obj) ? obj : null,
                BooleanExpressionSnippet exp => exp.Script,
                TSqlStatementSnippet snippet => snippet.Script,
                ScalarExpressionSnippet snippet => snippet.Script,

                string value => value,
                bool value => value,

                _ => null
            };
        }

        private static IEnumerable<(XName name, object? value)>? SelectAttributes(object input)
        {
            if (input is TSqlModel model)
            {
                yield return (XName.Get(nameof(model.EngineVersion), NAMESPACE), model.EngineVersion);
                yield return (XName.Get(nameof(model.Version), NAMESPACE), model.Version);
            }
            else if (input is TSqlObject obj)
            {
                yield return (XName.Get(nameof(obj.Name), NAMESPACE), string.Join(".", obj.Name.Parts));
            }
            else if (input is TSqlScript script)
            {
                yield return (XName.Get(nameof(script.StartLine), NAMESPACE), script.StartLine);
            }
            else if (input is TSqlBatch batch)
            {
                yield return (XName.Get(nameof(batch.StartLine), NAMESPACE), batch.StartLine);
            }
            else if (input is TSqlStatement statement)
            {
                yield return (XName.Get(nameof(statement.StartLine), NAMESPACE), statement.StartLine);

                if (statement is TSqlStatementSnippet snippet)
                {
                    //Note: do nothing
                }
                else if (statement is CreateIndexStatement index)
                {
                    yield return (XName.Get(nameof(index.Clustered), NAMESPACE), index.Clustered);
                    yield return (XName.Get(nameof(index.Translated80SyntaxTo90), NAMESPACE), index.Translated80SyntaxTo90);
                    yield return (XName.Get(nameof(index.Unique), NAMESPACE), index.Unique);
                }
                else
                {
                }
            }
            else if (input is Identifier identifier)
            {
                yield return (XName.Get(nameof(identifier.QuoteType), NAMESPACE), identifier.QuoteType);
                yield return (XName.Get(nameof(identifier.Value), NAMESPACE), identifier.Value);
            }
            else if (input is SecurityPrincipal securityPrincipal)
            {
                yield return (XName.Get(nameof(securityPrincipal.PrincipalType), NAMESPACE), securityPrincipal.PrincipalType);
            }
            else if (input is CreateTableStatement createTableStatement)
            {
                yield return (XName.Get(nameof(createTableStatement.AsEdge), NAMESPACE), createTableStatement.AsEdge);
                yield return (XName.Get(nameof(createTableStatement.AsFileTable), NAMESPACE), createTableStatement.AsFileTable);
                yield return (XName.Get(nameof(createTableStatement.AsNode), NAMESPACE), createTableStatement.AsNode);
            }
            else if (input is ColumnDefinition columnDefinition)
            {
                if (columnDefinition.GeneratedAlways.HasValue)
                    yield return (XName.Get(nameof(columnDefinition.GeneratedAlways), NAMESPACE), columnDefinition.GeneratedAlways);

                yield return (XName.Get(nameof(columnDefinition.IsHidden), NAMESPACE), columnDefinition.IsHidden);
                yield return (XName.Get(nameof(columnDefinition.IsMasked), NAMESPACE), columnDefinition.IsMasked);
                yield return (XName.Get(nameof(columnDefinition.IsPersisted), NAMESPACE), columnDefinition.IsPersisted);
                yield return (XName.Get(nameof(columnDefinition.IsRowGuidCol), NAMESPACE), columnDefinition.IsRowGuidCol);
            }
            else if (input is NullableConstraintDefinition nullableConstraintDefinition)
            {
                yield return (XName.Get(nameof(nullableConstraintDefinition.Nullable), NAMESPACE), nullableConstraintDefinition.Nullable);
            }
            else if (input is SqlDataTypeReference sqlDataTypeReference)
            {
                yield return (XName.Get(nameof(sqlDataTypeReference.SqlDataTypeOption), NAMESPACE), sqlDataTypeReference.SqlDataTypeOption);
            }
            else if (input is Literal literal)
            {
                yield return (XName.Get(nameof(literal.LiteralType), NAMESPACE), literal.LiteralType);
                yield return (XName.Get(nameof(literal.Value), NAMESPACE), literal.Value);
            }
            else if (input is UniqueConstraintDefinition uniqueConstraintDefinition)
            {
                yield return (XName.Get(nameof(uniqueConstraintDefinition.Clustered), NAMESPACE), uniqueConstraintDefinition.Clustered);
                yield return (XName.Get(nameof(uniqueConstraintDefinition.IndexType), NAMESPACE), uniqueConstraintDefinition.IndexType);
                yield return (XName.Get(nameof(uniqueConstraintDefinition.IsEnforced), NAMESPACE), uniqueConstraintDefinition.IsEnforced);
                yield return (XName.Get(nameof(uniqueConstraintDefinition.IsPrimaryKey), NAMESPACE), uniqueConstraintDefinition.IsPrimaryKey);
            }
            else if (input is ColumnReferenceExpression columnReferenceExpression)
            {
                yield return (XName.Get(nameof(columnReferenceExpression.ColumnType), NAMESPACE), columnReferenceExpression.ColumnType);
            }
            else if (input is ColumnWithSortOrder columnWithSortOrder)
            {
                yield return (XName.Get(nameof(columnWithSortOrder.SortOrder), NAMESPACE), columnWithSortOrder.SortOrder);
            }
            else if (input is DefaultConstraintDefinition defaultConstraintDefinition)
            {
                yield return (XName.Get(nameof(defaultConstraintDefinition.WithValues), NAMESPACE), defaultConstraintDefinition.WithValues);
            }
            else if (input is ForeignKeyConstraintDefinition foreignKeyConstraintDefinition)
            {
                yield return (XName.Get(nameof(foreignKeyConstraintDefinition.NotForReplication), NAMESPACE), foreignKeyConstraintDefinition.NotForReplication);
            }
            else
            {
            }
        }

        private static IEnumerable<(XName name, object child)>? SelectChildren(object input)
        {
            if (input is TSqlModel model)
            {
                foreach (var i in model.GetObjects(DacQueryScopes.SameDatabase | DacQueryScopes.UserDefined))
                    yield return (XName.Get(i.ObjectType.Name, NAMESPACE), i);
            }
            else if (input is TSqlObject obj)
            {
                foreach (var i in obj.GetChildren())
                    yield return (XName.Get(i.ObjectType.Name, NAMESPACE), i);

                //foreach (var i in obj.GetReferenced())
                //    yield return (XName.Get("RERERENCED", NAMESPACE), i);

                //foreach (var i in obj.GetReferencing())
                //    yield return (XName.Get("RERERENCEING", NAMESPACE), i);

                //obj.GetMetadata(new ModelMetadataClass {  })
                //obj.GetProperty(new ModelPropertyClass { });
                //obj.GetReferenced();
                //obj.GetReferencing();

                if (obj.TryGetAst(out var ast))
                    yield return (XName.Get("AST", NAMESPACE), ast);
            }
            else if (input is TSqlScript script)
            {
                foreach (var i in script.Batches)
                    yield return (XName.Get("BATCH", NAMESPACE), i);
            }
            else if (input is TSqlBatch batch)
            {
                foreach (var i in batch.Statements)
                    yield return (XName.Get("STATEMENT", NAMESPACE), i);
            }
            else if (input is TSqlStatement statement)
            {
                if (statement is TSqlStatementSnippet snippet)
                {
                    //note: do nothing
                }
                else if (statement is CreateIndexStatement index)
                {
                    yield return (XName.Get(nameof(index.FileStreamOn), NAMESPACE), index.FileStreamOn);
                    yield return (XName.Get(nameof(index.FilterPredicate), NAMESPACE), index.FilterPredicate);
                    foreach (var indexOption in index.IndexOptions)
                        yield return (XName.Get("INDEXOPTION", NAMESPACE), indexOption);
                    yield return (XName.Get(nameof(index.Name), NAMESPACE), index.Name);
                    yield return (XName.Get(nameof(index.OnFileGroupOrPartitionScheme), NAMESPACE), index.OnFileGroupOrPartitionScheme);
                    yield return (XName.Get(nameof(index.OnName), NAMESPACE), index.OnName);
                }
                else if (statement is GrantStatement grant)
                {
                    yield return (XName.Get(nameof(grant.AsClause), NAMESPACE), grant.AsClause);
                    foreach (var item in grant.Permissions)
                        yield return (XName.Get("PERMISSION", NAMESPACE), item);
                    foreach (var item in grant.Principals)
                        yield return (XName.Get("PRINCIPAL", NAMESPACE), item);
                }
                else if (statement is CreateSchemaStatement createSchemaStatementoolExp)
                {
                    yield return (XName.Get(nameof(createSchemaStatementoolExp.Name), NAMESPACE), createSchemaStatementoolExp.Name);
                    yield return (XName.Get(nameof(createSchemaStatementoolExp.Owner), NAMESPACE), createSchemaStatementoolExp.Owner);
                    yield return (XName.Get(nameof(createSchemaStatementoolExp.StatementList), NAMESPACE), createSchemaStatementoolExp.StatementList);
                }
                else if (statement is CreateTableStatement createTableStatement)
                {
                    foreach (var item in createTableStatement.CtasColumns)
                        yield return (XName.Get("CTAS-COLUMN", NAMESPACE), item);
                    yield return (XName.Get(nameof(createTableStatement.Definition), NAMESPACE), createTableStatement.Definition);
                    yield return (XName.Get(nameof(createTableStatement.FederationScheme), NAMESPACE), createTableStatement.FederationScheme);
                    yield return (XName.Get(nameof(createTableStatement.FileStreamOn), NAMESPACE), createTableStatement.FileStreamOn);
                    yield return (XName.Get(nameof(createTableStatement.OnFileGroupOrPartitionScheme), NAMESPACE), createTableStatement.OnFileGroupOrPartitionScheme);
                    foreach (var item in createTableStatement.Options)
                        yield return (XName.Get("OPTION", NAMESPACE), item);
                    yield return (XName.Get(nameof(createTableStatement.SchemaObjectName), NAMESPACE), createTableStatement.SchemaObjectName);
                    yield return (XName.Get(nameof(createTableStatement.SelectStatement), NAMESPACE), createTableStatement.SelectStatement);
                    yield return (XName.Get(nameof(createTableStatement.TextImageOn), NAMESPACE), createTableStatement.TextImageOn);
                }
                else
                {
                    throw new NotSupportedException($"{input.GetType().FullName}");
                }

                foreach (var item in statement.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
                    yield return (XName.Get("TOKEN", NAMESPACE), item);
            }
            else if (input is Identifier identifier)
            {
                foreach (var i in identifier.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
                    yield return (XName.Get("TOKEN", NAMESPACE), i);
            }
            else if (input is SchemaObjectName schemaObjectName)
            {
                //yield return (XName.Get(nameof(schemaObjectName.BaseIdentifier), NAMESPACE), schemaObjectName.BaseIdentifier);
                //yield return (XName.Get(nameof(schemaObjectName.DatabaseIdentifier), NAMESPACE), schemaObjectName.DatabaseIdentifier);
                //yield return (XName.Get(nameof(schemaObjectName.ServerIdentifier), NAMESPACE), schemaObjectName.ServerIdentifier);
                foreach (var i in schemaObjectName.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
                    yield return (XName.Get("TOKEN", NAMESPACE), i);

                foreach (var ident in schemaObjectName.Identifiers)
                    yield return (XName.Get("IDENTIFIER", NAMESPACE), ident);
            }
            else if (input is Microsoft.SqlServer.TransactSql.ScriptDom.Permission permission)
            {
                foreach (var ident in permission.Columns)
                    yield return (XName.Get("COLUMN", NAMESPACE), ident);
                foreach (var ident in permission.Identifiers)
                    yield return (XName.Get("IDENTIFIER", NAMESPACE), ident);
                if (permission.ScriptTokenStream != null)
                    foreach (var i in permission.ScriptTokenStream)
                        yield return (XName.Get("TOKEN", NAMESPACE), i);
            }
            else if (input is SecurityPrincipal securityPrincipal)
            {
                yield return (XName.Get(nameof(securityPrincipal.Identifier), NAMESPACE), securityPrincipal.Identifier);
                foreach (var i in securityPrincipal.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
                    yield return (XName.Get("TOKEN", NAMESPACE), i);
            }
            else if (input is BooleanExpressionSnippet booleanExpressionSnippet)
            {
                foreach (var i in booleanExpressionSnippet.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
                    yield return (XName.Get("TOKEN", NAMESPACE), i);
            }
            else if (input is StatementList statementList)
            {
                foreach (var i in statementList.Statements ?? Enumerable.Empty<TSqlStatement>())
                    yield return (XName.Get("STATEMENT", NAMESPACE), i);
            }
            else if (input is TableDefinition tableDefinition)
            {
                foreach (var i in tableDefinition.ColumnDefinitions)
                    yield return (XName.Get("COLUMN", NAMESPACE), i);
                foreach (var i in tableDefinition.Indexes)
                    yield return (XName.Get("INDEX", NAMESPACE), i);
                foreach (var i in tableDefinition.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
                    yield return (XName.Get("TOKEN", NAMESPACE), i);
                foreach (var i in tableDefinition.TableConstraints)
                    yield return (XName.Get("CONSTRAINT", NAMESPACE), i);
            }
            else if (input is ColumnDefinition columnDefinition)
            {
                yield return (XName.Get(nameof(columnDefinition.Collation), NAMESPACE), columnDefinition.Collation);
                yield return (XName.Get(nameof(columnDefinition.ColumnIdentifier), NAMESPACE), columnDefinition.ColumnIdentifier);
                yield return (XName.Get(nameof(columnDefinition.ComputedColumnExpression), NAMESPACE), columnDefinition.ComputedColumnExpression);
                foreach (var i in columnDefinition.Constraints)
                    yield return (XName.Get("CONSTRAINT", NAMESPACE), i);
                yield return (XName.Get(nameof(columnDefinition.DataType), NAMESPACE), columnDefinition.DataType);
                yield return (XName.Get(nameof(columnDefinition.DefaultConstraint), NAMESPACE), columnDefinition.DefaultConstraint);
                yield return (XName.Get(nameof(columnDefinition.Encryption), NAMESPACE), columnDefinition.Encryption);
                yield return (XName.Get(nameof(columnDefinition.IdentityOptions), NAMESPACE), columnDefinition.IdentityOptions);
                yield return (XName.Get(nameof(columnDefinition.Index), NAMESPACE), columnDefinition.Index);
                yield return (XName.Get(nameof(columnDefinition.MaskingFunction), NAMESPACE), columnDefinition.MaskingFunction);
                foreach (var i in columnDefinition.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
                    yield return (XName.Get("TOKEN", NAMESPACE), i);
                yield return (XName.Get(nameof(columnDefinition.StorageOptions), NAMESPACE), columnDefinition.StorageOptions);
            }
            else if (input is NullableConstraintDefinition nullableConstraintDefinition)
            {
                yield return (XName.Get(nameof(nullableConstraintDefinition.ConstraintIdentifier), NAMESPACE), nullableConstraintDefinition.ConstraintIdentifier);
                foreach (var i in nullableConstraintDefinition.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
                    yield return (XName.Get("TOKEN", NAMESPACE), i);
            }
            else if (input is SqlDataTypeReference sqlDataTypeReference)
            {
                yield return (XName.Get(nameof(sqlDataTypeReference.Name), NAMESPACE), sqlDataTypeReference.Name);

                foreach (var i in sqlDataTypeReference.Parameters)
                    yield return (XName.Get("PARAMETER", NAMESPACE), i);
                foreach (var i in sqlDataTypeReference.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
                    yield return (XName.Get("TOKEN", NAMESPACE), i);
            }
            else if (input is UniqueConstraintDefinition uniqueConstraintDefinition)
            {
                foreach (var i in uniqueConstraintDefinition.Columns)
                    yield return (XName.Get("COLUMN", NAMESPACE), i);
                yield return (XName.Get(nameof(uniqueConstraintDefinition.ConstraintIdentifier), NAMESPACE), uniqueConstraintDefinition.ConstraintIdentifier);
                yield return (XName.Get(nameof(uniqueConstraintDefinition.FileStreamOn), NAMESPACE), uniqueConstraintDefinition.FileStreamOn);
                foreach (var i in uniqueConstraintDefinition.IndexOptions)
                    yield return (XName.Get("OPTION", NAMESPACE), i);
                yield return (XName.Get(nameof(uniqueConstraintDefinition.OnFileGroupOrPartitionScheme), NAMESPACE), uniqueConstraintDefinition.OnFileGroupOrPartitionScheme);
                foreach (var i in uniqueConstraintDefinition.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
                    yield return (XName.Get("TOKEN", NAMESPACE), i);
            }
            else if (input is Literal literal)
            {
                foreach (var i in literal.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
                    yield return (XName.Get("TOKEN", NAMESPACE), i);
            }
            else if (input is ColumnWithSortOrder columnWithSortOrder)
            {
                yield return (XName.Get(nameof(columnWithSortOrder.Column), NAMESPACE), columnWithSortOrder.Column);
                foreach (var i in columnWithSortOrder.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
                    yield return (XName.Get("TOKEN", NAMESPACE), i);
            }
            else if (input is ColumnReferenceExpression columnReferenceExpression)
            {
                yield return (XName.Get(nameof(columnReferenceExpression.Collation), NAMESPACE), columnReferenceExpression.Collation);
                yield return (XName.Get(nameof(columnReferenceExpression.MultiPartIdentifier), NAMESPACE), columnReferenceExpression.MultiPartIdentifier);
                foreach (var i in columnReferenceExpression.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
                    yield return (XName.Get("TOKEN", NAMESPACE), i);
            }
            else if (input is MultiPartIdentifier multiPartIdentifier)
            {
                foreach (var i in multiPartIdentifier.Identifiers)
                    yield return (XName.Get("IDENTIFIER", NAMESPACE), i);
                foreach (var i in multiPartIdentifier.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
                    yield return (XName.Get("TOKEN", NAMESPACE), i);
            }
            else if (input is DefaultConstraintDefinition defaultConstraintDefinition)
            {
                yield return (XName.Get(nameof(defaultConstraintDefinition.Column), NAMESPACE), defaultConstraintDefinition.Column);
                yield return (XName.Get(nameof(defaultConstraintDefinition.ConstraintIdentifier), NAMESPACE), defaultConstraintDefinition.ConstraintIdentifier);
                yield return (XName.Get(nameof(defaultConstraintDefinition.Expression), NAMESPACE), defaultConstraintDefinition.Expression);

                foreach (var i in defaultConstraintDefinition.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
                    yield return (XName.Get("TOKEN", NAMESPACE), i);
            }
            else if (input is ScalarExpressionSnippet scalarExpressionSnippet)
            {
                foreach (var i in scalarExpressionSnippet.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
                    yield return (XName.Get("TOKEN", NAMESPACE), i);
            }
            else if (input is ForeignKeyConstraintDefinition foreignKeyConstraintDefinition)
            {
                yield return (XName.Get(nameof(foreignKeyConstraintDefinition.NotForReplication), NAMESPACE), foreignKeyConstraintDefinition.NotForReplication);

                foreach (var i in foreignKeyConstraintDefinition.Columns)
                    yield return (XName.Get("COLUMN", NAMESPACE), i);
                yield return (XName.Get(nameof(foreignKeyConstraintDefinition.ConstraintIdentifier), NAMESPACE), foreignKeyConstraintDefinition.ConstraintIdentifier);
                yield return (XName.Get(nameof(foreignKeyConstraintDefinition.DeleteAction), NAMESPACE), foreignKeyConstraintDefinition.DeleteAction);

                foreach (var i in foreignKeyConstraintDefinition.ReferencedTableColumns)
                    yield return (XName.Get("REFERENCE-COLUMN", NAMESPACE), i);

                yield return (XName.Get(nameof(foreignKeyConstraintDefinition.ReferenceTableName), NAMESPACE), foreignKeyConstraintDefinition.ReferenceTableName);
                yield return (XName.Get(nameof(foreignKeyConstraintDefinition.UpdateAction), NAMESPACE), foreignKeyConstraintDefinition.UpdateAction);


                foreach (var i in foreignKeyConstraintDefinition.ScriptTokenStream ?? Enumerable.Empty<TSqlParserToken>())
                    yield return (XName.Get("TOKEN", NAMESPACE), i);
            }
            else
            {

                throw new NotSupportedException($"{input.GetType().FullName}");
            }
        }
    }
}