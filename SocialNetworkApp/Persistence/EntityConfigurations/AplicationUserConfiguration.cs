using SocialNetworkApp.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace SocialNetworkApp.Persistence.EntityConfigurations
{
    public class AplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public AplicationUserConfiguration()
        {
            Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            HasMany(u => u.Followers)
                .WithRequired(f => f.Followee)
                .WillCascadeOnDelete(false);

            HasMany(u => u.Followees)
                .WithRequired(f => f.Follower)
                .WillCascadeOnDelete(false);
        }
    }
}