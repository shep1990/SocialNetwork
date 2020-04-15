using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Library;
using SocialNetwork.SignUpApi.ServiceBusHelper;

namespace SocialNetwork.SignUpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private ServiceBusSender _serviceBusSender;

        public SignUpController(ServiceBusSender serviceBusSender)
        {
            _serviceBusSender = serviceBusSender;
        }


        [HttpPost]
        public async Task Post([FromBody] SignUpModel signUp)
        {
            // Send this to the bus for the other services
            await _serviceBusSender.SendMessage(new SignUpModel
            {
                Name = signUp.Name,
                Email = signUp.Email,
                Age = signUp.Age,
                DateOfBirth = signUp.DateOfBirth
            });
        }
    }
}