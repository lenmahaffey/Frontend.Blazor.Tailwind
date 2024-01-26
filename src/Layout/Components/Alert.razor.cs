using Blazor.Frontend.Bootstrap.Classes;
using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.Frontend.Bootstrap.Layout.Components
{
    public partial class Alert
    {
        [Inject] IJSRuntime? jsRuntime { get; set; }
        [Inject] AlertService? alertService { get; set; }
        [Parameter] public string Id { get; set; } = "alert_" + Guid.NewGuid().ToString("N");
        [Parameter] public Message Message { get; set; } = new Message();
        string animationClass { get; set; } = "hidden";
        IJSObjectReference? js { get; set; }

        protected override async Task OnInitializedAsync()
        {
            js = await jsRuntime!.InvokeAsync<IJSObjectReference>("import", "./Layout/Components/Alert.razor.js");
            await js.InvokeVoidAsync("listenToAnimationEnd", Id, DotNetObjectReference.Create(this));
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                animationClass = Message.IsVisible ? "fadeIn" : "hidden";
            }
            else
            {
                animationClass = Message.IsVisible ? "visible" : "hidden";
            }
            if (Message.AutoDismiss)
            {
                await wait(Message.DisplayTime);
                hideMessage();
            }
        }
        async Task wait(double seconds)
        {
            await Task.Delay((int)(seconds * 1000));
        }
        void hideMessage()
        {
            animationClass = "fadeOut";
            StateHasChanged();
        }

        private string getBackgroundClass()
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

        [JSInvokable("DeleteAlert")]
        public void DeleteAlert()
        {
            alertService?.DeleteAlert(Message);
        }
    }
}
