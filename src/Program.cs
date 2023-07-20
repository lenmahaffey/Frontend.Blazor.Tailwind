using Blazor.Frontend;
using Blazor.Frontend.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddHttpClient<IMeetingPlannerApiService, MeetingPlannerApiService>(client =>
//    client.BaseAddress = new Uri("http://localhost:5001"));


builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<AlertService>();

await builder.Build().RunAsync();
