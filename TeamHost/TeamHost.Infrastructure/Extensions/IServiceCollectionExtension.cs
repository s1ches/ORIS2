using Microsoft.Extensions.DependencyInjection;
using TeamHost.Application.Interfaces;
using TeamHost.Infrastructure.Services;

namespace TeamHost.Infrastructure.Extensions;

public static class IServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
    {
        return services.AddScoped<IUserClaimsManager, UserClaimsManager>();
    }
}