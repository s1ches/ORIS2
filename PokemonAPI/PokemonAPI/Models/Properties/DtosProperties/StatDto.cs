namespace PokemonAPI.Models.Properties.DtosProperties;

public class StatDto
{
    public StatDto(string statName, int statValue)
    {
        StatName = statName;
        StatValue = statValue;
    }

    public string StatName { get; set; }
    
    public int StatValue { get; set; }
}