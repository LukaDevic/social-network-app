using SocialNetworkApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetworkApp.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Attendance> GetFutureAttendances(string userId)
        {
            return _context.Attendances
                            .Where(a => a.AttendeeId == userId && a.Concert.DateTime > DateTime.Now)
                            .ToList();
        }

        public Attendance GetAttendance(int id, string userId)
        {
            return _context.Attendances.SingleOrDefault(a => a.ConcertId == id && a.AttendeeId == userId);
        }
    }
}