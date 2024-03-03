using System.Text.Json.Serialization;

namespace PokemonAPI.Models;

public class Sprites
{
    [JsonPropertyName("other")]
    public Others OtherSprites { get; set; }
}