using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

namespace Blazor.Frontend.Bootstrap.Layout
{
    public partial class MainLayout
    {
        [Inject] IWebAssemblyHostEnvironment? Env { get; set; }
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

        string borderName
        {
            get
            {
                switch (Env?.Environment)
                {
                    case "Development":
                        return "Development";
                    case "QA":
                        return "QA";
                    case "Stageing":
                        return "Stageing";
                    default:
                        return "";
                }
            }
        }
    }
}
