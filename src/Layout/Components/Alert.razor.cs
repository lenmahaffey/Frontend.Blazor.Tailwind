using Blazor.Frontend.Bootstrap.Classes;
using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.Frontend.Bootstrap.Layout.Components
{
    public partial class Alert
    {
        [Inject] public IJSRuntime? Js { get; set; }
        [Inject] private AlertService? alertService { get; set; }
        [Parameter] public string Id { get; set; } = "alert_" + Guid.NewGuid().ToString("N");
        [Parameter] public Message Message { get; set; } = new Message();
        public string AnimationClass { get; set; } = "hidden";

        private IJSObjectReference? _js;

        protected override async Task OnInitializedAsync()
        {
            _js = await Js!.InvokeAsync<IJSObjectReference>("import", "./Layout/Components/Alert.razor.js");
            await _js.InvokeVoidAsync("listenToAnimationEnd", Id, DotNetObjectReference.Create(this));
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                AnimationClass = Message.IsVisible ? "fadeIn" : "hidden";
            }
            else
            {
                AnimationClass = Message.IsVisible ? "visible" : "hidden";
            }
            if (Message.AutoDismiss)
            {
                await Wait(Message.DisplayTime);
                hideMessage();
            }
        }
        async Task Wait(double seconds)
        {
            await Task.Delay((int)(seconds * 1000));
        }
        private void hideMessage()
        {
            AnimationClass = "fadeOut";
            StateHasChanged();
        }

        [JSInvokable("DeleteAlert")]
        public void DeleteAlert()
        {
            alertService?.DeleteAlert(Message);
        }

        private string SetBackgroundColor()
        {
            switch (Message?.Type)
            {
                case MessageType.Error:
                    return "alert-danger";
                case MessageType.Warning:
                    return "alert-warning";
                case MessageType.Success:
                    return "alert-success";
                default:
                    return "";
            }
        }
    }
}
