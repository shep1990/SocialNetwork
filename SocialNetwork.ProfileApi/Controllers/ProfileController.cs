using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using SocialNetwork.Library;
using SocialNetwork.Profile.Domain.Data;
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
        public async Task<IActionResult> Post([FromBody] SignUpModel signUp)
        {
            try
            {
                var profile = await _profileService.SaveProfile(signUp);
                return Ok();                
            }
            catch (Exception ex)
            {
                _logger.Error(String.Format("An exception was thrown: {0}", ex));
                return BadRequest(ex);
            }
        }

        [Route("GetProfile/{userId}"), HttpGet]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> Get(Guid userId)
        {
            try
            {
                var profile = await _profileService.GetProfile(userId);
                return Ok(profile);
            }
            catch (Exception ex)
            {
                _logger.Error(String.Format("An exception was thrown: {0}", ex));
                return BadRequest(ex);
            }
        }

        [Route("UpdateProfile/{userId}"), HttpPost]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> Put([FromBody] SignUpModel profile, Guid userId)
        {
            try
            {
                var response = await _profileService.UpdateProfile(profile, userId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.Error(String.Format("An exception was thrown: {0}", ex));
                return BadRequest(ex);
            }
        }
    }
}
