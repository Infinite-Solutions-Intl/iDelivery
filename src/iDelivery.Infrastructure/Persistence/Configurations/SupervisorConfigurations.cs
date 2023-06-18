using iDelivery.Domain.SupervisorAggregate;
using iDelivery.Domain.SupervisorAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iDelivery.Infrastructure.Persistence.Configurations;

internal class SupervisorConfigurations : IEntityTypeConfiguration<Supervisor>
{
    public void Configure(EntityTypeBuilder<Supervisor> builder)
    {
        builder.Property(m => m.Id)
            .HasConversion(
                id => id.Value,
                value => SupervisorId.Create(value)
            );

        builder.OwnsMany(m => m.CourierIds, cib => 
        {
            cib.ToTable("CourierIds");
            cib.WithOwner().HasForeignKey("SupervisorId");
            cib.HasKey("Id");
        });

        builder.Navigation(m => m.CourierIds).Metadata.SetField("_courierIds");
        builder.Metadata.FindNavigation(nameof(Supervisor.CourierIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
