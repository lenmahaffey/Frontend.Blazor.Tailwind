using Blazor.Frontend.Bootstrap.Classes;
using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.Frontend.Bootstrap.Layout.Components
{
    public partial class NavBar
    {
        [Inject] public IJSRuntime? Js { get; set; }
        [Inject] AppStateService? appStateService { get; set; }
        public List<NavLinkGroup> Links { get; set; } = TopNavLinks.Links;

        private IJSObjectReference? _js;

        protected override async Task OnInitializedAsync()
        {
            _js = await Js!.InvokeAsync<IJSObjectReference>("import", "./Layout/Components/NavBar.razor.js");
        }
    }
}
