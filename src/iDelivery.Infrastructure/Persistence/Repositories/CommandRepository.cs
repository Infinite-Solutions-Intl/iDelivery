using iDelivery.Application.Repositories;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.CommandAggregate;
using iDelivery.Domain.CommandAggregate.Enums;
using iDelivery.Domain.CommandAggregate.ValueObjects;
using iDelivery.Infrastructure.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace iDelivery.Infrastructure.Persistence.Repositories;

public sealed class CommandRepository : Repository<Command, CommandId>, ICommandRepository
{
    public CommandRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task AddRangeAsync(params Command[] commands)
    {
        await _dbContext.Commands.AddRangeAsync(commands);
        await _dbContext.SaveChangesAsync();
    }

    public Task<bool> AnyAsync()
    {
        return _dbContext.Commands.AnyAsync();
    }

    public IQueryable<Command> CommandsQuery()
    {
        return _dbContext.Commands;
    }

    public async Task<IReadOnlyList<Command>> GetAllAsync(AccountId accountId, CancellationToken cancellationToken = default)
    {
        var commands = await _dbContext.Commands
            .Where(c => c.AccountId == accountId)
            .ToArrayAsync(cancellationToken);

        return commands;
    }

    public Task<Command?> GetByIdAsync(AccountId accountId, CommandId id, CancellationToken cancellationToken = default)
    {
        return _dbContext.Commands
            .FirstOrDefaultAsync(c => 
                c.Id == id &&
                c.AccountId == accountId, cancellationToken);;
    }

    public async Task<Command> UpdateCommandAsync(Command command, CancellationToken cancellationToken = default)
    {
        _dbContext.Update(command);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return command;
    }

    public async Task<Command> UpdateStatusAsync(Command command, Status status, CancellationToken cancellationToken = default)
    {
        command.UpdateStatus(status);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return command;
    }
}
