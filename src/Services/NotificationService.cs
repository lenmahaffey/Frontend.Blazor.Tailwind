using Frontend.Blazor.Tailwind.Classes;
using Microsoft.AspNetCore.Components;

namespace Frontend.Blazor.Tailwind.Services
{
    public class NotificationService
    {
        public EventHandler<Message>? MessageReceived;
        public EventHandler<Message>? NotificationDeleted;
        public void SendNotification(Message message)
        {
            if (MessageReceived != null)
            {
                MessageReceived.Invoke(this, message);
            }
            else
            {
                //**TODO** Throw Error
            }
        }

        public void DeleteNotification(Message message)
        {
            if (NotificationDeleted != null)
            {
                NotificationDeleted.Invoke(this, message);
            }
            else
            {
                //**TODO** Throw Error
            }
        }
    }
}
