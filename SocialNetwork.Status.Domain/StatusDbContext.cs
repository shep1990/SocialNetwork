using Microsoft.EntityFrameworkCore;
using SocialNetwork.Status.Domain.Data;
using SocialNetwork.Status.Domain.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Status.Domain
{
    public class StatusDbContext : DbContext
    {
        public DbSet<StatusEntity> Statuses { get; set; }

        public StatusDbContext(DbContextOptions<StatusDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StatusEntityConfiuration());
        }
    }
}
