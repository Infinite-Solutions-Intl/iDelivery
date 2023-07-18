using iDelivery.Domain.CommandAggregate.Enums;

namespace iDelivery.Application.Commands.Update.UpdateStatus;

public sealed record UpdateDeliveryStatusCommand(
    Guid CommandId,
    Guid AccountId,
    Status Status) : IRequest<Result<CommandResponse>>;
