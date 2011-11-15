using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using leBlog.MarkupParser.Tags;

namespace leBlog.MarkupParser.Content
{
    internal class Fragment
    {
        public string Text { get; set; }

        public IEnumerable<Tag> Tags { get { return _tags; } }
        
        public void AddTag(Tag tag)
        {
            _tags.Add(tag);
        }

        public void AddTags(IEnumerable<Tag> tags)
        {
            _tags.AddRange(tags);
        }

        private readonly List<Tag> _tags = new List<Tag>();
        
        public override string ToString()
        {
            var description = new StringBuilder(Text);

            foreach (var tag in _tags)
            {
                description.Append(" ").Append(tag);
            }

            return description.ToString();
        }
    }
}
