namespace iDelivery.Application.Commands.Get;

public sealed record GetCommandQuery(
    string? SearchTerm,
    string? SortColumn,
    string? SortOrder,
    DateTime? StartDate,
    DateTime? EndDate,
    int? Page,
    int? PageSize) : IRequest<Result<PageList<CommandResponse>>>;