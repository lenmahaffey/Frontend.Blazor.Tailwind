using Blazor.Frontend.Classes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.Frontend.Components
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
            if (firstRender)
            {
                //_js!.InvokeVoidAsync("detectDisplayAnimationEnd", Id, DotNetObjectReference.Create(this));
                Message!.State = MessageState.isDisplaying;
            }
            base.OnAfterRender(firstRender);
        }

        private  void hideNotification()
        {
            _js!.InvokeVoidAsync("detectHideAnimationEnd", Id, DotNetObjectReference.Create(this));
            Message!.State = MessageState.isDismissing;
            //MessageDismissed.InvokeAsync(Message);
            //Message.IsVisible = false;
        }

        [JSInvokable("onDisplayAnimationEnd")]
        public void onDisplayAnimationEnd()
        {
            Message!.State = MessageState.isDisplayed;
        }

        [JSInvokable("onHideAnimationEnd")]
        public void onHideAnimationEnd()
        {
            Message!.State = MessageState.isDismissed;
            //Message!.IsDismissed = true;
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
