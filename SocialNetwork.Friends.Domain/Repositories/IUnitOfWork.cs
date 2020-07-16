using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Friends.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        FriendsDbContext Context { get; }

        int Commit();

        Task<int> CommitAsync();
    }
}
