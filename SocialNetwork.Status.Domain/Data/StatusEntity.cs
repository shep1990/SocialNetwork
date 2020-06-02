using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Status.Domain.Data
{
    public class StatusEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Status { get; set; } 
    }
}
