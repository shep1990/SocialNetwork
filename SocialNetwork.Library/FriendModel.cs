using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Library
{
    public class FriendModel
    {
        public Guid RequestUserId { get; set; }

        public Guid TargetUserId { get; set; }
    }
}
