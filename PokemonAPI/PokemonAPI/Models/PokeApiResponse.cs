namespace PokemonAPI.Models;

public class PokeApiResponse<T>
{
    public string ResultJson { get; set; }

    public T ResultValue { get; set; }
}