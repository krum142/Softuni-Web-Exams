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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Receipt>(receipt =>
            {
                receipt.HasOne(r => r.Recipient).WithMany(u => u.Receipts).HasForeignKey(r => r.RecipientId)
                    .OnDelete(DeleteBehavior.Restrict);
                receipt.HasOne(r => r.Package).WithOne(p => p.Receipt).HasForeignKey<Receipt>(r => r.PackageId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<User>().HasMany(u => u.Packages).WithOne(p => p.Recipient).HasForeignKey(p => p.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
