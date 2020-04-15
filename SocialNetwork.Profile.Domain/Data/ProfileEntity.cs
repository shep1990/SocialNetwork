using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Profile.Domain.Data
{
    public class ProfileEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
