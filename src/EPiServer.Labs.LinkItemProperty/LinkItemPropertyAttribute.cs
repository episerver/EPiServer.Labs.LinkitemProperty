using System.ComponentModel.DataAnnotations;

namespace EPiServer.Labs.LinkItemProperty
{
    public class LinkItemPropertyAttribute: UIHintAttribute
    {
        public LinkItemPropertyAttribute() : base("SingleItem")
        {
        }
    }
}
