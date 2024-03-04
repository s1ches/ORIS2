namespace PokemonAPI.Interfaces;

public interface ICanMap<To>
{
    public void MapTo(To entity);
}