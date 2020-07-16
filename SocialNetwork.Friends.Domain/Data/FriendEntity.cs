using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Friends.Domain.Data
{
    public class FriendsEntity
    {
        public Guid Id { get; set; }

        public Guid RequestUserId { get; set; }

        public Guid TargetUserId { get; set; }

        public bool RequestAccepted { get; set; }
    }
}
