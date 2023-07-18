using iDelivery.Application.Authentication.Services;
using iDelivery.Application.Repositories;
using iDelivery.Application.Utilities;
using iDelivery.Domain.AccountAggregate;
using iDelivery.Domain.CommandAggregate;
using iDelivery.Domain.CommandAggregate.Entities;
using iDelivery.Domain.CommandAggregate.Enums;
using iDelivery.Infrastructure.Authentication;
using iDelivery.Infrastructure.Persistence;
using iDelivery.Infrastructure.Utilities;
using Microsoft.AspNetCore.Builder;
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
        services.AddSingleton<IHashEngine, HashEngine>();
        services.AddPersistence(configuration, isDevelopment);
        services.AddAuthentication(configuration);
        return services;
    }

    public static async void SeedData(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        ICommandRepository commandRepository = scope.ServiceProvider.GetRequiredService<ICommandRepository>();
        AppDbContext dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        if(await commandRepository.AnyAsync())
            return;

        Account? account = dbContext.Accounts.FirstOrDefault();
        if(account is null)
            return;

        var commands = new []
        {
            Command.Create(
                account.Id,
                "command1",
                "command",
                "douala",
                "Bepanda",
                12,
                14,
                new DateTime(2010, 12, 25),
                new DateTime(2011,08, 11),
                new DateTime(2011, 04, 06)
            ),
            Command.Create(
                account.Id,
                "print2",
                "impression",
                "yaounde",
                "Mokolo",
                10,
                12,
                new DateTime(1990, 04, 25),
                new DateTime(2000,08, 11),
                new DateTime(2006, 04, 06)
            ),
            Command.Create(
                account.Id,
                "formatA4",
                "format",
                "Bafoussam",
                "mbo",
                12,
                14,
                new DateTime(2010, 07, 14),
                new DateTime(2011,01, 31),
                new DateTime(2012, 01, 01)
            ),
        };

        await commandRepository.AddRangeAsync(commands);
    }
}
