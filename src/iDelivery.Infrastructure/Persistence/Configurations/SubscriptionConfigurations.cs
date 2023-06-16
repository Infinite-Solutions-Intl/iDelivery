using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.Common.ValueObjects;
using iDelivery.Domain.PlanAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iDelivery.Infrastructure.Persistence.Configurations;

internal class SubscriptionConfigurations : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => SubscriptionId.Create(value)
            );
        builder.Property(s => s.PlanId)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => PlanId.Create(value)
            );
        builder.Property(s => s.AccountId)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => AccountId.Create(value)
            );
    }
}
