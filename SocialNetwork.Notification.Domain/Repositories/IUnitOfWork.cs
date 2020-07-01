using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Notification.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        NotificationDbContext Context { get; }

        int Commit();

        Task<int> CommitAsync();
    }
}
