﻿using Frontend.Blazor.Tailwind.Classes;
using Frontend.Blazor.Tailwind.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Frontend.Blazor.Tailwind.Layout.Components
{
    public partial class ToolTip : IDisposable
    {
        [Inject] AppStateService? appStateService { get; set; }
        [Inject] IJSRuntime? jsRuntime { get; set; }
        string text { get; set; } = "Tooltip";
        IJSObjectReference? js { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            js = await jsRuntime!.InvokeAsync<IJSObjectReference>("import", "./Layout/Components/ToolTip.razor.js");
            if (appStateService != null)
            {
                appStateService.ToolTipOptions += onToolTipTextReceived;
            }
        }

        void onToolTipTextReceived(object? sender, ToolTipOptions options)
        {
            text = options.Text;
            StateHasChanged();
            js!.InvokeVoidAsync("addMouseEvents", options.Element);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
