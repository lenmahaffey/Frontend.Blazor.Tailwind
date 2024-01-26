using Blazor.Frontend.Bootstrap.Classes;
using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;

namespace Blazor.Frontend.Bootstrap.Areas.Demo.Components
{
    public partial class ConfirmationDialogDemo : IDisposable
    {
        [Inject] AppStateService? appStateService { get; set; }
        bool? confirmationDialogResponse { get; set; }
        ConfirmationDialogOptions options { get; set; } = new ConfirmationDialogOptions();
        bool hasRun { get; set; } = false;
        ElementReference title { get; set; }
        ElementReference text { get; set; }
        ElementReference okText { get; set; }
        ElementReference cancelText { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (appStateService != null)
            {
                appStateService.ConfirmationResponse += onConfirmationResponseReceived;
            }
        }
        void openConfirmationDialog()
        {
            appStateService?.ConfirmationDialogOptions?.Invoke(this, options);
        }

        private void onConfirmationResponseReceived(object? sender, bool? input)
        {
            hasRun = true;
            confirmationDialogResponse = input;
            StateHasChanged();
        }

        void reset()
        {
            hasRun = false;
        }
        void openToolTip(ElementReference element, string text)
        {
            if (appStateService != null)
            {
                var options = new ToolTipOptions() { Element = element, Text = text };
                appStateService.ToolTipOptions?.Invoke(this, options);
            }
        }

        public void Dispose()
        {
            if (appStateService != null)
            {
                appStateService.ConfirmationResponse -= onConfirmationResponseReceived;
            }
        }
    }
}
