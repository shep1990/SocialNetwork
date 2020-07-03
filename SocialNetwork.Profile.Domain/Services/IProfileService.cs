using SocialNetwork.Library;
using SocialNetwork.Profile.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Profile.Domain.Services
{
    public interface IProfileService
    {
        Task<ProfileEntity> SaveProfile(SignUpModel model);

        Task<SignUpModel> GetProfile(Guid userId);

        Task<ProfileEntity> UpdateProfile(SignUpModel model, Guid userId);
    }
}
