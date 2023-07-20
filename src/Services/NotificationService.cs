using Blazor.Frontend.Classes;

namespace Blazor.Frontend.Services
{
    public class NotificationService
    {
        public EventHandler<Message>? MessageReceived;

        public void SendMessage(Message message)
        {
            OnMessageReceived(message);
        }

        protected virtual void OnMessageReceived(Message message)
        {
            MessageReceived?.Invoke(this, message);
        }
    }
}
