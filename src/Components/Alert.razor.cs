using Blazor.Frontend.Classes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.Frontend.Components
{
    public partial class Alert
    {
        [Inject] public IJSRuntime? Js { get; set; }
        [Parameter] public string Id { get; set; } = string.Empty;
        [Parameter] public Message Message { get; set; } = new Message { Text = "User Alert" };
        [Parameter] public EventCallback<Message> MessageDeleted { get; set; }
       
        private IJSObjectReference? _js;

        protected async override Task OnInitializedAsync()
        {
           _js = await Js!.InvokeAsync<IJSObjectReference>("import", "./Components/Alert.razor.js");
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (Message.AutoDismiss)
            {
                _js?.InvokeVoidAsync("dismissAlertInTime", Id , 1000);
                //Message.IsDismissed = true;
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        private void deleteMessage()
        {
            _js?.InvokeVoidAsync("dismissAlert");
            Message.IsDismissed = true;
        }

        private string SetBackgroundColor()
        {
            switch (Message?.Type)
            {
                case MessageType.Error:
                    return "mm-alert-error";
                case MessageType.Warning:
                    return "mm-alert-warning";
                case MessageType.Success:
                    return "mm-alert-success";
                default:
                    return "";
            }
        }
    }
}
