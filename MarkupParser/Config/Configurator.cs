using System.Xml.Linq;
using leBlog.MarkupParser.Exceptions;
using leBlog.MarkupParser.Helper;
using leBlog.MarkupParser.Renderer;
using leBlog.MarkupParser.Tags;

namespace leBlog.MarkupParser.Config
{
    internal class Configurator
    {
        public TransformerPool TransformerPool { get; private set; }
        public TagPool TagPool { get; private set; }

        public Configurator()
        {
            _configFile = XDocument.Parse(ConfigResources.Transformers);
            parseConfig();
        }

        private readonly XDocument _configFile;

        private void parseConfig()
        {
            TransformerPool = new TransformerPool();
            TagPool = new TagPool();

            var rootNode = _configFile.Element("transformers");
            if (rootNode == null) throw new ConfigFileCorruptException("<transformers> node missing");

            foreach (var node in rootNode.Descendants())
            {
                var transformerParams = new TransformerParams(node);
                var transformer = createTransformer(transformerParams);
                var tag = transformer.Tag;
                TransformerPool.Add(transformer);
                TagPool.Add(tag);
            }
        }

        private static Transformer createTransformer(TransformerParams transformerParams)
        {
            var tag = new Tag(transformerParams.MarkupStart, transformerParams.MarkupEnd);
            switch(transformerParams.TagType)
            {
                case "transformer":
                    return new SimpleTransformer(tag, transformerParams.CssClass);
                case "imgTransformer":
                    return new ImageTransformer(tag, transformerParams.CssClass);
                default:
                    throw new ConfigFileCorruptException(string.Format("Tag type {0} unknown.",
                                                                       transformerParams.TagType));
            }
        }

        private struct TransformerParams
        {
            public readonly string TagType;
            public readonly string MarkupStart;
            public readonly string MarkupEnd;
            public readonly string CssClass;

            public TransformerParams(XElement node)
            {
                TagType = node.Name.LocalName;
                MarkupStart = node.GetAttributeValue("markupStart");
                MarkupEnd = node.GetAttributeValue("markupEnd");
                CssClass = node.GetAttributeValue("cssClass");
            }

            public new string ToString()
            {
                return string.Format(
                    "TransformerParams: TagType={0}, MarkupStart={1}, MarkupEnd={2}, CssClass={3}",
                    TagType, MarkupStart, MarkupEnd, CssClass);
            }
        }

        public override string ToString()
        {
            return "Configurator object.";
        }
    }
}
