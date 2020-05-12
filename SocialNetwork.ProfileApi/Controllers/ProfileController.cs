using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Library;
using SocialNetwork.Profile.Domain.Services;

namespace SocialNetwork.ProfileApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private IProfileService _profileService;
        private readonly ILog _logger = LogManager.GetLogger(typeof(ProfileController));

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [Route("CreateProfile"), HttpPost]
        [AllowAnonymous]
        public async Task Post([FromBody] SignUpModel signUp)
        {
            try
            {
                await _profileService.SaveProfile(signUp);
            }
            catch (Exception ex)
            {
                _logger.Error(String.Format("An exception was thrown: {0}", ex));
                throw ex;
            }
        }

        [Route("GetProfile/{userId}"), HttpGet]
        [EnableCors("CorsPolicy")]
        public async Task<SignUpModel> Get(Guid userId)
        {
            try
            {
                return await _profileService.GetProfile(userId);
            }
            catch (Exception ex)
            {
                _logger.Error(String.Format("An exception was thrown: {0}", ex));
                throw ex;
            }
        }
    }
}
