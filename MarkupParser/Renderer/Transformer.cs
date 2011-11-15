using leBlog.MarkupParser.Tags;

namespace leBlog.MarkupParser.Renderer
{
    internal abstract class Transformer
    {
        protected readonly string CssClass;

        protected Transformer(Tag tag, string cssClass)
        {
            Tag = tag;
            CssClass = cssClass;
            HandlesContent = false;
        }

        public abstract void ApplyToHtmlFragment(HtmlFragment htmlFragment, string content);

        public bool MatchesTag(Tag tag)
        {
            return tag == Tag;
        }

        public Tag Tag { get; private set; }

        public bool HandlesContent { get; protected set; }
    }
}