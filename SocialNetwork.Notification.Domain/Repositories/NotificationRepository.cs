using SocialNetwork.Notification.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Notification.Domain.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<NotificationEntity> AddAsync(NotificationEntity entity)
        {
            _unitOfWork.Context.Set<NotificationEntity>().Add(entity);

            await _unitOfWork.CommitAsync();

            return entity;
        }
    }
}
