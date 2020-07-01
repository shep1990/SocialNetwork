using SocialNetwork.Library;
using SocialNetwork.Notification.Domain.Data;
using SocialNetwork.Notification.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Notification.Domain.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task AddNotification(NotificationModel model)
        {
            var entity = new NotificationEntity
            {
                UserId = model.UserId,
                UserName = model.UserName,
                Notification = model.NotificationMessage
            };
            await _notificationRepository.AddAsync(entity);
        }
    }
}
