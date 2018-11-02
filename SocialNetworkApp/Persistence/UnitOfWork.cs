using SocialNetworkApp.Core;
using SocialNetworkApp.Core.Repositories;
using SocialNetworkApp.Persistence.Repositories;
using SocialNetworkApp.Persitence.Repositories;

namespace SocialNetworkApp.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IConcertRepository Concerts { get; private set; }
        public IAttendanceRepository Attendances { get; private set; }
        public IGenreRepository Genres { get; private set; }
        public IFollowingRepository Followings { get; private set; }
        public IApplicationUserRepository Users { get; private set; }
        public INotificationRepository Notifications { get; private set; }
        public IUserNotificationRepository UserNotifications { get; private set; }


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Concerts = new ConcertRepository(context);
            Attendances = new AttendanceRepository(context);
            Followings = new FollowingRepository(context);
            Genres = new GenreRepository(context);
            Users = new ApplicationUserRepository(context);
            Notifications = new NotificationRepository(context);
            UserNotifications = new UserNotificationRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}