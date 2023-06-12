using iDelivery.Application.Authentication.Services;
using iDelivery.Application.Repositories;
using iDelivery.Infrastructure.Authentication;
using iDelivery.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace iDelivery.Infrastructure.Persistence;

internal static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlite(configuration.GetConnectionString("SqlServerDb")));
        services.AddScoped<IApiKeyGenerator, ApiKeyGenerator>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IUserRepository,UserRepository>();
        return services;
    }
}
