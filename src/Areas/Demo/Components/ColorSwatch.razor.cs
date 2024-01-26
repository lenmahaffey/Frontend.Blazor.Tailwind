using Blazor.Frontend.Bootstrap.Classes;
using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.Frontend.Bootstrap.Areas.Demo.Components
{
    public partial class ColorSwatch
    {
        [Inject] AppStateService? appStateService { get; set; }
        [Inject] public IJSRuntime? jsRuntime { get; set; }
        [Parameter] public string Name { get; set; } = string.Empty;
        string id { get; } = Guid.NewGuid().ToString("N");
        string? rgbString { get; set; } = string.Empty;
        string? hexString { get; set; } = string.Empty;
        IJSObjectReference? js { get; set; }
        ElementReference element { get; set; }
        protected override async Task OnInitializedAsync()
        {
            js = await jsRuntime!.InvokeAsync<IJSObjectReference>("import", "./Areas/Demo/Components/ColorSwatch.razor.js");
            rgbString = await GetRGBColorValueString(id);
            hexString = await GetHexColorValueString(id);
        }
        public async Task<string> GetRGBColorValueString(string id)
        {
            if (js != null)
            {
                var result = await js.InvokeAsync<string>("getRGBColorValue", id, DotNetObjectReference.Create(this));
                return result;
            }
            return string.Empty;
        }

        public async Task<string> GetHexColorValueString(string id)
        {
            if (js != null)
            {
                var result = await js.InvokeAsync<string>("getHexColorValue", id, DotNetObjectReference.Create(this));
                return result;
            }
            return string.Empty;
        }

        void OpenToolTip(string text)
        {
            if (appStateService != null)
            {
                var options = new ToolTipOptions() { Element = element, Text = text };
                appStateService.ToolTipOptions?.Invoke(this, options);
            }
        }
    }
}
