using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Library
{
    public class NotificationModel
    {
        public Guid UserId { get; set; }

        public string NotificationMessage { get; set; }

        public string UserName { get; set; }
    }
}
