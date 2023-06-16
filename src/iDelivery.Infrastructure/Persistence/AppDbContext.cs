using iDelivery.Domain.AccountAggregate;
using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.CommandAggregate;
using iDelivery.Domain.CourierAggregate;
using Microsoft.EntityFrameworkCore;

namespace iDelivery.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Command> Commands { get; set; } = null!;
    // public DbSet<Supervisor> Supervisors { get; set; } = null!;
    // public DbSet<Courier> Couriers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
