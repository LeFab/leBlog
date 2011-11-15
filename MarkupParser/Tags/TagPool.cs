using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace leBlog.MarkupParser.Tags
{
    internal class TagPool : IEnumerable<Tag>
    {
        private readonly List<Tag> _items = new List<Tag>();

        public void Add(Tag item)
        {
            _items.Add(item);
        }

        public bool IsMatchingTag(string text)
        {
            return this.Any(t => t.MatchesStartTag(text)) || this.Any(t => t.MatchesEndTag(text));
        }

        public Tag GetMatchingStartTag(string text)
        {
            return this.FirstOrDefault(t=>t.MatchesStartTag(text));
        }

        #region IEnumerable

        public Tag GetMatchingEndTag(string text)
        {
            return this.FirstOrDefault(t => t.MatchesEndTag(text));
        }

        public IEnumerator<Tag> GetEnumerator()
        {
            return _items.GetEnumerator();
        }
        
        #endregion

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
