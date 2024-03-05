using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Interfaces;
using PokemonAPI.Models.DTOs;

namespace PokemonAPI.Controllers;

/// <summary>
/// The controller is responsible for the return of Pokemon
/// </summary>
[ApiController]
[Route("api/[controller]/[action]")]
public class PokemonController : ControllerBase
{
    private readonly IPokeApiService _pokeApiService;

    public PokemonController(IPokeApiService pokeApiService) => _pokeApiService = pokeApiService;
    
    /// <summary>
    /// Returns Details Pokemon
    /// </summary>
    /// <param name="pokemonSearchParameter">Name or Id of pokemon</param>
    /// <param name="cancellationToken"></param>
    /// <returns>DetailsPokemonDto</returns>
    /// <exception cref="ArgumentException"></exception>
    [HttpGet("{pokemonSearchParameter}")]
    public async Task<DetailsPokemonDto> GetPokemonByIdOrName(string pokemonSearchParameter,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(pokemonSearchParameter))
            throw new ArgumentException($"Empty value was entered in {nameof(GetPokemonByIdOrName)}" +
                                        $" method of {nameof(PokemonController)} endpoint");

        var pokemon = await _pokeApiService.GetPokemonAsync(pokemonSearchParameter, cancellationToken);

        return DetailsPokemonDto.Map(pokemon);
    }

    /// <summary>
    /// Returns pokemons list on specific pag by name which includes search
    /// </summary>
    /// <param name="search">A part of pokemon name</param>
    /// <param name="pokemonsCount">Number of pokemons list result length</param>
    /// <param name="pageNumber">Number of pokemons page</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Pokemons list with length = pokemonsCount on page = pageNumber by name which includes search</returns>
    [HttpGet("{search}")]
    public async Task<IEnumerable<PokemonDto>> GetPokemonsByFilter(string search,
        [FromQuery] int pokemonsCount,
        [FromQuery] int pageNumber,
        CancellationToken cancellationToken)
    {

        var pokemonsList =
            await _pokeApiService.GetPokemonsByFilterAsync(search, pokemonsCount, pageNumber, cancellationToken);

        return pokemonsList.Select(PokemonDto.Map);
    }

    /// <summary>
    /// Returns all pokemons list on specific page
    /// </summary>
    /// <param name="pokemonsCount">Number of pokemons list result length</param>
    /// <param name="pageNumber">Number of pokemons page</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Pokemons list with length = pokemonsCount on page = pageNumber</returns>
    [HttpGet]
    public async Task<IEnumerable<PokemonDto>> GetAllPokemons([FromQuery] int pokemonsCount,
        [FromQuery] int pageNumber,
        CancellationToken cancellationToken)
    {
        var pokemonsList = await _pokeApiService.GetAllPokemonsAsync(pokemonsCount, pageNumber, cancellationToken);

        return pokemonsList.Select(PokemonDto.Map);
    }
}