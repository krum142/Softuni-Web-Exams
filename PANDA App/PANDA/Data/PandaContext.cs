using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PANDA.Config;
using PANDA.Models;

namespace PANDA.Data
{
    public class PandaContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Package> Package { get; set; }

        public DbSet<Receipt> Receipt { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
