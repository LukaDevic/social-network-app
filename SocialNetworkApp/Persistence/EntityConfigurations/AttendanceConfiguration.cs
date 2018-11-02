using SocialNetworkApp.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace SocialNetworkApp.Persistence.EntityConfigurations
{
    public class AttendanceConfiguration : EntityTypeConfiguration<Attendance>
    {
        public AttendanceConfiguration()
        {
            HasKey(a => new { a.ConcertId, a.AttendeeId });
        }
    }
}