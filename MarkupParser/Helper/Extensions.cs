using System.Xml.Linq;

namespace leBlog.MarkupParser.Helper
{
    internal static class Extensions
    {
        public static string GetAttributeValue(this XElement node, string attributeName, string defaultValue = null)
        {
            var attribute = node.Attribute(attributeName);
            return attribute != null ? attribute.Value : defaultValue;
        }
    }
}