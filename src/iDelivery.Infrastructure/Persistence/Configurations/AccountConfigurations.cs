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
        builder.Property(a => a.PhoneNumber)
            .HasConversion(
                phone => phone.Value,
                value => PhoneNumber.Create(value)
            );
        builder.Property(a => a.Name)
            .HasMaxLength(100);
        builder.HasIndex(a => a.Email);
        builder.HasIndex(a => a.ApiKey);
        builder.HasIndex(u => u.PhoneNumber);
    }

    private static void ConfigureUsersTable(EntityTypeBuilder<Account> builder)
    {
        builder.HasMany(a => a.Users).WithOne(u => u.Account).HasForeignKey(u => u.AccountId);

        builder.Navigation(a => a.Users).Metadata.SetField("_users");
        builder.Metadata.FindNavigation(nameof(Account.Users))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigureAccountSubscriptionsTable(EntityTypeBuilder<Account> builder)
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
