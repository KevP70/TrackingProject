using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjetSuiviGeek.Models;

namespace ProjetSuiviGeek.Data
{
    public class FollowedDbContext : DbContext
    {
        public FollowedDbContext(DbContextOptions<FollowedDbContext> options) : base(options)
        {
        }

        public DbSet<FollowedItem> FollowedItem { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FollowedItem>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<FollowedItem>()
                .HasOne(f => f.User)
                .WithMany(u => u.FollowedItemsId)
                .HasForeignKey(f => f.UserId);
        }
    }
}
