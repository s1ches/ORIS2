namespace PokemonAPI.Interfaces;

/// <summary>
/// Responsible for filtering
/// </summary>
/// <typeparam name="T">Filter object</typeparam>
public interface ISearchFilter<T>
{
    /// <summary>
    /// Responsible for filtering values
    /// </summary>
    /// <param name="filter">Search parameter for filtering</param>
    /// <param name="count">Count of values need</param>
    /// <param name="page">Page of values</param>
    /// <param name="enumerable">List of values</param>
    /// <returns>Filtered list</returns>
    public IEnumerable<T> GetFiltered(string filter, int count, int page,
        IEnumerable<T> enumerable);
}