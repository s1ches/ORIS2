using System.Text.Json.Serialization;

namespace PokemonAPI.Models.Properties.PokeApiModelsProperties.DetailPokemonProperties;

public class AbilityValue
{
    [JsonPropertyName("name")]
    public string AbilityName { get; set; }
}