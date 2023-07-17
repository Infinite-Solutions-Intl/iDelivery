namespace iDelivery.Application.Commands.Get.Single;

public sealed record GetSingleCommandQuery(
    Guid CommandId,
    Guid AccountId
) : IRequest<Result<CommandResponse>>;
