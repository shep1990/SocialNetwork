using SocialNetwork.Friends.Domain.Data;
using SocialNetwork.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Friends.Domain.Services
{
    public interface IFriendService
    {
        Task<FriendsEntity> SaveFriend(FriendModel model);
    }
}
