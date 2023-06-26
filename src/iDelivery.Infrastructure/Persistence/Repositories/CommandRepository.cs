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

    public async Task<Command> UpdateCommandAsync(Command command)
    {
        var cmd = await _dbContext.Commands.FirstAsync(c => c.Id == command.Id);
        cmd.Update(command);
        await _dbContext.SaveChangesAsync();
        return cmd;
    }

    public async Task<Command> UpdateStatusAsync(CommandId id, Status status)
    {
        var command = await _dbContext.Commands.FirstAsync(c => c.Id == id);
        command.UpdateStatus(status);
        await _dbContext.SaveChangesAsync();
        return command;
    }
}
