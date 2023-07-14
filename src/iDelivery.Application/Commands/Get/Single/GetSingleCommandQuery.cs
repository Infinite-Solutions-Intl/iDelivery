namespace iDelivery.Application.Commands.Get.Single;

public sealed record GetSingleCommandQuery(
    Guid CommandId
) : IRequest<Result<CommandResponse>>;
