using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.NotificationsApi.Notifications
{
    public class NotificationsHub : Hub<INotificationHub>
    {
        public void Send(string name, string message)
        {
            Clients.All.BroadcastMessage(name, message);
        }
    }
}
