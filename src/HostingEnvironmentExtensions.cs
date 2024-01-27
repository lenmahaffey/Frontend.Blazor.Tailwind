using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Frontend.Blazor.Bootstrap
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
