using iDelivery.Domain.CourierAggregate.Entities;
using iDelivery.Domain.CourierAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iDelivery.Infrastructure.Persistence.Configurations;

public sealed class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
{
    public void Configure(EntityTypeBuilder<Delivery> builder)
    {
        builder.ToTable("Deliveries");
        builder.HasKey(d => d.Id);
        builder
            .Property(d => d.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => DeliveryId.Create(value));

        builder.OwnsMany(d => d.CommandIds, cib =>
        {
            cib.ToTable("DeliveryCommandIds");
            cib.WithOwner().HasForeignKey("CourierId");
            cib.HasKey("Id");
        });

        builder.Navigation(d => d.CommandIds).Metadata.SetField("_commandIds");
        builder.Metadata.FindNavigation(nameof(Delivery.CommandIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
