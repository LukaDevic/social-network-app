using SocialNetworkApp.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace SocialNetworkApp.Persistence.EntityConfigurations
{
    public class NotificationConfiguration : EntityTypeConfiguration<Notification>
    {
        public NotificationConfiguration()
        {
            HasRequired(n => n.Concert);
        }
    }
}