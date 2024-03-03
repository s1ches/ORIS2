using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;

namespace PokemonAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class PokemonController : ControllerBase
{
    private readonly IPokeApiService _pokeApiService;

    public PokemonController(IPokeApiService pokeApiService)
    {
        _pokeApiService = pokeApiService;
    }

    // pagination, search by str 

    // FromQuery и другие виды аттрибутов сериализуют данные для передачи в контроллер, об этом париться не надо

    [HttpGet("{pokemonSearchParameter}")]
    public async Task<DetailPokemon> GetPokemonByIdOrName(string pokemonSearchParameter,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(pokemonSearchParameter))
            throw new ArgumentException($"Empty value was entered in {nameof(GetPokemonByIdOrName)}" +
                                        $" method of {nameof(PokemonController)} endpoint");

        return await _pokeApiService.GetPokemonAsync(pokemonSearchParameter, cancellationToken);
    }

    [HttpGet("{search}")]
    public async Task<IEnumerable<Pokemon>> GetPokemonsByFilter(string search,
        [FromQuery] int pokemonsCount,
        [FromQuery] int pageNumber,
        CancellationToken cancellationToken) =>
        await _pokeApiService.GetPokemonsByFilterAsync(search, pokemonsCount, pageNumber, cancellationToken);

    [HttpGet]
    public async Task<IEnumerable<Pokemon>> GetAllPokemons([FromQuery] int pokemonsCount,
        [FromQuery] int pageNumber,
        CancellationToken cancellationToken) =>
        await _pokeApiService.GetAllPokemonsAsync(pokemonsCount, pageNumber, cancellationToken);
}