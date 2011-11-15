using leBlog.MarkupParser.Tags;

namespace leBlog.MarkupParser.Renderer
{
    internal class SimpleTransformer : Transformer
    {
        public SimpleTransformer(Tag tag, string cssClass)
            : base(tag, cssClass)
        {
            HandlesContent = false;
        }

        public override void ApplyToHtmlFragment(HtmlFragment htmlFragment, string content)
        {
            htmlFragment.AddClass(CssClass);
        }

        public override string ToString()
        {
            return string.Format("SimpleTransformer {0}", Tag.ToString());
        }
    }
}