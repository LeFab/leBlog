using System;

namespace leBlog.MarkupParser.Exceptions
{
    public class TagMissingException : Exception
    {
        public TagMissingException()
        { }

        public TagMissingException(string message)
            : base(message)
        { }
    }
}