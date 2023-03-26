using Microsoft.EntityFrameworkCore;
using Travel_Agency.Models.Entities;

namespace Travel_Agency.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAuthInfo> UsersAuthInfo { get; set; }   

    }
}
