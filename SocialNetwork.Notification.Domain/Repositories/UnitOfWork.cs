using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Notification.Domain.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public NotificationDbContext Context { get; }

        public UnitOfWork(NotificationDbContext context)
        {
            Context = context;
        }

        public int Commit()
        {
            return Context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
