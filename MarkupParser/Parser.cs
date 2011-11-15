using leBlog.MarkupParser.Renderer;

namespace leBlog.MarkupParser
{
    public class Parser
    {
        private readonly Config.Configurator _configurator = new Config.Configurator();

        public string CreateHtml(string markup)
        {
            var parserCore = new ParserCore(_configurator.TagPool);
            var rendererCore = new RendererCore(_configurator.TransformerPool);

            var document = parserCore.CreateDocument(markup);
            var html = rendererCore.CreateHtml(document);

            return html;
        }

        public override string ToString()
        {
            return "Parser";
        }
    }
}
