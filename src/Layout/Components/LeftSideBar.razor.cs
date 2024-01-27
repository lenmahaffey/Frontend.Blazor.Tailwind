using Frontend.Blazor.Bootstrap.Classes;
using Frontend.Blazor.Bootstrap.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Frontend.Blazor.Bootstrap.Layout.Components
{
    public partial class LeftSideBar : IDisposable
    {
        [Inject] IJSRuntime? jsRuntime { get; set; }
        [Inject] AppStateService? appStateService { get; set; }
        List<NavLinkGroup> links { get; set; } = new List<NavLinkGroup>();
        IJSObjectReference? js { get; set; }

        protected override async Task OnInitializedAsync()
        {
            js = await jsRuntime!.InvokeAsync<IJSObjectReference>("import", "./Layout/Components/LeftSideBar.razor.js");
            await js.InvokeVoidAsync("listenForDropdowns", DotNetObjectReference.Create(this));
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (appStateService != null)
            {
                appStateService.SideNavLinks += onLinksReceived;
            }
        }

        void onLinksReceived(object? sender, List<NavLinkGroup> Links)
        {
            this.links = Links ?? new List<NavLinkGroup>();
        }

        public void Dispose()
        {
            if (appStateService != null)
            {
                appStateService.SideNavLinks += onLinksReceived;
            }
        }
    }
}
