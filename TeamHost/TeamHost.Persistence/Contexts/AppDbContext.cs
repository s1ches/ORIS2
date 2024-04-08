using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeamHost.Application.Interfaces;
using TeamHost.Domain.Entities;

namespace TeamHost.Persistence.Contexts;

public class AppDbContext : IdentityDbContext, IAppDbContext
{
    public DbSet<Company> Companies { get; set; }
    
    public DbSet<Country> Countries { get; set; }
    
    public DbSet<Platform> Platforms { get; set; }
    
    public DbSet<StaticFile> StaticFiles { get; set; }
    
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Game> Games { get; set; }
    
    public DbSet<UserInfo> UserInfos { get; set; }

    public AppDbContext()
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=postgres;Database=TeamHost");
    }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        base.OnModelCreating(modelBuilder);
    }
}