using SocialNetwork.Friends.Domain.Data;
using SocialNetwork.Friends.Domain.Repositories;
using SocialNetwork.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Friends.Domain.Services
{
    public class FriendService : IFriendService
    {
        private readonly IFriendsRepository _friendsRepository;

        public FriendService(IFriendsRepository friendsRepository)
        {
            _friendsRepository = friendsRepository;
        }

        public async Task<FriendsEntity> SaveFriend(FriendModel model)
        {
            try
            {
                var entity = new FriendsEntity()
                {
                    RequestUserId = model.RequestUserId,
                    TargetUserId = model.TargetUserId
                };

                return await _friendsRepository.AddAsync(entity);
            }
            catch (Exception ex)
            {
                //_logger.Error(String.Format("An exception was thrown in the profile service: {0}", ex.Message));
                throw ex;
            }
        }
    }
}
