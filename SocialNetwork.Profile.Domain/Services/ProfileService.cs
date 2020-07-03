using log4net;
using SocialNetwork.Library;
using SocialNetwork.Profile.Domain.Data;
using SocialNetwork.Profile.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Profile.Domain.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly ILog _logger = LogManager.GetLogger(typeof(ProfileService));

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<ProfileEntity> SaveProfile(SignUpModel model)
        {
            try
            {
                var entity = new ProfileEntity()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Age = model.Age,
                    DateOfBirth = model.DateOfBirth,
                    Email = model.Email
                };

                return await _profileRepository.AddAsync(entity);           
            }
            catch(Exception ex)
            {
                _logger.Error(String.Format("An exception was thrown in the profile service: {0}", ex.Message));
                throw ex;
            }
        }

        public async Task<SignUpModel> GetProfile(Guid userId) 
        {
            try
            {
                var profile = await _profileRepository.GetSingleAsync(p => p.Id == userId);

                var profileModel = new SignUpModel()
                {
                    Id = profile.Id,
                    Name = profile.Name,
                    Age = profile.Age,
                    Email = profile.Email,
                    DateOfBirth = profile.DateOfBirth
                };

                return profileModel;
            }
            catch(Exception ex)
            {
                _logger.Error(String.Format("An exception was thrown in the profile service: {0}", ex.Message));
                throw ex;
            }
        }

        public async Task<ProfileEntity> UpdateProfile(SignUpModel model, Guid userId)
        {
            try
            {
                var entity = new ProfileEntity()
                {
                    Id = userId,
                    Name = model.Name,
                    Age = model.Age,
                    DateOfBirth = model.DateOfBirth,
                    Email = model.Email
                };

                return await _profileRepository.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.Error(String.Format("An exception was thrown in the profile service: {0}", ex.Message));
                throw ex;
            }
        }
    }
}
