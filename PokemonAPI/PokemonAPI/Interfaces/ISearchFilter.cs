namespace PokemonAPI.Interfaces;


public interface ISearchFilter<T>
{
    public IEnumerable<T> GetFiltered(string filter, int count, int page,
        IEnumerable<T> enumerable);
}