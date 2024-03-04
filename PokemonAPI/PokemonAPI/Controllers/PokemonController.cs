using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Extensions;
using PokemonAPI.Interfaces;
using PokemonAPI.Models.DTOs;

namespace PokemonAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class PokemonController : ControllerBase
{
    private readonly IPokeApiService _pokeApiService;

    public PokemonController(IPokeApiService pokeApiService) => _pokeApiService = pokeApiService;
    
    
    [HttpGet("{pokemonSearchParameter}")]
    public async Task<DetailsPokemonDto> GetPokemonByIdOrName(string pokemonSearchParameter,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(pokemonSearchParameter))
            throw new ArgumentException($"Empty value was entered in {nameof(GetPokemonByIdOrName)}" +
                                        $" method of {nameof(PokemonController)} endpoint");

        var pokemon = await _pokeApiService.GetPokemonAsync(pokemonSearchParameter, cancellationToken);
        var detailsPokemonDto = new DetailsPokemonDto();
        
        pokemon.MapTo(detailsPokemonDto);

        return detailsPokemonDto;
    }

    [HttpGet("{search}")]
    public async Task<IEnumerable<PokemonDto>> GetPokemonsByFilter(string search,
        [FromQuery] int pokemonsCount,
        [FromQuery] int pageNumber,
        CancellationToken cancellationToken)
    {

        var pokemonsList =
            await _pokeApiService.GetPokemonsByFilterAsync(search, pokemonsCount, pageNumber, cancellationToken);

        return pokemonsList.ToPokemonsDtosList();
    }

    [HttpGet]
    public async Task<IEnumerable<PokemonDto>> GetAllPokemons([FromQuery] int pokemonsCount,
        [FromQuery] int pageNumber,
        CancellationToken cancellationToken)
    {
        var pokemonsList = await _pokeApiService.GetAllPokemonsAsync(pokemonsCount, pageNumber, cancellationToken);

        return pokemonsList.ToPokemonsDtosList();
    }
}