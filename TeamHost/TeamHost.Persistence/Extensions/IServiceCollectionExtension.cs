using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeamHost.Application.Interfaces.Repositories;
using TeamHost.Persistence.Contexts;
using TeamHost.Persistence.Repositories;

namespace TeamHost.Persistence.Extensions;

public static class IServiceCollectionExtension
{
    public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddDbContext<AppDbContext>(opt =>
                opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")))
            .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
            .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
            .AddTransient<IGameRepository, GameRepository>();
    } 
}