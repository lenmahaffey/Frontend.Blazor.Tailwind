using Frontend.Blazor.Tailwind.Classes;
using Frontend.Blazor.Tailwind.Services;
using Microsoft.AspNetCore.Components;

namespace Frontend.Blazor.Tailwind.Layout.Components
{
    public partial class AlertContainer : IDisposable
    {
        [Inject] AlertService? alertService { get; set; }
        List<Message> alerts { get; set; } = new List<Message>();
        protected override void OnInitialized()
        {
            alertService!.MessageReceived += onAlertReceived;
            alertService!.AlertDeleted += onAlertDeleted;
            base.OnInitialized();
        }

        void onAlertReceived(object? sender, Message message)
        {
            alerts.Add(message);
            StateHasChanged();
        }

        void onAlertDeleted(object? sender, Message message)
        {
            alerts.Remove(message);
            StateHasChanged();
        }

        public void Dispose()
        {
            if (alertService != null)
            {
                alertService.MessageReceived -= onAlertReceived;
                alertService.AlertDeleted -= onAlertDeleted;
            }
        }
    }
}
