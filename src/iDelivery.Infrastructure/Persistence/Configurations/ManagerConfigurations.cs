using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.ManagerAggregate;
using iDelivery.Domain.ManagerAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iDelivery.Infrastructure.Persistence.Configurations;

internal class ManagerConfigurations : IEntityTypeConfiguration<Manager>
{
    public void Configure(EntityTypeBuilder<Manager> builder)
    {
        builder.Property(m => m.Id)
            .HasConversion(
                id => id.Value,
                value => ManagerId.Create(value)
            );
        builder.OwnsMany(m => m.ComplaintIds, cib => 
        {
            cib.ToTable("ManagerComplaintIds");
            cib.WithOwner().HasForeignKey("ManagerId");
            cib.HasKey("Id");
        });
        
        builder.Navigation(m => m.ComplaintIds).Metadata.SetField("_complaintIds");
        builder.Metadata.FindNavigation(nameof(Manager.ComplaintIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
