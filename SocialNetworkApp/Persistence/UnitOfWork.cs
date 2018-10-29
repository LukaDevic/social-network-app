using SocialNetworkApp.Models;
using SocialNetworkApp.Repositories;

namespace SocialNetworkApp.Persistence
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ConcertRepository Concerts { get; private set; }

        public AttendanceRepository Attendances { get; private set; }

        public FollowingRepository Followings { get; set; }

        public GenreRepository Genres { get; set; }

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