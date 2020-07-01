using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Notification.Domain.Data
{
    public class NotificationEntity
    {
        public Guid Id { get; set; }

        public string Notification { get; set; }

        public string UserName { get; set; }

        public Guid UserId { get; set; }
    }
}
