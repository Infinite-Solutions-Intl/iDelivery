using iDelivery.Domain.AccountAggregate;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iDelivery.Infrastructure.Persistence.Configurations;

internal class AccountConfigurations : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        ConfigureAccountTable(builder);
        ConfigureUsersTable(builder);
        ConfigureAccountSubscriptionsTable(builder);
    }

    private static void ConfigureAccountTable(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => AccountId.Create(value)
            );
        builder.Property(a => a.Password)
            .HasConversion(
                pwd => pwd.Value,
                value => Password.Create(value)
            );
        builder.Property(a => a.Email)
            .HasConversion(
                email => email.Value,
                value => Email.Create(value)
            );
        builder.HasIndex(a => a.Email);
        builder.HasIndex(a => a.ApiKey);
        builder.Property(a => a.PhoneNumber)
            .HasConversion(
                phone => phone.Value,
                value => PhoneNumber.Create(value)
            );
        builder.Property(a => a.Name)
            .HasMaxLength(100);
    }

    private static void ConfigureUsersTable(EntityTypeBuilder<Account> builder)
    {
        builder.OwnsMany(a => a.Users, ub => 
        {
            ub.ToTable("Users");
            ub.WithOwner().HasForeignKey(u => u.AccountId);
            ub.HasKey(u => u.Id);
            ub.Property(u => u.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value)
                );
            ub.HasKey(u => u.Id);
            ub.Property(u => u.Password)
                .HasConversion(
                    pwd => pwd.Value,
                    value => Password.Create(value)
                );
            ub.Property(u => u.Email)
                .HasConversion(
                    email => email.Value,
                    value => Email.Create(value)
                );
            ub.HasIndex(u => u.Email);
            ub.Property(u => u.PhoneNumber)
                .HasConversion(
                    phone => phone.Value,
                    value => PhoneNumber.Create(value)
                );
            ub.Property(u => u.Name)
                .HasMaxLength(100);
            ub.Property(u => u.AccountId)
                .HasConversion(
                    id => id.Value,
                    value => AccountId.Create(value)
                );
        });

        builder.Navigation(a => a.Users).Metadata.SetField("_users");
        builder.Metadata.FindNavigation(nameof(Account.Users))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureAccountSubscriptionsTable(EntityTypeBuilder<Account> builder)
    {
        builder
            .HasMany(a => a.Subscriptions)
            .WithOne(s => s.Account)
            .HasForeignKey(s => s.AccountId);
        builder.Navigation(a => a.Subscriptions).Metadata.SetField("_subscriptions");
        builder.Metadata.FindNavigation(nameof(Account.Subscriptions))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
