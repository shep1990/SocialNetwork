using SocialNetwork.Notification.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Notification.Domain.Repositories
{
    public interface INotificationRepository
    {
        Task<NotificationEntity> AddAsync(NotificationEntity entity);
    }
}
