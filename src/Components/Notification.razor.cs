using Blazor.Frontend.Classes;
using Microsoft.AspNetCore.Components;

namespace Blazor.Frontend.Components
{
    public partial class Notification
    {
        [Parameter] public string Id { get; set; } = string.Empty;
        [Parameter] public Message? Message { get; set; } =  new Message();
        private void hideToast()
        {
            //DeleteNotification.InvokeAsync(Message);
            Message!.IsVisible = false;
            Message!.IsDismissed = true;
        }
        private string SetBorderColor()
        {
            switch(Message?.Type)
            {
                case MessageType.Error:
                    return "errorBorder";
                case MessageType.Warning:
                    return "warningBorder";
                case MessageType.Success:
                    return "successBorder";
                default:
                    return "";
            }
        }
    }
}
