using iDelivery.Domain.PlanAggregate;
using iDelivery.Domain.PlanAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iDelivery.Infrastructure.Persistence.Configurations;

internal class PlanConfigurations : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.ToTable("Plans");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => PlanId.Create(value)
            );
        builder.Property(p => p.Price)
            .HasPrecision(18, 2);
        builder.HasMany(p => p.Subscriptions).WithOne(s => s.Plan).HasForeignKey(s => s.PlanId);
    }
}
