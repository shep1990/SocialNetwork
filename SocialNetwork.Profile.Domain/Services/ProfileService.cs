﻿using SocialNetwork.Library;
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

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task SaveProfile(SignUpModel model)
        {
            var entity = new ProfileEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Age = model.Age,
                DateOfBirth = model.DateOfBirth,
                Email = model.Email
            };

            await _profileRepository.AddAsync(entity);
        }

        public async Task<SignUpModel> GetProfile(Guid userId) {

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

        public async Task UpdateProfile(SignUpModel model, Guid userId)
        {
            var entity = new ProfileEntity()
            {
                Id = userId,
                Name = model.Name,
                Age = model.Age,
                DateOfBirth = model.DateOfBirth,
                Email = model.Email
            };

            await _profileRepository.UpdateAsync(entity);
        }
    }
}
