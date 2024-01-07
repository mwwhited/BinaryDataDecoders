using BinaryDataDecoders.Templating.Abstractions;
using HtmlAgilityPack;
using System.Threading.Tasks;

namespace BinaryDataDecoders.Templating.Html;

public interface IHtmlDocumentVistor
{
    Task<HtmlNode> VisitAsync(HtmlNode node, IPathResolver root, IPathResolver current, (string scope, IPathResolver data)[] scoped);
}

/*
    public class GenerateText : IGenerateText
    {
        private const string UNWRAP = "__unwrap__";

        private readonly IObjectSerializer _serializer;
        private readonly ILogger<GenerateText> _log;

        public GenerateText(
            IObjectSerializer serializer,
            ILogger<GenerateText> log
            )
        {
            _serializer = serializer;
            _log = log;
        }

        // https://stackoverflow.com/questions/41446280/how-to-remove-image-as-attachment-but-show-in-body-of-email?noredirect=1&lq=1
        // https://stackoverflow.com/questions/32767314/how-to-use-razor-engine-for-email-templating-with-image-src/32767496#32767496
        // https://github.com/zzzprojects/html-agility-pack
        // https://goessner.net/articles/JsonPath/
        // https://www.newtonsoft.com/json/help/html/SelectToken.htm#SelectTokenJSONPath

        public async Task<string> GenerateAsync<TModel>(string template, TModel model)
        {
            if (string.IsNullOrWhiteSpace(template))
            {
                _log.LogWarning($@"No template provided for model ""{model.GetType()}""");
                return null;
            }

            var html = new HtmlDocument();
            html.LoadHtml(template);


            if (!(model is JToken json))
            {
                if (!(model is string data))
                {
                    data = await _serializer.GetAsSerializedAsync(model);
                }
                json = JToken.Parse(data);
            }

            // https://stackoverflow.com/questions/14348567/json-net-how-to-use-jsonpath-with
            // https://goessner.net/articles/JsonPath/
            //json.SelectToken()

            var result = Visit(html.DocumentNode, json, new List<Scoped>()); //, Enumerable.Empty<(string, JToken)>());

            return result.WriteTo();
        }

        private class Scoped
        {
            public string Key { get; set; }
            public JToken Value { get; set; }
        }

        private IEnumerable<JToken> SelectToken(JToken token, string path)
        {
            if (token == null)
            {
                return null;
            }
            if (string.IsNullOrWhiteSpace(path))
            {
                return token;
            }

            var firstChar = path?.ElementAtOrDefault(0);
            var source = firstChar == '$' ? token.Root : token;
            if (firstChar == '@')
            {
                path = "$" + (path.Length == 1 ? "" : path.Substring(1));
            }
            return source.SelectTokens(path).ToArray();
        }

        private HtmlNode Visit(HtmlNode node, JToken source, IList<Scoped> scopes)
        {
            var replacements = new List<(HtmlNode, HtmlNode)>();
            foreach (var child in node.ChildNodes)
            {
                var itemKey = child.Attributes["item"]?.Value;
                var sourceKey = child.Attributes["source"]?.Value;
                var bindingPath = child.Attributes["binding"]?.Value;
                var dataBindingPath = child.Attributes["data-binding"];

                var element = scopes.LastOrDefault(s => s.Key == sourceKey)?.Value ?? source;
                var data = SelectToken(element, bindingPath);
                var target = data.FirstOrDefault();
                var scope = string.IsNullOrWhiteSpace(itemKey) ? null : new Scoped() { Key = itemKey, Value = target, };
                if (scope != null)
                    scopes.Add(scope);

                //_log.LogDebug($"{node.Name} => ({itemKey}, {sourceKey}, {bindingPath}) {source}");
                try
                {
                    if (child.Name == "value-of")
                    {
                        var format = child.Attributes["format"]?.Value;
                        var input = target?.ToString() ?? "";
                        var value = GetValue(input,  format);

                        replacements.Add((HtmlNode.CreateNode(value), child));
                        continue;
                    }
                    else if (child.Name == "repeater")
                    {
                        var newNode = child.OwnerDocument.CreateElement("div");
                        newNode.Attributes.Add("class", UNWRAP);
                        if (data != null)
                        {
                            var set = data.Count() == 1 && target.Type == JTokenType.Array ? target.Children() : data;
                            foreach (var item in set)
                            {
                                var innerTemplate = child.CloneNode(true);
                                var innerScope = string.IsNullOrWhiteSpace(itemKey) ? null : new Scoped() { Key = itemKey, Value = item, };
                                if (innerScope != null)
                                    scopes.Add(innerScope);
                                try
                                {
                                    var innerChildren = Visit(innerTemplate, item, scopes);
                                    newNode.AppendChildren(innerChildren.ChildNodes);
                                }
                                finally
                                {
                                    if (innerScope != null)
                                        scopes.Remove(innerScope);
                                }
                            }
                        }

                        replacements.Add((newNode, child));
                        continue;
                    }
                    else if (child.Name == "value-attr")
                    {
                        child.ParentNode.SetAttributeValue(itemKey, target?.ToString() ?? "");
                        replacements.Add((HtmlNode.CreateNode(""), child));
                        continue;
                    }
                    else if (child.Name == "condition")
                    {
                        var rule = child.Attributes["rule"]?.Value;
                        if (!string.IsNullOrWhiteSpace(rule))
                        {
                            var check = element.DeepClone().SelectTokens($"$..[?({rule})]").Any();
                            if (check)
                            {
                                var item = element;
                                var newNode = child.OwnerDocument.CreateElement("div");
                                newNode.Attributes.Add("class", UNWRAP);

                                var innerTemplate = child.CloneNode(true);
                                _log.LogDebug($"{itemKey} => {item}");
                                var innerScope = string.IsNullOrWhiteSpace(itemKey) ? null : new Scoped() { Key = itemKey, Value = item, };
                                if (innerScope != null)
                                    scopes.Add(innerScope);
                                try
                                {
                                    var innerChildren = Visit(innerTemplate, item, scopes);
                                    newNode.AppendChildren(innerChildren.ChildNodes);
                                }
                                finally
                                {
                                    if (innerScope != null)
                                        scopes.Remove(innerScope);
                                }

                                replacements.Add((newNode, child));
                                continue;
                            }
                            else
                            {
                                replacements.Add((null, child));
                            }
                        }
                    }
                    else if (dataBindingPath != null)
                    {
                        var value = string.Join(Environment.NewLine, SelectToken(element, dataBindingPath.Value)?.Select(s => s.ToString()) ?? Enumerable.Empty<string>());
                        child.Attributes.Remove(dataBindingPath);
                        child.InnerHtml = value;
                    }
                    var visited = Visit(child, element, scopes);
                }
                finally
                {
                    if (scope != null)
                        scopes.Remove(scope);
                }
            }
            foreach (var item in replacements)
            {
                if (item.Item1 == null)
                {

                    item.Item2.Remove();
                }
                else if (item.Item1.Attributes["class"]?.Value == UNWRAP)
                {
                    foreach (var ch in item.Item1.ChildNodes)
                    {
                        node.InsertBefore(ch, item.Item2);
                    }
                    item.Item2.Remove();
                }
                else
                {
                    node.ReplaceChild(item.Item1, item.Item2);
                }
            }
            return node;
        }

        private string GetValue(string input, string format) =>
            !DateTimeOffset.TryParse(input, out var date) ?
                input :
                string.IsNullOrWhiteSpace(format) ?
                    date.ToString() :
                    date.ToString(format);

    }
*/