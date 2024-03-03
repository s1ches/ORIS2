using System.Text.Json.Serialization;

namespace PokemonAPI.Models;

public class Home
{
    [JsonPropertyName("front_default")]
    public Uri DefaultSpriteUrl { get; set; }
}