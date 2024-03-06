using PokemonAPI.Interfaces;
using PokemonAPI.Models.Properties.PokemonInfoProperties;

namespace PokemonAPI.Services;
/// <summary>
/// Responsible for filtering pokemons
/// </summary>
public class SearchFilter : ISearchFilter<PokemonInfo>
{
    /// <summary>
    /// Full Name Match filtering
    /// </summary>
    private static readonly Func<PokemonInfo, string, bool> FullNameMatchPredicate = (pokemon, filter) =>
        pokemon.PokemonName.Equals(filter, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Starts with Name Match filtering 
    /// </summary>
    private static readonly Func<PokemonInfo, string, bool> StartsWithNameMatchPredicate = (pokemon, filter) =>
        pokemon.PokemonName.StartsWith(filter, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Contains Name Match filtering
    /// </summary>
    private static readonly Func<PokemonInfo, string, bool> ContainsNameMatchPredicate = (pokemon, filter) =>
        pokemon.PokemonName.Contains(filter, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Filtering Method
    /// </summary>
    /// <param name="enumerable">List of pokemons</param>
    /// <param name="predicate">filtering function</param>
    /// <param name="filter">search value</param>
    /// <param name="skip">count of skipped values</param>
    /// <param name="take">count of taked value</param>
    /// <returns>Filtered pokemons by 1 filtering function</returns>
    private static IEnumerable<PokemonInfo> GetFilteredBy(IEnumerable<PokemonInfo> enumerable,
        Func<PokemonInfo, string, bool> predicate, string filter, int skip,
        int take) => enumerable.Where(pokemon => predicate(pokemon, filter)).Skip(skip).Take(take);

    /// <summary>
    /// Responsible for filtering pokemons list
    /// </summary>
    /// <param name="filter">Search parameter for filtering pokemons</param>
    /// <param name="count">Count of pokemons need</param>
    /// <param name="page">Page of pokemons</param>
    /// <param name="enumerable">List of pokemons</param>
    /// <returns>Filtered pokemons list</returns>
    public IEnumerable<PokemonInfo> GetFiltered(string filter, int count, int page, IEnumerable<PokemonInfo> enumerable)
    {
        var pokemonsFoundCount = 0;

        var fullNameMatch =
            GetFilteredBy(enumerable, FullNameMatchPredicate, filter, count * page, count).ToList();

        pokemonsFoundCount += fullNameMatch.Count;

        if (pokemonsFoundCount == count) return fullNameMatch;

        var startsWithNameMatch =
            GetFilteredBy(enumerable.Except(fullNameMatch), StartsWithNameMatchPredicate, filter,
                count * page + pokemonsFoundCount,
                count - pokemonsFoundCount).ToList();

        pokemonsFoundCount += startsWithNameMatch.Count;

        if (pokemonsFoundCount == count) return fullNameMatch.Concat(startsWithNameMatch);

        var containsNameMatch =
            GetFilteredBy(enumerable.Except(fullNameMatch).Except(startsWithNameMatch), ContainsNameMatchPredicate,
                filter, count * page + pokemonsFoundCount,
                count - pokemonsFoundCount).ToList();

        return fullNameMatch.Concat(startsWithNameMatch).Concat(containsNameMatch);
    }
}