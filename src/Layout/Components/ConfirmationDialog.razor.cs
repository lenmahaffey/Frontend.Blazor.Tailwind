using Blazor.Frontend.Bootstrap.Classes;
using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace Blazor.Frontend.Bootstrap.Layout.Components
{
    public partial class ConfirmationDialog
    {
        [Inject] AppStateService? appStateService { get; set; }
        [Inject] IJSRuntime? jsRuntime { get; set; }
        [Parameter] public bool DisableEscape { get; set; } = true;
        string id { get; set; } = "confirm";
        bool? response { get; set; }
        ConfirmationDialogOptions confirmationDialogOptions { get; set; } = new ConfirmationDialogOptions();
        Dictionary<string, object> attributes { get; set; } = new Dictionary<string, object> { { "data-bs-backdrop", "static" }, { "data-bs-keyboard", "false" } };
        ElementReference? toggleButton { get; set; }
        IJSObjectReference? js { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (!DisableEscape)
            {
                attributes.Clear();
            }
            js = await jsRuntime!.InvokeAsync<IJSObjectReference>("import", "./Layout/Components/ConfirmationDialog.razor.js");
            appStateService!.ConfirmationDialogOptions += onConfirmationDialogOptionsReceived;
            await base.OnInitializedAsync();
        }
        void onConfirmationDialogOptionsReceived(object? sender, ConfirmationDialogOptions options)
        {
            confirmationDialogOptions = options;
            StateHasChanged();
            openModal();
        }
        void openModal()
        {
            js!.InvokeVoidAsync("ToggleModal", toggleButton);
        }

        void closeModal()
        {
            appStateService!.ConfirmationResponse!.Invoke(this, response);
            js!.InvokeVoidAsync("ToggleModal", toggleButton);
        }

        void cancel()
        {
            response = false;
            closeModal();
        }
        void ok()
        {
            response = true;
            closeModal();
        }
        void dismiss()
        {
            response = null;
            closeModal();
        }
        void onKeyDown(KeyboardEventArgs e)
        {
            if (e.Key == "Escape")
            {
                dismiss();
            }
        }
    }
}
