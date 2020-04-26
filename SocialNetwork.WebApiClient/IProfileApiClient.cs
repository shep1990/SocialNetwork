using SocialNetwork.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.WebApiClient
{
    public interface IProfileApiClient
    {
        Task<SignUpModel> CreateProfile(SignUpModel signupModel);
    }
}
