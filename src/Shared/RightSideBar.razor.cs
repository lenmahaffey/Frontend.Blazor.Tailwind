using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.Frontend.Bootstrap.Shared
{
    public partial class RightSideBar
    {
        [Inject]
        public IJSRuntime? Js { get; set; }
        private IJSObjectReference? _js;
        protected override async Task OnInitializedAsync()
        {
            _js = await Js!.InvokeAsync<IJSObjectReference>("import", "./Shared/RightSideBar.razor.js");
        }

        async Task ToggleVisibility()
        {
            await _js!.InvokeVoidAsync("toggleSideNav");
        }
    }
}
