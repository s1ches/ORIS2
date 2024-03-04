using PokemonAPI.Models.Properties.DtosProperties;

namespace PokemonAPI.Models.DTOs;

public class DetailsPokemonDto: PokemonDto
{
    public int Height { get; set; } 
        
    public int Weight { get; set; }
    
    public List<string> Abilities { get; set; }
    
    public List<string> Moves { get; set; }
    
    public List<StatDto> Stats { get; set; }
}