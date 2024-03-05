namespace PokemonAPI.Interfaces;

public interface IMapWith<in TFrom,out TTo>
{
    public static abstract TTo Map(TFrom entity);
}