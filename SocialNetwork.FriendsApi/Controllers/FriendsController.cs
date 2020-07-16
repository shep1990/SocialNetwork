using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Friends.Domain.Services;
using SocialNetwork.FriendsApi.ServiceBusHelper;
using SocialNetwork.Library;

namespace SocialNetwork.FriendsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        private readonly IFriendService _friendService;
        private readonly ServiceBusSender _serviceBusSender;

        public FriendsController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        [Route("createRequest"), HttpPost]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> Post([FromBody] FriendModel friendModel)
        {
            try
            {
                var profile = await _friendService.SaveFriend(friendModel);

                if (profile != null)
                {
                    await _serviceBusSender.SendMessage(friendModel);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                //_logger.Error(String.Format("An exception was thrown: {0}", ex));
                return BadRequest(ex);
            }
        }
    }
}
