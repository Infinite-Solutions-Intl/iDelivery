using iDelivery.Application.Commands;
using iDelivery.Application.Commands.Add;
using iDelivery.Application.Commands.Update.UpdateDetails;
using iDelivery.Contracts.Commands;
using iDelivery.Domain.CommandAggregate;
using Mapster;

namespace iDelivery.Api.Mappings;

public class CommandsMappingsConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // src ->  dest
        config.NewConfig<(Guid AccountId, AddCommandRequest Request), AddCommand>()
            .Map(dest => dest.AccountId, src => src.AccountId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<(Guid AccountId, UpdateCommandRequest Request), UpdateCommand>()
            .Map(dest => dest.AccountId, src => src.AccountId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<(Guid Id, Guid AccountId, string RefNum, UpdateCommandRequest Request), UpdateCommand>()
            .Map(dest => dest.AccountId, src => src.AccountId)
            .Map(dest => dest.RefNum, src => src.RefNum)
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Command, CommandResponse>()
            .Map(dest => dest.CommandId, src => src.Id.Value)
            .Map(
                dest => dest.Statuses, 
                src => src.DeliveryStatuses.Select(
                    ds => new DeliveryStatusResponse(
                        ds.Id.Value,
                        ds.CommandId.Value,
                        (int)ds.Status,
                        ds.Date,
                        ds.Message
                    )).ToArray());
    }
}
