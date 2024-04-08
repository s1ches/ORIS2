using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeamHost.Application.Interfaces;
using TeamHost.Persistence.Contexts;

namespace TeamHost.Persistence.Extensions;

public static class IServiceCollectionExtension
{
    public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        return services.AddDbContext<IAppDbContext, AppDbContext>(options =>
            options.UseNpgsql(connectionString,
                builder => builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
    } 
}