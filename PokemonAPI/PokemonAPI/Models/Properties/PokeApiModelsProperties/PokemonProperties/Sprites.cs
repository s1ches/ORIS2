using System.Text.Json.Serialization;

namespace PokemonAPI.Models.Properties.PokeApiModelsProperties.PokemonProperties;

public class Sprites
{
    [JsonPropertyName("other")]
    public Others OtherSprites { get; set; }
}