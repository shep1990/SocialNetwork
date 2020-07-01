using Microsoft.EntityFrameworkCore;
using SocialNetwork.Notification.Domain.Data;
using SocialNetwork.Notification.Domain.EntityConfigurations;
using System;

namespace SocialNetwork.Notification.Domain
{
    public class NotificationDbContext : DbContext
    {
        public DbSet<NotificationEntity> Notifications { get; set; }

        public NotificationDbContext(DbContextOptions<NotificationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NotificationEntityConfiguration());
        }
    }
}
