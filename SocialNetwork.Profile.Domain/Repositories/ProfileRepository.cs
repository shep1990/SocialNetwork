using Microsoft.EntityFrameworkCore;
using SocialNetwork.Profile.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public async Task<List<ProfileEntity>> GetAsync()
        {
            var profileList = await _unitOfWork.Context.Set<ProfileEntity>().ToListAsync();

            return profileList;
        }

        public async Task<ProfileEntity> GetSingleAsync(Expression<Func<ProfileEntity, bool>> predicate)
        {
            return await _unitOfWork.Context.Set<ProfileEntity>().SingleOrDefaultAsync(predicate);
        }

        public async Task UpdateAsync(ProfileEntity entity)
        {
            _unitOfWork.Context.Set<ProfileEntity>().Attach(entity);

            var entry = _unitOfWork.Context.Entry(entity);
            entry.State = EntityState.Modified;


            await _unitOfWork.CommitAsync();
        }
    }
}
