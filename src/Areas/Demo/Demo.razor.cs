using Frontend.Blazor.Tailwind.Classes;
using Frontend.Blazor.Tailwind.Services;
using Microsoft.AspNetCore.Components;

namespace Frontend.Blazor.Tailwind.Areas.Demo
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
