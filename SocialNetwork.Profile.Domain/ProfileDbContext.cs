using Microsoft.EntityFrameworkCore;
using SocialNetwork.Profile.Domain.Data;
using SocialNetwork.Profile.Domain.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Profile.Domain
{
    public class ProfileDbContext : DbContext
    {
        public DbSet<ProfileEntity> Profiles { get; set; }

        public ProfileDbContext(DbContextOptions<ProfileDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProfileEntityConfiuration());
        }        
    }
}
