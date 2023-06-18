using iDelivery.Domain.CourierAggregate;
using iDelivery.Domain.SupervisorAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iDelivery.Infrastructure.Persistence.Configurations;

internal class CourierConfigurations : IEntityTypeConfiguration<Courier>
{
    public void Configure(EntityTypeBuilder<Courier> builder)
    {
        builder.Property(c => c.SupervisorId)
            .HasConversion(
                id => id.Value,
                value => SupervisorId.Create(value)
            );
    }
}
