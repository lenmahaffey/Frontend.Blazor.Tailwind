using Blazor.Frontend.Bootstrap.Classes;
using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.Frontend.Bootstrap.Layout.Components
{
    public partial class Notification
    {
        [Inject] private NotificationService? notificationService { get; set; }
        [Inject] public IJSRuntime? Js { get; set; }
        [Parameter] public string Id { get; set; } = "notification_" + Guid.NewGuid().ToString("N");
        [Parameter] public Message Message { get; set; } = new Message();
        public string AnimationClass { get; set; } = "hidden";

        private IJSObjectReference? _js;

        protected override async Task OnInitializedAsync()
        {
            _js = await Js!.InvokeAsync<IJSObjectReference>("import", "./Layout/Components/Notification.razor.js");
            await _js.InvokeVoidAsync("listenToAnimationEnd", Id, DotNetObjectReference.Create(this));
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                AnimationClass = Message.IsVisible ? "slideInDown" : "hidden";
            }
            else
            {
                AnimationClass = Message.IsVisible ? "visible" : "hidden";
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        private void hideNotification()
        {
            AnimationClass = "slideOutRight";
        }

        [JSInvokable("DeleteNotification")]
        public void DeleteNotification()
        {
            notificationService?.DeleteNotification(Message);
        }

        private string SetBorderColor()
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
    }
}
