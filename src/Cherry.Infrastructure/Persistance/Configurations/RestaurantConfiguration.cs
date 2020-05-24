using Cherry.Domain.FoodAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cherry.Infrastructure.Persistance.Configurations
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(32).IsRequired(true);
            builder.OwnsOne(x => x.Address).Property(x => x.City).IsRequired(true).HasColumnName("City");
            builder.OwnsOne(x => x.Address).Property(x => x.Street).IsRequired(true).HasColumnName("Street");
            builder.OwnsOne(x => x.Address).Property(x => x.Alley).IsRequired(true).HasColumnName("Alley");
            builder.OwnsOne(x => x.Address).Property(x => x.No).IsRequired(true).HasColumnName("No");

            builder.HasMany(x => x.Foods)
                .WithOne()
                .HasForeignKey(x => x.RestaurantId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}