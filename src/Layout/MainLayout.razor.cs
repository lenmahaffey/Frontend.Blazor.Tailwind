using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.Frontend.Bootstrap.Layout
{
    public partial class MainLayout
    {
        [Inject] public IJSRuntime? Js { get; set; }
        private IJSObjectReference? _js;

        protected async override Task OnInitializedAsync()
        {
            if (Js != null)
            {
                _js = await Js.InvokeAsync<IJSObjectReference>("import", "./Layout/MainLayout.razor.js");
            }
            await base.OnInitializedAsync();
        }
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }
    }
}
