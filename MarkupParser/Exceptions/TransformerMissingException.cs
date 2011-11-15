using System;
using leBlog.MarkupParser.Tags;

namespace leBlog.MarkupParser.Exceptions
{
    public class TransformerMissingException : Exception
    {
        public TransformerMissingException()
        { }

        public TransformerMissingException(string tagName)
            : base(string.Format("Transformer for Tag {0} not in TransformerPool", tagName))
        { }
    }
}