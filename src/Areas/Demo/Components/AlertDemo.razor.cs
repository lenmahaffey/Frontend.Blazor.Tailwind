﻿using Frontend.Blazor.Tailwind.Classes;
using Frontend.Blazor.Tailwind.Services;
using Microsoft.AspNetCore.Components;

namespace Frontend.Blazor.Tailwind.Areas.Demo.Components
{
    public partial class AlertDemo
    {
        [Inject] AppStateService? appStateService { get; set; }
        public Message AlertMessage { get; set; } = new Message();
        ElementReference type { get; set; }
        ElementReference text { get; set; }
        ElementReference autoDismiss { get; set; }
        ElementReference time { get; set; }
        void sendAlert()
        {
            if (appStateService != null)
            {
                AlertMessage.Time = DateTime.Now;
                appStateService.SendAlert(AlertMessage);
                AlertMessage = new Message(); //Reset the input
            }
        }
        void openToolTip(ElementReference element, string text)
        {
            if (appStateService != null)
            {
                var options = new ToolTipOptions() { Element = element, Text = text };
                appStateService.ToolTipOptions?.Invoke(this, options);
            }
        }
    }
}
