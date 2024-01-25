using Blazor.Frontend.Bootstrap.Classes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;

namespace Blazor.Frontend.Bootstrap.Components
{
    public partial class Notification
    {
        [Inject] public IJSRuntime? Js { get; set; }
        [Parameter] public string Id { get; set; } = string.Empty;
        [Parameter] public Message? Message { get; set; } =  new Message();
        [Parameter] public EventCallback<Message> MessageDismissed { get; set; }    

        private IJSObjectReference? _js;

        protected override async Task OnInitializedAsync()
        {
            _js = await Js!.InvokeAsync<IJSObjectReference>("import", "./Components/Notification.razor.js");
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (!Message!.IsDismissed)
            {
                Message!.State = MessageState.isDisplaying;
            }
            base.OnAfterRender(firstRender);
        }

        protected override bool ShouldRender()
        {
            if (Message!.HasDisplayed && !Message!.IsVisible)
            {
                return false;
            }
            return true;
        }

        private  void hideNotification()
        {
            _js!.InvokeVoidAsync("detectHideAnimationEnd", Id, DotNetObjectReference.Create(this));
            Message!.State = MessageState.isDismissing;
        }

        [JSInvokable("onHideAnimationEnd")]
        public void onHideAnimationEnd()
        {
            Message!.State = MessageState.isDismissed;
            Message!.HasDisplayed = true;
            Message!.IsVisible = false;
            //This will clear each message from the backing list when the notification
            //is dismissed but it breaks the CSS animations
            //MessageDismissed.InvokeAsync(Message); 
        }

        private string getAnimationClass()
        {
            if (Message!.State == MessageState.isDisplaying)
            {
                return "showNotification";
            }
            else if (Message!.State == MessageState.isDismissing)
            {
                return "dismissNotification";
            }
            else if (Message!.State == MessageState.isDismissed)
            {
                return "hidden";
            }
            else { return ""; }
        }
        private string SetBorderColor()
        {
            var result =  Enum.GetName(Message!.Type)?.ToLower() + "Border" ?? string.Empty;
            return result;
        }
    }
}
