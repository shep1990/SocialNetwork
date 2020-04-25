using SocialNetwork.Profile.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Profile.Domain.Repositories
{
    public interface IProfileRepository
    {
        Task<ProfileEntity> AddAsync(ProfileEntity entity);
    }
}
