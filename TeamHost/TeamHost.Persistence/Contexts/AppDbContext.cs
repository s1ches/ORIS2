using Microsoft.EntityFrameworkCore;
using TeamHost.Domain.Entities;

namespace TeamHost.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Company> Companies { get; set; }
    
    public DbSet<Country> Countries { get; set; }
    
    public DbSet<Platform> Platforms { get; set; }
    
    public DbSet<StaticFile> StaticFiles { get; set; }
    
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Game> Games { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}