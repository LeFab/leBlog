using System;

namespace leBlog.MarkupParser.Exceptions
{
	public class MarkupTextEmptyException : Exception
	{
		public MarkupTextEmptyException()
		{ }

		public MarkupTextEmptyException(string message)
			: base(message)
		{ }
	}
}