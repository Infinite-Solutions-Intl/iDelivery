using iDelivery.Application.Authentication.Services;
using iDelivery.Application.Repositories;
using iDelivery.Infrastructure.Authentication;
using iDelivery.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace iDelivery.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton<JwtSettings>(_ => 
        {
            return configuration.GetSection(JwtSettings.SectionName).Get<JwtSettings>();
        });
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IApiKeyGenerator, ApiKeyGenerator>();
        services.AddSingleton<IAccountRepository, AccountRepository>();
        services.AddSingleton<IUserRepository,UserRepository>();
        return services;
    }
}
