using Microsoft.EntityFrameworkCore;
using SocialNetwork.Friends.Domain.Data;
using SocialNetwork.Friends.Domain.EntityConfigurations;
using System;

namespace SocialNetwork.Friends.Domain
{
    public class FriendsDbContext : DbContext
    {
        public DbSet<FriendsEntity> Friends { get; set; }

        public FriendsDbContext(DbContextOptions<FriendsDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FriendEntityConfigurations());
        }
    }
}
