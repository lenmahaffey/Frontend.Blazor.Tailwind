using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

namespace Blazor.Frontend.Bootstrap.Layout
{
    public partial class MainLayout
    {
        [Inject] IWebAssemblyHostEnvironment? Env { get; set; }
        [Inject] public IJSRuntime? Js { get; set; }
        private IJSObjectReference? _js;
        string borderClassName
        {
            get
            {
                switch(Env?.Environment)
                {
                    case "Development":
                        return "dev";
                    case "QA":
                        return "qa";
                    case "Stageing":
                        return "stage";
                    default:
                        return "";
                }
            }
        }

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
            Console.WriteLine(Env?.Environment);
        }
    }
}
