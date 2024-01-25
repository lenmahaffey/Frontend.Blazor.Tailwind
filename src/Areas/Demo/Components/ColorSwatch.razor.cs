using Blazor.Frontend.Bootstrap.Classes;
using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.Frontend.Bootstrap.Areas.Demo.Components
{
    public partial class ColorSwatch
    {
        [Inject] AppStateService? appStateService { get; set; }
        [Inject] public IJSRuntime? Js { get; set; }
        private IJSObjectReference? _js;
        private string Id { get; } = Guid.NewGuid().ToString("N");
        private string borderColor
        {
            get
            {
                if (Name == string.Empty)
                {
                    return "";
                }
                else
                {
                    return $"borderColor";
                }
            }
        }
        [Parameter] public string Name { get; set; } = string.Empty;
        private string? rgbString { get; set; } = string.Empty;
        private string? hexString { get; set; } = string.Empty;
        ElementReference element { get; set; }
        protected override async Task OnInitializedAsync()
        {
            _js = await Js!.InvokeAsync<IJSObjectReference>("import", "./Areas/Demo/Components/ColorSwatch.razor.js");
            rgbString = await GetRGBColorValueString(Id);
            hexString = await GetHexColorValueString(Id);
        }
        public async Task<string> GetRGBColorValueString(string id)
        {
            if (_js != null)
            {
                var result = await _js.InvokeAsync<string>("getRGBColorValue", id, DotNetObjectReference.Create(this));
                return result;
            }
            return "JS NULL";
        }

        public async Task<string> GetHexColorValueString(string id)
        {
            if (_js != null)
            {
                var result = await _js.InvokeAsync<string>("getHexColorValue", id, DotNetObjectReference.Create(this));
                return result;
            }
            return "JS NULL";
        }

        void OpenToolTip(string text)
        {
            if (appStateService != null)
            {
                var options = new ToolTipOptions() { Element = element, Text = text };
                appStateService.OpenToolTip(options);
            }
        }
    }
}
