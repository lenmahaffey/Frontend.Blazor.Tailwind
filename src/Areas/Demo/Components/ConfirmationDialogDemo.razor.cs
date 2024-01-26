using Blazor.Frontend.Bootstrap.Classes;
using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;

namespace Blazor.Frontend.Bootstrap.Areas.Demo.Components
{
    public partial class ConfirmationDialogDemo
    {
        [Inject] AppStateService? appStateService { get; set; }
        public bool? ConfirmationDialogResponse { get; set; }
        public ConfirmationDialogOptions Options { get; set; } = new ConfirmationDialogOptions();
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
        private void onConfirmationResponseReceived(object? sender, bool? input)
        {
            hasRun = true;
            ConfirmationDialogResponse = input;
            StateHasChanged();
        }
        public void OpenConfirmationDialog()
        {
            appStateService?.OpenConfirmationDialog(Options);
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
                appStateService.OpenToolTip(options);
            }
        }
    }
}
