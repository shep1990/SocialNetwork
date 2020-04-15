using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Profile.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Profile.Domain.EntityConfigurations
{
    public class ProfileEntityConfiuration : IEntityTypeConfiguration<ProfileEntity>
    {
        public void Configure(EntityTypeBuilder<ProfileEntity> builder)
        {
            builder.ToTable("Profile");

            builder.HasIndex(x => x.Id)
                .IsUnique();

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
