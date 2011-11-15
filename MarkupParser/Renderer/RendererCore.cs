using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using leBlog.MarkupParser.Content;
using leBlog.MarkupParser.Exceptions;
using leBlog.MarkupParser.Properties;

namespace leBlog.MarkupParser.Renderer
{
    internal class RendererCore
    {
        public RendererCore(TransformerPool transformerPool)
        {
            _transformerPool = transformerPool;
        }

        public string CreateHtml(Document document)
        {
            _document = document;
            var htmlText = new StringBuilder();

            foreach (var htmlFragment in _document.Select(createHtmlFragment))
            {
                htmlText.Append(htmlFragment.CreateHtml());
            }
            return replaceLineBreaks(htmlText.ToString());
        }

        private readonly TransformerPool _transformerPool;
        private Document _document;

        private HtmlFragment createHtmlFragment(Fragment fragment)
        {
            var htmlFragment = new HtmlFragment();

            var transformers = from tag in fragment.Tags
                               select _transformerPool.GetByTag(tag);

            var contentHandlingType = applyTransformers(transformers, fragment.Text, htmlFragment);
            if (contentHandlingType == ContentHandlingType.Automatic)
            {
                htmlFragment.InnerText = fragment.Text;
            }
            return htmlFragment;
        }

        private string replaceLineBreaks(string text)
        {
            return text.Replace(Environment.NewLine, Settings.Default.LineBreak);
        }

        private ContentHandlingType applyTransformers(IEnumerable<Transformer> transformers,
            string fragmentText, HtmlFragment htmlFragment)
        {
            var contentHandlingType = ContentHandlingType.Automatic;

            foreach (var transformer in transformers)
            {
                transformer.ApplyToHtmlFragment(htmlFragment, fragmentText);
                if (transformer.HandlesContent)
                {
                    if (contentHandlingType == ContentHandlingType.Transformer)
                    {
                        throw new TransformerContentHandlingConflict(transformer.ToString());
                    }
                    contentHandlingType = ContentHandlingType.Transformer;
                }
            }
            return contentHandlingType;
        }

        private enum ContentHandlingType
        {
            Automatic,
            Transformer
        }

        public override string ToString()
        {
            return "RendererCore";
        }
    }
}