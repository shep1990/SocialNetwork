using SocialNetwork.Friends.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Friends.Domain.Repositories
{
    public class FriendsRepository : IFriendsRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly ILog _logger = LogManager.GetLogger(typeof(ProfileRepository));

        public FriendsRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FriendsEntity> AddAsync(FriendsEntity entity)
        {
            try
            {
                var profileEntity = _unitOfWork.Context.Set<FriendsEntity>().Add(entity);

                await _unitOfWork.CommitAsync();

                return entity;
            }
            catch (Exception ex)
            {
                //_logger.Error(String.Format("An exception was thrown in the profile repository: {0}", ex.Message));
                throw ex;
            }
        }
    }
}
