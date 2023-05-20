using iDelivery.Application.Authentication.Services;
using iDelivery.Application.Repositories;
using iDelivery.Infrastructure.Authentication;
using iDelivery.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace iDelivery.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IAccountRepository, AccountRepository>();
        services.AddSingleton<IUserRepository,UserRepository>();
        return services;
    }
}
