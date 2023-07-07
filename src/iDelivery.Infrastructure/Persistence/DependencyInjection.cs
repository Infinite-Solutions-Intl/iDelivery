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
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration,
        bool isDevelopment)
    {
        if(isDevelopment)
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("Database"));
        else
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServerDb")));

        services.AddScoped<IApiKeyGenerator, ApiKeyGenerator>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<ICommandRepository, CommandRepository>();
        services.AddScoped<ICourierRepository, CourierRepository>();
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}
