using Blazor.Frontend.Bootstrap.Classes;
using Microsoft.AspNetCore.Components;

namespace Blazor.Frontend.Bootstrap.Services
{
    public class AlertService
    {
        [Inject] private ILogger<AlertService> logger { get; set; }
        public EventHandler<Message>? MessageReceived;
        public EventHandler<Message>? AlertDeleted;
        public AlertService(ILogger<AlertService> logger)
        {
            this.logger = logger;
        }
        public void SendAlert(Message message)
        {
            MessageReceived?.Invoke(this, message);
        }

        public void DeleteAlert(Message message)
        {
            AlertDeleted?.Invoke(this, message);
        }
    }
}
