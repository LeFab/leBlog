using System.Text;

namespace leBlog.MarkupParser.Renderer
{
    internal class HtmlFragment
    {

        public string InnerText { get; set; }
        
        public string Attributes { get; set; }

        public string HtmlTag
        {
            get { return string.IsNullOrEmpty(_htmlTag) ? "span" : _htmlTag; }
            set { _htmlTag = value; }
        }

        public bool IsHtmlTagNameDefined
        {
            get { return string.IsNullOrEmpty(_htmlTag); }
        }

        public string Classes
        {
            get { return _classes.ToString(); }
        }

        public void AddClass(string className)
        {
            if (_classes.Length > 0)
            {
                _classes.Append(" ");
            }
            _classes.Append(className);
        }

        public string CreateHtml()
        {
            if (_classes.Length > 0 || !string.IsNullOrEmpty(Attributes))
            {
                return string.Format("<{0} {2}class=\"{1}\">{3}</{0}>",
                                     HtmlTag, _classes, Attributes, InnerText);
            }
            return InnerText;
        }

        private string _htmlTag;
        private readonly StringBuilder _classes = new StringBuilder();
        
        public override string ToString()
        {
            return "HtmlFragment: " + CreateHtml();
        }
    }
}