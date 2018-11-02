using SocialNetworkApp.Core.Models;
using System.Collections.Generic;

namespace SocialNetworkApp.Core.Repositories
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendance> GetFutureAttendances(string userId);
        Attendance GetAttendance(int id, string userId);
        void Add(Attendance attendance);
        void Remove(Attendance attendance);
    }
}