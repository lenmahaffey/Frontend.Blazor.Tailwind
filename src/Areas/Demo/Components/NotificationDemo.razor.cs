using Frontend.Blazor.Tailwind.Classes;
using Frontend.Blazor.Tailwind.Services;
using Microsoft.AspNetCore.Components;

namespace Frontend.Blazor.Tailwind.Areas.Demo.Components
{
    public partial class NotificationDemo
    {
        [Inject] AppStateService? appStateService { get; set; }
        Message notificationMessage { get; set; } = new Message();
        ElementReference type { get; set; }
        ElementReference title { get; set; } 
        ElementReference text { get; set; }

        void sendNotification()
        {
            if (appStateService != null)
            {
                notificationMessage.Time = DateTime.Now;
                appStateService.SendNotification(notificationMessage);
                notificationMessage = new Message(); //Reset the input
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
