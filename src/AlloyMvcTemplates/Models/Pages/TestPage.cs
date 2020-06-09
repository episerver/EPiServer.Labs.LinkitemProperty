using System.ComponentModel;
using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.Labs.LinkItemProperty;
using EPiServer.SpecializedProperties;

namespace AlloyTemplates.Models.Pages
{
    [SiteContentType(GUID = "F4BB4392-E5B8-4CC7-BED6-3158836D5A24")]
    [SiteImageUrl(Global.StaticGraphicsFolderPath + "page-type-thumbnail-standard.png")]
    public class TestPage : SitePageData
    {
        [Display(Name="Link", GroupName = Global.GroupNames.SiteSettings)]
        [LinkItemProperty]
        [BackingType(typeof(PropertyLinkCollection))]
        public virtual LinkItem Link1
        {
            get => this.GetLinkItemPropertyValue(nameof(Link1));
            set => this.SetLinkItemPropertyValue(nameof(Link1), value);
        }

        [Display(Name = "Link", GroupName = Global.GroupNames.SiteSettings)]
        [LinkItemProperty]
        [BackingType(typeof(PropertyLinkCollection))]
        [ReadOnly(true)]
        public virtual LinkItem Link2
        {
            get => this.GetLinkItemPropertyValue(nameof(Link1));
            set => this.SetLinkItemPropertyValue(nameof(Link1), value);
        }


        [Display(Name = "Test ContentArea", GroupName = Global.GroupNames.SiteSettings, Order = 320)]
        [CultureSpecific]
        public virtual ContentArea TestContentArea { get; set; }
    }
}
