using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.NotificationsApi.Notifications
{
    public interface INotificationHub
    {
        Task BroadcastMessage(string name, string message);
    }
}
