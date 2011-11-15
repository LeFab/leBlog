using System;

namespace leBlog.MarkupParser.Exceptions
{
    public class TagsLengthNotMatchingException : Exception
    {
        public TagsLengthNotMatchingException()
        { }

        public TagsLengthNotMatchingException(string startTag, string endTag)
            : base(string.Format("Start tag: {0}, end tag: {1}", startTag, endTag))
        { }
    }
}