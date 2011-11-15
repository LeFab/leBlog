using System;

namespace leBlog.MarkupParser.Exceptions
{
    public class TransformerContentHandlingConflict : Exception
    {
        public TransformerContentHandlingConflict()
        { }

        public TransformerContentHandlingConflict(string message)
            : base(message)
        { }
    }
}