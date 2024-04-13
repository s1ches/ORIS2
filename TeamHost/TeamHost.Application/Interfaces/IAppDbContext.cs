using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeamHost.Domain.Entities;
using TeamHost.Domain.Entities.Chats;

namespace TeamHost.Application.Interfaces;

public interface IAppDbContext
{
    public DbSet<Company> Companies { get; set; }
    
    public DbSet<Country> Countries { get; set; }
    
    public DbSet<Platform> Platforms { get; set; }
    
    public DbSet<StaticFile> StaticFiles { get; set; }
    
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Game> Games { get; set; }
    
    public DbSet<UserInfo> UserInfos { get; set; }
    
    public DbSet<IdentityUser> Users { get; set; }
    
    public DbSet<IdentityRole> Roles { get; set; }
    
    public DbSet<Message> Messages { get; set; }
    
    public DbSet<Chat> Chats { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}