using Blazor.Frontend.Bootstrap.Classes;
using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;

namespace Blazor.Frontend.Bootstrap.Areas.Demo.Components
{
    public partial class SpinnerDialogDemo
    {
        [Inject] AppStateService? appStateService { get; set; }
        public void OpenSpinner(string message, bool isStatic)
        {
            var options = new SpinnerDialogOptions()
            {
                Message = message,
                IsStatic = isStatic,
            };
            if (appStateService != null)
            {
                appStateService.OpenSpinnerDialog(options);
            }
        }
    }
}
