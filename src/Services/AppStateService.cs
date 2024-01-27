using Frontend.Blazor.Bootstrap.Classes;
using Microsoft.AspNetCore.Components;

namespace Frontend.Blazor.Bootstrap.Services
{
    public class AppStateService
    {
        [Inject] AlertService? alertService { get; set; }
        [Inject] NotificationService? notificationService { get; set; }
        public EventHandler<List<NavLinkGroup>>? SideNavLinks;
        public EventHandler<List<NavLinkGroup>>? TopNavLinks;
        public EventHandler<bool?>? ConfirmationResponse;
        public EventHandler<ConfirmationDialogOptions>? ConfirmationDialogOptions;
        public EventHandler<SpinnerDialogOptions>? SpinnerDialogOptions;
        public EventHandler<string>? SpinnerMessage;
        public EventHandler<bool>? CloseSpinner;
        public EventHandler<ToolTipOptions>? ToolTipOptions;
        public EventHandler<RenderFragment>? RightSideBarContent;
        public AppStateService(AlertService aService, NotificationService nService)
        {
            alertService = aService;
            notificationService = nService;
        }

        public void SendAlert(Message message)
        {
            if (alertService != null)
            {
                alertService.SendAlert(message);
            }
            else
            {
                //**TODO** Throw Error
            }
        }

        public void SendNotification(Message message)
        {
            if (notificationService != null)
            {
                notificationService.SendNotification(message);
            }
            else
            {
                //**TODO** Throw Error
            }
        }
    }
}
