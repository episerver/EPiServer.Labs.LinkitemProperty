using EPiServer.ServiceLocation;

namespace EPiServer.Labs.LinkItemProperty
{
    [Options]
    public class LinkItemPropertyOptions
    {
        /// <summary>
        /// When true then property renderer used to render link is enabled
        /// </summary>
        public bool PropertyRendererEnabled { get; set; } = true;
    }
}
