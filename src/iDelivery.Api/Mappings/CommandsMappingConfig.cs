using iDelivery.Application.Commands;
using iDelivery.Application.Commands.Add;
using iDelivery.Application.Commands.Update.UpdateDetails;
using iDelivery.Contracts.Commands;
using iDelivery.Domain.CommandAggregate;
using iDelivery.Domain.CommandAggregate.Entities;
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

        config.NewConfig<DeliveryStatus, DeliveryStatusResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.CommandId, src => src.CommandId.Value)
            .Map(dest => dest.Status, src => (int)src.Status);

        config.NewConfig<Command, CommandResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(
                dest => dest.Statuses, 
                src => src.DeliveryStatuses);
    }
}
