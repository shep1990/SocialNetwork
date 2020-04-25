using SocialNetwork.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Profile.Domain.Services
{
    public interface IProfileService
    {
        Task SaveProfile(SignUpModel model);
    }
}
