﻿using Blazor.Frontend.Classes;
using Blazor.Frontend.Services;
using Microsoft.AspNetCore.Components;

namespace Blazor.Frontend.Shared
{
    public partial class NotificationContainer : IDisposable
    {
        [Inject]
        private NotificationService? notificationService { get; set; }
        [Parameter] public List<Message> Notifications { get; set; } = new List<Message>();

        protected override void OnInitialized()
        {
            notificationService!.MessageReceived += OnMessageReceived;
            base.OnInitialized();
        }

        public void OnMessageReceived(object? sender, Message m)
        {
            purgeOldNotifications();
            var message = new Message(m);
            Notifications.Add(message);
            StateHasChanged();
        }

        public void purgeOldNotifications()
        {
            var old = Notifications.Where(x => !x.IsVisible && x.HasDisplayed == true).ToList();
            if (old.Count() == Notifications.Count())
            {
                Notifications = new List<Message>();
                StateHasChanged();
            }
        }
        public void Dispose()
        {
            notificationService!.MessageReceived -= OnMessageReceived;
        }
    }
}
