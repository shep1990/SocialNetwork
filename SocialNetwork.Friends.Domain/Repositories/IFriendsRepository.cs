using SocialNetwork.Friends.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Friends.Domain.Repositories
{
    public interface IFriendsRepository
    {
        Task<FriendsEntity> AddAsync(FriendsEntity entity);
    }
}
