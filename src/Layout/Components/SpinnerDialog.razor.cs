using Blazor.Frontend.Bootstrap.Classes;
using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.Frontend.Bootstrap.Layout.Components
{
    public partial class SpinnerDialog
    {
        [Inject] public IJSRuntime? Js { get; set; }
        [Inject] AppStateService? AppStateService { get; set; }
        public string Id { get; set; } = "spinner";
        public string Message { get; set; } = "Message goes here";
        public bool IsStatic { get; set; } = true;
        private IJSObjectReference? _js;
        private ElementReference? spinnerDialog;
        public SpinnerDialogOptions SpinnerDialogOptions { get; set; } = new SpinnerDialogOptions();
        protected async override Task OnInitializedAsync()
        {
            if (Js != null)
            {
                _js = await Js.InvokeAsync<IJSObjectReference>("import", "./Layout/Components/SpinnerDialog.razor.js");
            }
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (AppStateService != null)
            {
                AppStateService.SpinnerDialogOptions += OnSpinnerDialogOptionsReceived;
                AppStateService.CloseSpinner += OnCloseSpinnerReceived;
                AppStateService.SpinnerMessage += onSpinnerMessageReceived;
            }
        }
        void onSpinnerMessageReceived(object? sender, string message)
        {
            Message = message;
            StateHasChanged();
        }

        public void OnSpinnerDialogOptionsReceived(object? sender, SpinnerDialogOptions options)
        {
            SpinnerDialogOptions = options;
            Message = SpinnerDialogOptions.Message;
            StateHasChanged();
            _js!.InvokeVoidAsync("setAttributes", spinnerDialog, options.IsStatic, DotNetObjectReference.Create(this));
        }

        [JSInvokable]
        public void OpenSpinner()
        {
            _js!.InvokeVoidAsync("openSpinner", spinnerDialog);
        }

        public void OnCloseSpinnerReceived(object? sender, bool shouldClose)
        {
            _js!.InvokeVoidAsync("closeSpinner", spinnerDialog);
        }
    }
}
