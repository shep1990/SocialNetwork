using SocialNetwork.Profile.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Profile.Domain.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProfileRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProfileEntity> AddAsync(ProfileEntity entity)
        {
            _unitOfWork.Context.Set<ProfileEntity>().Add(entity);

            await _unitOfWork.CommitAsync();

            return entity;
        }
    }
}
