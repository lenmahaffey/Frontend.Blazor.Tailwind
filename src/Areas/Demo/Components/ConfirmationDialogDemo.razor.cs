using Blazor.Frontend.Bootstrap.Classes;
using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;

namespace Blazor.Frontend.Bootstrap.Areas.Demo.Components
{
    public partial class ConfirmationDialogDemo
    {
        [Inject] AppStateService? appStateService { get; set; }
        public bool? ConfirmationDialogResponse { get; set; }
        public ConfirmationDialogOptions options { get; set; } = new ConfirmationDialogOptions();
        bool hasRun { get; set; } = false;
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
            appStateService?.OpenConfirmationDialog(options);
        }

        void reset()
        {
            hasRun = false;
        }
    }
}
