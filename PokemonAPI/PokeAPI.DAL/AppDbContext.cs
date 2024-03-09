using Microsoft.EntityFrameworkCore;
using PokeAPI.DAL.Entities;

namespace PokeAPI.DAL;

public class AppDbContext: DbContext
{
    public DbSet<Breeding> Breedings { get; set; }
    
    public DbSet<Pokemon> Pokemons { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
}