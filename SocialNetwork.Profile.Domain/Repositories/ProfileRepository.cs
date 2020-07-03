using log4net;
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
        private readonly ILog _logger = LogManager.GetLogger(typeof(ProfileRepository));

        public ProfileRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProfileEntity> AddAsync(ProfileEntity entity)
        {
            try
            {
                var profileEntity = _unitOfWork.Context.Set<ProfileEntity>().Add(entity);

                await _unitOfWork.CommitAsync();

                return entity;
            }
            catch (Exception ex)
            {
                _logger.Error(String.Format("An exception was thrown in the profile repository: {0}", ex.Message));
                throw ex;
            }
        }

        public async Task<List<ProfileEntity>> GetAsync()
        {
            try{
                var profileList = await _unitOfWork.Context.Set<ProfileEntity>().ToListAsync();
                return profileList;
            }
            catch(Exception ex)
            {
                _logger.Error(String.Format("An exception was thrown in the profile repository: {0}", ex.Message));
                throw ex;
            }
        }

        public async Task<ProfileEntity> GetSingleAsync(Expression<Func<ProfileEntity, bool>> predicate)
        {
            try
            {
                return await _unitOfWork.Context.Set<ProfileEntity>().SingleOrDefaultAsync(predicate);
            }
            catch (Exception ex)
            {
                _logger.Error(String.Format("An exception was thrown in the profile repository: {0}", ex.Message));
                throw ex;
            }
        }

        public async Task<ProfileEntity> UpdateAsync(ProfileEntity entity)
        {
            try
            {
                _unitOfWork.Context.Set<ProfileEntity>().Attach(entity);

                var entry = _unitOfWork.Context.Entry(entity);
                entry.State = EntityState.Modified;

                await _unitOfWork.CommitAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.Error(String.Format("An exception was thrown in the profile repository: {0}", ex.Message));
                throw ex;
            }
        }
    }
}
