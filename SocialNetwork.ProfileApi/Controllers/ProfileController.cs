using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Library;
using SocialNetwork.Profile.Domain.Services;

namespace SocialNetwork.ProfileApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [Route("CreateProfile"), HttpPost]
        public void Post([FromBody] SignUpModel signUp)
        {
            _profileService.SaveProfile(signUp);
        }
    }
}
