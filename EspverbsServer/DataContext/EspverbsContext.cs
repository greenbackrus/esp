using Microsoft.EntityFrameworkCore;
using espverbs.Server.Helpers;
using espverbs.Domain.Users;

namespace espverbs.Server.DataContext
{
    public class EspverbsContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: get from env variables
            optionsBuilder.UseSqlite("Data Source = espverbs_base.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UserRest>()
            //    .HasKey(sc => new { sc.UserId, sc.RestId });
            //modelBuilder.Entity<UserRest>()
            //    .HasIndex(sc => new { sc.UserId, sc.RestId }).IsUnique();

            // seed users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Login = "Admin",
                    Name = "Vasily",
                    Password = GeneralHelpers.EncodeString("Password"),
                    Role = User.Roles.Admin,
                });
        }
    }
}
