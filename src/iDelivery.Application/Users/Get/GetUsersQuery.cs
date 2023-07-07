namespace iDelivery.Application.Users.Get;

public sealed record GetUsersQuery(
    Guid AccountId
) : IRequest<Result<IReadOnlyList<UserResponse>>>;
