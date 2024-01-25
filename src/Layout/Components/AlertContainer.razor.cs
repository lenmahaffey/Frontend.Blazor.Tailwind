using Blazor.Frontend.Bootstrap.Classes;
using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;

namespace Blazor.Frontend.Bootstrap.Layout.Components
{
    public partial class AlertContainer : IDisposable
    {
        [Inject] AlertService? alertService { get; set; }
        public List<Message> Alerts { get; set; } = new List<Message>();
        protected override void OnInitialized()
        {
            alertService!.MessageReceived += OnAlertReceived;
            alertService!.AlertDeleted += OnAlertDeleted;
            base.OnInitialized();
        }

        public void OnAlertReceived(object? sender, Message message)
        {
            Alerts.Add(message);
            StateHasChanged();
        }

        public void OnAlertDeleted(object? sender, Message message)
        {
            Alerts.Remove(message);
            StateHasChanged();
        }

        public void Dispose()
        {
            alertService!.MessageReceived -= OnAlertReceived;
        }
    }
}
