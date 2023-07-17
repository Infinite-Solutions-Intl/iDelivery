using System.Linq.Expressions;
using iDelivery.Domain.CommandAggregate;

namespace iDelivery.Application.Commands.Get.All;
public sealed class GetCommandQueryHandler : IRequestHandler<GetCommandQuery, Result<PageList<CommandResponse>>>
{
    private readonly ICommandRepository _commandRepository;
    private IMapper _mapper;

    public GetCommandQueryHandler(
        ICommandRepository commandRepository,
        IMapper mapper)
    {
        _commandRepository = commandRepository;
        _mapper = mapper;
    }

    public Task<Result<PageList<CommandResponse>>> Handle(GetCommandQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Command> query = _commandRepository.CommandsQuery();
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            query = query.Where(c =>
                c.RefNum.Contains(request.SearchTerm) ||
                c.Intitule.Contains(request.SearchTerm));
        }

        if (request.StartDate is not null)
        {
            DateTime end = request.EndDate ?? DateTime.Now;
            query.Where(c =>
                c.PreferredDate > request.StartDate &&
                c.PreferredDate < end);
        }

        if (request.SortOrder?.ToLower() == "desc")
        {
            query = query.OrderByDescending(GetSortProperty(request.SortColumn ?? string.Empty));
        }
        else
        {
            query = query.OrderBy(GetSortProperty(request.SortColumn ?? string.Empty));
        }

        IQueryable<CommandResponse> queryResp = query.Select(
            c => _mapper.Map<CommandResponse>(c));

        //IQueryable<CommandResponse> queryResp = query.Select(c => new CommandResponse(
        //    c.Id.Value,
        //    c.RefNum,
        //    c.Intitule,
        //    c.City,
        //    c.Quarter,
        //    c.Longitude,
        //    c.Latitude,
        //    c.DeliveryStatuses.Select(ds => new DeliveryStatusResponse(
        //        ds.Id.Value,
        //        ds.CommandId.Value,
        //        (int)ds.Status,
        //        ds.Date,
        //        ds.Message
        //    )).ToArray(),
        //    c.PreferredDate,
        //    c.PreferredTime
        //));

        int page = request.Page ?? 1;
        int pageSize = request.PageSize ?? queryResp.Count();
        var commands = PageList<CommandResponse>.Create(queryResp,
            page,
            pageSize);

        return Task.FromResult(Result.Ok(commands));
    }

    private static Expression<Func<Command, object>> GetSortProperty(string sortColumn) =>
        sortColumn?.ToLower() switch
        {
            "refNum" => command => command.RefNum,
            "intitule" => command => command.Intitule,
            "city" => command => command.City,
            "quarter" => command => command.Quarter,
            "preferred_date" => command => command.PreferredDate,
            "preferred_time" => command => command.PreferredTime,
            _ => command => command.Id
        };
}
