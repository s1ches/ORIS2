using Microsoft.EntityFrameworkCore;
using PokemonAPI.DAL.Entities;

namespace PokemonAPI.DAL.Repositories;

public class PokemonRepository(IDbContext dbContext) : IRepository<Pokemon, int>
{
    public IEnumerable<Pokemon> GetAllAsync()
    {
        foreach (var pokemon in dbContext.Pokemons)
            yield return pokemon;
    }

    public async Task<Pokemon> GetByIdAsync(int id,
        CancellationToken cancellationToken = default)
    {
        var result = await dbContext.Pokemons.FirstOrDefaultAsync(x => x.Id == id,
                cancellationToken) 
                 ?? throw new Exception($"Pokemon by id: {id} was not found");
        
        result.Abilities = await dbContext.Abilities.Where(x => x.PokemonId == result.Id)
            .ToListAsync(cancellationToken: cancellationToken);
            
        result.Moves = await dbContext.Moves.Where(x => x.PokemonId == result.Id)
            .ToListAsync(cancellationToken: cancellationToken);
            
        result.Types = await dbContext.Types.Where(x => x.PokemonId == result.Id)
            .ToListAsync(cancellationToken: cancellationToken);
            
        result.Breeding = await dbContext.Breedings.FirstOrDefaultAsync(x => x.PokemonId == result.Id,
            cancellationToken: cancellationToken);
            
        result.Stats = await dbContext.Stats.Where(x => x.PokemonId == result.Id)
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }

    public async Task<int> InsertAsync(Pokemon entity, CancellationToken cancellationToken = default)
    {
        if (entity.Id == default)
            entity.Id = dbContext.Pokemons.Select(x => x.Id).Max() + 1;
        else if (await dbContext.Pokemons.AnyAsync(x => x.Id == entity.Id, cancellationToken))
            throw new Exception($"Pokemon with the same id already exist");
            
        await dbContext.Pokemons.AddAsync(entity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<int> UpdateAsync(Pokemon entity, CancellationToken cancellationToken = default)
    {
        var updatePokemon = await dbContext.Pokemons
            .FirstOrDefaultAsync(x => x.Id == entity.Id, cancellationToken);
       
        if (updatePokemon is null)
            throw new Exception($"Pokemon with id {entity.Id} which you want to update was not found");

        updatePokemon.Name = entity.Name;
        updatePokemon.ImageUrl = entity.ImageUrl;
        
        await dbContext.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<int> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var pokemon = await dbContext.Pokemons
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        
        if (pokemon is null)
            throw new Exception($"Pokemon with id {id} which you want to delete was not found");

        dbContext.Pokemons.Remove(pokemon);
        await dbContext.SaveChangesAsync(cancellationToken);
        return pokemon.Id;
    }
}