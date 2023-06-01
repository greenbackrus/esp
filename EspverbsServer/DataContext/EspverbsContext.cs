using espverbs.Domain.LearningProcess;
using espverbs.Domain.LearningProcess.Tasks;
using espverbs.Domain.Users;
using espverbs.Domain.Words.Verbs;
using espverbs.Domain.Words.Verbs.Mutations;
using espverbs.Server.Helpers;
using Microsoft.EntityFrameworkCore;

namespace espverbs.Server.DataContext
{
    public class EspverbsContext : DbContext
    {
        // User-related records
        public DbSet<User> Users { get; set; }

        // Language-related records
        public DbSet<Verb> Verbs { get; set; }
        public DbSet<Tense> Tenses { get; set; }
        public DbSet<RegularVerbsMutation> RegularVerbsMutations { get; set; }

        // Learning process-related records
        public DbSet<LearningSession> LearningSessions { get; set; }
        public DbSet<TypingTask> TypingTasks { get; set; }

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
