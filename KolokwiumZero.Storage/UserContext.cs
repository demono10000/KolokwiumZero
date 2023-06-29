using KolokwiumZero.Storage.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumZero.Storage
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TripType> TripTypes { get; set; }
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("UserDb");
            }
        }
    }
}