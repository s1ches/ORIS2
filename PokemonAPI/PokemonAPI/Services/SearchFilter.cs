using PokemonAPI.Interfaces;
using PokemonAPI.Models.Properties.PokemonInfoProperties;

namespace PokemonAPI.Services;

public class SearchFilter : ISearchFilter<PokemonInfo>
{
    private static readonly Func<PokemonInfo, string, bool> FullNameMatchPredicate = (pokemon, filter) =>
        pokemon.PokemonName.Equals(filter, StringComparison.OrdinalIgnoreCase);

    private static readonly Func<PokemonInfo, string, bool> StartsWithNameMatchPredicate = (pokemon, filter) =>
        pokemon.PokemonName.StartsWith(filter, StringComparison.OrdinalIgnoreCase);

    private static readonly Func<PokemonInfo, string, bool> ContainsNameMatchPredicate = new((pokemon, filter) =>
        pokemon.PokemonName.Contains(filter, StringComparison.OrdinalIgnoreCase));

    private static IEnumerable<PokemonInfo> GetFilteredBy(IEnumerable<PokemonInfo> enumerable,
        Func<PokemonInfo, string, bool> predicate, string filter, int skip,
        int take) => enumerable.Where(pokemon => predicate(pokemon, filter)).Skip(skip).Take(take);

    public IEnumerable<PokemonInfo> GetFiltered(string filter, int count, int page, IEnumerable<PokemonInfo> enumerable)
    {
        var pokemonsFoundCount = 0;

        var fullNameMatch =
            GetFilteredBy(enumerable, FullNameMatchPredicate, filter, count * page, count).ToList();

        pokemonsFoundCount += fullNameMatch.Count;

        if (pokemonsFoundCount == count) return fullNameMatch;

        var startsWithNameMatch =
            GetFilteredBy(enumerable, StartsWithNameMatchPredicate, filter, count * page + pokemonsFoundCount,
                count - pokemonsFoundCount).ToList();

        pokemonsFoundCount += startsWithNameMatch.Count;

        if (pokemonsFoundCount == count) return fullNameMatch.Concat(startsWithNameMatch);

        var containsNameMatch =
            GetFilteredBy(enumerable, ContainsNameMatchPredicate, filter, count * page + pokemonsFoundCount,
                count - pokemonsFoundCount).ToList();

        return fullNameMatch.Concat(startsWithNameMatch).Concat(containsNameMatch);
    }
}