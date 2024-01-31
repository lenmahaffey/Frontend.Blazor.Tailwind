using Frontend.Blazor.Tailwind.Classes;
using Frontend.Blazor.Tailwind.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Frontend.Blazor.Tailwind.Layout.Components
{
    public partial class Notification
    {
        [Inject] NotificationService? notificationService { get; set; }
        [Inject] IJSRuntime? jsRuntime { get; set; }
        [Parameter] public string Id { get; set; } = "notification_" + Guid.NewGuid().ToString("N");
        [Parameter] public Message Message { get; set; } = new Message();
        string animationClass { get; set; } = "hidden";
        IJSObjectReference? js { get; set; }

        protected override async Task OnInitializedAsync()
        {
            js = await jsRuntime!.InvokeAsync<IJSObjectReference>("import", "./Layout/Components/Notification.razor.js");
            await js.InvokeVoidAsync("listenToAnimationEnd", Id, DotNetObjectReference.Create(this));
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                animationClass = Message.IsVisible ? "slideInDown" : "hidden";
            }
            else
            {
                animationClass = Message.IsVisible ? "visible" : "hidden";
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        void hideNotification()
        {
            animationClass = "slideOutRight";
        }

        string SetBorderColor()
        {
            switch (Message?.Type)
            {
                case MessageType.Error:
                    return "border-danger";
                case MessageType.Warning:
                    return "border-warning";
                case MessageType.Success:
                    return "border-success";
                default:
                    return "";
            }
        }

        [JSInvokable("DeleteNotification")]
        public void DeleteNotification()
        {
            notificationService?.DeleteNotification(Message);
        }
    }
}
