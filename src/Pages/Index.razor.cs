using Blazor.Frontend.Classes;
using Blazor.Frontend.Services;
using Microsoft.AspNetCore.Components;

namespace Blazor.Frontend.Pages
{
    public partial class Index
    {
        [Inject] NotificationService? notificationService { get; set; }
        [Inject] AlertService? alertService { get; set; }
        public bool? UserInput { get; set; }
        public Message AlertMessage { get; set; } = new Message();
        public Message NotificationMessage { get; set; } = new Message();
        public string TestString { get; set; } = string.Empty;
        public void OnResponse(bool input)
        {
            UserInput = input;
        }

        public void SendNotification()
        {
            notificationService!.SendMessage(NotificationMessage);
            NotificationMessage = new Message(); //Reset the input
        }

        public void SendAlert()
        {
            alertService!.SendMessage(AlertMessage);
            AlertMessage = new Message(); //Reset the input
        }
    }
}
