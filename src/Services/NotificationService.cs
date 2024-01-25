using Blazor.Frontend.Bootstrap.Classes;
using Microsoft.AspNetCore.Components;

namespace Blazor.Frontend.Bootstrap.Services
{
    public class NotificationService
    {
        [Inject] private ILogger<NotificationService> logger { get; set; }
        public EventHandler<Message>? MessageReceived;
        public EventHandler<Message>? NotificationDeleted;
        public NotificationService(ILogger<NotificationService> logger)
        {
            this.logger = logger;
        }
        public void SendNotification(Message message)
        {
            MessageReceived?.Invoke(this, message);
        }

        public void DeleteNotification(Message message)
        {
            NotificationDeleted?.Invoke(this, message);
        }
    }
}
