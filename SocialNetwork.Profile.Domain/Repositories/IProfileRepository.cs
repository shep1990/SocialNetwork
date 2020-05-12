using SocialNetwork.Profile.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Profile.Domain.Repositories
{
    public interface IProfileRepository
    {
        Task<ProfileEntity> AddAsync(ProfileEntity entity);

        Task<List<ProfileEntity>> GetAsync();

        Task<ProfileEntity> GetSingleAsync(Expression<Func<ProfileEntity, bool>> predicate);
    }
}
