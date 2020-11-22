using BinaryDataDecoders.ToolKit.Reflection;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace BinaryDataDecoders.CodeAnalysis.DacFx
{
    public class DacPacElementNodeBuilder : ReflectionElementNodeBuilder
    {
        private const string NAMESPACE = "";

        public DacPacElementNodeBuilder(TSqlModel sqlModel) :
            base(sqlModel, true, true)
        {
        }

        protected override IEnumerable<(XName name, object child)>? ChildSelector(object model) =>
            (model switch
            {
                TSqlModel sql => ChildSelector(sql),
                TSqlObject sql => ChildSelector(sql),
                Identifier _ => null,
                _ => Enumerable.Empty<(XName name, object child)>()
            })?.Concat(base.ChildSelector(model) ?? Enumerable.Empty<(XName name, object child)>());
        private IEnumerable<(XName name, object child)>? ChildSelector(TSqlModel model)
        {
            foreach (var i in model.GetObjects(DacQueryScopes.SameDatabase | DacQueryScopes.UserDefined))
                yield return (XName.Get(i.ObjectType.Name, NAMESPACE), i);
        }
        private IEnumerable<(XName name, object child)>? ChildSelector(TSqlObject model)
        {
            foreach (var i in model.GetChildren())
                yield return (XName.Get(i.ObjectType.Name, NAMESPACE), i);

            if (model.TryGetAst(out var ast))
                yield return (XName.Get("AST", NAMESPACE), ast);
        }

        protected override IEnumerable<(XName name, string? value)>? AttributeSelector(object model) =>
            model switch
            {
                TSqlModel sql => AttributeSelector(sql),
                TSqlObject sql => AttributeSelector(sql),
                Identifier ident => AttributeSelector(ident),
                Literal literal => AttributeSelector(literal),
                Type type => AttributeSelector(type),
                _ => base.AttributeSelector(model)
            };
        private IEnumerable<(XName name, string? value)>? AttributeSelector(Identifier model)
        {
            yield return (XName.Get(nameof(model.QuoteType), NAMESPACE), model.QuoteType.ToString());
        }
        private IEnumerable<(XName name, string? value)>? AttributeSelector(Literal model)
        {
            yield return (XName.Get(nameof(model.LiteralType), NAMESPACE), model.LiteralType.ToString());
            yield return (XName.Get(nameof(model.Collation), NAMESPACE), model.Collation?.ToString());
        }
        private IEnumerable<(XName name, string? value)>? AttributeSelector(TSqlModel model)
        {
            yield break;
            //yield return (XName.Get(nameof(model.), NAMESPACE), model.LiteralType.ToString());
            //yield return (XName.Get(nameof(model.Collation), NAMESPACE), model.Collation?.ToString());
        }
        private IEnumerable<(XName name, string? value)>? AttributeSelector(TSqlObject model)
        {
            yield break;
            //yield return (XName.Get(nameof(model.LiteralType), NAMESPACE), model.LiteralType.ToString());
            //yield return (XName.Get(nameof(model.Collation), NAMESPACE), model.Collation?.ToString());
        }
        private IEnumerable<(XName name, string? value)>? AttributeSelector(Type model)
        {
            yield return (XName.Get(nameof(model.AssemblyQualifiedName), NAMESPACE), model.AssemblyQualifiedName);
            yield return (XName.Get(nameof(model.Namespace), NAMESPACE), model.Namespace);
        }

        private HashSet<string> _excludeProperties = new HashSet<string>()
        {
            "Item", "Count",
            "StartOffset", "FragmentLength", "StartLine", "StartColumn", "FirstTokenIndex", "LastTokenIndex",
        };
        private HashSet<(object, PropertyInfo)> _collected = new HashSet<(object, PropertyInfo)>();
        protected override bool AllowNavigate(object model, PropertyInfo property)
        {
            var check = base.AllowNavigate(model, property);
            if (!check) return false;
            if (_excludeProperties.Contains(property.Name)) return false;

            if (_collected.Contains((model, property)))
            {
                //TODO: external reference?
                //Debug.WriteLine($"Loop Detected: {(model, property)}");
                return false;
            }

            _collected.Add((model, property));
            return check;
        }

        protected override string? ValueSelector(object model) =>
            model switch
            {
                TSqlModel _ => null,
                TSqlObject sql => null,
                Identifier ident => ident.ToString(),
                Literal literal => literal.Value,
                Type type => type.ToString(),
                _ => base.ValueSelector(model)
            };

    }
}