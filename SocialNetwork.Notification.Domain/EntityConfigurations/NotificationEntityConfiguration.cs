using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Notification.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Notification.Domain.EntityConfigurations
{
    public class NotificationEntityConfiguration : IEntityTypeConfiguration<NotificationEntity>
    {
        public void Configure(EntityTypeBuilder<NotificationEntity> builder)
        {
            builder.ToTable("Notifications");

            builder.HasIndex(x => x.Id)
                .IsUnique();

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
