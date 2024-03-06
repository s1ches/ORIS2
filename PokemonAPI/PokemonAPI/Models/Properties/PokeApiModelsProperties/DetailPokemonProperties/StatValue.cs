using System.Text.Json.Serialization;

namespace PokemonAPI.Models.Properties.PokeApiModelsProperties.DetailPokemonProperties;

public class StatValue
{
    [JsonPropertyName("name")]
    public string StatName { get; set; }
}