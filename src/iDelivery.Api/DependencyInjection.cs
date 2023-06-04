using System.Text;
using iDelivery.Api.Mappings.DependencyInjection;
using iDelivery.Domain.Common.Utilities;
using iDelivery.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace iDelivery.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        // Add Authentication Support
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => 
            {
                var jwtSettings = configuration.GetSection(JwtSettings.SectionName).Get<JwtSettings>();
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    ValidateLifetime = true,
                    ValidateIssuer = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                };
            });
        
        services.AddAuthorization(options => 
        {
            options.AddPolicy(Policies.SuperAdminOnly, policy =>
            {
                policy.RequireRole(Roles.SuperAdmin);
            });
            options.AddPolicy(Policies.AdminOnly, policy =>
            {
                policy.RequireRole(Roles.Admin);
            });
            options.AddPolicy(Policies.SupervisorOnly, policy =>
            {
                policy.RequireRole(Roles.Supervisor);
            });
            options.AddPolicy(Policies.RunnerOnly, policy =>
            {
                policy.RequireRole(Roles.Runner);
            });
        });
        
        services.AddControllers();
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddMappings();
        return services;
    }
}
