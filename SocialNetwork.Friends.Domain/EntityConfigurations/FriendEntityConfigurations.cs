using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Friends.Domain.Data;
using SocialNetwork.Profile.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Friends.Domain.EntityConfigurations
{
    public class FriendEntityConfigurations : IEntityTypeConfiguration<FriendsEntity>
    {
        public void Configure(EntityTypeBuilder<FriendsEntity> builder)
        {
            builder.ToTable("Friend");

            builder.HasIndex(x => x.Id)
                .IsUnique();

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
