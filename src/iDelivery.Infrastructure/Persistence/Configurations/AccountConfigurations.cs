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
        ConfigureUserIdsTable(builder);
    }

    private void ConfigureUserIdsTable(EntityTypeBuilder<Account> builder)
    {
        builder.OwnsMany(a => a.UserIds, uib => 
        {
            uib.ToTable("AccountUserIds");

            uib.WithOwner().HasForeignKey("AccountId");

            uib.HasKey("Id");

            uib.Property(id => id.Id)
                .HasColumnName("UserId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Account.UserIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureAccountTable(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Id,
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
}
