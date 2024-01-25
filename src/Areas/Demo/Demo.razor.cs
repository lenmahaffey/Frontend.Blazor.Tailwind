using Blazor.Frontend.Bootstrap.Classes;
using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;

namespace Blazor.Frontend.Bootstrap.Areas.Demo
{
    public partial class Demo
    {
        [Inject] ILogger<Demo>? logger { get; set; }
        [Inject] AppStateService? appStateService { get; set; }
        public List<NavLinkGroup> NavLinks { get; set; } = DemoSideNavLinks.Links;
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            SetNavLinks();
        }

        public void SetNavLinks()
        {
            if (appStateService != null)
            {
                appStateService.SetSideNavLinks(NavLinks);
            }
        }
    }
}
