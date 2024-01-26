﻿using Blazor.Frontend.Bootstrap.Classes;
using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;

namespace Blazor.Frontend.Bootstrap.Areas.Demo.Components
{
    public partial class NotificationDemo
    {
        [Inject] AppStateService? appStateService { get; set; }
        public Message NotificationMessage { get; set; } = new Message();
        ElementReference Type { get; set; }
        ElementReference Title { get; set; } 
        ElementReference Text { get; set; }


        public void SendNotification()
        {
            if (appStateService != null)
            {
                NotificationMessage.Time = DateTime.Now;
                appStateService.SendNotification(NotificationMessage);
                NotificationMessage = new Message(); //Reset the input
            }
        }
        void openToolTip(ElementReference element, string text)
        {
            if (appStateService != null)
            {
                var options = new ToolTipOptions() { Element = element, Text = text };
                appStateService.OpenToolTip(options);
            }
        }
    }
}