﻿using Frontend.Blazor.Bootstrap.Classes;

namespace Frontend.Blazor.Bootstrap.Services
{
    public class AlertService
    {
        public EventHandler<Message>? MessageReceived;
        public EventHandler<Message>? AlertDeleted;

        public void SendAlert(Message message)
        {
            if (MessageReceived != null)
            {
                MessageReceived?.Invoke(this, message);
            }
            else
            {
                //**TODO** Throw Error
            }
        }

        public void DeleteAlert(Message message)
        {
            if (AlertDeleted != null)
            {
                AlertDeleted?.Invoke(this, message);
            }
            else
            {
                //**TODO** Throw Error
            }
        }
    }
}
