using System.Collections.Generic;
using System.Linq;
using leBlog.MarkupParser.Exceptions;
using leBlog.MarkupParser.Tags;

namespace leBlog.MarkupParser.Renderer
{
    internal class TransformerPool
    {
        private readonly List<Transformer> _items = new List<Transformer>();

        public void Add(Transformer item)
        {
            _items.Add(item);
        }

        public Transformer GetByTag(Tag tag)
        {
            var translator = _items.FirstOrDefault(t => t.MatchesTag(tag));
            if (translator == null) throw new TransformerMissingException(tag.ToString());
            return translator;
        }

        public override string ToString()
        {
            return string.Format("TransformerPool containing {0} TransformerBases.", _items.Count);
        }
    }
}