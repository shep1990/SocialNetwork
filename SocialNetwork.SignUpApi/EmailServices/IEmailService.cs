using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.SignUpApi.EmailServices
{
    public interface IEmailService
    {
        Task SendEmail(string emailTo);
    }
}
