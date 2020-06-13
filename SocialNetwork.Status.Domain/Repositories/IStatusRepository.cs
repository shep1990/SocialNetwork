using SocialNetwork.Status.Domain.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Status.Domain.Repositories
{
    public interface IStatusRepository
    {
        Task<StatusEntity> AddAsync(StatusEntity entity);
        Task<List<StatusEntity>> GetAsync(Guid userId);
    }
}
