using iDelivery.Application.Authentication.Login;
using iDelivery.Contracts.Authentication;
using Mapster;

namespace iDelivery.Api.Mappings;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // config.NewConfig<TSrc,TDest>();
        config.NewConfig<(Guid AccountId,LoginRequest Request), LoginQuery>()
            .Map(dest => dest.AccountId, src => src.AccountId)
            .Map(dest => dest, src => src.Request);
    }
}
