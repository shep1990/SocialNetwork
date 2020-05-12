using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using log4net;
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
        private readonly ILog _logger = LogManager.GetLogger(typeof(SignUpController));

        public SignUpController(
            ServiceBusSender serviceBusSender, 
            IEmailService emailService
        )
        {
            _serviceBusSender = serviceBusSender;
            _emailSender = emailService;
        }


        [Route("SignUpConfirmation"), HttpPost]
        public async Task Post([FromBody] SignUpModel signUp)
        {
            try
            {
                await _emailSender.SendEmail(signUp.Email);
                // Send this to the bus for the other services
                await _serviceBusSender.SendMessage(signUp);
            }
            catch (Exception ex)
            {
                _logger.Error("an error occurred: {0}", ex);
                throw ex;
            }
        }
    }
}