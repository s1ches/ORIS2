using System.Text.Json.Serialization;
using PokemonAPI.Interfaces;
using PokemonAPI.Models.DTOs;
using PokemonAPI.Models.Properties.DtosProperties;

namespace PokemonAPI.Models;

public class Pokemon: ICanMap<DetailsPokemonDto>, ICanMap<PokemonDto>
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("sprites")]
    public Sprites Sprites { get; set; }

    [JsonPropertyName("types")]
    public List<Type> Types { get; set; }
    
    [JsonPropertyName("height")]
    public int Height { get; set; } 
        
    [JsonPropertyName("weight")]
    public int Weight { get; set; }
    
    [JsonPropertyName("abilities")]
    public List<Ability> Abilities { get; set; }
    
    [JsonPropertyName("moves")]
    public List<Move> Moves { get; set; }
    
    [JsonPropertyName("stats")]
    public List<Stat> Stats { get; set; }
    
    public void MapTo(DetailsPokemonDto entity)
    {
        if (entity is null)
            throw new NullReferenceException($"{nameof(DetailsPokemonDto)} object is null, it can not be mapped");
        
        entity.Id = Id;
        entity.Name = Name;
        entity.ImageUrl = Sprites.OtherSprites.HomeSprites.DefaultSpriteUrl;
        entity.Types = Types.Select(type => type.TypeValue.TypeName).ToList();
        entity.Weight = Weight;
        entity.Height = Height;
        entity.Abilities = Abilities.Select(ability => ability.AbilityValue.AbilityName).ToList();
        entity.Moves = Moves.Select(move => move.MoveValue.MoveName).ToList();
        entity.Stats = Stats.Select(stat => new StatDto(stat.StatValue.StatName, stat.BaseStat)).ToList();
    }

    public void MapTo(PokemonDto entity)
    {
        if (entity is null)
            throw new NullReferenceException($"{nameof(PokemonDto)} object is null, it can not be mapped");
        
        entity.Id = Id;
        entity.Name = Name;
        entity.ImageUrl = Sprites.OtherSprites.HomeSprites.DefaultSpriteUrl;
        entity.Types = Types.Select(type => type.TypeValue.TypeName).ToList();
    }
}