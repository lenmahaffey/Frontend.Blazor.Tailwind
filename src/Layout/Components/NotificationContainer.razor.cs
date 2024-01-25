using Blazor.Frontend.Bootstrap.Classes;
using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;

namespace Blazor.Frontend.Bootstrap.Layout.Components
{
    public partial class NotificationContainer : IDisposable
    {
        [Inject] private NotificationService? notificationService { get; set; }
        [Parameter] public List<Message> Notifications { get; set; } = new List<Message>();

        protected override void OnInitialized()
        {
            notificationService!.MessageReceived += OnMessageReceived;
            notificationService!.NotificationDeleted += OnNotificationDeleted;
            base.OnInitialized();
        }

        public void OnMessageReceived(object? sender, Message m)
        {
            Notifications.Add(m);
            StateHasChanged();
        }

        public void OnNotificationDeleted(object? sender, Message message)
        {
            Notifications.Remove(message);
            StateHasChanged();
        }
        public void Dispose()
        {
            notificationService!.MessageReceived -= OnMessageReceived;
        }
    }
}
