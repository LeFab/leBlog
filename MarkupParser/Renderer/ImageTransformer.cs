using leBlog.MarkupParser.Tags;

namespace leBlog.MarkupParser.Renderer
{
    internal class ImageTransformer : Transformer
    {
        public ImageTransformer(Tag tag, string cssClass)
            : base(tag, cssClass)
        {
            HandlesContent = true;
        }

        public override void ApplyToHtmlFragment(HtmlFragment htmlFragment, string content)
        {
            if (!htmlFragment.IsHtmlTagNameDefined)
            {
                htmlFragment.AddClass(CssClass);
                htmlFragment.HtmlTag = "img";
                htmlFragment.Attributes += string.Format(" src=\"{0}\" ", content);
            }
            else
            {
                htmlFragment.InnerText += string.Format("<img src=\"{0}\" class=\"{1}\" />",
                                                        content, CssClass);
            }
        }

        public override string ToString()
        {
            return string.Format("ImageTransformer {0}", Tag.ToString());
        }
    }
}