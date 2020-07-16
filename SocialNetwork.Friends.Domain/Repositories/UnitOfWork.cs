using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Friends.Domain.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public FriendsDbContext Context { get; }

        public UnitOfWork(FriendsDbContext context)
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
