using CommonLegacy.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CommonLegacy
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext() : base("name=con")
        {

        }

        public DbSet<User> Users {  get; set; }
    }
}