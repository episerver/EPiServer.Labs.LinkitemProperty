using System.Web.Mvc;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Framework.Modules.Internal;
using EPiServer.ServiceLocation;

namespace EPiServer.Labs.LinkItemProperty
{
    // PropertyRenderer class inside ExistDisplayTemplateWithName method,
    // checks if `partialViewName` exists inside DisplayTemplate folder. This can't be changed,
    // se we have to register custom ViewEngine, that will resolve "DisplayTemplates/SingleItem" path
    internal class LinkItemViewEngine : IViewEngine
    {
        public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            if (partialViewName != $"DisplayTemplates/{LinkItemRendering.Tag}")
            {
                return new ViewEngineResult(new string[0]);
            }

            if (ModuleResourceResolver.Instance.TryResolvePath(typeof(LinkItemViewEngine).Assembly,
                "Views/LinkItem.cshtml",
                out var resolvedPath))
            {
                return ViewEngines.Engines.FindPartialView(controllerContext, resolvedPath);
            }

            return new ViewEngineResult(new string[0]);
        }

        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            return new ViewEngineResult(new string[0]);
        }

        public void ReleaseView(ControllerContext controllerContext, IView view)
        {
        }
    }

    // we can't reuse `SingleItem` name, because then renderer would be reused also
    // for LinkItemCollection property since SingleItemCollectionEditorDescriptor
    // supports this backing type
    public static class LinkItemRendering
    {
        public const string Tag = "SingleLinkItemRenderer";
    }

    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class DisplayModesInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            if (ServiceLocator.Current.GetInstance<LinkItemPropertyOptions>().PropertyRendererEnabled)
            {
                ViewEngines.Engines.Add(new LinkItemViewEngine());
            }
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}
