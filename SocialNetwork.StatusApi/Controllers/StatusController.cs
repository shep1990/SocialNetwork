using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Library;
using SocialNetwork.Status.Domain.Services;

namespace SocialNetwork.StatusApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;
        private readonly ILog _logger = LogManager.GetLogger(typeof(StatusController));

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [Route("CreateStatus/{userId}"), HttpPost]
        [EnableCors("CorsPolicy")]
        public async Task Post([FromBody] StatusModel status, Guid userId)
        {
            try
            {
                status.UserId = userId != Guid.Empty ? userId : throw new Exception("User was not provided");
                await _statusService.SaveStatus(status);
            }
            catch (Exception ex)
            {
                _logger.Error(String.Format("An exception was thrown: {0}", ex));
                throw ex;
            }
        }
    }
}
