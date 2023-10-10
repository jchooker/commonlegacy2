using CommonLegacy.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace CommonLegacy
{
    public class UsersDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<User> Users {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.FirstName).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.LastName).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Email).IsRequired();
        }
    }
}