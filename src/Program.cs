using Frontend.Blazor.Tailwind;
using Frontend.Blazor.Tailwind.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<AlertService>();
builder.Services.AddScoped<AppStateService>();

await builder.Build().RunAsync();
