using Blazor.Frontend.Bootstrap.Classes;
using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;

namespace Blazor.Frontend.Bootstrap.Shared
{
    public partial class AlertContainer
    {
        [Inject] AlertService? alertService { get; set; }
        public List<Message> Alerts { get; set; } = new List<Message>();
        protected override void OnInitialized()
        {
            alertService!.AlertReceived += OnAlertReceived;
            base.OnInitialized();
        }

        public void OnAlertReceived(object? sender, Message message)
        {
            var oldAlerts = Alerts.Where(x => x.IsDismissed == true).ToList();
            Alerts = Alerts.Except(oldAlerts).ToList();
            Alerts.Add(new Message(message));
            StateHasChanged();
        }

        public void Dispose()
        {
            alertService!.AlertReceived -= OnAlertReceived;
        }
    }
}
