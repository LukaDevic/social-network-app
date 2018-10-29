using SocialNetworkApp.Repositories;

namespace SocialNetworkApp.Persistence
{
    public interface IUnitOfWork
    {
        IAttendanceRepository Attendances { get; }
        IConcertRepository Concerts { get; }
        IFollowingRepository Followings { get; set; }
        IGenreRepository Genres { get; set; }

        void Complete();
    }
}