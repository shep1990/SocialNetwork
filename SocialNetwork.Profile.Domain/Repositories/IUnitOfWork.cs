using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Profile.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ProfileDbContext Context { get; }

        int Commit();

        Task<int> CommitAsync();
    }
}
