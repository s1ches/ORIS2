using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;
using InvalidCastException = System.InvalidCastException;

namespace PokemonAPI.Services;

public class PokeApiService : IPokeApiService
{
    private readonly IMemoryCache _memoryCache;

    private readonly IRequestMessageSender _messageSender;

    public PokeApiService(IMemoryCache memoryCache, IRequestMessageSender messageSender) =>
        (_memoryCache, _messageSender) = (memoryCache, messageSender);

    public async Task<DetailPokemon> GetPokemonAsync(string pokemonSearchParameter,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(pokemonSearchParameter))
            throw new ArgumentException($"Empty value was entered in {nameof(GetPokemonAsync)}" +
                                        $" method of {nameof(PokeApiService)} service");

        pokemonSearchParameter = pokemonSearchParameter.Trim().ToLower();

        if (_memoryCache.TryGetValue(pokemonSearchParameter, out var pokemon))
            return pokemon as DetailPokemon ??
                   throw new InvalidCastException("In memory cache was added not valid data");

        var requestUrl = new Uri($"https://pokeapi.co/api/v2/pokemon/{pokemonSearchParameter}/");

        var result = await SendGetRequestAndDeserializeAsyncTo<DetailPokemon>(requestUrl, cancellationToken);

        _memoryCache.Set($"{result.Id}", result);

        if(!_memoryCache.TryGetValue(result.Name, out  _))
            _memoryCache.Set($"{result.Name}", result);
        
        return result;
    }

    public async Task<List<Pokemon>> GetPokemonsByFilterAsync(string searchValue = "", int pokemonsCount = 15,
        int pageNumber = 0, CancellationToken cancellationToken = default)
    {
        searchValue = searchValue.Trim().ToLower();
        
        if (_memoryCache.TryGetValue($"list: {searchValue}", out var pokemonsList))
            return pokemonsList as List<Pokemon>
                   ?? throw new InvalidCastException("In memory cache was added not valid data");

        var allPokemons = await GetAllPokemonsInfoAsync(cancellationToken);

        var rightPokemonsInfo = allPokemons.Pokemons.
            Where(pokemon => pokemon.PokemonName.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).
            Skip(pokemonsCount * pageNumber).
            Take(pokemonsCount);

        var result = new List<Pokemon>();
        foreach (var pokemonInfo in rightPokemonsInfo)
        {
            if (!_memoryCache.TryGetValue(pokemonInfo.PokemonName.ToLower(), out Pokemon? pokemon))
                pokemon = await SendGetRequestAndDeserializeAsyncTo<Pokemon>(pokemonInfo.PokemonUrl, cancellationToken);
            
            result.Add(pokemon!);
        }

        _memoryCache.Set($"list: {searchValue}", result);

        return result;
    }

    public async Task<List<Pokemon>> GetAllPokemonsAsync(int pokemonsCount, int pageNumber, CancellationToken cancellationToken)
    {
        return await GetPokemonsByFilterAsync("", pokemonsCount, pageNumber, cancellationToken);
    }

    private async Task<PokemonsInfo> GetAllPokemonsInfoAsync(CancellationToken cancellationToken)
    {
        if (_memoryCache.TryGetValue("https://pokeapi.co/api/v2/pokemon?limit=10000&offset=0", out var allPokemonsInfo))
            return allPokemonsInfo as PokemonsInfo
                   ?? throw new InvalidCastException("In memory cache was added not valid data");

        var requestUrl = new Uri("https://pokeapi.co/api/v2/pokemon?limit=10000&offset=0");

        return await SendGetRequestAndDeserializeAsyncTo<PokemonsInfo>(requestUrl, cancellationToken);
    }

    private async Task<T> SendGetRequestAndDeserializeAsyncTo<T>(Uri requestUrl,
        CancellationToken cancellationToken = default)
        where T : class
    {
        var resulJson = await _messageSender.SendGetRequestAsync(requestUrl, cancellationToken);
        return JsonSerializer.Deserialize<T>(resulJson) ?? throw new NullReferenceException(
            $"Null {nameof(T)} was returned from {requestUrl} in {nameof(PokeApiService)} service");
    }
}