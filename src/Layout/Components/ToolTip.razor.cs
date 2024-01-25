using Blazor.Frontend.Bootstrap.Classes;
using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.Frontend.Bootstrap.Layout.Components
{
    public partial class ToolTip
    {
        [Inject] AppStateService? appStateService { get; set; }
        [Inject] public IJSRuntime? Js { get; set; }
        string Text { get; set; } = "Tooltip";
        private IJSObjectReference? _js;
        protected override async Task OnInitializedAsync()
        {
            _js = await Js!.InvokeAsync<IJSObjectReference>("import", "./Layout/Components/ToolTip.razor.js");
            appStateService!.ToolTipOptions += onToolTipTextReceived;
            await base.OnInitializedAsync();
        }

        void onToolTipTextReceived(object? sender, ToolTipOptions options)
        {
            //Console.WriteLine("Tooltip received options");
            Text = options.Text;
            StateHasChanged();
            _js!.InvokeVoidAsync("addMouseEvents", options.Element);
        }
    }
}
