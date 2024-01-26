using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Blazor.Frontend.Bootstrap
{
    public static class HostingEnvironmentExtensions
    {
        public const string QAEnvironment = "QA";

        public static bool IsQA(this IWebAssemblyHostEnvironment hostingEnvironment)
        {
            return hostingEnvironment.IsEnvironment(QAEnvironment);
        }
    }
}
