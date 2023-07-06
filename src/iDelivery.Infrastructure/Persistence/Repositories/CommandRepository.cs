using iDelivery.Application.Repositories;
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

    public Task<bool> AnyAsync()
    {
        return _dbContext.Commands.AnyAsync();
    }

    public IQueryable<Command> CommandsQuery()
    {
        return _dbContext.Commands;
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
