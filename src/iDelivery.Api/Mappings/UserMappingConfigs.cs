using iDelivery.Application.Users;
using iDelivery.Application.Users.Add;
using iDelivery.Application.Users.UpdateRole;
using iDelivery.Contracts.Users;
using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.CourierAggregate;
using iDelivery.Domain.SupervisorAggregate;
using Mapster;

namespace iDelivery.Api.Mappings;

public class UserMappingConfigs : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // src -> dest
        config.NewConfig<(Guid AccountId, UserDto UserDto), AddUserCommand>()
            .Map(dest => dest.AccountId, src => src.AccountId)
            .Map(dest => dest, src => src.UserDto);

        config.NewConfig<(Guid AccountId, UpdateRoleRequest Request), ChangeRoleCommand>()
            .Map(dest => dest.AccountId, src => src.AccountId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<User, UserResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.AccountId, src => src.AccountId.Value)
            .Map(dest => dest.Email, src => src.Email.Value)
            .Map(dest => dest.Password, src => src.Password.Value)
            .Map(dest => dest.PhoneNumber, src => src.PhoneNumber.Value);

        config.NewConfig<Supervisor, UserResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.AccountId, src => src.AccountId.Value)
            .Map(dest => dest.Email, src => src.Email.Value)
            .Map(dest => dest.Password, src => src.Password.Value)
            .Map(dest => dest.PhoneNumber, src => src.PhoneNumber.Value);

        config.NewConfig<Courier, UserResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.AccountId, src => src.AccountId.Value)
            .Map(dest => dest.Email, src => src.Email.Value)
            .Map(dest => dest.Password, src => src.Password.Value)
            .Map(dest => dest.PhoneNumber, src => src.PhoneNumber.Value)
            .Map(dest => dest.SupervisorId, src => src.SupervisorId.Value);
    }
}
