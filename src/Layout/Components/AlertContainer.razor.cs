﻿using Blazor.Frontend.Bootstrap.Classes;
using Blazor.Frontend.Bootstrap.Services;
using Microsoft.AspNetCore.Components;

namespace Blazor.Frontend.Bootstrap.Layout.Components
{
    public partial class AlertContainer : IDisposable
    {
        [Inject] AlertService? alertService { get; set; }
        List<Message> alerts { get; set; } = new List<Message>();
        protected override void OnInitialized()
        {
            alertService!.MessageReceived += onAlertReceived;
            alertService!.AlertDeleted += onAlertDeleted;
            base.OnInitialized();
        }

        void onAlertReceived(object? sender, Message message)
        {
            alerts.Add(message);
            StateHasChanged();
        }

        void onAlertDeleted(object? sender, Message message)
        {
            alerts.Remove(message);
            StateHasChanged();
        }

        public void Dispose()
        {
            if (alertService != null)
            {
                alertService.MessageReceived -= onAlertReceived;
                alertService.AlertDeleted -= onAlertDeleted;
            }
        }
    }
}
