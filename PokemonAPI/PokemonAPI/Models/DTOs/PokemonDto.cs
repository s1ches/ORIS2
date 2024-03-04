namespace PokemonAPI.Models.DTOs;

public class PokemonDto
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public Uri ImageUrl { get; set; }

    public List<string> Types { get; set; }
}