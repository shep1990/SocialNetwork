using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Status.Domain.Repositories
{
    public interface IUnitOfWork
    {
        StatusDbContext Context { get; }

        int Commit();

        Task<int> CommitAsync();
    }
}
