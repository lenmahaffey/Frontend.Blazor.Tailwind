using Blazor.Frontend.Bootstrap.Classes;
using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;

namespace Blazor.Frontend.Bootstrap.Areas.Demo
{
    public partial class Demo
    {
        [Inject] AppStateService? appStateService { get; set; }
        List<NavLinkGroup> navLinks { get; set; } = DemoSideNavLinks.Links;
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            setNavLinks();
        }

        void setNavLinks()
        {
            if (appStateService != null)
            {
                appStateService.SideNavLinks?.Invoke(this, navLinks);
            }
        }
    }
}
