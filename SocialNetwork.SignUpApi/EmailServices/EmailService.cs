using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SocialNetwork.SignUpApi.EmailServices
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private SmtpClient _smtpClient;

        public EmailService(
            IConfiguration configuration,
            SmtpClient smtpClient
        )
        {
            _configuration = configuration;
            _smtpClient = smtpClient;
        }

        public async Task SendEmail(string emailTo)
        {
            try
            {
                _smtpClient.Credentials = new NetworkCredential(
                    _configuration.GetSection("Email:Smtp:Username").Value, 
                    _configuration.GetSection("Email:Smtp:Password").Value
                );

                var mail = new MailMessage(_configuration.GetSection("Email:Smtp:Username").Value, emailTo);
                mail.Subject = "Test Email";
                mail.Body = "test Message";
                await _smtpClient.SendMailAsync(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

    }
}
