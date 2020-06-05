To LinkItemCollection with one item:

[ContentType(GUID = "19671657-B684-4D95-A61F-8DD4FE60D559"]
public class StartPage : PageData
{
    [LinkItemProperty]
    public virtual LinkItemCollection IntranetLink { get; set; }
}


To use LinkItem in your model:

[ContentType(GUID = "19671657-B684-4D95-A61F-8DD4FE60D559"]
public class StartPage : PageData
{
    [LinkItemProperty]
    [BackingType(typeof(PropertyLinkCollection))]
    public virtual LinkItem Link
    {
        get => this.GetLinkItemPropertyValue(nameof(Link));
        set => this.SetLinkItemPropertyValue(nameof(Link), value);
    }
}


To render property on page (works only for LinkItem as model):

@Html.PropertyFor(x => x.CurrentPage.Link, new { Tag = EPiServer.Labs.LinkItemProperty.LinkItemRendering.Tag })