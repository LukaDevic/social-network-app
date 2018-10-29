using System.Collections.Generic;
using SocialNetworkApp.Models;

namespace SocialNetworkApp.Repositories
{
    public interface IAttendanceRepository
    {
        Attendance GetAttendance(int id, string userId);
        IEnumerable<Attendance> GetFutureAttendances(string userId);
    }
}