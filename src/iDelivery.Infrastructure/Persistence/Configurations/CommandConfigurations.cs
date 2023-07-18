using iDelivery.Domain.CommandAggregate;
using iDelivery.Domain.CommandAggregate.ValueObjects;
using iDelivery.Domain.Common.ValueObjects;
using iDelivery.Domain.ManagerAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iDelivery.Infrastructure.Persistence.Configurations;

internal class CommandConfigurations : IEntityTypeConfiguration<Command>
{
    public void Configure(EntityTypeBuilder<Command> builder)
    {
        ConfigureCommandsTable(builder);
        ConfigureDeliveryStatusTable(builder);
    }

    private static void ConfigureCommandsTable(EntityTypeBuilder<Command> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => CommandId.Create(value)
            );
        builder.HasIndex(c => c.AccountId);
        builder.HasIndex(c => c.RefNum);
        builder.HasIndex(c => c.City);
        builder.HasIndex(c => c.Latitude);
        builder.HasIndex(c => c.Longitude);
        builder.HasIndex(c => c.Quarter);
        builder.OwnsMany(c => c.Complaints, cb => 
        {
            cb.ToTable("Complaints");
            cb.WithOwner().HasForeignKey(c => c.CommandId);
            cb.HasKey(c => c.Id);
            cb.Property(c => c.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ComplaintId.Create(value)
                );
            cb.Property(c => c.CommandId)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => CommandId.Create(value)
                );
            cb.Property(c => c.ManagerId)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ManagerId.Create(value)
                );
            cb.Property(c => c.Object);
            cb.Property(c => c.Message);
            cb.Property(c => c.Status);
            cb.Property(c => c.PictureBlob);
        });
        
        builder.Navigation(c => c.Complaints).Metadata.SetField("_complaints");
        builder.Metadata.FindNavigation(nameof(Command.Complaints))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigureDeliveryStatusTable(EntityTypeBuilder<Command> builder)
    {
        builder.OwnsMany(c => c.DeliveryStatuses, dsb => 
        {
            dsb.ToTable("CommandDeliveryStatuses");
            dsb.HasKey(ds => ds.Id);
            dsb.WithOwner().HasForeignKey(ds => ds.CommandId);
            dsb.Property(ds => ds.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => DeliveryStatusId.Create(value)
                );
            dsb.Property(ds => ds.Status);
            dsb.Property(ds => ds.Date);
        });
        
        builder.Navigation(a => a.DeliveryStatuses).Metadata.SetField("_deliveryStatuses");
        builder.Metadata.FindNavigation(nameof(Command.DeliveryStatuses))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
