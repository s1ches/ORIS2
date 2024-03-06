using System.Text.Json.Serialization;

namespace PokemonAPI.Models.Properties.PokeApiModelsProperties.PokemonProperties;

public class Home
{
    [JsonPropertyName("front_default")]
    public Uri DefaultSpriteUrl { get; set; }
}