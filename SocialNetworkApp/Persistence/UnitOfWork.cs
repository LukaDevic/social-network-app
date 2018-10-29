using SocialNetworkApp.Models;
using SocialNetworkApp.Repositories;

namespace SocialNetworkApp.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IConcertRepository Concerts { get; private set; }

        public IAttendanceRepository Attendances { get; private set; }

        public IFollowingRepository Followings { get; set; }

        public IGenreRepository Genres { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Concerts = new ConcertRepository(context);
            Attendances = new AttendanceRepository(context);
            Followings = new FollowingRepository(context);
            Genres = new GenreRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}