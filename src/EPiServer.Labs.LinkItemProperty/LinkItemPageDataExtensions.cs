using EPiServer.Core;
using EPiServer.SpecializedProperties;

namespace EPiServer.Labs.LinkItemProperty
{
    public static class LinkItemPageDataExtensions
    {
        public static LinkItem GetLinkItemPropertyValue(this ContentData content, string propertyName)
        {
            return content[propertyName] is LinkItemCollection link && link.Count > 0 ? link[0] : null;
        }

        public static void SetLinkItemPropertyValue(this ContentData content, string propertyName, LinkItem value)
        {
            if (value is LinkItem)
            {
                content[propertyName] = new LinkItemCollection(new[] { value });
            }
        }
    }
}
