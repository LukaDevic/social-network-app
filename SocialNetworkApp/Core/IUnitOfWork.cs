using SocialNetworkApp.Core.Repositories;

namespace SocialNetworkApp.Core
{
    public interface IUnitOfWork
    {
        IAttendanceRepository Attendances { get; }
        IConcertRepository Concerts { get; }
        IFollowingRepository Followings { get; }
        IGenreRepository Genres { get; }
        IApplicationUserRepository Users { get; }
        INotificationRepository Notifications { get; }
        IUserNotificationRepository UserNotifications { get; }

        void Complete();
    }
}