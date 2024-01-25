using Blazor.Frontend.Bootstrap.Classes;
using Microsoft.AspNetCore.Components;

namespace Blazor.Frontend.Bootstrap.Services
{
    public class AppStateService
    {
        [Inject] private ILogger<AppStateService> logger { get; set; }
        [Inject] private AlertService? alertService { get; set; }
        [Inject] private NotificationService? notificationService { get; set; }
        public EventHandler<List<NavLinkGroup>>? SideNavLinks;
        public EventHandler<List<NavLinkGroup>>? TopNavLinks;
        public EventHandler<bool?>? ConfirmationResponse;
        public EventHandler<ConfirmationDialogOptions>? ConfirmationDialogOptions;
        public EventHandler<SpinnerDialogOptions>? SpinnerDialogOptions;
        public EventHandler<bool>? CloseSpinner;
        public EventHandler<ToolTipOptions>? ToolTipOptions;
        public EventHandler<RenderFragment>? RightSideBarContent;
        public AppStateService(ILogger<AppStateService> logs, AlertService aService, NotificationService nService)
        {
            logger = logs;
            alertService = aService;
            notificationService = nService;
        }

        public void SendAlert(Message message)
        {
            if (alertService != null)
            {
                alertService.SendAlert(message);
            }
        }

        public void SendNotification(Message message)
        {
            if (notificationService != null)
            {
                notificationService.SendNotification(message);
            }
        }

        public void OpenConfirmationDialog(ConfirmationDialogOptions options)
        {
            if (ConfirmationDialogOptions != null)
            {
                ConfirmationDialogOptions.Invoke(this, options);
            }
        }

        public void OpenSpinnerDialog(SpinnerDialogOptions options)
        {
            if (SpinnerDialogOptions != null)
            {
                SpinnerDialogOptions.Invoke(this, options);
            }
        }

        public void CloseSpinnerDialog(ConfirmationDialogOptions options)
        {
            if (CloseSpinner != null)
            {
                CloseSpinner.Invoke(this, true);
            }
        }

        public void SendConfirmationResponse(bool? response)
        {
            if (ConfirmationResponse != null)
            {
                ConfirmationResponse.Invoke(this, response);
            }
        }

        public void SetSideNavLinks(List<NavLinkGroup> links)
        {
            if (SideNavLinks != null)
            {
                SideNavLinks.Invoke(this, links);
            }
        }

        public void OpenToolTip(ToolTipOptions options)
        {
            if (ToolTipOptions != null)
            {
                ToolTipOptions.Invoke(this, options);
            }
        }

        public void SetRightSideBarContent(RenderFragment fragment)
        {
            if (RightSideBarContent != null)
            {
                RightSideBarContent.Invoke(this, fragment);
            }
        }
    }
}
