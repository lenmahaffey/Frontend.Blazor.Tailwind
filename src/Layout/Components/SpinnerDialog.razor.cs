using Frontend.Blazor.Tailwind.Classes;
using Frontend.Blazor.Tailwind.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Frontend.Blazor.Tailwind.Layout.Components
{
    public partial class SpinnerDialog : IDisposable
    {
        [Inject] IJSRuntime? jsRuntime { get; set; }
        [Inject] AppStateService? appStateService { get; set; }
        string id { get; set; } = "spinner";
        string message { get; set; } = "Message goes here";
        IJSObjectReference? js { get; set; }
        ElementReference? spinnerDialog { get; set; }
        SpinnerDialogOptions options { get; set; } = new SpinnerDialogOptions();
        protected async override Task OnInitializedAsync()
        {
            if (jsRuntime != null)
            {
                js = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "./Layout/Components/SpinnerDialog.razor.js");
            }
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (appStateService != null)
            {
                appStateService.SpinnerDialogOptions += onSpinnerDialogOptionsReceived;
                appStateService.CloseSpinner += onCloseSpinnerReceived;
                appStateService.SpinnerMessage += onSpinnerMessageReceived;
            }
        }
        void onSpinnerMessageReceived(object? sender, string message)
        {
            this.message = message;
            StateHasChanged();
        }

        void onSpinnerDialogOptionsReceived(object? sender, SpinnerDialogOptions options)
        {
            this.options = options;
            message = this.options.Message;
            StateHasChanged();
            js!.InvokeVoidAsync("setAttributes", spinnerDialog, options.IsStatic, DotNetObjectReference.Create(this));
        }

        void onCloseSpinnerReceived(object? sender, bool shouldClose)
        {
            js!.InvokeVoidAsync("closeSpinner", spinnerDialog);
        }

        [JSInvokable]
        public void OpenSpinner()
        {
            js!.InvokeVoidAsync("openSpinner", spinnerDialog);
        }
        public void Dispose()
        {
            if (appStateService != null)
            {
                appStateService.SpinnerDialogOptions -= onSpinnerDialogOptionsReceived;
                appStateService.CloseSpinner -= onCloseSpinnerReceived;
                appStateService.SpinnerMessage -= onSpinnerMessageReceived;
            }
        }
    }
}
