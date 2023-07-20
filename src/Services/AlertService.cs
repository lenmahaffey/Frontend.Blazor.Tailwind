using Blazor.Frontend.Classes;

namespace Blazor.Frontend.Services
{
    public class AlertService
    {
        public EventHandler<Message>? AlertReceived;

        public void SendMessage(Message message)
        {
            OnAlertReceived(message);
        }

        protected virtual void OnAlertReceived(Message message)
        {
            AlertReceived?.Invoke(this, message);
        }
    }
}
