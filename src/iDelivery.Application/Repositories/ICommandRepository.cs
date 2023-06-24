using iDelivery.Application.Repositories.Common;
using iDelivery.Domain.CommandAggregate;
using iDelivery.Domain.CommandAggregate.Enums;
using iDelivery.Domain.CommandAggregate.ValueObjects;

namespace iDelivery.Application.Repositories;

public interface ICommandRepository : IRepository<Command, CommandId>
{
    Task<Command> UpdateStatusAsync(CommandId id, Status status);
    Task<Command> UpdateCommandAsync(Command command);
}