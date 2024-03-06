using PokemonAPI.Interfaces;
using PokemonAPI.Models.PokeApiModels;

namespace PokemonAPI.Models.DTOs;

public class PokemonDto: IMapWith<Pokemon, PokemonDto>
{
    /// <summary>
    /// Pokemon Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Pokemon Name
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Pokemon image url
    /// </summary>
    public Uri ImageUrl { get; set; }

    /// <summary>
    /// Pokemon Types List
    /// </summary>
    public List<string> Types { get; set; }
    
    public static PokemonDto Map(Pokemon entity)
    {
        if (entity is null)
            throw new NullReferenceException($"{nameof(PokemonDto)} object is null, it can not be mapped");

        return new PokemonDto
        {
            Id = entity.Id,
            Name = entity.Name,
            ImageUrl = entity.Sprites.OtherSprites.HomeSprites.DefaultSpriteUrl,
            Types = entity.Types.Select(type => type.TypeValue.TypeName).ToList()
        };
    }
}