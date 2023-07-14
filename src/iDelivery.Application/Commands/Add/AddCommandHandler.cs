using iDelivery.Domain.CommandAggregate;
using iDelivery.Domain.CommandAggregate.Events;
using Microsoft.Extensions.Logging;

namespace iDelivery.Application.Commands.Add;
public sealed class AddCommandHandler : IRequestHandler<AddCommand, Result<CommandResponse>>
{
    private readonly ICommandRepository _commandRepository;
    private readonly ILogger<AddCommandHandler> _logger;

    public AddCommandHandler(
        ICommandRepository commandRepository,
        ILogger<AddCommandHandler> logger)
    {
        _commandRepository = commandRepository;
        _logger = logger;
    }

    public async Task<Result<CommandResponse>> Handle(AddCommand request, CancellationToken cancellationToken)
    {
        DateTime dateTime= DateTime.Now;

        Command command = Command.Create(
            request.RefNum,
            request.Intitule,
            request.City,
            request.Quarter,
            request.Latitude,
            request.Longitude,
            dateTime,
            request.PreferredDate,
            request.PreferredTime
        );

        try
        {
            await _commandRepository.AddAsync(command, cancellationToken);

            // TODO: Publish the command added event
            command.RaiseDomainEvent(new CommandCreated(command.Id, command.CreatedDate));

            return new CommandResponse(
                command.Id.Value,
                command.RefNum,
                command.Intitule,
                command.City,
                command.Quarter,
                command.Longitude,
                command.Latitude,
                command.DeliveryStatuses.Select(ds => new DeliveryStatusResponse(
                    ds.Id.Value,
                    ds.CommandId.Value,
                    (int) ds.Status,
                    ds.Date,
                    ds.Message
                )).ToArray(),
                request.PreferredDate,
                request.PreferredTime
            );
        }
        catch (Exception e)
        {
            _logger.LogError("Error: {e}", e);
            return Result.Fail(new AddCommandError());
        }        
    }
}
