using SocialNetworkApp.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace SocialNetworkApp.Persistence.EntityConfigurations
{
    public class ConcertConfiguration : EntityTypeConfiguration<Concert>
    {
        public ConcertConfiguration()
        {

            Property(c => c.ArtistId)
            .IsRequired();

            Property(c => c.GenreId)
            .IsRequired();

            Property(c => c.Venue)
            .IsRequired()
            .HasMaxLength(255);

            HasMany(c => c.Attendances)
                .WithRequired(a => a.Concert)
                .WillCascadeOnDelete(false);
        }
    }
}