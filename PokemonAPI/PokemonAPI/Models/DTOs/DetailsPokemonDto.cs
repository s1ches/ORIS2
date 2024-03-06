using PokemonAPI.Interfaces;
using PokemonAPI.Models.PokeApiModels;
using PokemonAPI.Models.Properties.DtosProperties;

namespace PokemonAPI.Models.DTOs;

public class DetailsPokemonDto: PokemonDto, IMapWith<Pokemon, DetailsPokemonDto>
{
    /// <summary>
    /// Pokemon Height in decimeters
    /// </summary>
    public int Height { get; set; } 
        
    /// <summary>
    /// Pokemon weight in kilograms
    /// </summary>
    public int Weight { get; set; }
    
    /// <summary>
    /// Pokemon abilities list
    /// </summary>
    public List<string> Abilities { get; set; }
    
    /// <summary>
    /// Pokemon Moves List
    /// </summary>
    public List<string> Moves { get; set; }
    
    /// <summary>
    /// Pokemon Stats List
    /// </summary>
    public List<StatDto> Stats { get; set; }
    
    public static DetailsPokemonDto Map(Pokemon entity)
    {
        if (entity is null)
            throw new NullReferenceException($"{nameof(DetailsPokemonDto)} object is null, it can not be mapped");

        return new DetailsPokemonDto
        {
            Id = entity.Id,
            Name = entity.Name,
            ImageUrl = entity.Sprites.OtherSprites.HomeSprites.DefaultSpriteUrl,
            Types = entity.Types.Select(type => type.TypeValue.TypeName).ToList(),
            Weight = entity.Weight,
            Height = entity.Height,
            Abilities = entity.Abilities.Select(ability => ability.AbilityValue.AbilityName).ToList(),
            Moves = entity.Moves.Select(move => move.MoveValue.MoveName).ToList(),
            Stats = entity.Stats.Select(stat => new StatDto(stat.StatValue.StatName, stat.BaseStat)).ToList()
        };
    }
}