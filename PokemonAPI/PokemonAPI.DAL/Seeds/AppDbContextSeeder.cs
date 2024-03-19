using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using PokemonAPI.DAL.Entities;
using PokemonAPI.DAL.Seeds.PokeApiModels;
using Type = PokemonAPI.DAL.Entities.Type;

namespace PokemonAPI.DAL.Seeds;

public class AppDbContextSeeder : ISeeder
{
    private readonly IDbContext _dbContext;

    private readonly HttpClient _client;

    private readonly ILogger<AppDbContextSeeder> _logger;

    private static readonly Uri PokemonsInfoUri = new("https://pokeapi.co/api/v2/pokemon?limit=10000&offset=0");

    public AppDbContextSeeder(IDbContext dbContext, HttpClient client, ILogger<AppDbContextSeeder> logger)
    {
        _dbContext = dbContext;
        _client = client;
        _logger = logger;
    }

    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        var info = await GetFromApi<PokemonsInfo>(PokemonsInfoUri, cancellationToken);

        var pokemonsNamesFromDb = _dbContext.Pokemons.Select(pokemon => pokemon.Name)
            .ToHashSet();

        var newPokemons = info.Pokemons.Where(x =>
            !pokemonsNamesFromDb.Contains(x.PokemonName));
        
        foreach (var pokemonInfo in newPokemons)
        {
            var pokemon = await GetFromApi<PokemonFromApi>(pokemonInfo.PokemonUrl, cancellationToken)
                .ConfigureAwait(false);
            
            var dbPokemon = MapFromPokemonFromApi(pokemon);
            
            await _dbContext.Pokemons.AddAsync(dbPokemon, cancellationToken).ConfigureAwait(false);
            _logger.Log(LogLevel.Information, $"Added {pokemon.Name} with id: {pokemon.Id}");
        }

        await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    private async Task<string> SendGetRequestAsync(Uri requestUri,
        CancellationToken cancellationToken = default)
    {
        var message = new HttpRequestMessage();
        message.RequestUri = requestUri;
        message.Method = HttpMethod.Get;

        var httpResponse = await _client.SendAsync(message, cancellationToken);

        if (httpResponse.StatusCode != HttpStatusCode.OK)
            throw new HttpRequestException(
                $"{(int)httpResponse.StatusCode} by {requestUri} in {nameof(SendGetRequestAsync)}");

        return await httpResponse.Content.ReadAsStringAsync(cancellationToken);
    }

    private async Task<T> GetFromApi<T>(Uri requestUri, CancellationToken cancellationToken = default)
    {
        var resultJson = await SendGetRequestAsync(requestUri, cancellationToken);

        var result = JsonSerializer.Deserialize<T>(resultJson) ?? throw new NullReferenceException(
            $"Null {nameof(PokemonsInfo)} was returned from {requestUri} in {nameof(GetFromApi)} service");

        return result;
    }

    private static Pokemon MapFromPokemonFromApi(PokemonFromApi pokemon)
    {
        var result = new Pokemon
        {
            Id = pokemon.Id,
            Name = pokemon.Name,
            ImageUrl = pokemon.Sprites.OtherSprites.HomeSprites.DefaultSpriteUrl?.ToString() ?? string.Empty
        };

        result.Breeding = new Breeding
        {
            Id = Guid.NewGuid(),
            PokemonId = result.Id,
            Pokemon = result,
            Weight = pokemon.Weight,
            Height = pokemon.Height
        };

        result.Abilities = pokemon.Abilities.Select(x =>
            new Ability
            {
                Id = Guid.NewGuid(),
                PokemonId = result.Id,
                Pokemon = result,
                AbilityName = x.AbilityValue.AbilityName
            }).ToList();

        result.Moves = pokemon.Moves.Select(x =>
            new Move
            {
                Id = Guid.NewGuid(),
                PokemonId = result.Id,
                Pokemon = result,
                MoveName = x.MoveValue.MoveName
            }
        ).ToList();

        result.Types = pokemon.Types.Select(x =>
            new Type
            {
                Id = Guid.NewGuid(),
                PokemonId = result.Id,
                Pokemon = result,
                TypeName = x.TypeValue.TypeName
            }
        ).ToList();

        result.Stats = pokemon.Stats.Select(x =>
            new Stat
            {
                Id = Guid.NewGuid(),
                PokemonId = result.Id,
                Pokemon = result,
                StatValue = x.BaseStat,
                StatName = x.StatValue.StatName
            }
        ).ToList();

        return result;
    }
}