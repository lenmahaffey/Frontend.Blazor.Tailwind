using Blazor.Frontend.Bootstrap.Classes;
using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;

namespace Blazor.Frontend.Bootstrap.Areas.Demo.Components
{
    public partial class SpinnerDialogDemo
    {
        [Inject] AppStateService? appStateService { get; set; }
        string message { get; set; } = "Spin the Spinner";
        int displayTime { get; set; } = 5;
        int countdownTime { get; set; } = 3;
        bool isStatic { get; set; } = true;
        ElementReference countdownTimeInput { get; set; }
        ElementReference displayTimeInput { get; set; }
        ElementReference messageInput { get; set; }
        async void startSpinner()
        {
            openSpinner();
            await wait(displayTime);
            for (int i = 0; i <= countdownTime; i++)
            {
                await wait(1);
                if(i != countdownTime)
                {
                    updateSpinnerMessage($"Closing in {countdownTime - i} seconds");

                }
                else 
                {
                    updateSpinnerMessage($"");

                }
            }
            closeSpinner();
        }
        
        void openSpinner()
        {
            var options = new SpinnerDialogOptions()
            {
                Message = this.message,
                IsStatic = this.isStatic,
            };
            if (appStateService != null)
            {
                appStateService?.SpinnerDialogOptions?.Invoke(this, options);
            }
        }

        void updateSpinnerMessage(string message)
        {
            if(appStateService != null)
            {
                appStateService.SpinnerMessage?.Invoke(this, message);
            }
        }

        void closeSpinner()
        {
            if(appStateService != null)
            {
                appStateService.CloseSpinner?.Invoke(this, true);
            }
        }
        async Task wait(int seconds)
        {
            await Task.Delay(seconds * 1000);
        }
        void openToolTip(ElementReference element, string text)
        {
            if (appStateService != null)
            {
                var options = new ToolTipOptions() { Element = element, Text = text };
                appStateService?.ToolTipOptions?.Invoke(this, options);
            }
        }
    }
}
