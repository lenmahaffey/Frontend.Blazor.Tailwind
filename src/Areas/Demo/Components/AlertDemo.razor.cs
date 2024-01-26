using Blazor.Frontend.Bootstrap.Classes;
using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;

namespace Blazor.Frontend.Bootstrap.Areas.Demo.Components
{
    public partial class AlertDemo
    {
        [Inject] AppStateService? appStateService { get; set; }
        public Message AlertMessage { get; set; } = new Message();
        ElementReference Type { get; set; }
        ElementReference Text { get; set; }
        ElementReference AutoDismiss { get; set; }
        ElementReference Time { get; set; }
        public void SendAlert()
        {
            if (appStateService != null)
            {
                AlertMessage.Time = DateTime.Now;
                appStateService.SendAlert(AlertMessage);
                AlertMessage = new Message(); //Reset the input
            }
        }
        void OpenToolTip(ElementReference element, string text)
        {
            if (appStateService != null)
            {
                var options = new ToolTipOptions() { Element = element, Text = text };
                appStateService.OpenToolTip(options);
            }
        }
    }
}
