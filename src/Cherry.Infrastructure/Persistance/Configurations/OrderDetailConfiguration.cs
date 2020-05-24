using Cherry.Domain.FoodAggregate;
using Cherry.Domain.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cherry.Infrastructure.Persistance.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasOne<Food>()
                .WithMany()
                .HasForeignKey(x => x.FoodId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.OwnsOne(x => x.UnitPrice)
                .Property(x => x.Value)
                .IsRequired(true)
                .HasColumnName("UnitPrice");
        }
    }
}