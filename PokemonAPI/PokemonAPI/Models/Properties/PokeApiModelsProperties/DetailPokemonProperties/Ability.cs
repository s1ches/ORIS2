using System.Text.Json.Serialization;

namespace PokemonAPI.Models.Properties.PokeApiModelsProperties.DetailPokemonProperties;

public class Ability
{
    [JsonPropertyName("ability")]
    public AbilityValue AbilityValue { get; set; }
}