using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Library;
using SocialNetwork.SignUpApi.EmailServices;
using SocialNetwork.SignUpApi.ServiceBusHelper;

namespace SocialNetwork.SignUpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private ServiceBusSender _serviceBusSender;
        private IEmailService _emailSender;

        public SignUpController(
            ServiceBusSender serviceBusSender, 
            IEmailService emailService
        )
        {
            _serviceBusSender = serviceBusSender;
            _emailSender = emailService;
        }


        [Route("CreateProfile"), HttpPost]
        public async Task Post([FromBody] SignUpModel signUp)
        {
            await _emailSender.SendEmail(signUp.Email);

            // Send this to the bus for the other services
            await _serviceBusSender.SendMessage(new SignUpModel
            {
                Id = signUp.Id,
                Name = signUp.Name,
                Email = signUp.Email,
                Age = signUp.Age,
                DateOfBirth = signUp.DateOfBirth
            });
        }
    }
}