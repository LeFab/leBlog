using leBlog.MarkupParser.Exceptions;

namespace leBlog.MarkupParser.Tags
{
    internal class Tag
    {
        private readonly string _startTag;
        private readonly string _endTag;
        private readonly int _tagLength;

        public Tag(string startTag, string endTag)
        {
            if (endTag.Length != startTag.Length)
            {
                throw new TagsLengthNotMatchingException();
            }
            _startTag = startTag;
            _endTag = endTag;
            _tagLength = _startTag.Length;
        }

        public bool MatchesStartTag(string text)
        {
            return validAndStartsWith(text, _startTag);
        }

        public bool MatchesEndTag(string text)
        {
            return validAndStartsWith(text, _endTag);
        }

        public int Length { get { return _tagLength; } }

        private bool validAndStartsWith(string text, string tag)
        {
            var textExisting = string.IsNullOrEmpty(text);
            if (textExisting) return false;

            var textLongEnough = text.Length >= _tagLength;
            if (!textLongEnough) return false;

            var textMatching = tag.Equals(text.Substring(0, _tagLength));
            return textMatching;
        }

        public override string ToString()
        {
            return string.Format("{0}...{1}", _startTag, _endTag);
        }
    }
}
