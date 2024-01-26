using Blazor.Frontend.Bootstrap.Classes;
using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;

namespace Blazor.Frontend.Bootstrap.Areas.Demo.Components
{
    public partial class SpinnerDialogDemo
    {
        [Inject] AppStateService? appStateService { get; set; }
        string Message { get; set; } = "Spin the Spinner";
        int DisplayTime { get; set; } = 5;
        int CountdownTime { get; set; } = 3;
        bool IsStatic { get; set; } = true;
        ElementReference countdownTimeInput { get; set; }
        ElementReference displayTimeInput { get; set; }
        ElementReference messageInput { get; set; }
        public async void StartSpinner()
        {
            openSpinner();
            await wait(DisplayTime);
            for (int i = 0; i <= CountdownTime; i++)
            {
                await wait(1);
                if(i != CountdownTime)
                {
                    updateSpinnerMessage($"Closing in {CountdownTime - i} seconds");

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
                Message = this.Message,
                IsStatic = this.IsStatic,
            };
            if (appStateService != null)
            {
                appStateService.OpenSpinnerDialog(options);
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
        void OpenToolTip(ElementReference element, string text)
        {
            if (appStateService != null)
            {
                var options = new ToolTipOptions() { Element = element, Text = text };
                appStateService.OpenToolTip(options);
            }
        }
    }
}
