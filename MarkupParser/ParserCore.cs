using System.Collections.Generic;
using System.Text;
using leBlog.MarkupParser.Content;
using leBlog.MarkupParser.Exceptions;
using leBlog.MarkupParser.Tags;

namespace leBlog.MarkupParser
{
    internal class ParserCore
    {

        public ParserCore(TagPool tagPool)
        {
            _tagPool = tagPool;
        }

        public Document CreateDocument(string markupText)
        {
            if (string.IsNullOrEmpty(markupText)) throw new MarkupTextEmptyException();

            _activeTags = new HashSet<Tag>();
            _fragmentContent = new StringBuilder();
            _document = new Document();

            parse(markupText);

            return _document;
        }

        private readonly TagPool _tagPool;
        private HashSet<Tag> _activeTags;
        private StringBuilder _fragmentContent;
        private Document _document;

        private void parse(string markupText)
        {
            var index = 0;
            var markupTextLength = markupText.Length;

            while (index < markupTextLength)
            {
                var currentText = markupText.Substring(index);

                if (_tagPool.IsMatchingTag(currentText))
                {
                    appendNewFragment();
                    var tag = updateActiveTags(currentText);
                    index += tag.Length;
                }
                else
                {
                    _fragmentContent.Append(currentText.Substring(0, 1));
                    index++;
                }
            }
            appendNewFragment();
        }

        private Tag updateActiveTags(string text)
        {
            Tag tag;
            if ((tag = _tagPool.GetMatchingStartTag(text)) != null)
            {
                _activeTags.Add(tag);
            }
            else
            {
                tag = _tagPool.GetMatchingEndTag(text);
                _activeTags.Remove(tag);
            }
            return tag;
        }

        private void appendNewFragment()
        {
            if (_fragmentContent.Length == 0) return;

            var fragment = new Fragment { Text = _fragmentContent.ToString() };
            fragment.AddTags(_activeTags);
            _document.Append(fragment);
            _fragmentContent.Clear();
        }

        public override string ToString()
        {
            return "ParserCore";
        }
    }
}
