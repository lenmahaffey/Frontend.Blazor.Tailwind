using Blazor.Frontend.Bootstrap.Classes;
using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.Frontend.Bootstrap.Layout.Components
{
    public partial class LeftSideBar
    {
        [Inject] public IJSRuntime? Js { get; set; }
        [Inject] AppStateService? appStateService { get; set; }
        public List<NavLinkGroup> Links { get; set; } = new List<NavLinkGroup>();
        private IJSObjectReference? _js;

        protected override async Task OnInitializedAsync()
        {
            _js = await Js!.InvokeAsync<IJSObjectReference>("import", "./Layout/Components/LeftSideBar.razor.js");
            await _js.InvokeVoidAsync("listenForDropdowns", DotNetObjectReference.Create(this));
        }
        protected override void OnInitialized()
        {
            appStateService!.SideNavLinks += OnLinksReceived;
            base.OnInitialized();
        }

        public void OnLinksReceived(object? sender, List<NavLinkGroup> Links)
        {
            this.Links = Links ?? new List<NavLinkGroup>();
        }
    }
}
