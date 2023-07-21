using Blazor.Frontend.Classes;
using Microsoft.AspNetCore.Components;

namespace Blazor.Frontend.Components
{
    public partial class Notification
    {
        [Parameter] public string Id { get; set; } = string.Empty;
        [Parameter] public Message? Message { get; set; } =  new Message();
        private void hideNotification()
        {
            Message!.IsVisible = false;
            Message!.IsDismissed = true;
        }
        private string SetBorderColor()
        {
            var result =  Enum.GetName(Message!.Type)?.ToLower() + "Border" ?? string.Empty;
            return result;
        }
    }
}
