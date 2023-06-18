using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iDelivery.Infrastructure.Persistence.Configurations;

internal class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        // builder.WithOwner().HasForeignKey(u => u.AccountId);
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value)
            );
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Password)
            .HasConversion(
                pwd => pwd.Value,
                value => Password.Create(value)
            );
        builder.Property(u => u.Email)
            .HasConversion(
                email => email.Value,
                value => Email.Create(value)
            );
        builder.HasIndex(u => u.Email);
        builder.Property(u => u.PhoneNumber)
            .HasConversion(
                phone => phone.Value,
                value => PhoneNumber.Create(value)
            );
        builder.Property(u => u.Name)
            .HasMaxLength(100);
        builder.Property(u => u.AccountId)
            .HasConversion(
                id => id.Value,
                value => AccountId.Create(value)
            );
    }
}
