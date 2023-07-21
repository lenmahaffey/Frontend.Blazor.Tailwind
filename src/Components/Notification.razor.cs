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

        private IJSObjectReference? _js;

        protected override async Task OnInitializedAsync()
        {
            _js = await Js!.InvokeAsync<IJSObjectReference>("import", "./Components/Notification.razor.js");
        }
        private  void hideNotification()
        {
            _js!.InvokeVoidAsync("detectAnimationEnd", Id, DotNetObjectReference.Create(this));
        }

        [JSInvokable("onAnimationEnd")]
        public void onAnimationEnd()
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
