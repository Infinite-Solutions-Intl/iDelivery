using iDelivery.Application.Authentication.Services;
using iDelivery.Infrastructure.Authentication;
using iDelivery.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace iDelivery.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration,
        bool isDevelopment)
    {
        services.AddSingleton(_ => configuration.GetSection(JwtSettings.SectionName).Get<JwtSettings>());
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddPersistence(configuration, isDevelopment);
        return services;
    }
}
