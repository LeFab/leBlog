using System;

namespace leBlog.MarkupParser.Exceptions
{
    public class ConfigFileCorruptException : Exception
    {
        public ConfigFileCorruptException()
        { }

        public ConfigFileCorruptException(string message)
            : base(message)
        { }
    }
}