using SocialNetwork.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Notification.Domain.Services
{
    public interface INotificationService
    {
        Task AddNotification(NotificationModel model);
    }
}
