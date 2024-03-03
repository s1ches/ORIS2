using System.Text.Json.Serialization;

namespace PokemonAPI.Models;

public class Others
{
    [JsonPropertyName("home")]
    public Home HomeSprites { get; set; }
}