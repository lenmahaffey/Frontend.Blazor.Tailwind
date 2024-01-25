using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;

namespace Blazor.Frontend.Bootstrap.Layout.Components
{
    public partial class RightSideBar
    {
        [Inject] AppStateService? appStateService { get; set; }
        public RenderFragment? Content { get; set; }
        bool isActive { get; set; } = false;
        protected override void OnInitialized()
        {
            if (appStateService != null)
            {
                appStateService.RightSideBarContent += onContentReceived;
            }
            base.OnInitialized();
        }

        private void onContentReceived(object? sender, RenderFragment fragment)
        {
            Content = fragment;
        }

        void ToggleVisibility()
        {
            isActive = !isActive;
        }
    }
}
