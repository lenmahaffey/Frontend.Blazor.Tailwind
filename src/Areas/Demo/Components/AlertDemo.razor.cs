using Blazor.Frontend.Bootstrap.Classes;
using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;

namespace Blazor.Frontend.Bootstrap.Areas.Demo.Components
{
    public partial class AlertDemo
    {
        [Inject] AppStateService? appStateService { get; set; }
        public Message AlertMessage { get; set; } = new Message();
        public void SendAlert()
        {
            if (appStateService != null)
            {
                AlertMessage.Time = DateTime.Now;
                appStateService.SendAlert(AlertMessage);
                AlertMessage = new Message(); //Reset the input
            }
        }
    }
}
