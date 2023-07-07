using iDelivery.Domain.CommandAggregate.Enums;

namespace iDelivery.Application.Commands.Update.UpdateStatus;

public sealed record UpdateDeliveryStatusCommand(
    Guid CommandId,
    Status Status) : IRequest<Result<CommandResponse>>;
