using Microsoft.AspNet.Identity.EntityFramework;
using SocialNetworkApp.Core.Models;
using SocialNetworkApp.Persistence.EntityConfigurations;
using System.Data.Entity;

namespace SocialNetworkApp.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Following> Followings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ConcertConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());
            modelBuilder.Configurations.Add(new NotificationConfiguration());
            modelBuilder.Configurations.Add(new AplicationUserConfiguration());
            modelBuilder.Configurations.Add(new AttendanceConfiguration());
            modelBuilder.Configurations.Add(new FollowingConfiguration());
            modelBuilder.Configurations.Add(new UserNotificationConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}