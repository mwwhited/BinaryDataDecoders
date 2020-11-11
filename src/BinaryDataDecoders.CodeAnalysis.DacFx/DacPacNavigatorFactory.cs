using BinaryDataDecoders.ToolKit.Xml.XPath;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BinaryDataDecoders.CodeAnalysis.DacFx
{
    public static class DacPacNavigatorFactory
    {
        public static IXPathNavigable ToNavigable(this TSqlModel tree) =>
            new ExtensibleNavigator(tree.AsNode());

        public static INode AsNode(this TSqlModel build) =>
            new ExtensibleElementNode(
                "sql",
                build,

              valueSelector: n => n switch
              {
                  TSqlObject model => model.TryGetScript(out var obj) ? obj : null,
                  string value => value,

                  _ => null
              },

              attributeSelector: n => n switch
              {
                  TSqlModel model => new (XName, string?)[] {
                          (XName.Get(nameof(model.EngineVersion), ""),model.EngineVersion.ToString()),
                          (XName.Get(nameof(model.Version), ""),model.Version.ToString()),
                  },

                  TSqlObject model => new (XName, string?)[] {
                          (XName.Get(nameof(model.Name), ""),string.Join(".",model.Name.Parts)),
                  },

                  //TSqlScript script => new (XName, string?)[] {
                  //        (XName.Get(nameof(script.StartLine), ""),script.StartLine.ToString()),
                  //},

                  //TSqlBatch batch => new (XName, string?)[] {
                  //        (XName.Get(nameof(batch.StartLine), ""),batch.StartLine.ToString()),
                  //},

                  //TSqlStatement statement => new (XName, string?)[] {
                  //        (XName.Get(nameof(statement.StartLine), ""),statement.StartLine.ToString()),
                  //},

                  TSqlParserToken token => new (XName, string?)[] {
                          (XName.Get(nameof(token.Text), ""),token.Text),
                  },

                  _ => null,
              },

              childSelector: n => n switch
              {
                  TSqlModel model => model.GetObjects(DacQueryScopes.SameDatabase | DacQueryScopes.UserDefined)
                                          .Select(i => (XName.Get(i.ObjectType.Name, ""), (object)i)),

                  TSqlObject model => model.GetChildren().Select(i => (XName.Get(i.ObjectType.Name, ""), (object)i))
                                           //   .Concat(model.GetReferencedRelationshipInstances())
                                           .Concat(new[] { (XName.Get("AST", ""), model.TryGetAst(out var ast) ? (object)ast : null) })
                                        ,

                  TSqlScript script => script.Batches?.Select(i => (XName.Get("Batch", ""), (object)i)),
                  TSqlBatch batch => batch.Statements?.Select(i => (XName.Get("Statements", ""), (object)i)),
                  TSqlStatement statement => statement.ScriptTokenStream?.Select(i => (XName.Get(i.TokenType.ToString(), ""), (object)i)),
                  TSqlParserToken token => null,

                  //  .Concat(model.GetReferencedRelationshipInstances().Select(i=>i.,
                  //.Concat(
                  //                from i in model.GetProperty(new ModelPropertyClass())
                  //                select (XName.Get(i.ObjectType.Name, ""), (object)i)
                  //            ),


                  _ => throw new NotSupportedException($"{n.GetType()}"),
              }

              );
    }
}