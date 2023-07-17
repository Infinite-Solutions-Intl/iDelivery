using iDelivery.Domain.CommandAggregate;
using iDelivery.Domain.CommandAggregate.ValueObjects;

namespace iDelivery.Application.Commands.Get.Single;

public class GetSingleCommandQueryHandler : IRequestHandler<GetSingleCommandQuery, Result<CommandResponse>>
{
    private readonly ICommandRepository _commandRepository;
    private readonly IMapper _mapper;

    public GetSingleCommandQueryHandler(
        ICommandRepository commandRepository,
        IMapper mapper)
    {
        _commandRepository = commandRepository;
        _mapper = mapper;
    }

    public async Task<Result<CommandResponse>> Handle(GetSingleCommandQuery request, CancellationToken cancellationToken)
    {
        CommandId commandId = CommandId.Create(request.CommandId);
        Command? command = await _commandRepository.GetByIdAsync(commandId, cancellationToken);
        if(command is null)
            return Result.Fail("Command not found!");

        return _mapper.Map<CommandResponse>(command);
    }
}
