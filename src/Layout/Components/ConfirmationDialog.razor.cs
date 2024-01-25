using Blazor.Frontend.Bootstrap.Classes;
using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace Blazor.Frontend.Bootstrap.Layout.Components
{
    public partial class ConfirmationDialog
    {
        [Inject] public AppStateService? AppStateService { get; set; }
        [Inject] public IJSRuntime? Js { get; set; }
        [Parameter] public bool DisableEscape { get; set; } = true;
        private ElementReference? toggleButton { get; set; }
        public string Id { get; set; } = "confirm";
        public ConfirmationDialogOptions ConfirmationDialogOptions { get; set; } = new ConfirmationDialogOptions();

        private IJSObjectReference? _js;
        private bool? response { get; set; }
        private Dictionary<string, object> attributes = new Dictionary<string, object> { { "data-bs-backdrop", "static" }, { "data-bs-keyboard", "false" } };

        protected override async Task OnInitializedAsync()
        {
            if (!DisableEscape)
            {
                attributes.Clear();
            }
            _js = await Js!.InvokeAsync<IJSObjectReference>("import", "./Layout/Components/ConfirmationDialog.razor.js");
            AppStateService!.ConfirmationDialogOptions += OnConfirmationDialogOptionsReceived;
            await base.OnInitializedAsync();
        }
        public void OnConfirmationDialogOptionsReceived(object? sender, ConfirmationDialogOptions options)
        {
            ConfirmationDialogOptions = options;
            StateHasChanged();
            OpenModal();
        }
        public void OpenModal()
        {
            _js!.InvokeVoidAsync("ToggleModal", toggleButton);
        }

        public void CloseModal()
        {
            AppStateService!.ConfirmationResponse!.Invoke(this, response);
            _js!.InvokeVoidAsync("ToggleModal", toggleButton);
        }

        private void cancel()
        {
            response = false;
            CloseModal();
        }
        private void ok()
        {
            response = true;
            CloseModal();
        }
        private void dismiss()
        {
            response = null;
            CloseModal();
        }
        private void onKeyDown(KeyboardEventArgs e)
        {
            if (e.Key == "Escape")
            {
                dismiss();
            }
        }
    }
}
