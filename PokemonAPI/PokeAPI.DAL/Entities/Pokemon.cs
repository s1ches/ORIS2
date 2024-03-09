namespace PokeAPI.DAL.Entities;

public class Pokemon
{
    public int Id { get; set; }
    
    public string Name { get; set; }
        
    public string ImageUrl { get; set; }
    
    public Breeding Breeding { get; set; }
}