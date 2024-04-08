using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace TeamHost.Application.Extensions;

public static class IServiceCollectionExtension
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        return services.AddMediatR(config => 
            config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    } 
}